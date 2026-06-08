using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo
{
	public class InternalServerErrorException : Exception
	{
		public InternalServerErrorException(string apiData)
			: base(apiData)
		{
		}
	}
}
