using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo.CreateVideo
{
	public class UnauthorizedException : Exception
	{
		public UnauthorizedException(string apiData)
			: base(apiData)
		{
		}
	}
}
