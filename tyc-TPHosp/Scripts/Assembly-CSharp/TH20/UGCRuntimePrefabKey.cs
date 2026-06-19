namespace TH20
{
	[DontSave]
	public struct UGCRuntimePrefabKey
	{
		private string _contentID;

		private int _upgradeLevel;

		public UGCRuntimePrefabKey(string contentID, int upgradeLevel)
		{
			_contentID = contentID;
			_upgradeLevel = upgradeLevel;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is UGCRuntimePrefabKey uGCRuntimePrefabKey))
			{
				return false;
			}
			if (uGCRuntimePrefabKey._contentID == _contentID)
			{
				return uGCRuntimePrefabKey._upgradeLevel == _upgradeLevel;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((_contentID != null) ? _contentID.GetHashCode() : 0) ^ _upgradeLevel.GetHashCode();
		}
	}
}
