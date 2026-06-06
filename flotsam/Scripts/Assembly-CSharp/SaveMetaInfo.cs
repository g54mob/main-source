using System;
using System.IO;
using System.Runtime.Serialization;
using PajamaLlama.Persistence;
using UnityEngine;

[Serializable]
public class SaveMetaInfo : IComparable<SaveMetaInfo>, ISerializable
{
	public static readonly float MINIMUM_SAVE_INTERVAL = 5f;

	public string Name;

	public string CommunityName;

	public int CommunityMembersInt;

	public float PlayTime;

	public DateTime DateTime;

	[OptionalField(VersionAdded = 2)]
	public GameVersion Version;

	public SaveType Type;

	[OptionalField(VersionAdded = 3)]
	public int DaysSurvived;

	public int AutosaveIteration;

	private byte[] _data;

	[NonSerialized]
	private WorldPersistentData _worldPersistentData;

	private static bool _deserializeData;

	public string Path { get; private set; }

	public int Size { get; private set; }

	public SaveMetaInfo(string name, SaveType saveType = SaveType.Manual)
	{
		Name = name;
		Type = saveType;
	}

	public SaveMetaInfo(SaveInfo saveInfo, byte[] data)
	{
		Name = saveInfo.Name;
		CommunityName = saveInfo.CommunityName;
		CommunityMembersInt = saveInfo.DrifterCount;
		PlayTime = saveInfo.PlayTime;
		DateTime = saveInfo.TimeStamp;
		Version = saveInfo.GameVersion;
		Type = saveInfo.Type;
		DaysSurvived = saveInfo.Day;
		_data = data;
	}

	protected SaveMetaInfo(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString("Name");
		CommunityName = info.GetString("CommunityName");
		CommunityMembersInt = info.GetInt32("CommunityMembersInt");
		PlayTime = info.GetSingle("PlayTime");
		DateTime = info.GetDateTime("DateTime");
		Version = (GameVersion)info.GetValue("Version", typeof(GameVersion));
		Type = (SaveType)info.GetValue("Type", typeof(SaveType));
		DaysSurvived = info.GetInt32("DaysSurvived");
		AutosaveIteration = info.GetInt32("AutosaveIteration");
		if (_deserializeData)
		{
			_data = info.GetValue("_data", typeof(byte[])) as byte[];
		}
	}

	private void SetWorldPersistentData(WorldPersistentData worldPersistentData)
	{
		_worldPersistentData = worldPersistentData;
		CommunityName = "[Trello]" + Name;
		try
		{
			DateTime = DateTime.Now;
		}
		catch (TimeZoneNotFoundException)
		{
			DateTime = DateTime.UtcNow;
		}
	}

	public void Restore()
	{
		GameManager.TimeManager.LastSavedPlayTime = PlayTime;
	}

	public int CompareTo(SaveMetaInfo other)
	{
		return other.DateTime.CompareTo(DateTime);
	}

	public static bool TryDeserialize(StorageActionResult storageActionResult, out SaveMetaInfo saveMetaInfo)
	{
		saveMetaInfo = null;
		if (storageActionResult != null && storageActionResult.Succes)
		{
			return TryDeserialize(storageActionResult.Filename, storageActionResult.Data, out saveMetaInfo, deserializeData: true);
		}
		return false;
	}

	public static bool TryDeserialize(string path, byte[] bytes, out SaveMetaInfo instance, bool deserializeData = false)
	{
		try
		{
			_deserializeData = deserializeData;
			object obj = PersistenceLifeCycle.Deserialize(bytes);
			if (obj is WorldPersistentData)
			{
				instance = new SaveMetaInfo("[Trello] " + System.IO.Path.GetFileName(path));
				instance.SetWorldPersistentData(obj as WorldPersistentData);
			}
			else
			{
				instance = obj as SaveMetaInfo;
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			instance = null;
		}
		finally
		{
			_deserializeData = false;
		}
		if (instance != null)
		{
			instance.Path = path;
			instance.Size = bytes.Length;
		}
		return instance != null;
	}

	public bool TryDeserializeData<T>(out T obj)
	{
		if (_data == null)
		{
			if (typeof(T).Equals(typeof(WorldPersistentData)) && _worldPersistentData != null)
			{
				obj = (T)(object)_worldPersistentData;
				return true;
			}
			obj = default(T);
			return false;
		}
		return TryDeserializeData<T>(_data, out obj);
	}

	public static bool TryDeserializeData<T>(byte[] data, out T obj)
	{
		try
		{
			obj = (T)PersistenceLifeCycle.Deserialize(data);
			return true;
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("Data deserialization failed with error: {0}\r\n{1}", ex.Message, ex.StackTrace);
			obj = default(T);
			return false;
		}
	}

	public static bool TryReturnDirectory(string communityName, SaveType type, out string directory)
	{
		directory = SaveInfo.PLAYER_SAVES_DIRECTORY + communityName + "/";
		if (type == SaveType.Autosave)
		{
			directory += "Autosaves/";
		}
		return Directory.Exists(directory);
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("Name", Name);
		info.AddValue("CommunityName", CommunityName);
		info.AddValue("CommunityMembersInt", CommunityMembersInt);
		info.AddValue("PlayTime", PlayTime);
		info.AddValue("DateTime", DateTime);
		info.AddValue("Version", Version);
		info.AddValue("Type", Type);
		info.AddValue("DaysSurvived", DaysSurvived);
		info.AddValue("AutosaveIteration", AutosaveIteration);
		info.AddValue("_data", _data);
	}
}
