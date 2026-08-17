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

public class TP_Icicle2_Weapon : Weapon
{
	private Projectile _LaunchProjectilePrefab;

	private Projectile _RuneProjectilePrefab;

	private Transform _RuneContainer;

	private int _003CNumRunes_003Ek__BackingField;

	private BulletPool _003CLaunchProjectilePool_003Ek__BackingField;

	private BulletPool _003CRuneProjectilePool_003Ek__BackingField;

	private Timer _runeTimer;

	public float ProjScale
	{
		get
		{
			float num = PArea();
			object obj = default(object);
			float num2 = (float)obj * 0.3f;
			return num2 + 1f;
		}
	}

	public Transform RuneContainer => _RuneContainer;

	private float RuneZRotSpeed
	{
		get
		{
			float num = base.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float num2 = (float)obj * -45f;
			return deltaTime * num2;
		}
	}

	public int NumRunes
	{
		get
		{
			return _003CNumRunes_003Ek__BackingField;
		}
		private set
		{
			_003CNumRunes_003Ek__BackingField = value;
		}
	}

	public BulletPool LaunchProjectilePool
	{
		get
		{
			return _003CLaunchProjectilePool_003Ek__BackingField;
		}
		private set
		{
			_003CLaunchProjectilePool_003Ek__BackingField = value;
		}
	}

	public BulletPool RuneProjectilePool
	{
		get
		{
			return _003CRuneProjectilePool_003Ek__BackingField;
		}
		private set
		{
			_003CRuneProjectilePool_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base._003CFreezeChance_003Ek__BackingField = 0.05f;
	}

	protected override void OnStart()
	{
		//IL_00a9: Expected I, but got O
		//IL_024a: Expected I, but got O
		//IL_014c: Expected I, but got O
		//IL_02ed: Expected I, but got O
		base.OnStart();
		if (_003CLaunchProjectilePool_003Ek__BackingField != null)
		{
			goto IL_0184;
		}
		BulletPool bulletPool = new BulletPool(_LaunchProjectilePrefab);
		_003CLaunchProjectilePool_003Ek__BackingField = bulletPool;
		BulletPool bulletPool2 = _003CLaunchProjectilePool_003Ek__BackingField;
		bulletPool2.UpperLimit = 100;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_003CLaunchProjectilePool_003Ek__BackingField, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_003CLaunchProjectilePool_003Ek__BackingField, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0184;
			}
		}
		goto IL_0326;
		IL_0326:
		throw new NullReferenceException();
		IL_0184:
		if (_003CRuneProjectilePool_003Ek__BackingField != null)
		{
			return;
		}
		BulletPool bulletPool3 = new BulletPool(_RuneProjectilePrefab);
		_003CRuneProjectilePool_003Ek__BackingField = bulletPool3;
		BulletPool bulletPool4 = _003CRuneProjectilePool_003Ek__BackingField;
		bulletPool4.UpperLimit = 100;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v722 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_003CRuneProjectilePool_003Ek__BackingField, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_003CRuneProjectilePool_003Ek__BackingField, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0326;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		if (_runeTimer != null)
		{
			_runeTimer.Cancel();
		}
		Action onComplete = UpdateRuneAmount;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer runeTimer = Timers.Register(1f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_runeTimer = runeTimer;
	}

