using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Mace1_Weapon : Weapon
{
	private float maxCooldownOffset = 0.5f;

	private float cooldownOffset;

	private BulletPool _lingerPool;

	[NonSerialized]
	public int ExtraBodyAmount = 3;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00bf: Expected I, but got O
		//IL_0162: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (_lingerPool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_MACE1_LINGER);
			BulletPool lingerPool = new BulletPool(projectilePrefab);
			_lingerPool = lingerPool;
			BulletPool lingerPool2 = _lingerPool;
			lingerPool2.UpperLimit = 100;
			BulletPool lingerPool3 = _lingerPool;
			lingerPool3.IsUncapped = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_lingerPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_lingerPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
		base._003CCanCrit_003Ek__BackingField = true;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected override void OnUpdate()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj = default(object);
		float num2 = 1f / (float)obj;
		float num3 = num2 * characterController._currentHp;
		float num4 = 1f - num3;
		float num5 = num4 * maxCooldownOffset;
		cooldownOffset = num5;
	}

	public override float PInterval()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0197;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num3 = default(float);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			if (characterController2._sineCooldown == null)
			{
				goto IL_0197;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && characterController3._sineCooldown != null)
				{
					float value = characterController3._sineCooldown.Value;
					float num2 = num3 + characterController2._003CSilentCooldown_003Ek__BackingField;
					float num4 = num2 - cooldownOffset;
					num3 = value * num4;
					bool flag = !(0.1f < num3);
					float num5 = 0.1f;
					if (!flag)
					{
						num5 = num3;
					}
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null)
					{
						return num5 * currentWeaponData._003Cinterval_003Ek__BackingField;
					}
				}
			}
		}
		goto IL_0253;
		IL_0253:
		throw new NullReferenceException();
		IL_0197:
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num6 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
			WeaponData currentWeaponData2 = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num7 = num3 + characterController4._003CSilentCooldown_003Ek__BackingField;
				float num8 = num7 - cooldownOffset;
				bool flag2 = !(0.1f < num8);
				float num9 = 0.1f;
				if (!flag2)
				{
					num9 = num8;
				}
				return num9 * currentWeaponData2._003Cinterval_003Ek__BackingField;
			}
		}
		goto IL_0253;
	}

	public override void Cleanup()
	{
		if (_lingerPool != null)
		{
			_lingerPool.Cleanup();
		}
		base.Cleanup();
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_020d: Expected I4, but got O
		//IL_00b7: Expected I, but got O
		//IL_00bf: Expected I, but got O
		//IL_00cf: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_0148: Expected O, but got I
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_022a;
					}
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null)
					{
						float num = currentWeaponData._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
						if (second != null)
						{
							nint num2 = (nint)typeof(Projectile);
							nint num3 = (nint)second;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							if (num4 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v13+FFFFFFF8+v67 @ rax_v12*8]");
								if (0 == (nint)typeof(Projectile))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v13+FFFFFFF8+v282 @ rcx_v8*8]");
									object obj4 = 0 - typeof(Projectile);
									bool flag = obj4 == null;
									bool flag2 = !flag;
									Projectile projectile = null;
									if (!flag2)
									{
										projectile = (Projectile)second;
									}
									if (!projectile.HasAlreadyHitObject(component))
									{
										float num5 = base.PPower();
										WeaponData currentWeaponData2 = _currentWeaponData;
										object obj5 = default(object);
										float num6 = (float)obj5 * num;
										HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData2._003ChitVFX_003Ek__BackingField);
										float knockback = base.Knockback;
										component.GetDamaged(num6, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
										float num7 = num6 + base._003CStatsInflictedDamage_003Ek__BackingField;
										base._003CStatsInflictedDamage_003Ek__BackingField = num7;
									}
									goto IL_022a;
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_022a:
		return false;
	}

	public Projectile CreateLingerProjectile(int index)
	{
		float2 pos = default(float2);
		if (_lingerPool != null)
		{
			return _lingerPool.SpawnAt(pos, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		if (_lingerPool != null)
		{
			_lingerPool.Destroy();
		}
		_lingerPool = null;
		base.OnDestroy();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		if (base._003CCanCrit_003Ek__BackingField)
		{
			base.StandardCritical(second, first);
			return false;
		}
		return base.OnBulletOverlapsEnemy(context, second, first);
	}
}
