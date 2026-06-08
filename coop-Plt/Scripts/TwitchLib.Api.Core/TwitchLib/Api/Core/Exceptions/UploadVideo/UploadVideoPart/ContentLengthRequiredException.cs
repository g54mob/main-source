using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo.UploadVideoPart
{
	public class ContentLengthRequiredException : Exception
	{
		public ContentLengthRequiredException(string apiData)
			: base(apiData)
		{
		}
	}
}
