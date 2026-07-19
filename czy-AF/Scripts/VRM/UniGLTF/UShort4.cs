using System;
using System.Runtime.InteropServices;

namespace UniGLTF
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct UShort4
	{
		public ushort x;

		public ushort y;

		public ushort z;

		public ushort w;

		public UShort4(ushort _x, ushort _y, ushort _z, ushort _w)
		{
			x = _x;
			y = _y;
			z = _z;
			w = _w;
		}
	}
}
