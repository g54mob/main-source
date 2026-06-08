using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Utils
{
	public delegate bool IncludeFilePredicate(FileInfo file, string dstPath);

	public static System.Random random = new System.Random();

	private static Dictionary<string, GameObject> preloadedPrefabs = new Dictionary<string, GameObject>();

	private static Dictionary<string, Stack<Action<GameObject>>> preloadCallbacks = new Dictionary<string, Stack<Action<GameObject>>>();

	private const string ManualBreak = "\\n";

	private static readonly string D = "tid_time_suffix_days";

	private static readonly string H = "tid_time_suffix_hours";

	private static readonly string M = "tid_time_suffix_minutes";

	private static readonly string S = "tid_time_suffix_seconds";

	private static char[] alaphaNumericalChars;

	private static int smallDeltaTimeLogCount;

	private const int LOG_LIMIT = 5242880;

	private static int logSize = 0;

	public static float deltaTime
	{
		get
		{
			float num = Time.deltaTime;
			if (num <= 0.0001f && Time.timeScale >= 1f)
			{
				num = 1f / 60f;
				if (smallDeltaTimeLogCount < 10)
				{
					smallDeltaTimeLogCount++;
					if (smallDeltaTimeLogCount == 10)
					{
						LogError("(FINAL LOG OF THIS TYPE) Time.deltaTime is too small. Editor may crash at any moment.");
					}
					else
					{
						LogError("Time.deltaTime is too small. Editor may crash at any moment.");
					}
				}
			}
			return num;
		}
	}

	public static GameObject LoadPrefab(string prefabPath)
	{
		UnityEngine.Object obj = Resources.Load(prefabPath, typeof(GameObject));
		if (obj == null)
		{
			if (preloadedPrefabs.ContainsKey(prefabPath))
			{
				obj = preloadedPrefabs[prefabPath];
			}
			else
			{
				LogError("Could not load prefab " + prefabPath);
			}
		}
		GameObject obj2 = obj as GameObject;
		if (obj2 == null)
		{
			LogError(prefabPath + " is not a GameObject");
		}
		return obj2;
	}

	public static GameObject InstantiatePrefab(string prefabPath)
	{
		GameObject gameObject = LoadPrefab(prefabPath);
		if (gameObject != null)
		{
			return UnityEngine.Object.Instantiate(gameObject);
		}
		return null;
	}

	public static void PreloadAsyncPrefab(string prefabPath, Action<GameObject> callback = null)
	{
		if (preloadedPrefabs.ContainsKey(prefabPath))
		{
			if (callback != null)
			{
				if (preloadedPrefabs[prefabPath] != null)
				{
					callback(preloadedPrefabs[prefabPath]);
				}
				else
				{
					AddPreloadCallback(prefabPath, callback);
				}
			}
		}
		else
		{
			AddPreloadCallback(prefabPath, callback);
			preloadedPrefabs.Add(prefabPath, null);
			_PreloadAsyncPrefab(prefabPath, 0);
		}
	}

	private static void _PreloadAsyncPrefab(string prefabPath, int attempts)
	{
		AsyncOperationHandle<GameObject> loadHandler = Addressables.LoadAssetAsync<GameObject>(prefabPath);
		LoadingAccountant.Add(loadHandler);
		loadHandler.Completed += delegate
		{
			if (loadHandler.Status == AsyncOperationStatus.Succeeded)
			{
				preloadedPrefabs[prefabPath] = loadHandler.Result;
				InvokePreloadCallbacks(prefabPath, loadHandler.Result);
			}
			else if (attempts < 5)
			{
				Addressables.Release(loadHandler);
				attempts++;
				_PreloadAsyncPrefab(prefabPath, attempts);
			}
			else
			{
				preloadedPrefabs.Remove(prefabPath);
				GameplayActionMessages.SetMessage("Failed to load " + prefabPath, ColorConstants.red);
			}
		};
	}

	private static void AddPreloadCallback(string prefabPath, Action<GameObject> callback)
	{
		if (callback != null)
		{
			GetCallbackStack(prefabPath).Push(callback);
		}
	}

	private static void InvokePreloadCallbacks(string prefabPath, GameObject go)
	{
		Stack<Action<GameObject>> callbackStack = GetCallbackStack(prefabPath);
		while (callbackStack.Count > 0)
		{
			callbackStack.Pop()(go);
		}
	}

	private static Stack<Action<GameObject>> GetCallbackStack(string prefabPath)
	{
		if (!preloadCallbacks.ContainsKey(prefabPath))
		{
			preloadCallbacks[prefabPath] = new Stack<Action<GameObject>>();
		}
		return preloadCallbacks[prefabPath];
	}

	public static void ResetTransform(Transform t)
	{
		t.localPosition = Vector3.zero;
		t.localRotation = Quaternion.identity;
		t.localScale = Vector3.one;
	}

	public static string Join(string separator, object[] arr)
	{
		if (arr.Length == 0)
		{
			return "";
		}
		string text = arr[0].ToString();
		for (int i = 1; i < arr.Length; i++)
		{
			text = text + separator + arr[i].ToString();
		}
		return text;
	}

	public static string InsertLineBreaks(string message, int maxCharactersPerLine)
	{
		maxCharactersPerLine = Mathf.Max(maxCharactersPerLine, 1);
		int num = message.IndexOf("\\n");
		if (num >= 0)
		{
			string message2 = message.Substring(0, num);
			num += "\\n".Length;
			return string.Concat(str2: InsertLineBreaks(message.Substring(num, message.Length - num), maxCharactersPerLine), str0: InsertLineBreaks(message2, maxCharactersPerLine), str1: "\n");
		}
		if (message.Length <= maxCharactersPerLine)
		{
			return message;
		}
		int num2 = maxCharactersPerLine;
		bool flag = false;
		for (int i = 0; i <= maxCharactersPerLine; i++)
		{
			switch (message[i])
			{
			case ' ':
				num2 = i;
				flag = true;
				continue;
			case '\n':
				break;
			default:
				continue;
			}
			num2 = i;
			flag = true;
			break;
		}
		string message3;
		if (flag)
		{
			if (num2 == 0)
			{
				message3 = message.Substring(1, message.Length - 1);
				return "\n" + InsertLineBreaks(message3, maxCharactersPerLine);
			}
			string text = message.Substring(0, num2);
			message3 = message.Substring(num2 + 1, message.Length - num2 - 1);
			return text + "\n" + InsertLineBreaks(message3, maxCharactersPerLine);
		}
		string text2 = message.Substring(0, num2);
		message3 = message.Substring(num2, message.Length - num2);
		return text2 + "\n" + InsertLineBreaks(message3, maxCharactersPerLine);
	}

	public static string[] BreakIntoLines(string message, int preferredWidth)
	{
		return InsertLineBreaks(message, preferredWidth).Split(new char[1] { '\n' });
	}

	public static string FormatNumber(long amount)
	{
		if (amount < 1000)
		{
			return amount.ToString();
		}
		string text = "";
		long num = amount / 1000;
		long num2 = amount - num * 1000;
		return string.Concat(str2: (num2 < 10) ? ("00" + num2) : ((num2 >= 100) ? num2.ToString() : ("0" + num2)), str0: FormatNumber(num), str1: ",");
	}

	public static string FormatTimeDigital(int seconds)
	{
		int num = seconds / 60;
		seconds -= num * 60;
		int num2 = num / 60;
		num -= num2 * 60;
		string text = seconds.ToString();
		if (seconds < 10)
		{
			text = "0" + text;
		}
		text = num + ":" + text;
		if (num2 > 0)
		{
			if (num < 10)
			{
				text = "0" + text;
			}
			text = num2 + ":" + text;
		}
		return text;
	}

	public static string FormatTimeCasual(long seconds, bool morePrecision = false)
	{
		long num = seconds / 60;
		seconds -= num * 60;
		if (num > 0)
		{
			long num2 = num / 60;
			num -= num2 * 60;
			if (num2 > 0)
			{
				long num3 = num2 / 24;
				num2 -= num3 * 24;
				if (num3 > 0)
				{
					if (morePrecision)
					{
						return $"{num3}{Te.xt(D)} {num2}{Te.xt(H)} {num}{Te.xt(M)}";
					}
					if (num2 > 0)
					{
						return $"{num3}{Te.xt(D)} {num2}{Te.xt(H)}";
					}
					return $"{num3}{Te.xt(D)}";
				}
				if (morePrecision)
				{
					return $"{num2}{Te.xt(H)} {num}{Te.xt(M)} {seconds}{Te.xt(S)}";
				}
				if (num > 0)
				{
					return $"{num2}{Te.xt(H)} {num}{Te.xt(M)}";
				}
				return $"{num2}{Te.xt(H)}";
			}
			return $"{num}{Te.xt(M)} {seconds}{Te.xt(S)}";
		}
		return $"{seconds}{Te.xt(S)}";
	}

	public static int GetSecondsUtilMidnight()
	{
		DateTime now = DateTime.Now;
		int num = now.Second + now.Minute * 60 + now.Hour * 3600;
		return 86400 - num;
	}

	public static string GetYearAbbreviated(DateTime dateTime)
	{
		int year = dateTime.Year;
		string text = year.ToString();
		if (year < 2100)
		{
			text = text.Substring(2);
		}
		return text;
	}

	public static string RandomString(int size)
	{
		if (alaphaNumericalChars == null)
		{
			alaphaNumericalChars = new char[62];
			alaphaNumericalChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
		}
		char[] array = alaphaNumericalChars;
		byte[] array2 = new byte[size];
		new RNGCryptoServiceProvider().GetBytes(array2);
		StringBuilder stringBuilder = new StringBuilder(size);
		byte[] array3 = array2;
		foreach (byte b in array3)
		{
			stringBuilder.Append(array[b % array.Length]);
		}
		return stringBuilder.ToString();
	}

	public static string MD5(string input)
	{
		using MD5 mD = System.Security.Cryptography.MD5.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static float ParseFloat(string str)
	{
		return float.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture);
	}

	public static int ParseInt(string str)
	{
		return int.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture);
	}

	public static long ParseLong(string str)
	{
		return long.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture);
	}

	public static void Log(string msg)
	{
		if (!CheckLogLimit(msg))
		{
			Debug.Log(msg);
		}
	}

	public static void Log(string msg, GameObject context)
	{
		if (!CheckLogLimit(msg))
		{
			Debug.Log(msg, context);
		}
	}

	public static void LogIfEditor(string msg)
	{
	}

	public static void LogWarning(string msg)
	{
		if (!CheckLogLimit(msg))
		{
			Debug.LogWarning(msg);
		}
	}

	public static void LogWarning(string msg, GameObject context)
	{
		if (!CheckLogLimit(msg))
		{
			Debug.LogWarning(msg, context);
		}
	}

	public static void LogWarningIfEditor(string msg)
	{
	}

	public static void LogError(string msg)
	{
		if (!CheckLogLimit(msg))
		{
			Debug.LogError(msg);
		}
	}

	public static void LogError(string msg, GameObject context)
	{
		if (!CheckLogLimit(msg))
		{
			Debug.LogError(msg, context);
		}
	}

	public static void LogErrorIfEditor(string msg)
	{
	}

	private static bool CheckLogLimit(string msg)
	{
		if (msg == null)
		{
			return true;
		}
		if (logSize < 5242880)
		{
			logSize += msg.Length;
			if (logSize >= 5242880)
			{
				Debug.Log("LOG LIMIT REACHED");
			}
			return false;
		}
		return true;
	}

	public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, IncludeFilePredicate includePredicate = null)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
		if (!directoryInfo.Exists)
		{
			throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
		}
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (!Directory.Exists(destDirName))
		{
			Directory.CreateDirectory(destDirName);
		}
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			string text = Path.Combine(destDirName, fileInfo.Name);
			if (includePredicate == null || includePredicate(fileInfo, text))
			{
				fileInfo.CopyTo(text, overwrite: true);
			}
		}
		if (copySubDirs)
		{
			DirectoryInfo[] array = directories;
			foreach (DirectoryInfo directoryInfo2 in array)
			{
				string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
				DirectoryCopy(directoryInfo2.FullName, destDirName2, copySubDirs, includePredicate);
			}
		}
	}

	public static Resolution[] GetScreenResolutions(bool removeDuplicates = true)
	{
		if (!removeDuplicates)
		{
			return Screen.resolutions;
		}
		HashSet<string> hashSet = new HashSet<string>();
		List<Resolution> list = new List<Resolution>();
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution item = resolutions[i];
			string item2 = item.width + "x" + item.height;
			if (!hashSet.Contains(item2))
			{
				hashSet.Add(item2);
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	public static Color ConvertColor(string colorStr)
	{
		switch (colorStr)
		{
		case "#white":
			return ColorConstants.white;
		case "#cyan":
			return ColorConstants.rarityUncommon;
		case "#yellow":
			return ColorConstants.rarityRare;
		case "#green":
			return ColorConstants.rarityHeroic;
		case "#blue":
			return ColorConstants.rarityEpic;
		case "#red":
			return ColorConstants.rarityLegendary;
		case "#magenta":
			return ColorConstants.magenta;
		default:
		{
			Color color = default(Color);
			if (ColorUtility.TryParseHtmlString(colorStr, out color))
			{
				return color;
			}
			return ColorConstants.invalid;
		}
		}
	}
}
