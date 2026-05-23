using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CableSaveData
{
	public int cableID;

	public CableEndpointSaveData startPoint;

	public CableEndpointSaveData endPoint;

	public List<Vector3> waypoints;

	public List<Vector3> midPointPositions;

	public float maxSpeed;

	public Color cableColor;
}
