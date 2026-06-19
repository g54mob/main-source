using System;
using System.Collections.Generic;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class SpriteMaterialFromEntity : MonoBehaviour, IGraphicalSpawn, IEntityMonoBehaviourDataPreview
{
	[Serializable]
	public struct MaterialOverride
	{
		public OptionalValue<ObjectID> requireObjectID;

		public OptionalValue<int> requireVariation;

		public OptionalValue<Season> requireSeason;

		public List<Material> material;
	}

	public List<SpriteObject> spriteObjects;

	public List<MaterialOverride> overrideConditions;

	private List<Material> _defaultMaterials = new List<Material>();

	private void LazyInit()
	{
		if (spriteObjects.Count == _defaultMaterials.Count)
		{
			return;
		}
		_defaultMaterials.Clear();
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			_defaultMaterials.Add(spriteObject.material);
		}
	}

	public void Awake()
	{
		LazyInit();
	}

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (!entityManager.HasComponent<ObjectDataCD>(entity))
		{
			Debug.LogError($"{base.name} has {typeof(SpriteSkinFromEntityAndSeason)}, but the entity has no {typeof(ObjectDataCD)}");
			return;
		}
		Season season = Manager.prefs.season;
		ObjectDataCD componentData = entityManager.GetComponentData<ObjectDataCD>(entity);
		UpdateMaterial(componentData.objectID, componentData.variation, season);
	}

	public void UpdateGraphicsFromObjectInfo(ObjectInfo objectInfo)
	{
		UpdateMaterial(objectInfo.objectID, objectInfo.variation, Season.None);
	}

	private void UpdateMaterial(ObjectID objectID, int variation, Season currentSeason)
	{
		foreach (MaterialOverride overrideCondition in overrideConditions)
		{
			bool num = objectID == overrideCondition.requireObjectID.GetOrDefault(objectID);
			bool flag = variation == overrideCondition.requireVariation.GetOrDefault(variation);
			bool flag2 = currentSeason == overrideCondition.requireSeason.GetOrDefault(currentSeason);
			if (num && flag && flag2)
			{
				for (int i = 0; i < spriteObjects.Count; i++)
				{
					SpriteObject spriteObject = spriteObjects[i];
					spriteObject.material = overrideCondition.material[i];
					spriteObject.ApplyVisualChange();
				}
				return;
			}
		}
		for (int j = 0; j < spriteObjects.Count; j++)
		{
			SpriteObject spriteObject2 = spriteObjects[j];
			spriteObject2.material = _defaultMaterials[j];
			spriteObject2.ApplyVisualChange();
		}
	}

	public void OnValidate()
	{
		foreach (MaterialOverride overrideCondition in overrideConditions)
		{
			List<Material> material = overrideCondition.material;
			object elementToFillOutWith;
			if (overrideCondition.material.Count <= 0)
			{
				elementToFillOutWith = null;
			}
			else
			{
				List<Material> material2 = overrideCondition.material;
				elementToFillOutWith = material2[material2.Count - 1];
			}
			material.Resize((Material)elementToFillOutWith, spriteObjects.Count);
		}
	}
}
