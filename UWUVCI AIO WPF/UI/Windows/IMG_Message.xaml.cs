﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UWUVCI_AIO_WPF.UI.Frames.InjectFrames.Configurations;

namespace UWUVCI_AIO_WPF.UI.Windows
{
    /// <summary>
    /// Interaktionslogik für IMG_Message.xaml
    /// </summary>
    public partial class IMG_Message : Window
    {
        string ic = "";
        string tvs = "";
        public IMG_Message(string icon, string tv)
        {
            
            
                InitializeComponent();
                ic = icon;
                tvs = tv;

               BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(icon, UriKind.Absolute);
                bitmap.EndInit();

                this.icon.Source = bitmap;

                BitmapImage bmp2 = new BitmapImage();
                bmp2.BeginInit();
                bmp2.UriSource = new Uri(tv, UriKind.Absolute);
                bmp2.EndInit();
                this.tv.Source = bmp2;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mvm = FindResource("mvm") as MainViewModel;
            var client = new WebClient();
            if (Directory.Exists(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo")))
            {
                Directory.Delete(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo"), true);
            }
            Directory.CreateDirectory(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo"));
            client.DownloadFile(ic, System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "iconTex.png"));
            mvm.GameConfiguration.TGAIco.ImgPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "iconTex.png");
            mvm.GameConfiguration.TGAIco.extension = ".png";
            if (mvm.test == GameBaseClassLibrary.GameConsoles.GCN)
            {
                (mvm.Thing as GCConfig).icoIMG.Visibility = Visibility.Visible;
            }
            else if(mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.WII)
            {
                (mvm.Thing as WiiConfig).icoIMG.Visibility = Visibility.Visible;
            }
            else if (mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.N64)
            {
                (mvm.Thing as N64Config).icoIMG.Visibility = Visibility.Visible;
            }
            else if (mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.NDS || mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.SNES)
            {
                (mvm.Thing as OtherConfigs).icoIMG.Visibility = Visibility.Visible;
            }
            client.DownloadFile(tvs, System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "bootTvTex.png"));
            mvm.GameConfiguration.TGATv.ImgPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "bootTvTex.png");
            mvm.GameConfiguration.TGATv.extension = ".png";
            if (mvm.test == GameBaseClassLibrary.GameConsoles.GCN)
            {
                (mvm.Thing as GCConfig).tvIMG.Visibility = Visibility.Visible;
            }
            else if (mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.WII)
            {
                (mvm.Thing as WiiConfig).tvIMG.Visibility = Visibility.Visible;
            }
            else if (mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.N64)
            {
                (mvm.Thing as N64Config).tvIMG.Visibility = Visibility.Visible;
                (mvm.Thing as N64Config).imgpath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "iconTex.png"), System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "bootTvTex.png"));
            }
            else if (mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.NDS || mvm.GameConfiguration.Console == GameBaseClassLibrary.GameConsoles.SNES)
            {
                (mvm.Thing as OtherConfigs).imgpath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "iconTex.png"), System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin", "repo", "bootTvTex.png"));

            }
            this.Close();
        }

    }
}
