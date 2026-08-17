using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
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

public class TP_Spite2_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public TP_Spite2_Weapon _003C_003E4__this;

		public int j;
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_07ab: Expected O, but got I4
			//IL_0110: Expected I, but got O
			//IL_011e: Expected I, but got O
			//IL_012e: Expected O, but got I
			//IL_01ae: Expected O, but got I4
			//IL_016a: Expected O, but got I
			//IL_01a0: Expected O, but got I4
			//IL_043c: Expected I, but got O
			//IL_044a: Expected I, but got O
			//IL_045a: Expected O, but got I
			//IL_04da: Expected O, but got I4
			//IL_0496: Expected O, but got I
			//IL_04cc: Expected O, but got I4
			//IL_069a: Expected I, but got O
			//IL_06a8: Expected I, but got O
			//IL_06b8: Expected O, but got I
			//IL_0738: Expected O, but got I4
			//IL_06f4: Expected O, but got I
			//IL_072a: Expected O, but got I4
			//IL_0084->IL074b: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0215->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0272->IL074b: Incompatible stack heights: 1 vs 0
			//IL_02a1->IL074b: Incompatible stack heights: 1 vs 0
			//IL_02da->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0315->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0344->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0366->IL074b: Incompatible stack heights: 1 vs 0
			//IL_03a1->IL074b: Incompatible stack heights: 1 vs 0
			//IL_03c3->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0405->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0842->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0516->IL074b: Incompatible stack heights: 1 vs 0
			//IL_054f->IL074b: Incompatible stack heights: 1 vs 0
			//IL_058a->IL074b: Incompatible stack heights: 1 vs 0
			//IL_05b9->IL074b: Incompatible stack heights: 1 vs 0
			//IL_05db->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0616->IL074b: Incompatible stack heights: 1 vs 0
			//IL_0638->IL074b: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			TP_Spite2_Projectile tP_Spite2_Projectile;
			float2 pos = default(float2);
			TP_Spite2_Projectile tP_Spite2_Projectile2;
			object obj6;
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
					_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Spite2_Weapon tP_Spite2_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							tP_Spite2_Projectile = (TP_Spite2_Projectile)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Spite2_Weapon._targetTransform);
							if ((object)tP_Spite2_Projectile == null)
							{
								tP_Spite2_Projectile2 = null;
								goto IL_07f4;
							}
							nint num = (nint)tP_Spite2_Projectile;
							nint num2 = (nint)typeof(TP_Spite2_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+C8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rax_v70+FFFFFFF8+v697 @ rax_v66*8]");
								if (0 == (nint)typeof(TP_Spite2_Projectile))
								{
									obj6 = 1;
									goto IL_07cd;
								}
							}
							obj6 = 0;
							goto IL_07cd;
						}
					}
				}
			}
			goto IL_074b;
			IL_0847:
			object obj7;
			bool flag2 = obj7 == null;
			TP_Spite1_Projectile item = null;
			Projectile projectile;
			if (!flag2)
			{
				item = (TP_Spite1_Projectile)projectile;
			}
			goto IL_0811;
			IL_074b:
			throw new NullReferenceException();
			IL_0888:
			object obj8;
			bool flag3 = obj8 == null;
			TP_Spite1_Projectile item2 = null;
			Projectile projectile2;
			if (!flag3)
			{
				item2 = (TP_Spite1_Projectile)projectile2;
			}
			goto IL_0869;
			IL_07cd:
			bool flag4 = obj6 == null;
			tP_Spite2_Projectile2 = null;
			if (!flag4)
			{
				tP_Spite2_Projectile2 = tP_Spite2_Projectile;
			}
			goto IL_07f4;
			IL_0869:
			List<TP_Spite1_Projectile> list;
			list.Add(item2);
			tP_Spite2_Projectile2.SetDamageBoxes(list);
			return;
			IL_07f4:
			if ((object)tP_Spite2_Projectile2 == null || ((UnityEngine.Object)tP_Spite2_Projectile2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			_003C_003Ec__DisplayClass17_0 obj9 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				if (obj9.j <= 0)
				{
					return;
				}
				list = new List<TP_Spite1_Projectile>();
				_003C_003Ec__DisplayClass17_0 obj10 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					TP_Spite2_Weapon tP_Spite2_Weapon2 = obj10._003C_003E4__this;
					if ((object)obj10._003C_003E4__this != null)
					{
						_003C_003Ec__DisplayClass17_0 obj11 = CS_0024_003C_003E8__locals1;
						TP_Spite2_Weapon tP_Spite2_Weapon3 = obj11._003C_003E4__this;
						if ((object)((Equipment)tP_Spite2_Weapon3)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)tP_Spite2_Weapon3)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass17_0 obj12 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_Spite2_Weapon tP_Spite2_Weapon4 = obj12._003C_003E4__this;
								if ((object)obj12._003C_003E4__this != null && (object)((Equipment)tP_Spite2_Weapon4)._003COwner_003Ek__BackingField != null)
								{
									float2 position2 = ((Equipment)tP_Spite2_Weapon4)._003COwner_003Ek__BackingField.position;
									_003C_003Ec__DisplayClass17_0 obj13 = CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals1 != null && tP_Spite2_Weapon2._centralProjectilePool != null)
									{
										projectile = tP_Spite2_Weapon2._centralProjectilePool.SpawnAt(pos, obj13._003C_003E4__this, localIndex);
										if (list != null)
										{
											if ((object)projectile == null)
											{
												item = null;
												goto IL_0811;
											}
											nint num4 = (nint)projectile;
											nint num5 = (nint)typeof(TP_Spite1_Projectile);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
											object obj14 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
											if (num6 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
												object obj15 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v59+FFFFFFF8+v868 @ rax_v55*8]");
												if (0 == (nint)typeof(TP_Spite1_Projectile))
												{
													obj7 = 1;
													goto IL_0847;
												}
											}
											obj7 = 0;
											goto IL_0847;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_074b;
			IL_0811:
			list.Add(item);
			_003C_003Ec__DisplayClass17_0 obj16 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Spite2_Weapon tP_Spite2_Weapon5 = obj16._003C_003E4__this;
				if ((object)obj16._003C_003E4__this != null)
				{
					_003C_003Ec__DisplayClass17_0 obj17 = CS_0024_003C_003E8__locals1;
					TP_Spite2_Weapon tP_Spite2_Weapon6 = obj17._003C_003E4__this;
					if ((object)((Equipment)tP_Spite2_Weapon6)._003COwner_003Ek__BackingField != null)
					{
						float2 position3 = ((Equipment)tP_Spite2_Weapon6)._003COwner_003Ek__BackingField.position;
						_003C_003Ec__DisplayClass17_0 obj18 = CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							TP_Spite2_Weapon tP_Spite2_Weapon7 = obj18._003C_003E4__this;
							if ((object)obj18._003C_003E4__this != null && (object)((Equipment)tP_Spite2_Weapon7)._003COwner_003Ek__BackingField != null)
							{
								float2 position4 = ((Equipment)tP_Spite2_Weapon7)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass17_0 obj19 = CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals1 != null && tP_Spite2_Weapon5._centralProjectilePool != null)
								{
									int index = localIndex + 1;
									projectile2 = tP_Spite2_Weapon5._centralProjectilePool.SpawnAt(pos, obj19._003C_003E4__this, index);
									bool flag5 = (object)projectile2 == null;
									item2 = null;
									if (flag5)
									{
										goto IL_0869;
									}
									nint num7 = (nint)projectile2;
									nint num8 = (nint)typeof(TP_Spite1_Projectile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
									object obj20 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
									if (num9 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
										object obj21 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1004 @ rax_v53+FFFFFFF8+v968 @ rax_v49*8]");
										if (0 == (nint)typeof(TP_Spite1_Projectile))
										{
											obj8 = 1;
											goto IL_0888;
										}
									}
									obj8 = 0;
									goto IL_0888;
								}
							}
						}
					}
				}
			}
			goto IL_074b;
		}
	}

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private BulletPool _centralProjectilePool;

	private Projectile _centralProjectilePrefab;

	private float _hahaSfxCounter;

	private float _hahaSfxThreshold;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public override float PPower()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				float num = (float)config._003CRunEnemies_003Ek__BackingField / 5000f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
				float num2 = num;
				if (!flag)
				{
					num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
						float num3 = num * 0.1f;
						float num4 = num3 + currentWeaponData._003Cpower_003Ek__BackingField;
						float num5 = num4 * num2;
						return num2 + num5;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Spite2_Weapon>)+350]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Spite2_Weapon>)+3A0]");
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0062: Invalid comparison between O and F4
		//IL_008d: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		PlayFiringSfx();
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_012a: Expected I, but got O
		//IL_0138: Expected I, but got O
		//IL_0148: Expected O, but got I
		//IL_01c8: Expected O, but got I4
		//IL_0184: Expected O, but got I
		//IL_01ba: Expected O, but got I4
		//IL_02cd: Expected I, but got O
		//IL_02db: Expected I, but got O
		//IL_02eb: Expected O, but got I
		//IL_036b: Expected O, but got I4
		//IL_0327: Expected O, but got I
		//IL_035d: Expected O, but got I4
		//IL_0402: Expected I, but got O
		//IL_0410: Expected I, but got O
		//IL_0420: Expected O, but got I
		//IL_04a0: Expected O, but got I4
		//IL_045c: Expected O, but got I
		//IL_0492: Expected O, but got I4
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj._003C_003E4__this = this;
		float num = base.PAmount();
		obj.j = 0;
		object obj2 = default(object);
		TP_Spite2_Projectile tP_Spite2_Projectile = default(TP_Spite2_Projectile);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		float2 pos2 = default(float2);
		while ((nint)obj2 > obj.j)
		{
			_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals31 = new _003C_003Ec__DisplayClass17_1();
			CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 = obj;
			_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
			CS_0024_003C_003E8__locals31.__pos = pos;
			int localIndex = obj3.j + obj3.j;
			CS_0024_003C_003E8__locals31.localIndex = localIndex;
			WeaponData currentWeaponData = _currentWeaponData;
			_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
			object obj5 = obj4.j * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			TP_Spite2_Projectile tP_Spite2_Projectile2;
			object obj8;
			if ((nint)obj5 <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if ((object)tP_Spite2_Projectile == null)
				{
					tP_Spite2_Projectile2 = null;
					goto IL_0599;
				}
				nint num2 = (nint)tP_Spite2_Projectile;
				nint num3 = (nint)typeof(TP_Spite2_Projectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+C8]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v60+FFFFFFF8+v703 @ rax_v56*8]");
					if (0 == (nint)typeof(TP_Spite2_Projectile))
					{
						obj8 = 1;
						goto IL_0572;
					}
				}
				obj8 = 0;
				goto IL_0572;
			}
			Action onComplete = delegate
			{
				//IL_07ab: Expected O, but got I4
				//IL_0110: Expected I, but got O
				//IL_011e: Expected I, but got O
				//IL_012e: Expected O, but got I
				//IL_01ae: Expected O, but got I4
				//IL_016a: Expected O, but got I
				//IL_01a0: Expected O, but got I4
				//IL_043c: Expected I, but got O
				//IL_044a: Expected I, but got O
				//IL_045a: Expected O, but got I
				//IL_04da: Expected O, but got I4
				//IL_0496: Expected O, but got I
				//IL_04cc: Expected O, but got I4
				//IL_069a: Expected I, but got O
				//IL_06a8: Expected I, but got O
				//IL_06b8: Expected O, but got I
				//IL_0738: Expected O, but got I4
				//IL_06f4: Expected O, but got I
				//IL_072a: Expected O, but got I4
				//IL_0084->IL074b: Incompatible stack heights: 1 vs 0
				//IL_00b3->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0215->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0272->IL074b: Incompatible stack heights: 1 vs 0
				//IL_02a1->IL074b: Incompatible stack heights: 1 vs 0
				//IL_02da->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0315->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0344->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0366->IL074b: Incompatible stack heights: 1 vs 0
				//IL_03a1->IL074b: Incompatible stack heights: 1 vs 0
				//IL_03c3->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0405->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0842->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0516->IL074b: Incompatible stack heights: 1 vs 0
				//IL_054f->IL074b: Incompatible stack heights: 1 vs 0
				//IL_058a->IL074b: Incompatible stack heights: 1 vs 0
				//IL_05b9->IL074b: Incompatible stack heights: 1 vs 0
				//IL_05db->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0616->IL074b: Incompatible stack heights: 1 vs 0
				//IL_0638->IL074b: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass17_0 obj16 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
				TP_Spite2_Projectile tP_Spite2_Projectile3;
				float2 pos3 = default(float2);
				object obj21;
				TP_Spite2_Projectile tP_Spite2_Projectile4;
				if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null && (object)obj16._003C_003E4__this != null)
				{
					GameObject gameObject = obj16._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj17 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj17 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass17_0 obj18 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Spite2_Weapon tP_Spite2_Weapon = obj18._003C_003E4__this;
							if ((object)obj18._003C_003E4__this != null)
							{
								tP_Spite2_Projectile3 = (TP_Spite2_Projectile)obj18._003C_003E4__this.FireOneProjectile(pos3, CS_0024_003C_003E8__locals31.localIndex, tP_Spite2_Weapon._targetTransform);
								if ((object)tP_Spite2_Projectile3 != null)
								{
									nint num12 = (nint)tP_Spite2_Projectile3;
									nint num13 = (nint)typeof(TP_Spite2_Projectile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
									object obj19 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
									nint num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+130]");
									if (num14 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+C8]");
										object obj20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rax_v70+FFFFFFF8+v697 @ rax_v66*8]");
										if (0 == (nint)typeof(TP_Spite2_Projectile))
										{
											obj21 = 1;
											goto IL_07cd;
										}
									}
									obj21 = 0;
									goto IL_07cd;
								}
								tP_Spite2_Projectile4 = null;
								goto IL_07f4;
							}
						}
					}
				}
				goto IL_074b;
				IL_0847:
				object obj22;
				bool flag5 = obj22 == null;
				TP_Spite1_Projectile item3 = null;
				Projectile projectile3;
				if (!flag5)
				{
					item3 = (TP_Spite1_Projectile)projectile3;
				}
				goto IL_0811;
				IL_074b:
				throw new NullReferenceException();
				IL_0888:
				object obj23;
				bool flag6 = obj23 == null;
				TP_Spite1_Projectile item4 = null;
				Projectile projectile4;
				if (!flag6)
				{
					item4 = (TP_Spite1_Projectile)projectile4;
				}
				goto IL_0869;
				IL_07cd:
				bool flag7 = obj21 == null;
				tP_Spite2_Projectile4 = null;
				if (!flag7)
				{
					tP_Spite2_Projectile4 = tP_Spite2_Projectile3;
				}
				goto IL_07f4;
				IL_0869:
				List<TP_Spite1_Projectile> list2;
				list2.Add(item4);
				tP_Spite2_Projectile4.SetDamageBoxes(list2);
				return;
				IL_07f4:
				if ((object)tP_Spite2_Projectile4 == null || ((UnityEngine.Object)tP_Spite2_Projectile4).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				_003C_003Ec__DisplayClass17_0 obj24 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
				{
					if (obj24.j <= 0)
					{
						return;
					}
					list2 = new List<TP_Spite1_Projectile>();
					_003C_003Ec__DisplayClass17_0 obj25 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
					{
						TP_Spite2_Weapon tP_Spite2_Weapon2 = obj25._003C_003E4__this;
						if ((object)obj25._003C_003E4__this != null)
						{
							_003C_003Ec__DisplayClass17_0 obj26 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
							TP_Spite2_Weapon tP_Spite2_Weapon3 = obj26._003C_003E4__this;
							if ((object)((Equipment)tP_Spite2_Weapon3)._003COwner_003Ek__BackingField != null)
							{
								float2 position5 = ((Equipment)tP_Spite2_Weapon3)._003COwner_003Ek__BackingField.position;
								_003C_003Ec__DisplayClass17_0 obj27 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Spite2_Weapon tP_Spite2_Weapon4 = obj27._003C_003E4__this;
									if ((object)obj27._003C_003E4__this != null && (object)((Equipment)tP_Spite2_Weapon4)._003COwner_003Ek__BackingField != null)
									{
										float2 position6 = ((Equipment)tP_Spite2_Weapon4)._003COwner_003Ek__BackingField.position;
										_003C_003Ec__DisplayClass17_0 obj28 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null && tP_Spite2_Weapon2._centralProjectilePool != null)
										{
											projectile3 = tP_Spite2_Weapon2._centralProjectilePool.SpawnAt(pos3, obj28._003C_003E4__this, CS_0024_003C_003E8__locals31.localIndex);
											if (list2 != null)
											{
												if ((object)projectile3 == null)
												{
													item3 = null;
													goto IL_0811;
												}
												nint num15 = (nint)projectile3;
												nint num16 = (nint)typeof(TP_Spite1_Projectile);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
												object obj29 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
												nint num17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
												if (num17 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
													object obj30 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rax_v59+FFFFFFF8+v868 @ rax_v55*8]");
													if (0 == (nint)typeof(TP_Spite1_Projectile))
													{
														obj22 = 1;
														goto IL_0847;
													}
												}
												obj22 = 0;
												goto IL_0847;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_074b;
				IL_0811:
				list2.Add(item3);
				_003C_003Ec__DisplayClass17_0 obj31 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
				{
					TP_Spite2_Weapon tP_Spite2_Weapon5 = obj31._003C_003E4__this;
					if ((object)obj31._003C_003E4__this != null)
					{
						_003C_003Ec__DisplayClass17_0 obj32 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
						TP_Spite2_Weapon tP_Spite2_Weapon6 = obj32._003C_003E4__this;
						if ((object)((Equipment)tP_Spite2_Weapon6)._003COwner_003Ek__BackingField != null)
						{
							float2 position7 = ((Equipment)tP_Spite2_Weapon6)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass17_0 obj33 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Spite2_Weapon tP_Spite2_Weapon7 = obj33._003C_003E4__this;
								if ((object)obj33._003C_003E4__this != null && (object)((Equipment)tP_Spite2_Weapon7)._003COwner_003Ek__BackingField != null)
								{
									float2 position8 = ((Equipment)tP_Spite2_Weapon7)._003COwner_003Ek__BackingField.position;
									_003C_003Ec__DisplayClass17_0 obj34 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1 != null && tP_Spite2_Weapon5._centralProjectilePool != null)
									{
										int index2 = CS_0024_003C_003E8__locals31.localIndex + 1;
										projectile4 = tP_Spite2_Weapon5._centralProjectilePool.SpawnAt(pos3, obj34._003C_003E4__this, index2);
										bool flag8 = (object)projectile4 == null;
										item4 = null;
										if (flag8)
										{
											goto IL_0869;
										}
										nint num18 = (nint)projectile4;
										nint num19 = (nint)typeof(TP_Spite1_Projectile);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
										object obj35 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
										nint num20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
										if (num20 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
											object obj36 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1004 @ rax_v53+FFFFFFF8+v968 @ rax_v49*8]");
											if (0 == (nint)typeof(TP_Spite1_Projectile))
											{
												obj23 = 1;
												goto IL_0888;
											}
										}
										obj23 = 0;
										goto IL_0888;
									}
								}
							}
						}
					}
				}
				goto IL_074b;
			};
			float num5 = (float)obj4.j * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float duration = num5 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			goto IL_0539;
			IL_0572:
			bool flag = obj8 == null;
			tP_Spite2_Projectile2 = null;
			if (!flag)
			{
				tP_Spite2_Projectile2 = tP_Spite2_Projectile;
			}
			goto IL_0599;
			IL_0629:
			object obj9;
			bool flag2 = obj9 == null;
			TP_Spite1_Projectile item = null;
			Projectile projectile;
			if (!flag2)
			{
				item = (TP_Spite1_Projectile)projectile;
			}
			goto IL_05ea;
			IL_05ea:
			List<TP_Spite1_Projectile> list;
			list.Add(item);
			tP_Spite2_Projectile2.SetDamageBoxes(list);
			int j = obj.j + 1;
			obj.j = j;
			continue;
			IL_0539:
			int j2 = obj.j + 1;
			obj.j = j2;
			continue;
			IL_0599:
			Projectile projectile2;
			TP_Spite1_Projectile item2;
			object obj13;
			if ((object)tP_Spite2_Projectile2 != null && ((UnityEngine.Object)tP_Spite2_Projectile2).m_CachedPtr != (IntPtr)0)
			{
				_003C_003Ec__DisplayClass17_0 obj10 = CS_0024_003C_003E8__locals31.CS_0024_003C_003E8__locals1;
				if (obj10.j > 0)
				{
					list = new List<TP_Spite1_Projectile>();
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					projectile2 = _centralProjectilePool.SpawnAt(pos2, this, CS_0024_003C_003E8__locals31.localIndex);
					if ((object)projectile2 == null)
					{
						item2 = null;
						goto IL_05b6;
					}
					nint num6 = (nint)projectile2;
					nint num7 = (nint)typeof(TP_Spite1_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
					if (num8 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ rax_v49+FFFFFFF8+v937 @ rax_v45*8]");
						if (0 == (nint)typeof(TP_Spite1_Projectile))
						{
							obj13 = 1;
							goto IL_05c8;
						}
					}
					obj13 = 0;
					goto IL_05c8;
				}
			}
			goto IL_0539;
			IL_05b6:
			list.Add(item2);
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			int index = CS_0024_003C_003E8__locals31.localIndex + 1;
			projectile = _centralProjectilePool.SpawnAt(pos2, this, index);
			if ((object)projectile == null)
			{
				item = null;
				goto IL_05ea;
			}
			nint num9 = (nint)projectile;
			nint num10 = (nint)typeof(TP_Spite1_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1036 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1035 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1036 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite1_Projectile>)+130]");
			if (num11 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1035 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ rax_v43+FFFFFFF8+v1037 @ rax_v39*8]");
				if (0 == (nint)typeof(TP_Spite1_Projectile))
				{
					obj9 = 1;
					goto IL_0629;
				}
			}
			obj9 = 0;
			goto IL_0629;
			IL_05c8:
			bool flag3 = obj13 == null;
			item2 = null;
			if (!flag3)
			{
				item2 = (TP_Spite1_Projectile)projectile2;
			}
			goto IL_05b6;
		}
	}

	private void PlayFiringSfx()
	{
		//IL_020d: Expected O, but got F4
		//IL_0033: Expected F4, but got I4
		//IL_0065: Expected F4, but got I4
		//IL_009c: Expected F4, but got I4
		//IL_00b5: Invalid comparison between F4 and I4
		//IL_01d3: Expected F4, but got I4
		//IL_0104: Expected F4, but got I4
		//IL_0136: Expected F4, but got I4
		//IL_016d: Expected F4, but got I4
		//IL_01f5: Expected F4, but got I4
		object obj = UnityEngine.Random.value;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Acerbatus, 200f, 3, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Nightmare, 200f, 3, 0f, volume, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Nightmare2, 200f, 3, 0f, volume, rate, detune, loop, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874750A0h\"");
		if (_hahaSfxThreshold == 0f)
		{
			float hahaSfxThreshold = UnityEngine.Random.RandomRangeInt(5, 9);
			_hahaSfxThreshold = hahaSfxThreshold;
		}
		if (!(++_hahaSfxCounter < _hahaSfxThreshold))
		{
			PlaySoundResult playSoundResult4 = SoundManager.PlaySoundNonAlloc(SfxType.Haha, 200f, 3, 0f, volume, rate, detune, loop, 1f);
			PlaySoundResult playSoundResult5 = SoundManager.PlaySoundNonAlloc(SfxType.Haha, 200f, 3, 0f, volume, rate, detune, loop, 1f);
			PlaySoundResult playSoundResult6 = SoundManager.PlaySoundNonAlloc(SfxType.Haha, 200f, 3, 0f, volume, rate, detune, loop, 1f);
			_hahaSfxCounter = 0f;
			float hahaSfxThreshold2 = UnityEngine.Random.RandomRangeInt(5, 9);
			_hahaSfxThreshold = hahaSfxThreshold2;
		}
	}
}
