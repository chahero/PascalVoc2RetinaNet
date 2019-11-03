using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace PascalVoc2RetinaNet
{
    public partial class FormConvertPascalVocToRetinaNet : Form
    {
        public FormConvertPascalVocToRetinaNet()
        {
            InitializeComponent();

            // listViewFiles 설정
            listViewFiles.View = View.Details;
            listViewFiles.GridLines = true;
            listViewFiles.FullRowSelect = true;
            listViewFiles.HeaderStyle = ColumnHeaderStyle.Clickable;
            listViewFiles.CheckBoxes = true;

            listViewFiles.Columns.Add("v", 40);
            listViewFiles.Columns.Add("file name", 150);
            listViewFiles.Columns.Add("directory", 200);
        }

        private void buttonSaveAsRetinaNetFormat_Click(object sender, EventArgs e)
        {
            int iListCount = listViewFiles.Items.Count;

            if (iListCount == 0)
            {
                MessageBox.Show("파일을 추가해 주세요");
                return;
            }
            else
            {
                // 경고 메시지
                DialogResult ret = MessageBox.Show("Filename will be overwritten. If you need, you should make a copy.", "Filename Overwritten Warning", MessageBoxButtons.YesNo);

                if (ret == DialogResult.No)
                    return;

                for (int iCount = 0; iCount < iListCount; iCount++)
                {
                    // ListView에서 이름 가져와서, 가져올 파일명 만들기
                    string fileName = listViewFiles.Items[iCount].SubItems[1].Text;
                    string directoryName = listViewFiles.Items[iCount].SubItems[2].Text;
                    string fullFileName = directoryName + "\\" + fileName;

                    // xml 파일 불러서, 파일명 바꿔서 csv로 저장
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullFileName);
                    string fullCsvName = directoryName + "\\" + fileNameWithoutExtension + ".csv";

                    // fullCsvName에 Comma이 있는지 확인
                    // csv로 저장되기 때문에, comma가 있으면 제대로 처리가 불가
                    if (fullCsvName.Contains(",") == true)
                    {
                        MessageBox.Show("{0}의 경로에 comma가 있으면 안됩니다. 경로를 수정해 주세요.", fullCsvName);
                        continue;
                    }

                    // Pascla VOC Xml 파일이 있는지 확인
                    if (File.Exists(fullFileName))
                    {
                        // Pascal VOC xml 파일 불러서 임시 정보에 저장하게
                        XmlDocument xmlLoadDoc = new XmlDocument();

                        xmlLoadDoc.Load(fullFileName);

                        XmlNodeList xmlObjectNodes = xmlLoadDoc.SelectNodes("/annotation/object");

                        StreamWriter swOutput = new StreamWriter(fullCsvName);

                        foreach (XmlNode xmlObjectNode in xmlObjectNodes)
                        {
                            // 객체 이름 가져오기
                            string objectName = xmlObjectNode.SelectSingleNode("name").InnerText;

                            // 바운딩 박스 정보 가져오기
                            XmlNode boundingBoxNode = xmlObjectNode.SelectSingleNode("bndbox");
                            int boundingBoxXmin = Convert.ToInt32(boundingBoxNode.SelectSingleNode("xmin").InnerText);
                            int boundingBoxXmax = Convert.ToInt32(boundingBoxNode.SelectSingleNode("xmax").InnerText);
                            int boundingBoxYmin = Convert.ToInt32(boundingBoxNode.SelectSingleNode("ymin").InnerText);
                            int boundingBoxYmax = Convert.ToInt32(boundingBoxNode.SelectSingleNode("ymax").InnerText);

                            // RetinaNet Annotation 형태로 저장
                            swOutput.WriteLine("{0},{1},{2},{3},{4},{5}",
                                fullCsvName,
                                boundingBoxXmin,boundingBoxYmin,boundingBoxXmax, boundingBoxYmax,
                                objectName);
                        }

                        swOutput.Close();
                    }
                }
            }

            MessageBox.Show("변환이 완료되었습니다.");
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] strFiles = (string[])(e.Data.GetData(DataFormats.FileDrop, false));

            // listview files에 추가
            AddFilesIntoListView(strFiles, ref listViewFiles);
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            bool bDesignatedFileExist = false;

            // 여러 파일 리스트를 가져옴
            string[] strFiles = (string[])(e.Data.GetData(DataFormats.FileDrop, false));

            // 여러 파일 중 하나라도 xml 파일이 있는지 확인
            foreach (string strFile in strFiles)
            {
                string strFileExtension = Path.GetExtension(strFile);
                if (strFileExtension.ToLower() == ".xml")
                {
                    bDesignatedFileExist = true;
                }
            }

            // 여러 파일 중 하나라도 xml 파일이 있으면 copy 표시
            if (bDesignatedFileExist == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // 선택된 줄들의 모음 반환
                var varSelectedCollections = listViewFiles.SelectedIndices;

                for (int i = varSelectedCollections.Count - 1; i >= 0; i--)
                {
                    int iIndex = varSelectedCollections[i];
                    listViewFiles.Items[iIndex].Remove();
                }
            }
        }

        // File List를 지정한 ListView에 추가
        private void AddFilesIntoListView(string[] strFiles, ref ListView listView)
        {
            // 가져온 파일들에 대하여 처리
            foreach (string strFile in strFiles)
            {
                string strFileExtension = Path.GetExtension(strFile);
                string fileName = Path.GetFileName(strFile);
                string directoryName = Path.GetDirectoryName(strFile);

                ListViewItem lvItem = new ListViewItem();
                          
                if (strFileExtension.ToLower() == ".xml")
                {
                    lvItem.SubItems.Add(fileName);
                    lvItem.SubItems.Add(directoryName);
                    listView.Items.Add(lvItem);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
