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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Cannon3Weapon : EME_Cannon2Weapon
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public EME_Cannon3Weapon _003C_003E4__this;

		public List<float2> spawnPoints;

		public List<float2> targets;
	}

	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireSunlightShower_003Eb__0()
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
			_003C_003Ec__DisplayClass12_0 obj = CS_0024_003C_003E8__locals1;
			EME_CannonProjectile_SunlightShower eME_CannonProjectile_SunlightShower;
			float2 float5 = default(float2);
			EME_CannonProjectile_SunlightShower eME_CannonProjectile_SunlightShower2;
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
					_003C_003Ec__DisplayClass12_0 obj3 = CS_0024_003C_003E8__locals1;
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
								_003C_003Ec__DisplayClass12_0 obj4 = CS_0024_003C_003E8__locals1;
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
										_003C_003Ec__DisplayClass12_0 obj6 = CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals1 != null)
										{
											EME_Cannon3Weapon eME_Cannon3Weapon = obj6._003C_003E4__this;
											if ((object)obj6._003C_003E4__this != null)
											{
												eME_CannonProjectile_SunlightShower = (EME_CannonProjectile_SunlightShower)obj6._003C_003E4__this.FireOneProjectile(float5, localIndex, eME_Cannon3Weapon._targetTransform);
												if ((object)eME_CannonProjectile_SunlightShower == null)
												{
													eME_CannonProjectile_SunlightShower2 = null;
													goto IL_045c;
												}
												nint num5 = (nint)eME_CannonProjectile_SunlightShower;
												nint num6 = (nint)typeof(EME_CannonProjectile_SunlightShower);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShower>)+130]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShower>)+130]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShower>)+130]");
												if (num7 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShower>)+C8]");
													object obj8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v47+FFFFFFF8+v582 @ rax_v43*8]");
													if (0 == (nint)typeof(EME_CannonProjectile_SunlightShower))
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
			eME_CannonProjectile_SunlightShower2 = null;
			if (!flag6)
			{
				eME_CannonProjectile_SunlightShower2 = eME_CannonProjectile_SunlightShower;
			}
			goto IL_045c;
			IL_045c:
			if ((object)eME_CannonProjectile_SunlightShower2 != null && ((UnityEngine.Object)eME_CannonProjectile_SunlightShower2).m_CachedPtr != (IntPtr)0)
			{
				eME_CannonProjectile_SunlightShower2.MoveToTarget(float5);
			}
		}
	}

	private Projectile _sunlightShowerExplosionPrefab;

	private BulletPool _sunlightShower_Explosion_Pool;

	private Timer _sunlightShowerTimer;

	protected override int ComboIndexFinal => base.ComboIndex3;

	protected override int GlimmerTier => 3;

	public BulletPool SunlightShowerExplosionPool => _sunlightShower_Explosion_Pool;

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		base.OnStart();
		if (_sunlightShower_Explosion_Pool == null)
		{
			BulletPool sunlightShower_Explosion_Pool = new BulletPool(_sunlightShowerExplosionPrefab, 20);
			_sunlightShower_Explosion_Pool = sunlightShower_Explosion_Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = base.OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_sunlightShower_Explosion_Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon3Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_sunlightShower_Explosion_Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void Cleanup()
	{
		if (_sunlightShowerTimer != null)
		{
			_sunlightShowerTimer.Cancel();
		}
		if (base._bombardingFireTimer != null)
		{
			base._bombardingFireTimer.Cancel();
		}
		((Weapon)this).Cleanup();
		if (((EME_Weapon)this).glimmerUnlockTimer != null)
		{
			((EME_Weapon)this).glimmerUnlockTimer.Cancel();
		}
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		object obj = default(object);
		if (obj != _glimmer3Pool)
		{
			if (obj != _glimmer2Pool)
			{
				Fire_FireGlimmerProjectile(pos, index, target, pool);
			}
			else
			{
				FireBombardment();
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 30 Invalid \"Jump target not found in method: 0x187490100\"");
		}
	}

	public unsafe void FireSunlightShower()
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
		_003C_003Ec__DisplayClass12_0 obj = new _003C_003Ec__DisplayClass12_0();
		obj._003C_003E4__this = this;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Sfx_eme_sunlightshower1, 500f, 1, 0f, num, num2, num3, flag, 1f);
		List<float2> targets = GenerateShowerTargets();
		obj.targets = targets;
		List<float2> spawnPoints = GenerateShowerSpawnPoints(obj.targets);
		obj.spawnPoints = spawnPoints;
		float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		float num5 = (float)currentWeaponData._003Camount_003Ek__BackingField + 1.5f;
		float num6 = num5 + num5;
		if (!(num6 > 0f))
		{
			return;
		}
		bool flag2 = false;
		do
		{
			_003C_003Ec__DisplayClass12_1 obj2 = new _003C_003Ec__DisplayClass12_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = (flag2 ? 1 : 0);
			Action action = null;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass12_1._003CFireSunlightShower_003Eb__0);
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
			float num9 = (float)(flag2 ? 1 : 0) * 50f;
			float duration = num9 * 0.001f;
			Timer sunlightShowerTimer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			_sunlightShowerTimer = sunlightShowerTimer;
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while (num6 > (float)(flag2 ? 1 : 0));
	}

	private List<float2> GenerateShowerTargets()
	{
		//IL_022f: Expected O, but got I4
		//IL_026c: Expected O, but got I
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_015a: Expected I, but got O
		//IL_00ea->IL0176: Incompatible stack heights: 1 vs 0
		List<float2> list = new List<float2>();
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon3Weapon)+204]");
				float num = 0f * 2f;
				float num2 = num / 6f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon3Weapon)+208]");
				float num3 = 0f * 2f;
				float num4 = num3 / 6f;
				object obj = 0;
				nint num5 = ((UnityEngine.Object)transform).m_CachedPtr;
				float2 item = default(float2);
				while (true)
				{
					Transform transform2 = null;
					List<float2> list2 = (List<float2>)num5;
					while (true)
					{
						if ((nint)transform2 <= 3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,esi\"");
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
							list.Add(item);
							list2 = list;
						}
						transform2 = (Transform)(transform2 + 1);
						if ((nint)transform2 < 6)
						{
							continue;
						}
						goto IL_0135;
					}
					break;
					IL_0135:
					obj++;
					bool flag2 = (nint)obj < 6;
					num5 = (nint)list2;
					if (!flag2)
					{
						Extensions.Shuffle(list);
						return list;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private List<float2> GenerateShowerSpawnPoints(List<float2> targets)
	{
		//IL_000e: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0032: Expected O, but got I
		//IL_016f: Expected O, but got F4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00bb: Expected I, but got O
		//IL_0093: Expected O, but got I8
		List<float2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		object obj = 0;
		nint num = 0;
		object obj2 = 0;
		object obj6 = default(object);
		float2 float5 = default(float2);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [targets @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj3 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj4 == null)
					{
						break;
					}
					obj2 = 6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v271 @ rax_v15 (should have been resolved before IL gen)");
				object obj5 = UnityEngine.Random.value;
				if (0.05f > 0.5f)
				{
					/*Error: End of method reached without returning.*/;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.EME_Cannon3Weapon)+208]");
				float num2 = 0f * 2f;
				float num3 = (float)obj6 + num2;
				list.Add(float5);
				obj++;
				num = (nint)float5;
				obj2 = obj;
				continue;
			}
			return list;
		}
		MissingMethodException ex = new MissingMethodException();
		throw ex;
	}
}
