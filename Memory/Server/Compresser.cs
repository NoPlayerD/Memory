using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using TorchSharp.Modules;
using System.ComponentModel.DataAnnotations;

public class Compresser
{
    AAM MDL = new AAM();
    public string DataPath { get; set; }

    public void Compress(string prPath)
    {
        //string PrPath;
        //PrPath = MDL.MyPath;

        SelectLocation();
        string fileLocation = $@"{DataPath}\";
        string zipLocation = $@"{prPath}\data.zip";

        ZipFile.CreateFromDirectory(fileLocation, zipLocation);
        Console.Clear();
        Console.WriteLine("All Done. Press any key to exit..");
        Console.ReadKey();
    }
   
    void SelectLocation()
    {
        Console.WriteLine("Enter the Directory Path of the Data: ");
        DataPath = Console.ReadLine();
    }
}