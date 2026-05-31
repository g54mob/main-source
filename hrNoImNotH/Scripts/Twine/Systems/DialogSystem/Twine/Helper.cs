using System.Collections.Generic;

namespace Systems.DialogSystem.Twine
{
	public static class Helper
	{
		public static bool TryGetTweeDestination(string line, out string value, out string subValue)
		{
			value = null;
			subValue = null;
			return false;
		}

		public static bool TryGetTweeTags(string line, out string value, out List<string> tags)
		{
			value = null;
			tags = null;
			return false;
		}

		public static bool IsEndNode(this Node node)
		{
			return false;
		}
	}
}
