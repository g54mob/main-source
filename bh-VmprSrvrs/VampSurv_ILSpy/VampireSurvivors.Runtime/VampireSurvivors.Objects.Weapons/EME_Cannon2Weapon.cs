using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Cannon2Weapon : EME_Cannon1Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public EME_Cannon2Weapon _003C_003E4__this;

		public List<float2> spawnPoints;

		public List<float2> targets;
	}

	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireBombardment_003Eb__0()
		{
			//IL_0413: Expected O, but got I4
			//IL_00ff: Expected O, but got I
			//IL_01c7: Expected O, but got I
			//IL_02bf: Expected I, but got O
			//IL_02cd: Expected I, but got O
			//IL_02dd: Expected O, but got I
			//IL_035d: Expected O, but got I4
			//IL_0319: Expected O, but got I
			//IL_034f: Expected O, but got I4
			//IL_0084->IL03b3: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL03b3: Incompatible stack heights: 1 vs 0
			//IL_011c->IL03b3: Incompatible stack heights: 2 vs 0
			//IL_0178->IL03b3: Incompatible stack heights: 3 vs 0
			//IL_01e7->IL03b3: Incompatible stack heights: 4 vs 0
			//IL_0233->IL03b3: Incompatible stack heights: 5 vs 0
			//IL_0262->IL03b3: Incompatible stack heights: 5 vs 0
			//IL_0474->IL03b2: Incompatible stack heights: 5 vs 1
			//IL_039b->IL03b2: Incompatible stack heights: 5 vs 1
			//IL_03b2->IL03b2: Incompatible stack heights: 5 vs 1
			_003C_003Ec__DisplayClass16_0 obj = CS_0024_003C_003E8__locals1;
			EME_CannonProjectile_BombardingFire_Missile eME_CannonProjectile_BombardingFire_Missile;
			float2 float5 = default(float2);
			EME_CannonProjectile_BombardingFire_Missile eME_CannonProjectile_BombardingFire_Missile2;
			object obj9;
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
					_003C_003Ec__DisplayClass16_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						GameObject spawnPoints = (GameObject)(object)obj3.spawnPoints;
						if (obj3.spawnPoints != null)
						{
							int num = localIndex;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v9 (UnityEngine.GameObject)+18]");
							int num2 = (int)((nint)num % (nint)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v9 (UnityEngine.GameObject)+18]");
							bool flag2 = (nint)num2 >= (nint)0;
							GameObject gameObject2 = (GameObject)(nint)((UnityEngine.Object)spawnPoints).m_CachedPtr;
							if (((UnityEngine.Object)spawnPoints).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v10 (UnityEngine.GameObject)+18]");
								bool flag3 = (nint)num2 >= (nint)0;
								_003C_003Ec__DisplayClass16_0 obj4 = CS_0024_003C_003E8__locals1;
								List<float2> targets = obj4.targets;
								if (obj4.targets != null)
								{
									int num3 = localIndex;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v16 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
									int num4 = (int)((nint)num3 % (nint)0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v16 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
									bool flag4 = (nint)num4 >= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v16 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v16 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v17+18]");
										bool flag5 = (nint)num4 >= (nint)0;
										_003C_003Ec__DisplayClass16_0 obj6 = CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals1 != null)
										{
											EME_Cannon2Weapon eME_Cannon2Weapon = obj6._003C_003E4__this;
											if ((object)obj6._003C_003E4__this != null)
											{
												eME_CannonProjectile_BombardingFire_Missile = (EME_CannonProjectile_BombardingFire_Missile)obj6._003C_003E4__this.FireOneProjectile(float5, localIndex, eME_Cannon2Weapon._targetTransform);
												if ((object)eME_CannonProjectile_BombardingFire_Missile == null)
												{
													eME_CannonProjectile_BombardingFire_Missile2 = null;
													goto IL_045c;
												}
												nint num5 = (nint)eME_CannonProjectile_BombardingFire_Missile;
												nint num6 = (nint)typeof(EME_CannonProjectile_BombardingFire_Missile);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_BombardingFire_Missile>)+130]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_BombardingFire_Missile>)+130]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_BombardingFire_Missile>)+130]");
												if (num7 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_BombardingFire_Missile>)+C8]");
													object obj8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v47+FFFFFFF8+v582 @ rax_v43*8]");
													if (0 == (nint)typeof(EME_CannonProjectile_BombardingFire_Missile))
													{
														obj9 = 1;
														goto IL_0435;
													}
												}
												obj9 = 0;
												goto IL_0435;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_0435:
			bool flag6 = obj9 == null;
			eME_CannonProjectile_BombardingFire_Missile2 = null;
			if (!flag6)
			{
				eME_CannonProjectile_BombardingFire_Missile2 = eME_CannonProjectile_BombardingFire_Missile;
			}
			goto IL_045c;
			IL_045c:
			if ((object)eME_CannonProjectile_BombardingFire_Missile2 != null && ((UnityEngine.Object)eME_CannonProjectile_BombardingFire_Missile2).m_CachedPtr != (IntPtr)0)
			{
				eME_CannonProjectile_BombardingFire_Missile2.MoveToTarget(float5);
			}
		}
	}

	private Projectile BombardingFireExplosionPrefab;

	private BulletPool _bombardingFire_Explosion_Pool;

	private Timer _bombardingFireTimer;

	protected Camera _mainCamera;

	protected Bounds _camBounds;

	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	public BulletPool BombardingFireExplosionPool => _bombardingFire_Explosion_Pool;

	protected override void Awake()
	{
		base.Awake();
		Camera main = Camera.main;
		_mainCamera = main;
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v6 (UnityEngine.Bounds)+10]");
		_ = 0;
	}

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		((Weapon)this).OnStart();
		InitGlimmer1BulletPool();
		InitGlimmer2BulletPool();
		InitGlimmer3BulletPool();
		if (_bombardingFire_Explosion_Pool == null)
		{
			BulletPool bombardingFire_Explosion_Pool = new BulletPool(BombardingFireExplosionPrefab, 20);
			_bombardingFire_Explosion_Pool = bombardingFire_Explosion_Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamageWithSlow;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_bombardingFire_Explosion_Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_bombardingFire_Explosion_Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void Cleanup()
	{
		if (_bombardingFireTimer != null)
		{
			_bombardingFireTimer.Cancel();
		}
		((Weapon)this).Cleanup();
		if (((EME_Weapon)this).glimmerUnlockTimer != null)
		{
			((EME_Weapon)this).glimmerUnlockTimer.Cancel();
		}
	}

	private bool OnBulletOverlapsEnemyHighDamageWithSlow(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01c5: Expected I4, but got O
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
						goto IL_01b1;
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
									GameObject gameObject3 = component.gameObject;
									if ((object)gameObject3 == null)
									{
										goto IL_01b7;
									}
									EnemyController component3 = gameObject3.GetComponent<EnemyController>();
									if ((bool)component3)
									{
										float num = base.PPower();
										float num2 = base.CalcCritMul();
										object obj = default(object);
										float num3 = (float)obj * 20f;
										float damage = (float)obj * num3;
										base.DealDamage(component, damage);
										return false;
									}
								}
								goto IL_01b1;
							}
						}
					}
				}
			}
		}
		goto IL_01b7;
		IL_01b7:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01b1:
		return false;
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		object obj = default(object);
		if (obj != _glimmer2Pool)
		{
			base.Fire_FireGlimmerProjectile(pos, index, target, pool);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x18748F040\"");
		}
	}

	public unsafe void FireBombardment()
	{
		//IL_0047: Expected F4, but got I4
		//IL_00dc: Invalid comparison between F4 and I4
		//IL_016e: Expected I, but got O
		//IL_0184: Expected O, but got I
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01fb: Expected I, but got O
		//IL_024f: Expected O, but got I4
		//IL_0266: Expected I, but got I8
		//IL_02b3: Expected I4, but got F4
		//IL_02b3: Expected O, but got F4
		//IL_02b3: Expected I4, but got O
		//IL_0223: Invalid comparison between F4 and I4
		//IL_01e4: Expected I, but got I8
		_003C_003Ec__DisplayClass16_0 obj = new _003C_003Ec__DisplayClass16_0();
		obj._003C_003E4__this = this;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Sfx_eme_bombardingfire1, 500f, 1, 0f, num, num2, num3, flag, 1f);
		List<float2> targets = GenerateBombardmentTargets();
		obj.targets = targets;
		List<float2> spawnPoints = GenerateBombardmentSpawnPoints(obj.targets);
		obj.spawnPoints = spawnPoints;
		float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		float num5 = (float)currentWeaponData._003Camount_003Ek__BackingField + 1f;
		float num6 = num5 + num5;
		if (!(num6 > 0f))
		{
			return;
		}
		bool flag2 = false;
		do
		{
			_003C_003Ec__DisplayClass16_1 obj2 = new _003C_003Ec__DisplayClass16_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = (flag2 ? 1 : 0);
			Action action = null;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_1._003CFireBombardment_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num8;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num8 = unchecked((nint)6447293664L);
					goto IL_0246;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num8 = ((Delegate)action).method_ptr;
			goto IL_0246;
			IL_0246:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num9 = (float)(flag2 ? 1 : 0) * 100f;
			float duration = num9 * 0.001f;
			Timer bombardingFireTimer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			_bombardingFireTimer = bombardingFireTimer;
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while (num6 > (float)(flag2 ? 1 : 0));
	}

	private unsafe List<float2> GenerateBombardmentTargets()
	{
		//IL_02ad: Expected O, but got I4
		//IL_02bd: Expected O, but got Ref
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_0077: Expected O, but got I
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_01a5: Expected I, but got O
		//IL_0148->IL01f4: Incompatible stack heights: 1 vs 0
		List<float2> list = new List<float2>();
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon)+204]");
				float num = 0f * 2f;
				float num2 = num / 6f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon)+208]");
				float num3 = 0f * 2f;
				float num4 = num3 / 6f;
				object obj = 0;
				Transform transform2 = transform;
				float2 float5 = (float2)(&ret);
				nint num5 = ((UnityEngine.Object)transform).m_CachedPtr;
				object obj3 = default(object);
				float2 float7 = default(float2);
				while (true)
				{
					if (obj != null && (nint)obj != 5)
					{
						Transform transform3 = null;
						float2 float6 = float5;
						object obj2 = obj3;
						List<float2> list2 = (List<float2>)num5;
						while (true)
						{
							if ((object)transform3 != null && (nint)transform3 != 5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
								float maxInclusive = 0f * num2;
								float minInclusive = 0f * num2;
								float num6 = UnityEngine.Random.Range(minInclusive, maxInclusive);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
								float maxInclusive2 = 0f * num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
								float minInclusive2 = 0f * num4;
								float num7 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
								if (list == null)
								{
									break;
								}
								list.Add(float7);
								float6 = float7;
								list2 = list;
							}
							transform2 = (Transform)(transform3 + 1);
							bool flag2 = (nint)transform2 < 6;
							float5 = float6;
							obj3 = obj2;
							num5 = (nint)list2;
							transform3 = transform2;
							if (flag2)
							{
								continue;
							}
							goto IL_01bb;
						}
						break;
					}
					goto IL_01bb;
					IL_01bb:
					obj++;
					if ((nint)obj >= 6)
					{
						Extensions.Shuffle(list);
						return list;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private List<float2> GenerateBombardmentSpawnPoints(List<float2> targets)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0053: Expected O, but got I
		//IL_0105: Expected O, but got I
		//IL_0174: Expected O, but got I
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		List<float2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		object obj = 0;
		object obj2 = 0;
		float2 item = default(float2);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [targets @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj3 < 0)
			{
				object obj4 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [targets @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [targets @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon)+204]");
				float num = 0f * 2f;
				object obj6 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [targets @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj6 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon)+208]");
				float num2 = 0f * 2f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v9+20+v98 @ rbx_v5*8]");
				float num3 = 0f + num;
				float num4 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v9+24+v98 @ rbx_v5*8]");
				float num5 = num4 + 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v10+18]");
				if (num6 >= 0)
				{
					list.AddWithResize(item);
					obj++;
					obj2 = obj;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					object obj8 = (nint)0 + (nint)1;
					obj++;
					obj2 = obj;
				}
				continue;
			}
			return list;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<float2> result = default(List<float2>);
		return result;
	}
}
