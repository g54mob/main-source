using UnityEngine;

public struct SpriteRotationInfo
{
	public Sprite sprite;

	public Quaternion rotation;

	public SpriteRotationInfo(Sprite sprite, Quaternion rotation)
	{
		this.sprite = null;
		this.rotation = default(Quaternion);
	}
}
