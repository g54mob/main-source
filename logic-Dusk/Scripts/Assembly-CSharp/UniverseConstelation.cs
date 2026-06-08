public class UniverseConstelation
{
	private string finalGroupKey = string.Empty;

	private int lastGroupKeyInternalID;

	private int lastKnownInternalID = -1;

	private string _guiThumbnail = string.Empty;

	public int InternalID { get; set; }

	public string GroupKey
	{
		get
		{
			if (lastGroupKeyInternalID != InternalID)
			{
				finalGroupKey = string.Format("CNSTLN_{0}", InternalID);
				lastGroupKeyInternalID = InternalID;
			}
			return finalGroupKey;
		}
	}

	public string name
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "NAME", string.Empty);
		}
		set
		{
			UniverseSaveFile.Save(GroupKey, "NAME", value);
		}
	}

	public string guiThumbnail
	{
		get
		{
			if (lastKnownInternalID != InternalID)
			{
				_guiThumbnail = string.Format("CNSTLN_{0}_tm", InternalID);
				lastKnownInternalID = InternalID;
			}
			return _guiThumbnail;
		}
	}

	public override string ToString()
	{
		return string.Format("ID: {0}", InternalID);
	}
}
