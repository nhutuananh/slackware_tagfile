using System;
using System.IO;

namespace scan_list_packages
{
    internal class Business
    {
        private string getFileContainPackage(string dirTagFile, string package_name)
        {
            //string sourceDir = @"d:\Projects\4.slackware_tagfile\13.37_minimum\";
            string[] dirEntries = Directory.GetDirectories(dirTagFile);
            foreach (var dirName in dirEntries)
            {
                string[] fileEntries = Directory.GetFiles(dirName);
                foreach (var fileName in fileEntries)
                {
                    string[] lines = File.ReadAllLines(fileName);
                    foreach (var line in lines)
                    {
                        if (line.Contains(package_name))
                            return fileName;
                    }
                }
            }
            return null;
        }

        public void skip_all_package(string dirTagFile)
        {
            string[] dirEntries = Directory.GetDirectories(dirTagFile);
            foreach (var dirName in dirEntries)
            {
                string[] fileEntries = Directory.GetFiles(dirName);
                foreach (var fileName in fileEntries)
                {
                    string text = File.ReadAllText(fileName);
                    text = text.Replace(":ADD", ":SKP");
                    File.WriteAllText(fileName, text);
                }
            }
        }

        private void add_package(string fileName, string package)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            string text = File.ReadAllText(fileName);
            if (text != null)
            {
                text = text.Replace(package+":SKP", package+":ADD");
                File.WriteAllText(fileName, text);
            }
        }
        
        public void add_pkgs_from_file_to_tagdir(string fileName, string tagDir)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string tagFile = getFileContainPackage(tagDir, line);
                if (string.IsNullOrEmpty(tagFile))
                {
                    Console.WriteLine("not found package: " + line);
                    continue;
                }
                else
                {
                    // update tagfile from :SKP to :ADD
                    add_package(tagFile, line);
                }
            }
        }
    }

}