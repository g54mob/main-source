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
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Banana1_Weapon : LEM_BaseWeapon
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public LEM_Banana1_Weapon _003C_003E4__this;

		public Vector2 playerDir;
	}

	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			//IL_0188: Expected O, but got I4
			//IL_00a8->IL0151: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0151: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0151: Incompatible stack heights: 1 vs 0
			//IL_012a->IL0151: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass6_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass6_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						LEM_Banana1_Weapon lEM_Banana1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)((Equipment)lEM_Banana1_Weapon)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)lEM_Banana1_Weapon)._003COwner_003Ek__BackingField.position;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								Vector2 vector = default(Vector2);
								obj3._003C_003E4__this.FireOneBananaProjectile(vector, localIndex, vector);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _CritExplosionPrefab;

	private BulletPool _critExplosionPool;

	public virtual bool DespawnOnExplode => true;

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		base.OnStart();
		if (_critExplosionPool == null)
		{
			BulletPool critExplosionPool = new BulletPool(_CritExplosionPrefab, 100);
			_critExplosionPool = critExplosionPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnExplosionOverlapsEnemy;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_critExplosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_critExplosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		AddOuterSaboteur();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0081: Invalid comparison between O and F4
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_026d: Invalid comparison between O and F4
		//IL_00b3: Invalid comparison between O and F4
		//IL_0298: Expected F4, but got O
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_01fb: Expected O, but got F4
		_003C_003Ec__DisplayClass6_0 obj = new _003C_003Ec__DisplayClass6_0();
		obj._003C_003E4__this = this;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		obj.playerDir = characterController._lastMovementDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v6 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		_ = 0;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		FireOneBananaProjectile(vector, 0, vector);
		float num = base.PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		Vector2 vector2 = vector;
		if (!flag)
		{
			float num2 = base.PAmount();
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			vector2 = vector;
			if (!flag2)
			{
				int num3 = 1;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj2 = num3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj2 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						FireOneBananaProjectile(playerPos, num3, vector);
						vector2 = vector;
					}
					else
					{
						_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass6_1();
						CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
						CS_0024_003C_003E8__locals8.localIndex = num3;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_0188: Expected O, but got I4
							//IL_00a8->IL0151: Incompatible stack heights: 1 vs 0
							//IL_00d7->IL0151: Incompatible stack heights: 1 vs 0
							//IL_00f9->IL0151: Incompatible stack heights: 1 vs 0
							//IL_012a->IL0151: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass6_0 obj4 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
							{
								GameObject gameObject = obj4._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj5 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass6_0 obj6 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
									{
										LEM_Banana1_Weapon lEM_Banana1_Weapon = obj6._003C_003E4__this;
										if ((object)obj6._003C_003E4__this != null && (object)((Equipment)lEM_Banana1_Weapon)._003COwner_003Ek__BackingField != null)
										{
											float2 position2 = ((Equipment)lEM_Banana1_Weapon)._003COwner_003Ek__BackingField.position;
											if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
											{
												Vector2 vector3 = default(Vector2);
												obj6._003C_003E4__this.FireOneBananaProjectile(vector3, CS_0024_003C_003E8__locals8.localIndex, vector3);
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num4 = (float)num3 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						float num5 = num4 * 0.001f;
						Timer lastShotTimer = Timers.Register(num5, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
						vector2 = (Vector2)num5;
					}
					num3++;
					float num6 = base.PAmount();
				}
				while ((nint)vector2 > num3);
			}
		}
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		bool flag3 = default(bool);
		if (!flag3)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void FireOneBananaProjectile(Vector2 pos, int index, Vector2 playerDir)
	{
		//IL_000d: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		Projectile projectile = base.FireOneProjectile(pos, index, _targetTransform);
		bool flag = (object)projectile == null;
		LEM_Banana1_Projectile lEM_Banana1_Projectile = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(LEM_Banana1_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v27+FFFFFFF8+v68 @ rax_v23*8]");
				if (0 == (nint)typeof(LEM_Banana1_Projectile))
				{
					obj3 = 1;
					goto IL_0196;
				}
			}
			obj3 = 0;
			goto IL_0196;
		}
		goto IL_01bd;
		IL_01bd:
		if ((object)lEM_Banana1_Projectile != null && ((UnityEngine.Object)lEM_Banana1_Projectile).m_CachedPtr != (IntPtr)0)
		{
			lEM_Banana1_Projectile.SetFlipFromPlayerDirection(playerDir);
			Weapon weapon = ((Projectile)lEM_Banana1_Projectile)._weapon;
			if (!weapon.IsHoming)
			{
				lEM_Banana1_Projectile.AimInDirection(playerDir);
			}
			else
			{
				Transform transform = lEM_Banana1_Projectile.AimForNearestEnemy(rotate: false);
			}
		}
		return;
		IL_0196:
		bool flag2 = obj3 == null;
		lEM_Banana1_Projectile = null;
		if (!flag2)
		{
			lEM_Banana1_Projectile = (LEM_Banana1_Projectile)projectile;
		}
		goto IL_01bd;
	}

	public bool IsCritProjectile()
	{
		//IL_0053: Expected O, but got I
		//IL_00b4: Invalid comparison between F4 and I
		//IL_00da: Invalid comparison between F4 and I4
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			WeaponData currentWeaponData = _currentWeaponData;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+20+v53 @ rdx_v5 (System.Int32)*4]");
			bool flag = num3 < 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+20+v53 @ rdx_v5 (System.Int32)*4]");
			float num5 = num4 - 0f;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01e2: Expected I4, but got O
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
						goto IL_01ff;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							LEM_Banana1_Projectile component2 = gameObject2.GetComponent<LEM_Banana1_Projectile>();
							if ((object)component2 != null)
							{
								bool flag = component2.HasAlreadyHitObject(component);
								if (!flag)
								{
									float num2;
									float num3 = default(float);
									if (component2._003CIsCrit_003Ek__BackingField != flag)
									{
										float num = CalcCritMul();
										num2 = num3;
									}
									else
									{
										num2 = 1f;
									}
									float num4 = base.PPower();
									float damage = num3 * num2;
									base.DealDamage(component, damage);
									if (component2._003CIsCrit_003Ek__BackingField && !component2._003CHasExploded_003Ek__BackingField)
									{
										float2 position = component.position;
										Vector2 pos = default(Vector2);
										Projectile projectile = base.FireOneProjectile(pos, 0);
										component2._003CHasExploded_003Ek__BackingField = true;
										if (DespawnOnExplode)
										{
											component2.Despawn();
										}
									}
								}
								goto IL_01ff;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01ff:
		return false;
	}

	private void DealProjectileDamage(IDamageable other, LEM_Banana1_Projectile projectile)
	{
		float num2;
		float num3 = default(float);
		if (projectile._003CIsCrit_003Ek__BackingField)
		{
			float num = CalcCritMul();
			num2 = num3;
		}
		else
		{
			num2 = 1f;
		}
		float num4 = base.PPower();
		float damage = num3 * num2;
		base.DealDamage(other, damage);
	}

	protected override float CalcCritMul()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		return currentWeaponData._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
	}

	private void SpawnExplosionOnCrit(EnemyController target, LEM_Banana1_Projectile projectile)
	{
		if (projectile._003CIsCrit_003Ek__BackingField && !projectile._003CHasExploded_003Ek__BackingField)
		{
			float2 position = target.position;
			Vector2 pos = default(Vector2);
			Projectile projectile2 = base.FireOneProjectile(pos, 0);
			projectile._003CHasExploded_003Ek__BackingField = true;
			if (DespawnOnExplode)
			{
				projectile.Despawn();
			}
		}
	}

	private bool OnExplosionOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_014c: Expected I4, but got O
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
						goto IL_0169;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = CalcCritMul();
									object obj = default(object);
									float damage = (float)obj * (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0169;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0169:
		return false;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 2;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}
}
