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

public class TP_SpriteWhip_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int localIndex;

		public bool localShoot;

		public TP_SpriteWhip_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_0201: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0171: Expected O, but got I
			//IL_0079->IL01ca: Incompatible stack heights: 1 vs 0
			//IL_009e->IL01ca: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL01ca: Incompatible stack heights: 1 vs 0
			//IL_0136->IL01ca: Incompatible stack heights: 1 vs 0
			//IL_015b->IL01ca: Incompatible stack heights: 1 vs 0
			//IL_0199->IL01ca: Incompatible stack heights: 1 vs 0
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
							TP_SpriteWhip_Weapon tP_SpriteWhip_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								if (!localShoot)
								{
									return;
								}
								GameObject gameObject3 = (GameObject)(object)_003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
										float2 position2 = ((ArcadeSprite)0).position;
										TP_SpriteWhip_Weapon tP_SpriteWhip_Weapon2 = _003C_003E4__this;
										if ((object)_003C_003E4__this != null)
										{
											Vector2 pos = default(Vector2);
											BulletPool pool = default(BulletPool);
											Projectile projectile = _003C_003E4__this.FireFireballProjectile(pos, localIndex, tP_SpriteWhip_Weapon2._targetTransform, pool);
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

	private Projectile _fireballPrefab;

	private BulletPool _fireballPool;

	private Projectile _explosionPrefab;

	private BulletPool _explosionPool;

	private List<float> _fireBallAngles;

	private List<float> _fireBallAnglesFlipped;

	public int _activationsCount;

	public int _specialCounter;

	private float BossBonus;

	public virtual bool ShootFireballs => false;

	public override float PPower()
	{
		float num = base.PPower();
		return num + BossBonus;
	}

	public void CalculateBossBonus()
	{
		//IL_0054: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CRunBossesCount_003Ek__BackingField > 10)
		{
			object obj = config._003CRunBossesCount_003Ek__BackingField + -10;
			float num = (float)obj * 0.1f;
			float bossBonus = num + 2f;
			BossBonus = bossBonus;
		}
		else
		{
			float bossBonus2 = (float)config._003CRunBossesCount_003Ek__BackingField * 0.2f;
			BossBonus = bossBonus2;
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected override void OnStart()
	{
		//IL_00c6: Expected I, but got O
		//IL_0284: Expected I, but got O
		//IL_0169: Expected I, but got O
		//IL_0327: Expected I, but got O
		base.OnStart();
		if (_fireballPool != null)
		{
			goto IL_01a1;
		}
		BulletPool fireballPool = new BulletPool(_fireballPrefab);
		_fireballPool = fireballPool;
		BulletPool fireballPool2 = _fireballPool;
		fireballPool2.UpperLimit = 100;
		BulletPool fireballPool3 = _fireballPool;
		fireballPool3.IsUncapped = true;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_fireballPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_fireballPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_01a1;
			}
		}
		goto IL_0360;
		IL_0360:
		throw new NullReferenceException();
		IL_01a1:
		if (_explosionPool != null)
		{
			return;
		}
		BulletPool explosionPool = new BulletPool(_explosionPrefab);
		_explosionPool = explosionPool;
		BulletPool explosionPool2 = _explosionPool;
		explosionPool2.UpperLimit = 100;
		BulletPool explosionPool3 = _explosionPool;
		explosionPool3.IsUncapped = true;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_explosionPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_explosionPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0360;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0402: Expected I, but got O
		//IL_0054: Expected O, but got I4
		//IL_0181: Invalid comparison between O and F4
		//IL_0192: Expected F4, but got O
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_03b1: Invalid comparison between O and F4
		//IL_01b3: Invalid comparison between O and F4
		//IL_01c4: Expected F4, but got O
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_023b: Expected F4, but got O
		//IL_032c: Expected I4, but got O
		//IL_0364: Invalid comparison between F4 and I4
		//IL_027c: Expected F4, but got O
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float bossBonus;
		if (config._003CRunBossesCount_003Ek__BackingField > 10)
		{
			object obj = config._003CRunBossesCount_003Ek__BackingField + -10;
			float num = (float)obj * 0.1f;
			bossBonus = num + 2f;
		}
		else
		{
			bossBonus = (float)config._003CRunBossesCount_003Ek__BackingField * 0.2f;
		}
		nint num2 = (nint)this;
		int activationsCount = _activationsCount + 1;
		_activationsCount = activationsCount;
		BossBonus = bossBonus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+5C0]");
		int num3 = 0;
		bool shootFireballs = ShootFireballs;
		bool flag = !shootFireballs;
		bool flag2 = false;
		if (!flag)
		{
			num3 = _activationsCount % _specialCounter;
			bool flag3 = num3 != 0;
			flag2 = false;
			if (!flag3)
			{
				flag2 = true;
			}
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		bool flag4 = !flag2;
		object obj3 = default(object);
		object obj2 = obj3;
		Vector2 vector2 = vector;
		BulletPool bulletPool = default(BulletPool);
		if (!flag4)
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile2 = FireFireballProjectile(vector, 0, _targetTransform, bulletPool);
			obj2 = obj3;
			vector2 = vector;
		}
		float num4 = base.PAmount();
		bool flag5 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num5 = (float)vector2;
		if (!flag5)
		{
			float num6 = base.PAmount();
			bool flag6 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num5 = (float)vector2;
			if (!flag6)
			{
				int num7 = 1;
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj4 = num7 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj4 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						bool flag7 = !flag2;
						num5 = (float)playerPos;
						if (!flag7)
						{
							Vector2 playerPos2 = base.PlayerPos;
							Projectile projectile3 = FireFireballProjectile(playerPos2, num7, _targetTransform, bulletPool);
							num5 = (float)playerPos;
						}
					}
					else
					{
						_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass15_0();
						CS_0024_003C_003E8__locals16._003C_003E4__this = this;
						CS_0024_003C_003E8__locals16.localIndex = num7;
						CS_0024_003C_003E8__locals16.localShoot = flag2;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_0201: Expected O, but got I4
							//IL_00b4: Expected O, but got I
							//IL_00e9: Expected I, but got O
							//IL_0171: Expected O, but got I
							//IL_0079->IL01ca: Incompatible stack heights: 1 vs 0
							//IL_009e->IL01ca: Incompatible stack heights: 1 vs 0
							//IL_00dc->IL01ca: Incompatible stack heights: 1 vs 0
							//IL_0136->IL01ca: Incompatible stack heights: 1 vs 0
							//IL_015b->IL01ca: Incompatible stack heights: 1 vs 0
							//IL_0199->IL01ca: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals16._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals16._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj6 == null)
									{
										return;
									}
									GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals16._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals16._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (UnityEngine.GameObject)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v7 (UnityEngine.GameObject)+58]");
											float2 position3 = ((ArcadeSprite)0).position;
											TP_SpriteWhip_Weapon tP_SpriteWhip_Weapon = CS_0024_003C_003E8__locals16._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals16._003C_003E4__this != null)
											{
												nint num13 = (nint)gameObject2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
												if (!CS_0024_003C_003E8__locals16.localShoot)
												{
													return;
												}
												GameObject gameObject3 = (GameObject)(object)CS_0024_003C_003E8__locals16._003C_003E4__this;
												if ((object)CS_0024_003C_003E8__locals16._003C_003E4__this != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v8 (UnityEngine.GameObject)+58]");
														float2 position4 = ((ArcadeSprite)0).position;
														TP_SpriteWhip_Weapon tP_SpriteWhip_Weapon2 = CS_0024_003C_003E8__locals16._003C_003E4__this;
														if ((object)CS_0024_003C_003E8__locals16._003C_003E4__this != null)
														{
															Vector2 pos = default(Vector2);
															BulletPool pool = default(BulletPool);
															Projectile projectile4 = CS_0024_003C_003E8__locals16._003C_003E4__this.FireFireballProjectile(pos, CS_0024_003C_003E8__locals16.localIndex, tP_SpriteWhip_Weapon2._targetTransform, pool);
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
						float num8 = (float)num7 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num5 = num8 * 0.001f;
						Timer lastShotTimer = Timers.Register(num5, onComplete, null, isLooped: false, (byte)(int)bulletPool != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					num7++;
					float num9 = base.PAmount();
				}
				while (num5 > (float)num7);
			}
		}
		float num10 = base.PInterval();
		float num11 = _lastFiringInterval - num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = num11 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num12 = base.PInterval();
			_lastFiringInterval = num5;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public Projectile FireFireballProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0047: Expected I, but got O
		//IL_0055: Expected I, but got O
		//IL_0065: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		//IL_01ba: Expected O, but got I
		//IL_01d4: Expected F4, but got I
		float2 pos2 = default(float2);
		Projectile projectile = _fireballPool.SpawnAt(pos2, this, index);
		bool flag = (object)projectile == null;
		Projectile projectile2 = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(TP_VampireKiller_Fire_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Fire_Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Fire_Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v32+FFFFFFF8+v184 @ rax_v28*8]");
				if (0 == (nint)typeof(TP_VampireKiller_Fire_Projectile))
				{
					obj3 = 1;
					goto IL_0220;
				}
			}
			obj3 = 0;
			goto IL_0220;
		}
		goto IL_0247;
		IL_0247:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			if (((Equipment)this)._003COwner_003Ek__BackingField.flipX)
			{
				List<float> fireBallAnglesFlipped = _fireBallAnglesFlipped;
			}
			else
			{
				List<float> fireBallAnglesFlipped = _fireBallAngles;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num4 = (int)((nint)index % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num4 >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Projectile result = default(Projectile);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			Projectile projectile3 = projectile2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v7+20+v81 @ rdx_v9 (System.Int32)*4]");
			((TP_VampireKiller_Fire_Projectile)projectile3).SetAngleVelocity_Deg(0f);
			BaseBody body = projectile2.body;
			if (projectile2.body != null)
			{
				body._transform.ForceFullReupdate();
			}
		}
		return projectile2;
		IL_0220:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0247;
	}

	public Projectile FireExplosionProjectile(Vector2 pos, int index, EnemyController target = null, BulletPool pool = null)
	{
		//IL_0047: Expected I, but got O
		//IL_0055: Expected I, but got O
		//IL_0065: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if (_explosionPool != null)
		{
			float2 pos2 = default(float2);
			projectile = _explosionPool.SpawnAt(pos2, this, index);
			bool flag = (object)projectile == null;
			projectile2 = null;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(TP_VampireKiller_Explosion_Projectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Explosion_Projectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Explosion_Projectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v25+FFFFFFF8+v86 @ rax_v21*8]");
					if (0 == (nint)typeof(TP_VampireKiller_Explosion_Projectile))
					{
						obj3 = 1;
						goto IL_0169;
					}
				}
				obj3 = 0;
				goto IL_0169;
			}
			goto IL_0190;
		}
		return (Projectile)(object)new NullReferenceException();
		IL_0169:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0190;
		IL_0190:
		if ((object)projectile2 == null || ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
		}
		return projectile2;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override void OnDestroy()
	{
		if (_fireballPool != null)
		{
			_fireballPool.Destroy();
		}
		_fireballPool = null;
		if (_explosionPool != null)
		{
			_explosionPool.Destroy();
		}
		_explosionPool = null;
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_fireballPool != null)
		{
			_fireballPool.Cleanup();
		}
		if (_explosionPool != null)
		{
			_explosionPool.Cleanup();
		}
		base.Cleanup();
	}

	public TP_SpriteWhip_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_032d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0355: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01fb: Expected O, but got I
		//IL_038c: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_03b4: Expected O, but got I
		//IL_02cf: Expected O, but got I
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(45f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1110704128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-45f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 3258187776L;
		}
		_fireBallAngles = list;
		List<float> list2 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v9+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize(180f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1127481344;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v10+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize(135f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1124532224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v11+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize(225f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1130430464;
		}
		_fireBallAnglesFlipped = list2;
		_specialCounter = 3;
		base._002Ector();
	}
}
