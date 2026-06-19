using System;
using System.IO;

namespace zlib
{
	[Serializable]
	internal sealed class ZStreamException : IOException
	{
		public ZStreamException()
		{
		}

		public ZStreamException(string s)
			: base(s)
		{
		}
	}
}
