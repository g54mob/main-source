using System;
using System.Collections.Generic;
using NaughtyAttributes;
using NetworkedEcb;
using Outlines.Components;
using Pug.ECS.Hybrid;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

public class EntityMonoBehaviour : PoolableSimple, IEntityMonoBehaviourDataPreview, IGraphicalObject, IGraphicalSpawn, IGraphicalDespawn
{
	[Serializable]
	public struct ReskinOptions
	{
		public SpriteSheetSkin sourceSpriteSheetSkin;

		[ArrayElementTitle("objectIDToUseReskinOn, variation, isOnlyAppliedDuringSeason")]
		public List<ReskinInfo> reskins;
	}

	[Serializable]
	public class ReskinInfo
	{
		public ObjectID objectIDToUseReskinOn;

		public bool worksForAnyVariation;

		[HideIf("worksForAnyVariation")]
		[AllowNesting]
		public int variation;

		public Season isOnlyAppliedDuringSeason;

		[Header("If more than one texture is added to these lists then a\nrandom one index will be selected based on world position.")]
		public List<Texture2D> textures;

		public List<Texture2D> emissiveTextures;
	}

	[Serializable]
	public class PaintingOptions
	{
		[ArrayElementTitle("sourceSpriteRenderer")]
		public List<PaintableSpriteRenderers> spriteRenderers = new List<PaintableSpriteRenderers>();

		[ArrayElementTitle("sourceSpriteRenderer")]
		public List<PaintableColorTints> spriteColorTints = new List<PaintableColorTints>();

		[ArrayElementTitle("sourceSpriteSheetSkin")]
		public List<PaintableSpriteSheetSkins> spriteSheetSkins = new List<PaintableSpriteSheetSkins>();
	}

	[Serializable]
	public class PaintableSpriteRenderers
	{
		public SpriteRenderer sourceSpriteRenderer;

		[ArrayElementTitle("PaintableColors")]
		public List<Sprite> colorSprites;

		[NonSerialized]
		public Sprite defaultSprite;
	}

	[Serializable]
	public class PaintableColorTints
	{
		public SpriteRenderer sourceSpriteRenderer;

		[ArrayElementTitle("PaintableColors")]
		public List<Color> colors;

		[NonSerialized]
		public Color defaultColor;
	}

	[Serializable]
	public class PaintableLights
	{
		public Light sourceLight;

		[ArrayElementTitle("PaintableColors")]
		public List<Color> colors;

		[NonSerialized]
		public Color defaultColor;
	}

	[Serializable]
	public class PaintableSpriteSheetSkins
	{
		public SpriteSheetSkin sourceSpriteSheetSkin;

		[ArrayElementTitle("PaintableColors")]
		public List<Texture2D> colorTextures;
	}

	[Serializable]
	public class SoundOptions
	{
		public SFXTableIDField takeDamageSfx;

		public SFXTableIDField deathSfx;
	}

	[Serializable]
	public class ParticlesOptions
	{
		[ArrayElementTitle("spawnOccasion")]
		public List<ParticlesToSpawn> particlesToSpawn;

		public List<Transform> particleSpawnLocations;

		public List<ParticleSystem> particlesToDisableOnLowQuality;
	}

	[Serializable]
	public class ParticlesToSpawn
	{
		public ParticleSpawnOccasion spawnOccasion;

		public bool spawnManually;

		public ObjectID objectID;

		public List<EntityMonoBehaviourPuffParams> particles;
	}

	[Serializable]
	public struct EntityMonoBehaviourPuffParams
	{
		public PuffID puff;

		public Transform positionTransform;

		public int particleCount;
	}

	public enum ParticleSpawnOccasion
	{
		OnDeath = 0,
		OnSpawn = 1
	}

	[Serializable]
	public struct ObjectVariant
	{
		public bool worksForAnyObjectID;

		public ObjectID objectID;

		public bool dependsOnVariation;

		[ShowIf("dependsOnVariation")]
		[AllowNesting]
		public int variation;

		public bool dependsOnDirection;

		[ShowIf("dependsOnDirection")]
		[AllowNesting]
		public ObjectDirection direction;

		public List<GameObject> objectsToEnable;
	}

	public enum ObjectDirection
	{
		UP = 0,
		RIGHT = 1,
		DOWN = 2,
		LEFT = 3
	}

	public enum SpriteObjectOrientation
	{
		Undefined = 0,
		Down = 1,
		Up = 2,
		Side = 3,
		DownRight = 4,
		UpRight = 5
	}

	[Header("References------------------------------")]
	public Transform XScaler;

	protected bool hasXScaler;

	public GameObject shadow;

	protected bool hasShadow;

	[Tooltip("Objects in this list are automatically enabled/disabled via OnOccupied and OnDeath.")]
	public List<GameObject> indirectLightEmitters;

	public Animator animator;

	protected bool hasAnimator;

	public InteractableObject interactable;

	protected bool hasInteractable;

	[Header("Sprite Objects------------------------------")]
	public List<SpriteObject> spriteObjects;

	[Tooltip("Use shared SpriteObject transform animations, such as wobble when taking damage.")]
	public bool useSharedTransformAnimations = true;

	[Header("Additional Options------------------------")]
	[ArrayElementTitle("sourceSpriteSheetSkin")]
	public List<ReskinOptions> reskinOptions;

	private static readonly int EmissiveTex = Shader.PropertyToID("_EmissiveTex");

	public PaintingOptions paintableOptions;

	private PaintableColor previousPaint;

	public SoundOptions soundOptions;

	public ParticlesOptions particleOptions;

	[Header("Variants------------------------------------")]
	[ArrayElementTitle("objectVariants")]
	public List<ObjectVariant> objectVariants;

	public List<SpriteRenderer> spritesToRandomlyFlip;

	public List<GameObject> gameObjectsToRandomlyFlip;

	[Header("Optional------------------------------------")]
	public HealthBar optionalHealthBar;

	public ManagedLight optionalLightOptimizer;

	public ConditionsEffectsHandler conditionEffectsHandler;

	public ConditionsEffectsSettings conditionsEffectsSettings;

	public List<OutlineController> outlineControllers;

	private int variationOverride;

	private int variationOverrideUpdateCount;

	private int pugMapPosX;

	private int pugMapPosZ;

	private int width;

	private int height;

	private bool appearInMapUI;

	private Color colorInMap;

	private bool onlyEnableAnimatorTemporarilyWhenPlayingAnimation;

	private const string destroyableObjectAnimatorName = "DestroyableObject";

	private float animatorTemporaryDisableTimer;

	protected int lastAnim;

	private int lastNonDeathAnim;

	private bool hasOverriddenAnim;

	private float deathTimer;

	private float3 interactableDefaultPosition;

	private quaternion interactableDefaultRotation;

