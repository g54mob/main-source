using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Mace2_Weapon : Weapon
{
	[NonSerialized]
	public bool isCrit;

	[NonSerialized]
	public int ExtraBodyAmount = 3;

	private float maxCooldownOffset = 0.5f;

	private float cooldownOffset;

	private Timer _freezeTimer;

	private bool _canFreeze = true;

	private BulletPool _invisPool;

	private BulletPool _critPool;

	private BulletPool _standardPool;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_009e: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_02cc: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (_standardPool != null)
		{
			goto IL_0179;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_MACE2_STANDARD);
		BulletPool standardPool = new BulletPool(projectilePrefab);
		_standardPool = standardPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_standardPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_standardPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0179;
			}
		}
		goto IL_0310;
		IL_0179:
		if (_critPool != null)
		{
			goto IL_0304;
		}
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_MACE2_CRIT);
		BulletPool critPool = new BulletPool(projectilePrefab2);
		_critPool = critPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			ArcadePhysicsCallback collideCallback3 = OnCriticalBulletOverlapsEnemy;
			Collider collider3 = physics3.add.overlap(_critPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider4 = physics4.add.overlap(_critPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				goto IL_0304;
			}
		}
		goto IL_0310;
		IL_0310:
		throw new NullReferenceException();
		IL_0304:
		_canFreeze = true;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0053: Expected O, but got I
		//IL_00c2: Invalid comparison between F4 and I
		//IL_00e8: Invalid comparison between F4 and I4
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026b: Invalid comparison between O and F4
		//IL_0174: Expected I, but got O
		//IL_017c: Expected I, but got O
		//IL_018c: Expected O, but got I
		//IL_0296: Expected F4, but got O
		//IL_020c: Expected O, but got I4
		//IL_01c8: Expected O, but got I
		//IL_01fe: Expected O, but got I4
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		Projectile projectile;
		Vector2 vector = default(Vector2);
		object obj5;
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			WeaponData currentWeaponData = _currentWeaponData;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num2 = characterController.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v7+20+v58 @ rdx_v5 (System.Int32)*4]");
			bool flag = num3 < 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v7+20+v58 @ rdx_v5 (System.Int32)*4]");
			float num5 = num4 - 0f;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			isCrit = flag5;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			projectile = base.FireOneProjectile(vector, 0, _targetTransform);
			if ((object)projectile == null)
			{
				goto IL_0232;
			}
			nint num6 = (nint)typeof(TP_Mace2_Projectile);
			nint num7 = (nint)projectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Mace2_Projectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Mace2_Projectile>)+130]");
			if (num8 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rcx_v26+FFFFFFF8+v360 @ rcx_v20*8]");
				if (0 == (nint)typeof(TP_Mace2_Projectile))
				{
					obj5 = 1;
					goto IL_02c7;
				}
			}
			obj5 = 0;
			goto IL_02c7;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_02c7:
		bool flag6 = obj5 == null;
		TP_Mace2_Projectile tP_Mace2_Projectile = null;
		if (!flag6)
		{
			tP_Mace2_Projectile = (TP_Mace2_Projectile)projectile;
		}
		tP_Mace2_Projectile?.SetCritical(isCrit);
		goto IL_0232;
		IL_0232:
		float num9 = PInterval();
		float num10 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj6 = num10 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num11 = PInterval();
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

	protected bool OnCriticalBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02b3: Expected I4, but got O
		//IL_00b7: Expected I, but got O
		//IL_00bf: Expected I, but got O
		//IL_00cf: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_0148: Expected O, but got I
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_0349: Expected O, but got I4
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
						goto IL_02d0;
					}
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null)
					{
						float num = currentWeaponData._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
						if (second != null)
						{
							nint num2 = (nint)typeof(Projectile);
							nint num3 = (nint)second;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							if (num4 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v13+FFFFFFF8+v146 @ rax_v12*8]");
								if (0 == (nint)typeof(Projectile))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v13+FFFFFFF8+v455 @ rcx_v8*8]");
									object obj4 = 0 - typeof(Projectile);
									bool flag = obj4 == null;
									bool flag2 = !flag;
									Projectile projectile = null;
									if (!flag2)
									{
										projectile = (Projectile)second;
									}
									if (projectile.HasAlreadyHitObject(component))
									{
										goto IL_02d0;
									}
									float num5 = base.PPower();
									WeaponData currentWeaponData2 = _currentWeaponData;
									object obj5 = default(object);
									float num6 = (float)obj5 * num;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData2._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									component.GetDamagedSpecial(num6, showHitVfx, knockback, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
									float2 position = component.position;
									if (_playerOptions != null)
									{
										PlayerOptionsData config = _playerOptions.Config;
										if (config != null)
										{
											if (config._003CDamageNumbersEnabled_003Ek__BackingField)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
												if (_signalBus == null)
												{
													goto IL_02a5;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
											}
											float num7 = num6 + base._003CStatsInflictedDamage_003Ek__BackingField;
											base._003CStatsInflictedDamage_003Ek__BackingField = num7;
											goto IL_02d0;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_02a5;
		IL_02a5:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02d0:
		return false;
	}

	public void ShowBigDamage(float value, Vector3 position)
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CDamageNumbersEnabled_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
		}
	}

	public bool FrameFreeze()
	{
		//IL_01b0: Expected I4, but got O
		if (!_canFreeze)
		{
			return false;
		}
		bool flag = _freezeTimer == null;
		_canFreeze = false;
		if (!flag)
		{
			_freezeTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_canFreeze = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer freezeTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_freezeTimer = freezeTimer;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				if (config._003CScreenShakeEnabled_003Ek__BackingField)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core == null)
					{
						goto IL_01a2;
					}
					if (!core2._003CFreezingFrame_003Ek__BackingField)
					{
						GM.Core.FrameFreeze(null, 150f);
					}
				}
				return true;
			}
		}
		goto IL_01a2;
		IL_01a2:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public Projectile CreateStandardProjectile(int index)
	{
		float2 pos = default(float2);
		if (_standardPool != null)
		{
			return _standardPool.SpawnAt(pos, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	public Projectile CreateCriticalProjectile(int index)
	{
		float2 pos = default(float2);
		if (_critPool != null)
		{
			return _critPool.SpawnAt(pos, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		if (_critPool != null)
		{
			_critPool.Destroy();
		}
		_critPool = null;
		if (_standardPool != null)
		{
			_standardPool.Destroy();
		}
		_standardPool = null;
		base.OnDestroy();
	}

	private void _003CFrameFreeze_003Eb__16_0()
	{
		_canFreeze = true;
	}
}
