using System.Collections.Generic;
using NaughtyAttributes;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpriteVariationFromEntityVariation : MonoBehaviour, IGraphicalSpawn
{
	public enum VariationType
	{
		WallDecoration = 0,
		Torch = 1,
		Other = 2
	}

	public List<SpriteObject> spriteObjects;

	public VariationType variationType;

	public bool hasMultipleDownVariants;

	[AllowNesting]
	[ShowIf("hasMultipleDownVariants")]
	public int downVariants;

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (!entityManager.HasComponent<ObjectDataCD>(entity))
		{
			Debug.LogError($"{base.name} has {typeof(SpriteVariationFromEntityVariation)}, but the entity has no {typeof(ObjectDataCD)}.");
		}
		else if (spriteObjects.Count != 0)
		{
			SetVariation(entityManager.GetComponentData<ObjectDataCD>(entity).variation);
		}
	}

	public void SetVariation(int variation)
	{
		int num = variation;
		int num2 = default(int);
		if (variationType == VariationType.Torch)
		{
			num2 = variation switch
			{
				1 => 1133833840, 
				2 => -1577224171, 
				3 => 1133833840, 
				4 => 595663797, 
				_ => 0, 
			};
			num = num2;
		}
		else if (variationType == VariationType.WallDecoration)
		{
			num2 = variation switch
			{
				0 => 1133833840, 
				1 => 595663797, 
				3 => 595663797, 
				_ => 0, 
			};
			num = num2;
		}
		if (variation == 2 && hasMultipleDownVariants)
		{
			int num3 = Unity.Mathematics.Random.CreateFromIndex(PugRandom.GetSeedFromVector(EntityMonoBehaviour.ToWorldFromRender(base.transform.position))).NextInt(0, downVariants);
			switch (num3)
			{
			case 0:
				num2 = -568891545;
				break;
			case 1:
				num2 = -1458546703;
				break;
			case 2:
				num2 = 806946379;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num3);
				break;
			}
			num = num2;
		}
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			if (variationType == VariationType.Other)
			{
				spriteObject.transform.localScale = Vector3.one;
				spriteObject.SetVariantByIndex(num);
			}
			else
			{
				bool flag = (variationType == VariationType.Torch && variation == 4) || (variationType == VariationType.WallDecoration && variation == 3);
				spriteObject.transform.localScale = ((variation == 3 && flag) ? new Vector3(-1f, 1f, 1f) : Vector3.one);
				spriteObject.SetVariant(num);
			}
		}
	}
}
