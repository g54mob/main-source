using System.Runtime.InteropServices;

namespace Aura2API
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct VisibleCellData
	{
		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += 12;
					_byteSize += 16;
					_byteSize += 12;
				}
				return _byteSize;
			}
		}
	}
}
