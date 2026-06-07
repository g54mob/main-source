using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagLongArray : Tag, IEquatable<TagLongArray>
	{
		public long[] value;

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

		public TagLongArray()
		{
		}

		public TagLongArray(long[] value)
		{
		}

		internal TagLongArray(Stream stream)
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

		internal static long[] ReadLongArray(Stream stream)
		{
			return null;
		}

		internal static void WriteLongArray(Stream stream, long[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagLongArray(long[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagLongArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
