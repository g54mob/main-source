using System;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.MapGeneration;

[Serializable]
public class RandomMapObject
{
	public int amount;

	public int maxAmount;

	public float checkRadius;

	public float scaleMin;

	public float scaleMax;

	public float maxSlopeAngle;

	public float upOffset;

	public GameObject[] prefabs;

	public Vector3 randomRotationVector;

	public bool alignWithNormal;

	public int GetAmount()
	{
		//IL_004c: Expected I4, but got O
		if (maxAmount != 0)
		{
			if (MyRandom.random != null)
			{
				int maxValue = maxAmount + 1;
				return MyRandom.random.Next(amount, maxValue);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return amount;
	}

	public RandomMapObject()
	{
		//IL_0016: Expected O, but got I4
		amount = 10;
		randomRotationVector = (Vector3)0;
		checkRadius = 0.5f;
		scaleMin = 0.75f;
		scaleMax = 1.25f;
		maxSlopeAngle = 90f;
		_ = 1065353216;
		base._002Ector();
	}
}
