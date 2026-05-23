using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
	private static SaveData _current;

	public PlayerData playerData;

	public int[] loadedScenes;

	public int version;

	public string nameOfSave;

	public NetworkSaveData networkData;

	public List<InteractObjectData> rackMountObjectData;

	public int[] isWallOpened;

	public List<InteractObjectData> interactObjectData;

	public int lastUsedRackPositionGlobalUID;

	public float wallPrice;

	public Dictionary<string, bool> shopItemUnlockStates;

	public bool isIPHintHidden;

	public static SaveData instance
	{
		get
		{
			return null;
		}
		set
		{
		}
	}
}
