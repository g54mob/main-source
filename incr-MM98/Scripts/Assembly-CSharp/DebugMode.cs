public static class DebugMode
{
	public enum Type
	{
		StudioName = 0,
		StartingMoney = 1,
		SkipComponentUnlock = 2
	}

	public static bool Debug
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool StudioName
	{
		get
		{
			if (Debug)
			{
				return GetValue(Type.StudioName);
			}
			return false;
		}
		set
		{
			SetValue(Type.StudioName, value);
		}
	}

	public static bool StartingMoney
	{
		get
		{
			if (Debug)
			{
				return GetValue(Type.StartingMoney);
			}
			return false;
		}
		set
		{
			SetValue(Type.StartingMoney, value);
		}
	}

	public static bool SkipComponentUnlock
	{
		get
		{
			if (Debug)
			{
				return GetValue(Type.SkipComponentUnlock);
			}
			return false;
		}
		set
		{
			SetValue(Type.SkipComponentUnlock, value);
		}
	}

	public static bool GetValue(Type type)
	{
		return false;
	}

	public static void SetValue(Type type, bool value)
	{
	}

	public static void ToggleValue(Type type)
	{
		SetValue(type, !GetValue(type));
	}

	public static string Key(Type type)
	{
		return $"debug_{type}";
	}
}
