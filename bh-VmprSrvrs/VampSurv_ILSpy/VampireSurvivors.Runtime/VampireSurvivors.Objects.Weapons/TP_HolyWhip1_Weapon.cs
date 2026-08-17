using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_HolyWhip1_Weapon : TP_WhipCore1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public Vector2 pos;

		public float __radius;

		public TP_HolyWhip1_Weapon _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass2_1
	{
		public int localI;

		public _003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireSmokeProjectiles_003Eb__0()
		{
			//IL_014c: Expected O, but got F4
			//IL_007b: Expected O, but got F4
			//IL_00dc: Expected O, but got I4
			_003C_003Ec__DisplayClass2_2 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass2_2();
			CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 = this;
			object obj = UnityEngine.Random.value;
			_003C_003Ec__DisplayClass2_0 obj2 = CS_0024_003C_003E8__locals1;
			object obj4 = default(object);
			object obj3 = obj4 + obj4;
			float num = (float)obj3 * (float)Math.PI;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num2 = num * obj2.__radius;
			float num3 = num2 + (float)obj2.pos;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num4 = num * obj2.__radius;
			CS_0024_003C_003E8__locals9.__pos = (Vector2)num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r15_v3 (VampireSurvivors.Objects.Weapons.TP_HolyWhip1_Weapon+<>c__DisplayClass2_0)+14]");
			float num5 = 0f - num4;
			_003C_003Ec__DisplayClass2_0 obj5 = CS_0024_003C_003E8__locals1;
			TP_HolyWhip1_Weapon tP_HolyWhip1_Weapon = obj5._003C_003E4__this;
			Action onComplete = delegate
			{
				//IL_0223: Expected O, but got I4
				//IL_00d7->IL01ec: Incompatible stack heights: 1 vs 0
				//IL_0106->IL01ec: Incompatible stack heights: 1 vs 0
				//IL_0135->IL01ec: Incompatible stack heights: 1 vs 0
				//IL_015e->IL01ec: Incompatible stack heights: 1 vs 0
				//IL_018d->IL01ec: Incompatible stack heights: 1 vs 0
				//IL_01b9->IL01ec: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass2_1 obj7 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2;
				if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 != null)
				{
					_003C_003Ec__DisplayClass2_0 obj8 = obj7.CS_0024_003C_003E8__locals1;
					if (obj7.CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
					{
						GameObject gameObject = obj8._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj9 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj9 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass2_1 obj10 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2;
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 != null)
							{
								_003C_003Ec__DisplayClass2_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
								if (obj10.CS_0024_003C_003E8__locals1 != null)
								{
									TP_HolyWhip1_Weapon tP_HolyWhip1_Weapon2 = obj11._003C_003E4__this;
									if ((object)obj11._003C_003E4__this != null)
									{
										_003C_003Ec__DisplayClass2_1 obj12 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2;
										if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2 != null)
										{
											_003C_003Ec__DisplayClass2_0 obj13 = obj12.CS_0024_003C_003E8__locals1;
											if (obj12.CS_0024_003C_003E8__locals1 != null)
											{
												_003C_003Ec__DisplayClass2_1 obj14 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals2;
												if (tP_HolyWhip1_Weapon2._smokePool != null)
												{
													float2 pos = default(float2);
													Projectile projectile = tP_HolyWhip1_Weapon2._smokePool.SpawnAt(pos, obj13._003C_003E4__this, obj14.localI);
													return;
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
			};
			object obj6 = localI * 50;
			float duration = (float)obj6 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			tP_HolyWhip1_Weapon._lastShotTimer = lastShotTimer;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_2
	{
		public Vector2 __pos;

		public _003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals2;

		internal void _003CFireSmokeProjectiles_003Eb__1()
		{
			//IL_0223: Expected O, but got I4
			//IL_00d7->IL01ec: Incompatible stack heights: 1 vs 0
			//IL_0106->IL01ec: Incompatible stack heights: 1 vs 0
			//IL_0135->IL01ec: Incompatible stack heights: 1 vs 0
			//IL_015e->IL01ec: Incompatible stack heights: 1 vs 0
			//IL_018d->IL01ec: Incompatible stack heights: 1 vs 0
			//IL_01b9->IL01ec: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass2_1 obj = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				_003C_003Ec__DisplayClass2_0 obj2 = obj.CS_0024_003C_003E8__locals1;
				if (obj.CS_0024_003C_003E8__locals1 != null && (object)obj2._003C_003E4__this != null)
				{
					GameObject gameObject = obj2._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj3 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass2_1 obj4 = CS_0024_003C_003E8__locals2;
						if (CS_0024_003C_003E8__locals2 != null)
						{
							_003C_003Ec__DisplayClass2_0 obj5 = obj4.CS_0024_003C_003E8__locals1;
							if (obj4.CS_0024_003C_003E8__locals1 != null)
							{
								TP_HolyWhip1_Weapon tP_HolyWhip1_Weapon = obj5._003C_003E4__this;
								if ((object)obj5._003C_003E4__this != null)
								{
									_003C_003Ec__DisplayClass2_1 obj6 = CS_0024_003C_003E8__locals2;
									if (CS_0024_003C_003E8__locals2 != null)
									{
										_003C_003Ec__DisplayClass2_0 obj7 = obj6.CS_0024_003C_003E8__locals1;
										if (obj6.CS_0024_003C_003E8__locals1 != null)
										{
											_003C_003Ec__DisplayClass2_1 obj8 = CS_0024_003C_003E8__locals2;
											if (tP_HolyWhip1_Weapon._smokePool != null)
											{
												float2 pos = default(float2);
												Projectile projectile = tP_HolyWhip1_Weapon._smokePool.SpawnAt(pos, obj7._003C_003E4__this, obj8.localI);
												return;
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
		}
	}

	protected BulletPool _smokePool;

	protected override void Awake()
	{
		base.Awake();
		_weaponNodeType = WeaponType.TP_HOLYWHIP1_NODE;
	}

	public unsafe void FireSmokeProjectiles(Vector2 pos)
	{
		//IL_03f2: Expected O, but got F4
		//IL_0237: Expected F4, but got I4
		//IL_0277: Invalid comparison between F4 and I4
		//IL_0318: Expected I, but got O
		//IL_032e: Expected O, but got I
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_03a5: Expected I, but got O
		//IL_0400: Expected O, but got I4
		//IL_0417: Expected I, but got I8
		//IL_0468: Expected I4, but got F4
		//IL_0468: Expected O, but got F4
		//IL_0468: Expected I4, but got O
		//IL_0483: Invalid comparison between F4 and I4
		//IL_011e: Expected I, but got O
		//IL_014d: Expected O, but got F4
		//IL_038e: Expected I, but got I8
		//IL_01c1: Expected I, but got O
		//IL_01f0: Expected O, but got F4
		_003C_003Ec__DisplayClass2_0 obj = new _003C_003Ec__DisplayClass2_0();
		Vector2 pos2 = default(Vector2);
		obj.pos = pos2;
		obj._003C_003E4__this = this;
		float? num2 = default(float?);
		float num3 = default(float);
		if (_smokePool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_HOLYWHIP1_SMOKE);
			BulletPool smokePool = new BulletPool(projectilePrefab);
			_smokePool = smokePool;
			BulletPool smokePool2 = _smokePool;
			smokePool2.UpperLimit = 100;
			BulletPool smokePool3 = _smokePool;
			smokePool3.IsUncapped = true;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				GameManager core = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_HolyWhip1_Weapon>)+370]");
				ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Collider collider = physics.add.overlap(_smokePool, core.Enemies, collideCallback, (ArcadePhysicsCallback)num2, (CallbackContext)num3);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					ArcadePhysics physics2 = s_scene2.physics;
					GameManager core2 = GM.Core;
					PhysicsManager physicsManager = core2._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1047 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_HolyWhip1_Weapon>)+3A0]");
					ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num4 = (nint)this;
					Collider collider2 = physics2.add.overlap(_smokePool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)num2, (CallbackContext)num3);
					num2 = num2;
					goto IL_03e9;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_03e9;
		IL_03e9:
		object obj2 = UnityEngine.Random.value;
		float num5 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Kick, 200f, 3, 0f, num2, num3, num5, flag, 1f);
		float num6 = base.PAmount();
		float num7 = base.PArea();
		float _radius = 0.8f * 0.2f;
		obj.__radius = _radius;
		if (!(0.8f > 0f))
		{
			return;
		}
		bool flag2 = false;
		do
		{
			_003C_003Ec__DisplayClass2_1 obj3 = new _003C_003Ec__DisplayClass2_1();
			obj3.CS_0024_003C_003E8__locals1 = obj;
			obj3.localI = (flag2 ? 1 : 0);
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass2_1._003CFireSmokeProjectiles_003Eb__0);
			((Delegate)action).m_target = obj3;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num9;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num9 = unchecked((nint)6447293664L);
					goto IL_03f7;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num9 = ((Delegate)action).method_ptr;
			goto IL_03f7;
			IL_03f7:
			object obj6 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num10 = (float)(flag2 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float duration = num10 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)num3, (int)num5, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while (0.8f > (float)(flag2 ? 1 : 0));
	}

	protected override void OnDestroy()
	{
		if (_smokePool != null)
		{
			_smokePool.Destroy();
			_smokePool = null;
		}
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_smokePool != null)
		{
			_smokePool.Cleanup();
		}
		if (_nodePool != null)
		{
			_nodePool.Cleanup();
		}
		((Weapon)this).Cleanup();
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
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}
}
