using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagVector3Array : Tag, IEquatable<TagVector3Array>
	{
		public Vector3[] value;

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

		public TagVector3Array()
		{
		}

		public TagVector3Array(Vector3[] value)
		{
		}

		internal TagVector3Array(Stream stream)
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

		internal static Vector3[] ReadVector3Array(Stream stream)
		{
			return null;
		}

		internal static void WriteVector3Array(Stream stream, Vector3[] value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagVector3Array(Vector3[] value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagVector3Array other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
