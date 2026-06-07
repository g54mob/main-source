using System;
using System.IO;
using System.Net.NetworkInformation;

namespace NBT.Tags
{
	public sealed class TagMAC : Tag, IEquatable<TagMAC>
	{
		public PhysicalAddress value;

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

		public TagMAC()
		{
		}

		public TagMAC(PhysicalAddress value)
		{
		}

		internal TagMAC(Stream stream)
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

		internal static PhysicalAddress ReadMAC(Stream stream)
		{
			return null;
		}

		internal static void WriteMAC(Stream stream, PhysicalAddress value)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static explicit operator TagMAC(PhysicalAddress value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagMAC other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
