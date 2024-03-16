using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using TorchSharp.Modules;
using System.ComponentModel.DataAnnotations;
using Google.Protobuf.WellKnownTypes;
using System.Diagnostics;

public class Compresser
{
    public string DataPath { get; set; }
    public string prjName { get; set; }


    public void Compress(string prPath)
    {
        //string PrPath;
        //PrPath = MDL.MyPath;

        SelectLocation();
        SelectName();
        string fileLocation = $@"{prPath}/prjTMP/";
        string zipLocation = $@"{prPath}/{prjName}.zip";

        #region copyDataFiles

        string dr = $"{prPath}/prjTMP/data/";
        Directory.CreateDirectory(dr);
        var myFiles = Directory.GetFiles(DataPath);
        foreach (var myFile in myFiles)
        {
            string mfile = myFile.Remove(0,myFile.LastIndexOf('\\')+1);
            File.Copy(myFile, $"{dr}/{mfile}");
        }
        #endregion

        ZipFile.CreateFromDirectory(fileLocation, zipLocation);
        Console.Clear();
        Console.WriteLine("Your Project is Ready ;)");
        Directory.Delete(fileLocation,true);
        Console.WriteLine("All Done. Press any key to exit..");
        Console.ReadKey();
    }
   
    void SelectLocation()
    {
        Console.WriteLine("Enter the Directory Path of the Data: ");
        DataPath = Console.ReadLine();
    }
    void SelectName()
    {
        Console.Clear();
        Console.WriteLine("Enter a name for your Project: ");
        prjName = Console.ReadLine();
    }
}