using System;
using System.Runtime.InteropServices;

namespace BCnEncoder.Encoder.Bptc
{
	internal struct IndexBlock4x4
	{
		public byte i00;

		public byte i10;

		public byte i20;

		public byte i30;

		public byte i01;

		public byte i11;

		public byte i21;

		public byte i31;

		public byte i02;

		public byte i12;

		public byte i22;

		public byte i32;

		public byte i03;

		public byte i13;

		public byte i23;

		public byte i33;

		public Span<byte> AsSpan => MemoryMarshal.CreateSpan(ref i00, 16);

		public byte this[int x, int y]
		{
			get
			{
				return AsSpan[x + y * 4];
			}
			set
			{
				AsSpan[x + y * 4] = value;
			}
		}

		public byte this[int index]
		{
			get
			{
				return AsSpan[index];
			}
			set
			{
				AsSpan[index] = value;
			}
		}
	}
}
