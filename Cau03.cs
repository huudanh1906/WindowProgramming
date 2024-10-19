using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Ex01
{
    public partial class Cau03 : Form
    {
        string path = @"D:\form03.xml"; // File path to save form size
        InfoWindows03 iw = new InfoWindows03();

        public Cau03()
        {
            InitializeComponent();
        }

        // Method to save the form size (width and height) to XML
        public void Write(InfoWindows03 iw)
        {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows03));
            StreamWriter file = new StreamWriter(path);
            writer.Serialize(file, iw);
            file.Close();
        }

        // Method to read the form size from XML and set the form's size
        public InfoWindows03 Read()
        {
            if (!File.Exists(path))
            {
                return null;
            }

            XmlSerializer reader = new XmlSerializer(typeof(InfoWindows03));
            using (StreamReader file = new StreamReader(path)) // Use StreamReader for reading
            {
                return (InfoWindows03)reader.Deserialize(file);
            }
        }


        // Event triggered when the form's resizing ends
        void Cau03_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows03 iw = new InfoWindows03();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw); // Save the size to the XML file
        }

        // Event triggered when the form is loaded
        void Cau03_Load(object sender, EventArgs e)
        {
            iw = Read();

            // If `iw` is null (meaning the file does not exist or couldn't be read), initialize with default values
            if (iw == null)
            {
                iw = new InfoWindows03
                {
                    Width = this.Width,  // Use the current form's dimensions as default
                    Height = this.Height,
                    Location = this.Location // Use the current form's location as default
                };
            }

            // Apply the saved size and location to the form
            this.Width = iw.Width;
            this.Height = iw.Height;
            this.Location = iw.Location;
        }



        private void Cau03_FormClosing(object sender, FormClosingEventArgs e)
        {
            iw.Width = this.Size.Width;
            iw.Height= this.Size.Height;
            iw.Location= this.Location;
            Write(iw);
        }


    }

    public class InfoWindows03
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Location { get; set; }
    }
}
