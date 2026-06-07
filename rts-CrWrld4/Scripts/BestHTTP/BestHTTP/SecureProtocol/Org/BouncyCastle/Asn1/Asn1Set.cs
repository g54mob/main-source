using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class Asn1Set : Asn1Object, IEnumerable
	{
		private class Asn1SetParserImpl : Asn1SetParser, IAsn1Convertible
		{
			private readonly Asn1Set outer;

			private readonly int max;

			private int index;

			public Asn1SetParserImpl(Asn1Set outer)
			{
			}

			public IAsn1Convertible ReadObject()
			{
				return null;
			}

			public virtual Asn1Object ToAsn1Object()
			{
				return null;
			}
		}

		private class DerComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				return 0;
			}
		}

		internal Asn1Encodable[] elements;

		public virtual Asn1Encodable Item => null;

		public virtual int Count => 0;

		public Asn1SetParser Parser => null;

		public static Asn1Set GetInstance(object obj)
		{
			return null;
		}

		public static Asn1Set GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		protected internal Asn1Set()
		{
		}

		protected internal Asn1Set(Asn1Encodable element)
		{
		}

		protected internal Asn1Set(params Asn1Encodable[] elements)
		{
		}

		protected internal Asn1Set(Asn1EncodableVector elementVector)
		{
		}

		public virtual IEnumerator GetEnumerator()
		{
			return null;
		}

		public virtual Asn1Encodable[] ToArray()
		{
			return null;
		}

		protected override int Asn1GetHashCode()
		{
			return 0;
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		protected internal void Sort()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
