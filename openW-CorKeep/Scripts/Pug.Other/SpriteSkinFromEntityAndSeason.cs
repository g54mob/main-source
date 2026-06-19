using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteSkinFromEntityAndSeason : MonoBehaviour, IGraphicalSpawn, IEntityMonoBehaviourDataPreview
{
	[Serializable]
	public struct ReskinCondition
	{
		[Tooltip("Use None to match any ObjectID.")]
		public ObjectID objectID;

		public bool dependsOnVariation;

		[AllowNesting]
		[ShowIf("dependsOnVariation")]
		public int variation;

		[Tooltip("None matches any season.")]
		public Season season;

		public bool useAlternateSounds;

		[Tooltip("If null, the sprite's corresponding default is used.")]
		public List<SkinAndGradientMap> reskin;
	}

	[Serializable]
	public struct SkinAndGradientMap
	{
		public DataBlockRef<SpriteAssetSkin> skinRef;

		public DataBlockRef<GradientMapDataBlock> gradientMapRef;

		public bool hasEmissiveColorOverride;

		[ColorUsage(false, true)]
		public Color emissiveColorOverride;

		[FormerlySerializedAs("effects")]
		public GameObject glow;

		public SpriteAssetSkin skin => skinRef.Get();

		public GradientMapDataBlock gradientMap => gradientMapRef.Get();
	}

	public List<SpriteObject> spritesToReskin = new List<SpriteObject>();

	[ArrayElementTitle("objectID, variation, season")]
	[InfoBox("The sprites are re-skinned based on the first matching entry. If none match, the default skin is used. Each entry in the reskin list applies to the corresponding sprite in the spritesToReskin list.", EInfoBoxType.Normal)]
	public List<ReskinCondition> reskinConditions = new List<ReskinCondition>();

	private bool _hasAnyEmissiveColorOverrides;

	private List<Color> _defaultEmissiveColors = new List<Color>();

	[Tooltip("List of SpriteObjectAnimationEventEffects that will have alternate sounds enabled when applicable.")]
	public List<SpriteObjectAnimationEventEffects> animationEventEffects = new List<SpriteObjectAnimationEventEffects>();

	public void Awake()
	{
		foreach (SpriteObject item in spritesToReskin)
		{
			_defaultEmissiveColors.Add(item.emissiveColor);
		}
		_hasAnyEmissiveColorOverrides = false;
		foreach (ReskinCondition reskinCondition in reskinConditions)
		{
			foreach (SkinAndGradientMap item2 in reskinCondition.reskin)
			{
				if (item2.hasEmissiveColorOverride)
				{
					_hasAnyEmissiveColorOverrides = true;
					break;
				}
			}
		}
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
		UpdateSkin(componentData.objectID, componentData.variation, season);
	}

	public void UpdateGraphicsFromObjectInfo(ObjectInfo objectInfo)
	{
		UpdateSkin(objectInfo.objectID, objectInfo.variation, Season.None);
	}

	private void UpdateSkin(ObjectID objectID, int variation, Season currentSeason)
	{
		foreach (ReskinCondition reskinCondition in reskinConditions)
		{
			bool num = reskinCondition.objectID == ObjectID.None || reskinCondition.objectID == objectID;
			bool flag = !reskinCondition.dependsOnVariation || reskinCondition.variation == variation;
			bool flag2 = reskinCondition.season == Season.None || reskinCondition.season == currentSeason;
			if (!(num && flag && flag2))
			{
				continue;
			}
			for (int i = 0; i < spritesToReskin.Count; i++)
			{
				spritesToReskin[i].skinRef = reskinCondition.reskin[i].skinRef;
				spritesToReskin[i].primaryGradientMapRef = reskinCondition.reskin[i].gradientMapRef;
				if (_hasAnyEmissiveColorOverrides)
				{
					spritesToReskin[i].emissiveColor = (reskinCondition.reskin[i].hasEmissiveColorOverride ? reskinCondition.reskin[i].emissiveColorOverride : _defaultEmissiveColors[i]);
				}
				spritesToReskin[i].ApplyVisualChange();
				if (reskinCondition.reskin[i].glow != null)
				{
					reskinCondition.reskin[i].glow.SetActive(value: true);
				}
			}
			List<SpriteObjectAnimationEventEffects> list = animationEventEffects;
			if (list == null || list.Count <= 0)
			{
				return;
			}
			bool useAlternateSounds = reskinCondition.useAlternateSounds;
			{
				foreach (SpriteObjectAnimationEventEffects animationEventEffect in animationEventEffects)
				{
					if (animationEventEffect != null)
					{
						animationEventEffect.useAlternateSounds = useAlternateSounds;
					}
				}
				return;
			}
		}
		for (int j = 0; j < spritesToReskin.Count; j++)
		{
			SpriteObject spriteObject = spritesToReskin[j];
			spriteObject.skinRef = default(DataBlockRef<SpriteAssetSkin>);
			spriteObject.primaryGradientMapRef = default(DataBlockRef<GradientMapDataBlock>);
			if (_hasAnyEmissiveColorOverrides)
			{
				spriteObject.emissiveColor = _defaultEmissiveColors[j];
			}
			spriteObject.ApplyVisualChange();
		}
	}

	public void OnValidate()
	{
		foreach (ReskinCondition reskinCondition in reskinConditions)
		{
			List<SkinAndGradientMap> reskin = reskinCondition.reskin;
			SkinAndGradientMap elementToFillOutWith;
			if (reskinCondition.reskin.Count <= 0)
			{
				elementToFillOutWith = default(SkinAndGradientMap);
			}
			else
			{
				List<SkinAndGradientMap> reskin2 = reskinCondition.reskin;
				elementToFillOutWith = reskin2[reskin2.Count - 1];
			}
			reskin.Resize(elementToFillOutWith, spritesToReskin.Count);
		}
	}
}
