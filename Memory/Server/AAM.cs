﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Tokenizers;
using Server;
using Spectre.Console;
using Tensorflow;

// All About Model
public class AAM
{

    public string MyPath { get; set; }
    public double Accuracy { get; set; }
    public ITransformer BModel { get; set; }
    
    // AutoML experiment to find the best alorithm
    public void Experiment(string path)
    {
        
        Console.Clear();
        Console.WriteLine("How much time do you want to train your model? (second)(10/30/95/..)");
        uint second = Convert.ToUInt32(Console.ReadLine());
        Console.Clear();
        Console.Write("Creating Model..");



        #region Main
        
        try
        {
            #region Experiment

            MLContext Context = new MLContext();
            var trainData = Context.Data.LoadFromTextFile<Input>(path, hasHeader: true, separatorChar: ',');
            var experiment = Context.Auto().CreateMulticlassClassificationExperiment(second);
            var result = experiment.Execute(trainData, labelColumnName: "Label");
            #endregion


            #region Values

            BModel = result.BestRun.Model;
            Accuracy = result.BestRun.ValidationMetrics.MacroAccuracy;

            Console.Clear();
            Console.WriteLine($"Macro Accuracy of your Model: {Accuracy.ToString()}");
            #endregion


            #region Save

            var devam = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Do you want to save your model?").PageSize(5).HighlightStyle("gray").AddChoices(new[] { "Yes", "[red]No (Abort)[/]" }));
            if (devam == "[red]No (Abort)[/]")
            {
                Environment.Exit(0);
            }
            SelectLocation();
            Directory.CreateDirectory(MyPath+"/prjTMP");
            Context.Model.Save(BModel, trainData.Schema, $"{MyPath}/prjTMP/Model.zip");

            #region Copying DataSet
            
            File.Copy(path, $"{MyPath}/prjTMP/dataSet.csv");
            CS(path);
            #endregion

            #endregion

        }
        catch (Exception ex)
        {
            ERROR an = new ERROR();
            an.exit(ex.Message);
        }
        #endregion


        Console.Clear();
        Console.WriteLine("Model has saved.");

        Compresser comp = new Compresser();
        comp.Compress(MyPath);

    }

    // Locatin Selector for Project
    void SelectLocation()
    {
        Console.Clear();
        Console.WriteLine("Enter a Directory path to save your Project Files: ");
        string LPath = Console.ReadLine();
        if (Directory.Exists(LPath)) 
        {
            MyPath = LPath;
        }
        else
        {
            SelectLocation();
        }
    }

    
    //Category Splitter
    void CS(string path)
    {
        string filePath = path; // CSV dosyanızın yolu
        HashSet<string> uniqueValues = new HashSet<string>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 2) // En az 2 sütun olduğunu kontrol edin
                {
                    uniqueValues.Add(parts[1]); // 2. sütundaki değeri ekleyin
                }
            }
        }

        string loc = $"{MyPath}/prjTMP/categories.txt";

        FileStream fs = new FileStream(loc, FileMode.OpenOrCreate);

        foreach (string value in uniqueValues)
        {
            string vv = $"{value}\n";
            byte[] bytm = Encoding.UTF8.GetBytes(vv);
            fs.Write(bytm, 0, bytm.Length);
        }
        fs.Close();
    }


}