using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace GoogleSheets
{
  public class SheetConnector
  {
    private string[] _scopes = { SheetsService.Scope.Spreadsheets }; // Change this if you're accessing Drive or Docs
    private string _applicationName = "SmartSheet";
    private string _spreadsheetId = "1W6lNDsE9rvEXn6FslNTFR9WPn9NgmoA60gjYlBXhVy8";
    private string SettingName = "credentials.json";
    private SheetsService _sheetsService;

    public SheetConnector()
    {
      Init(SettingName);
    }

    private void Init(string settingsFileName)
    {
      if (string.IsNullOrEmpty(settingsFileName)) throw new ArgumentNullException(nameof(settingsFileName));

      var googleCredential = GetGoogleCredentials(settingsFileName);
      GetSheetsService(googleCredential);
    }

    private GoogleCredential GetGoogleCredentials(string settingFileName)
    {
      using var stream = new FileStream(settingFileName, FileMode.Open, FileAccess.Read);
      var googleCredential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
      return googleCredential;
    }

    private void GetSheetsService(GoogleCredential googleCredential)
    {
      _sheetsService = new SheetsService(new BaseClientService.Initializer
      {
        HttpClientInitializer = googleCredential
      });
    }

    public BatchGetValuesResponse GetSheets()
    {
      SpreadsheetsResource.ValuesResource.BatchGetRequest request = _sheetsService.Spreadsheets.Values.BatchGet(_spreadsheetId);
      request.Ranges = new List<string>() { "A1:ZZZ10000" };
      request.ValueRenderOption = 0;

      BatchGetValuesResponse response = request.Execute();

      return response;
    }
  }
}
