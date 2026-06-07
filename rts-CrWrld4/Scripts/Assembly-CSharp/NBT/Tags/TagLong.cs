using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagLong : Tag, IEquatable<TagLong>
	{
		public long value;

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

		public TagLong()
		{
		}

		public TagLong(long value)
		{
		}

		internal TagLong(Stream stream)
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

		internal static long ReadLong(Stream stream)
		{
			return 0L;
		}

		internal static void WriteLong(Stream stream, long value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagLong(long value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagLong other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
