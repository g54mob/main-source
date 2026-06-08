using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo
{
	public class InvalidVideoIdException : Exception
	{
		public InvalidVideoIdException(string apiData)
			: base(apiData)
		{
		}
	}
}
