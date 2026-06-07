using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AimbotProjectile : MonoBehaviour
{
	[Serializable]
	public class GameObjectToDestroyAfterTime
	{
		public GameObject target;

		public float lifetime;
	}

	private Weapon weapon;

	public bool shakeCameraOnDestroy;

	public List<GameObjectToDestroyAfterTime> objectsToUnparentOnDestroy = new List<GameObjectToDestroyAfterTime>();

	public GameObject spawnOnHit;

	private Transform targetTransform;

	private Hp targetHp;

	private TaggedObject targetTaggedObject;

	[HideInInspector]
	public Vector3 rememberTarget;

	private Vector3 myLinearPosition;

	private Vector3 spawnPosition;

	private Vector3 previousPosition;

	private float finalDamageMultiplyer = 1f;

	private float remainingRange;

	private TaggedObject firedBy;

	private bool firedByPlayer;

	private bool targetIsFlying;

	[HideInInspector]
	public UnityEvent onHit = new UnityEvent();

	private float speed;

	public Weapon Weapon
	{
		get
		{
			return weapon;
		}
		set
		{
			weapon = value;
		}
	}

	public void Fire(Weapon _weapon, Hp _target, float _chaseRange, Vector3 _backupTarget, TaggedObject _firedBy, float _finalDamageMultiplyer = 1f, float _projectileSpeedMultiplyer = 1f)
	{
		firedBy = _firedBy;
		if ((bool)firedBy)
		{
			firedByPlayer = _firedBy.Tags.Contains(TagManager.ETag.Player);
		}
		weapon = _weapon;
		if ((bool)_target)
		{
			targetTransform = _target.transform;
			rememberTarget = targetTransform.position;
			targetHp = _target;
			targetTaggedObject = _target.GetComponent<TaggedObject>();
			if (targetTaggedObject.Tags.Contains(TagManager.ETag.Flying))
			{
				targetIsFlying = true;
			}
		}
		else
		{
			rememberTarget = _backupTarget;
		}
		myLinearPosition = base.transform.position;
		spawnPosition = base.transform.position;
		previousPosition = base.transform.position;
		remainingRange = Mathf.Max(_chaseRange, (spawnPosition - rememberTarget).magnitude + 0.5f);
		finalDamageMultiplyer = _finalDamageMultiplyer;
		foreach (GameObjectToDestroyAfterTime item in objectsToUnparentOnDestroy)
		{
			item?.target.transform.SetParent(null);
		}
		speed = weapon.projectileSpeed * _projectileSpeedMultiplyer;
		Update();
	}

	private void Update()
	{
		if ((bool)targetTransform)
		{
			if (targetTaggedObject.colliderForBigOjectsToMeasureDistance != null)
			{
				rememberTarget = targetTaggedObject.colliderForBigOjectsToMeasureDistance.ClosestPoint(spawnPosition);
			}
			else
			{
				rememberTarget = targetTransform.position + targetHp.hitFeedbackHeight * Vector3.up;
			}
		}
		Vector3 vector = rememberTarget - myLinearPosition;
		float num = speed * Time.deltaTime;
		if (num >= vector.magnitude)
		{
			_ = base.transform.position;
			base.transform.position = rememberTarget;
			if (targetTaggedObject != null && targetHp != null && targetTransform != null)
			{
				weapon.DealDamage(targetHp, finalDamageMultiplyer, firedBy);
			}
			GameObject gameObject = null;
			if (!targetIsFlying && (bool)weapon.spawnOnGroundWhenTargetingGround)
			{
				gameObject = ((!(targetTransform != null)) ? UnityEngine.Object.Instantiate(weapon.spawnOnGroundWhenTargetingGround, base.transform.position, Quaternion.identity) : UnityEngine.Object.Instantiate(weapon.spawnOnGroundWhenTargetingGround, targetTransform.position, Quaternion.identity));
			}
			else if (targetIsFlying && (bool)weapon.spawnInAirWhenTargetingAir)
			{
				gameObject = ((!(targetTransform != null)) ? UnityEngine.Object.Instantiate(weapon.spawnInAirWhenTargetingAir, base.transform.position, Quaternion.identity) : UnityEngine.Object.Instantiate(weapon.spawnInAirWhenTargetingAir, targetTransform.position, Quaternion.identity));
			}
			if ((bool)gameObject)
			{
				WeaponDamageDealer[] components = gameObject.GetComponents<WeaponDamageDealer>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].DamageMultiplyer = finalDamageMultiplyer * weapon.BlacksmithMulti;
				}
			}
			if (spawnOnHit != null)
			{
				UnityEngine.Object.Instantiate(spawnOnHit, base.transform.position, Quaternion.identity, null);
			}
			onHit.Invoke();
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			myLinearPosition += vector.normalized * num;
		}
		float magnitude = (rememberTarget - spawnPosition).magnitude;
		float num4;
		if (magnitude > 0.001f)
		{
			float num2 = (myLinearPosition - spawnPosition).magnitude / magnitude;
			float num3 = Mathf.Max(0f, (magnitude + weapon.projectileParabulaOffset) * weapon.projectileParabulaFactor);
			num4 = (0f - Mathf.Pow(2f * num2 - 1f, 2f) + 1f) * num3;
		}
		else
		{
			num4 = 0f;
		}
		base.transform.position = myLinearPosition + Vector3.up * num4;
		if (weapon.projectileFacingDirection == Weapon.EFacingDirection.FaceVictim && base.transform.position != previousPosition)
		{
			base.transform.rotation = Quaternion.LookRotation(base.transform.position - previousPosition, Vector3.up);
		}
		previousPosition = base.transform.position;
		foreach (GameObjectToDestroyAfterTime item in objectsToUnparentOnDestroy)
		{
			item.target.transform.position = base.transform.position;
		}
		remainingRange -= num;
		if (remainingRange <= 0f)
		{
			targetTransform = null;
		}
	}

	private void OnDestroy()
	{
		foreach (GameObjectToDestroyAfterTime item in objectsToUnparentOnDestroy)
		{
			UnityEngine.Object.Destroy(item.target, item.lifetime);
		}
		if (shakeCameraOnDestroy && (bool)CameraController.instance)
		{
			CameraController.instance.ShakePunch();
		}
	}
}
