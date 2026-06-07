using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagTimeSpan : Tag, IEquatable<TagTimeSpan>
	{
		public TimeSpan value;

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

		public TagTimeSpan()
		{
		}

		public TagTimeSpan(TimeSpan value)
		{
		}

		internal TagTimeSpan(Stream stream)
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

		internal static TimeSpan ReadTimeSpan(Stream stream)
		{
			return default(TimeSpan);
		}

		internal static void WriteTimeSpan(Stream stream, TimeSpan value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagTimeSpan(TimeSpan value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagTimeSpan other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
