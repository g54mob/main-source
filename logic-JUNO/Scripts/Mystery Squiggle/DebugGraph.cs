using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Mystery.Graphing;
using UnityEngine;

public static class DebugGraph
{
	public enum TimeScales
	{
		RealTimeSinceStartUp = 0,
		TimeSinceLevelLoad = 1,
		TimeSinceGameStart = 2
	}

	public enum FileTypes
	{
		CommaDelimited = 0,
		TabDelimited = 1
	}

	public static Color DefaultRed = GetUniqueColor(2);

	public static Color DefaultGreen = GetUniqueColor(1);

	public static Color DefaultBlue = GetUniqueColor(0);

	internal static readonly string[] Vector2ValueNames = new string[2] { "X", "Y" };

	internal static readonly string[] Vector3ValueNames = new string[3] { "X", "Y", "Z" };

	internal static readonly string[] ColorValueNames = new string[4] { "R", "G", "B", "A" };

	private static bool loggingEnabled = true;

	private static bool stackTraceEnabled = true;

	private static float minDisplayTime = float.MaxValue;

	private static float maxDisplayTime = float.MinValue;

	private static StringBuilder sb;

	private static string dataPath;

	private static int dataPathLength;

	private static Dictionary<string, IGraphConsole> graphs = new Dictionary<string, IGraphConsole>();

	public static TimeScales DefaultTimeScale { get; set; }

	public static bool LoggingEnabled
	{
		get
		{
			return loggingEnabled;
		}
		set
		{
			loggingEnabled = value;
		}
	}

	public static bool StackTraceEnabled
	{
		get
		{
			return stackTraceEnabled;
		}
		set
		{
			stackTraceEnabled = value;
		}
	}

	public static float MinDisplayTime => minDisplayTime;

	public static float MaxDisplayTime => maxDisplayTime;

	public static Color GetUniqueColor(int index)
	{
		return HueToRGB(Mathf.Repeat((float)(2 - index) * (19f / 72f) + 0.02f, 1f));
	}

	private static Color HueToRGB(float H)
	{
		Color black = Color.black;
		float num = H * 6f;
		int num2 = Mathf.FloorToInt(num);
		float num3 = num - (float)num2;
		float num4 = 1f - num3;
		float num5 = num3;
		switch (num2)
		{
		case -1:
			black.r = 1f;
			black.g = 0f;
			black.b = num4;
			break;
		case 0:
			black.r = 1f;
			black.g = num5;
			black.b = 0f;
			break;
		case 1:
			black.r = num4;
			black.g = 1f;
			black.b = 0f;
			break;
		case 2:
			black.r = 0f;
			black.g = 1f;
			black.b = num5;
			break;
		case 3:
			black.r = 0f;
			black.g = num4;
			black.b = 1f;
			break;
		case 4:
			black.r = num5;
			black.g = 0f;
			black.b = 1f;
			break;
		case 5:
			black.r = 1f;
			black.g = 0f;
			black.b = num4;
			break;
		case 6:
			black.r = 1f;
			black.g = num5;
			black.b = 0f;
			break;
		}
		black.r = Mathf.Clamp(black.r, 0f, 1f);
		black.g = Mathf.Clamp(black.g, 0f, 1f);
		black.b = Mathf.Clamp(black.b, 0f, 1f);
		return black;
	}

	public static void UpdateTimeRange(float value)
	{
		if (value < minDisplayTime)
		{
			minDisplayTime = value;
		}
		if (value > maxDisplayTime)
		{
			maxDisplayTime = value;
		}
	}

	public static void CleanUpHistory(float length)
	{
		CleanUpHistory(length, maxDisplayTime);
	}

	public static void CleanUpHistory(float length, float fromTime)
	{
		lock (graphs)
		{
			maxDisplayTime = fromTime;
			float num = maxDisplayTime - length;
			if (num > minDisplayTime)
			{
				minDisplayTime = num;
			}
			foreach (IGraphConsole value in graphs.Values)
			{
				value.CleanUpHistory(minDisplayTime);
			}
		}
	}

	public static void ClearDeveloperConsole()
	{
		lock (graphs)
		{
			foreach (IGraphConsole value in graphs.Values)
			{
				value.Clear();
			}
		}
		graphs.Clear();
		minDisplayTime = float.MaxValue;
		maxDisplayTime = float.MinValue;
		GC.Collect();
	}

