using System.IO;
using UnityEngine;

public static class ExceptionHandler
{
	private static bool isExceptionHandlingSetup;

	public static void SetupExceptionHandling()
	{
		if (!isExceptionHandlingSetup)
		{
			isExceptionHandlingSetup = true;
			Application.logMessageReceived += HandleException;
		}
	}

	private static void HandleException(string condition, string stackTrace, LogType type)
	{
		StreamWriter streamWriter = File.AppendText("C:\\Users\\worth\\Documents\\My Games\\Duskers\\test.log");
		streamWriter.WriteLine(string.Format("LogType: {2}, condition: {0}, stacktrace: {1}", condition, stackTrace, type));
		streamWriter.Close();
	}
}
