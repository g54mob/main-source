using UnityEngine;

namespace Assets.Scripts.Web
{
	public abstract class WebRequest
	{
		public abstract string Error { get; }

		public WWWForm Form { get; private set; }

		public abstract bool IsDone { get; }

		public abstract float Progress { get; }

		public abstract string Text { get; }

		public abstract byte[] Bytes { get; }

		public abstract string Url { get; }

		private static bool IsMac
		{
			get
			{
				if (Application.platform != RuntimePlatform.OSXEditor)
				{
					return Application.platform == RuntimePlatform.OSXPlayer;
				}
				return true;
			}
		}

		public static WebRequest Create(string url)
		{
			if (IsMac)
			{
				return new WebRequestDotNet(url);
			}
			return new WebRequestUnity(url);
		}

		public static WebRequest Create(string url, WWWForm form)
		{
			return new WebRequestUnity(url, form);
		}
	}
}
