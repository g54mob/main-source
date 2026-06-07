using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SimpleSiege/Weapon")]
public class Weapon : ScriptableObject
{
	public enum EFacingDirection
	{
		Uniform = 0,
		FaceVictim = 1,
		FaceAttacker = 2,
		Random = 3
	}

	public enum EDamageAffectedByBlacksmithUpgrade
	{
		Null = 0,
		MultiplyBy_MeleeDamage = 1,
		MultiplyBy_RangedDamage = 2,
		DivideBy_MeleeResistance = 3,
		DivideBy_RangedResistance = 4
	}

	[Header("Blacksmith Upgrades")]
	public EDamageAffectedByBlacksmithUpgrade blacksmithEffect;

	[Header("Aimbot Projectile Settings")]
	public EFacingDirection projectileFacingDirection;

	public float projectileSpeed;

	public float projectileParabulaFactor;

	public float projectileParabulaOffset;

	public GameObject projectileVisuals;

	public GameObject projectileImpactVisuals;

	public float raycastLength = 1f;

	public bool performRaycastBeforeShooting;

	public LayerMask raycastBeforeShootingLayerMask;

	public float maximumChaseRange = 10000f;

	public float shootWithoutTargetRange = 20f;

	public GameObject spawnOnGroundWhenTargetingGround;

	public GameObject spawnInAirWhenTargetingAir;

	[Header("Melee Attack Setting")]
	public GameObject fxSpawnOnAttacker;

	public bool parentFxToAttacker;

	public GameObject fxSpawnOnVictim;

	public bool followFxVictim;

	[Header("Damage")]
	public bool isPlayerWeapon;

	public List<DamageModifyer> directDamage;

	public List<DamageModifyer> splashDamage;

	public float slowsFastEnemiesFor;

	private PlayerUpgradeManager playerUpgradeManager;

	private GameObject lastSpawnedFX;

	[Header("Bonus Effects")]
	[SerializeField]
	private List<AdditionalWeaponEffectScript> additionalWeaponEffects = new List<AdditionalWeaponEffectScript>();

	private BlacksmithUpgrades blacksmithUpgrades;

	public float BlacksmithMulti => blacksmithEffect switch
	{
		EDamageAffectedByBlacksmithUpgrade.MultiplyBy_MeleeDamage => BlacksmithUpgrades.instance.meleeDamage, 
		EDamageAffectedByBlacksmithUpgrade.MultiplyBy_RangedDamage => BlacksmithUpgrades.instance.rangedDamage, 
		EDamageAffectedByBlacksmithUpgrade.DivideBy_MeleeResistance => 1f / BlacksmithUpgrades.instance.meleeResistance, 
		EDamageAffectedByBlacksmithUpgrade.DivideBy_RangedResistance => 1f / BlacksmithUpgrades.instance.rangedResistance, 
		_ => 1f, 
	};

	public void Attack(Vector3 _attackOrigin, Hp _target, Vector3 _attackDirection, TaggedObject _attacker, float _finalDamageMultiplyer = 1f, float _projectileSpeedMultiplyer = 1f)
	{
		playerUpgradeManager = PlayerUpgradeManager.instance;
		Vector3 vector = _attackOrigin + _attackDirection;
		try
		{
			vector = ((!(_target.TaggedObj.colliderForBigOjectsToMeasureDistance != null)) ? (_target.transform.position + _target.hitFeedbackHeight * Vector3.up) : _target.TaggedObj.colliderForBigOjectsToMeasureDistance.ClosestPoint(_attackOrigin));
		}
		catch
		{
		}
		if (performRaycastBeforeShooting)
		{
			Physics.Raycast(_attackOrigin, vector - _attackOrigin, out var hitInfo, (vector - _attackOrigin).magnitude, raycastBeforeShootingLayerMask);
			if ((bool)hitInfo.collider)
			{
				Hp componentInParent = hitInfo.collider.GetComponentInParent<Hp>();
				if ((bool)componentInParent)
				{
					_target = componentInParent;
					vector = ((!_target.TaggedObj.colliderForBigOjectsToMeasureDistance) ? (_target.transform.position + _target.hitFeedbackHeight * Vector3.up) : _target.TaggedObj.colliderForBigOjectsToMeasureDistance.ClosestPoint(_attackOrigin));
				}
			}
		}
		if (projectileSpeed > 0f && projectileVisuals != null)
		{
			AimbotProjectile component = Object.Instantiate(projectileVisuals, _attackOrigin, Quaternion.identity).GetComponent<AimbotProjectile>();
			Vector3 backupTarget = Vector3.zero;
			if (_target == null)
			{
				backupTarget = vector;
			}
			component.Fire(this, _target, maximumChaseRange, backupTarget, _attacker, _finalDamageMultiplyer, _projectileSpeedMultiplyer);
			return;
		}
		if (fxSpawnOnAttacker != null)
		{
			SpawnAttackFx(fxSpawnOnAttacker, _attackOrigin, _attackOrigin, _target, vector, _attacker, _finalDamageMultiplyer, parentFxToAttacker);
		}
		if (fxSpawnOnVictim != null && _target != null)
		{
			SpawnAttackFx(fxSpawnOnVictim, vector, _attackOrigin, _target, vector, _attacker, _finalDamageMultiplyer);
			if (followFxVictim && lastSpawnedFX != null && (bool)lastSpawnedFX.GetComponent<CustomPositionConstraint>())
			{
				lastSpawnedFX.GetComponent<CustomPositionConstraint>().followTransform = _target.transform;
			}
		}
		DealDamage(_target, _finalDamageMultiplyer, _attacker);
	}