	private void StartRuneTimer()
	{
		if (_runeTimer != null)
		{
			_runeTimer.Cancel();
		}
		Action onComplete = UpdateRuneAmount;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer runeTimer = Timers.Register(1f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_runeTimer = runeTimer;
	}

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(4.5f > num2);
		float result = 4.5f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public override float SecondaryPPower()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				return num * currentWeaponData._003Cpower_003Ek__BackingField;
			}
		}
		throw new NullReferenceException();
	}

	public override float SecondaryPAmount()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = !(10f > num2);
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		return (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target, BulletPool pool = null)
	{
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = projectile.transform;
			if ((object)transform == null)
			{
				return (Projectile)(object)new NullReferenceException();
			}
			transform.SetParent(_cachedTransform, worldPositionStays: true);
		}
		return projectile;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18744B840\"");
	}

	private unsafe void UpdateRuneContainer()
	{
		//IL_003f: Expected O, but got Ref
		Transform transform = _RuneContainer.transform;
		float num = PArea();
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		float num2 = base.PSpeed();
		float deltaTime = PauseSystem.DeltaTime;
		Vector3 vector = default(Vector3);
		_RuneContainer.Rotate((Vector3)(&vector), Space.Self);
	}

	private unsafe void UpdateRuneAmount()
	{
		//IL_079a: Expected O, but got Ref
		//IL_004d: Expected O, but got Ref
		//IL_01d8: Invalid comparison between F4 and I4
		//IL_07ad: Expected I, but got O
		//IL_07bd: Expected O, but got I
		//IL_07db: Invalid comparison between F4 and I4
		//IL_04d1: Expected O, but got I4
		//IL_0274: Expected I, but got O
		//IL_0282: Expected I, but got O
		//IL_0292: Expected O, but got I
		//IL_0312: Expected O, but got I4
		//IL_02ce: Expected O, but got I
		//IL_0304: Expected O, but got I4
		//IL_0570: Expected O, but got I
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected O, but got Unknown
		//IL_05bd: Expected O, but got I
		//IL_05db: Expected O, but got I4
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_0601: Expected O, but got I4
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected O, but got Unknown
		if (!_isVisible)
		{
			return;
		}
		List<TP_Icicle2_RuneProjectile> list = new List<TP_Icicle2_RuneProjectile>();
		bool flag = _spawnedProjectiles == null;
		List<TP_Icicle2_RuneProjectile> list2 = list;
		Projectile projectile;
		Component component;
		object obj3;
		if (!flag)
		{
			List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
			if (enumerator.MoveNext())
			{
				TP_Icicle2_RuneProjectile tP_Icicle2_RuneProjectile = null;
				list2 = (List<TP_Icicle2_RuneProjectile>)(&enumerator);
				throw new NullReferenceException();
			}
			bool flag2 = list == null;
			list2 = (List<TP_Icicle2_RuneProjectile>)(&enumerator);
			if (!flag2)
			{
				_003CNumRunes_003Ek__BackingField = list._size;
				float num = base.PAmount();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				if (num > (float)_003CNumRunes_003Ek__BackingField)
				{
					bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
					list2 = (List<TP_Icicle2_RuneProjectile>)(object)((Equipment)this)._003COwner_003Ek__BackingField;
					if (!flag3)
					{
						float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						Vector2 pos = default(Vector2);
						projectile = FireOneProjectile(pos, _003CNumRunes_003Ek__BackingField, _targetTransform);
						if ((object)projectile == null)
						{
							component = null;
							goto IL_081e;
						}
						nint num2 = (nint)projectile;
						nint num3 = (nint)typeof(TP_Icicle2_RuneProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Icicle2_RuneProjectile>)+130]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Icicle2_RuneProjectile>)+130]");
						if (num4 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v93+FFFFFFF8+v1063 @ rax_v89*8]");
							if (0 == (nint)typeof(TP_Icicle2_RuneProjectile))
							{
								obj3 = 1;
								goto IL_07f7;
							}
						}
						obj3 = 0;
						goto IL_07f7;
					}
				}
				else
				{
					nint num5 = (nint)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+410]");
					TP_Icicle2_RuneProjectile tP_Icicle2_RuneProjectile2 = (TP_Icicle2_RuneProjectile)0;
					float num6 = base.PAmount();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					if (!(num6 < (float)_003CNumRunes_003Ek__BackingField))
					{
						return;
					}
					List<Projectile> spawnedProjectiles = _spawnedProjectiles;
					bool flag4 = (nint)_spawnedProjectiles < 0;
					bool flag5 = _spawnedProjectiles == null;
					list2 = (List<TP_Icicle2_RuneProjectile>)(object)this;
					if (!flag5)
					{
						TP_Icicle2_RuneProjectile tP_Icicle2_RuneProjectile3 = (TP_Icicle2_RuneProjectile)(spawnedProjectiles._size - 1);
						list2 = (List<TP_Icicle2_RuneProjectile>)(object)this;
						if (flag4)
						{
							return;
						}
						object obj5 = default(object);
						object obj6 = default(object);
						TP_Icicle2_RuneProjectile tP_Icicle2_RuneProjectile4 = default(TP_Icicle2_RuneProjectile);
						List<TP_Icicle2_RuneProjectile>.Enumerator enumerator2 = default(List<TP_Icicle2_RuneProjectile>.Enumerator);
						object obj7 = default(object);
						while (true)
						{
							List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
							if (_spawnedProjectiles == null)
							{
								break;
							}
							if ((nint)tP_Icicle2_RuneProjectile3 < spawnedProjectiles2._size)
							{
								list2 = (List<TP_Icicle2_RuneProjectile>)(object)spawnedProjectiles2._items;
								if (spawnedProjectiles2._items == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.TP_Icicle2_RuneProjectile>)+20+v107 @ rdi_v13 (VampireSurvivors.Objects.Projectiles.TP_Icicle2_RuneProjectile)*8]");
								list2 = (List<TP_Icicle2_RuneProjectile>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.TP_Icicle2_RuneProjectile>)+20+v107 @ rdi_v13 (VampireSurvivors.Objects.Projectiles.TP_Icicle2_RuneProjectile)*8]");
								if ((nint)0 == 0)
								{
									break;
								}
								object obj4 = list2 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
								list2 = (List<TP_Icicle2_RuneProjectile>)0;
								((List<TP_Icicle2_RuneProjectile>)(object)typeof(TP_Icicle2_RuneProjectile)).Add((TP_Icicle2_RuneProjectile)1);
								list2 = (List<TP_Icicle2_RuneProjectile>)(obj5 + 32);
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								tP_Icicle2_RuneProjectile2 = (TP_Icicle2_RuneProjectile)1;
								if (obj6 != tP_Icicle2_RuneProjectile4)
								{
									tP_Icicle2_RuneProjectile3 = (TP_Icicle2_RuneProjectile)(tP_Icicle2_RuneProjectile3 - 1);
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<TP_Icicle2_RuneProjectile, UIntPtr>(ref tP_Icicle2_RuneProjectile4))
									{
										return;
									}
									continue;
								}
								int num7 = _003CNumRunes_003Ek__BackingField - 1;
								_003CNumRunes_003Ek__BackingField = num7;
								if (enumerator2.MoveNext())
								{
									TP_Icicle2_RuneProjectile tP_Icicle2_RuneProjectile5 = null;
									throw new NullReferenceException();
								}
								if (_spawnedProjectiles == null)
								{
									break;
								}
								((List<TP_Icicle2_RuneProjectile>)(object)_spawnedProjectiles).Add(tP_Icicle2_RuneProjectile3);
								if (obj7 == null)
								{
									break;
								}
								object obj8 = obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ r8_v11+368] (should have been resolved before IL gen)");
								return;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							return;
						}
					}
				}
			}
		}
		goto IL_06ba;
		IL_07f7:
		bool flag6 = obj3 == null;
		component = null;
		if (!flag6)
		{
			component = projectile;
		}
		goto IL_081e;
		IL_081e:
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform transform = component.transform;
		if ((object)transform != null)
		{
			transform.SetParent(_RuneContainer, worldPositionStays: true);
			int version = list._version + 1;
			list._version = version;
			TP_Icicle2_RuneProjectile[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)component);
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int num8 = _003CNumRunes_003Ek__BackingField + 1;
				_003CNumRunes_003Ek__BackingField = num8;
				List<TP_Icicle2_RuneProjectile>.Enumerator enumerator3 = default(List<TP_Icicle2_RuneProjectile>.Enumerator);
				if (enumerator3.MoveNext())
				{
					TP_Icicle2_RuneProjectile tP_Icicle2_RuneProjectile5 = null;
					throw new NullReferenceException();
				}
				return;
			}
		}
		goto IL_06ba;
		IL_06ba:
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			_explodeOnExpire = true;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.35f;
			}
		}
		CheckBeginningArcana();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		if (_runeTimer != null)
		{
			_runeTimer.Cancel();
		}
		base.Cleanup();
	}
}
