using System;

namespace Newtonsoft.Json.Bson.Utilities
{
	internal static class ConvertUtils
	{
		public static bool TryConvertGuid(string s, out Guid g)
		{
			g = default(Guid);
			return false;
		}
	}
}
