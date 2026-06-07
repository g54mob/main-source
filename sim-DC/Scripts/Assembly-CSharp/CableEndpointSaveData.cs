using System;
using UnityEngine;

[Serializable]
public class CableEndpointSaveData
{
	public CableLink.TypeOfLink type;

	public Vector3 position;

	public int customerID;

	public string switchID;

	public string serverID;
}