	protected Flashable flashable;

	protected bool hasFlashable;

	private bool hasConditions;

	private bool hasDamageEffect;

	private int damageEffectTrigger;

	public bool hasDisableableParticles;

	[HideInInspector]
	public int previousHealth;

	public ClientSendSystem netEcbSystem;

	private bool hasLocalToWorld;

	protected Vector3 currentFacingVector;

	protected Vector3 normalizedFacingVector;

	protected Vector3 animatedMovementVector;

	private bool hasAnimationOrientationCD;

	private float orientationY;

	protected SpriteObjectOrientation m_spriteObjectOrientation;

	protected SpriteObjectOrientation m_prevSpriteObjectOrientation;

	public int m_spriteObjectOrientationHash;

	private ObjectID cachedLastSpriteSheetObjectID;

	private int cachedLastSpriteSheetVariation = -1;

	private Color transparentColor = new Color(0f, 0f, 0f, 0f);

	public World world => Manager.ecs.ClientWorld;

	public Entity entity { get; protected set; }

	public ObjectInfo objectInfo => PugDatabase.GetObjectInfo(objectData.objectID, variation);

	public ObjectDataCD objectData => EntityUtility.GetObjectData(entity, world);

	public bool hasDirection
	{
		get
		{
			if (Application.isPlaying)
			{
				return EntityUtility.HasComponentData<DirectionCD>(entity, world);
			}
			return false;
		}
	}

	public float3 direction
	{
		get
		{
			if (!hasDirection)
			{
				return math.back();
			}
			return EntityUtility.GetComponentData<DirectionCD>(entity, world).direction;
		}
	}

	public int variation
	{
		get
		{
			ObjectDataCD objectDataCD = objectData;
			if (variationOverrideUpdateCount <= objectDataCD.variationUpdateCount)
			{
				return objectDataCD.variation;
			}
			return variationOverride;
		}
	}

	protected virtual bool updateAnimOrientation => false;

	protected virtual bool updateAnimMovement => false;

	protected virtual bool updateAnimMovementSpeed => false;

	protected virtual bool hideDirectlyOnDeath => true;

	public bool isHidden { get; private set; }

	protected virtual bool skipConditionEffectsHandler => false;

	public bool hasHealth { get; private set; }

	public bool isEnemy { get; private set; }

	public virtual int currentHealth => EntityUtility.GetComponentData<HealthCD>(entity, world).health;

	public virtual Vector3 center
	{
		get
		{
			Vector3 result = RenderPosition + Vector3.up * 0.5f;
			ObjectInfo objectInfo = this.objectInfo;
			if (objectInfo.centerIsAtEntityPosition)
			{
				return result;
			}
			EntityUtility.GetPrefabSizeAndOffset(entity, objectInfo, out var size, out var offset);
			Vector2Int vector2Int = size - offset;
			if (vector2Int.x > 1)
			{
				result.x += (float)(vector2Int.x - 1) / 2f;
			}
			return result;
		}
	}

	public virtual Vector3 combatTextPosition => RenderPosition;

	public bool entityExist
	{
		get
		{
			if (EntityUtility.EntityExists(entity, world))
			{
				return EntityUtility.HasComponentData<LocalTransform>(entity, world);
			}
			return false;
		}
	}

	public Vector3 WorldPosition { get; protected set; }

	public Vector3 RenderPosition => WorldPosition - Manager.camera.RenderOrigo;

	protected virtual float GetAnimSpeed()
	{
		return 1.5f;
	}

	public bool HasConditions()
	{
		return hasConditions;
	}

	public virtual int GetCurrentHealth(in HealthCD healthCD)
	{
		return healthCD.health;
	}

	public virtual int GetMaxHealth()
	{
		HealthCD componentData = EntityUtility.GetComponentData<HealthCD>(entity, world);
		if (EntityUtility.TryGetBuffer(entity, world, out DynamicBuffer<SummarizedConditionEffectsBuffer> value))
		{
			return componentData.GetMaxHealthWithConditions(value);
		}
		return componentData.maxHealth;
	}

	protected virtual int GetProtectiveArmor()
	{
		return EntityUtility.GetConditionEffectValue(ConditionEffect.ProtectiveArmor, entity, world);
	}

	protected virtual int GetMaxProtectiveArmor()
	{
		return 0;
	}

	private void SetLastAnimID(int animID)
	{
		lastAnim = animID;
		if (animID != -414722770)
		{
			lastNonDeathAnim = animID;
		}
	}

	protected Transform GetVariationsParticleSpawnLocation()
	{
		if (particleOptions.particleSpawnLocations.Count > variation && particleOptions.particleSpawnLocations[variation] != null)
		{
			return particleOptions.particleSpawnLocations[variation];
		}
		return base.transform;
	}

	public static Vector3 ToRenderFromWorld(Vector3 p)
	{
		return p - Manager.camera.RenderOrigo;
	}

	public static Vector3Int ToRenderFromWorld(Vector3Int p)
	{
		return p - Manager.camera.RenderOrigo;
	}

	public static Vector3 ToWorldFromRender(Vector3 p)
	{
		return p + Manager.camera.RenderOrigo;
	}

	public static Vector3Int ToWorldFromRender(Vector3Int p)
	{
		return p + Manager.camera.RenderOrigo;
	}

	public static int2 ToRenderFromWorld(int2 p)
	{
		return p - Manager.camera.RenderOrigo.ToInt2();
	}

	public static void TryAddWaterImpulseForObject(ObjectInfo objectInfo, Vector3 position, float3 direction)
	{
		if (objectInfo != null)
		{
			bool num = objectInfo.prefabTileSize.x > 1 || objectInfo.prefabTileSize.y > 1;
			Vector2Int v = Vector2Int.one;
			if (num)
			{
				Vector3 zero = Vector3.zero;
				zero.x += ((float)objectInfo.prefabTileSize.x - 1f) / 2f;
				zero.z += ((float)objectInfo.prefabTileSize.y - 1f) / 2f;
				zero += (Vector3)objectInfo.prefabCornerOffset.To3D();
				int variationFromDirection = DirectionBasedOnVariationCD.GetVariationFromDirection(direction.RoundToInt2());
				DirectionCD.RotateTransform(quaternion.identity, zero, variationFromDirection, objectInfo.prefabCornerOffset.ToInt2(), objectInfo.prefabTileSize.ToInt2(), out var _, out var newTranslation);
				position += (Vector3)newTranslation;
				v = DirectionCD.GetPrefabTileSize(objectInfo.prefabTileSize.ToInt2(), direction.RoundToInt2()).ToVec2Int();
			}
			if (objectInfo.objectType != ObjectType.Creature && (objectInfo.prefabTileSize.x > 1 || objectInfo.prefabTileSize.y > 1))
			{
				WaterSim.AddSquareImpulse(position, Quaternion.identity, v.To3D());
			}
			else
			{
				WaterSim.AddImpulse(position, (float)math.min(v.x, v.y) / 2f);
			}
		}
	}

