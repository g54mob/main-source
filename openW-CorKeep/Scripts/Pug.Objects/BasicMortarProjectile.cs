using System;
using System.Collections.Generic;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BasicMortarProjectile : EntityMonoBehaviour
{
	[Flags]
	public enum MovementState
	{
		None = 0,
		GoingUp = 1,
		InAir = 2,
		GoingDown = 4,
		Explosion = 8,
		OnlyFlight = 7,
		All = 0xF
	}

	[Serializable]
	public struct EnabledInAnimationTransform
	{
		public Transform targetTransform;

		public MovementState enabledInState;
	}

	[Header("AnimationCurveMoement")]
	public bool spawnFromOwnerWeaponPos;

	public bool useAnimationCurveMovement;

	public Transform moveTransform;

	public Transform shadowMoveTransform;

	public Transform shadowScaleAnimatedTransform;

	public AnimationCurve goUpYCurve;

	public AnimationCurve inAirXZCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve goDownYCurve;

	public AnimationCurve shadowScaleByHeightCurve = AnimationCurve.Constant(0f, 1f, 1f);

	[Header("Flip")]
	public bool rotate180OnGoingDown;

	public Vector3 rotate180AxisMask = Vector3.up;

	public Transform rotate180Transform;

	[Header("Effects")]
	public List<ParticleSystem> launchOneShotEffectsOld = new List<ParticleSystem>();

	public List<ParticleEffectSpawner> launchOneShotEffects = new List<ParticleEffectSpawner>();

	public List<ParticleSystem> trailContinuousEffectsOld = new List<ParticleSystem>();

	public List<ParticleEffectSpawner> trailContinuousEffects = new List<ParticleEffectSpawner>();

	public List<ParticleSystem> hitOneShotEffectsOld = new List<ParticleSystem>();

	public List<ParticleEffectSpawner> hitOneShotEffects = new List<ParticleEffectSpawner>();

	public List<PuffID> hitPuffs = new List<PuffID>();

	public List<EnabledInAnimationTransform> enabledInAnimationTransforms = new List<EnabledInAnimationTransform>();

	private MovementState _movementState;

	private bool _hasExploded;

	private Quaternion _baseline180Rotation;

	private Quaternion _rotated180Rotation;

	private float _timer;

	private Vector3 _startPos;

	private Vector3 _endPos;

	protected override void Awake()
	{
		base.Awake();
		if (rotate180OnGoingDown)
		{
			if (rotate180Transform == null)
			{
				Debug.LogError("flipYOnGoingDown is true but flipTransform is not assigned.", this);
				rotate180OnGoingDown = false;
			}
			else
			{
				_baseline180Rotation = rotate180Transform.localRotation;
				_rotated180Rotation = Quaternion.Euler(rotate180AxisMask * 180f) * _baseline180Rotation;
			}
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		InitializeFlyingPosition();
		_hasExploded = false;
		_movementState = MovementState.None;
		bool flag = currentHealth <= 0;
		MortarVisualUtilities.EnableTransforms(enabledInAnimationTransforms, (!flag) ? MovementState.GoingUp : MovementState.None);
		_timer = 0f;
		if (useAnimationCurveMovement)
		{
			AnimateYMovementByCurve(goUpYCurve, _startPos);
		}
		if (rotate180OnGoingDown)
		{
			rotate180Transform.localRotation = _baseline180Rotation;
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
		ownerPosition = entityMono.WorldPosition;
		if (spawnFromOwnerWeaponPos)
		{
			EntityUtility.TryGetComponentData<AnimationOrientationCD>(value.owner, base.world, out var value2);
			EntityUtility.TryGetComponentData<PlayerStateCD>(value.owner, base.world, out var value3);
			ownerPosition += GetWeaponOffset(in value2, in value3);
		}
		return true;
	}

	private static Vector3 GetWeaponOffset(in AnimationOrientationCD animationOrientationCD, in PlayerStateCD playerStateCD)
	{
		Direction facingDirection = animationOrientationCD.facingDirection;
		Vector3 result = Vector3.zero;
		if (facingDirection.id == Direction.Id.forward)
		{
			result = new float3(0.3f, 0f, 0f);
		}
		else if (facingDirection.id == Direction.Id.back)
		{
			result = new float3(-0.3f, 0f, -0.15f);
		}
		else if (facingDirection.id == Direction.Id.left)
		{
			result = new float3(0.3f, 0f, -0.15f);
		}
		else if (facingDirection.id == Direction.Id.right)
		{
			result = new float3(-0.3f, 0f, -0.15f);
		}
		if (playerStateCD.HasAnyState(PlayerStateEnum.BoatRiding))
		{
			result += new Vector3(0f, 0f, -0.2f);
		}
		return result;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		_movementState = MovementState.None;
		switch (animID)
		{
		case 1408713878:
			OnStartGoUp();
			SetAnimationCurveMovementState(MovementState.GoingUp);
			break;
		case -225098472:
			OnStartInAir();
			SetAnimationCurveMovementState(MovementState.InAir);
			break;
		case 584621764:
			OnStartGoDown();
			SetAnimationCurveMovementState(MovementState.GoingDown);
			break;
		case 1416834189:
			OnExplode();
			SetAnimationCurveMovementState(MovementState.None);
			break;
		}
		base.HandleAnimationTrigger(animID);
	}

	private void SetAnimationCurveMovementState(MovementState state)
	{
		_movementState = state;
		_timer = 0f;
	}

	protected virtual void OnStartGoUp()
	{
		MortarVisualUtilities.PlayAllEffects(launchOneShotEffectsOld);
		MortarVisualUtilities.PlayAllEffects(launchOneShotEffects);
		MortarVisualUtilities.PlayAllEffects(trailContinuousEffectsOld);
		MortarVisualUtilities.PlayAllEffects(trailContinuousEffects);
		MortarVisualUtilities.EnableTransforms(enabledInAnimationTransforms, MovementState.GoingUp);
	}

	protected virtual void OnStartInAir()
	{
		MortarVisualUtilities.StopAllEffects(trailContinuousEffectsOld);
		MortarVisualUtilities.StopAllEffects(trailContinuousEffects);
		MortarVisualUtilities.EnableTransforms(enabledInAnimationTransforms, MovementState.InAir);
	}

	protected virtual void OnStartGoDown()
	{
		MortarVisualUtilities.PlayAllEffects(trailContinuousEffectsOld);
		MortarVisualUtilities.PlayAllEffects(trailContinuousEffects);
		if (rotate180OnGoingDown)
		{
			rotate180Transform.localRotation = _rotated180Rotation;
		}
		MortarVisualUtilities.EnableTransforms(enabledInAnimationTransforms, MovementState.GoingDown);
	}

	protected virtual void OnExplode()
	{
		if (!_hasExploded)
		{
			Explode();
		}
	}

	protected virtual void Explode()
	{
		_hasExploded = true;
		MortarVisualUtilities.PlayAllEffects(hitOneShotEffectsOld);
		MortarVisualUtilities.PlayAllEffects(hitOneShotEffects);
		MortarVisualUtilities.PlayAllPuffs(hitPuffs, base.transform.position);
		MortarVisualUtilities.StopAllEffects(trailContinuousEffectsOld);
		MortarVisualUtilities.StopAllEffects(trailContinuousEffects);
		MortarVisualUtilities.EnableTransforms(enabledInAnimationTransforms, MovementState.Explosion);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (useAnimationCurveMovement)
		{
			MoveByAnimationCurve();
		}
	}

	private void MoveByAnimationCurve()
	{
		_timer += Time.deltaTime;
		switch (_movementState)
		{
		case MovementState.GoingUp:
			AnimateYMovementByCurve(goUpYCurve, _startPos);
			break;
		case MovementState.InAir:
			AnimateXZMovementByCurve(inAirXZCurve);
			break;
		case MovementState.GoingDown:
			AnimateYMovementByCurve(goDownYCurve, _endPos);
			break;
		case MovementState.GoingUp | MovementState.InAir:
			break;
		}
	}

	private void AnimateXZMovementByCurve(AnimationCurve curve)
	{
		Vector3 position = moveTransform.position;
		float t = curve.Evaluate(_timer);
		Vector3 p = new Vector3(Mathf.Lerp(_startPos.x, _endPos.x, t), position.y, Mathf.Lerp(_startPos.z, _endPos.z, t));
		moveTransform.position = EntityMonoBehaviour.ToRenderFromWorld(p);
		UpdateShadowTransform();
	}

	private void AnimateYMovementByCurve(AnimationCurve curve, Vector3 baseWorldPos)
	{
		baseWorldPos.y = curve.Evaluate(_timer);
		moveTransform.position = EntityMonoBehaviour.ToRenderFromWorld(baseWorldPos);
		UpdateShadowTransform();
	}

	private void UpdateShadowTransform()
	{
		if ((bool)shadowMoveTransform)
		{
			shadowMoveTransform.position = new Vector3(moveTransform.position.x, 0f, moveTransform.position.z);
		}
		if ((bool)shadowScaleAnimatedTransform)
		{
			float num = shadowScaleByHeightCurve.Evaluate(moveTransform.position.y);
			shadowScaleAnimatedTransform.localScale = new Vector3(num, num, num);
		}
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}
}
