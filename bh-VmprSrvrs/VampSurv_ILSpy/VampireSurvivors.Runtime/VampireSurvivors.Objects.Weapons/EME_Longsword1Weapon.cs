using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
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

public class EME_Longsword1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public float final;

		public EME_Longsword1Weapon _003C_003E4__this;

		internal void _003CFire_FireGlimmerProjectile_003Eb__1()
		{
			EME_Longsword1Weapon eME_Longsword1Weapon = _003C_003E4__this;
			float2 position = ((Equipment)eME_Longsword1Weapon)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			eME_Longsword1Weapon.FireSwallowSwing(pos, final);
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public EME_Longsword1Weapon _003C_003E4__this;

		public Vector2 pos;
	}

	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public Vector3 Direction;

		public int localIndex;

		public _003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFireSwallowSwing_003Eb__0()
		{
			//IL_024f: Expected O, but got I4
			//IL_00fb: Expected I, but got O
			//IL_0109: Expected I, but got O
			//IL_0119: Expected O, but got I
			//IL_0199: Expected O, but got I4
			//IL_0155: Expected O, but got I
			//IL_018b: Expected O, but got I4
			//IL_01e9: Expected O, but got Ref
			//IL_0084->IL01ef: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL01ef: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass18_0 obj = CS_0024_003C_003E8__locals1;
			EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice;
			EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice2;
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
					_003C_003Ec__DisplayClass18_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						eME_LongswordProjectile_SwallowSlice = (EME_LongswordProjectile_SwallowSlice)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex);
						if ((object)eME_LongswordProjectile_SwallowSlice == null)
						{
							eME_LongswordProjectile_SwallowSlice2 = null;
							goto IL_0298;
						}
						nint num = (nint)eME_LongswordProjectile_SwallowSlice;
						nint num2 = (nint)typeof(EME_LongswordProjectile_SwallowSlice);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
							if (0 == (nint)typeof(EME_LongswordProjectile_SwallowSlice))
							{
								obj6 = 1;
								goto IL_0271;
							}
						}
						obj6 = 0;
						goto IL_0271;
					}
				}
			}
			throw new NullReferenceException();
			IL_0298:
			if ((object)eME_LongswordProjectile_SwallowSlice2 != null && ((UnityEngine.Object)eME_LongswordProjectile_SwallowSlice2).m_CachedPtr != (IntPtr)0)
			{
				object obj7 = default(object);
				eME_LongswordProjectile_SwallowSlice2.SetDirection((Vector3)(&obj7));
			}
			return;
			IL_0271:
			bool flag2 = obj6 == null;
			eME_LongswordProjectile_SwallowSlice2 = null;
			if (!flag2)
			{
				eME_LongswordProjectile_SwallowSlice2 = eME_LongswordProjectile_SwallowSlice;
			}
			goto IL_0298;
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public EME_Longsword1Weapon _003C_003E4__this;

		public Vector2 pos;

		public Projectile parent;
	}

	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireLSSlashes_003Eb__0()
		{
			//IL_027f: Expected O, but got I4
			//IL_0105: Expected I4, but got O
			//IL_0113: Expected I, but got O
			//IL_0123: Expected O, but got I
			//IL_01a3: Expected O, but got I4
			//IL_015f: Expected O, but got I
			//IL_0195: Expected O, but got I4
			//IL_0084->IL021f: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL021f: Incompatible stack heights: 1 vs 0
			//IL_020a->IL021f: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass21_0 obj = CS_0024_003C_003E8__locals1;
			GameObject gameObject2;
			GameObject gameObject3;
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
					_003C_003Ec__DisplayClass21_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						int num = localIndex;
						Vector2 pos = default(Vector2);
						gameObject2 = (GameObject)(object)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex);
						if ((object)gameObject2 == null)
						{
							gameObject3 = null;
							goto IL_02c8;
						}
						num = (int)gameObject2;
						nint num2 = (nint)typeof(EME_LongswordProjectile_Sprinkler);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v6 (System.Int32)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v6 (System.Int32)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v36+FFFFFFF8+v411 @ rax_v32*8]");
							if (0 == (nint)typeof(EME_LongswordProjectile_Sprinkler))
							{
								obj6 = 1;
								goto IL_02a1;
							}
						}
						obj6 = 0;
						goto IL_02a1;
					}
				}
			}
			goto IL_021f;
			IL_02a1:
			bool flag2 = obj6 == null;
			gameObject3 = null;
			if (!flag2)
			{
				gameObject3 = gameObject2;
			}
			goto IL_02c8;
			IL_02c8:
			if ((object)gameObject3 != null && ((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
			{
				_003C_003Ec__DisplayClass21_0 obj7 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180BA5BF0");
					return;
				}
				goto IL_021f;
			}
			return;
			IL_021f:
			throw new NullReferenceException();
		}
	}

	private float swallowSliceInterval;

	protected Projectile _slicesPrefab;

	private BulletPool _slicesPool;

	protected override int EvolutionLevel => 6;

	protected override int _comboIndex1 => 3;

	protected override int _comboIndex2 => 14;

	protected override int _comboIndex3 => 21;

	protected override int ComboIndexFinal => base.ComboIndex1;

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		//IL_0034: Expected O, but got I4
		if (level == 1)
		{
			return WeaponType.EME_LONGSWORD_TECH_01;
		}
		object obj = level - 2;
		bool flag = obj == null;
		bool flag2 = !flag;
		return (WeaponType)((flag2 ? 1 : 0) + 2382);
	}

	protected override void OnStart()
	{
		//IL_0054: Expected I, but got O
		//IL_00f7: Expected I, but got O
		((Weapon)this).OnStart();
		base.InitGlimmer1BulletPool();
		InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		BulletPool slicesPool = new BulletPool(_slicesPrefab);
		_slicesPool = slicesPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Longsword1Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_slicesPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Longsword1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_slicesPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected unsafe override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00c5: Expected O, but got I4
		//IL_00ce: Invalid comparison between F4 and I4
		//IL_00e4: Expected I, but got I8
		//IL_01ed: Expected I, but got O
		//IL_0203: Expected O, but got I
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_010c: Expected O, but got I4
		//IL_027f: Expected I, but got O
		//IL_03d5: Expected O, but got I4
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_0252: Expected I, but got I8
		//IL_0127: Expected I, but got O
		//IL_013d: Expected O, but got I
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_01b4: Expected I, but got O
		//IL_0310: Expected I, but got I8
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_0375: Invalid comparison between F4 and I4
		//IL_01d3: Expected I, but got I8
		//IL_019d: Expected I, but got I8
		object obj = default(object);
		if (obj != _glimmer1Pool)
		{
			return;
		}
		swallowSliceInterval = 20f;
		float num = base.PAmount();
		object obj2 = default(object);
		float num2 = (float)obj2 * 4f;
		nint extra_arg;
		bool flag2;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Action action2;
		if (28f < num2)
		{
			_003C_003Ec__DisplayClass17_0 obj3 = new _003C_003Ec__DisplayClass17_0();
			obj3._003C_003E4__this = this;
			FireSwallowSwing(pos, 28f);
			float num3 = num2 - 28f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			float num4 = num3 / 28f;
			obj3.final = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			object obj4 = 24;
			bool flag = !(num4 > 0f);
			extra_arg = unchecked((nint)6447293568L);
			flag2 = false;
			_003C_003Ec__DisplayClass17_0 target2 = obj3;
			if (!flag)
			{
				object obj5 = 500;
				flag2 = false;
				do
				{
					Action action = null;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ r10_v6 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(EME_Longsword1Weapon._003CFire_FireGlimmerProjectile_003Eb__17_0);
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ r10_v6 (Il2CppMethodInfo)+4C]");
					object obj6 = (nint)0 >> 4;
					object obj7 = obj6 & 1;
					nint num6;
					if (obj7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ r10_v6 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num6 = unchecked((nint)6447293664L);
							goto IL_02f9;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num6 = ((Delegate)action).method_ptr;
					goto IL_02f9;
					IL_02f9:
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					float duration = (float)obj5 * 0.001f;
					Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
					obj5 += 500;
				}
				while (num4 > (float)(flag2 ? 1 : 0));
				extra_arg = unchecked((nint)6447293568L);
				target2 = obj3;
			}
			action2 = null;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass17_0._003CFire_FireGlimmerProjectile_003Eb__1);
			((Delegate)action2).m_target = target2;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj8 = (nint)0 >> 4;
			object obj9 = obj8 & 1;
			nint num8;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ r10_v4 (Il2CppMethodInfo)+52]");
				bool flag3 = (nint)0 == 0;
				num8 = unchecked((nint)6447293664L);
				if (flag3)
				{
					goto IL_03c7;
				}
			}
			num8 = ((Delegate)action2).method_ptr;
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			goto IL_03c7;
		}
		FireSwallowSwing(pos, num2);
		return;
		IL_03c7:
		object obj10 = (flag2 ? 1 : 0) + 1;
		object obj11 = obj10 * 500;
		((Delegate)action2).extra_arg = extra_arg;
		float duration2 = (float)obj11 * 0.001f;
		Timer timer2 = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void FireSwallowSwing(Vector2 pos, float _amount)
	{
		//IL_004b: Expected O, but got I4
		//IL_0079: Invalid comparison between F4 and I4
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_028f: Expected I4, but got F4
		//IL_02bd: Invalid comparison between F4 and I4
		//IL_0142: Expected I, but got O
		//IL_0152: Expected O, but got I
		//IL_01d2: Expected O, but got I4
		//IL_018e: Expected O, but got I
		//IL_01c4: Expected O, but got I4
		//IL_0227: Expected O, but got Ref
		//IL_0227: Expected O, but got I4
		_003C_003Ec__DisplayClass18_0 obj = new _003C_003Ec__DisplayClass18_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_swallow, soundConfig, 100f, 5, num);
		if (!(_amount > 0f))
		{
			return;
		}
		bool flag = false;
		Vector3 direction = default(Vector3);
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Vector3 vector = default(Vector3);
		do
		{
			_003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass18_1();
			CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals9.Direction = direction;
			_ = 0;
			object obj2 = flag * swallowSliceInterval;
			bool flag3;
			object obj6;
			if ((nint)obj2 <= 0)
			{
				_003C_003Ec__DisplayClass18_0 obj3 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if (!flag2)
				{
					flag3 = false;
					goto IL_0310;
				}
				bool value = ((bool*)(flag2 ? 1 : 0))->m_value;
				nint num2 = (nint)typeof(EME_LongswordProjectile_SwallowSlice);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ r8_v12 (System.Boolean)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ r8_v12 (System.Boolean)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ rax_v38+FFFFFFF8+v606 @ rax_v34*8]");
					if (0 == (nint)typeof(EME_LongswordProjectile_SwallowSlice))
					{
						obj6 = 1;
						goto IL_02e5;
					}
				}
				obj6 = 0;
				goto IL_02e5;
			}
			CS_0024_003C_003E8__locals9.localIndex = (flag ? 1 : 0);
			Action onComplete = delegate
			{
				//IL_024f: Expected O, but got I4
				//IL_00fb: Expected I, but got O
				//IL_0109: Expected I, but got O
				//IL_0119: Expected O, but got I
				//IL_0199: Expected O, but got I4
				//IL_0155: Expected O, but got I
				//IL_018b: Expected O, but got I4
				//IL_01e9: Expected O, but got Ref
				//IL_0084->IL01ef: Incompatible stack heights: 1 vs 0
				//IL_00a6->IL01ef: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass18_0 obj7 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
				EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice;
				object obj12;
				EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice2;
				if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj7._003C_003E4__this != null)
				{
					GameObject gameObject = obj7._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj8 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj8 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass18_0 obj9 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj9._003C_003E4__this != null)
						{
							Vector2 pos2 = default(Vector2);
							eME_LongswordProjectile_SwallowSlice = (EME_LongswordProjectile_SwallowSlice)obj9._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals9.localIndex);
							if ((object)eME_LongswordProjectile_SwallowSlice != null)
							{
								nint num4 = (nint)eME_LongswordProjectile_SwallowSlice;
								nint num5 = (nint)typeof(EME_LongswordProjectile_SwallowSlice);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+C8]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
									if (0 == (nint)typeof(EME_LongswordProjectile_SwallowSlice))
									{
										obj12 = 1;
										goto IL_0271;
									}
								}
								obj12 = 0;
								goto IL_0271;
							}
							eME_LongswordProjectile_SwallowSlice2 = null;
							goto IL_0298;
						}
					}
				}
				throw new NullReferenceException();
				IL_0298:
				if ((object)eME_LongswordProjectile_SwallowSlice2 != null && ((UnityEngine.Object)eME_LongswordProjectile_SwallowSlice2).m_CachedPtr != (IntPtr)0)
				{
					object obj13 = default(object);
					eME_LongswordProjectile_SwallowSlice2.SetDirection((Vector3)(&obj13));
				}
				return;
				IL_0271:
				bool flag6 = obj12 == null;
				eME_LongswordProjectile_SwallowSlice2 = null;
				if (!flag6)
				{
					eME_LongswordProjectile_SwallowSlice2 = eME_LongswordProjectile_SwallowSlice;
				}
				goto IL_0298;
			};
			float duration = (float)obj2 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			goto IL_02a7;
			IL_0310:
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ rbx_v8 (System.Boolean)+10]");
				if ((nint)0 != 0)
				{
					((EME_LongswordProjectile_SwallowSlice)flag3).SetDirection((Vector3)(&vector));
				}
			}
			goto IL_02a7;
			IL_02a7:
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			continue;
			IL_02e5:
			bool flag4 = obj6 == null;
			flag3 = false;
			if (!flag4)
			{
				flag3 = flag2;
			}
			goto IL_0310;
		}
		while (_amount > (float)(flag ? 1 : 0));
	}

	protected override void InitGlimmer2BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer2Prefab = _Glimmer2Prefab;
		if ((object)_Glimmer2Prefab != null && ((UnityEngine.Object)glimmer2Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer2Pool = new BulletPool(_Glimmer2Prefab, 20);
			_glimmer2Pool = glimmer2Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer2Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Longsword1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer2Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 5f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	public unsafe void FireLSSlashes(Vector2 pos, Projectile parent, float __amount = 1f)
	{
		//IL_001d: Invalid comparison between F4 and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_00b2: Expected I, but got O
		//IL_00c2: Expected O, but got I
		//IL_0142: Expected O, but got I4
		//IL_0266: Invalid comparison between F4 and I4
		//IL_00fe: Expected O, but got I
		//IL_0134: Expected O, but got I4
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		obj.parent = parent;
		if (!(__amount > 0f))
		{
			return;
		}
		bool flag = false;
		bool flag2 = default(bool);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			object obj2 = flag * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			bool flag3;
			object obj5;
			if ((nint)obj2 <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if (!flag2)
				{
					flag3 = false;
					goto IL_02dd;
				}
				bool value = ((bool*)(flag2 ? 1 : 0))->m_value;
				nint num = (nint)typeof(EME_LongswordProjectile_Sprinkler);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ r9_v10 (System.Boolean)+130]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+130]");
				if (num2 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ r9_v10 (System.Boolean)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v37+FFFFFFF8+v519 @ rax_v33*8]");
					if (0 == (nint)typeof(EME_LongswordProjectile_Sprinkler))
					{
						obj5 = 1;
						goto IL_02b2;
					}
				}
				obj5 = 0;
				goto IL_02b2;
			}
			_003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass21_1();
			CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals10.localIndex = (flag ? 1 : 0);
			WeaponData currentWeaponData2 = _currentWeaponData;
			Action onComplete = delegate
			{
				//IL_027f: Expected O, but got I4
				//IL_0105: Expected I4, but got O
				//IL_0113: Expected I, but got O
				//IL_0123: Expected O, but got I
				//IL_01a3: Expected O, but got I4
				//IL_015f: Expected O, but got I
				//IL_0195: Expected O, but got I4
				//IL_0084->IL021f: Incompatible stack heights: 1 vs 0
				//IL_00a6->IL021f: Incompatible stack heights: 1 vs 0
				//IL_020a->IL021f: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass21_0 obj6 = CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1;
				GameObject gameObject2;
				object obj11;
				GameObject gameObject3;
				if (CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1 != null && (object)obj6._003C_003E4__this != null)
				{
					GameObject gameObject = obj6._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj7 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass21_0 obj8 = CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
						{
							int localIndex = CS_0024_003C_003E8__locals10.localIndex;
							Vector2 pos2 = default(Vector2);
							gameObject2 = (GameObject)(object)obj8._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals10.localIndex);
							if ((object)gameObject2 != null)
							{
								localIndex = (int)gameObject2;
								nint num4 = (nint)typeof(EME_LongswordProjectile_Sprinkler);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+130]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v6 (System.Int32)+130]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+130]");
								if (num5 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v6 (System.Int32)+C8]");
									object obj10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v36+FFFFFFF8+v411 @ rax_v32*8]");
									if (0 == (nint)typeof(EME_LongswordProjectile_Sprinkler))
									{
										obj11 = 1;
										goto IL_02a1;
									}
								}
								obj11 = 0;
								goto IL_02a1;
							}
							gameObject3 = null;
							goto IL_02c8;
						}
					}
				}
				goto IL_021f;
				IL_02a1:
				bool flag6 = obj11 == null;
				gameObject3 = null;
				if (!flag6)
				{
					gameObject3 = gameObject2;
				}
				goto IL_02c8;
				IL_02c8:
				if ((object)gameObject3 == null || ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				_003C_003Ec__DisplayClass21_0 obj12 = CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals10.CS_0024_003C_003E8__locals1 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180BA5BF0");
					return;
				}
				goto IL_021f;
				IL_021f:
				throw new NullReferenceException();
			};
			float num3 = (float)(flag ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
			float duration = num3 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			goto IL_0250;
			IL_02dd:
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rbx_v8 (System.Boolean)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180BA5BF0");
				}
			}
			goto IL_0250;
			IL_0250:
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			continue;
			IL_02b2:
			bool flag4 = obj5 == null;
			flag3 = false;
			if (!flag4)
			{
				flag3 = flag2;
			}
			goto IL_02dd;
		}
		while (__amount > (float)(flag ? 1 : 0));
	}

	private void _003CFire_FireGlimmerProjectile_003Eb__17_0()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		FireSwallowSwing(pos, 32f);
	}
}
