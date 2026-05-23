using System;
using UnityEngine;

[Serializable]
public class ServerSaveData
{
	public string serverID;

	public int customerID;

	public string ip;

	public int serverType;

	public Vector3 position;

	public Quaternion rotation;

	public int rackPositionUID;

	public int prefabID;

	public bool isOn;

	public bool isBroken;

	public int eoltime;

	public int defaultEOLTime;
}
