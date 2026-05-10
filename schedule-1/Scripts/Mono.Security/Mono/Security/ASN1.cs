using System.Collections;

namespace Mono.Security
{
	public class ASN1
	{
		private byte m_nTag;

		private byte[] m_aValue;

		private ArrayList elist;

		public int Count => 0;

		public byte Tag => 0;

		public int Length => 0;

		public byte[] Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ASN1 this[int index] => null;

		public ASN1(byte tag)
		{
		}

		public ASN1(byte tag, byte[] data)
		{
		}

		public ASN1(byte[] data)
		{
		}

		private bool CompareArray(byte[] array1, byte[] array2)
		{
			return false;
		}

		public bool CompareValue(byte[] value)
		{
			return false;
		}

		public ASN1 Add(ASN1 asn1)
		{
			return null;
		}

		public virtual byte[] GetBytes()
		{
			return null;
		}

		protected void Decode(byte[] asn1, ref int anPos, int anLength)
		{
		}

		protected void DecodeTLV(byte[] asn1, ref int pos, out byte tag, out int length, out byte[] content)
		{
			tag = default(byte);
			length = default(int);
			content = null;
		}

		public ASN1 Element(int index, byte anTag)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
