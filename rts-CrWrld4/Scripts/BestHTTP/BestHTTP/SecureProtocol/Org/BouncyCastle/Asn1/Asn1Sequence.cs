using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class Asn1Sequence : Asn1Object, IEnumerable
	{
		private class Asn1SequenceParserImpl : Asn1SequenceParser, IAsn1Convertible
		{
			private readonly Asn1Sequence outer;

			private readonly int max;

			private int index;

			public Asn1SequenceParserImpl(Asn1Sequence outer)
			{
			}

			public IAsn1Convertible ReadObject()
			{
				return null;
			}

			public Asn1Object ToAsn1Object()
			{
				return null;
			}
		}

		internal Asn1Encodable[] elements;

		public virtual Asn1SequenceParser Parser => null;

		public virtual Asn1Encodable Item => null;

		public virtual int Count => 0;

		public static Asn1Sequence GetInstance(object obj)
		{
			return null;
		}

		public static Asn1Sequence GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		protected internal Asn1Sequence()
		{
		}

		protected internal Asn1Sequence(Asn1Encodable element)
		{
		}

		protected internal Asn1Sequence(params Asn1Encodable[] elements)
		{
		}

		protected internal Asn1Sequence(Asn1EncodableVector elementVector)
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

		public override string ToString()
		{
			return null;
		}
	}
}
