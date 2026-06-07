using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagFloatArray : Tag, IEquatable<TagFloatArray>
	{
		public float[] value;

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

		public TagFloatArray()
		{
		}

		public TagFloatArray(float[] value)
		{
		}

		internal TagFloatArray(Stream stream)
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

		internal static float[] ReadFloatArray(Stream stream)
		{
			return null;
		}

		internal static void WriteFloatArray(Stream stream, float[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagFloatArray(float[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagFloatArray other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
