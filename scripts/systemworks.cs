﻿using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SystemControl
{
    public class FileControl
    {
        public static string OpenFile()
        {
            string fullpath;
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Choose image",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                SupportMultiDottedExtensions = false,
                Filter = "Image files|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                fullpath = ofd.FileName;
            else
                fullpath = "-1";
            ofd.Dispose();
            return fullpath;
        }
        public static void CreateTemp(string fullpath, string new_fullpath_full, string new_fullpath_poor)
        {
            if (!Directory.Exists("temp/")) 
                Directory.CreateDirectory("temp/");
            if (fullpath == "-1")
            {
                using (Image img = new Bitmap(PathfinderKINGPortrait.Properties.Resources._default))
                {
                    img.Save(new_fullpath_full);
                    img.Save(new_fullpath_poor);
                }
            }
            else
            {
                using (Image img = new Bitmap(fullpath))
                {
                    img.Save(new_fullpath_full);
                    ImageControl.Wraps.CreatePoorImage(img, new_fullpath_poor);
                }
            }
        }
        public static void TempClear()
        {
            try
            {
                if (Directory.Exists("temp/")) 
                    Directory.Delete("temp/", true);
            }
            catch (System.IO.IOException)
            {
                return;
            }
        }
    }
}