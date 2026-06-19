using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public static class WebBrowser
	{
		public static void OpenWebPage(string url)
		{
			Application.OpenURL(url);
		}
	}
}
