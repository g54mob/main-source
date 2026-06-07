using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagIntArray : Tag, IEquatable<TagIntArray>
	{
		public int[] value;

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

		public TagIntArray()
		{
		}

		public TagIntArray(int[] value)
		{
		}

		internal TagIntArray(Stream stream)
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

		internal static int[] ReadIntegerArray(Stream stream)
		{
			return null;
		}

		internal static void WriteIntegerArray(Stream stream, int[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagIntArray(int[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagIntArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
