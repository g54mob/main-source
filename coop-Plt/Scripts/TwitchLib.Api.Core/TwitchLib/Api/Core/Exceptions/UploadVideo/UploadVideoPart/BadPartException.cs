using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo.UploadVideoPart
{
	public class BadPartException : Exception
	{
		public BadPartException(string apiData)
			: base(apiData)
		{
		}
	}
}
