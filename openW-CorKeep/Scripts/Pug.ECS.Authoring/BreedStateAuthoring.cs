using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BreedStateAuthoring : MonoBehaviour
{
	[Serializable]
	public struct VariationWithWeight
	{
		public int variation;

		public float weight;
	}

	public int mealsToTrigger = 3;

	public float minDistanceToBreed = 2f;

	public ObjectID babyType;

	public float mutationChance = 0.1f;

	public List<VariationWithWeight> mutationWeights = new List<VariationWithWeight>();
}
