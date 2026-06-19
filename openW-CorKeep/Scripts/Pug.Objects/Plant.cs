using System;
using System.Collections.Generic;
using Pug.Properties;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Transforms;
using UnityEngine;

public class Plant : EntityMonoBehaviour
{
	[Serializable]
	public class VariationData
	{
		[ColorUsage(false, true)]
		public Color emissiveColor = Color.black;

		[ColorUsage(false, true)]
		public Color indirectLightColor = Color.black;

		public bool useUnlitMaterial;
	}

	[Serializable]
	public class TypeData
	{
		[HideInInspector]
		public string name;

		public ObjectID objectID;

		public int minGlowStage = 2;

		public VariationData normalVariant = new VariationData();

		public VariationData rareVariant = new VariationData();

		[Min(0f)]
		public float potLightMultiplier = 1f;
	}

	private static int m_shineAnimation = SpriteAsset.StringToHash("shine");

	private static readonly int[] m_stageAnimations = new int[4]
	{
		SpriteAsset.StringToHash("stage1"),
		SpriteAsset.StringToHash("stage2"),
		SpriteAsset.StringToHash("stage3"),
		SpriteAsset.StringToHash("ripe")
	};

	[ClearOnReload(true)]
	public static HashSet<Plant> plantTracker = new HashSet<Plant>();

	[Header("Plant settings----------------------------")]
	public SpriteObject spriteObject;

	public SpriteObject spriteObjectShadow;

	public SpriteObject indirectLightEmitter;

	public Material litMaterial;

	public Material unlitMaterial;

	private int currentLocalStage;

	private TimerSimple shineCooldown;

	public SpriteObject shadowSO;

	public PlatformDependentValue<bool> disableShadow;

	[SerializeField]
	public List<TypeData> m_typeData = new List<TypeData>();

	private TileType hiddenTile;

	private ObjectID plantID;

	private int plantVariation;

	private int stage;

	private bool hasReachedFinalStage;

	private bool hasUpdatedPosition;

	protected override void Awake()
	{
		base.Awake();
		if (disableShadow.GetValueForCurrentPlatform() && shadowSO != null)
		{
			shadowSO.enabled = false;
		}
	}

	public override void OnOccupied()
	{
		hasUpdatedPosition = false;
		base.OnOccupied();
		shineCooldown.Stop();
		hiddenTile = TileType.none;
		stage = 0;
		hasReachedFinalStage = false;
		plantID = EntityUtility.GetObjectID(base.entity, base.world);
		plantVariation = base.variation;
		UpdateVisuals(playChangeStateEffects: false, GetStage(), plantID, resetCurrentLocalStage: true, plantVariation);
		spriteObject.RandomizeCurrentAnimationTime();
		spriteObjectShadow.animationTime = spriteObject.animationTime;
	}

	protected override void OnShow()
	{
		plantTracker.Add(this);
		base.OnShow();
	}

	public override void OnFree()
	{
		plantTracker.Remove(this);
		base.OnFree();
	}

