using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo
{
	public class InvalidUploadTokenException : Exception
	{
		public InvalidUploadTokenException(string apiData)
			: base(apiData)
		{
		}
	}
}
