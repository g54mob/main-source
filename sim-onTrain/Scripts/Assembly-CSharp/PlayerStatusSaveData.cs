using System;

[Serializable]
public struct PlayerStatusSaveData
{
	public bool hasData;

	public float posX;

	public float posY;

	public float posZ;

	public float rotX;

	public float rotY;

	public float rotZ;

	public float health;

	public float food;

	public float water;

	public int lastSelectedSlot;
}
