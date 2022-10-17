﻿using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace PathfinderKINGPortrait
{
    public partial class MainForm : Form
    {
        private void PicPortraitTemp_DragDrop(object sender, DragEventArgs e)
        {
            string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string fullpath = "-1";
            if (filelist[0] != null && File.Exists(filelist[0]) &&
                (Path.GetExtension(filelist[0]) == ".png") ||
                (Path.GetExtension(filelist[0]) == ".jpg") ||
                (Path.GetExtension(filelist[0]) == ".jpeg")||
                (Path.GetExtension(filelist[0]) == ".bmp") ||
                (Path.GetExtension(filelist[0]) == ".gif"))
                fullpath = filelist[0];
            if (fullpath == "-1")
            {
                if (is_loaded == true)
                {
                    LoadAllImages();
                    return;
                }
                is_loaded = false;
            }
            else
                is_loaded = true;
            ClearImages();
            SystemControl.FileControl.CreateTemp(fullpath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void PicPortraitTemp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void PicPortraitTemp_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFile();
            if (fullpath == "-1")
            {
                if (is_loaded == true)
                {
                    LoadAllImages();
                    return;
                }
                is_loaded = false;
            }
            else
                is_loaded = true;
            ClearImages();
            SystemControl.FileControl.CreateTemp(fullpath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void BtnLoadPortrait_Click(object sender, EventArgs e)
        {
            string fullpath = SystemControl.FileControl.OpenFile();
            if (fullpath == "-1")
            {
                if (is_loaded == true)
                {
                    LoadAllImages();
                    return;
                }
                is_loaded = false;
            }
            else
                is_loaded = true;
            ClearImages();
            SystemControl.FileControl.CreateTemp(fullpath, RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
            LoadAllImages();
        }
        private void PicPortraitLrg_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitLrg.VerticalScroll.Visible = false;
            PanelPortraitLrg.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_pos = e.Location;
                is_dragging = 1;
            }
        }
        private void PicPortraitLrg_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_dragging == 1 && (PicPortraitLrg.Image.Width > PanelPortraitLrg.Width ||
                                  PicPortraitLrg.Image.Height > PanelPortraitLrg.Height))
            {
                PanelPortraitLrg.AutoScrollPosition = new Point(-PanelPortraitLrg.AutoScrollPosition.X + (mouse_pos.X - e.X),
                                                              -PanelPortraitLrg.AutoScrollPosition.Y + (mouse_pos.Y - e.Y));
            }
        }
        private void PicPortraitLrg_MouseUp(object sender, MouseEventArgs e)
        {
            PanelPortraitLrg.VerticalScroll.Visible = false;
            PanelPortraitLrg.HorizontalScroll.Visible = false;
            is_dragging = 0;
        }
        private void PicPortraitMed_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitMed.VerticalScroll.Visible = false;
            PanelPortraitMed.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_pos = e.Location;
                is_dragging = 2;
            }
        }
        private void PicPortraitMed_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_dragging == 2 && (PicPortraitMed.Image.Width > PanelPortraitMed.Width ||
                                  PicPortraitMed.Image.Height > PanelPortraitMed.Height))
            {
                PanelPortraitMed.AutoScrollPosition = new Point(-PanelPortraitMed.AutoScrollPosition.X + (mouse_pos.X - e.X),
                                                              -PanelPortraitMed.AutoScrollPosition.Y + (mouse_pos.Y - e.Y));
            }
        }
        private void PicPortraitMed_MouseUp(object sender, MouseEventArgs e)
        {
            PanelPortraitMed.VerticalScroll.Visible = false;
            PanelPortraitMed.HorizontalScroll.Visible = false;
            is_dragging = 0;
        }
        private void PicPortraitSml_MouseDown(object sender, MouseEventArgs e)
        {
            PanelPortraitSml.VerticalScroll.Visible = false;
            PanelPortraitSml.HorizontalScroll.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_pos = e.Location;
                is_dragging = 3;
            }
        }
        private void PicPortraitSml_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_dragging == 3 && (PicPortraitSml.Image.Width > PanelPortraitSml.Width ||
                                  PicPortraitSml.Image.Height > PanelPortraitSml.Height))
            {
                PanelPortraitSml.AutoScrollPosition = new Point(-PanelPortraitSml.AutoScrollPosition.X + (mouse_pos.X - e.X),
                                                              -PanelPortraitSml.AutoScrollPosition.Y + (mouse_pos.Y - e.Y));
            }
        }
        private void PicPortraitSml_MouseUp(object sender, MouseEventArgs e)
        {
            PanelPortraitSml.VerticalScroll.Visible = false;
            PanelPortraitSml.HorizontalScroll.Visible = false;
            is_dragging = 0;
        }
        private void PicPortraitLrg_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitLrg.Width * 1.0f / PicPortraitLrg.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitLrg.Width * 1.0f / 8;
                ImageControl.Direct.Zoom(PicPortraitLrg, PanelPortraitLrg, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
        }
        private void PicPortraitMed_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitMed.Width * 1.0f / PicPortraitMed.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitMed.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitMed, PanelPortraitMed, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
        }
        private void PicPortraitSml_MouseWheel(object sender, MouseEventArgs e)
        {
            float aspect_ratio = (PicPortraitSml.Width * 1.0f / PicPortraitSml.Height * 1.0f),
                  factor;
            if (e.Delta > 0)
            {
                factor = PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
            else
            {
                factor = -PicPortraitSml.Width * 1.0f / 10;
                ImageControl.Direct.Zoom(PicPortraitSml, PanelPortraitSml, e, RELATIVEPATH_TO_TEMPPOOR, aspect_ratio, factor);
            }
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            ClearImages();
            SystemControl.FileControl.TempClear();
            Application.Exit();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeAllImagesAsWindow();
        }
        private void BtnCreatePortrait_Click(object sender, EventArgs e)
        {
            string exoduspath,
                   fullexoduspath;
            exoduspath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") +
                         "\\Owlcat Games\\Pathfinder Kingmaker\\Portraits";
            fullexoduspath = "";
            if(!SystemControl.FileControl.DirExists(exoduspath))
            {
                MessageBox.Show("Pathfinder: Kingmaker portraits folder was not found.", "Directory not found!", MessageBoxButtons.OK);
                return;
            }
            bool findplace = false;
            uint localname = 1000;
            while (findplace == false)
            {
                fullexoduspath = exoduspath + "\\" + Convert.ToString(localname);
                if (!Directory.Exists(fullexoduspath))
                {
                    Directory.CreateDirectory(fullexoduspath);
                    ImageControl.Wraps.CropImage(PicPortraitLrg, PanelPortraitLrg, RELATIVEPATH_TO_TEMPFULL, 
                                                 fullexoduspath + LARGE_EXTENRSION, 
                                                 ASPECT_RATIO_LARGE, 692, 1024);
                    ImageControl.Wraps.CropImage(PicPortraitMed, PanelPortraitMed, RELATIVEPATH_TO_TEMPFULL, 
                                                 fullexoduspath + MEDIUM_EXTENSION, 
                                                 ASPECT_RATIO_MED, 330, 432);
                    ImageControl.Wraps.CropImage(PicPortraitSml, PanelPortraitSml, RELATIVEPATH_TO_TEMPFULL, 
                                                 fullexoduspath + SMALL_EXTENSION, 
                                                 ASPECT_RATIO_SMALL, 185, 242);
                    findplace = true;
                }
                localname++;
            }
            if (CheckExistence(fullexoduspath))
            {
                using (AuxForms.FinalDialog fd = new AuxForms.FinalDialog())
                {
                    fd.ShowDialog();
                    if (fd.State == 1)
                    {
                        ClearImages();
                        is_loaded = false;
                        AllToNotEnabled();
                        ThisToEnabled(LayoutMainPage);
                    }
                    else if (fd.State == 2)
                    {
                        ClearImages();
                        is_loaded = false;
                        SystemControl.FileControl.CreateTemp("-1", RELATIVEPATH_TO_TEMPFULL, RELATIVEPATH_TO_TEMPPOOR);
                        LoadAllImages();
                        AllToNotEnabled();
                        ThisToEnabled(LayoutFilePage);
                        ResizeAllImagesAsWindow();
                    }
                    else if (fd.State == 3)
                    {
                        ClearImages();
                        is_loaded = false;
                        AllToNotEnabled();
                        System.Diagnostics.Process.Start(fullexoduspath);
                        ThisToEnabled(LayoutMainPage);
                    }
                }
            }
            else 
            {
                MessageBox.Show("Program was unable to load any images into portraits folder.", "No images load!", MessageBoxButtons.OK);
                return;
            }
        }
        private void PicPortraitMed_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitMed, img, PanelPortraitMed);
        }
        private void PicPortraitLrg_MouseDoubleClick(object sedner, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitLrg, img, PanelPortraitLrg);
        }
        private void PicPortraitSml_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Image img = new Bitmap(RELATIVEPATH_TO_TEMPPOOR))
                ResizeImageAsWindow(PicPortraitSml, img, PanelPortraitSml);
        }
        private void LblUnnamed1_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed1.Text = "Stats portrait";
            LabelUnnamed1.Font = smlfont;
        }
        private void LblUnnamed2_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed2.Text = "Character portrait";
            LabelUnnamed2.Font = smlfont;
        }
        private void LblUnnamed3_MouseHover(object sender, EventArgs e)
        {
            LabelUnnamed3.Text = "Gameplay portrait";
            LabelUnnamed3.Font = smlfont;
        }
        private void LblUnnamed1_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed1.Text = "Medium";
            LabelUnnamed1.Font = lrgfont;
        }

        private void LblUnnamed2_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed2.Text = "Large";
            LabelUnnamed2.Font = lrgfont;
        }

        private void LblUnnamed3_MouseLeave(object sender, EventArgs e)
        {
            LabelUnnamed3.Text = "Small";
            LabelUnnamed3.Font = lrgfont;
        }
        private void BtnURLLoad_Click(object sender, EventArgs e)
        {
            using (AuxForms.UrlDialog ud = new AuxForms.UrlDialog())
            { 
                ud.ShowDialog();
                if (ud.URL != "-1")
                {   try
                    {
                        var request = System.Net.WebRequest.Create(ud.URL);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            using (Image web_img = Bitmap.FromStream(stream))
                            {
                                if (!Directory.Exists("temp/"))
                                    Directory.CreateDirectory("temp/");
                                web_img.Save(RELATIVEPATH_TO_TEMPFULL);
                                ImageControl.Wraps.CreatePoorImage(web_img, RELATIVEPATH_TO_TEMPPOOR);
                                is_loaded = true;
                                ClearImages();
                                LoadAllImages();
                            }
                        }
                    }
                    catch
                    {
                        ud.URL = "-1";
                    }
                }
            }
        }
        private void BtnShowHints_Click(object sender, EventArgs e)
        {
            using (AuxForms.ScalingHint sh = new AuxForms.ScalingHint())
                sh.ShowDialog();
        }
        private void BtnFileHint_Click(object sender, EventArgs e)
        {
            using (AuxForms.FileHint fh = new AuxForms.FileHint())
                fh.ShowDialog();
        }
    }
}