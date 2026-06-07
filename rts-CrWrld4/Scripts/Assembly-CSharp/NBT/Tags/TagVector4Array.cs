using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagVector4Array : Tag, IEquatable<TagVector4Array>
	{
		public Vector4[] value;

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

		public TagVector4Array()
		{
		}

		public TagVector4Array(Vector4[] value)
		{
		}

		internal TagVector4Array(Stream stream)
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

		internal static Vector4[] ReadVector4Array(Stream stream)
		{
			return null;
		}

		internal static void WriteVector4Array(Stream stream, Vector4[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagVector4Array(Vector4[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagVector4Array other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
