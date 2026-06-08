using System;

namespace TwitchLib.Api.Core.Exceptions.UploadVideo.CompleteUpload
{
	public class MissingPartsException : Exception
	{
		public MissingPartsException(string apiData)
			: base(apiData)
		{
		}
	}
}
