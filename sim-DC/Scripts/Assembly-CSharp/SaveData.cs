using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class SaveData
{
	private static SaveData _current;

	public PlayerData playerData;

	public List<TechnicianSaveData> technicianData;

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

	public bool saveComplete;

	public int[] hiredTechnicians;

	[OptionalField]
	public List<RepairJobSaveData> repairJobQueue;

	[OptionalField]
	public List<Vector3> assignedAppsLogos;

	public Vector3 trolleyPosition;

	public Quaternion trolleyRotation;

	[OptionalField]
	public BalanceSheetSaveData balanceSheetData;

	[OptionalField]
	public List<ModItemSaveData> modItemData;

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

	public string Validate()
	{
		return null;
	}
}
