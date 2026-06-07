using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XColor
	{
		public byte A { get; private set; }

		public byte R { get; private set; }

		public byte G { get; private set; }

		public byte B { get; private set; }

		public uint Value { get; private set; }

		internal XColor(XGamingRuntime.Interop.XColor interopStruct)
		{
		}
	}
}
