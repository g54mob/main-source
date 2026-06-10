using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloorSaveData
{
	public string floorName;

	public Vector2 size;

	public int defaultFloorHeight;

	public int defaultCeilingHeight;

	public List<AddressSaveData> a_d;

	public List<TileSaveData> t_d;
}
