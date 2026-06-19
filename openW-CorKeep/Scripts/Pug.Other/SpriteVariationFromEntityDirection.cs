using System.Collections.Generic;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpriteVariationFromEntityDirection : MonoBehaviour, IGraphicalSpawn
{
	public List<SpriteObject> spritesToRotate;

	[Tooltip("If set, the right-facing variation is reused and reflected for the left-facing variation.")]
	public bool reflectSides = true;

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (!entityManager.HasComponent<DirectionCD>(entity))
		{
			Debug.LogError($"{base.name} has {typeof(SpriteVariationFromEntityDirection)}, but the entity has no {typeof(DirectionCD)}.");
		}
		else if (spritesToRotate.Count != 0)
		{
			SetDirection(entityManager.GetComponentData<DirectionCD>(entity).direction.RoundToInt2());
		}
	}

	public void SetDirection(int2 direction)
	{
		int variationFromDirection = DirectionBasedOnVariationCD.GetVariationFromDirection(direction);
		int variant = variationFromDirection switch
		{
			0 => 1133833840, 
			1 => 595663797, 
			3 => reflectSides ? 595663797 : (-1577224171), 
			_ => 0, 
		};
		foreach (SpriteObject item in spritesToRotate)
		{
			item.transform.localScale = ((variationFromDirection == 3 && reflectSides) ? new Vector3(-1f, 1f, 1f) : Vector3.one);
			item.SetVariant(variant);
		}
	}
}
