using System;

namespace Platforms
{
	public abstract class PlatformException : Exception
	{
		public PlatformException(string m = "")
			: base(m)
		{
		}
	}
}
