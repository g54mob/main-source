using System;
using System.Runtime.CompilerServices;

namespace MagicaCloth2
{
	[Serializable]
	public struct ExBitFlag16
	{
		public ushort Value;

		public ExBitFlag16(ushort initialValue = 0)
		{
			Value = 0;
		}

		public void Clear()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFlag(ushort flag, bool sw)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsSet(ushort flag)
		{
			return false;
		}
	}
}