	public static List<IPlottableGraphPoint[]> ExportData(string graphName)
	{
		if (!graphs.ContainsKey(graphName))
		{
			return null;
		}
		return graphs[graphName].ExportData();
	}

	private static string GetAnonymousName<T>(string prefix = "")
	{
		int lineNumber;
		return GetAnonymousName(prefix, typeof(T).Name, out lineNumber, displayType: false);
	}

	private static string GetAnonymousMultiName<T>(T value, out Color color, string prefix = "")
	{
		int lineNumber;
		string anonymousName = GetAnonymousName(prefix, typeof(T).Name, out lineNumber, displayType: true);
		color = GetUniqueColor(lineNumber);
		return anonymousName;
	}

	private static string GetAnonymousName(Type type, string prefix = "")
	{
		int lineNumber;
		return GetAnonymousName(prefix, type.Name, out lineNumber, displayType: false);
	}

	private static string GetAnonymousMultiName(Type type, out Color color, string prefix = "")
	{
		int lineNumber;
		string anonymousName = GetAnonymousName(prefix, type.Name, out lineNumber, displayType: true);
		color = GetUniqueColor(lineNumber);
		return anonymousName;
	}

	private static string GetAnonymousName(string prefix, string typeName, out int lineNumber, bool displayType)
	{
		if (stackTraceEnabled)
		{
			if (sb == null)
			{
				sb = new StringBuilder();
			}
			else
			{
				sb.Length = 0;
			}
			StackFrame frame = new StackTrace(3, fNeedFileInfo: true).GetFrame(0);
			lineNumber = frame.GetFileLineNumber();
			MethodBase method = frame.GetMethod();
			sb.Append(prefix);
			sb.Append(method.DeclaringType.ToString());
			sb.Append(" : ");
			sb.Append(method.ToString());
			if (displayType)
			{
				sb.Append(" (");
				sb.Append(typeName);
				sb.Append(")");
			}
			else
			{
				string fileName = frame.GetFileName();
				if (!string.IsNullOrEmpty(fileName))
				{
					sb.Append(" (at ");
					if (string.IsNullOrEmpty(dataPath))
					{
						dataPath = Application.dataPath.Replace('/', Path.DirectorySeparatorChar);
						dataPathLength = dataPath.Length - "Assets".Length;
					}
					if (fileName.StartsWith(dataPath))
					{
						sb.Append(frame.GetFileName().Substring(dataPathLength));
					}
					else
					{
						sb.Append(frame.GetFileName());
					}
					sb.Append(":");
					sb.Append(lineNumber);
					sb.Append(")");
				}
			}
			return sb.ToString();
		}
		lineNumber = 0;
		return typeName;
	}

	public static void SaveAllToFile(string filename, FileTypes fileType = FileTypes.CommaDelimited, bool format = true)
	{
		using (StreamWriter streamWriter = new StreamWriter(filename))
		{
			foreach (IGraphConsole item in GetGraphEnumerator())
			{
				SaveToStream(item, streamWriter, fileType, format);
				streamWriter.WriteLine();
			}
		}
		UnityEngine.Debug.Log("Exported: " + filename);
	}

	public static void SaveAllToFolder(string folderName, FileTypes fileType = FileTypes.CommaDelimited, bool format = true)
	{
		foreach (IGraphConsole item in GetGraphEnumerator())
		{
			Save(item, folderName, fileType, format);
		}
	}

	public static void Save(string graphName, string folderName, FileTypes fileType = FileTypes.CommaDelimited, bool format = true)
	{
		Save(graphs[graphName], folderName, fileType, format);
	}

	public static void Save(IGraphConsole console, string folderName, FileTypes fileType = FileTypes.CommaDelimited, bool format = true)
	{
		string text = Path.Combine(folderName, console.Name + "." + GetFilenameExtension(fileType));
		using (StreamWriter sw = new StreamWriter(text))
		{
			SaveToStream(console, sw, fileType, format);
		}
		UnityEngine.Debug.Log("Exported: " + text);
	}

	public static void SaveToStream(IGraphConsole console, StreamWriter sw, FileTypes fileType = FileTypes.CommaDelimited, bool format = true)
	{
		switch (fileType)
		{
		case FileTypes.CommaDelimited:
			GraphExportUtility.WriteDelimited(sw, console.Name, console.ValueNames, console.ExportData(), ",", format);
			break;
		case FileTypes.TabDelimited:
			GraphExportUtility.WriteDelimited(sw, console.Name, console.ValueNames, console.ExportData(), "\t", format);
			break;
		}
	}

