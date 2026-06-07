using UnityEngine;

namespace CTS
{
	public static class StringExtensions
	{
		public static string AbsoluteToRelativePath(this string absolutePath)
		{
			string text = absolutePath.Replace('\\', '/');
			if (text.StartsWith(Application.dataPath))
			{
				text = "Assets" + absolutePath.Substring(Application.dataPath.Length);
			}
			return text;
		}
	}
}
