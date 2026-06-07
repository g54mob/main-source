using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	internal class PKMacFactory : IMacFactory
	{
		protected readonly PbmParameter parameters;

		private readonly byte[] key;

		public virtual object AlgorithmDetails => null;

		public PKMacFactory(byte[] key, PbmParameter parameters)
		{
		}

		public virtual IStreamCalculator CreateCalculator()
		{
			return null;
		}
	}
}
