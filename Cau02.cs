using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Ex01
{
    public partial class Cau02 : Form
    {
        string path = @"D:\form.xml"; // File path to save form size

        public Cau02()
        {
            InitializeComponent();
        }

        // Method to save the form size (width and height) to XML
        public void Write(InfoWindows iw)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(InfoWindows));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, iw);
            }
        }

        // Method to read the form size from XML and set the form's size
        public InfoWindows Read()
        {
            if (!File.Exists(path))
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(InfoWindows));
            using (StreamReader reader = new StreamReader(path))
            {
                return (InfoWindows)serializer.Deserialize(reader);
            }
        }

        // Event triggered when the form's resizing ends
        void Cau02_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw); // Save the size to the XML file
        }

        // Event triggered when the form is loaded
        void Cau02_Load(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
        }
    }

    // Class to hold the width and height of the form
    public class InfoWindows
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
