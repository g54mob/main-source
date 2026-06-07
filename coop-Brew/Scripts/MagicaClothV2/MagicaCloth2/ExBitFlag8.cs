using System;
using System.Runtime.CompilerServices;

namespace MagicaCloth2
{
	[Serializable]
	public struct ExBitFlag8
	{
		public byte Value;

		public ExBitFlag8(byte initialValue = 0)
		{
			Value = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFlag(byte flag, bool sw)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsSet(byte flag)
		{
			return false;
		}
	}
}
