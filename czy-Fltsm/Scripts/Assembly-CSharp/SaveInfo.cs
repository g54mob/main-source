using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveInfo : IComparable<SaveInfo>
{
	public static readonly string EDITOR_SAVES_DIRECTORY = System.IO.Path.GetFullPath(Application.persistentDataPath + "/Editor Saves/");

	public static readonly string PLAYER_SAVES_DIRECTORY = System.IO.Path.GetFullPath(Application.persistentDataPath + "/Saves/");

	public const string AUTOSAVE_DIRECTORY = "Autosaves/";

	public const string SAVE_INFO_EXTENSION = ".fsi";

	public const string SAVE_META_INFO_EXTENSION = ".fs";

	public const string WORLD_PERSISTENT_DATA_EXTENSION = ".wpd";

	public string Path { get; private set; }

	public SaveType Type { get; private set; }

	public string Name { get; private set; }

	public string CommunityName { get; private set; }

	public int DrifterCount { get; private set; }

	public float PlayTime { get; private set; }

	public int Day { get; private set; }

	public DateTime TimeStamp { get; private set; }

	public GameVersion GameVersion { get; private set; }

	public int Size { get; private set; }

	public SaveObjectType ObjectType { get; private set; }

	public SaveInfo(string path, SaveType saveType, SaveObjectType objectType = SaveObjectType.SaveMetaInfo)
	{
		Path = path;
		Type = saveType;
		Name = System.IO.Path.GetFileNameWithoutExtension(path);
		ObjectType = objectType;
		Timestamp();
	}

	public SaveInfo(SaveMetaInfo saveMetaInfo)
	{
		Path = saveMetaInfo.Path;
		Type = saveMetaInfo.Type;
		Name = saveMetaInfo.Name;
		DrifterCount = saveMetaInfo.CommunityMembersInt;
		Day = saveMetaInfo.DaysSurvived;
		TimeStamp = saveMetaInfo.DateTime;
		GameVersion = saveMetaInfo.Version;
		Size = saveMetaInfo.Size;
		ObjectType = SaveObjectType.SaveMetaInfo;
	}

	public void Timestamp()
	{
		CommunityName = Community.PlayerCommunity.Name;
		DrifterCount = Community.PlayerCommunity.Agents.Count;
		PlayTime = GameManager.TimeManager.ReturnTotalTimePlayed();
		Day = GameManager.TimeManager.Days.Count;
		GameVersion = GameManager.Settings.Version;
		try
		{
			TimeStamp = DateTime.Now;
		}
		catch (TimeZoneNotFoundException)
		{
			TimeStamp = DateTime.UtcNow;
		}
	}

	public void SetSize(int size)
	{
		Size = size;
	}

	public void SetMetaData(SaveInfoMetaData metaData)
	{
		CommunityName = metaData.CommunityName;
		DrifterCount = metaData.DrifterCount;
		PlayTime = metaData.PlayTime;
		Day = metaData.Day;
		GameVersion = metaData.GameVersion;
		TimeStamp = metaData.TimeStamp;
		GameVersion = metaData.GameVersion;
		Size = metaData.Size;
	}

	public int CompareTo(SaveInfo other)
	{
		return other.TimeStamp.CompareTo(TimeStamp);
	}

	public string GetExtension()
	{
		return ObjectType switch
		{
			SaveObjectType.SaveMetaInfo => ".fs", 
			SaveObjectType.WorldPersistentData => ".wpd", 
			_ => throw new NotImplementedException(), 
		};
	}
}
