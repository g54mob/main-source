using System.Collections.Generic;
using System.IO;

namespace kcp2k
{
	internal class Segment
	{
		internal uint conv;

		internal uint cmd;

		internal uint frg;

		internal uint wnd;

		internal uint ts;

		internal uint sn;

		internal uint una;

		internal uint resendts;

		internal int rto;

		internal uint fastack;

		internal uint xmit;

		internal MemoryStream data;

		internal static readonly Stack<Segment> Pool;

		public static Segment Take()
		{
			return null;
		}

		public static void Return(Segment seg)
		{
		}

		internal int Encode(byte[] ptr, int offset)
		{
			return 0;
		}

		internal void Reset()
		{
		}
	}
}
