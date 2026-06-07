using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagInt : Tag, IEquatable<TagInt>
	{
		private static byte[] buffer;

		private static byte[] emptyBytes;

		public int value;

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

		public TagInt()
		{
		}

		public TagInt(int value)
		{
		}

		internal TagInt(Stream stream)
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

		internal static int ReadInt(Stream stream)
		{
			return 0;
		}

		internal static void WriteInt(Stream stream, int value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagInt(int value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagInt other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
