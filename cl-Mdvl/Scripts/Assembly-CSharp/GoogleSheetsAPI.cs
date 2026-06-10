using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

public static class GoogleSheetsAPI
{
	private const string ServiceAccountEmail = "going-medieval@going-medieval.iam.gserviceaccount.com";

	private const string ServiceAccountJsonPath = "going-medieval-google-api-service-account-key.json";

	private const string SpreadsheetId = "1HVqYIdDVui5uB8s8O2vXQT9OhkC8erEx8IwfBD0AwYc";

	private const int DevBranchPerTestRunSheetId = 0;

	private const int DevBranchPerSingleTestSheetId = 1001830210;

	private const int OtherBranchesPerTestRunSheetId = 194084955;

	private const int OtherBranchesPerSingleTestSheetId = 283659239;

	public static void SendPerformanceStatsReport(string branchName, List<PerformanceTestStats> testStats)
	{
		string text = ((branchName == "develop") ? "" : (branchName + ","));
		string timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
		PerformanceTestStats performanceTestStats = new PerformanceTestStats
		{
			AverageFrameTime = testStats.Select((PerformanceTestStats stats) => stats.AverageFrameTime).Average(),
			MedianFrameTime = testStats.Select((PerformanceTestStats stats) => stats.MedianFrameTime).Average(),
			MinFrameTime = testStats.Select((PerformanceTestStats stats) => stats.MinFrameTime).Min(),
			MaxFrameTime = testStats.Select((PerformanceTestStats stats) => stats.MaxFrameTime).Max(),
			Duration = testStats.Select((PerformanceTestStats stats) => stats.Duration).Sum(),
			UpperQuartileAverageFrameTime = testStats.Select((PerformanceTestStats stats) => stats.UpperQuartileAverageFrameTime).Average()
		};
		GoogleCredential httpClientInitializer = GoogleCredential.FromFile("going-medieval-google-api-service-account-key.json").CreateScoped(SheetsService.Scope.Spreadsheets);
		SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer
		{
			HttpClientInitializer = httpClientInitializer,
			ApplicationName = "Going Medieval"
		});
		List<Request> list = new List<Request>();
		int value = ((!(branchName == "develop")) ? 194084955 : 0);
		int value2 = ((branchName == "develop") ? 1001830210 : 283659239);
		InsertDimensionRequest insertDimension = new InsertDimensionRequest
		{
			Range = new DimensionRange
			{
				SheetId = value,
				Dimension = "ROWS",
				StartIndex = 1,
				EndIndex = 2
			}
		};
		string data = text + performanceTestStats.GetSheetsLineNoTestName(timestamp);
		PasteDataRequest pasteData = new PasteDataRequest
		{
			Data = data,
			Delimiter = ",",
			Coordinate = new GridCoordinate
			{
				SheetId = value,
				ColumnIndex = 0,
				RowIndex = 1
			}
		};
		list.Add(new Request
		{
			InsertDimension = insertDimension
		});
		list.Add(new Request
		{
			PasteData = pasteData
		});
		foreach (PerformanceTestStats testStat in testStats)
		{
			InsertDimensionRequest insertDimension2 = new InsertDimensionRequest
			{
				Range = new DimensionRange
				{
					SheetId = value2,
					Dimension = "ROWS",
					StartIndex = 1,
					EndIndex = 2
				}
			};
			PasteDataRequest pasteData2 = new PasteDataRequest
			{
				Data = text + testStat.GetSheetsLine(timestamp),
				Delimiter = ",",
				Coordinate = new GridCoordinate
				{
					SheetId = value2,
					ColumnIndex = 0,
					RowIndex = 1
				}
			};
			list.Add(new Request
			{
				InsertDimension = insertDimension2
			});
			list.Add(new Request
			{
				PasteData = pasteData2
			});
		}
		BatchUpdateSpreadsheetRequest body = new BatchUpdateSpreadsheetRequest
		{
			Requests = list
		};
		SpreadsheetsResource.BatchUpdateRequest batchUpdateRequest = sheetsService.Spreadsheets.BatchUpdate(body, "1HVqYIdDVui5uB8s8O2vXQT9OhkC8erEx8IwfBD0AwYc");
		try
		{
			batchUpdateRequest.Execute();
			Log.Info("Sent performance stats report to Google Sheets", "C:\\GIT\\dev\\Assets\\Scripts\\Testing\\Autoplay\\GoogleSheetsAPI.cs");
		}
		catch (Exception ex)
		{
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(86, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Testing\\Autoplay\\GoogleSheetsAPI.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Failed to send performance stats report to Google Sheets API because of an exception: ");
				messageBuilder.AppendFormatted(ex.Message);
			}
			Log.Error(messageBuilder);
		}
	}

	public static void Test()
	{
		SendPerformanceStatsReport("develop", new List<PerformanceTestStats>
		{
			new PerformanceTestStats
			{
				AverageFrameTime = 0.1f,
				UpperQuartileAverageFrameTime = 0.55f,
				MedianFrameTime = 0.1f,
				MinFrameTime = 0.05f,
				MaxFrameTime = 0.4f,
				Duration = 10.34f,
				TestName = "Test1"
			},
			new PerformanceTestStats
			{
				AverageFrameTime = 0.2f,
				UpperQuartileAverageFrameTime = 0.61f,
				MedianFrameTime = 0.2f,
				MinFrameTime = 0.03f,
				MaxFrameTime = 0.6f,
				Duration = 16.21f,
				TestName = "Test2"
			}
		});
	}
}
