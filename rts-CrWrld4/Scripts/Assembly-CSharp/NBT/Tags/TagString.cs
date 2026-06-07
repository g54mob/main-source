using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagString : Tag, IEquatable<TagString>
	{
		public string value;

		public override byte tagID => 0;

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

		public TagString()
		{
		}

		public TagString(string value)
		{
		}

		internal TagString(Stream stream)
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

		internal static string ReadString(Stream stream)
		{
			return null;
		}

		internal static void WriteString(Stream stream, string value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagString(string value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagString other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
