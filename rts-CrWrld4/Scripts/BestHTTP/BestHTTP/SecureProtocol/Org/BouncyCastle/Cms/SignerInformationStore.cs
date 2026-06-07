using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class SignerInformationStore
	{
		private readonly IList all;

		private readonly IDictionary table;

		public int Count => 0;

		public SignerInformationStore(SignerInformation signerInfo)
		{
		}

		public SignerInformationStore(ICollection signerInfos)
		{
		}

		public SignerInformation GetFirstSigner(SignerID selector)
		{
			return null;
		}

		public ICollection GetSigners()
		{
			return null;
		}

		public ICollection GetSigners(SignerID selector)
		{
			return null;
		}
	}
}
