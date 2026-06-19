using System;

[Serializable]
public struct OnUseLootDrop
{
	public ObjectID lootDropID;

	public int amount;

	public float chance;
}
