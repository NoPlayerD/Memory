## What is this?
- It is a project based on nonsense and laziness that I developed to help us not forget or easily remember the information we have learned but do not use regularly.
- It uses multi-class classification to classify your inputs so you can use it in many scenarios
- (Example Scenarios: functions of a coding language / food recipes / some infos about shortcuts of your OS / ...)

## Latest Release:
[For Win x64](https://github.com/NoPlayerD/Memory/releases/tag/Self-Contained)

## How it works?
1. Create a .csv file like this;

| Prompts          | Categories |
| ---------------- | ---------- |
| soup recipe      | Soup       |
| my soup's recipe | Soup       |
| soup             | Soup       |
| potage           | Soup       |
| potage recipe    | Soup       |
| meatball recipe  | MeatBall   |
| meatball         | MeatBall   |
| my meatballs     | MeatBall   |
| rissole          | MeatBall   |
| rissole recipe   | MeatBall   |


2. Create text files of the categories and write the data into it
3. Run the 'Server'
4. Create a model
5. Train it with different times (precision may vary)
6. Select Data files' location
7. Save the project
8. Run the 'Client'
9. the remaining steps are written there..


## Dependencies
#### Server:
- Microsoft.ML.AutoML
- Microsoft.ML.TorchSharp
- Spectre.Console
- TorchSharp
- TorchSharp-cpu

#### Client:
- Microsoft.ML
- Microsoft.ML.FastTree
- Microsoft.ML.LightGbm
- LightGBM
