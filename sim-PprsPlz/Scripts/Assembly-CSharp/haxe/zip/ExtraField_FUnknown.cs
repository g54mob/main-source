using haxe.io;

namespace haxe.zip
{
	public sealed class ExtraField_FUnknown : ExtraField
	{
		public readonly int tag;

		public readonly Bytes bytes;

		public ExtraField_FUnknown(int tag, Bytes bytes)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}
