namespace Kitchen
{
	public static class WarningLevelExtensions
	{
		public static WarningLevel If(this WarningLevel warning, bool b)
		{
			if (!b)
			{
				return WarningLevel.Safe;
			}
			return warning;
		}

		public static bool IsActive(this WarningLevel warning)
		{
			if (warning != WarningLevel.Error)
			{
				return warning == WarningLevel.Warning;
			}
			return true;
		}

		public static bool IsBlocking(this WarningLevel warning)
		{
			if (warning != WarningLevel.Error && warning != WarningLevel.Warning)
			{
				return warning == WarningLevel.Unknown;
			}
			return true;
		}
	}
}
