using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagDoubleArray : Tag, IEquatable<TagDoubleArray>
	{
		public double[] value;

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

		public TagDoubleArray()
		{
		}

		public TagDoubleArray(double[] value)
		{
		}

		internal TagDoubleArray(Stream stream)
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

		internal static double[] ReadDoubleArray(Stream stream)
		{
			return null;
		}

		internal static void WriteDoubleArray(Stream stream, double[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagDoubleArray(double[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagDoubleArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
