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

public class TP_Light1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int localIndex;

		public TP_Light1_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_01dd: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0152: Expected O, but got I
			//IL_0187: Expected I, but got O
			//IL_0197: Expected O, but got I4
			//IL_0079->IL01a6: Incompatible stack heights: 1 vs 0
			//IL_009e->IL01a6: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL01a6: Incompatible stack heights: 1 vs 0
			//IL_0117->IL01a6: Incompatible stack heights: 1 vs 0
			//IL_013c->IL01a6: Incompatible stack heights: 1 vs 0
			//IL_017a->IL01a6: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							TP_Light1_Weapon tP_Light1_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								GameObject gameObject3 = (GameObject)(object)_003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
										float2 position2 = ((ArcadeSprite)0).position;
										TP_Light1_Weapon tP_Light1_Weapon2 = _003C_003E4__this;
										if ((object)_003C_003E4__this != null)
										{
											nint num2 = (nint)gameObject3;
											object obj2 = localIndex + 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v325 @ r10_v6 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public WeaponType wt;

		internal bool _003CInitWeapon_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - wt;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private BulletPool _orbitersPool;

	protected Projectile _orbiterPrefab;

	[NonSerialized]
	public int OrbitAmount = 5;

	private float _003CProjScaledAlpha_003Ek__BackingField;

	private WeaponType[] _lightDarkWeapons = new WeaponType[4]
	{
		WeaponType.TP_LIGHT1,
		WeaponType.TP_LIGHT2,
		WeaponType.TP_DARK1,
		WeaponType.TP_DARK2
	};

	public float ProjScaledAlpha
	{
		get
		{
			return _003CProjScaledAlpha_003Ek__BackingField;
		}
		set
		{
			_003CProjScaledAlpha_003Ek__BackingField = value;
		}
	}

	protected override void OnStart()
	{
		//IL_0090: Expected I, but got O
		//IL_0133: Expected I, but got O
		base.OnStart();
		if (_orbitersPool == null)
		{
			BulletPool orbitersPool = new BulletPool(_orbiterPrefab);
			_orbitersPool = orbitersPool;
			BulletPool orbitersPool2 = _orbitersPool;
			orbitersPool2.UpperLimit = 200;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_orbitersPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_orbitersPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_022e: Expected I, but got O
		//IL_0266: Expected I, but got O
		//IL_0276: Expected O, but got I
		//IL_00a9: Expected I, but got O
		//IL_02b2: Expected O, but got I
		//IL_014c: Expected I, but got O
		//IL_0325: Expected I, but got O
		//IL_0373: Expected I4, but got O
		base.InitWeapon(characterController, weaponType);
		ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if (_orbitersPool == null)
		{
			BulletPool orbitersPool = new BulletPool(_orbiterPrefab);
			_orbitersPool = orbitersPool;
			BulletPool orbitersPool2 = _orbitersPool;
			orbitersPool2.UpperLimit = 200;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				GameManager core = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+350]");
				ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Collider collider = physics.add.overlap(_orbitersPool, core.Enemies, collideCallback, arcadePhysicsCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					ArcadePhysics physics2 = s_scene2.physics;
					GameManager core2 = GM.Core;
					PhysicsManager physicsManager = core2._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num2 = (nint)this;
					Collider collider2 = physics2.add.overlap(_orbitersPool, physicsManager._destructiblesGroup, collideCallback2, arcadePhysicsCallback, callbackContext);
					goto IL_0187;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0187;
		IL_0187:
		WeaponType[] lightDarkWeapons = _lightDarkWeapons;
		bool flag = false;
		bool flag2 = false;
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			if ((flag ? 1 : 0) >= lightDarkWeapons.Length)
			{
				return;
			}
			_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass9_0();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbp_v3 (VampireSurvivors.Data.WeaponType[])+20+v250 @ rdi_v5 (System.Boolean)*4]");
			CS_0024_003C_003E8__locals2.wt = WeaponType.VOID;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
			Predicate<Equipment> match = delegate(Equipment x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj3 = x._equipmentType - CS_0024_003C_003E8__locals2.wt;
				return obj3 == null;
			};
			Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
			nint num3 = (nint)typeof(Weapon);
			Equipment equipment2;
			if ((object)equipment == null)
			{
				nint num4 = 0;
				equipment2 = null;
			}
			else
			{
				nint num4 = (nint)equipment;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				if (num5 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rax_v36+FFFFFFF8+v670 @ rax_v33*8]");
				bool flag3 = 0 != (nint)typeof(Weapon);
				equipment2 = equipment;
				if (flag3)
				{
					break;
				}
			}
			if ((object)equipment2 != null && ((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0)
			{
				nint num6 = (nint)equipment2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v843 @ rax_v23 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+568] (should have been resolved before IL gen)");
				Action onComplete = delegate
				{
					base.ResetFiringTimer();
				};
				Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)arcadePhysicsCallback != 0, (MonoBehaviour)(object)callbackContext, repeat, type, isOnlineTimer: false, canPause: false);
			}
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			arcadePhysicsCallback = arcadePhysicsCallback;
			flag = flag2;
		}
		throw new InvalidCastException();
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
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

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0202: Invalid comparison between F4 and I4
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_01a8: Invalid comparison between O and F4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0153: Invalid comparison between F4 and I4
		//IL_0161: Expected F4, but got I4
		float num = base.PAmount();
		float num2 = default(float);
		bool flag = !(num2 > 0f);
		float num3 = num2;
		if (!flag)
		{
			bool flag2 = false;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag4;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj = flag2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj <= 0)
				{
					Vector2 playerPos = base.PlayerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					Vector2 playerPos2 = base.PlayerPos;
					bool flag3 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass13_0();
					CS_0024_003C_003E8__locals13._003C_003E4__this = this;
					CS_0024_003C_003E8__locals13.localIndex = (flag2 ? 1 : 0);
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_01dd: Expected O, but got I4
						//IL_00b4: Expected O, but got I
						//IL_00e9: Expected I, but got O
						//IL_0152: Expected O, but got I
						//IL_0187: Expected I, but got O
						//IL_0197: Expected O, but got I4
						//IL_0079->IL01a6: Incompatible stack heights: 1 vs 0
						//IL_009e->IL01a6: Incompatible stack heights: 1 vs 0
						//IL_00dc->IL01a6: Incompatible stack heights: 1 vs 0
						//IL_0117->IL01a6: Incompatible stack heights: 1 vs 0
						//IL_013c->IL01a6: Incompatible stack heights: 1 vs 0
						//IL_017a->IL01a6: Incompatible stack heights: 1 vs 0
						if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
						{
							GameObject gameObject = CS_0024_003C_003E8__locals13._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj3 == null)
								{
									return;
								}
								GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals13._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (UnityEngine.GameObject)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (UnityEngine.GameObject)+58]");
										float2 position = ((ArcadeSprite)0).position;
										TP_Light1_Weapon tP_Light1_Weapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
										{
											nint num8 = (nint)gameObject2;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
											GameObject gameObject3 = (GameObject)(object)CS_0024_003C_003E8__locals13._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
													float2 position2 = ((ArcadeSprite)0).position;
													TP_Light1_Weapon tP_Light1_Weapon2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
													if ((object)CS_0024_003C_003E8__locals13._003C_003E4__this != null)
													{
														nint num9 = (nint)gameObject3;
														object obj4 = CS_0024_003C_003E8__locals13.localIndex + 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v325 @ r10_v6 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
														return;
													}
												}
											}
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num4 = (float)(flag2 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num4 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag4 = num2 > (float)(flag2 ? 1 : 0);
				num3 = (flag2 ? 1 : 0);
			}
			while (flag4);
		}
		float num5 = base.PInterval();
		float num6 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num6 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num7 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public Projectile SpawnOrbitProjectile(float2 pos, int index)
	{
		if (_orbitersPool != null)
		{
			return _orbitersPool.SpawnAt(pos, this, index);
		}
		return (Projectile)(object)new NullReferenceException();
	}

	public override bool LevelUp()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	private void _003CInitWeapon_003Eb__9_1()
	{
		base.ResetFiringTimer();
	}
}
