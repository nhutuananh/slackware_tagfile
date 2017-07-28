using System;
using System.IO;

namespace scan_list_packages
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //string[] lines = File.ReadAllLines(@"d:\Projects\4.slackware_tagfile\tools\scan_list_packages\list_packages");
            // foreach (var line in lines)
            // {
            //     Console.WriteLine(line);
            // }

            string fileName_listPackage = @"d:\Projects\4.slackware_tagfile\tools\scan_list_packages\list_packages";
            string tagDir = @"d:\Projects\4.slackware_tagfile\13.37_minimum\";
            Business bu = new Business();
            //bu.skip_all_package(@"d:\Projects\4.slackware_tagfile\13.37_minimum\");
            bu.add_pkgs_from_file_to_tagdir(fileName_listPackage, tagDir);
        }

    }
}
