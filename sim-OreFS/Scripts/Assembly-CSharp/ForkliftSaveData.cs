using System;
using UnityEngine;

[Serializable]
public class ForkliftSaveData
{
	public Vector3 position;

	public Quaternion rotation;

	public string attachedPalletBuildingId;

	public string attachedDeliveryPalletId;

	public bool isDeliveryPallet;
}
