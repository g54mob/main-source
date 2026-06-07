using System;
using System.Runtime.CompilerServices;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public struct BitArray
	{
		public byte Data { get; set; }

		public bool this[int index]
		{
			get
			{
				return GetBit(index);
			}
			set
			{
				SetBit(index, value);
			}
		}

		public BitArray(byte initialData = 0)
		{
			Data = initialData;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetBit(int index)
		{
			if (index < 0 || index > 7)
			{
				throw new ArgumentOutOfRangeException("index", "Index must be between 0 and 7.");
			}
			return (Data & (1 << index)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetBit(int index, bool bit)
		{
			if (index < 0 || index > 7)
			{
				throw new ArgumentOutOfRangeException("index", "Index must be between 0 and 7.");
			}
			if (bit)
			{
				Data |= (byte)(1 << index);
			}
			else
			{
				Data &= (byte)(~(1 << index));
			}
		}
	}
}
