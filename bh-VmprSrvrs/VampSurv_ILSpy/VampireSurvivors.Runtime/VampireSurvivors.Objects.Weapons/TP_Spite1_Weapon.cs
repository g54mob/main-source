using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Spite1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Vector2 __pos;

		public int localIndex;

		public TP_Spite1_Weapon _003C_003E4__this;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_05ba: Expected O, but got I4
			//IL_00b9: Expected I, but got O
			//IL_00c7: Expected I, but got O
			//IL_00d7: Expected O, but got I
			//IL_0157: Expected O, but got I4
			//IL_0113: Expected O, but got I
			//IL_0149: Expected O, but got I4
			//IL_02f6: Expected I, but got O
			//IL_0304: Expected I, but got O
			//IL_0314: Expected O, but got I
			//IL_0394: Expected O, but got I4
			//IL_0350: Expected O, but got I
			//IL_0386: Expected O, but got I4
			//IL_04b3: Expected I, but got O
			//IL_04c1: Expected I, but got O
			//IL_04d1: Expected O, but got I
			//IL_0551: Expected O, but got I4
			//IL_050d: Expected O, but got I
			//IL_0543: Expected O, but got I4
			//IL_005f->IL0564: Incompatible stack heights: 1 vs 0
			//IL_01cd->IL0564: Incompatible stack heights: 1 vs 0
			//IL_01ef->IL0564: Incompatible stack heights: 1 vs 0
			//IL_022a->IL0564: Incompatible stack heights: 1 vs 0
			//IL_024c->IL0564: Incompatible stack heights: 1 vs 0
			//IL_0280->IL0564: Incompatible stack heights: 1 vs 0
			//IL_02bf->IL0564: Incompatible stack heights: 1 vs 0
			//IL_0651->IL0564: Incompatible stack heights: 1 vs 0
			//IL_03c3->IL0564: Incompatible stack heights: 1 vs 0
			//IL_03fe->IL0564: Incompatible stack heights: 1 vs 0
			//IL_0420->IL0564: Incompatible stack heights: 1 vs 0
			//IL_0454->IL0564: Incompatible stack heights: 1 vs 0
			GameObject gameObject2;
			float2 pos = default(float2);
			GameObject gameObject3;
			object obj4;
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
					TP_Spite1_Weapon tP_Spite1_Weapon = _003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						gameObject2 = (GameObject)(object)_003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Spite1_Weapon._targetTransform);
						if ((object)gameObject2 == null)
						{
							gameObject3 = null;
							goto IL_0603;
						}
						nint num = (nint)gameObject2;
						nint num2 = (nint)typeof(TP_Spite0_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ r8_v15 (Il2CppClass<UnityEngine.GameObject>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ r8_v15 (Il2CppClass<UnityEngine.GameObject>)+C8]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v60+FFFFFFF8+v588 @ rax_v56*8]");
							if (0 == (nint)typeof(TP_Spite0_Projectile))
							{
								obj4 = 1;
								goto IL_05dc;
							}
						}
						obj4 = 0;
						goto IL_05dc;
					}
				}
			}
			goto IL_0564;
			IL_0697:
			object obj5;
			bool flag2 = obj5 == null;
			GameObject item = null;
			Projectile projectile;
			if (!flag2)
			{
				item = (GameObject)(object)projectile;
			}
			goto IL_0678;
			IL_05dc:
			bool flag3 = obj4 == null;
			gameObject3 = null;
			if (!flag3)
			{
				gameObject3 = gameObject2;
			}
			goto IL_0603;
			IL_0678:
			List<TP_Spite1_Projectile> list;
			list.Add((TP_Spite1_Projectile)(object)item);
			((TP_Spite0_Projectile)(object)gameObject3).SetDamageBoxes(list);
			return;
			IL_0603:
			if ((object)gameObject3 == null || ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			list = new List<TP_Spite1_Projectile>();
			TP_Spite1_Weapon tP_Spite1_Weapon2 = _003C_003E4__this;
			Projectile projectile2;
			TP_Spite1_Projectile item2;
			object obj8;
			if ((object)_003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon2)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)tP_Spite1_Weapon2)._003COwner_003Ek__BackingField.position;
				TP_Spite1_Weapon tP_Spite1_Weapon3 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon3)._003COwner_003Ek__BackingField != null)
				{
					float2 position2 = ((Equipment)tP_Spite1_Weapon3)._003COwner_003Ek__BackingField.position;
					if (tP_Spite1_Weapon2._centralProjectilePool != null)
					{
						projectile2 = tP_Spite1_Weapon2._centralProjectilePool.SpawnAt(pos, _003C_003E4__this, localIndex);
						if (list != null)
						{
							if ((object)projectile2 == null)
							{
								item2 = null;
								goto IL_0620;
							}
							nint num4 = (nint)projectile2;
							nint num5 = (nint)typeof(TP_Spite1_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
							if (num6 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rax_v49+FFFFFFF8+v755 @ rax_v45*8]");
								if (0 == (nint)typeof(TP_Spite1_Projectile))
								{
									obj8 = 1;
									goto IL_0656;
								}
							}
							obj8 = 0;
							goto IL_0656;
						}
					}
				}
			}
			goto IL_0564;
			IL_0620:
			list.Add(item2);
			TP_Spite1_Weapon tP_Spite1_Weapon4 = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon4)._003COwner_003Ek__BackingField != null)
			{
				float2 position3 = ((Equipment)tP_Spite1_Weapon4)._003COwner_003Ek__BackingField.position;
				TP_Spite1_Weapon tP_Spite1_Weapon5 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon5)._003COwner_003Ek__BackingField != null)
				{
					float2 position4 = ((Equipment)tP_Spite1_Weapon5)._003COwner_003Ek__BackingField.position;
					if (tP_Spite1_Weapon4._centralProjectilePool != null)
					{
						int index = localIndex + 1;
						projectile = tP_Spite1_Weapon4._centralProjectilePool.SpawnAt(pos, _003C_003E4__this, index);
						bool flag4 = (object)projectile == null;
						item = null;
						if (flag4)
						{
							goto IL_0678;
						}
						nint num7 = (nint)projectile;
						nint num8 = (nint)typeof(TP_Spite1_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
						if (num9 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v43+FFFFFFF8+v853 @ rax_v39*8]");
							if (0 == (nint)typeof(TP_Spite1_Projectile))
							{
								obj5 = 1;
								goto IL_0697;
							}
						}
						obj5 = 0;
						goto IL_0697;
					}
				}
			}
			goto IL_0564;
			IL_0656:
			bool flag5 = obj8 == null;
			item2 = null;
			if (!flag5)
			{
				item2 = (TP_Spite1_Projectile)projectile2;
			}
			goto IL_0620;
			IL_0564:
			throw new NullReferenceException();
		}
	}

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private BulletPool _centralProjectilePool;

	private Projectile _centralProjectilePrefab;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public override float PSpeed()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		float num2 = default(float);
		bool flag = !(4f > num2);
		float num3 = 4f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num4 *= value;
			}
		}
		return num4;
	}

	protected override void Awake()
	{
		//IL_0076: Expected I, but got O
		//IL_0119: Expected I, but got O
		base.Awake();
		BulletPool centralProjectilePool = new BulletPool(_centralProjectilePrefab);
		_centralProjectilePool = centralProjectilePool;
		BulletPool centralProjectilePool2 = _centralProjectilePool;
		centralProjectilePool2.UpperLimit = 200;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Spite1_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_centralProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Spite1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_centralProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Invalid comparison between O and F4
		//IL_0087: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00df: Expected I, but got O
		//IL_00ed: Expected I, but got O
		//IL_00fd: Expected O, but got I
		//IL_017d: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		//IL_056c: Expected O, but got I4
		//IL_0139: Expected O, but got I
		//IL_016f: Expected O, but got I4
		//IL_024b: Expected I, but got O
		//IL_0259: Expected I, but got O
		//IL_0269: Expected O, but got I
		//IL_02e9: Expected O, but got I4
		//IL_02a5: Expected O, but got I
		//IL_02db: Expected O, but got I4
		//IL_0389: Expected I, but got O
		//IL_0397: Expected I, but got O
		//IL_03a7: Expected O, but got I
		//IL_0427: Expected O, but got I4
		//IL_03e3: Expected O, but got I
		//IL_0419: Expected O, but got I4
		float num = base.PAmount();
		float num2 = base.PDuration();
		float hitBoxDelay = base.HitBoxDelay;
		object obj = default(object);
		float num3 = (float)obj / hitBoxDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		if ((nint)obj <= 0)
		{
			return;
		}
		int num4 = 0;
		bool flag = false;
		bool flag2 = false;
		TP_Spite0_Projectile tP_Spite0_Projectile = default(TP_Spite0_Projectile);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		float2 pos2 = default(float2);
		do
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals23._003C_003E4__this = this;
			CS_0024_003C_003E8__locals23.__pos = pos;
			CS_0024_003C_003E8__locals23.localIndex = num4;
			WeaponData currentWeaponData = _currentWeaponData;
			object obj2 = flag * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			TP_Spite0_Projectile tP_Spite0_Projectile2;
			object obj5;
			if ((nint)obj2 <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if ((object)tP_Spite0_Projectile == null)
				{
					tP_Spite0_Projectile2 = (TP_Spite0_Projectile)flag2;
					goto IL_057f;
				}
				nint num5 = (nint)tP_Spite0_Projectile;
				nint num6 = (nint)typeof(TP_Spite0_Projectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rax_v62+FFFFFFF8+v633 @ rax_v58*8]");
					if (0 == (nint)typeof(TP_Spite0_Projectile))
					{
						obj5 = 1;
						goto IL_0555;
					}
				}
				obj5 = 0;
				goto IL_0555;
			}
			Action onComplete = delegate
			{
				//IL_05ba: Expected O, but got I4
				//IL_00b9: Expected I, but got O
				//IL_00c7: Expected I, but got O
				//IL_00d7: Expected O, but got I
				//IL_0157: Expected O, but got I4
				//IL_0113: Expected O, but got I
				//IL_0149: Expected O, but got I4
				//IL_02f6: Expected I, but got O
				//IL_0304: Expected I, but got O
				//IL_0314: Expected O, but got I
				//IL_0394: Expected O, but got I4
				//IL_0350: Expected O, but got I
				//IL_0386: Expected O, but got I4
				//IL_04b3: Expected I, but got O
				//IL_04c1: Expected I, but got O
				//IL_04d1: Expected O, but got I
				//IL_0551: Expected O, but got I4
				//IL_050d: Expected O, but got I
				//IL_0543: Expected O, but got I4
				//IL_005f->IL0564: Incompatible stack heights: 1 vs 0
				//IL_01cd->IL0564: Incompatible stack heights: 1 vs 0
				//IL_01ef->IL0564: Incompatible stack heights: 1 vs 0
				//IL_022a->IL0564: Incompatible stack heights: 1 vs 0
				//IL_024c->IL0564: Incompatible stack heights: 1 vs 0
				//IL_0280->IL0564: Incompatible stack heights: 1 vs 0
				//IL_02bf->IL0564: Incompatible stack heights: 1 vs 0
				//IL_0651->IL0564: Incompatible stack heights: 1 vs 0
				//IL_03c3->IL0564: Incompatible stack heights: 1 vs 0
				//IL_03fe->IL0564: Incompatible stack heights: 1 vs 0
				//IL_0420->IL0564: Incompatible stack heights: 1 vs 0
				//IL_0454->IL0564: Incompatible stack heights: 1 vs 0
				GameObject gameObject2;
				float2 pos3 = default(float2);
				object obj15;
				GameObject gameObject3;
				if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null)
				{
					GameObject gameObject = CS_0024_003C_003E8__locals23._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj12 == null)
						{
							return;
						}
						TP_Spite1_Weapon tP_Spite1_Weapon = CS_0024_003C_003E8__locals23._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null)
						{
							gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals23._003C_003E4__this.FireOneProjectile(pos3, CS_0024_003C_003E8__locals23.localIndex, tP_Spite1_Weapon._targetTransform);
							if ((object)gameObject2 != null)
							{
								nint num15 = (nint)gameObject2;
								nint num16 = (nint)typeof(TP_Spite0_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ r8_v15 (Il2CppClass<UnityEngine.GameObject>)+130]");
								nint num17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+130]");
								if (num17 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ r8_v15 (Il2CppClass<UnityEngine.GameObject>)+C8]");
									object obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v60+FFFFFFF8+v588 @ rax_v56*8]");
									if (0 == (nint)typeof(TP_Spite0_Projectile))
									{
										obj15 = 1;
										goto IL_05dc;
									}
								}
								obj15 = 0;
								goto IL_05dc;
							}
							gameObject3 = null;
							goto IL_0603;
						}
					}
				}
				goto IL_0564;
				IL_0697:
				object obj16;
				bool flag7 = obj16 == null;
				GameObject item3 = null;
				Projectile projectile3;
				if (!flag7)
				{
					item3 = (GameObject)(object)projectile3;
				}
				goto IL_0678;
				IL_05dc:
				bool flag8 = obj15 == null;
				gameObject3 = null;
				if (!flag8)
				{
					gameObject3 = gameObject2;
				}
				goto IL_0603;
				IL_0678:
				List<TP_Spite1_Projectile> list2;
				list2.Add((TP_Spite1_Projectile)(object)item3);
				((TP_Spite0_Projectile)(object)gameObject3).SetDamageBoxes(list2);
				return;
				IL_0603:
				if ((object)gameObject3 == null || ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				list2 = new List<TP_Spite1_Projectile>();
				TP_Spite1_Weapon tP_Spite1_Weapon2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
				Projectile projectile4;
				TP_Spite1_Projectile item4;
				object obj19;
				if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon2)._003COwner_003Ek__BackingField != null)
				{
					float2 position5 = ((Equipment)tP_Spite1_Weapon2)._003COwner_003Ek__BackingField.position;
					TP_Spite1_Weapon tP_Spite1_Weapon3 = CS_0024_003C_003E8__locals23._003C_003E4__this;
					if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon3)._003COwner_003Ek__BackingField != null)
					{
						float2 position6 = ((Equipment)tP_Spite1_Weapon3)._003COwner_003Ek__BackingField.position;
						if (tP_Spite1_Weapon2._centralProjectilePool != null)
						{
							projectile4 = tP_Spite1_Weapon2._centralProjectilePool.SpawnAt(pos3, CS_0024_003C_003E8__locals23._003C_003E4__this, CS_0024_003C_003E8__locals23.localIndex);
							if (list2 != null)
							{
								if ((object)projectile4 == null)
								{
									item4 = null;
									goto IL_0620;
								}
								nint num18 = (nint)projectile4;
								nint num19 = (nint)typeof(TP_Spite1_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
								object obj17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num20 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
								if (num20 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rax_v49+FFFFFFF8+v755 @ rax_v45*8]");
									if (0 == (nint)typeof(TP_Spite1_Projectile))
									{
										obj19 = 1;
										goto IL_0656;
									}
								}
								obj19 = 0;
								goto IL_0656;
							}
						}
					}
				}
				goto IL_0564;
				IL_0620:
				list2.Add(item4);
				TP_Spite1_Weapon tP_Spite1_Weapon4 = CS_0024_003C_003E8__locals23._003C_003E4__this;
				if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon4)._003COwner_003Ek__BackingField != null)
				{
					float2 position7 = ((Equipment)tP_Spite1_Weapon4)._003COwner_003Ek__BackingField.position;
					TP_Spite1_Weapon tP_Spite1_Weapon5 = CS_0024_003C_003E8__locals23._003C_003E4__this;
					if ((object)CS_0024_003C_003E8__locals23._003C_003E4__this != null && (object)((Equipment)tP_Spite1_Weapon5)._003COwner_003Ek__BackingField != null)
					{
						float2 position8 = ((Equipment)tP_Spite1_Weapon5)._003COwner_003Ek__BackingField.position;
						if (tP_Spite1_Weapon4._centralProjectilePool != null)
						{
							int index2 = CS_0024_003C_003E8__locals23.localIndex + 1;
							projectile3 = tP_Spite1_Weapon4._centralProjectilePool.SpawnAt(pos3, CS_0024_003C_003E8__locals23._003C_003E4__this, index2);
							bool flag9 = (object)projectile3 == null;
							item3 = null;
							if (flag9)
							{
								goto IL_0678;
							}
							nint num21 = (nint)projectile3;
							nint num22 = (nint)typeof(TP_Spite1_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
							object obj20 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
							if (num23 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj21 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v43+FFFFFFF8+v853 @ rax_v39*8]");
								if (0 == (nint)typeof(TP_Spite1_Projectile))
								{
									obj16 = 1;
									goto IL_0697;
								}
							}
							obj16 = 0;
							goto IL_0697;
						}
					}
				}
				goto IL_0564;
				IL_0656:
				bool flag10 = obj19 == null;
				item4 = null;
				if (!flag10)
				{
					item4 = (TP_Spite1_Projectile)projectile4;
				}
				goto IL_0620;
				IL_0564:
				throw new NullReferenceException();
			};
			float num8 = (float)(flag ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float duration = num8 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag2);
			_lastShotTimer = lastShotTimer;
			goto IL_04c0;
			IL_05d0:
			List<TP_Spite1_Projectile> list;
			TP_Spite1_Projectile item;
			list.Add(item);
			tP_Spite0_Projectile2.SetDamageBoxes(list);
			goto IL_04c0;
			IL_04c0:
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			num4 += 2;
			continue;
			IL_05ae:
			object obj6;
			bool flag3 = obj6 == null;
			TP_Spite1_Projectile item2 = null;
			Projectile projectile;
			if (!flag3)
			{
				item2 = (TP_Spite1_Projectile)projectile;
			}
			goto IL_059c;
			IL_059c:
			list.Add(item2);
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			int index = CS_0024_003C_003E8__locals23.localIndex + 1;
			Projectile projectile2 = _centralProjectilePool.SpawnAt(pos2, this, index);
			if ((object)projectile2 == null)
			{
				item = null;
				flag2 = false;
				goto IL_05d0;
			}
			nint num9 = (nint)projectile2;
			nint num10 = (nint)typeof(TP_Spite1_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v990 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
			object obj9;
			if (num11 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v990 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1029 @ rax_v45+FFFFFFF8+v992 @ rax_v41*8]");
				if (0 == (nint)typeof(TP_Spite1_Projectile))
				{
					obj9 = 1;
					goto IL_05ef;
				}
			}
			obj9 = 0;
			goto IL_05ef;
			IL_05ef:
			bool flag4 = obj9 == null;
			item = null;
			flag2 = false;
			if (!flag4)
			{
				item = (TP_Spite1_Projectile)projectile2;
				flag2 = false;
			}
			goto IL_05d0;
			IL_057f:
			if ((object)tP_Spite0_Projectile2 == null || ((UnityEngine.Object)tP_Spite0_Projectile2).m_CachedPtr == (IntPtr)0)
			{
				goto IL_04c0;
			}
			list = new List<TP_Spite1_Projectile>();
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			projectile = _centralProjectilePool.SpawnAt(pos2, this, CS_0024_003C_003E8__locals23.localIndex);
			if ((object)projectile == null)
			{
				item2 = null;
				goto IL_059c;
			}
			nint num12 = (nint)projectile;
			nint num13 = (nint)typeof(TP_Spite1_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
			if (num14 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v933 @ rax_v51+FFFFFFF8+v891 @ rax_v47*8]");
				if (0 == (nint)typeof(TP_Spite1_Projectile))
				{
					obj6 = 1;
					goto IL_05ae;
				}
			}
			obj6 = 0;
			goto IL_05ae;
			IL_0555:
			bool flag5 = obj5 == null;
			tP_Spite0_Projectile2 = (TP_Spite0_Projectile)flag2;
			if (!flag5)
			{
				tP_Spite0_Projectile2 = tP_Spite0_Projectile;
			}
			goto IL_057f;
		}
		while ((nint)obj > (flag ? 1 : 0));
	}
}
