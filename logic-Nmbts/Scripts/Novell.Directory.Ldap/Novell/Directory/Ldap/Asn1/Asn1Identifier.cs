using System;
using System.IO;

namespace Novell.Directory.Ldap.Asn1
{
	public class Asn1Identifier : ICloneable
	{
		public const int UNIVERSAL = 0;

		public const int APPLICATION = 1;

		public const int CONTEXT = 2;

		public const int PRIVATE = 3;

		private int tagClass;

		private bool constructed;

		private int tag;

		private int encodedLength;

		public virtual int Asn1Class
		{
			get
			{
				return tagClass;
			}
		}

		public virtual bool Constructed
		{
			get
			{
				return constructed;
			}
		}

		public virtual int Tag
		{
			get
			{
				return tag;
			}
		}

		public virtual int EncodedLength
		{
			get
			{
				return encodedLength;
			}
		}

		[CLSCompliant(false)]
		public virtual bool Universal
		{
			get
			{
				return tagClass == 0;
			}
		}

		[CLSCompliant(false)]
		public virtual bool Application
		{
			get
			{
				return tagClass == 1;
			}
		}

		[CLSCompliant(false)]
		public virtual bool Context
		{
			get
			{
				return tagClass == 2;
			}
		}

		[CLSCompliant(false)]
		public virtual bool Private
		{
			get
			{
				return tagClass == 3;
			}
		}

		public Asn1Identifier(int tagClass, bool constructed, int tag)
		{
			this.tagClass = tagClass;
			this.constructed = constructed;
			this.tag = tag;
		}

		public Asn1Identifier(Stream in_Renamed)
		{
			int num = in_Renamed.ReadByte();
			encodedLength++;
			if (num < 0)
			{
				throw new EndOfStreamException("BERDecoder: decode: EOF in Identifier");
			}
			tagClass = num >> 6;
			constructed = (num & 0x20) != 0;
			tag = num & 0x1F;
			if (tag == 31)
			{
				tag = decodeTagNumber(in_Renamed);
			}
		}

		public Asn1Identifier()
		{
		}

		public void reset(Stream in_Renamed)
		{
			encodedLength = 0;
			int num = in_Renamed.ReadByte();
			encodedLength++;
			if (num < 0)
			{
				throw new EndOfStreamException("BERDecoder: decode: EOF in Identifier");
			}
			tagClass = num >> 6;
			constructed = (num & 0x20) != 0;
			tag = num & 0x1F;
			if (tag == 31)
			{
				tag = decodeTagNumber(in_Renamed);
			}
		}

		private int decodeTagNumber(Stream in_Renamed)
		{
			int num = 0;
			int num2;
			do
			{
				num2 = in_Renamed.ReadByte();
				encodedLength++;
				if (num2 < 0)
				{
					throw new EndOfStreamException("BERDecoder: decode: EOF in tag number");
				}
				num = (num << 7) + (num2 & 0x7F);
			}
			while ((num2 & 0x80) != 0);
			return num;
		}

		public object Clone()
		{
			try
			{
				return MemberwiseClone();
			}
			catch (Exception)
			{
				throw new SystemException("Internal error, cannot create clone");
			}
		}
	}
}
