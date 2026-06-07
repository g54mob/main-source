using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagByteArray : Tag, IEquatable<TagByteArray>
	{
		public byte[] value;

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

		public TagByteArray()
		{
		}

		public TagByteArray(byte[] value)
		{
		}

		internal TagByteArray(Stream stream)
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

		internal static byte[] ReadByteArray(Stream stream)
		{
			return null;
		}

		internal static void WriteByteArray(Stream stream, byte[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagByteArray(byte[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagByteArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
