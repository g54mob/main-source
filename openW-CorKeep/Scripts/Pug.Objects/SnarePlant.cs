using System.Collections.Generic;
using PlayerEquipment;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

public class SnarePlant : EntityMonoBehaviour
{
	public GameObject plantSegmentPrefab;

	public GameObject plantSegmentsContainer;

	public List<GameObject> plantSegments;

	public SpriteObject thornSO;

	private const float SEGMENTS_SPREAD = 0.15f;

	private const float SEGMENTS_PER_UNIT = 6.6666665f;

	private Vector3 SEGMENTS_HEIGHT_OFFSET = Vector3.up * 0.0625f * 2f;

	private const float SPRITE_MAX_OFFSET = 1f / 160f;

	private AttackContinuouslyCD attackContinuously;

	private float lastTriggerTime;

	private float timeBetweenAttacks;

	private float attackDuration;

	private PugQuerySystem _querySystem;

	private readonly int m_GrowEvent = SpriteAsset.StringToHash("grow");

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		XScaler.localPosition = new Vector3(0f, rng.NextFloat(-1f / 160f, 1f / 160f), 0f);
		attackContinuously = EntityUtility.GetComponentData<AttackContinuouslyCD>(base.entity, base.world);
		attackDuration = attackContinuously.attackTime;
		timeBetweenAttacks = attackDuration + attackContinuously.cooldown;
		lastTriggerTime = -2.1474836E+09f;
		_querySystem = base.world.GetExistingSystemManaged<PugQuerySystem>();
		thornSO.gameObject.SetActive(value: false);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		for (int i = 0; i < plantSegments.Count; i++)
		{
			plantSegments[i].SetActive(value: false);
		}
		if (IsAttacking())
		{
			int num = 0;
			CollisionWorld collisionWorld = PhysicsManager.GetCollisionWorld();
			NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			ColliderCacheCD singleton = _querySystem.GetSingleton<ColliderCacheCD>();
			PhysicsCollider sphereCollider = PhysicsManager.GetSphereCollider(new float3(0f, 0f, 0f), 2f, 2u, singleton);
			Vector3 worldPosition = base.WorldPosition;
			collisionWorld.CastCollider(PhysicsManager.GetColliderCastInput(worldPosition, worldPosition, sphereCollider), ref allHits);
			foreach (ColliderCastHit item2 in allHits)
			{
				Entity entity = item2.Entity;
				if (!(entity != Entity.Null) || EntityUtility.GetConditionEffectValue(ConditionEffect.Snared, entity, base.world) <= 0)
				{
					continue;
				}
				EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(entity);
				if (entityMono == null)
				{
					continue;
				}
				Vector3 vector = entityMono.RenderPosition - base.transform.position;
				Vector3 vector2 = vector.normalized * 0.15f;
				float num2 = vector.magnitude * 6.6666665f;
				Vector3 vector3 = Vector3.up * (0.35f / num2);
				for (int j = 0; (float)j < num2; j++)
				{
					if (plantSegments.Count <= num)
					{
						GameObject item = Object.Instantiate(plantSegmentPrefab, plantSegmentsContainer.transform);
						plantSegments.Add(item);
					}
					plantSegments[num].SetActive(value: true);
					plantSegments[num].transform.position = base.transform.position + SEGMENTS_HEIGHT_OFFSET + vector2 * j + vector3 * j;
					num++;
				}
			}
			allHits.Dispose();
		}
		if (!AttackCooldownReady())
		{
			if (thornSO.gameObject.activeSelf)
			{
				Manager.effects.PlayPuff(PuffID.LeafDebris, base.transform.position, 5);
				spriteObjects[0].PlayTransformAnimation(-13548874);
			}
			thornSO.gameObject.SetActive(value: false);
		}
		else if (!thornSO.gameObject.activeSelf && (float)currentHealth > 0f && spriteObjects[0].currentAnimationHash != -1248613499)
		{
			PlayThornAppearEffects();
			thornSO.gameObject.SetActive(value: true);
		}
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (lastAnim != -1248613499 || animID != -601574123)
		{
			return base.ShouldPlayAnimTrigger(animID);
		}
		return false;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1203776827 && AttackCooldownReady())
		{
			lastTriggerTime = Time.time;
			Manager.effects.PlayPuff(PuffID.LeafDebris, base.transform.position);
			AudioManager.Sfx(SfxID.burrow, base.transform.position, 0.4f, 1.1f, 0.05f);
		}
	}

	private void PlayThornAppearEffects()
	{
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 5);
		AudioManager.Sfx(SfxID.bubble, base.transform.position, 0.4f, 1f, 0.05f);
		spriteObjects[0].PlayTransformAnimation(-13548874);
		thornSO.PlayTransformAnimation(-13548874);
	}

	private bool AttackCooldownReady()
	{
		return Time.time - lastTriggerTime > timeBetweenAttacks;
	}

	private bool IsAttacking()
	{
		return Time.time - lastTriggerTime < attackDuration;
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_GrowEvent == hash)
		{
			spriteObjects[0].PlayTransformAnimation(-13548874);
		}
	}
}
