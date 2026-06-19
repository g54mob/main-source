using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class CrossPlatformSessionData
{
	public Dictionary<Platform, string> platformSessionIds;

	public PlatformSessionParams platformSessionData;

	public static byte[] Serialize(CrossPlatformSessionData crossPlatformSessionData)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
		{
			binaryWriter.Write(crossPlatformSessionData.platformSessionData.SessionId);
			binaryWriter.Write(crossPlatformSessionData.platformSessionData.JoinString);
			binaryWriter.Write(crossPlatformSessionData.platformSessionData.MaxPlayers);
			binaryWriter.Write((int)crossPlatformSessionData.platformSessionData.WorldMode);
			binaryWriter.Write(crossPlatformSessionData.platformSessionData.IconIndex);
			binaryWriter.Write(crossPlatformSessionData.platformSessionData.WorldName);
			int count = crossPlatformSessionData.platformSessionIds.Count;
			binaryWriter.Write(count);
			foreach (KeyValuePair<Platform, string> platformSessionId in crossPlatformSessionData.platformSessionIds)
			{
				binaryWriter.Write((int)platformSessionId.Key);
				binaryWriter.Write(platformSessionId.Value);
			}
		}
		return memoryStream.ToArray();
	}

	public static CrossPlatformSessionData Deserialize(byte[] data)
	{
		CrossPlatformSessionData crossPlatformSessionData = new CrossPlatformSessionData();
		crossPlatformSessionData.platformSessionData = new PlatformSessionParams();
		crossPlatformSessionData.platformSessionIds = new Dictionary<Platform, string>();
		using MemoryStream input = new MemoryStream(data);
		using BinaryReader binaryReader = new BinaryReader(input);
		crossPlatformSessionData.platformSessionData.SessionId = binaryReader.ReadString();
		crossPlatformSessionData.platformSessionData.JoinString = binaryReader.ReadString();
		crossPlatformSessionData.platformSessionData.MaxPlayers = binaryReader.ReadUInt32();
		crossPlatformSessionData.platformSessionData.WorldMode = (WorldMode)binaryReader.ReadInt32();
		crossPlatformSessionData.platformSessionData.IconIndex = binaryReader.ReadInt32();
		crossPlatformSessionData.platformSessionData.WorldName = binaryReader.ReadString();
		int num = binaryReader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			Platform key = (Platform)binaryReader.ReadInt32();
			string value = binaryReader.ReadString();
			crossPlatformSessionData.platformSessionIds.Add(key, value);
		}
		return crossPlatformSessionData;
	}
}
