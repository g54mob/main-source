using System;

namespace MLAPI.Transports.UNET
{
	public class InvalidConfigException : SystemException
	{
		public InvalidConfigException()
		{
		}

		public InvalidConfigException(string issue)
			: base(issue)
		{
		}
	}
}
