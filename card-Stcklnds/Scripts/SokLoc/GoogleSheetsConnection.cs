using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

public class GoogleSheetsConnection
{
	private static readonly string[] scopes = new string[1] { SheetsService.Scope.Spreadsheets };

	private GoogleCredential credential;

	private SheetsService service;

	private string spreadsheetId;

	private const string credentials = "";

	public GoogleSheetsConnection(string spreadsheetId)
	{
		this.spreadsheetId = spreadsheetId;
		using (Stream stream = GenerateStreamFromString(""))
		{
			credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
		}
		service = new SheetsService(new BaseClientService.Initializer
		{
			HttpClientInitializer = credential,
			ApplicationName = "Sokloc"
		});
	}

	private static Stream GenerateStreamFromString(string s)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream);
		streamWriter.Write(s);
		streamWriter.Flush();
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public void AppendRow(params string[] txts)
	{
		IList<object> list = new List<object>();
		foreach (string item in txts)
		{
			list.Add(item);
		}
		IList<IList<object>> list2 = new List<IList<object>>();
		list2.Add(list);
		SpreadsheetsResource.ValuesResource.AppendRequest appendRequest = service.Spreadsheets.Values.Append(new ValueRange
		{
			Values = list2
		}, spreadsheetId, "A:A");
		appendRequest.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
		appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
		appendRequest.Execute();
	}
}
