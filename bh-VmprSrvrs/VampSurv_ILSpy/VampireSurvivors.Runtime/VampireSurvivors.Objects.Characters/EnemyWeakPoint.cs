using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Characters;

public class EnemyWeakPoint : IDamageable
{
	private EnemyController _parentEnemy;

	public ArcadeSprite _damageZone;

	public bool _isApplyingDamage;

	private Collider _damageZoneCollider;

	public EnemyWeakPoint(EnemyController parentEnemy)
	{
		//IL_008a: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		EnemyController enemyController = default(EnemyController);
		_parentEnemy = enemyController;
		float2 position = enemyController.position;
		GameObject gameObject = enemyController.gameObject;
		Vector2 pos = default(Vector2);
		ArcadeSprite arcadeSprite = RenderingExtensions.AddArcadeSprite(gameObject, pos, "vfx", "WhiteDot");
		ArcadeSprite damageZone = arcadeSprite.setVisible(visible: false);
		_damageZone = damageZone;
		ArcadeSprite damageZone2 = _damageZone;
		BaseBody baseBody = damageZone2.body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		PhysicsManager sInstance = PhysicsManager._sInstance;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsDamageZone;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_damageZone, sInstance._bulletGroup, collideCallback, processCallback, callbackContext);
		Collider damageZoneCollider = collider.setName("Bullet>Weak Point");
		_damageZoneCollider = damageZoneCollider;
	}

	private bool OnBulletOverlapsDamageZone(CallbackContext context, ArcadeColliderType damageZone, ArcadeColliderType bullet)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0168: Expected I4, but got O
		Projectile projectile;
		if (bullet == null)
		{
			projectile = null;
			goto IL_01b4;
		}
		nint num = (nint)typeof(Projectile);
		nint num2 = (nint)bullet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v25+FFFFFFF8+v52 @ rax_v21*8]");
			if (0 == (nint)typeof(Projectile))
			{
				obj3 = 1;
				goto IL_018d;
			}
		}
		obj3 = 0;
		goto IL_018d;
		IL_018d:
		bool flag = obj3 == null;
		projectile = null;
		if (!flag)
		{
			projectile = (Projectile)bullet;
		}
		goto IL_01b4;
		IL_01b4:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			_isApplyingDamage = true;
			if (!projectile.HasAlreadyHitObject(this))
			{
				if ((object)projectile._weapon == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				projectile._weapon.DealDamage(_parentEnemy);
			}
			_isApplyingDamage = false;
		}
		return false;
	}

	public void Destroy()
	{
		if (_damageZoneCollider != null)
		{
			_damageZoneCollider.destroy();
			_damageZoneCollider = null;
		}
		ArcadeSprite damageZone = _damageZone;
		if ((object)_damageZone != null && ((UnityEngine.Object)damageZone).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite damageZone2 = _damageZone;
			damageZone2.body.destroy();
			ArcadeSprite damageZone3 = _damageZone;
			damageZone3.body = null;
			GameObject gameObject = _damageZone.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	public float CurrentHealth()
	{
		EnemyController parentEnemy = _parentEnemy;
		return parentEnemy._hp;
	}

	public void Despawn()
	{
		_parentEnemy.Despawn();
	}

	public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		_parentEnemy.GetDamaged(value, showHitVfx, damageKb, WeaponType.VOID, hasKb: false);
	}

	public GameObject GetGameObject()
	{
		if ((object)_parentEnemy != null)
		{
			return _parentEnemy.gameObject;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public void GiveReward(Action<Pickup> onRewardGiven = null)
	{
		_parentEnemy.GiveReward(onRewardGiven);
	}

	public bool IsUnitDead()
	{
		//IL_0041: Expected I4, but got O
		EnemyController parentEnemy = _parentEnemy;
		if ((object)_parentEnemy != null)
		{
			return parentEnemy._003CIsDead_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public float MaxHp()
	{
		EnemyController parentEnemy = _parentEnemy;
		return parentEnemy._maxHp;
	}

	public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
	{
		_parentEnemy.OnGetDamaged(hitVfxType, hasKb);
	}
}