	protected virtual void Awake()
	{
		hasXScaler = XScaler != null;
		hasShadow = shadow != null;
		hasInteractable = interactable != null;
		if (animator == null)
		{
			animator = GetComponent<Animator>();
		}
		hasAnimator = animator != null;
		if (flashable == null)
		{
			flashable = GetComponent<Flashable>();
		}
		hasFlashable = flashable != null;
		if (hasAnimator)
		{
			animator.writeDefaultValuesOnDisable = true;
			animator.keepAnimatorStateOnDisable = false;
			if (animator.runtimeAnimatorController != null)
			{
				onlyEnableAnimatorTemporarilyWhenPlayingAnimation = animator.runtimeAnimatorController.name == "DestroyableObject";
			}
		}
		if (hasInteractable)
		{
			interactableDefaultPosition = interactable.transform.localPosition;
			interactableDefaultRotation = interactable.transform.localRotation;
		}
		foreach (PaintableSpriteRenderers spriteRenderer in paintableOptions.spriteRenderers)
		{
			spriteRenderer.defaultSprite = spriteRenderer.sourceSpriteRenderer.sprite;
		}
		foreach (PaintableColorTints spriteColorTint in paintableOptions.spriteColorTints)
		{
			spriteColorTint.defaultColor = spriteColorTint.sourceSpriteRenderer.color;
		}
		hasDisableableParticles = particleOptions.particlesToDisableOnLowQuality.Count > 0;
	}

	private void OnValidate()
	{
		if (particleOptions == null)
		{
			return;
		}
		foreach (PaintableSpriteRenderers spriteRenderer in paintableOptions.spriteRenderers)
		{
			if (spriteRenderer.colorSprites.Count != Constants.paintableColorNames.Length)
			{
				spriteRenderer.colorSprites.Resize(null, Constants.paintableColorNames.Length);
			}
		}
		foreach (PaintableColorTints spriteColorTint in paintableOptions.spriteColorTints)
		{
			if (spriteColorTint.colors.Count != Constants.paintableColorNames.Length)
			{
				spriteColorTint.colors.Resize(Color.white, Constants.paintableColorNames.Length);
			}
		}
		foreach (PaintableSpriteSheetSkins spriteSheetSkin in paintableOptions.spriteSheetSkins)
		{
			if (spriteSheetSkin.colorTextures.Count != Constants.paintableColorNames.Length)
			{
				spriteSheetSkin.colorTextures.Resize(null, Constants.paintableColorNames.Length);
			}
		}
	}

	public void InitAndOccupy(Entity entity)
	{
		this.entity = entity;
		OnOccupied();
	}

	public void SetVariation(int value)
	{
		variationOverride = value;
		variationOverrideUpdateCount = Mathf.Max(variationOverrideUpdateCount, objectData.variationUpdateCount) + 1;
		if (EntityUtility.HasComponentData<GhostInstance>(this.entity, world))
		{
			Entity entity = world.EntityManager.CreateEntity(typeof(SetVariationRPC), typeof(SendRpcCommandRequest));
			world.EntityManager.SetComponentData(entity, new SetVariationRPC
			{
				entity = this.entity,
				variation = value,
				updateCount = variationOverrideUpdateCount
			});
		}
	}

	public virtual void ManagedLateUpdate()
	{
	}

	public virtual void OnPlayerTriggerEnter(PlayerController pc)
	{
	}

	public virtual void OnPlayerTriggerExit(PlayerController pc)
	{
	}

	public virtual void OnPlayerTrigger(PlayerController pc)
	{
	}

	public virtual void OnNonPlayerTriggerEnter(Entity triggeringEntity)
	{
	}

	public virtual void OnNonPlayerTriggerExit(Entity triggeringEntity)
	{
	}

	public virtual void OnNonPlayerTrigger(Entity triggeringEntity)
	{
	}

	public virtual void UpdatePosition(bool hasLocalToWorld, in LocalToWorld localToWorld)
	{
		if (hasLocalToWorld)
		{
			WorldPosition = localToWorld.Position;
		}
	}

	protected virtual Vector3 GetAnimOrientationVec3()
	{
		return EntityUtility.GetComponentData<AnimationOrientationCD>(entity, world).facingDirection.vec3;
	}

	public virtual void UpdateAnimatorSpeedAndOrientation()
	{
		if ((updateAnimMovement || updateAnimOrientation) && hasAnimationOrientationCD)
		{
			currentFacingVector = GetAnimOrientationVec3();
			normalizedFacingVector = currentFacingVector.normalized;
		}
		if (updateAnimMovement)
		{
			if (currentFacingVector.magnitude > 0.01f)
			{
				if (hasAnimator)
				{
					animator.SetFloat(-1801483167, normalizedFacingVector.x);
					animator.SetFloat(-476529417, normalizedFacingVector.z);
				}
			}
			else if (hasAnimator)
			{
				animator.SetFloat(-1801483167, 0f);
				animator.SetFloat(-476529417, 0f);
			}
		}
		if (updateAnimMovementSpeed && hasAnimator)
		{
			animator.SetFloat(-1985230220, GetAnimSpeed());
		}
		if (updateAnimOrientation && currentFacingVector.magnitude > 0f)
		{
			animatedMovementVector = normalizedFacingVector;
			SetOrientation(animatedMovementVector);
		}
	}

	protected void SetOrientation(Vector3 direction)
	{
		float num = Mathf.Sin(Mathf.Atan(direction.z / Mathf.Abs(direction.x)));
		orientationY = num * Mathf.Abs(num);
		if (hasAnimator)
		{
			animator.SetFloat(1116435161, orientationY);
		}
		UpdateSpriteObjectsOrientation();
		int num2 = ((!(direction.x < 0f)) ? 1 : (-1));
		XScaler.localScale = new Vector3(num2, 1f, 1f);
	}

	protected virtual void OnShow()
	{
	}

	protected virtual void OnHide()
	{
	}

