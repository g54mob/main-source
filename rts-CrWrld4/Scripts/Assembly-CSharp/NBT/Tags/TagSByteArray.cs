using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagSByteArray : Tag, IEquatable<TagSByteArray>
	{
		public sbyte[] value;

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

		public TagSByteArray()
		{
		}

		public TagSByteArray(sbyte[] value)
		{
		}

		internal TagSByteArray(Stream stream)
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

		internal static sbyte[] ReadSByteArray(Stream stream)
		{
			return null;
		}

		internal static void WriteSByteArray(Stream stream, sbyte[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagSByteArray(sbyte[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagSByteArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
