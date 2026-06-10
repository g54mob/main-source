using System;

namespace ModIO
{
	[Serializable]
	public struct DownloadReference
	{
		public ModId modId;

		public string url;

		public string filename;

		public bool IsValid()
		{
			return false;
		}
	}
}
