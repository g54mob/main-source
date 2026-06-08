using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo.UploadVideoPart
{
	public class UploadFailedException : Exception
	{
		public UploadFailedException(string apiData)
			: base(apiData)
		{
		}
	}
}
