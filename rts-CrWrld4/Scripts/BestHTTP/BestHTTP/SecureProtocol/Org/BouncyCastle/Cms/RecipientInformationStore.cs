using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class RecipientInformationStore
	{
		private readonly IList all;

		private readonly IDictionary table;

		public RecipientInformation Item => null;

		public int Count => 0;

		public RecipientInformationStore(ICollection recipientInfos)
		{
		}

		public RecipientInformation GetFirstRecipient(RecipientID selector)
		{
			return null;
		}

		public ICollection GetRecipients()
		{
			return null;
		}

		public ICollection GetRecipients(RecipientID selector)
		{
			return null;
		}
	}
}
