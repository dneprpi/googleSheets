// See https://aka.ms/new-console-template for more information


using GoogleSheets;

Console.WriteLine("Hello, World!");
SheetConnector connector = new SheetConnector();
var response = connector.GetSheets().ValueRanges.FirstOrDefault()?.Values;

var phone = "380632578427";

List<Model> models = new List<Model>();

foreach (var sheet in response)
{
  Model m = new Model(sheet);
  models.Add(m);
}

var result = models.Where(i => i.Phone == phone).FirstOrDefault();

Console.WriteLine(result?.DaysOff ?? "not found");



