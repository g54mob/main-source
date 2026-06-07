using System;
using System.IO;
using System.Net;

namespace NBT.Tags
{
	public sealed class TagIP : Tag, IEquatable<TagIP>
	{
		public IPAddress value;

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

		public TagIP()
		{
		}

		public TagIP(IPAddress value)
		{
		}

		internal TagIP(Stream stream)
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

		internal static IPAddress ReadIP(Stream stream)
		{
			return null;
		}

		internal static void WriteIP(Stream stream, IPAddress value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagIP(IPAddress value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagIP other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
