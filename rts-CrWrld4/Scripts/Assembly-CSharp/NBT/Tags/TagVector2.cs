using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagVector2 : Tag, IEquatable<TagVector2>
	{
		public Vector2 value;

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

		public TagVector2()
		{
		}

		public TagVector2(Vector2 value)
		{
		}

		internal TagVector2(Stream stream)
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

		internal static Vector2 ReadVector2(Stream stream)
		{
			return default(Vector2);
		}

		internal static void WriteVector2(Stream stream, Vector2 value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagVector2(Vector2 value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagVector2 other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