	public void UpdateDestroyedState(bool destroyed)
	{
		if ((isHidden && destroyed) || (!isHidden && !destroyed))
		{
			return;
		}
		isHidden = destroyed;
		bool flag = EntityUtility.HasComponentData<TriggerAnimationOnDeathCD>(entity, world) && EntityUtility.IsComponentEnabled<TriggerAnimationOnDeathCD>(entity, world);
		if (!destroyed)
		{
			if (!(deathTimer > 0f))
			{
				return;
			}
			deathTimer = 0f;
			if (flag && lastAnim == -414722770)
			{
				HandleAnimationTrigger(lastNonDeathAnim);
			}
			if (hideDirectlyOnDeath)
			{
				if (hasAnimator)
				{
					animator.enabled = true;
				}
				if (hasXScaler)
				{
					XScaler.gameObject.SetActive(value: true);
				}
				if (hasShadow)
				{
					shadow.SetActive(value: true);
				}
				if (optionalLightOptimizer != null)
				{
					optionalLightOptimizer.gameObject.SetActive(value: true);
				}
			}
			if (conditionEffectsHandler != null)
			{
				conditionEffectsHandler.UpdateShowing(shouldShow: true);
			}
			OnShow();
			return;
		}
		OnHide();
		deathTimer += Time.deltaTime;
		if (flag && lastAnim != -414722770)
		{
			HandleAnimationTrigger(-414722770);
			SetLastAnimID(-414722770);
		}
		if (hideDirectlyOnDeath)
		{
			if (hasAnimator)
			{
				animator.enabled = false;
			}
			if (hasXScaler)
			{
				XScaler.gameObject.SetActive(value: false);
			}
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
			if (optionalLightOptimizer != null)
			{
				optionalLightOptimizer.gameObject.SetActive(value: false);
			}
		}
		if (conditionEffectsHandler != null)
		{
			conditionEffectsHandler.UpdateShowing(shouldShow: false);
		}
	}

	public void TryPlayAnimation(int animID)
	{
		if (lastAnim != -414722770 || animID != lastAnim)
		{
			HandleAnimationTrigger(animID);
		}
		SetLastAnimID(animID);
	}

	protected bool AnimationCanOverrideCurrentAnimation(int serverAnim, int overrideAnim)
	{
		if (overrideAnim == -414722770)
		{
			return true;
		}
		switch (serverAnim)
		{
		case -414722770:
			return false;
		case -1473092350:
			return false;
		case -1533413595:
			return AnimationHasHigherOrSamePrioAsTakeDamage(overrideAnim);
		default:
			if (overrideAnim == -1533413595)
			{
				return !AnimationHasHigherOrSamePrioAsTakeDamage(serverAnim);
			}
			return true;
		}
	}

	protected virtual bool AnimationHasHigherOrSamePrioAsTakeDamage(int animID)
	{
		if (animID != 910517187 && animID != 1354651601 && animID != -1533413595)
		{
			return animID == -2008574808;
		}
		return true;
	}

	protected virtual bool ShouldPlayAnimTrigger(int animID)
	{
		return (lastAnim != -601574123 && lastAnim != -1442707745) || (animID != -601574123 && animID != -1442707745);
	}

	protected virtual void HandleAnimationTrigger(int animID)
	{
		using (new ProfilerMarker("HandleAnimationTrigger").Auto())
		{
			if (animID == -414722770)
			{
				OnDeath();
			}
			if (animID == 0 || !ShouldPlayAnimTrigger(animID))
			{
				return;
			}
			if (hasAnimator)
			{
				EnableAnimatorTemporarily();
				if (animID == -414722770)
				{
					ResetAllTriggers();
				}
				animator.SetTrigger(animID);
			}
			if (spriteObjects != null && spriteObjects.Count > 0)
			{
				PlaySpriteObjectAnimation(animID);
			}
		}
	}

	private void ResetAllTriggers()
	{
		AnimatorControllerParameter[] parameters = animator.parameters;
		foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
		{
			if (animatorControllerParameter.type == AnimatorControllerParameterType.Trigger)
			{
				animator.ResetTrigger(animatorControllerParameter.name);
			}
		}
	}

	protected virtual void PlaySpriteObjectAnimation(int animID)
	{
		if (updateAnimOrientation)
		{
			UpdateSpriteObjectsOrientation();
		}
		if (spriteObjects == null || spriteObjects.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < spriteObjects.Count; i++)
		{
			SpriteObject spriteObject = spriteObjects[i];
			if (spriteObject == null)
			{
				continue;
			}
			if (spriteObject.HasAnimation(animID))
			{
				if (updateAnimOrientation)
				{
					spriteObject.PlayAnimation(animID, m_spriteObjectOrientationHash, forceResetTime: true);
				}
				else
				{
					spriteObject.PlayAnimation(animID, forceResetTime: true);
				}
			}
			if (useSharedTransformAnimations)
			{
				spriteObject.PlayTransformAnimation(animID);
			}
		}
	}

	protected virtual void UpdateSpriteObjectsOrientation()
	{
		m_spriteObjectOrientation = ((orientationY > 0.5f) ? SpriteObjectOrientation.Up : ((orientationY < -0.5f) ? SpriteObjectOrientation.Down : SpriteObjectOrientation.Side));
		if (m_spriteObjectOrientation != m_prevSpriteObjectOrientation)
		{
			UpdateSpriteObjectOrientationHash(in m_spriteObjectOrientation, out m_spriteObjectOrientationHash);
			if (spriteObjects != null && spriteObjects.Count > 0)
			{
				for (int i = 0; i < spriteObjects.Count; i++)
				{
					SpriteObject spriteObject = spriteObjects[i];
					if (!(spriteObject == null))
					{
						spriteObject.SetVariant(m_spriteObjectOrientationHash);
					}
				}
			}
		}
		m_prevSpriteObjectOrientation = m_spriteObjectOrientation;
	}

	public static void UpdateSpriteObjectOrientationHash(in SpriteObjectOrientation spriteObjectOrientation, out int spriteObjectOrientationHash)
	{
		switch (spriteObjectOrientation)
		{
		default:
			spriteObjectOrientationHash = 595663797;
			break;
		case SpriteObjectOrientation.Up:
			spriteObjectOrientationHash = 1133833840;
			break;
		case SpriteObjectOrientation.Down:
			spriteObjectOrientationHash = 0;
			break;
		}
	}

