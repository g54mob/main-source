using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo.CreateVideo
{
	public class InvalidChannelException : Exception
	{
		public InvalidChannelException(string apiData)
			: base(apiData)
		{
		}
	}
}
