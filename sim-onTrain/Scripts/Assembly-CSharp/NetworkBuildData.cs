using System;
using UnityEngine;

[Serializable]
public struct NetworkBuildData
{
	public string itemName;

	public Vector3 localPosition;

	public Vector3 localEulerAngles;

	public float health;

	public int wagonID;

	public string itemID;

	public string stateData;

	public bool isNetworkObject;

	public string parentObjectID;

	public int parentLeafIndex;

	public NetworkBuildData(string name, Vector3 localPos, Vector3 localEuler, float hp, int wagon, string uniqueID, string state = "", bool isNetwork = false, string parentObjectID = "", int parentLeafIndex = -1)
	{
		itemName = name;
		localPosition = localPos;
		localEulerAngles = localEuler;
		health = hp;
		wagonID = wagon;
		itemID = uniqueID;
		stateData = state;
		isNetworkObject = isNetwork;
		this.parentObjectID = parentObjectID;
		this.parentLeafIndex = parentLeafIndex;
	}

	public PropSaveSystem.PropSaveData ToPropSaveData()
	{
		return new PropSaveSystem.PropSaveData(itemName, localPosition, localEulerAngles, wagonID, isNetworkObject, itemID, stateData, health, parentObjectID, parentLeafIndex);
	}

	public static NetworkBuildData FromPropSaveData(PropSaveSystem.PropSaveData propData)
	{
		return new NetworkBuildData(propData.itemName, propData.localPosition, propData.localEulerAngles, propData.health, propData.wagonIndex, propData.uniqueID, propData.stateData, propData.isNetworkObject, propData.parentObjectID, propData.parentLeafIndex);
	}
}