	public void SpawnFadeOutLight(Light expiredLight, float fadeOutTime = 0.15f)
	{
		FadeoutLight freeComponent = Manager.memory.GetFreeComponent<FadeoutLight>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.fadeoutLight.color = expiredLight.color;
			freeComponent.fadeoutLight.intensity = expiredLight.intensity;
			freeComponent.fadeoutLight.range = expiredLight.range;
			freeComponent.followTransform = expiredLight.transform;
			freeComponent.transform.position = expiredLight.transform.position;
			freeComponent.fadeOutTime = fadeOutTime;
			freeComponent.OnOccupied();
		}
		else
		{
			Debug.LogError("failed to instantiate fadeOutLight");
		}
	}

	private void UpdateHealthBar(int currentHealth)
	{
		if (optionalHealthBar != null)
		{
			optionalHealthBar.UpdateHealthBar((float)currentHealth / (float)GetMaxHealth(), GetProtectiveArmor(), GetMaxProtectiveArmor());
		}
	}

	public virtual void UpdateHealthChangeAnimations(in HealthCD healthCD)
	{
		int num = GetCurrentHealth(in healthCD);
		UpdateHealEffect(num);
		previousHealth = num;
		UpdateHealthBar(num);
	}

	protected virtual void UpdateHealEffect(int currentHealth)
	{
		if (isEnemy && previousHealth < currentHealth && previousHealth > 0)
		{
			if (hasFlashable)
			{
				flashable.Flash(Manager.effects.healCurve, Color.green, 0.4f, 1);
			}
			if (conditionEffectsHandler != null)
			{
				conditionEffectsHandler.regenerateCurrentTime = 1f;
			}
		}
	}

	protected virtual void PlayBrightFlashEffect(float Time)
	{
		if (hasFlashable)
		{
			flashable.Flash(Manager.effects.brightFlashCurve, Color.white, Time);
		}
	}

	public void UpdateDamageTakenEffect(in DamageEffectCD damageEffectCD)
	{
		int trigger = damageEffectCD.trigger;
		if (trigger > damageEffectTrigger)
		{
			damageEffectTrigger = trigger;
			OnTakeDamage();
		}
	}

	public void FlashToDisplayAsMinionTarget()
	{
		if (hasFlashable)
		{
			flashable.Flash(Manager.effects.minionTargetFlashCurve, Manager.effects.minionTargetFlashColor, Manager.effects.minionTargetFlashDuration);
		}
	}

	public void UpdateAppearanceInMapUI(bool hasDirection, in DirectionCD directionCD)
	{
		if (!appearInMapUI || isHidden)
		{
			return;
		}
		int2 int5 = WorldPosition.RoundToInt2();
		ObjectInfo objectInfo = this.objectInfo;
		if (objectInfo == null)
		{
			return;
		}
		Vector2Int prefabOffset = EntityUtility.GetPrefabOffset(objectInfo, hasDirection, in directionCD);
		Vector2Int vector2Int = EntityUtility.GetPrefabSize(objectInfo, hasDirection, in directionCD) + prefabOffset;
		for (int i = prefabOffset.x; i < vector2Int.x; i++)
		{
			for (int j = prefabOffset.y; j < vector2Int.y; j++)
			{
				int2 worldPos = int5 + new int2(i, j);
				Manager.ui.mapUI.SetColorAtPos(worldPos, colorInMap);
			}
		}
	}

	public void UpdatePaintedColor(in PaintableObjectCD paintableObjectCD)
	{
		PaintableColor color = paintableObjectCD.color;
		if (previousPaint == color)
		{
			return;
		}
		previousPaint = color;
		foreach (PaintableSpriteSheetSkins spriteSheetSkin in paintableOptions.spriteSheetSkins)
		{
			if (color == PaintableColor.Unpainted)
			{
				spriteSheetSkin.sourceSpriteSheetSkin.ResetAllTemporarySkins();
			}
			else
			{
				spriteSheetSkin.sourceSpriteSheetSkin.SetTemporarySkin(spriteSheetSkin.colorTextures[(int)(color - 1)]);
			}
		}
		foreach (PaintableSpriteRenderers spriteRenderer in paintableOptions.spriteRenderers)
		{
			if (color == PaintableColor.Unpainted)
			{
				spriteRenderer.sourceSpriteRenderer.sprite = spriteRenderer.defaultSprite;
			}
			else
			{
				spriteRenderer.sourceSpriteRenderer.sprite = spriteRenderer.colorSprites[(int)(color - 1)];
			}
		}
		foreach (PaintableColorTints spriteColorTint in paintableOptions.spriteColorTints)
		{
			if (color == PaintableColor.Unpainted)
			{
				spriteColorTint.sourceSpriteRenderer.color = spriteColorTint.defaultColor;
			}
			else
			{
				spriteColorTint.sourceSpriteRenderer.color = spriteColorTint.colors[(int)(color - 1)];
			}
		}
	}

	public void UpdateSpriteSheetSkins(ObjectInfo info, int overrideVariation = -1)
	{
		int num = info.variation;
		if (overrideVariation != -1)
		{
			num = overrideVariation;
		}
		else if (entity != Entity.Null)
		{
			num = variation;
		}
		if (info.objectID == cachedLastSpriteSheetObjectID && num == cachedLastSpriteSheetVariation)
		{
			return;
		}
		foreach (ReskinOptions reskinOption in reskinOptions)
		{
			UpdateReskinOption(WorldPosition, reskinOption, info, num, reskinOption.sourceSpriteSheetSkin);
		}
	}

	public static void UpdateReskinOption(Vector3 worldPosition, ReskinOptions reskinOption, ObjectInfo info, int currentVariation, SpriteSheetSkin sourceSpriteSheetSkin)
	{
		Texture2D skinToApply = null;
		Texture2D emissiveSkinToApply = null;
		if (sourceSpriteSheetSkin != null)
		{
			sourceSpriteSheetSkin.ResetAllTemporarySkins();
		}
		GetSpriteDataForMatchingReskinOption(worldPosition, reskinOption, info, currentVariation, out skinToApply, out emissiveSkinToApply);
		if (sourceSpriteSheetSkin != null && skinToApply != null)
		{
			sourceSpriteSheetSkin.SetTemporarySkin(skinToApply);
			if (Application.isPlaying && sourceSpriteSheetSkin.sr != null && sourceSpriteSheetSkin.sr.material != null)
			{
				sourceSpriteSheetSkin.sr.material.SetTexture(EmissiveTex, emissiveSkinToApply);
			}
		}
	}

	public static void GetSpriteDataForMatchingReskinOption(Vector3 worldPosition, ReskinOptions reskinOption, ObjectInfo info, int currentVariation, out Texture2D skinToApply, out Texture2D emissiveSkinToApply)
	{
		skinToApply = null;
		emissiveSkinToApply = null;
		for (int i = 0; i < reskinOption.reskins.Count; i++)
		{
			ReskinInfo reskinInfo = reskinOption.reskins[i];
			if ((reskinInfo.objectIDToUseReskinOn != ObjectID.None && reskinInfo.objectIDToUseReskinOn != info.objectID) || (!reskinInfo.worksForAnyVariation && reskinInfo.variation != currentVariation) || (reskinInfo.isOnlyAppliedDuringSeason != Season.None && (!Application.isPlaying || reskinInfo.isOnlyAppliedDuringSeason != Manager.prefs.season)))
			{
				continue;
			}
			if (reskinInfo.textures != null && reskinInfo.textures.Count > 0)
			{
				int num = PugRandom.GetRngFromWorldPosition(worldPosition).NextInt(0, reskinInfo.textures.Count);
				skinToApply = reskinInfo.textures[num];
				if (reskinInfo.emissiveTextures != null && reskinInfo.emissiveTextures.Count > num)
				{
					emissiveSkinToApply = reskinInfo.emissiveTextures[num];
				}
			}
			if (reskinInfo.isOnlyAppliedDuringSeason != Season.None)
			{
				break;
			}
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		if (!isHidden)
		{
			isHidden = true;
			OnHide();
		}
		Manager.memory.RemoveEntityMonoFromLookUp(entity);
		entity = Entity.Null;
		if (conditionEffectsHandler != null && conditionEffectsHandler.isPooled && !conditionEffectsHandler.isFree)
		{
			conditionEffectsHandler.Free();
			conditionEffectsHandler = null;
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		Manager.memory.AddEntityMonoToLookUp(entity, this);
		EntityUtility.EntityComponentLookup entityComponentLookup = EntityUtility.GetEntityComponentLookup(entity, world);
		ObjectInfo objectInfo = this.objectInfo;
		deathTimer = 0f;
		ResetVisuals();
		if (hasInteractable && entityComponentLookup.HasComponentData<DirectionCD>())
		{
			DirectionCD.RotateTransform(interactableDefaultRotation, interactableDefaultPosition, DirectionBasedOnVariationCD.GetVariationFromDirection(direction.RoundToInt2()), objectInfo.prefabCornerOffset.ToInt2(), objectInfo.prefabTileSize.ToInt2(), out var newOrientation, out var newTranslation);
			interactable.transform.SetLocalPositionAndRotation(newTranslation, newOrientation);
		}
		WorldPosition = EntityUtility.GetComponentData<LocalTransform>(entity, world).Position;
		base.transform.position = WorldPosition - Manager.camera.RenderOrigo;
		hasLocalToWorld = entityComponentLookup.HasComponentData<LocalToWorld>();
		hasConditions = entityComponentLookup.HasComponentData<ConditionsBuffer>();
		hasDamageEffect = entityComponentLookup.HasComponentData<DamageEffectCD>();
		previousPaint = PaintableColor.__max__;
		if (EntityUtility.TryGetComponentData<PaintableObjectCD>(entity, world, out var value))
		{
			UpdatePaintedColor(in value);
		}
		hasAnimationOrientationCD = entityComponentLookup.HasComponentData<AnimationOrientationCD>();
		if (objectInfo.objectType == ObjectType.PlaceablePrefab && Manager.effects.ShouldPlayPlacedObjectEffectAtPosition(WorldPosition))
		{
			if (hasAnimator)
			{
				animator.SetTrigger(-1533413595);
			}
			else
			{
				PlaySpriteObjectAnimation(-1533413595);
			}
		}
		if (hasDamageEffect)
		{
			damageEffectTrigger = EntityUtility.GetComponentData<DamageEffectCD>(entity, world).trigger;
		}
		hasHealth = entityComponentLookup.HasComponentData<HealthCD>();
		if (hasHealth)
		{
			previousHealth = currentHealth;
		}
		isEnemy = entityComponentLookup.HasComponentData<EnemyCD>();
		if (entityComponentLookup.HasComponentData<AnimationBuffer>())
		{
			AnimationBufferPointer pointer = EntityUtility.GetComponentData<AnimationBufferPointer>(entity, world);
			AnimationBuffer lastAddedElement = EntityUtility.GetBuffer<AnimationBuffer>(entity, world).GetLastAddedElement(in pointer);
			if (lastAddedElement.animID != 0)
			{
				HandleInitialAnimationTrigger(lastAddedElement.animID);
			}
			else
			{
				HandleInitialAnimationTrigger(1352515405);
			}
		}
		appearInMapUI = objectInfo.appearInMapUI;
		colorInMap = objectInfo.mapColor;
		if (hasConditions && !skipConditionEffectsHandler)
		{
			if (conditionEffectsHandler == null)
			{
				conditionEffectsHandler = Manager.memory.GetFreeComponent<ConditionsEffectsHandler>(deferOnOccupied: false, deferReparent: true);
				if (conditionEffectsHandler != null)
				{
					Transform obj = conditionEffectsHandler.transform;
					obj.SetParent(base.transform);
					obj.localPosition = Vector3.zero;
				}
			}
			else
			{
				conditionEffectsHandler.OnOccupied();
			}
		}
		if (conditionEffectsHandler != null)
		{
			conditionEffectsHandler.UpdateShowing(shouldShow: true);
		}
		if (optionalLightOptimizer != null)
		{
			optionalLightOptimizer.gameObject.SetActive(value: true);
		}
		if (entity == Entity.Null)
		{
			Debug.LogWarning(base.name + " has no entity set");
			base.gameObject.SetActive(value: false);
			return;
		}
		netEcbSystem = world.GetOrCreateSystemManaged<ClientSendSystem>();
		UpdateGraphicsFromObjectInfo(objectInfo);
		SetIndirectLightEmittersEnabled(state: true);
		PlayParticleEffect(ParticleSpawnOccasion.OnSpawn, automatic: true);
		OnShow();
		isHidden = false;
	}

	public void ResetVisuals()
	{
		SetLastAnimID(0);
		hasOverriddenAnim = false;
		variationOverrideUpdateCount = 0;
		isHidden = false;
		m_spriteObjectOrientation = SpriteObjectOrientation.Undefined;
		m_prevSpriteObjectOrientation = SpriteObjectOrientation.Undefined;
		if (hasAnimator)
		{
			animator.enabled = true;
			animatorTemporaryDisableTimer = 1f;
		}
		if (hasXScaler)
		{
			XScaler.gameObject.SetActive(value: true);
		}
		if (hasShadow)
		{
			shadow.SetActive(value: true);
		}
	}

	protected virtual void HandleInitialAnimationTrigger(int animID)
	{
		if (animID != 1203776827)
		{
			if (hasAnimator)
			{
				animator.SetTrigger(animID);
			}
			if (spriteObjects != null && spriteObjects.Count > 0)
			{
				PlaySpriteObjectAnimation(animID);
			}
			SetLastAnimID(animID);
		}
	}

	public virtual void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		uint seedFromVector = PugRandom.GetSeedFromVector(WorldPosition);
		if (objectVariants.Count > 0)
		{
			int num = -1;
			for (int i = 0; i < objectVariants.Count; i++)
			{
				ObjectVariant objectVariant = objectVariants[i];
				bool num2 = objectVariant.worksForAnyObjectID || objectVariant.objectID == ObjectID.None || objectVariant.objectID == info.objectID;
				bool flag = !objectVariant.dependsOnVariation || info.variation == objectVariant.variation;
				bool flag2 = !objectVariant.dependsOnDirection || DirectionBasedOnVariationCD.GetVariationFromDirection(direction.RoundToInt2()) == (int)objectVariant.direction;
				if (num2 && flag && flag2)
				{
					num = i;
					continue;
				}
				for (int j = 0; j < objectVariant.objectsToEnable.Count; j++)
				{
					if (objectVariant.objectsToEnable[j] != null && objectVariant.objectsToEnable[j].gameObject.activeSelf)
					{
						objectVariant.objectsToEnable[j].gameObject.SetActive(value: false);
					}
				}
			}
			if (num >= 0)
			{
				EnableVariation(objectVariants[num], seedFromVector);
			}
		}
		if (spritesToRandomlyFlip.Count > 0)
		{
			bool flipX = PugRandom.GetRandomValueFromWorldPosition(WorldPosition) > 0.5f;
			foreach (SpriteRenderer item in spritesToRandomlyFlip)
			{
				item.flipX = flipX;
			}
		}
		if (gameObjectsToRandomlyFlip.Count > 0)
		{
			bool flag3 = PugRandom.GetRandomValueFromWorldPosition(WorldPosition) > 0.5f;
			foreach (GameObject item2 in gameObjectsToRandomlyFlip)
			{
				Vector3 localScale = item2.transform.localScale;
				localScale.x = (flag3 ? (-1f) : 1f);
				item2.transform.localScale = localScale;
			}
		}
		UpdateSpriteSheetSkins(info);
		if (!Application.isPlaying)
		{
			OffsetFromEntityDirectionOrVariation component = GetComponent<OffsetFromEntityDirectionOrVariation>();
			if (component != null)
			{
				component.SetPreview(info.variation);
			}
		}
	}

	protected virtual void EnableVariation(ObjectVariant objectVariant, uint seed)
	{
		for (int i = 0; i < objectVariant.objectsToEnable.Count; i++)
		{
			if (objectVariant.objectsToEnable[i] != null && !objectVariant.objectsToEnable[i].activeSelf)
			{
				objectVariant.objectsToEnable[i].SetActive(value: true);
			}
		}
	}

	protected virtual void OnTakeDamage()
	{
		if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(Color.red);
		}
		bool flag = false;
		Vector3 vector = Vector3.zero;
		bool flag2 = false;
		bool playOnGamepad = false;
		if (this is PlayerController playerController)
		{
			flag = playerController.IsShielded();
			vector = playerController.facingDirection.vec3.normalized * 0.5f;
			flag2 = playerController.visuallyEquippedContainedObject.objectID == ObjectID.PoisonousShield;
			playOnGamepad = true;
		}
		if (flag)
		{
			AudioManager.SfxFollowTransform(SfxID.shieldBlock, base.transform, 1f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			AudioManager.SfxFollowTransform(SfxID.shieldBlock2, base.transform, 0.5f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			if (flag2)
			{
				AudioManager.SfxFollowTransform(SfxID.slimeFootstep, base.transform, 1f, 1.3f, 0.2f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
				Manager.effects.PlayPuff(PuffID.PoisonSlimeExplosion, center + vector, 20);
			}
			TakeDamageEffect(vector);
		}
		else
		{
			AudioManager.SfxFollowTransform(soundOptions.takeDamageSfx.value, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad);
		}
		if (objectInfo.objectType == ObjectType.Creature)
		{
			TakeDamageEffect(Vector3.zero);
		}
		TryAddWaterImpulse();
	}

	protected virtual void OnTakeBarrierDamage()
	{
		if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(Color.cyan);
		}
		bool playOnGamepad = this is PlayerController;
		AudioManager.SfxFollowTransform(SfxTableID.PlayerTakeBarrierDamage, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad);
	}

	protected void TryAddWaterImpulse()
	{
		float3 zero = float3.zero;
		if (EntityUtility.HasComponentData<DirectionCD>(entity, world))
		{
			zero = EntityUtility.GetComponentData<DirectionCD>(entity, world).direction;
		}
		TryAddWaterImpulseForObject(objectInfo, RenderPosition, zero);
	}

	protected virtual void OnDeath()
	{
		if (soundOptions.deathSfx.value != SfxTableID.none)
		{
			AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
		}
		PlayParticleEffect(ParticleSpawnOccasion.OnDeath, automatic: true);
		TryAddWaterImpulse();
		DeathEffect();
		SetIndirectLightEmittersEnabled(state: false);
	}

	protected void PlayParticleEffect(ParticleSpawnOccasion spawnOccasion, Vector3? overridePosition = null)
	{
		PlayParticleEffect(spawnOccasion, automatic: false, overridePosition);
	}

	private void PlayParticleEffect(ParticleSpawnOccasion spawnOccasion, bool automatic, Vector3? overridePosition = null)
	{
		foreach (ParticlesToSpawn item in particleOptions.particlesToSpawn)
		{
			if ((automatic && item.spawnManually) || item.spawnOccasion != spawnOccasion || (item.objectID != ObjectID.None && objectData.objectID != item.objectID))
			{
				continue;
			}
			foreach (EntityMonoBehaviourPuffParams particle in item.particles)
			{
				if (particle.positionTransform.gameObject.activeInHierarchy)
				{
					Manager.effects.PlayPuff(new PuffParams
					{
						puff = particle.puff,
						particleCount = particle.particleCount
					}, overridePosition.HasValue ? (overridePosition.Value + particle.positionTransform.localPosition) : particle.positionTransform.position);
				}
			}
		}
	}

	private void SetIndirectLightEmittersEnabled(bool state)
	{
		if (indirectLightEmitters != null && indirectLightEmitters.Count > 0)
		{
			for (int i = 0; i < indirectLightEmitters.Count; i++)
			{
				indirectLightEmitters[i].SetActive(state);
			}
		}
	}

	public bool IsClaimedByPlayer()
	{
		if (Manager.main.player != null)
		{
			return IsClaimedByPlayer(Manager.main.player);
		}
		return false;
	}

	public bool IsClaimedByPlayer(PlayerController player)
	{
		if (!EntityUtility.HasComponentData<ClaimedByPlayerGuidCD>(entity, world) || !EntityUtility.HasComponentData<PlayerGhost>(player.entity, world))
		{
			return false;
		}
		Unity.Entities.Hash128 playerGuid = EntityUtility.GetComponentData<ClaimedByPlayerGuidCD>(entity, world).playerGuid;
		Unity.Entities.Hash128 playerGuid2 = EntityUtility.GetComponentData<PlayerGhost>(player.entity, world).playerGuid;
		return playerGuid == playerGuid2;
	}

	public static bool IsClaimedByPlayer(Entity targetEntity, Entity playerEntity, PlayerAttackLookups playerAttackLookups)
	{
		if (!playerAttackLookups.claimedByPlayerGUIDLookup.TryGetComponent(targetEntity, out var componentData) || !playerAttackLookups.playerGhostLookup.TryGetComponent(playerEntity, out var componentData2))
		{
			return false;
		}
		Unity.Entities.Hash128 playerGuid = componentData.playerGuid;
		Unity.Entities.Hash128 playerGuid2 = componentData2.playerGuid;
		return playerGuid == playerGuid2;
	}

	public static bool IsClaimedByPlayer(Entity targetEntity, in PlayerGhost playerGhost, ComponentLookup<ClaimedByPlayerGuidCD> claimedByPlayerGUIDLookup)
	{
		if (!claimedByPlayerGUIDLookup.TryGetComponent(targetEntity, out var componentData))
		{
			return false;
		}
		Unity.Entities.Hash128 playerGuid = componentData.playerGuid;
		Unity.Entities.Hash128 playerGuid2 = playerGhost.playerGuid;
		return playerGuid == playerGuid2;
	}

	protected virtual void DeathEffect()
	{
		if (objectInfo.objectType == ObjectType.Creature)
		{
			Manager.effects.ExploDisc(center, 0.5f);
		}
	}

	protected virtual void TakeDamageEffect(Vector3 offset)
	{
		int num = 1;
		if (UnityEngine.Random.value < 0.5f)
		{
			num = -1;
		}
		Manager.effects.PlayTempSprite(SpriteTempEffectID.HitEffect, center + new Vector3(0f, 0.25f, -0.25f) + offset, num);
	}

	protected void PlayShakeAnim(Vector3 position, SpriteObject spriteObject, float duration = -1f, bool gentle = false)
	{
		float num = Mathf.Sign(position.x - RenderPosition.x) * spriteObject.transform.localScale.x;
		int hash = ((num > 0f) ? 1266726044 : (-1315993089));
		if (gentle)
		{
			hash = ((num > 0f) ? 301701564 : (-336288545));
		}
		spriteObject.PlayTransformAnimation(hash, duration);
	}

	public void UpdateDisableAnimator()
	{
		if (onlyEnableAnimatorTemporarilyWhenPlayingAnimation && animator.enabled)
		{
			if (animatorTemporaryDisableTimer < 0f)
			{
				animator.enabled = false;
			}
			animatorTemporaryDisableTimer -= Time.deltaTime;
		}
	}

	private void EnableAnimatorTemporarily()
	{
		if (onlyEnableAnimatorTemporarilyWhenPlayingAnimation)
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
			}
			animatorTemporaryDisableTimer = 1f;
		}
	}

	public void UpdateParticlesEnabled()
	{
		new ProfilerMarker("Update particles check");
		if (!hasDisableableParticles)
		{
			return;
		}
		using (new ProfilerMarker("Update particle systems enabled state").Auto())
		{
			bool flag = Manager.prefs.particleQuality == 1;
			foreach (ParticleSystem item in particleOptions.particlesToDisableOnLowQuality)
			{
				if (flag && !item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(value: true);
				}
				else if (!flag && item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(value: false);
				}
			}
		}
	}

	public void UpdateOutline(OutlineType outlineType)
	{
		bool flag = outlineType != OutlineType.None;
		Color color = transparentColor;
		switch (outlineType)
		{
		case OutlineType.ClosestInteractable:
			color = ((interactable != null && interactable.useDiscreteOutlineColor) ? Manager.effects.discreteOutlineColor : Manager.effects.outlineColor);
			break;
		case OutlineType.Clone:
			color = Manager.effects.cloneEnemyOutlineColor;
			break;
		}
		if (interactable != null)
		{
			if (interactable.optionalOutlineController != null)
			{
				interactable.optionalOutlineController.showOutline = flag;
				if (flag)
				{
					interactable.optionalOutlineController.SetColor(color);
				}
				else
				{
					interactable.optionalOutlineController.ResetColor();
				}
			}
			foreach (OutlineController additionalOutlineController in interactable.additionalOutlineControllers)
			{
				additionalOutlineController.showOutline = flag;
				if (flag)
				{
					additionalOutlineController.SetColor(color);
				}
				else
				{
					additionalOutlineController.ResetColor();
				}
			}
			if (interactable.spriteObjects == null)
			{
				return;
			}
			{
				foreach (SpriteObject spriteObject in interactable.spriteObjects)
				{
					spriteObject.outlineColor = color;
				}
				return;
			}
		}
		foreach (OutlineController outlineController in outlineControllers)
		{
			outlineController.showOutline = flag;
			if (flag)
			{
				outlineController.SetColor(color);
			}
			else
			{
				outlineController.ResetColor();
			}
		}
		if (spriteObjects != null && spriteObjects.Count > 0 && spriteObjects[0] != null)
		{
			spriteObjects[0].outlineColor = color;
		}
	}

	public static bool IsClone(Entity entity, ComponentLookup<IsCloneCD> isCloneLookup)
	{
		return isCloneLookup.HasAndIsComponentDisabled(entity);
	}

	public void AE_SleepEffects(float xOffset = 0f)
	{
		Vector3 position = center + new Vector3(xOffset, 0.125f, -0.125f);
		if (this is PlayerController playerController)
		{
			AudioManager.Sfx(SfxTableID.snore, position);
			PlayerClaimedBed componentData = EntityUtility.GetComponentData<PlayerClaimedBed>(playerController.entity, world);
			if (componentData.claimedBedEntity != Entity.Null)
			{
				switch (DirectionBasedOnVariationCD.GetVariationFromDirection(EntityUtility.GetComponentData<DirectionCD>(componentData.claimedBedEntity, world).direction.RoundToInt2()))
				{
				case 0:
					position = center + new Vector3(xOffset, 0.375f, -0.75f);
					break;
				case 1:
					position = center + new Vector3(xOffset - 0.375f, 0.375f, -0.375f);
					break;
				case 2:
					position = center + new Vector3(xOffset, 0.375f, -0.375f);
					break;
				case 3:
					position = center + new Vector3(xOffset + 0.375f, 0.375f, -0.375f);
					break;
				}
			}
		}
		Manager.effects.PlayPuff(PuffID.Sleeping, position);
	}

	public virtual void Spawn(Entity entity, EntityManager entityManager)
	{
		InitAndOccupy(entity);
	}

	public virtual void Despawn(Entity entity, EntityManager entityManager)
	{
		Free();
	}

	public virtual void GraphicalUpdate(Entity entity, EntityManager entityManager, TimeData timeData)
	{
		ManagedLateUpdate();
	}

	public bool HasRecentlySpawned()
	{
		EntityUtility.TryGetComponentData<SpawnTickCD>(entity, world, out var value);
		PugQuerySystem pugQuerySystem = Manager.main?.player?.querySystem;
		if (pugQuerySystem == null)
		{
			return false;
		}
		pugQuerySystem.TryGetSingleton<NetworkTime>(out var value2);
		if (value.Value.IsValid)
		{
			return value2.InterpolationTick.TicksSince(value.Value) < 10;
		}
		return true;
	}
}
