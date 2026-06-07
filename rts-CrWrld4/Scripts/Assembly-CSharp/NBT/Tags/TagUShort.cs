using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagUShort : Tag, IEquatable<TagUShort>
	{
		public ushort value;

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

		public TagUShort()
		{
		}

		public TagUShort(ushort value)
		{
		}

		internal TagUShort(Stream stream)
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

		internal static ushort ReadUShort(Stream stream)
		{
			return 0;
		}

		internal static void WriteUShort(Stream stream, ushort value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagUShort(ushort value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagUShort other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
