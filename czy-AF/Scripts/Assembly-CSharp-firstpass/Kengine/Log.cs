using UnityEngine;

namespace Kengine
{
	public class Log : MonoBehaviour
	{
		private static string pre = "<color=#FF1F6A>kengine: </color>";

		public static void Print(string txt, bool error = false, GameObject context = null)
		{
			if (!error)
			{
				Debug.Log(pre + txt, context);
			}
			else
			{
				Debug.LogError(pre + txt, context);
			}
		}

		public static void Print(string txt, bool error)
		{
			Print(txt, error, null);
		}

		public static void Print(string txt)
		{
			Print(txt, false, null);
		}
	}
}
