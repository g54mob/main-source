using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagByte : Tag, IEquatable<TagByte>
	{
		public byte value;

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

		public TagByte()
		{
		}

		public TagByte(byte value)
		{
		}

		internal TagByte(Stream stream)
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

		internal static byte ReadByte(Stream stream)
		{
			return 0;
		}

		internal static void WriteByte(Stream stream, byte value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagByte(byte value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagByte other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
