using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagShort : Tag, IEquatable<TagShort>
	{
		public short value;

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

		public override byte tagID => 0;

		public TagShort()
		{
		}

		public TagShort(short value)
		{
		}

		internal TagShort(Stream stream)
		{
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

		internal static short ReadShort(Stream stream)
		{
			return 0;
		}

		internal static void WriteShort(Stream stream, short value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagShort(short value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagShort other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
