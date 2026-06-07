using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class DHParametersGenerator
	{
		private int size;

		private int certainty;

		private SecureRandom random;

		public virtual void Init(int size, int certainty, SecureRandom random)
		{
		}

		public virtual DHParameters GenerateParameters()
		{
			return null;
		}
	}
}
