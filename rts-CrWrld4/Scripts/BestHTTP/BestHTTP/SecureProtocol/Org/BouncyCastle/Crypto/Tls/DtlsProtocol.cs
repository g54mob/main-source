using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class DtlsProtocol
	{
		protected readonly SecureRandom mSecureRandom;

		protected DtlsProtocol(SecureRandom secureRandom)
		{
		}

		protected virtual void ProcessFinished(byte[] body, byte[] expected_verify_data)
		{
		}

		internal static void ApplyMaxFragmentLengthExtension(DtlsRecordLayer recordLayer, short maxFragmentLength)
		{
		}

		protected static short EvaluateMaxFragmentLengthExtension(bool resumedSession, IDictionary clientExtensions, IDictionary serverExtensions, byte alertDescription)
		{
			return 0;
		}

		protected static byte[] GenerateCertificate(Certificate certificate)
		{
			return null;
		}

		protected static byte[] GenerateSupplementalData(IList supplementalData)
		{
			return null;
		}

		protected static void ValidateSelectedCipherSuite(int selectedCipherSuite, byte alertDescription)
		{
		}
	}
}
