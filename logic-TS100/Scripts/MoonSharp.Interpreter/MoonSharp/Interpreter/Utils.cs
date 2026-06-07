using System;

namespace MoonSharp.Interpreter
{
	internal static class Utils
	{
		internal static bool IsDbNull(this object p)
		{
			if (p != null)
			{
				return Convert.IsDBNull(p);
			}
			return false;
		}
	}
}
