using System.IO;
using System.Text;
using UnityEngine;

public class DebugLogger
{
	private StringBuilder info = new StringBuilder();

	private StringBuilder warning = new StringBuilder();

	public void Log(object message)
	{
		info.AppendLine(message.ToString());
	}

	public void LogFormat(string format, params object[] args)
	{
		info.AppendFormat(format, args);
		info.Append("\n");
	}

	public void Print(object message)
	{
		info.Append(message);
	}

	public void PrintFormat(string format, params object[] args)
	{
		info.AppendFormat(format, args);
	}

	public void LogWarning(object message)
	{
		warning.AppendLine(message.ToString());
	}

	public void LogWarningFormat(string format, params object[] args)
	{
		warning.AppendFormat(format, args);
		warning.Append("\n");
	}

	public void PrintWarning(object message)
	{
		warning.Append(message);
	}

	public void PrintWarningFormat(string format, params object[] args)
	{
		warning.AppendFormat(format, args);
	}

	public void Flush(string filename = null)
	{
		if (filename != null)
		{
			File.WriteAllText(filename, info.ToString() + "\n" + warning.ToString());
		}
		if (info.Length > 0)
		{
			Debug.Log(info.ToString());
		}
		if (warning.Length > 0)
		{
			Debug.LogWarning(warning.ToString());
		}
		info.Length = 0;
		warning.Length = 0;
	}
}
