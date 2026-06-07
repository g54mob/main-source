using System;

[Serializable]
public class SaveData
{
	public string playerData;

	public string checksum;

	public SaveData(string data, string checksumString)
	{
		playerData = data;
		checksum = checksumString;
	}
}
