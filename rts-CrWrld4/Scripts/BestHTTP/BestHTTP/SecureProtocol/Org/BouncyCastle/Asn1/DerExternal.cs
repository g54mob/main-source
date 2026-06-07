using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerExternal : Asn1Object
	{
		private DerObjectIdentifier directReference;

		private DerInteger indirectReference;

		private Asn1Object dataValueDescriptor;

		private int encoding;

		private Asn1Object externalContent;

		public Asn1Object DataValueDescriptor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DerObjectIdentifier DirectReference
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Encoding
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Asn1Object ExternalContent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DerInteger IndirectReference
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DerExternal(Asn1EncodableVector vector)
		{
		}

		public DerExternal(DerObjectIdentifier directReference, DerInteger indirectReference, Asn1Object dataValueDescriptor, DerTaggedObject externalData)
		{
		}

		public DerExternal(DerObjectIdentifier directReference, DerInteger indirectReference, Asn1Object dataValueDescriptor, int encoding, Asn1Object externalData)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}

		protected override int Asn1GetHashCode()
		{
			return 0;
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		private static Asn1Object GetObjFromVector(Asn1EncodableVector v, int index)
		{
			return null;
		}

		private static void WriteEncodable(MemoryStream ms, Asn1Encodable e)
		{
		}
	}
}
