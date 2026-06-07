using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagBoolArray : Tag, IEquatable<TagBoolArray>
	{
		public bool[] value;

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

		public TagBoolArray()
		{
		}

		public TagBoolArray(bool[] value)
		{
		}

		internal TagBoolArray(Stream stream)
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

		internal static bool[] ReadBoolArray(Stream stream)
		{
			return null;
		}

		internal static void WriteBoolArray(Stream stream, bool[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagBoolArray(bool[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagBoolArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
