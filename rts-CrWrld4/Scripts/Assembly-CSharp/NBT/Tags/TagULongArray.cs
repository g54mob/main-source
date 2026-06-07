using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagULongArray : Tag, IEquatable<TagULongArray>
	{
		public ulong[] value;

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

		public TagULongArray()
		{
		}

		public TagULongArray(ulong[] value)
		{
		}

		internal TagULongArray(Stream stream)
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

		internal static ulong[] ReadULongArray(Stream stream)
		{
			return null;
		}

		internal static void WriteULongArray(Stream stream, ulong[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagULongArray(ulong[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagULongArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
