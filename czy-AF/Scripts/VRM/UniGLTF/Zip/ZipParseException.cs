using System;

namespace UniGLTF.Zip
{
	internal class ZipParseException : Exception
	{
		public ZipParseException(string msg)
			: base(msg)
		{
		}
	}
}
