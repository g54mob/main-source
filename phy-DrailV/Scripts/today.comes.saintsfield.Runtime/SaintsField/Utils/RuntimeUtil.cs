using UnityEngine;

namespace SaintsField.Utils
{
	public static class RuntimeUtil
	{
		public static (string content, bool isCallback) ParseCallback(string content, bool isCallback = false)
		{
			if (isCallback || content == null)
			{
				return (content: content, isCallback: isCallback);
			}
			if (content.StartsWith("\\"))
			{
				return (content: content.Substring(1, content.Length - 1), isCallback: false);
			}
			if (content.StartsWith("$"))
			{
				return (content: content.Substring(1, content.Length - 1), isCallback: true);
			}
			return (content: content, isCallback: false);
		}

		public static bool IsNull(object obj)
		{
			if (obj is Object obj2)
			{
				return obj2 == null;
			}
			return obj == null;
		}
	}
}
