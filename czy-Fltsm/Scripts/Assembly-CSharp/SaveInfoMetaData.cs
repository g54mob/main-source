using System;

[Serializable]
public struct SaveInfoMetaData
{
	public string CommunityName { get; private set; }

	public int DrifterCount { get; private set; }

	public float PlayTime { get; private set; }

	public int Day { get; private set; }

	public DateTime TimeStamp { get; private set; }

	public GameVersion GameVersion { get; private set; }

	public int Size { get; private set; }

	public void Copy(SaveInfo saveInfo)
	{
		CommunityName = saveInfo.CommunityName;
		DrifterCount = saveInfo.DrifterCount;
		PlayTime = saveInfo.PlayTime;
		Day = saveInfo.Day;
		TimeStamp = saveInfo.TimeStamp;
		GameVersion = saveInfo.GameVersion;
		Size = saveInfo.Size;
	}
}
