using System;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagFloat : Tag, IEquatable<TagFloat>
	{
		private static byte[] buffer;

		private static byte[] emptyBytes;

		public float value;

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

		public TagFloat()
		{
		}

		public TagFloat(float value)
		{
		}

		internal TagFloat(Stream stream)
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

		internal static float ReadFloat(Stream stream)
		{
			return 0f;
		}

		internal static void WriteFloat(Stream stream, float value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagFloat(float value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagFloat other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
