using System;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	internal struct DownloadObject
	{
		public string binary_url;

		public long date_expires;
	}
}
