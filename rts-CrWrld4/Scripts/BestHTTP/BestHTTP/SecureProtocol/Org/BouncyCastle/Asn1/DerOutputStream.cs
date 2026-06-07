using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerOutputStream : FilterStream
	{
		public DerOutputStream(Stream os)
			: base(null)
		{
		}

		private void WriteLength(int length)
		{
		}

		internal void WriteEncoded(int tag, byte[] bytes)
		{
		}

		internal void WriteEncoded(int tag, byte first, byte[] bytes)
		{
		}

		internal void WriteEncoded(int tag, byte[] bytes, int offset, int length)
		{
		}

		internal void WriteTag(int flags, int tagNo)
		{
		}

		internal void WriteEncoded(int flags, int tagNo, byte[] bytes)
		{
		}

		protected void WriteNull()
		{
		}

		public virtual void WriteObject(object obj)
		{
		}

		public virtual void WriteObject(Asn1Encodable obj)
		{
		}

		public virtual void WriteObject(Asn1Object obj)
		{
		}
	}
}
