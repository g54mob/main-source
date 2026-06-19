using System;

namespace ModIO
{
	[Serializable]
	public struct UserProfile
	{
		public string username;

		public long userId;

		public string portal_username;

		public DownloadReference avatar_original;

		public DownloadReference avatar_50x50;

		public DownloadReference avatar_100x100;

		public string timezone;

		public string language;
	}
}
