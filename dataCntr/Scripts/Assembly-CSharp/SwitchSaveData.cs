using System;
using UnityEngine;

[Serializable]
public class SwitchSaveData
{
	public string switchID;

	public int switchType;

	public Vector3 position;

	public Quaternion rotation;

	public int rackPositionUID;

	public bool isOn;

	public string label;

	public bool isBroken;

	public int eoltime;

	public int defaultEOLTime;
}
