using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagShortArray : Tag, IEquatable<TagShortArray>
	{
		public short[] value;

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

		public TagShortArray()
		{
		}

		public TagShortArray(short[] value)
		{
		}

		internal TagShortArray(Stream stream)
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

		internal static short[] ReadShortArray(Stream stream)
		{
			return null;
		}

		internal static void WriteShortArray(Stream stream, short[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagShortArray(short[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagShortArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
