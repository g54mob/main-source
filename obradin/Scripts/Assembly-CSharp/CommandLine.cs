using System;

public class CommandLine
{
	public static string all
	{
		get
		{
			return string.Join(" ", Environment.GetCommandLineArgs());
		}
	}

	public static bool log
	{
		get
		{
			return Get("log");
		}
	}

	public static bool _30fps
	{
		get
		{
			return Get("30fps");
		}
	}

	public static bool _60fps
	{
		get
		{
			return Get("60fps");
		}
	}

	public static bool freefps
	{
		get
		{
			return Get("freefps");
		}
	}

	public static bool syncfps
	{
		get
		{
			return Get("syncfps");
		}
	}

	public static bool Get(string name)
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		foreach (string text in commandLineArgs)
		{
			if (text == name)
			{
				return true;
			}
		}
		return false;
	}
}
