using haxe.lang;

namespace haxe.zip._InflateImpl
{
	public class State : Enum
	{
		public static readonly State Head;

		public static readonly State Block;

		public static readonly State CData;

		public static readonly State Flat;

		public static readonly State Crc;

		public static readonly State Dist;

		public static readonly State DistOne;

		public static readonly State Done;

		protected static readonly string[] __hx_constructs;

		protected State(int index)
			: base(0)
		{
		}
	}
}
