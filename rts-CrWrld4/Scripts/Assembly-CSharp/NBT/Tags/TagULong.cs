using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagULong : Tag, IEquatable<TagULong>
	{
		public ulong value;

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

		public TagULong()
		{
		}

		public TagULong(ulong value)
		{
		}

		internal TagULong(Stream stream)
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

		internal static ulong ReadULong(Stream stream)
		{
			return 0uL;
		}

		internal static void WriteULong(Stream stream, ulong value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagULong(ulong value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagULong other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
