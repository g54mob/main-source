using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public abstract class CmsPbeKey : ICipherParameters
	{
		internal readonly char[] password;

		internal readonly byte[] salt;

		internal readonly int iterationCount;

		public string Password => null;

		public byte[] Salt => null;

		public int IterationCount => 0;

		public string Algorithm => null;

		public string Format => null;

		public CmsPbeKey(string password, byte[] salt, int iterationCount)
		{
		}

		public CmsPbeKey(string password, AlgorithmIdentifier keyDerivationAlgorithm)
		{
		}

		public CmsPbeKey(char[] password, byte[] salt, int iterationCount)
		{
		}

		public CmsPbeKey(char[] password, AlgorithmIdentifier keyDerivationAlgorithm)
		{
		}

		~CmsPbeKey()
		{
		}

		public byte[] GetSalt()
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}

		internal abstract KeyParameter GetEncoded(string algorithmOid);
	}
}
