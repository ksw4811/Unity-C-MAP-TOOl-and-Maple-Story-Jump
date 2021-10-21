﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformtest
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private Point pntCurrentPicbox;
        private Point pntMouseClick;
        String[] UlucityTiles = { "UluCity_Tile1-1", "UluCity_Tile1-2", "UluCity_Tile1-3", "UluCity_Tile1-4", "UluCity_Tile1-5", "UluCity_Tile1-6" };
        String[] BlossomTiles = { "Blossom_Tile1-1", "Blossom_Tile1-2", "Blossom_Tile1-3", "Blossom_Tile1-4", "Blossom_Tile1-5", "Blossom_Tile1-6" };
        String[] HalloweenTiles = { "Halloween_Tile1-1", "Halloween_Tile1-2", "Halloween_Tile1-3", "Halloween_Tile1-4", "Halloween_Tile1-5", "Halloween_Tile1-6" };
        private bool blsClick = false;

        public struct Tile
        {
            String tileName;
            Bitmap tileBitmap;
        }

        int nPictureBoxX;
        int nPictureBoxY;

        public Form1()
        {
            InitializeComponent();
        }

        private void dirListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(winformtest.Properties.Resources.Black_1000x2000);

            nPictureBoxX = pictureBox1.Size.Width;
            nPictureBoxY = pictureBox1.Size.Height;
        }

        private void lbTile_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, pntCurrentPicbox);
            pictureBox1.Focus();
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            blsClick = true;

            pntMouseClick.X = e.X;
            pntMouseClick.Y = e.Y;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blsClick)
            {
                pntCurrentPicbox.X = pntCurrentPicbox.X + e.X - pntMouseClick.X;
                pntCurrentPicbox.Y = pntCurrentPicbox.Y + e.Y - pntMouseClick.Y;

                if (pntCurrentPicbox.X > 0)
                {
                    pntCurrentPicbox.X = 0;
                }
                if (pntCurrentPicbox.Y > 0)
                {
                    pntCurrentPicbox.Y = 0;
                }

                if (pntCurrentPicbox.X + image.Width < nPictureBoxX)
                {
                    pntCurrentPicbox.X = nPictureBoxX - image.Width;
                }
                if (pntCurrentPicbox.Y + image.Height < nPictureBoxY)
                {
                    pntCurrentPicbox.Y = nPictureBoxY - image.Height;
                }

                pntMouseClick = e.Location;

                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            blsClick = false;
        }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbTile_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            String file_path = null;
            openFileDialog1.InitialDirectory = "C:\\"; // 시작 위치를 C:\\로 설정
            if(openFileDialog1.ShowDialog() == DialogResult.OK) // 파일을 정하고 열기를 누르면
            {
                file_path = openFileDialog1.FileName; // 선택된 파일의 풀 경로를 불러와 저장
                //이제 여기서 불러온거를 오른쪽 픽쳐박스에 띄우기? Json 파일
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            String file_path = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Json File(*.json)|*.json";

            if(saveFileDialog.ShowDialog() == DialogResult.OK) // 저장 위치를 정하고 저장을 누르면
            {
                file_path = saveFileDialog.FileName; // 저장 경로
                pictureBox1.Image.Save(file_path);// 이제 픽쳐박스에서 만든거를 저장 예: pb.Image.Save(file_path) pb는 픽쳐박스
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
            }
        }

        private void btGroundSelect_Click(object sender, EventArgs e)
        {
            if(cbBackGround.Text == "Ulu City")
            {
                image = new Bitmap(winformtest.Properties.Resources.Ulucity_Grid);
                pictureBox1.Image = image;
            }
            else if(cbBackGround.Text == "Blossom Castle")
            {
                image = new Bitmap(winformtest.Properties.Resources.Blossom_Grid);
                pictureBox1.Image = image;
            }
            else if(cbBackGround.Text == "Halloween")
            {
                image = new Bitmap(winformtest.Properties.Resources.Halloween_Grid);
                pictureBox1.Image = image;
            }
        }

        private void btTileSelect_Click(object sender, EventArgs e)
        {
            if (cbBackGround.Text == "Ulu City" && cbTile.Text == "Normal")
            {
                TileListBox.Items.Clear();
                for (int index = 0; index < UlucityTiles.Length; index++)
                {
                    TileListBox.Items.Add(UlucityTiles[index]);
                }
            }
            else if (cbBackGround.Text == "Blossom Castle" && cbTile.Text == "Normal")
            {
                TileListBox.Items.Clear();
                for (int index = 0; index < BlossomTiles.Length; index++)
                {
                    TileListBox.Items.Add(BlossomTiles[index]);
                }
            }

            else if (cbBackGround.Text == "Halloween" && cbTile.Text == "Normal")
            {
                TileListBox.Items.Clear();
                for (int index = 0; index < HalloweenTiles.Length; index++)
                {
                    TileListBox.Items.Add(HalloweenTiles[index]);
                }
            }
        }

        private void TileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBackGround.Text == "Ulu City" && cbTile.Text == "Normal")
            {
                switch (TileListBox.Text)
                {
                    case "UluCity_Tile1-1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_1);
                        return;
                    case "UluCity_Tile1-2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_2);
                        return;
                    case "UluCity_Tile1-3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_3);
                        return;
                    case "UluCity_Tile1-4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_4);
                        return;
                    case "UluCity_Tile1-5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_5);
                        return;
                    case "UluCity_Tile1-6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_6);
                        return;
                }
            }
            else if (cbBackGround.Text == "Blossom Castle" && cbTile.Text == "Normal")
            {
                switch (TileListBox.Text)
                {
                    case "Blossom_Tile1-1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_1);
                        return;
                    case "Blossom_Tile1-2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_2);
                        return;
                    case "Blossom_Tile1-3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_3);
                        return;
                    case "Blossom_Tile1-4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_4);
                        return;
                    case "Blossom_Tile1-5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_5);
                        return;
                    case "Blossom_Tile1-6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_6);
                        return;
                }
            }

            else if (cbBackGround.Text == "Halloween" && cbTile.Text == "Normal")
            {
                switch (TileListBox.Text)
                {
                    case "Halloween_Tile1-1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_1);
                        return;
                    case "Halloween_Tile1-2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_2);
                        return;
                    case "Halloween_Tile1-3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_3);
                        return;
                    case "Halloween_Tile1-4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_4);
                        return;
                    case "Halloween_Tile1-5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_5);
                        return;
                    case "Halloween_Tile1-6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_6);
                        return;
                }
            }
        }
    }
}
