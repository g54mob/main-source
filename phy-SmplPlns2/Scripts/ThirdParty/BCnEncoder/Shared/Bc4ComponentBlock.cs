using System;

namespace BCnEncoder.Shared
{
	internal struct Bc4ComponentBlock
	{
		public ulong componentBlock;

		public byte Endpoint0
		{
			readonly get
			{
				return (byte)(componentBlock & 0xFF);
			}
			set
			{
				componentBlock &= 18446744073709551360uL;
				componentBlock |= value;
			}
		}

		public byte Endpoint1
		{
			readonly get
			{
				return (byte)((componentBlock >> 8) & 0xFF);
			}
			set
			{
				componentBlock &= 18446744073709486335uL;
				componentBlock |= (ulong)value << 8;
			}
		}

		public readonly byte GetComponentIndex(int pixelIndex)
		{
			ulong num = (ulong)(7L << pixelIndex * 3 + 16);
			int num2 = pixelIndex * 3 + 16;
			return (byte)((componentBlock & num) >> num2);
		}

		public void SetComponentIndex(int pixelIndex, byte redIndex)
		{
			ulong num = (ulong)(7L << pixelIndex * 3 + 16);
			int num2 = pixelIndex * 3 + 16;
			componentBlock &= ~num;
			componentBlock |= (ulong)((long)(redIndex & 7) << num2);
		}

		public readonly byte[] Decode()
		{
			byte[] array = new byte[16];
			byte endpoint = Endpoint0;
			byte endpoint2 = Endpoint1;
			Span<byte> span = ((endpoint <= endpoint2) ? stackalloc byte[8]
			{
				endpoint,
				endpoint2,
				endpoint.InterpolateFifth(endpoint2, 1),
				endpoint.InterpolateFifth(endpoint2, 2),
				endpoint.InterpolateFifth(endpoint2, 3),
				endpoint.InterpolateFifth(endpoint2, 4),
				0,
				byte.MaxValue
			} : stackalloc byte[8]
			{
				endpoint,
				endpoint2,
				endpoint.InterpolateSeventh(endpoint2, 1),
				endpoint.InterpolateSeventh(endpoint2, 2),
				endpoint.InterpolateSeventh(endpoint2, 3),
				endpoint.InterpolateSeventh(endpoint2, 4),
				endpoint.InterpolateSeventh(endpoint2, 5),
				endpoint.InterpolateSeventh(endpoint2, 6)
			});
			Span<byte> span2 = span;
			for (int i = 0; i < array.Length; i++)
			{
				byte componentIndex = GetComponentIndex(i);
				array[i] = span2[componentIndex];
			}
			return array;
		}
	}
}
