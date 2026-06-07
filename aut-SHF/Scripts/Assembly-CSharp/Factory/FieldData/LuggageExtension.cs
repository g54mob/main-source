using System.Collections.Generic;

namespace Factory.FieldData
{
	public static class LuggageExtension
	{
		private static Dictionary<eLuggage, string> luggageStringCache;

		public static bool IsRecyclable(this eLuggage self, bool includeParts)
		{
			return false;
		}

		public static string ToLuggageString(this IEnumerable<ILuggageCarrier> datas, string sep = ",")
		{
			return null;
		}

		public static string ToLuggageString(this ILuggageCarrier lug)
		{
			return null;
		}

		public static string ToCachedLuggageString(this eLuggage luggage)
		{
			return null;
		}
	}
}
