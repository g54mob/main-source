using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagDouble : Tag, IEquatable<TagDouble>
	{
		public double value;

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

		public TagDouble()
		{
		}

		public TagDouble(double value)
		{
		}

		internal TagDouble(Stream stream)
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

		internal static double ReadDouble(Stream stream)
		{
			return 0.0;
		}

		internal static void WriteDouble(Stream stream, double value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagDouble(double value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagDouble other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
