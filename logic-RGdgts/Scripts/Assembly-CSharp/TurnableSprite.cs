using System;
using UnityEngine;

[Serializable]
public struct TurnableSprite
{
	public Sprite defaultSprite;

	public Sprite diagonalSprite;

	public SpriteRotationInfo GetRotationInfo(int rotationI)
	{
		return default(SpriteRotationInfo);
	}
}
