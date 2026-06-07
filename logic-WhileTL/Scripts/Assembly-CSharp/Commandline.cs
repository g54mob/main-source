using System;

internal static class Commandline
{
	private static string[] Get()
	{
		return Environment.GetCommandLineArgs();
	}

	public static bool IsSet(string flag)
	{
		string[] array = Get();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == flag)
			{
				return true;
			}
		}
		return false;
	}

	public static string GetString(string name)
	{
		string[] array = Get();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == name)
			{
				if (i + 1 >= array.Length)
				{
					return string.Empty;
				}
				return array[i + 1];
			}
		}
		return string.Empty;
	}

	public static string GetString(int i)
	{
		string[] array = Get();
		if (i >= array.Length)
		{
			return string.Empty;
		}
		return array[i];
	}

	public static int GetInt(string name)
	{
		string text = GetString(name);
		if (text.Length <= 0)
		{
			return -1;
		}
		return int.Parse(text);
	}

	public static float GetFloat(string name)
	{
		string text = GetString(name);
		if (text.Length <= 0)
		{
			return float.MinValue;
		}
		return float.Parse(text);
	}
}
