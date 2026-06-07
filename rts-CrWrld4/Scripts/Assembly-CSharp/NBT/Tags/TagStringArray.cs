using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagStringArray : Tag, IEquatable<TagStringArray>
	{
		public string[] value;

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

		public TagStringArray()
		{
		}

		public TagStringArray(string[] value)
		{
		}

		internal TagStringArray(Stream stream)
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

		internal static string[] ReadStringArray(Stream stream)
		{
			return null;
		}

		internal static void WriteStringArray(Stream stream, string[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagStringArray(string[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagStringArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
