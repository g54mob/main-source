using System;

[Serializable]
public class ModConfig
{
	public string itemName;

	public int price;

	public int xpToUnlock;

	public int sizeInU;

	public float mass;

	public float modelScale;

	public float[] colliderSize;

	public float[] colliderCenter;

	public string modelFile;

	public string textureFile;

	public string iconFile;

	public PlayerManager.ObjectInHand objectType;
}
