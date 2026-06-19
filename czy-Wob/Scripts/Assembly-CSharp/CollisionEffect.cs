using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CollisionEffect
{
	public float chanceToProcess = 0.05f;

	public List<FloraInteractionType> typesEffected = new List<FloraInteractionType> { FloraInteractionType.ALL };

	public List<GutFloraEffect> effects = new List<GutFloraEffect>();

	public bool CheckCollision(FloraInteractionType collidingType)
	{
		if (UnityEngine.Random.value > chanceToProcess)
		{
			return false;
		}
		if (typesEffected.Contains(FloraInteractionType.ALL))
		{
			return true;
		}
		if (!typesEffected.Contains(collidingType))
		{
			return false;
		}
		return true;
	}
}
