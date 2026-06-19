using System;
using UnityEngine;

[Serializable]
public class LegPair
{
	public GameObject leftLeg;

	public GameObject rightLeg;

	public LegPair(GameObject left, GameObject right)
	{
		leftLeg = left;
		rightLeg = right;
	}
}
