namespace haxe.zip
{
	public sealed class ExtraField_FInfoZipUnicodePath : ExtraField
	{
		public readonly string name;

		public readonly int crc;

		public ExtraField_FInfoZipUnicodePath(string name, int crc)
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
