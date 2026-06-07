using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagSByte : Tag, IEquatable<TagSByte>
	{
		public sbyte value;

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

		public TagSByte()
		{
		}

		public TagSByte(sbyte value)
		{
		}

		internal TagSByte(Stream stream)
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

		internal static sbyte ReadSByte(Stream stream)
		{
			return 0;
		}

		internal static void WriteSByte(Stream stream, sbyte value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagSByte(sbyte value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagSByte other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
