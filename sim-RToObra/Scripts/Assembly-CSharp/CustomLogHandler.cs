using System;
using System.IO;
using UnityEngine;

public class CustomLogHandler : ILogHandler
{
	private FileStream stream;

	private StreamWriter writer;

	private ILogHandler defaultHandler = Debug.unityLogger.logHandler;

	public CustomLogHandler()
	{
		string path = Application.persistentDataPath + "/output.log";
		stream = new FileStream(path, FileMode.Append, FileAccess.Write);
		writer = new StreamWriter(stream);
	}

	public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
	{
		writer.WriteLine(string.Format(format, args));
		writer.Flush();
		defaultHandler.LogFormat(logType, context, format, args);
	}

	public void LogException(Exception exception, UnityEngine.Object context)
	{
		writer.WriteLine(string.Format("EXCEPTION: {0}", exception.Message));
		writer.WriteLine(string.Format("CONTEXT: {0}", context.ToString()));
		writer.WriteLine(exception.StackTrace);
		writer.Flush();
		defaultHandler.LogException(exception, context);
	}
}
