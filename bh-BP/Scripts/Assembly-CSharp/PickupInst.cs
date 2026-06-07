using System;
using UnityEngine;

[Serializable]
public class PickupInst
{
	public PickupType Type;

	public Vector3 Pos;

	public int SpawnTurn;

	public float RemainingLifetime;

	public int ExtraData;

	[NonSerialized]
	public PickupObj Obj;

	public PickupInst(PickupType t, int turn)
	{
	}

	public PickupInst(PickupInst toCopy)
	{
	}

	public bool IsImportant()
	{
		return false;
	}

	public float GetValue()
	{
		return 0f;
	}
}
