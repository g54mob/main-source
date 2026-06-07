using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagEnd : Tag
	{
		public override byte tagID => 0;

		public override object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string toString()
		{
			return null;
		}

		internal override void readTag(Stream stream)
		{
		}

		internal override void writeTag(Stream stream)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
