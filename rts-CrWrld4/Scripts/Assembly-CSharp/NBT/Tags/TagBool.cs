using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagBool : Tag, IEquatable<TagBool>
	{
		public bool value;

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

		public TagBool()
		{
		}

		public TagBool(bool value)
		{
		}

		internal TagBool(Stream stream)
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

		internal static bool ReadBool(Stream stream)
		{
			return false;
		}

		internal static void WriteBool(Stream stream, bool value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagBool(bool value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagBool other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