	private void SpawnAttackFx(GameObject _fxPrefab, Vector3 _spawnPosition, Vector3 _attackOrigin, Hp _target, Vector3 _attackPosition, TaggedObject _attacker, float _finalDamageMultiplyer = 1f, bool parentToAttacker = false)
	{
		Quaternion rotation = Quaternion.identity;
		if (_attackPosition != _attackOrigin)
		{
			Vector3 vector = _attackPosition - _attackOrigin;
			vector = new Vector3(vector.x, 0f, vector.z);
			rotation = Quaternion.LookRotation(vector, Vector3.up);
		}
		Transform parent = null;
		if (parentToAttacker)
		{
			parent = _attacker.transform;
		}
		DealSplashDamage(lastSpawnedFX = Object.Instantiate(_fxPrefab, _spawnPosition, rotation, parent), _attacker, _finalDamageMultiplyer);
	}

	public void DealSplashDamage(GameObject _fxWithSplashDamageAreas, TaggedObject _attacker, float _finalDamageMultiplyer)
	{
		if (splashDamage.Count <= 0)
		{
			return;
		}
		SplashDamageArea[] componentsInChildren = _fxWithSplashDamageAreas.GetComponentsInChildren<SplashDamageArea>();
		if (componentsInChildren.Length != 0)
		{
			List<Hp> list = new List<Hp>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].AddReiveDamageHpScriptsInAreaToList(list);
			}
			for (int j = 0; j < list.Count; j++)
			{
				DealDamage(list[j], _finalDamageMultiplyer, _attacker, splashDamage: true);
			}
		}
	}

	public void DealDamage(Hp _target, float _finalDamageMultiplyer, TaggedObject _attacker, bool splashDamage = false)
	{
		if (!_target)
		{
			return;
		}
		TaggedObject taggedObj = _target.TaggedObj;
		if (!taggedObj)
		{
			return;
		}
		float num = _finalDamageMultiplyer;
		if (blacksmithUpgrades == null)
		{
			blacksmithUpgrades = BlacksmithUpgrades.instance;
		}
		switch (blacksmithEffect)
		{
		case EDamageAffectedByBlacksmithUpgrade.MultiplyBy_MeleeDamage:
			num *= blacksmithUpgrades.meleeDamage;
			break;
		case EDamageAffectedByBlacksmithUpgrade.MultiplyBy_RangedDamage:
			num *= blacksmithUpgrades.rangedDamage;
			break;
		case EDamageAffectedByBlacksmithUpgrade.DivideBy_MeleeResistance:
			num /= blacksmithUpgrades.meleeResistance;
			break;
		case EDamageAffectedByBlacksmithUpgrade.DivideBy_RangedResistance:
			num /= blacksmithUpgrades.rangedResistance;
			break;
		}
		float hpValue = _target.HpValue;
		float num2;
		bool targetKilled;
		if (splashDamage)
		{
			num2 = CalculateSplashDamageOnTarget(taggedObj, num);
			targetKilled = _target.TakeDamage(num2, _attacker, isPlayerWeapon);
		}
		else
		{
			num2 = CalculateDirectDamageOnTarget(taggedObj, num);
			targetKilled = _target.TakeDamage(num2, _attacker, isPlayerWeapon);
		}
		if (num2 == 0f)
		{
			return;
		}
		foreach (AdditionalWeaponEffectScript additionalWeaponEffect in additionalWeaponEffects)
		{
			additionalWeaponEffect.Effect(_target, taggedObj, _attacker, this, _finalDamageMultiplyer, targetKilled, num2);
		}
		if (taggedObj.Tags.Contains(TagManager.ETag.Player) && playerUpgradeManager.magicArmor && hpValue - _target.HpValue > 0f && (bool)_attacker && (bool)_attacker.Hp)
		{
			if (_attacker.Tags.Contains(TagManager.ETag.RangedFighter))
			{
				_attacker.Hp.TakeDamage(UpgradeMagicArmor.instance.damageVersusRanged, taggedObj, causedByPlayer: true);
			}
			else
			{
				_attacker.Hp.TakeDamage(UpgradeMagicArmor.instance.damageVersusMelee, taggedObj, causedByPlayer: true);
			}
		}
		if (slowsFastEnemiesFor >= 0f && taggedObj.Tags.Contains(TagManager.ETag.FastMoving) && (bool)_target.PathfindMovement)
		{
			if (PerkManager.instance.IceMagicActive)
			{
				_target.PathfindMovement.Slow(slowsFastEnemiesFor);
			}
			else
			{
				_target.PathfindMovement.Slow(slowsFastEnemiesFor);
			}
		}
	}

	public float CalculateDirectDamageOnTarget(TaggedObject _taggedObject, float _finalDamageMultiplyer = 1f)
	{
		return DamageModifyer.CalculateDamageOnTarget(_taggedObject, directDamage, _finalDamageMultiplyer);
	}

	public float CalculateSplashDamageOnTarget(TaggedObject _taggedObject, float _finalDamageMultiplyer = 1f)
	{
		return DamageModifyer.CalculateDamageOnTarget(_taggedObject, splashDamage, _finalDamageMultiplyer);
	}

	public static float CalculateDamageGeneral(TaggedObject _taggedObject, List<DamageModifyer> directDamage, float _finalDamageMultiplyer = 1f)
	{
		return DamageModifyer.CalculateDamageOnTarget(_taggedObject, directDamage, _finalDamageMultiplyer);
	}
}
