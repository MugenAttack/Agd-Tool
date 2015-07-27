using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace agdDecryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //convert xml to agd
            List<byte> filebyte = new List<byte>();
            filebyte.Add(0x23);
            filebyte.Add(0x41);
            filebyte.Add(0x47);
            filebyte.Add(0x44);
            filebyte.Add(0xFE);
            filebyte.Add(0xFF);
            filebyte.Add(0x10);
            filebyte.Add(0x00);

            XmlDocument xd = new XmlDocument();
            xd.Load("avatar_growth_data.xml");
            XmlNodeList levels = xd.SelectSingleNode("Data").ChildNodes;
            byte[] count = BitConverter.GetBytes(levels.Count);
            filebyte.Add(count[0]);
            filebyte.Add(count[1]);
            filebyte.Add(count[2]);
            filebyte.Add(count[3]);

            filebyte.Add(0x10);
            filebyte.Add(0x00);
            filebyte.Add(0x00);
            filebyte.Add(0x00);
            int value;
            for (int i = 0; i < levels.Count; i++)
            {
                value = int.Parse(levels.Item(i).Attributes["ID"].Value);
                count = BitConverter.GetBytes(value);
                filebyte.Add(count[0]);
                filebyte.Add(count[1]);
                filebyte.Add(count[2]);
                filebyte.Add(count[3]);

                value = int.Parse(levels.Item(i).Attributes["ExptoLevel"].Value);
                count = BitConverter.GetBytes(value);
                filebyte.Add(count[0]);
                filebyte.Add(count[1]);
                filebyte.Add(count[2]);
                filebyte.Add(count[3]);

                value = int.Parse(levels.Item(i).Attributes["RequiredExp"].Value);
                count = BitConverter.GetBytes(value);
                filebyte.Add(count[0]);
                filebyte.Add(count[1]);
                filebyte.Add(count[2]);
                filebyte.Add(count[3]);

                value = int.Parse(levels.Item(i).Attributes["AttributePoints"].Value);
                count = BitConverter.GetBytes(value);
                filebyte.Add(count[0]);
                filebyte.Add(count[1]);
                filebyte.Add(count[2]);
                filebyte.Add(count[3]);


            }


            FileStream fs = new FileStream("avatar_growth_data.agd", FileMode.Create);
            fs.Write(filebyte.ToArray(), 0, filebyte.Count);
            fs.Close();
        }

        private void toXml_Click(object sender, EventArgs e)
        {
            //convert agd to xml
            XmlWriter xw = XmlWriter.Create("avatar_growth_data.xml");
            byte[] readByte = File.ReadAllBytes("avatar_growth_data.agd");
            byte[] readFour = new byte[4];
            ReadFourBytes(ref readByte,ref readFour, 8);
            int LastID = BitConverter.ToInt32(readFour, 0);
            //MessageBox.Show(LastID.ToString());
            ReadFourBytes(ref readByte, ref readFour, 12);
            int pos = BitConverter.ToInt32(readFour, 0);
            //MessageBox.Show(pos.ToString());
            int ID = 0;
            int Value;
            xw.WriteStartDocument();
            xw.WriteStartElement("Data");
            do
            {
                xw.WriteStartElement("level");
                ReadFourBytes(ref readByte, ref readFour, pos);
                ID = BitConverter.ToInt32(readFour, 0);
                xw.WriteAttributeString("ID", Convert.ToString(ID));
                pos += 4;

                ReadFourBytes(ref readByte, ref readFour, pos);
                Value = BitConverter.ToInt32(readFour, 0);
                xw.WriteAttributeString("ExptoLevel", Convert.ToString(Value));
                pos += 4;

                ReadFourBytes(ref readByte, ref readFour, pos);
                Value = BitConverter.ToInt32(readFour, 0);
                xw.WriteAttributeString("RequiredExp", Convert.ToString(Value));
                pos+=4;

                ReadFourBytes(ref readByte, ref readFour, pos);
                Value = BitConverter.ToInt32(readFour, 0);
                xw.WriteAttributeString("AttributePoints", Convert.ToString(Value));
                pos += 4;
                xw.WriteEndElement();
           
            } while (ID != LastID);
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();
    

        }

        public void ReadFourBytes(ref byte[] Allbytes,ref byte[] Fourbytes, int pos)
        {
            for (int j= 0; j < 4; j++)
            {
                Fourbytes[j] = Allbytes[pos + j];
            }
        }
    }
}
