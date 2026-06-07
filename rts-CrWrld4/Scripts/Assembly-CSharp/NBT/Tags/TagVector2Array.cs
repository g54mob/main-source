using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagVector2Array : Tag, IEquatable<TagVector2Array>
	{
		public Vector2[] value;

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

		public TagVector2Array()
		{
		}

		public TagVector2Array(Vector2[] value)
		{
		}

		internal TagVector2Array(Stream stream)
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

		internal static Vector2[] ReadVector2Array(Stream stream)
		{
			return null;
		}

		internal static void WriteVector2Array(Stream stream, Vector2[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagVector2Array(Vector2[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagVector2Array other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
