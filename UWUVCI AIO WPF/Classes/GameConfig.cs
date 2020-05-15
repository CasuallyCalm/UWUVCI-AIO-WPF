﻿using GameBaseClassLibrary;
using System;
using UWUVCI_AIO_WPF.Classes;

namespace UWUVCI_AIO_WPF
{
    [Serializable]
    public class GameConfig
    {
        public GameConfig Clone()
        {
            return this.MemberwiseClone() as GameConfig;
        }
        public GameConsoles Console { get; set; }
        public GameBases BaseRom { get; set; }

        private string cBasePath;

        public string CBasePath
        {
            get { return cBasePath; }
            set { cBasePath = value;

            }
        }


        public int Index;


        public string GameName { get; set; }


        public PNGTGA TGAIco { get; set; } = new PNGTGA();



        public PNGTGA TGADrc { get; set; } = new PNGTGA();
        public PNGTGA TGATv { get; set; } = new PNGTGA();
        public PNGTGA TGALog { get; set; } = new PNGTGA();
        public N64Conf N64Stuff { get; set; } = new N64Conf();

    }
}