	protected override void OnHide()
	{
		if (hiddenTile != TileType.none)
		{
			Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), hiddenTile);
		}
		if (plantTracker.Contains(this))
		{
			plantTracker.Remove(this);
		}
		base.OnHide();
	}

	private int GetStage()
	{
		if (hasReachedFinalStage)
		{
			return stage;
		}
		if (EntityUtility.HasComponentData<GrowingCD>(base.entity, base.world))
		{
			GrowingCD componentData = EntityUtility.GetComponentData<GrowingCD>(base.entity, base.world);
			stage = componentData.currentStage;
			if (componentData.HasReachedFinalStage(EntityUtility.GetComponentData<ObjectPropertiesCD>(base.entity, base.world)))
			{
				hasReachedFinalStage = true;
			}
			return stage;
		}
		return 0;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateVisuals(playChangeStateEffects: true, GetStage(), plantID, resetCurrentLocalStage: false, plantVariation);
		if (shineCooldown.isRunning && shineCooldown.isTimerElapsed)
		{
			shineCooldown.Stop();
			spriteObject.PlayAnimation(m_shineAnimation);
			spriteObjectShadow.PlayAnimation(m_shineAnimation);
			ResetShineCooldown();
		}
	}

	public void UpdateVisuals(bool playChangeStateEffects, int currentStage, ObjectID objectID, bool resetCurrentLocalStage, int currentVariation, bool isInPot = false)
	{
		if (resetCurrentLocalStage)
		{
			currentLocalStage = -1;
		}
		if (currentLocalStage != currentStage)
		{
			currentLocalStage = currentStage;
			if (objectID == ObjectID.GlowingTulipPlant && currentStage == 2)
			{
				SetEmissiveColor(Color.white * 0.3f);
			}
			else
			{
				SetEmissiveColor(Color.black);
			}
			spriteObject.PlayAnimation(m_stageAnimations[currentStage + 1]);
			spriteObject.RandomizeCurrentAnimationTime();
			spriteObjectShadow.animationTime = spriteObject.animationTime;
			UpdateEffects(playChangeStateEffects, objectID, currentVariation);
			UpdateMaterialAndGlow(objectID, currentVariation, isInPot);
			if (hasReachedFinalStage)
			{
				ReachedFinalStage();
			}
			spriteObject.ApplyVisualChange();
		}
	}

	private void SetEmissiveColor(Color color)
	{
		spriteObject.emissiveColor = color;
	}

	private void UpdateEffects(bool playChangeStateEffects, ObjectID objectID, int currentVariation)
	{
		List<Sprite> additionalSprites = PugDatabase.GetObjectInfo(objectID, currentVariation).additionalSprites;
		if (additionalSprites.Count <= currentLocalStage)
		{
			Debug.LogError("Requested plant sprite index " + currentLocalStage + " for " + base.gameObject.name + " but there are only " + additionalSprites.Count);
			return;
		}
		bool flag = additionalSprites.Count == currentLocalStage + 1;
		if (flag)
		{
			ResetShineCooldown();
		}
		if (playChangeStateEffects)
		{
			spriteObject.PlayTransformAnimation(-13548874);
			spriteObjectShadow.PlayTransformAnimation(-13548874);
			if (flag)
			{
				PlayRipeEffects();
			}
		}
	}

	private void OnValidate()
	{
		for (int i = 0; i < m_typeData.Count; i++)
		{
			m_typeData[i].name = m_typeData[i].objectID.ToString();
		}
	}

	private void UpdateMaterialAndGlow(ObjectID objectID, int variation, bool isInPot)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < m_typeData.Count; i++)
		{
			TypeData typeData = m_typeData[i];
			if (objectID == typeData.objectID && currentLocalStage >= typeData.minGlowStage)
			{
				VariationData variationData = ((variation == 2) ? typeData.rareVariant : typeData.normalVariant);
				spriteObject.emissiveColor = variationData.emissiveColor;
				indirectLightEmitter.emissiveColor = variationData.indirectLightColor * (isInPot ? typeData.potLightMultiplier : 1f);
				flag = indirectLightEmitter.emissiveColor.r > Mathf.Epsilon || indirectLightEmitter.emissiveColor.g > Mathf.Epsilon || indirectLightEmitter.emissiveColor.b > Mathf.Epsilon;
				flag2 = variationData.useUnlitMaterial;
				break;
			}
		}
		indirectLightEmitter.enabled = flag;
		Material material = (flag2 ? unlitMaterial : litMaterial);
		if (spriteObject.material != material)
		{
			spriteObject.material = material;
			spriteObject.ApplyVisualChange();
		}
	}

	private void PlayRipeEffects()
	{
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(EntityUtility.GetObjectID(base.entity, base.world));
		if (objectInfo.objectID == ObjectID.CoralRootPlant)
		{
			Manager.effects.PlayPuff(PuffID.BeachFloorTilesDebris, base.transform.position, 8);
		}
		else if (objectInfo.objectID == ObjectID.GleamRootPlant)
		{
			Manager.effects.PlayPuff(PuffID.CrystalDebrisPaleBlueSmall, base.transform.position, 4);
		}
		else
		{
			Manager.effects.PlayPuff(PuffID.LeafDebris, base.transform.position, 4);
		}
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}

	private void ResetShineCooldown()
	{
		float newLifespan = UnityEngine.Random.Range(4f, 8f);
		shineCooldown.Start(newLifespan);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if (base.entityExist)
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(EntityUtility.GetObjectID(base.entity, base.world));
			if (objectInfo.objectID == ObjectID.CoralRootPlant)
			{
				AudioManager.Sfx(SfxTableID.coralDestroy, base.transform.position);
				return;
			}
			if (objectInfo.objectID == ObjectID.GleamRootPlant)
			{
				AudioManager.Sfx(SfxTableID.woodCrystalDestroy, base.transform.position);
				return;
			}
			Manager.effects.PlayPuff(PuffID.LeafDebris, base.transform.position);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f);
		}
	}

	public override void OnPlayerTriggerEnter(PlayerController pc)
	{
		base.OnPlayerTriggerEnter(pc);
		if (spriteObject != null)
		{
			PlayShakeAnim(pc.RenderPosition, spriteObject);
		}
		if (spriteObjectShadow != null)
		{
			PlayShakeAnim(pc.RenderPosition, spriteObjectShadow);
		}
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.2f, 1.15f, 0.125f);
	}

	public override void UpdatePosition(bool hasLocalToWorld, in LocalToWorld localToWorld)
	{
		if (!hasUpdatedPosition)
		{
			base.UpdatePosition(hasLocalToWorld, in localToWorld);
			hasUpdatedPosition = true;
		}
	}

	public virtual void ReachedFinalStage()
	{
		switch (plantID)
		{
		case ObjectID.RootPlant:
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 0, TileType.bigRoot, 0);
			hiddenTile = TileType.bigRoot;
			break;
		case ObjectID.CoralRootPlant:
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 10, TileType.bigRoot, 0);
			hiddenTile = TileType.bigRoot;
			break;
		case ObjectID.GleamRootPlant:
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 55, TileType.bigRoot, 0);
			hiddenTile = TileType.bigRoot;
			break;
		}
	}
}
