using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagDateTime : Tag, IEquatable<TagDateTime>
	{
		public DateTime value;

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

		public TagDateTime()
		{
		}

		public TagDateTime(DateTime value)
		{
		}

		internal TagDateTime(Stream stream)
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

		internal static DateTime ReadDateTime(Stream stream)
		{
			return default(DateTime);
		}

		internal static void WriteDateTime(Stream stream, DateTime value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagDateTime(DateTime value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagDateTime other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
