using System;
using System.IO;
using UnityEngine;

namespace NBT.Tags
{
	public sealed class TagQuaternion : Tag, IEquatable<TagQuaternion>
	{
		public Quaternion value;

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

		public TagQuaternion()
		{
		}

		public TagQuaternion(Quaternion value)
		{
		}

		internal TagQuaternion(Stream stream)
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

		internal static Quaternion ReadQuaternion(Stream stream)
		{
			return default(Quaternion);
		}

		internal static void WriteQuaternion(Stream stream, Quaternion value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagQuaternion(Quaternion value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagQuaternion other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
