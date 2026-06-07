using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagVector4 : Tag, IEquatable<TagVector4>
	{
		public Vector4 value;

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

		public TagVector4()
		{
		}

		public TagVector4(Vector4 value)
		{
		}

		internal TagVector4(Stream stream)
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

		internal static Vector4 ReadVector4(Stream stream)
		{
			return default(Vector4);
		}

		internal static void WriteVector4(Stream stream, Vector4 value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagVector4(Vector4 value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagVector4 other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
