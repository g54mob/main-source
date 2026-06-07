using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagVector3 : Tag, IEquatable<TagVector3>
	{
		public Vector3 value;

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

		public TagVector3()
		{
		}

		public TagVector3(Vector3 value)
		{
		}

		internal TagVector3(Stream stream)
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

		internal static Vector3 ReadVector3(Stream stream)
		{
			return default(Vector3);
		}

		internal static void WriteVector3(Stream stream, Vector3 value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagVector3(Vector3 value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagVector3 other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
