using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagUInt : Tag, IEquatable<TagUInt>
	{
		public uint value;

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

		public TagUInt()
		{
		}

		public TagUInt(uint value)
		{
		}

		internal TagUInt(Stream stream)
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

		internal static uint ReadUInt(Stream stream)
		{
			return 0u;
		}

		internal static void WriteUInt(Stream stream, uint value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagUInt(uint value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagUInt other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
