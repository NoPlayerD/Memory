using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ML.Data;


# region I/O Classes for Model Training

public class Input
{

    [LoadColumn(0)]
    public string startLine { get; set; }

    [LoadColumn(1), ColumnName("Label")]
    public string endLine { get; set; }
}

public class Output
{
    [ColumnName("PredictedLabel")]
    public string PredictedLabel { get; set; }

    [ColumnName("Score")]
    public float[] Score { get; set; }
}
#endregion