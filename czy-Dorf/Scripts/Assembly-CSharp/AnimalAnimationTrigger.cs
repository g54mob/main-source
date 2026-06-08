using System;
using UnityEngine;

[Serializable]
public class AnimalAnimationTrigger : IWeightedRandomizable
{
	[SerializeField]
	private float probability = 1f;

	public int triggerIndex;

	public float clipDuration;

	public float Probability => probability;
}
