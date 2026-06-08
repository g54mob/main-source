using UnityEngine;

namespace Dorfromantik
{
	public class ClipboardUtility : MonoBehaviour
	{
		public static string GetClipboardEntry()
		{
			return GUIUtility.systemCopyBuffer;
		}

		public static void CopyToClipboard(string value)
		{
			GUIUtility.systemCopyBuffer = value;
		}
	}
}
