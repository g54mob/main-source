using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XColor
	{
		public byte A { get; }

		public byte R { get; }

		public byte G { get; }

		public byte B { get; }

		public uint Value { get; }

		internal XColor(XGamingRuntime.Interop.XColor interopStruct)
		{
			A = interopStruct.A;
			R = interopStruct.R;
			G = interopStruct.G;
			B = interopStruct.B;
			Value = BitConverter.ToUInt32(new byte[4] { interopStruct.A, interopStruct.R, interopStruct.G, interopStruct.B }, 0);
		}
	}
}
