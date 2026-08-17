using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FixWiringWeapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__17_0;

		public static TweenCallback _003C_003E9__17_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__17_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__17_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public FixWiringProjectile _wire;

		public FixWiringWeapon _003C_003E4__this;

		public Action _003C_003E9__0;

		internal void _003CFire_003Eb__0()
		{
			_003C_003E4__this.fireSpark(_wire);
		}
	}

	private int currentLineNum;

	private List<FixWiringProjectile> _wireList;

	private List<uint> _colourList;

	private List<int> _remainingWireList;

	private List<float2> _wireLeftPosY;

	private List<float2> _wireRightPosY;

	private List<PhaserSprite> _leftSprites;

	private List<PhaserSprite> _rightSprites;

	private List<PhaserSprite> _endCapRightSprites;

	private MultiTargetTween alphaTween;

	public int failedAttempts;

	private BulletPool _wireSparkPool;

	private Timer _completeTimer;

	private Unity.Mathematics.Random _random;

	public override float SecondaryPPower()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+428]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+430]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_069f: Expected O, but got I4
		//IL_0069: Expected O, but got I
		//IL_0743: Invalid comparison between I4 and F4
		//IL_070c: Expected O, but got I4
		//IL_00ca: Expected O, but got I8
		//IL_07dd: Expected O, but got I4
		//IL_0151: Expected I, but got O
		//IL_015f: Expected I, but got O
		//IL_016f: Expected O, but got I
		//IL_01ef: Expected O, but got I4
		//IL_01ab: Expected O, but got I
		//IL_01e1: Expected O, but got I4
		//IL_047f: Expected O, but got I
		//IL_048f: Expected O, but got I
		//IL_04e9: Expected O, but got I
		//IL_0825: Expected O, but got I
		//IL_0835: Expected O, but got I
		//IL_0553: Expected O, but got I
		//IL_034e: Expected I, but got O
		//IL_0864: Expected O, but got I
		//IL_0874: Expected O, but got I
		//IL_05bd: Expected O, but got I
		//IL_089c: Expected O, but got I
		//IL_08ac: Expected O, but got I
		//IL_0627: Expected O, but got I
		//IL_03f1: Expected I, but got O
		//IL_0675: Expected F4, but got I4
		//IL_0675: Expected F4, but got O
		base.InitWeapon(characterController, weaponType);
		_random = (Unity.Mathematics.Random)0;
		GameManager core = GM.Core;
		MultiplayerManager multiplayer = core._multiplayer;
		uint num3 = default(uint);
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				multiplayer = (MultiplayerManager)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v547 @ rax_v103 (should have been resolved before IL gen)");
			if (0f > 1f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				float num = 1f;
				float num2 = 4.2949673E+09f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
				float num = 1f;
				float num2 = 4.2949673E+09f;
			}
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			num3 = instance._003CRandomEventsSeed_003Ek__BackingField;
		}
		int num4 = (int)(num3 << 13);
		int num5 = num4 ^ (int)num3;
		int num6 = num5 >> 17;
		int num7 = num5 ^ num6;
		int num8 = num7 << 5;
		Unity.Mathematics.Random random = (Unity.Mathematics.Random)(num8 ^ num7);
		_random = random;
		List<FixWiringProjectile> wireList = new List<FixWiringProjectile>();
		_wireList = wireList;
		int num9 = 0;
		do
		{
			List<object> wireList2 = (List<object>)(object)_wireList;
			Projectile projectile = base.FireOneProjectileIgnoreDistanceToPlayer((Vector2)0, num9);
			object item;
			if ((object)projectile == null)
			{
				item = null;
				goto IL_076e;
			}
			nint num10 = (nint)projectile;
			nint num11 = (nint)typeof(FixWiringProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rdx_v51 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FixWiringProjectile>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rdx_v51 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FixWiringProjectile>)+130]");
			object obj4;
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v96+FFFFFFF8+v890 @ rax_v92*8]");
				if (0 == (nint)typeof(FixWiringProjectile))
				{
					obj4 = 1;
					goto IL_07a0;
				}
			}
			obj4 = 0;
			goto IL_07a0;
			IL_07a0:
			bool flag = obj4 == null;
			item = null;
			if (!flag)
			{
				item = projectile;
			}
			goto IL_076e;
			IL_076e:
			int version = wireList2._version + 1;
			wireList2._version = version;
			ArcadePhysicsCallback items = (ArcadePhysicsCallback)(object)wireList2._items;
			if (wireList2._size >= (nint)((Delegate)items).invoke_impl)
			{
				wireList2.AddWithResize(item);
			}
			else
			{
				int size = wireList2._size + 1;
				wireList2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num9++;
		}
		while (num9 < 4);
		float? num14 = default(float?);
		CallbackContext callbackContext = default(CallbackContext);
		if (_wireSparkPool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.C1_SWIPECARD1_SPARK);
			BulletPool wireSparkPool = new BulletPool(projectilePrefab);
			_wireSparkPool = wireSparkPool;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+370]");
				ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num13 = (nint)this;
				Collider collider = physics.add.overlap(_wireSparkPool, core2.Enemies, collideCallback, (ArcadePhysicsCallback)num14, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					ArcadePhysics physics2 = s_scene2.physics;
					GameManager core3 = GM.Core;
					PhysicsManager physicsManager = core3._physicsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1254 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+3A0]");
					ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num15 = (nint)this;
					Collider collider2 = physics2.add.overlap(_wireSparkPool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)num14, callbackContext);
					num14 = num14;
					goto IL_0431;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0431;
		IL_0431:
		shufflePositions();
		drawSides();
		setWireCaps();
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v19+18]");
		if (num16 >= 0)
		{
			list.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj7 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v21+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v23+18]");
		if (num18 >= 0)
		{
			list.AddWithResize(2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj13 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v25+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 3;
		}
		_remainingWireList = list;
		PickNewTarget();
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_FixWireOpen, 500f, 10, 0f, num14, (float)callbackContext, detune, loop, 1f);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00d1: Invalid comparison between F4 and I4
		//IL_01cd: Invalid comparison between F4 and I4
		List<FixWiringProjectile> wireList = _wireList;
		bool flag = false;
		bool flag2 = false;
		float num2 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			if ((flag2 ? 1 : 0) < wireList._size)
			{
				_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass16_0();
				CS_0024_003C_003E8__locals8._003C_003E4__this = this;
				List<FixWiringProjectile> wireList2 = _wireList;
				if ((flag ? 1 : 0) >= wireList2._size)
				{
					break;
				}
				FixWiringProjectile[] items = wireList2._items;
				CS_0024_003C_003E8__locals8._wire = items[flag ? 1u : 0u];
				FixWiringProjectile wire = CS_0024_003C_003E8__locals8._wire;
				if (wire.Connected)
				{
					float num = base.PAmount();
					bool flag3 = !(num2 > 0f);
					bool flag4 = false;
					if (!flag3)
					{
						do
						{
							WeaponData currentWeaponData = _currentWeaponData;
							Action onComplete = CS_0024_003C_003E8__locals8._003C_003E9__0;
							if (CS_0024_003C_003E8__locals8._003C_003E9__0 == null)
							{
								onComplete = (CS_0024_003C_003E8__locals8._003C_003E9__0 = delegate
								{
									CS_0024_003C_003E8__locals8._003C_003E4__this.fireSpark(CS_0024_003C_003E8__locals8._wire);
								});
							}
							float num3 = 0f * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
							num2 = num3 * 0.001f;
							Timer timer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							flag4 = true;
							float num4 = base.PAmount();
						}
						while (num2 > (float)(flag4 ? 1 : 0));
					}
				}
				wireList = _wireList;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag2 = flag;
				continue;
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void ScreenShake()
	{
		//IL_00b3: Expected I, but got O
		//IL_0133: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 4;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__17_0;
		if (_003C_003Ec._003C_003E9__17_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__17_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__17_1;
		if (_003C_003Ec._003C_003E9__17_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__17_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public unsafe void LineComplete()
	{
		//IL_00ef: Expected O, but got Ref
		//IL_0421: Expected O, but got I4
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		//IL_045f: Expected O, but got I4
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_0570: Expected F4, but got I4
		//IL_04e1: Expected I4, but got F4
		//IL_04e1: Expected O, but got F4
		//IL_04e1: Expected I4, but got O
		List<int> remainingWireList = _remainingWireList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		bool flag;
		bool flag2;
		bool flag3;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805893E0");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				int num = failedAttempts + 1;
				failedAttempts = num;
				ScreenShake();
				List<FixWiringProjectile> wireList = _wireList;
				int num2 = currentLineNum;
				if (currentLineNum < wireList._size)
				{
					FixWiringProjectile[] items = wireList._items;
					items[num2].clearLine();
					List<FixWiringProjectile> wireList2 = _wireList;
					int num3 = currentLineNum;
					if (currentLineNum < wireList2._size)
					{
						FixWiringProjectile[] items2 = wireList2._items;
						FixWiringProjectile fixWiringProjectile = items2[num3];
						List<PhaserSprite> leftSprites = _leftSprites;
						int num4 = currentLineNum;
						if (currentLineNum < leftSprites._size)
						{
							PhaserSprite[] items3 = leftSprites._items;
							float2 position = items3[num4].position;
							object obj2 = (object)fixWiringProjectile._wireCap ^ (object)fixWiringProjectile._wireCap;
							object obj3 = (object)fixWiringProjectile._wireCap & obj2;
							flag = (nint)obj3 < 0;
							flag2 = (nint)fixWiringProjectile._wireCap < 0;
							flag3 = (object)fixWiringProjectile._wireCap == null;
							float2 position2 = default(float2);
							PhaserSprite phaserSprite = fixWiringProjectile._wireCap.setPosition(position2);
							goto IL_039f;
						}
					}
				}
				goto IL_0510;
			}
		}
		List<FixWiringProjectile> wireList3 = _wireList;
		int num5 = currentLineNum;
		failedAttempts = 0;
		if (currentLineNum < wireList3._size)
		{
			FixWiringProjectile[] items4 = wireList3._items;
			FixWiringProjectile fixWiringProjectile2 = items4[num5];
			fixWiringProjectile2.Connected = true;
			Transform transform = fixWiringProjectile2._wireCap.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
			PhaserSprite phaserSprite2 = fixWiringProjectile2._line.setAlpha(0.35f);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			object obj5 = (object)fixWiringProjectile2._line ^ (object)fixWiringProjectile2._line;
			object obj6 = (object)fixWiringProjectile2._line & obj5;
			flag = (nint)obj6 < 0;
			flag2 = (nint)fixWiringProjectile2._line < 0;
			flag3 = (object)fixWiringProjectile2._line == null;
			int depth = -renderer.pixelHeight;
			PhaserSprite phaserSprite3 = fixWiringProjectile2._line.setDepth(depth);
			goto IL_039f;
		}
		goto IL_0510;
		IL_0510:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_039f:
		object obj7 = (object)_random << 13;
		object obj8 = obj7 ^ (object)_random;
		object obj9 = obj8 >> 17;
		object obj10 = obj8 ^ obj9;
		object obj11 = obj10 << 5;
		Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj11 ^ obj10);
		_random = random;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag4 = flag2 == flag;
		object obj12 = !flag3;
		object obj13 = flag4 & obj12;
		SfxType sfxType;
		if (obj13 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			bool flag5 = flag2 == flag;
			object obj14 = !flag3;
			object obj15 = flag5 & obj14;
			sfxType = ((obj15 != null) ? SfxType.DLC3_FixWire2 : SfxType.DLC3_FixWire3);
		}
		else
		{
			sfxType = SfxType.DLC3_FixWire1;
		}
		float? num6 = default(float?);
		float num7 = default(float);
		float num8 = default(float);
		bool flag6 = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(sfxType, 500f, 10, 0f, num6, num7, num8, flag6, 1f);
		Action onComplete = delegate
		{
			checkIfAllLinesComplete();
		};
		Timer completeTimer = Timers.Register(0.05f, onComplete, null, isLooped: false, (byte)(int)num6 != 0, (MonoBehaviour)num7, (int)num8, flag6 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		_completeTimer = completeTimer;
	}

	public override void Cleanup()
	{
		//IL_00f7: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		base.Cleanup();
		if (_wireList != null)
		{
			List<FixWiringProjectile>.Enumerator enumerator = default(List<FixWiringProjectile>.Enumerator);
			if (enumerator.MoveNext())
			{
				FixWiringProjectile fixWiringProjectile = null;
				throw new NullReferenceException();
			}
			if (_leftSprites != null)
			{
				List<PhaserSprite>.Enumerator enumerator2 = default(List<PhaserSprite>.Enumerator);
				if (enumerator2.MoveNext())
				{
					PhaserSprite phaserSprite = null;
					throw new NullReferenceException();
				}
				if (_rightSprites != null)
				{
					List<PhaserSprite>.Enumerator enumerator3 = default(List<PhaserSprite>.Enumerator);
					if (enumerator3.MoveNext())
					{
						PhaserSprite phaserSprite = null;
						throw new NullReferenceException();
					}
					if (_endCapRightSprites != null)
					{
						List<PhaserSprite>.Enumerator enumerator4 = default(List<PhaserSprite>.Enumerator);
						if (enumerator4.MoveNext())
						{
							PhaserSprite phaserSprite = null;
							throw new NullReferenceException();
						}
						if (_wireSparkPool != null)
						{
							_wireSparkPool.Cleanup();
						}
						if (_completeTimer != null)
						{
							Timer completeTimer = _completeTimer;
							if (!_completeTimer.IsDone)
							{
								float timeElapsed = _completeTimer.GetTimeElapsed();
								completeTimer._timeElapsedBeforeCancel = (float?)(object)1;
								completeTimer._timeElapsedBeforePause = (float?)(object)0;
							}
						}
						if (alphaTween != null)
						{
							alphaTween.Kill();
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void shufflePositions()
	{
		//IL_002d: Expected O, but got I4
		//IL_0095: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01b1: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		List<float2> wireLeftPosY = new List<float2>();
		_wireLeftPosY = wireLeftPosY;
		List<float2> wireRightPosY = new List<float2>();
		_wireRightPosY = wireRightPosY;
		object obj = 1;
		float2 item = default(float2);
		while (true)
		{
			List<float2> wireLeftPosY2 = _wireLeftPosY;
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.height / 5f;
			float num2 = num * (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v15+18]");
			if (num3 >= 0)
			{
				wireLeftPosY2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v4 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				object obj3 = (nint)0 + (nint)1;
				_ = 0;
			}
			List<float2> wireRightPosY2 = _wireRightPosY;
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			float num4 = renderer3.height / 5f;
			float num5 = num4 * (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ r8_v10+18]");
			if (num6 >= 0)
			{
				wireRightPosY2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v7 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				object obj6 = (nint)0 + (nint)1;
				_ = renderer2.width;
			}
			obj++;
			object obj7 = obj - 1;
			if ((nint)obj7 >= 4)
			{
				Extensions.Shuffle(_wireLeftPosY, _random);
				Extensions.Shuffle(_wireRightPosY, _random);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void drawSides()
	{
		//IL_007d: Expected I, but got O
		//IL_0225: Expected O, but got I4
		//IL_022e: Expected O, but got I4
		//IL_00d5: Expected I, but got O
		//IL_012d: Expected I, but got O
		//IL_0191: Expected O, but got I4
		//IL_032c: Expected O, but got I
		//IL_0362: Expected O, but got I4
		//IL_04a5: Expected O, but got I
		//IL_04db: Expected O, but got I4
		//IL_05e9: Expected O, but got Ref
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Expected O, but got Unknown
		if (_leftSprites != null)
		{
			if (alphaTween != null)
			{
				alphaTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[3];
			if (_leftSprites != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_087c;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (_rightSprites != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (_endCapRightSprites != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			alphaTween = multiTargetTween;
			return;
		}
		List<PhaserSprite> leftSprites = new List<PhaserSprite>();
		_leftSprites = leftSprites;
		List<PhaserSprite> rightSprites = new List<PhaserSprite>();
		_rightSprites = rightSprites;
		List<PhaserSprite> endCapRightSprites = new List<PhaserSprite>();
		_endCapRightSprites = endCapRightSprites;
		List<FixWiringProjectile> wireList = _wireList;
		object obj4 = 0;
		object obj5 = 0;
		Vector2 vector = default(Vector2);
		Vector2 vector2 = default(Vector2);
		while (true)
		{
			if ((nint)obj5 >= wireList._size)
			{
				return;
			}
			PhaserWorld instance = PhaserWorld.Instance;
			List<float2> wireLeftPosY = _wireLeftPosY;
			object obj6 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rcx_v22 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)obj6 >= 0)
			{
				break;
			}
			PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "vfx", "wire_Greyscale_Start");
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				int depth = renderer.pixelHeight - 1;
				PhaserSprite phaserSprite2 = phaserSprite.setDepth(depth);
				List<uint> colourList = _colourList;
				object obj7 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v22 (System.Collections.Generic.List`1<System.UInt32>)+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v22 (System.Collections.Generic.List`1<System.UInt32>)+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rdx_v23+20+v348 @ rbx_v10*4]");
				PhaserSprite phaserSprite3 = phaserSprite2.setTint(0u);
				PhaserSprite component = phaserSprite3.setOrigin(0f, (float?)(object)1);
				PhaserSprite phaserSprite4 = RenderingExtensions.SetScrollFactor(component, 0f);
				GameObject gameObject = phaserSprite4.gameObject;
				((UnityEngine.Object)gameObject).SetName("FixWiringWeapon - LeftSprite");
				PhaserWorld instance2 = PhaserWorld.Instance;
				List<float2> wireRightPosY = _wireRightPosY;
				object obj9 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rcx_v38 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj9 >= 0)
				{
					break;
				}
				PhaserSprite phaserSprite5 = instance2.AddPhaserSprite(vector, "vfx", "wire_Greyscale_End");
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer2 = s_scene2._renderer;
					int depth2 = renderer2.pixelHeight - 1;
					PhaserSprite phaserSprite6 = phaserSprite5.setDepth(depth2);
					List<uint> colourList2 = _colourList;
					object obj10 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v32 (System.Collections.Generic.List`1<System.UInt32>)+18]");
					if ((nint)obj10 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v32 (System.Collections.Generic.List`1<System.UInt32>)+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rdx_v33+20+v348 @ rbx_v10*4]");
					PhaserSprite phaserSprite7 = phaserSprite6.setTint(0u);
					PhaserSprite component2 = phaserSprite7.setOrigin(1f, (float?)(object)1);
					PhaserSprite phaserSprite8 = RenderingExtensions.SetScrollFactor(component2, 0f);
					GameObject gameObject2 = phaserSprite8.gameObject;
					((UnityEngine.Object)gameObject2).SetName("FixWiringWeapon - RightSprite");
					PhaserWorld instance3 = PhaserWorld.Instance;
					List<float2> wireRightPosY2 = _wireRightPosY;
					object obj12 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rcx_v51 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					if ((nint)obj12 >= 0)
					{
						break;
					}
					PhaserSprite phaserSprite9 = instance3.AddPhaserSprite(vector, "vfx", "wire_CopperEnd");
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer3 = s_scene3._renderer;
						PhaserSprite phaserSprite10 = phaserSprite9.setDepth(renderer3.pixelHeight);
						Transform transform = phaserSprite10.transform;
						transform.localEulerAngles = (Vector3)(&vector2);
						PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor(phaserSprite10, 0f);
						GameObject gameObject3 = phaserSprite11.gameObject;
						((UnityEngine.Object)gameObject3).SetName("FixWiringWeapon - endCapRightSprite");
						List<object> leftSprites2 = (List<object>)(object)_leftSprites;
						int version = leftSprites2._version + 1;
						leftSprites2._version = version;
						object[] items = leftSprites2._items;
						if (leftSprites2._size >= items.Length)
						{
							leftSprites2.AddWithResize((object)phaserSprite4);
						}
						else
						{
							int size = leftSprites2._size + 1;
							leftSprites2._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						List<object> rightSprites2 = (List<object>)(object)_rightSprites;
						int version2 = rightSprites2._version + 1;
						rightSprites2._version = version2;
						object[] items2 = rightSprites2._items;
						if (rightSprites2._size >= items2.Length)
						{
							rightSprites2.AddWithResize((object)phaserSprite8);
						}
						else
						{
							int size2 = rightSprites2._size + 1;
							rightSprites2._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						List<object> endCapRightSprites2 = (List<object>)(object)_endCapRightSprites;
						int version3 = endCapRightSprites2._version + 1;
						endCapRightSprites2._version = version3;
						object[] items3 = endCapRightSprites2._items;
						if (endCapRightSprites2._size >= items3.Length)
						{
							endCapRightSprites2.AddWithResize((object)phaserSprite11);
						}
						else
						{
							int size3 = endCapRightSprites2._size + 1;
							endCapRightSprites2._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						wireList = _wireList;
						obj4++;
						vector2 = vector;
						obj5 = obj4;
						continue;
					}
				}
			}
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_087c;
		IL_087c:
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	private unsafe void shuffleWirePositions()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0016: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_063f: Expected I, but got O
		//IL_0656: Expected O, but got I
		//IL_06a0: Expected I, but got O
		//IL_06f4: Expected I, but got O
		//IL_0785: Expected O, but got I
		//IL_0e26: Expected I, but got O
		//IL_0e3c: Expected O, but got I
		//IL_0e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4a: Expected O, but got Unknown
		//IL_081c: Expected I, but got O
		//IL_0e70: Expected O, but got I4
		//IL_0e87: Expected I, but got I8
		//IL_07f8: Expected I, but got I8
		//IL_0a19: Expected O, but got Ref
		//IL_0be7: Expected O, but got Ref
		//IL_0cec: Expected I, but got O
		//IL_0da9: Expected O, but got Ref
		//IL_0dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd6: Expected O, but got Unknown
		//IL_009d->IL0843: Incompatible stack heights: 1 vs 0
		//IL_066f->IL066f: Incompatible stack heights: 1 vs 0
		//IL_06c3->IL06c3: Incompatible stack heights: 1 vs 0
		//IL_0717->IL0717: Incompatible stack heights: 1 vs 0
		//IL_0ec7->IL0843: Incompatible stack heights: 1 vs 0
		//IL_08ef->IL0843: Incompatible stack heights: 2 vs 0
		//IL_0948->IL0843: Incompatible stack heights: 3 vs 0
		//IL_00fe->IL0843: Incompatible stack heights: 4 vs 0
		//IL_011c->IL0843: Incompatible stack heights: 4 vs 0
		//IL_096f->IL0843: Incompatible stack heights: 4 vs 0
		//IL_0143->IL0843: Incompatible stack heights: 4 vs 0
		//IL_0161->IL0843: Incompatible stack heights: 4 vs 0
		//IL_0996->IL0843: Incompatible stack heights: 4 vs 0
		//IL_0189->IL0843: Incompatible stack heights: 4 vs 0
		//IL_01b1->IL0843: Incompatible stack heights: 4 vs 0
		//IL_01ff->IL0843: Incompatible stack heights: 4 vs 0
		//IL_0a52->IL0843: Incompatible stack heights: 7 vs 0
		//IL_026d->IL0843: Incompatible stack heights: 8 vs 0
		//IL_0efa->IL0843: Incompatible stack heights: 8 vs 0
		//IL_0ab7->IL0843: Incompatible stack heights: 9 vs 0
		//IL_0b16->IL0843: Incompatible stack heights: 10 vs 0
		//IL_02ce->IL0843: Incompatible stack heights: 11 vs 0
		//IL_02ec->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0b3d->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0313->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0331->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0b64->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0359->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0381->IL0843: Incompatible stack heights: 11 vs 0
		//IL_03cf->IL0843: Incompatible stack heights: 11 vs 0
		//IL_0c20->IL0843: Incompatible stack heights: 14 vs 0
		//IL_043d->IL0843: Incompatible stack heights: 15 vs 0
		//IL_0f2d->IL0843: Incompatible stack heights: 15 vs 0
		//IL_0c85->IL0843: Incompatible stack heights: 16 vs 0
		//IL_0cde->IL0843: Incompatible stack heights: 17 vs 0
		//IL_049e->IL0843: Incompatible stack heights: 18 vs 0
		//IL_04bc->IL0843: Incompatible stack heights: 18 vs 0
		//IL_0d05->IL0843: Incompatible stack heights: 18 vs 0
		//IL_04e6->IL0843: Incompatible stack heights: 18 vs 0
		//IL_0504->IL0843: Incompatible stack heights: 18 vs 0
		//IL_0d2c->IL0843: Incompatible stack heights: 18 vs 0
		//IL_052c->IL0843: Incompatible stack heights: 18 vs 0
		//IL_0554->IL0843: Incompatible stack heights: 18 vs 0
		//IL_05a2->IL0843: Incompatible stack heights: 18 vs 0
		//IL_0df0->IL0843: Incompatible stack heights: 21 vs 0
		//IL_05d3->IL0df5: Incompatible stack heights: 21 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Extensions.Shuffle(_wireLeftPosY, _random);
		Extensions.Shuffle(_wireRightPosY, _random);
		List<FixWiringProjectile> wireList = _wireList;
		if (_wireList != null)
		{
			object obj3 = 0;
			nint num = 0;
			object obj4 = 0;
			object obj10 = default(object);
			object obj11 = default(object);
			object obj12 = default(object);
			while (true)
			{
				if ((nint)obj4 < wireList._size)
				{
					List<PhaserSprite> leftSprites = _leftSprites;
					if (_leftSprites == null)
					{
						break;
					}
					bool flag = (nint)obj3 >= leftSprites._size;
					PhaserSprite[] items = leftSprites._items;
					if (leftSprites._items == null)
					{
						break;
					}
					IntPtr main_Injected = Camera.get_main_Injected();
					Camera camera = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected);
					if ((object)camera == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)camera).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					List<float2> wireLeftPosY = _wireLeftPosY;
					if (_wireLeftPosY == null)
					{
						break;
					}
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v137 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag4 = (nint)obj5 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v137 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					if ((nint)0 == 0 || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene._renderer == null || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene2._renderer == null || (object)items[obj3] == null)
					{
						break;
					}
					Transform transform2 = items[obj3].transform;
					Transform transform3 = items[obj3].transform;
					if ((object)transform3 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v169 (UnityEngine.Transform)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v169 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					bool flag6 = (object)transform2 == null;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ rax_v168 (UnityEngine.Transform)+10]");
					bool flag7 = (nint)0 == 0;
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2785 @ rax_v168 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj6);
					List<PhaserSprite> rightSprites = _rightSprites;
					if (_rightSprites == null)
					{
						break;
					}
					bool flag8 = (nint)obj3 >= rightSprites._size;
					PhaserSprite[] items2 = rightSprites._items;
					if (rightSprites._items == null)
					{
						break;
					}
					IntPtr main_Injected2 = Camera.get_main_Injected();
					Camera camera2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected2);
					if ((object)camera2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v184 (UnityEngine.Camera)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v184 (UnityEngine.Camera)+10]");
					IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					if ((object)transform4 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v189 (UnityEngine.Transform)+10]");
					bool flag10 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v189 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					List<float2> wireRightPosY = _wireRightPosY;
					if (_wireRightPosY == null)
					{
						break;
					}
					object obj7 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rcx_v163 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag11 = (nint)obj7 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rcx_v163 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					if ((nint)0 == 0 || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene3._renderer == null || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene4._renderer == null || (object)items2[obj3] == null)
					{
						break;
					}
					Transform transform5 = items2[obj3].transform;
					Transform transform6 = items2[obj3].transform;
					if ((object)transform6 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v205 (UnityEngine.Transform)+10]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v205 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					bool flag13 = (object)transform5 == null;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4116 @ rax_v204 (UnityEngine.Transform)+10]");
					bool flag14 = (nint)0 == 0;
					object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4116 @ rax_v204 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj8);
					List<PhaserSprite> endCapRightSprites = _endCapRightSprites;
					if (_endCapRightSprites == null)
					{
						break;
					}
					bool flag15 = (nint)obj3 >= endCapRightSprites._size;
					PhaserSprite[] items3 = endCapRightSprites._items;
					if (endCapRightSprites._items == null)
					{
						break;
					}
					IntPtr main_Injected3 = Camera.get_main_Injected();
					Camera camera3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected3);
					if ((object)camera3 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v220 (UnityEngine.Camera)+10]");
					bool flag16 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v220 (UnityEngine.Camera)+10]");
					IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
					Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					if ((object)transform7 == null)
					{
						break;
					}
					bool flag17 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out Vector3 _);
					List<float2> wireRightPosY2 = _wireRightPosY;
					if (_wireRightPosY == null)
					{
						break;
					}
					object obj9 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v231 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag18 = (nint)obj9 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v231 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					if ((nint)0 == 0 || (object)GM.Core == null)
					{
						break;
					}
					num = (nint)ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ r8_v39 (Il2CppMethodInfo)+28]");
					if ((nint)0 == 0 || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene5 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene5._renderer == null || (object)items3[obj3] == null)
					{
						break;
					}
					Transform transform8 = items3[obj3].transform;
					Transform transform9 = items3[obj3].transform;
					if ((object)transform9 == null)
					{
						break;
					}
					bool flag19 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, out Vector3 _);
					bool flag20 = (object)transform8 == null;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4356 @ rax_v241 (UnityEngine.Transform)+10]");
					bool flag21 = (nint)0 == 0;
					Unity.Mathematics.Random random = (Unity.Mathematics.Random)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4356 @ rax_v241 (UnityEngine.Transform)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)random);
					wireList = _wireList;
					obj3++;
					if (_wireList == null)
					{
						break;
					}
					obj4 = obj3;
					continue;
				}
				setWireCaps();
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[3];
				if (array == null)
				{
					break;
				}
				if (_leftSprites != null)
				{
					nint num2 = (nint)array;
					List<PhaserSprite> leftSprites2 = _leftSprites;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rcx_v124 (Il2CppClass<UnityEngine.Camera>)+40]");
					Extensions.Shuffle((IList<float2>)leftSprites2, (Unity.Mathematics.Random)0);
					bool flag22 = obj10 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (_rightSprites != null)
				{
					nint num3 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag23 = obj11 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (_endCapRightSprites != null)
				{
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag24 = obj12 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig == null)
				{
					break;
				}
				tweenConfig.targets = array;
				_ = 0;
				tweenConfig.duration = 200f;
				_ = 1065353216;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
				tweenConfig.alpha = (float?)(object)0;
				TweenCallback tweenCallback = null;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ r10_v1 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(FixWiringWeapon._003CshuffleWirePositions_003Eb__22_0);
				((Delegate)tweenCallback).m_target = this;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ r10_v1 (Il2CppMethodInfo)+4C]");
				object obj13 = (nint)0 >> 4;
				object obj14 = obj13 & 1;
				nint num6;
				if (obj14 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ r10_v1 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num6 = unchecked((nint)6447293664L);
						goto IL_0e67;
					}
				}
				num6 = ((Delegate)tweenCallback).method_ptr;
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				goto IL_0e67;
				IL_0e67:
				object obj15 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				tweenConfig.onComplete = tweenCallback;
				MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
				alphaTween = multiTargetTween;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void setWireCaps()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_008f->IL01fd: Incompatible stack heights: 1 vs 0
		//IL_00c9->IL01fd: Incompatible stack heights: 1 vs 0
		//IL_0118->IL01fd: Incompatible stack heights: 2 vs 0
		//IL_013e->IL01fd: Incompatible stack heights: 2 vs 0
		//IL_0171->IL01fd: Incompatible stack heights: 2 vs 0
		//IL_027e->IL01fd: Incompatible stack heights: 3 vs 0
		//IL_019d->IL01fd: Incompatible stack heights: 3 vs 0
		//IL_01ea->IL01fd: Incompatible stack heights: 3 vs 0
		//IL_01fc->IL0283: Incompatible stack heights: 3 vs 0
		List<FixWiringProjectile> wireList = _wireList;
		if (_wireList != null)
		{
			object obj = 0;
			object obj2 = 0;
			float2 position = default(float2);
			while (true)
			{
				if ((nint)obj2 < wireList._size)
				{
					List<FixWiringProjectile> wireList2 = _wireList;
					if (_wireList == null)
					{
						break;
					}
					bool flag = (nint)obj >= wireList2._size;
					FixWiringProjectile[] items = wireList2._items;
					if (wireList2._items == null)
					{
						break;
					}
					FixWiringProjectile fixWiringProjectile = items[obj];
					List<PhaserSprite> leftSprites = _leftSprites;
					if (_leftSprites == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= leftSprites._size;
					PhaserSprite[] items2 = leftSprites._items;
					if (leftSprites._items == null || (object)items2[obj] == null)
					{
						break;
					}
					Transform transform = items2[obj].transform;
					if ((object)transform == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)items[obj] == null || (object)fixWiringProjectile._wireCap == null)
					{
						break;
					}
					PhaserSprite phaserSprite = fixWiringProjectile._wireCap.setPosition(position);
					wireList = _wireList;
					obj++;
					if (_wireList == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void fireSpark(FixWiringProjectile wire, float speedMultiplier = 1f)
	{
		//IL_03c9: Expected O, but got I4
		//IL_0079: Expected I, but got O
		//IL_0087: Expected I, but got O
		//IL_0097: Expected O, but got I
		//IL_0117: Expected O, but got I4
		//IL_00d3: Expected O, but got I
		//IL_0109: Expected O, but got I4
		//IL_0029->IL036b: Incompatible stack heights: 1 vs 0
		//IL_017c->IL036b: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL036b: Incompatible stack heights: 1 vs 0
		//IL_01fc->IL036b: Incompatible stack heights: 2 vs 0
		//IL_0244->IL036b: Incompatible stack heights: 3 vs 0
		//IL_0290->IL036b: Incompatible stack heights: 3 vs 0
		//IL_02e4->IL036b: Incompatible stack heights: 4 vs 0
		//IL_032c->IL036b: Incompatible stack heights: 5 vs 0
		//IL_036a->IL036a: Incompatible stack heights: 5 vs 1
		GameObject gameObject = base.gameObject;
		Projectile projectile;
		float2 float5 = default(float2);
		GameObject gameObject2;
		object obj4;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if (_wireSparkPool != null)
			{
				projectile = _wireSparkPool.SpawnAt(float5, this);
				if ((object)projectile == null)
				{
					gameObject2 = null;
					goto IL_0412;
				}
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(FixWiringSparkProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FixWiringSparkProjectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FixWiringSparkProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v40+FFFFFFF8+v577 @ rax_v36*8]");
					if (0 == (nint)typeof(FixWiringSparkProjectile))
					{
						obj4 = 1;
						goto IL_03eb;
					}
				}
				obj4 = 0;
				goto IL_03eb;
			}
		}
		goto IL_036b;
		IL_03eb:
		bool flag2 = obj4 == null;
		gameObject2 = null;
		if (!flag2)
		{
			gameObject2 = (GameObject)(object)projectile;
		}
		goto IL_0412;
		IL_0412:
		if ((object)gameObject2 == null || ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<PhaserSprite> leftSprites = _leftSprites;
		if ((object)wire != null)
		{
			int num4 = wire.Num;
			if (_leftSprites != null)
			{
				bool flag3 = wire.Num >= leftSprites._size;
				PhaserSprite[] items = leftSprites._items;
				if (leftSprites._items != null)
				{
					bool flag4 = wire.Num >= items.Length;
					if ((object)items[num4] != null)
					{
						float2 position = items[num4].position;
						List<PhaserSprite> rightSprites = _rightSprites;
						int num5 = wire.Num;
						if (_rightSprites != null)
						{
							bool flag5 = wire.Num >= rightSprites._size;
							PhaserSprite[] items2 = rightSprites._items;
							if (rightSprites._items != null)
							{
								bool flag6 = wire.Num >= items2.Length;
								if ((object)items2[num5] != null)
								{
									float2 position2 = items2[num5].position;
									float speedMultiplier2 = default(float);
									((FixWiringSparkProjectile)(object)gameObject2).Pulse(float5, float5, wire.Color, speedMultiplier2);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_036b;
		IL_036b:
		throw new NullReferenceException();
	}

	private void PickNewTarget()
	{
		//IL_003d: Expected O, but got I
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0278: Expected O, but got I
		//IL_0495: Expected O, but got I
		//IL_028d: Expected O, but got I
		//IL_0338: Expected O, but got I
		Extensions.Shuffle(_remainingWireList, _random);
		List<int> remainingWireList = _remainingWireList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
		int num;
		FixWiringProjectile[] items;
		uint color;
		float2 to;
		float2 float5;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v10+20]");
			num = 0;
			List<FixWiringProjectile> wireList = _wireList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v10+20]");
			currentLineNum = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v10+20]");
			if ((nint)0 < (nint)wireList._size)
			{
				items = wireList._items;
				object obj2 = (object)_random << 13;
				object obj3 = obj2 ^ (object)_random;
				object obj4 = (object)_random >> 9;
				object obj5 = obj4 | 0x3F800000;
				object obj6 = obj3 >> 17;
				object obj7 = obj3 ^ obj6;
				object obj8 = obj7 << 5;
				Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj8 ^ obj7);
				_random = random;
				WeaponData currentWeaponData = _currentWeaponData;
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
				List<int> remainingWireList2 = _remainingWireList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v20 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 != 1)
				{
					float num3 = (float)obj5 - 1f;
					float num5 = default(float);
					float num4 = num5 * currentWeaponData._003CcritChance_003Ek__BackingField;
					if (!(num4 > num3))
					{
						List<PhaserSprite> leftSprites = _leftSprites;
						int num6 = currentLineNum;
						if (currentLineNum < leftSprites._size)
						{
							PhaserSprite[] items2 = leftSprites._items;
							float2 position = items2[num6].position;
							List<PhaserSprite> rightSprites = _rightSprites;
							List<int> remainingWireList3 = _remainingWireList;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v31 (System.Collections.Generic.List`1<System.Int32>)+18]");
							if ((nint)0 > (nint)1)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v31 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v32+24]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v32+24]");
								if ((nint)0 < (nint)rightSprites._size)
								{
									PhaserSprite[] items3 = rightSprites._items;
									float2 position2 = items3[obj10].position;
									int num7 = currentLineNum;
									List<uint> colourList = _colourList;
									int num8 = currentLineNum;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v34 (System.Collections.Generic.List`1<System.UInt32>)+18]");
									if ((nint)num8 < (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v34 (System.Collections.Generic.List`1<System.UInt32>)+10]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v15+20+v72 @ r8_v8 (System.Int32)*4]");
										color = 0u;
										to = position2;
										float5 = position;
										goto IL_04e5;
									}
								}
							}
						}
						goto IL_04df;
					}
				}
				bool flag = remainingWireList2.Remove(currentLineNum);
				List<PhaserSprite> leftSprites2 = _leftSprites;
				int num9 = currentLineNum;
				if (currentLineNum < leftSprites2._size)
				{
					PhaserSprite[] items4 = leftSprites2._items;
					float2 position3 = items4[num9].position;
					List<PhaserSprite> rightSprites2 = _rightSprites;
					int num10 = currentLineNum;
					if (currentLineNum < rightSprites2._size)
					{
						PhaserSprite[] items5 = rightSprites2._items;
						float2 position4 = items5[num10].position;
						int num11 = currentLineNum;
						List<uint> colourList2 = _colourList;
						int num12 = currentLineNum;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v28 (System.Collections.Generic.List`1<System.UInt32>)+18]");
						if ((nint)num12 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v28 (System.Collections.Generic.List`1<System.UInt32>)+10]");
							object obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v22+20+v98 @ rdx_v11 (System.Int32)*4]");
							color = 0u;
							to = position4;
							float5 = position3;
							goto IL_04e5;
						}
					}
				}
			}
		}
		goto IL_04df;
		IL_04e5:
		int num13 = default(int);
		items[num].startLine(float5, to, color, num13);
		return;
		IL_04df:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void checkIfAllLinesComplete()
	{
		//IL_0069: Expected F4, but got I4
		//IL_014a: Expected O, but got I4
		//IL_0153: Invalid comparison between F4 and I4
		//IL_02c1: Expected I, but got O
		//IL_02d7: Expected O, but got I
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_0353: Expected I, but got O
		//IL_01be: Expected I, but got O
		//IL_01d4: Expected O, but got I
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_045d: Expected I, but got I8
		//IL_04bd: Expected I4, but got F4
		//IL_04bd: Expected O, but got F4
		//IL_04bd: Expected I4, but got O
		//IL_0326: Expected I, but got I8
		//IL_024b: Expected I, but got O
		//IL_03a8: Expected I, but got I8
		//IL_03f9: Expected I4, but got F4
		//IL_03f9: Expected O, but got F4
		//IL_03f9: Expected I4, but got O
		//IL_0413: Invalid comparison between F4 and I4
		//IL_0118: Expected O, but got I4
		//IL_0234: Expected I, but got I8
		List<int> remainingWireList = _remainingWireList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)0 != 0)
		{
			PickNewTarget();
			return;
		}
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_TaskComplete, 1300f, 10, 0f, num, num2, num3, flag, 1f);
		List<FixWiringProjectile> wireList = _wireList;
		Action<float> action = null;
		List<FixWiringProjectile> wireList2 = _wireList;
		bool flag2 = false;
		bool flag3 = default(bool);
		while (true)
		{
			if ((nint)action < wireList._size)
			{
				if ((flag2 ? 1 : 0) >= wireList2._size)
				{
					break;
				}
				FixWiringProjectile[] items = wireList2._items;
				FixWiringProjectile fixWiringProjectile = items[flag2 ? 1u : 0u];
				fixWiringProjectile.Connected = false;
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				wireList2 = _wireList;
				action = (Action<float>)flag2;
				wireList = _wireList;
				continue;
			}
			float num4 = base.PAmount();
			float num5 = (float)(flag3 ? 1 : 0) * 8f;
			object obj = 24;
			bool flag4 = !(num5 > 0f);
			bool flag5 = false;
			if (!flag4)
			{
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					Action action2 = null;
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r10_v5 (Il2CppMethodInfo)+8]");
					((Delegate)action2).method_ptr = (IntPtr)0;
					((Delegate)action2).method = (nint)__ldftn(FixWiringWeapon._003CcheckIfAllLinesComplete_003Eb__26_1);
					((Delegate)action2).m_target = this;
					((Delegate)action2).method_code = (IntPtr)action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r10_v5 (Il2CppMethodInfo)+4C]");
					object obj2 = (nint)0 >> 4;
					object obj3 = obj2 & 1;
					nint num7;
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r10_v5 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num7 = unchecked((nint)6447293664L);
							goto IL_0391;
						}
					}
					((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
					num7 = ((Delegate)action2).method_ptr;
					goto IL_0391;
					IL_0391:
					((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
					float num8 = (float)(flag5 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					float duration = num8 * 0.001f;
					Timer timer = Timers.Register(duration, action2, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
				}
				while (num5 > (float)(flag5 ? 1 : 0));
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			float num9 = base.PSpeed();
			Action action3 = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v7 (Il2CppMethodInfo)+8]");
			((Delegate)action3).method_ptr = (IntPtr)0;
			((Delegate)action3).method = (nint)__ldftn(FixWiringWeapon._003CcheckIfAllLinesComplete_003Eb__26_0);
			((Delegate)action3).m_target = this;
			((Delegate)action3).method_code = (IntPtr)action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v7 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num11;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v7 (Il2CppMethodInfo)+52]");
				bool flag6 = (nint)0 == 0;
				num11 = unchecked((nint)6447293664L);
				if (flag6)
				{
					goto IL_0436;
				}
			}
			num11 = ((Delegate)action3).method_ptr;
			((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
			goto IL_0436;
			IL_0436:
			float num12 = 2000f / (float)(flag5 ? 1 : 0);
			((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
			float num13 = currentWeaponData2._003CrepeatInterval_003Ek__BackingField * num5;
			float num14 = num12 + num13;
			float duration2 = num14 * 0.001f;
			Timer timer2 = Timers.Register(duration2, action3, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void HideWeapon()
	{
		//IL_0047: Expected O, but got I
		//IL_0057: Expected O, but got I
		//IL_00d1: Expected O, but got I
		//IL_0576: Expected O, but got I
		//IL_0586: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_05d5: Expected O, but got I
		//IL_05e5: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_063d: Expected O, but got I
		//IL_020f: Expected O, but got I
		//IL_0257: Expected F4, but got I4
		//IL_02cf: Expected I, but got O
		//IL_0327: Expected I, but got O
		//IL_037f: Expected I, but got O
		//IL_03ed: Expected O, but got I4
		//IL_06ba: Expected I, but got O
		//IL_06d0: Expected O, but got I
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06de: Expected O, but got Unknown
		//IL_0492: Expected I, but got O
		//IL_0704: Expected O, but got I4
		//IL_071b: Expected I, but got I8
		//IL_046e: Expected I, but got I8
		bool flag = _wireList == null;
		List<int> list = (List<int>)(object)this;
		TweenConfig tweenConfig;
		TweenCallback tweenCallback;
		if (!flag)
		{
			List<FixWiringProjectile>.Enumerator enumerator = default(List<FixWiringProjectile>.Enumerator);
			if (enumerator.MoveNext())
			{
				FixWiringProjectile fixWiringProjectile = null;
				throw new NullReferenceException();
			}
			List<int> list2 = new List<int>();
			bool flag2 = list2 == null;
			list = list2;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
				list = (List<int>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v14+18]");
					if (num >= 0)
					{
						list2.AddWithResize(0);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj2 = (nint)0 + (nint)1;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
					list = (List<int>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v16+18]");
						if (num2 >= 0)
						{
							list2.AddWithResize(1);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj4 = (nint)0 + (nint)1;
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
						list = (List<int>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v18+18]");
							if (num3 >= 0)
							{
								list2.AddWithResize(2);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj6 = (nint)0 + (nint)1;
								_ = 2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
							list = (List<int>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v20+18]");
								if (num4 >= 0)
								{
									list2.AddWithResize(3);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
									object obj8 = (nint)0 + (nint)1;
									_ = 3;
								}
								_remainingWireList = list2;
								float? volume = default(float?);
								float rate = default(float);
								float detune = default(float);
								bool loop = default(bool);
								PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_FixWireClose, 500f, 10, 0f, volume, rate, detune, loop, 1f);
								tweenConfig = new TweenConfig();
								object[] array = new object[3];
								bool flag3 = array == null;
								list = (List<int>)(object)typeof(object[]);
								if (!flag3)
								{
									if (_leftSprites != null)
									{
										nint num5 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj9 = default(object);
										if (obj9 == null)
										{
											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
											throw ex;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (_rightSprites != null)
									{
										nint num6 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj10 = default(object);
										if (obj10 == null)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (_endCapRightSprites != null)
									{
										nint num7 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj11 = default(object);
										if (obj11 == null)
										{
											ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
											throw ex3;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										tweenConfig.targets = array;
										tweenConfig.alpha = (float?)(object)1;
										tweenConfig.duration = 200f;
										tweenCallback = null;
										nint num8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ r10_v1 (Il2CppMethodInfo)+8]");
										((Delegate)tweenCallback).method_ptr = (IntPtr)0;
										((Delegate)tweenCallback).method = (nint)__ldftn(FixWiringWeapon._003CHideWeapon_003Eb__27_0);
										((Delegate)tweenCallback).m_target = this;
										((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ r10_v1 (Il2CppMethodInfo)+4C]");
										object obj12 = (nint)0 >> 4;
										object obj13 = obj12 & 1;
										nint num9;
										if (obj13 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ r10_v1 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num9 = unchecked((nint)6447293664L);
												goto IL_06fb;
											}
										}
										num9 = ((Delegate)tweenCallback).method_ptr;
										((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
										goto IL_06fb;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_06fb:
		object obj14 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		tweenConfig.onComplete = tweenCallback;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		alphaTween = multiTargetTween;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0237: Expected I4, but got O
		//IL_00f7: Expected I, but got O
		//IL_00ff: Expected I, but got O
		//IL_010f: Expected O, but got I
		//IL_018f: Expected O, but got I4
		//IL_014b: Expected O, but got I
		//IL_0181: Expected O, but got I4
		EnemyController component;
		Projectile component2;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0254;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								nint num = (nint)typeof(FixWiringProjectile);
								nint num2 = (nint)component2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FixWiringProjectile>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FixWiringProjectile>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v18+FFFFFFF8+v259 @ rcx_v8*8]");
									if (0 == (nint)typeof(FixWiringProjectile))
									{
										obj3 = 1;
										goto IL_025a;
									}
								}
								obj3 = 0;
								goto IL_025a;
							}
						}
					}
				}
			}
		}
		goto IL_0229;
		IL_0229:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0254:
		return false;
		IL_025a:
		bool flag = obj3 == null;
		Projectile projectile = null;
		if (!flag)
		{
			projectile = component2;
		}
		if ((object)projectile == null)
		{
			goto IL_0229;
		}
		if (!projectile.HasAlreadyHitObject(component))
		{
			float num4 = base.PPower();
			float num5 = base.CalcCritMul();
			object obj4 = default(object);
			float num6 = (float)obj4 * (float)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rbx_v6 (VampireSurvivors.Objects.Projectiles.Projectile)+100]");
			if ((nint)0 == 0)
			{
				float num7 = base.PAmount();
				num6 *= (float)obj4;
			}
			base.DealDamage(component, num6);
		}
		goto IL_0254;
	}

	public unsafe override void SetVisible(bool visible)
	{
		//IL_059b: Expected O, but got Ref
		//IL_05f8: Expected O, but got Ref
		//IL_0655: Expected O, but got Ref
		//IL_0088: Expected O, but got I4
		//IL_0090: Expected O, but got Ref
		//IL_016d: Expected O, but got I
		//IL_017d: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_070f: Expected O, but got I
		//IL_071f: Expected O, but got I
		//IL_028b: Expected O, but got I
		//IL_04d9: Expected O, but got I4
		//IL_04e7: Expected O, but got I4
		//IL_0772: Expected O, but got I
		//IL_0782: Expected O, but got I
		//IL_031f: Expected O, but got I
		//IL_07ca: Expected O, but got I
		//IL_07da: Expected O, but got I
		//IL_03b3: Expected O, but got I
		_isVisible = visible;
		bool flag = _leftSprites == null;
		List<int> list = (List<int>)(object)this;
		if (!flag)
		{
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			if (enumerator.MoveNext())
			{
				PhaserSprite phaserSprite = null;
				throw new NullReferenceException();
			}
			bool flag2 = _rightSprites == null;
			list = (List<int>)(&enumerator);
			if (!flag2)
			{
				List<PhaserSprite>.Enumerator enumerator2 = default(List<PhaserSprite>.Enumerator);
				if (enumerator2.MoveNext())
				{
					PhaserSprite phaserSprite = null;
					throw new NullReferenceException();
				}
				bool flag3 = _endCapRightSprites == null;
				list = (List<int>)(&enumerator2);
				if (!flag3)
				{
					List<PhaserSprite>.Enumerator enumerator3 = default(List<PhaserSprite>.Enumerator);
					if (enumerator3.MoveNext())
					{
						PhaserSprite phaserSprite = null;
						throw new NullReferenceException();
					}
					bool flag4 = _wireList == null;
					list = (List<int>)(&enumerator3);
					if (!flag4)
					{
						List<FixWiringProjectile>.Enumerator enumerator4 = default(List<FixWiringProjectile>.Enumerator);
						if (enumerator4.MoveNext())
						{
							object obj = 0;
							PhaserSprite phaserSprite = (PhaserSprite)(&enumerator4);
							throw new NullReferenceException();
						}
						if (visible)
						{
							List<int> list2 = new List<int>();
							bool flag5 = list2 == null;
							list = list2;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
								list = (List<int>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v35+18]");
									if (num >= 0)
									{
										list2.AddWithResize(0);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
										object obj3 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v35+18]");
										if (num2 >= 0)
										{
											goto IL_0744;
										}
										_ = 0;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
									list = (List<int>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v37+18]");
										if (num3 >= 0)
										{
											list2.AddWithResize(1);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
											object obj5 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
											nint num4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v37+18]");
											if (num4 >= 0)
											{
												goto IL_0744;
											}
											_ = 1;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
										list = (List<int>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v39+18]");
											if (num5 >= 0)
											{
												list2.AddWithResize(2);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
												object obj7 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
												nint num6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v39+18]");
												if (num6 >= 0)
												{
													goto IL_0744;
												}
												_ = 2;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
											list = (List<int>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v41+18]");
												if (num7 >= 0)
												{
													list2.AddWithResize(3);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
													object obj9 = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ rax_v69 (System.Collections.Generic.List`1<System.Int32>)+18]");
													nint num8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v41+18]");
													if (num8 >= 0)
													{
														goto IL_0744;
													}
													_ = 3;
												}
												_remainingWireList = list2;
												shuffleWirePositions();
												return;
											}
										}
									}
								}
							}
						}
						else
						{
							list = _remainingWireList;
							if (_remainingWireList != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								_ = 0;
								if (_wireList != null)
								{
									List<FixWiringProjectile>.Enumerator enumerator5 = default(List<FixWiringProjectile>.Enumerator);
									if (enumerator5.MoveNext())
									{
										FixWiringProjectile fixWiringProjectile = null;
										throw new NullReferenceException();
									}
									if (_wireSparkPool != null)
									{
										_wireSparkPool.Cleanup();
									}
									if (_completeTimer != null)
									{
										Timer completeTimer = _completeTimer;
										if (!_completeTimer.IsDone)
										{
											float timeElapsed = _completeTimer.GetTimeElapsed();
											completeTimer._timeElapsedBeforeCancel = (float?)(object)1;
											completeTimer._timeElapsedBeforePause = (float?)(object)0;
										}
									}
									if (alphaTween != null)
									{
										alphaTween.Kill();
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0744:
		throw new IndexOutOfRangeException();
	}

	public FixWiringWeapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_03f2: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_041a: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0442: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0207: Expected O, but got I
		//IL_0261: Expected O, but got I
		//IL_0479: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_04a1: Expected O, but got I
		//IL_0335: Expected O, but got I
		//IL_04c9: Expected O, but got I
		//IL_039f: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16711680u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16711680;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(255u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 255;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16776960u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16776960;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(16711935u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 16711935;
		}
		_colourList = list;
		List<int> list2 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v14+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v16+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v18+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize(2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v20+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize(3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 3;
		}
		_remainingWireList = list2;
		base._002Ector();
	}

	private void _003CLineComplete_003Eb__18_0()
	{
		checkIfAllLinesComplete();
	}

	private void _003CshuffleWirePositions_003Eb__22_0()
	{
		PickNewTarget();
	}

	private void _003CcheckIfAllLinesComplete_003Eb__26_1()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		List<FixWiringProjectile> wireList = _wireList;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < wireList._size)
			{
				List<FixWiringProjectile> wireList2 = _wireList;
				object obj3 = obj & 0x80000003L;
				if ((nint)_wireList < 0)
				{
					object obj4 = obj3 - 1;
					object obj5 = obj4 | -4;
					obj3 = obj5 + 1;
				}
				if ((nint)obj3 >= wireList2._size)
				{
					break;
				}
				FixWiringProjectile[] items = wireList2._items;
				fireSpark(items[obj3], 2f);
				wireList = _wireList;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CcheckIfAllLinesComplete_003Eb__26_0()
	{
		HideWeapon();
	}

	private void _003CHideWeapon_003Eb__27_0()
	{
		shuffleWirePositions();
	}
}
