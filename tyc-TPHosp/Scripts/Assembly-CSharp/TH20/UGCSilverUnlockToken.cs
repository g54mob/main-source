using FullSerializerSave;

namespace TH20
{
	public class UGCSilverUnlockToken : ISilverUnlockToken
	{
		[fsProperty]
		private string _contentID;

		public string ContentID => _contentID;

		public UGCSilverUnlockToken(string contentID)
		{
			_contentID = contentID;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is UGCSilverUnlockToken uGCSilverUnlockToken))
			{
				return false;
			}
			return uGCSilverUnlockToken.ContentID == ContentID;
		}

		public override int GetHashCode()
		{
			if (_contentID == null)
			{
				return 0;
			}
			return _contentID.GetHashCode();
		}
	}
}
