using System;

namespace Assets.Packages.SocialPlatforms.Steam.Events
{
	public class GameWebCallbackEventArgs : EventArgs
	{
		public string Url { get; private set; }

		public GameWebCallbackEventArgs(string url)
		{
			Url = url;
		}
	}
}
