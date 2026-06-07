using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class PKMacBuilder
	{
		private AlgorithmIdentifier owf;

		private AlgorithmIdentifier mac;

		private IPKMacPrimitivesProvider provider;

		private SecureRandom random;

		private PbmParameter parameters;

		private int iterationCount;

		private int saltLength;

		private int maxIterations;

		public PKMacBuilder()
		{
		}

		public PKMacBuilder(IPKMacPrimitivesProvider provider)
		{
		}

		public PKMacBuilder(IPKMacPrimitivesProvider provider, AlgorithmIdentifier digestAlgorithmIdentifier, AlgorithmIdentifier macAlgorithmIdentifier)
		{
		}

		public PKMacBuilder(IPKMacPrimitivesProvider provider, int maxIterations)
		{
		}

		private PKMacBuilder(AlgorithmIdentifier digestAlgorithmIdentifier, int iterationCount, AlgorithmIdentifier macAlgorithmIdentifier, IPKMacPrimitivesProvider provider)
		{
		}

		public PKMacBuilder SetSaltLength(int saltLength)
		{
			return null;
		}

		public PKMacBuilder SetIterationCount(int iterationCount)
		{
			return null;
		}

		public PKMacBuilder SetParameters(PbmParameter parameters)
		{
			return null;
		}

		public PKMacBuilder SetSecureRandom(SecureRandom random)
		{
			return null;
		}

		public IMacFactory Build(char[] password)
		{
			return null;
		}

		private void CheckIterationCountCeiling(int iterationCount)
		{
		}

		private IMacFactory GenCalculator(PbmParameter parameters, char[] password)
		{
			return null;
		}
	}
}