	public static string GetFilenameExtension(FileTypes fileType)
	{
		return fileType switch
		{
			FileTypes.CommaDelimited => "CSV", 
			FileTypes.TabDelimited => "txt", 
			_ => string.Empty, 
		};
	}

	public static IEnumerable<IGraphConsole> GetGraphEnumerator()
	{
		lock (graphs)
		{
			foreach (IGraphConsole value in graphs.Values)
			{
				yield return value;
			}
		}
	}

	public static IGraphConsole GetGraph(string name)
	{
		if (!graphs.ContainsKey(name))
		{
			return null;
		}
		return graphs[name];
	}

	public static void AddCustomGraph(string name, IPlottableGraph graph)
	{
		lock (graphs)
		{
			if (!graphs.ContainsKey(name))
			{
				graphs.Add(name, new SingleGraphConsole(name, graph));
			}
		}
	}

	public static void AddCustomGraph(IGraphConsole graphConsole)
	{
		lock (graphs)
		{
			if (!graphs.ContainsKey(graphConsole.Name))
			{
				graphs.Add(graphConsole.Name, graphConsole);
			}
		}
	}

	public static void RemoveCustomGraph(string name)
	{
		lock (graphs)
		{
			if (graphs.ContainsKey(name))
			{
				graphs.Remove(name);
			}
		}
	}

	public static void RemoveCustomGraph(IGraphConsole graphConsole)
	{
		lock (graphs)
		{
			if (graphs.ContainsKey(graphConsole.Name))
			{
				graphs.Remove(graphConsole.Name);
			}
		}
	}

	public static void Write(object value)
	{
		Write(GetAnonymousName<string>(), value);
	}

	public static void Write(string name, object value)
	{
		Write(name, value, GetDefaultTime());
	}

