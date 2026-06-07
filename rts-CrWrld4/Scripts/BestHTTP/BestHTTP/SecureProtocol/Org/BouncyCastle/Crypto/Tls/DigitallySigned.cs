using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class DigitallySigned
	{
		protected readonly SignatureAndHashAlgorithm mAlgorithm;

		protected readonly byte[] mSignature;

		public virtual SignatureAndHashAlgorithm Algorithm => null;

		public virtual byte[] Signature => null;

		public DigitallySigned(SignatureAndHashAlgorithm algorithm, byte[] signature)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static DigitallySigned Parse(TlsContext context, Stream input)
		{
			return null;
		}
	}
}
