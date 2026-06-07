using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TruckSaveData
{
	public Vector3 position;

	public Quaternion rotation;

	public List<SackSaveEntry> sacks = new List<SackSaveEntry>();

	public int currentItemCount;

	public int totalCapacityIndex;

	public bool isInDigsite;
}
