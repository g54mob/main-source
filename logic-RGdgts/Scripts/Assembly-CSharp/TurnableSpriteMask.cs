using System;
using Fix;
using UnityEngine;

[Serializable]
public class TurnableSpriteMask
{
	public TurnableSprite turnableSprite;

	private int rotationI;

	private SpriteMask mask;

	public bool enabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector3 localPosition
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public void SetParent(Transform parent, bool worldPositionStay)
	{
	}

	public bool IsEmpty()
	{
		return false;
	}

	public void Init(SpriteMask mask)
	{
	}

	public void Destroy()
	{
	}

	public void SetRotation(int rotationI)
	{
	}

	public static implicit operator SpriteMask(TurnableSpriteMask tsm)
	{
		return null;
	}
}
