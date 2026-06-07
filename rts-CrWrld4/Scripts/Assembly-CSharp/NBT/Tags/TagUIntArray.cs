using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagUIntArray : Tag, IEquatable<TagUIntArray>
	{
		public uint[] value;

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

		public TagUIntArray()
		{
		}

		public TagUIntArray(uint[] value)
		{
		}

		internal TagUIntArray(Stream stream)
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

		internal static uint[] ReadUIntegerArray(Stream stream)
		{
			return null;
		}

		internal static void WriteUIntegerArray(Stream stream, uint[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagUIntArray(uint[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagUIntArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
