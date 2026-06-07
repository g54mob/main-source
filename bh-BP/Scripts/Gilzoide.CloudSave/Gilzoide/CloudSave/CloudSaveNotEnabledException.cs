using System;

namespace Gilzoide.CloudSave
{
	public class CloudSaveNotEnabledException : CloudSaveException
	{
		public CloudSaveNotEnabledException(string message)
			: base(null)
		{
		}

		public CloudSaveNotEnabledException(string message, Exception innerException)
			: base(null)
		{
		}
	}
}
