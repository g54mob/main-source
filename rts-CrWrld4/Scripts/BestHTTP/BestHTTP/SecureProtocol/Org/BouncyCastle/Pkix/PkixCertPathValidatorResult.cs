using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixCertPathValidatorResult
	{
		private TrustAnchor trustAnchor;

		private PkixPolicyNode policyTree;

		private AsymmetricKeyParameter subjectPublicKey;

		public PkixPolicyNode PolicyTree => null;

		public TrustAnchor TrustAnchor => null;

		public AsymmetricKeyParameter SubjectPublicKey => null;

		public PkixCertPathValidatorResult(TrustAnchor trustAnchor, PkixPolicyNode policyTree, AsymmetricKeyParameter subjectPublicKey)
		{
		}

		public object Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
