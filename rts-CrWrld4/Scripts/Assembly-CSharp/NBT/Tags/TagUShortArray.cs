using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagUShortArray : Tag, IEquatable<TagUShortArray>
	{
		public ushort[] value;

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

		public TagUShortArray()
		{
		}

		public TagUShortArray(ushort[] value)
		{
		}

		internal TagUShortArray(Stream stream)
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

		internal static ushort[] ReadUShortArray(Stream stream)
		{
			return null;
		}

		internal static void WriteUShortArray(Stream stream, ushort[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagUShortArray(ushort[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagUShortArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