	public static void Write(string name, object value, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new StringGraphConsole(name, new StringLinearPlottableGraph()));
			}
		}
		((StringGraphConsole)graphs[name]).Push(time, (value == null) ? "Null" : value.ToString());
		UpdateTimeRange(time);
	}

	public static void Write(object value, Color color)
	{
		Write(GetAnonymousName<string>(), value, color);
	}

	public static void Write(string name, object value, Color color)
	{
		Write(name, value, color, GetDefaultTime());
	}

	public static void Write(string name, object value, Color color, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new StringGraphConsole(name, new StringLinearPlottableGraph()));
			}
		}
		((StringGraphConsole)graphs[name]).Push(time, (value == null) ? "Null" : value.ToString(), color);
		UpdateTimeRange(time);
	}

	public static void Log(Enum value)
	{
		Log(GetAnonymousName(value.GetType()), value, DefaultBlue);
	}

	public static void Log(Enum value, Color color)
	{
		Log(GetAnonymousName(value.GetType()), value, color);
	}

	public static void Log(string name, Enum value)
	{
		Log(name, value, DefaultBlue);
	}

	public static void Log(string name, Enum value, Color color)
	{
		Log(name, value, color, GetDefaultTime());
	}

	public static void Log(string name, Enum value, Color color, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new SingleGraphConsole<float, long>(name, new EnumLinearPlottableGraph(value.GetType())));
			}
		}
		((SingleGraphConsole<float, long>)graphs[name]).Push(time, Convert.ToInt64(value), color);
		UpdateTimeRange(time);
	}

	public static void Log(bool value)
	{
		Log(GetAnonymousName<bool>(), value, DefaultBlue);
	}

	public static void Log(bool value, Color color)
	{
		Log(GetAnonymousName<bool>(), value, color);
	}

	public static void Log(string name, bool value)
	{
		Log(name, value, DefaultBlue);
	}

	public static void Log(string name, bool value, Color color)
	{
		Log(name, value, color, GetDefaultTime());
	}

	public static void Log(string name, bool value, Color color, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new SingleGraphConsole<float, bool>(name, new BooleanLinearPlottableGraph()));
			}
		}
		((SingleGraphConsole<float, bool>)graphs[name]).Push(time, value, color);
		UpdateTimeRange(time);
	}

	public static void Log(double value)
	{
		Log(GetAnonymousName<double>(), value, DefaultBlue);
	}

	public static void Log(double value, Color color)
	{
		Log(GetAnonymousName<double>(), value, color);
	}

	public static void Log(string name, double value)
	{
		Log(name, value, DefaultBlue);
	}

	public static void Log(string name, double value, Color color)
	{
		Log(name, value, color, GetDefaultTime());
	}

	public static void Log(string name, double value, Color color, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new SingleGraphConsole<float, double>(name, new FloatingPointLinearPlottableGraph()));
			}
		}
		((SingleGraphConsole<float, double>)graphs[name]).Push(time, value, color);
		UpdateTimeRange(time);
	}

	public static void Log(long value)
	{
		Log(GetAnonymousName<long>(), value, DefaultBlue);
	}

	public static void Log(long value, Color color)
	{
		Log(GetAnonymousName<long>(), value, color);
	}

	public static void Log(string name, long value)
	{
		Log(name, value, DefaultBlue);
	}

	public static void Log(string name, long value, Color color)
	{
		Log(name, value, color, GetDefaultTime());
	}

	public static void Log(string name, long value, Color color, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new SingleGraphConsole<float, long>(name, new IntegerLinearPlottableGraph()));
			}
		}
		((SingleGraphConsole<float, long>)graphs[name]).Push(time, value, color);
		UpdateTimeRange(time);
	}

	public static void Log(Vector2 value)
	{
		Log(GetAnonymousName<Vector2>(), value);
	}

	public static void Log(string name, Vector2 value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, Vector2 value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, Vector2 value, float time)
	{
		Log(name, value, Vector2ValueNames, GetDefaultTime());
	}

	public static void Log(string name, Vector2 value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph()));
			}
		}
		MultiGraphConsole<float, double> obj = (MultiGraphConsole<float, double>)graphs[name];
		obj.ValueNames = valueNames;
		obj.Push(time, value.x, DefaultRed);
		obj.Push(time, value.y, DefaultGreen);
		UpdateTimeRange(time);
	}

	public static void Log(Vector3 value)
	{
		Log(GetAnonymousName<Vector3>(), value);
	}

	public static void Log(string name, Vector3 value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, Vector3 value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, Vector3 value, float time)
	{
		Log(name, value, Vector3ValueNames, GetDefaultTime());
	}

	public static void Log(string name, Vector3 value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph()));
			}
		}
		MultiGraphConsole<float, double> obj = (MultiGraphConsole<float, double>)graphs[name];
		obj.ValueNames = valueNames;
		obj.Push(time, value.x, DefaultRed);
		obj.Push(time, value.y, DefaultGreen);
		obj.Push(time, value.z, DefaultBlue);
		UpdateTimeRange(time);
	}

	public static void Log(float[] value)
	{
		Log(GetAnonymousName<float[]>(), value);
	}

	public static void Log(string name, float[] value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, float[] value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, float[] value, float time)
	{
		Log(name, value, null, GetDefaultTime());
	}

	public static void Log(string name, float[] value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph()));
			}
		}
		MultiGraphConsole<float, double> multiGraphConsole = (MultiGraphConsole<float, double>)graphs[name];
		multiGraphConsole.ValueNames = valueNames;
		for (int num = 0; num < value.Length; num++)
		{
			multiGraphConsole.Push(time, value[num], GetUniqueColor(num));
		}
		UpdateTimeRange(time);
	}

	public static void Log(uint[] value)
	{
		Log(GetAnonymousName<uint[]>(), value);
	}

	public static void Log(string name, uint[] value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, uint[] value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, uint[] value, float time)
	{
		Log(name, value, null, GetDefaultTime());
	}

	public static void Log(string name, uint[] value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, long>(name, (Type newGraphType) => new IntegerLinearPlottableGraph()));
			}
		}
		MultiGraphConsole<float, long> multiGraphConsole = (MultiGraphConsole<float, long>)graphs[name];
		multiGraphConsole.ValueNames = valueNames;
		for (int num = 0; num < value.Length; num++)
		{
			multiGraphConsole.Push(time, value[num], GetUniqueColor(num));
		}
		UpdateTimeRange(time);
	}

	public static void Log(int[] value)
	{
		Log(GetAnonymousName<int[]>(), value);
	}

	public static void Log(string name, int[] value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, int[] value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, int[] value, float time)
	{
		Log(name, value, null, GetDefaultTime());
	}

	public static void Log(string name, int[] value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, long>(name, (Type newGraphType) => new IntegerLinearPlottableGraph()));
			}
		}
		MultiGraphConsole<float, long> multiGraphConsole = (MultiGraphConsole<float, long>)graphs[name];
		multiGraphConsole.ValueNames = valueNames;
		for (int num = 0; num < value.Length; num++)
		{
			multiGraphConsole.Push(time, value[num], GetUniqueColor(num));
		}
		UpdateTimeRange(time);
	}

	public static void Log(long[] value)
	{
		Log(GetAnonymousName<long[]>(), value);
	}

	public static void Log(string name, long[] value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, long[] value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, long[] value, float time)
	{
		Log(name, value, null, GetDefaultTime());
	}

	public static void Log(string name, long[] value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, long>(name, (Type newGraphType) => new IntegerLinearPlottableGraph()));
			}
		}
		MultiGraphConsole<float, long> multiGraphConsole = (MultiGraphConsole<float, long>)graphs[name];
		multiGraphConsole.ValueNames = valueNames;
		for (int num = 0; num < value.Length; num++)
		{
			multiGraphConsole.Push(time, value[num], GetUniqueColor(num));
		}
		UpdateTimeRange(time);
	}

	public static void Log(Color value)
	{
		Log(GetAnonymousName<Color>(), value);
	}

	public static void Log(string name, Color value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, Color value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, Color value, float time)
	{
		Log(name, value, ColorValueNames, GetDefaultTime());
	}

	public static void Log(string name, Color value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new ColorGraphConsole<double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph()));
			}
		}
		ColorGraphConsole<double> obj = (ColorGraphConsole<double>)graphs[name];
		obj.ValueNames = valueNames;
		obj.Push(time, value.r, Color.red);
		obj.Push(time, value.g, Color.green);
		obj.Push(time, value.b, Color.blue);
		obj.Push(time, value.a, Color.black);
		UpdateTimeRange(time);
	}

	public static void Log(Color32 value)
	{
		Log(GetAnonymousName<Color32>(), value);
	}

	public static void Log(string name, Color32 value)
	{
		Log(name, value, GetDefaultTime());
	}

	public static void Log(string name, Color32 value, IEnumerable<string> valueNames)
	{
		Log(name, value, valueNames, GetDefaultTime());
	}

	public static void Log(string name, Color32 value, float time)
	{
		Log(name, value, ColorValueNames, GetDefaultTime());
	}

	public static void Log(string name, Color32 value, IEnumerable<string> valueNames, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new ColorGraphConsole<long>(name, (Type newGraphType) => new IntegerLinearPlottableGraph()));
			}
		}
		ColorGraphConsole<long> obj = (ColorGraphConsole<long>)graphs[name];
		obj.ValueNames = valueNames;
		obj.Push(time, value.r, Color.red);
		obj.Push(time, value.g, Color.green);
		obj.Push(time, value.b, Color.blue);
		obj.Push(time, value.a, Color.black);
		UpdateTimeRange(time);
	}

	public static void MultiLog(Enum value)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value);
	}

	public static void MultiLog(Enum value, string valueName)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value, valueName);
	}

	public static void MultiLog(Color color, Enum value)
	{
		MultiLog(GetAnonymousName(value.GetType(), "Multi "), color, value);
	}

	public static void MultiLog(Color color, Enum value, string valueName)
	{
		MultiLog(GetAnonymousName(value.GetType(), "Multi "), color, value, valueName);
	}

	public static void MultiLog(string name, Color color, Enum value)
	{
		MultiLog(name, color, value, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, Enum value, float time)
	{
		MultiLog(name, color, value, null, time);
	}

	public static void MultiLog(string name, Color color, Enum value, string valueName)
	{
		MultiLog(name, color, value, valueName, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, Enum value, string valueName, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, long>(name, (Type newGraphType) => new EnumLinearPlottableGraph(newGraphType)));
			}
		}
		((MultiGraphConsole<float, long>)graphs[name]).Push(time, Convert.ToInt64(value), color, valueName, value.GetType());
		UpdateTimeRange(time);
	}

	public static void MultiLog(bool value)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value);
	}

	public static void MultiLog(bool value, string valueName)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value, valueName);
	}

	public static void MultiLog(Color color, bool value)
	{
		MultiLog(GetAnonymousName<bool>("Multi "), color, value);
	}

	public static void MultiLog(Color color, bool value, string valueName)
	{
		MultiLog(GetAnonymousName<bool>("Multi "), color, value, valueName);
	}

	public static void MultiLog(string name, Color color, bool value)
	{
		MultiLog(name, color, value, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, bool value, float time)
	{
		MultiLog(name, color, value, null, time);
	}

	public static void MultiLog(string name, Color color, bool value, string valueName)
	{
		MultiLog(name, color, value, valueName, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, bool value, string valueName, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, bool>(name, (Type newGraphType) => new BooleanLinearPlottableGraph()));
			}
		}
		((MultiGraphConsole<float, bool>)graphs[name]).Push(time, value, color, valueName);
		UpdateTimeRange(time);
	}

	public static void MultiLog(double value)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value);
	}

	public static void MultiLog(double value, string valueName)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value, valueName);
	}

	public static void MultiLog(Color color, double value)
	{
		MultiLog(GetAnonymousName<double>("Multi "), color, value);
	}

	public static void MultiLog(Color color, double value, string valueName)
	{
		MultiLog(GetAnonymousName<double>("Multi "), color, value, valueName);
	}

	public static void MultiLog(string name, Color color, double value)
	{
		MultiLog(name, color, value, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, double value, float time)
	{
		MultiLog(name, color, value, null, time);
	}

	public static void MultiLog(string name, Color color, double value, string valueName)
	{
		MultiLog(name, color, value, valueName, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, double value, string valueName, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph()));
			}
		}
		((MultiGraphConsole<float, double>)graphs[name]).Push(time, value, color, valueName);
		UpdateTimeRange(time);
	}

	public static void MultiLog(long value)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value);
	}

	public static void MultiLog(long value, string valueName)
	{
		MultiLog(GetAnonymousMultiName(value, out var color), color, value, valueName);
	}

	public static void MultiLog(Color color, long value)
	{
		MultiLog(GetAnonymousName<long>("Multi "), color, value);
	}

	public static void MultiLog(Color color, long value, string valueName)
	{
		MultiLog(GetAnonymousName<long>("Multi "), color, value, valueName);
	}

	public static void MultiLog(string name, Color color, long value)
	{
		MultiLog(name, color, value, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, long value, float time)
	{
		MultiLog(name, color, value, null, time);
	}

	public static void MultiLog(string name, Color color, long value, string valueName)
	{
		MultiLog(name, color, value, valueName, GetDefaultTime());
	}

	public static void MultiLog(string name, Color color, long value, string valueName, float time)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, long>(name, (Type newGraphType) => new IntegerLinearPlottableGraph()));
			}
		}
		((MultiGraphConsole<float, long>)graphs[name]).Push(time, value, color, valueName);
		UpdateTimeRange(time);
	}

	public static void Draw(Vector2 value)
	{
		Draw(GetAnonymousName<Vector2>("Draw "), value, DefaultBlue);
	}

	public static void Draw(Vector2 value, Color color)
	{
		Draw(GetAnonymousName<Vector2>(), value, color);
	}

	public static void Draw(string name, Vector2 value)
	{
		Draw(name, value, DefaultBlue);
	}

	public static void Draw(string name, Vector2 value, Color color)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new SingleGraphConsole<float, float>(name, new Vector2ScatteredPlottableGraph()));
			}
		}
		((SingleGraphConsole<float, float>)graphs[name]).Push(value.x, value.y, color);
	}

	public static void MultiDraw(Vector2 value)
	{
		Draw(GetAnonymousMultiName(value, out var color, "Draw "), value, color);
	}

	public static void MultiDraw(Color color, Vector2 value)
	{
		Draw(GetAnonymousName<Vector2>("Draw "), value, color);
	}

	public static void MultiDraw(string name, Color color, Vector2 value)
	{
		MultiDraw(name, color, value, Vector2ValueNames);
	}

	public static void MultiDraw(string name, Color color, Vector2 value, IEnumerable<string> valueNames)
	{
		if (!loggingEnabled)
		{
			return;
		}
		if (!graphs.ContainsKey(name))
		{
			lock (graphs)
			{
				graphs.Add(name, new MultiGraphConsole<float, float>(name, (Type newGraphType) => new Vector2ScatteredPlottableGraph()));
			}
		}
		MultiGraphConsole<float, float> obj = (MultiGraphConsole<float, float>)graphs[name];
		obj.ValueNames = valueNames;
		obj.Push(value.x, value.y, color);
	}

	public static float GetDefaultTime()
	{
		return DefaultTimeScale switch
		{
			TimeScales.RealTimeSinceStartUp => Time.realtimeSinceStartup, 
			TimeScales.TimeSinceLevelLoad => Time.timeSinceLevelLoad, 
			TimeScales.TimeSinceGameStart => Time.time, 
			_ => 0f, 
		};
	}
}
