using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ArchMortarProjectile : EntityMonoBehaviour
{
	[Header("Arch Settings")]
	public AnimationCurve flyingCurve;

	public AnimationCurve shadowScaleByHeightCurve = AnimationCurve.Constant(0f, 1f, 1f);

	[FormerlySerializedAs("srPivot")]
	public Transform animatedTransform;

	public Transform shadowAnimatedTransform;

	public Transform shadowScaleAnimatedTransform;

	[Header("Effects")]
	public List<ParticleSystem> launchOneShotEffectsOld;

	public List<ParticleEffectSpawner> launchOneShotEffects;

	public List<PuffID> launchOneShotPuffs;

	public List<ParticleSystem> trailContinuousEffectsOld;

	public List<ParticleEffectSpawner> trailContinuousEffects;

	public List<ParticleSystem> hitOneShotEffectsOld;

	public List<ParticleEffectSpawner> hitOneShotEffects;

	public List<PuffID> hitPuffs;

	public List<Transform> transformAliveDuringFlight;

	[Header("Direction")]
	public Transform directionTransform;

	public bool shouldUpdateDirection;

	[Header("ZigZag")]
	public bool zigZag;

	public Transform zigZagTransform;

	public float zigZagFrequency;

	public float zigZagMagnitude;

	[Header("Animation")]
	public bool hasTiltAnimation;

	public SpriteObject animatedSO;

	public float additionalAnimationTime;

	private TimerSimple _timer;

	private bool _explosionPlayed;

	private float zigZagTimeOffset;

	private Vector3 _startPos;

	private Vector3 _endPos;

	[SerializeField]
	private SFXTableIDField sfxTableElementProjectileLaunch;

	[SerializeField]
	private SFXTableIDField sfxTableElementProjectileImpact;

	[SerializeField]
	private SFXTableIDField sfxTableElementProjectileImpactRandom;

	[SerializeField]
	private SFXTableIDField sfxTableElementAnticipation;

	private static float lastRandomSfxTime = -999f;

	private List<AudioManager.RunningSfxReference> launchSfxRef = new List<AudioManager.RunningSfxReference>();

	private static float lastAnticipationSfxTime = -999f;

	private const float anticipationSfxCooldown = 1.5f;

	public override void OnOccupied()
	{
		base.OnOccupied();
		_explosionPlayed = false;
		InitializeFlyingPosition();
		if (currentHealth > 0)
		{
			EntityUtility.TryGetComponentData<MortarProjectileCD>(base.entity, base.world, out var value);
			_timer.Start(value.totalAirTime + additionalAnimationTime);
			UpdateFlyingPosition();
			PlayStartEffects();
			foreach (Transform item in transformAliveDuringFlight)
			{
				item.gameObject.SetActive(value: true);
			}
		}
		else
		{
			_timer.Stop();
			foreach (Transform item2 in transformAliveDuringFlight)
			{
				item2.gameObject.SetActive(value: false);
			}
		}
		zigZagTimeOffset = UnityEngine.Random.Range(0f, 10000f);
	}

	private void PlayStartEffects()
	{
		PlayAllPuffs(launchOneShotPuffs);
		PlayAllEffects(launchOneShotEffectsOld);
		PlayAllEffects(launchOneShotEffects);
		PlayAllEffects(trailContinuousEffectsOld);
		PlayAllEffects(trailContinuousEffects);
		EntityMonoBehaviour.ToRenderFromWorld(_startPos);
		AudioManager.SfxFollowTransform(sfxTableElementProjectileLaunch.value, animatedTransform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, launchSfxRef);
	}

	private void PlayAllEffects(List<ParticleSystem> effects)
	{
		foreach (ParticleSystem effect in effects)
		{
			effect.Play();
		}
	}

	private static void PlayAllEffects(List<ParticleEffectSpawner> effects)
	{
		foreach (ParticleEffectSpawner effect in effects)
		{
			effect.enabled = true;
		}
	}

	private void StopAllEffects(List<ParticleSystem> effects)
	{
		foreach (ParticleSystem effect in effects)
		{
			effect.Stop();
		}
	}

	private void StopAllEffects(List<ParticleEffectSpawner> effects)
	{
		foreach (ParticleEffectSpawner effect in effects)
		{
			effect.enabled = false;
		}
	}

	private void PlayAllPuffs(List<PuffID> puffIds)
	{
		foreach (PuffID puffId in puffIds)
		{
			Manager.effects.PlayPuff(puffId, animatedTransform.position, 1);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.entityExist)
		{
			UpdateFlyingPosition();
			if (zigZag)
			{
				ZigZag();
			}
		}
	}

	private void InitializeFlyingPosition()
	{
		if (!TryGetOwnerPosition(out var ownerPosition))
		{
			ownerPosition = base.WorldPosition;
		}
		MortarProjectileCD componentData = EntityUtility.GetComponentData<MortarProjectileCD>(base.entity, base.world);
		_startPos = ownerPosition;
		_endPos = componentData.targetPosition;
	}

	private bool TryGetOwnerPosition(out Vector3 ownerPosition)
	{
		ownerPosition = default(Vector3);
		EntityUtility.TryGetComponentData<OwnerReferenceCD>(base.entity, base.world, out var value);
		if (value.owner == Entity.Null)
		{
			return false;
		}
		EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(value.owner);
		if (entityMono == null)
		{
			return false;
		}
		if (entityMono is IMortarShooter mortarShooter)
		{
			ownerPosition = mortarShooter.GetNextMortarStartWorldPosition();
		}
		else
		{
			ownerPosition = entityMono.WorldPosition;
		}
		return true;
	}

	private void UpdateFlyingPosition()
	{
		if (_timer.isRunning && !_timer.isTimerElapsed)
		{
			Vector3 p = Vector3.Lerp(_startPos, _endPos, _timer.elapsedRatio);
			animatedTransform.position = EntityMonoBehaviour.ToRenderFromWorld(p);
			float num = flyingCurve.Evaluate(_timer.elapsedRatio);
			animatedTransform.position = new Vector3(animatedTransform.position.x, num, animatedTransform.position.z);
			if (shadowAnimatedTransform != null)
			{
				shadowAnimatedTransform.position = new Vector3(animatedTransform.position.x, 0f, animatedTransform.position.z);
				float num2 = shadowScaleByHeightCurve.Evaluate(animatedTransform.position.y);
				shadowScaleAnimatedTransform.localScale = new Vector3(num2, num2, num2);
			}
			if (!shouldUpdateDirection)
			{
				return;
			}
			Vector3 vector = new Vector3(p.x, 0f, p.z + num);
			Vector3 vector2 = Vector3.Lerp(_startPos, _endPos, Mathf.Min(1f, _timer.elapsedRatio + 0.01f));
			float num3 = flyingCurve.Evaluate(Mathf.Min(1f, _timer.elapsedRatio + 0.01f));
			Vector3 vector3 = new Vector3(vector2.x, 0f, vector2.z + num3) - vector;
			if (vector3.sqrMagnitude <= float.Epsilon)
			{
				return;
			}
			vector3.Normalize();
			if (hasAnimator)
			{
				SetOrientation(vector3);
			}
			else
			{
				directionTransform.LookAt(directionTransform.position + vector3, Vector3.up);
			}
			if (hasTiltAnimation && animatedSO != null)
			{
				if ((double)_timer.elapsedRatio < 0.3)
				{
					animatedSO.PlayAnimation(-568891545);
				}
				else if ((double)_timer.elapsedRatio < 0.6)
				{
					animatedSO.PlayAnimation(-1458546703);
				}
				else
				{
					animatedSO.PlayAnimation(806946379);
				}
			}
		}
		else
		{
			animatedTransform.position = EntityMonoBehaviour.ToRenderFromWorld(_endPos);
			animatedTransform.position = new Vector3(animatedTransform.position.x, flyingCurve.Evaluate(1f), animatedTransform.position.z);
			if (shadowAnimatedTransform != null)
			{
				shadowAnimatedTransform.position = new Vector3(animatedTransform.position.x, 0f, animatedTransform.position.z);
				float num4 = shadowScaleByHeightCurve.Evaluate(animatedTransform.position.y);
				shadowScaleAnimatedTransform.localScale = new Vector3(num4, num4, num4);
			}
			if (!_explosionPlayed)
			{
				Explode();
			}
		}
	}

	protected void Explode()
	{
		_explosionPlayed = true;
		PlayAllEffects(hitOneShotEffectsOld);
		PlayAllEffects(hitOneShotEffects);
		PlayAllPuffs(hitPuffs);
		AudioManager.SfxFollowTransform(sfxTableElementProjectileImpact.value, animatedTransform);
		if (UnityEngine.Random.value < 0.5f && Time.time - lastRandomSfxTime >= 2f)
		{
			AudioManager.SfxFollowTransform(sfxTableElementProjectileImpactRandom.value, animatedTransform);
			lastRandomSfxTime = Time.time;
		}
		StopAllEffects(trailContinuousEffects);
		StopAllEffects(trailContinuousEffectsOld);
		foreach (Transform item in transformAliveDuringFlight)
		{
			item.gameObject.SetActive(value: false);
		}
		if (launchSfxRef != null)
		{
			foreach (AudioManager.RunningSfxReference item2 in launchSfxRef)
			{
				if (item2.IsValid)
				{
					item2.FadeOutAndStop(0.5f);
				}
			}
			launchSfxRef.Clear();
		}
		base.OnDeath();
	}

	private void ZigZag()
	{
		float2 obj = new float2(0f, 1f);
		float2 float5 = new float2(1f, 0f);
		float time = Time.time;
		float x = zigZagTimeOffset + time * zigZagFrequency;
		float x2 = math.sin(x) * zigZagMagnitude;
		float num = math.cos(x) * zigZagMagnitude;
		float2 x3 = obj + float5 * num;
		x3 = math.normalizesafe(x3);
		zigZagTransform.SetLocalPositionAndRotation(new Vector3(x2, 0f, 0f), Quaternion.LookRotation(x3.ToFloat3(), Vector3.up));
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, animatedTransform);
	}
}
