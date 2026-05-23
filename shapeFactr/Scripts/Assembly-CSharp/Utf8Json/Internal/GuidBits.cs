using System;
using System.Runtime.InteropServices;

namespace Utf8Json.Internal
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 16)]
	internal struct GuidBits
	{
		[FieldOffset(0)]
		public readonly Guid Value;

		[FieldOffset(0)]
		public readonly byte Byte0;

		[FieldOffset(1)]
		public readonly byte Byte1;

		[FieldOffset(2)]
		public readonly byte Byte2;

		[FieldOffset(3)]
		public readonly byte Byte3;

		[FieldOffset(4)]
		public readonly byte Byte4;

		[FieldOffset(5)]
		public readonly byte Byte5;

		[FieldOffset(6)]
		public readonly byte Byte6;

		[FieldOffset(7)]
		public readonly byte Byte7;

		[FieldOffset(8)]
		public readonly byte Byte8;

		[FieldOffset(9)]
		public readonly byte Byte9;

		[FieldOffset(10)]
		public readonly byte Byte10;

		[FieldOffset(11)]
		public readonly byte Byte11;

		[FieldOffset(12)]
		public readonly byte Byte12;

		[FieldOffset(13)]
		public readonly byte Byte13;

		[FieldOffset(14)]
		public readonly byte Byte14;

		[FieldOffset(15)]
		public readonly byte Byte15;

		private static byte[] byteToHexStringHigh;

		private static byte[] byteToHexStringLow;

		public GuidBits(ref Guid value)
		{
			Value = default(Guid);
			Byte0 = 0;
			Byte1 = 0;
			Byte2 = 0;
			Byte3 = 0;
			Byte4 = 0;
			Byte5 = 0;
			Byte6 = 0;
			Byte7 = 0;
			Byte8 = 0;
			Byte9 = 0;
			Byte10 = 0;
			Byte11 = 0;
			Byte12 = 0;
			Byte13 = 0;
			Byte14 = 0;
			Byte15 = 0;
		}

		public GuidBits(ref ArraySegment<byte> utf8string)
		{
			Value = default(Guid);
			Byte0 = 0;
			Byte1 = 0;
			Byte2 = 0;
			Byte3 = 0;
			Byte4 = 0;
			Byte5 = 0;
			Byte6 = 0;
			Byte7 = 0;
			Byte8 = 0;
			Byte9 = 0;
			Byte10 = 0;
			Byte11 = 0;
			Byte12 = 0;
			Byte13 = 0;
			Byte14 = 0;
			Byte15 = 0;
		}

		private static byte Parse(byte[] bytes, int highOffset)
		{
			return 0;
		}

		private static byte SwitchParse(byte b)
		{
			return 0;
		}

		public void Write(byte[] buffer, int offset)
		{
		}
	}
}
