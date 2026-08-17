using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Flower2Weapon : Weapon
{
	public float BoomBallExplodingSpeed = 0.1f;

	public float BoomBallMAXRADIUS = 70f;

	private float _mul = 16.666666f;

	private bool _explosionTriggered;

	private Timer _chainTimer;

	private bool _canChainExplosion;

	[NonSerialized]
	public float WORLD_RIGHT;

	[NonSerialized]
	public float WORLD_LEFT;

	[NonSerialized]
	public float WORLD_TOP;

	[NonSerialized]
	public float WORLD_BOTTOM;

	private BulletPool _boomBallPool;

	[NonSerialized]
	public PhysicsGroup _activeBalls;

	private float _firingTimes;

	private List<Vector2> _positions;

	private List<float> _offsetsX;

	private List<float> _offsetsY;

	private PhaserSprite _sprCore;

	private PhaserSprite _sprFlower;

	private PhaserSprite _sprPond;

	private PhaserSprite _sprSplash;

	private PhaserSprite _sprGrass;

	private bool _hasFlex;

	private bool _hasCharacterFlex;

	protected override void OnStart()
	{
		base.OnStart();
		PhysicsGroup physicsGroup = (PhysicsGroup)new Group(300);
		((Group)physicsGroup)._002Ector(300);
		physicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
		_activeBalls = physicsGroup;
		PhysicsManager sInstance = PhysicsManager._sInstance;
		ArcadePhysics.s_world.addSubsetGroupTree(_activeBalls, sInstance._bulletGroup);
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.BOOMBALL);
		BulletPool boomBallPool = new BulletPool(projectilePrefab);
		_boomBallPool = boomBallPool;
		BulletPool boomBallPool2 = _boomBallPool;
		boomBallPool2.UpperLimit = 300;
	}

	public void createFlex()
	{
		//IL_027c: Expected O, but got I4
		//IL_029a: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02d6: Expected O, but got I4
		//IL_02f4: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite sprCore = RenderingExtensions.sprite(s_scene.add, pos, "anima", "Flex_01");
		_sprCore = sprCore;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserSprite sprFlower = RenderingExtensions.sprite(s_scene2.add, pos, "anima", "FlexFlower_01");
			_sprFlower = sprFlower;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				PhaserSprite sprPond = RenderingExtensions.sprite(s_scene3.add, pos, "anima", "FlexPond_01");
				_sprPond = sprPond;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					PhaserSprite sprSplash = RenderingExtensions.sprite(s_scene4.add, pos, "anima", "FlexSplash_01");
					_sprSplash = sprSplash;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene5 = ArcadePhysics.s_scene;
						PhaserSprite sprGrass = RenderingExtensions.sprite(s_scene5.add, pos, "anima", "FlexGrass_01");
						_sprGrass = sprGrass;
						int num = default(int);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Flex_", 1, 8, "anima", num);
						PhaserSprite sprCore2 = _sprCore;
						bool flag = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						sprCore2._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, flag, onComplete, autoSetAnimation);
						List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("FlexFlower_", 1, 8, "anima", num);
						PhaserSprite sprFlower2 = _sprFlower;
						sprFlower2._spriteAnimation.AddAnimation("idle", animationFrames2, 8, (byte)num != 0, flag, onComplete, autoSetAnimation);
						List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("FlexPond_", 1, 8, "anima", num);
						PhaserSprite sprPond2 = _sprPond;
						sprPond2._spriteAnimation.AddAnimation("idle", animationFrames3, 8, (byte)num != 0, flag, onComplete, autoSetAnimation);
						List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("FlexSplash_", 1, 8, "anima", num);
						PhaserSprite sprSplash2 = _sprSplash;
						sprSplash2._spriteAnimation.AddAnimation("idle", animationFrames4, 8, (byte)num != 0, flag, onComplete, autoSetAnimation);
						PhaserSprite phaserSprite = _sprCore.setOrigin(0.5f, (float?)(object)1);
						PhaserSprite phaserSprite2 = _sprFlower.setOrigin(0.5f, (float?)(object)1);
						PhaserSprite phaserSprite3 = _sprPond.setOrigin(0.5f, (float?)(object)1);
						PhaserSprite phaserSprite4 = _sprSplash.setOrigin(0.5f, (float?)(object)1);
						PhaserSprite phaserSprite5 = _sprGrass.setOrigin(0.5f, (float?)(object)1);
						int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
						int depth2 = depth - 5;
						PhaserSprite phaserSprite6 = _sprCore.setDepth(depth2);
						int depth3 = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
						int depth4 = depth3 - 4;
						PhaserSprite phaserSprite7 = _sprPond.setDepth(depth4);
						int depth5 = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
						int depth6 = depth5 - 3;
						PhaserSprite phaserSprite8 = _sprGrass.setDepth(depth6);
						int depth7 = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
						int depth8 = depth7 - 2;
						PhaserSprite phaserSprite9 = _sprSplash.setDepth(depth8);
						int depth9 = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
						int depth10 = depth9 - 1;
						PhaserSprite phaserSprite10 = _sprFlower.setDepth(depth10);
						PhaserSprite sprCore3 = _sprCore;
						sprCore3._spriteAnimation.SetAnimation("idle");
						PhaserSprite sprFlower3 = _sprFlower;
						sprFlower3._spriteAnimation.SetAnimation("idle");
						PhaserSprite sprPond3 = _sprPond;
						sprPond3._spriteAnimation.SetAnimation("idle");
						PhaserSprite sprSplash3 = _sprSplash;
						sprSplash3._spriteAnimation.SetAnimation("idle");
						PhaserSprite phaserSprite11 = _sprCore.setTint(14737663u, 255u, 14737663u, (uint)num, flag ? BlendMode.Add : BlendMode.Normal);
						PhaserSprite phaserSprite12 = phaserSprite11.setAlpha(0.65f);
						PhaserSprite phaserSprite13 = _sprFlower.setTint(14737663u, 255u, 14737663u, (uint)num, flag ? BlendMode.Add : BlendMode.Normal);
						PhaserSprite phaserSprite14 = phaserSprite13.setAlpha(0.65f);
						PhaserSprite phaserSprite15 = _sprPond.setTint(14737663u, 255u, 14737663u, (uint)num, flag ? BlendMode.Add : BlendMode.Normal);
						PhaserSprite phaserSprite16 = phaserSprite15.setAlpha(0.65f);
						PhaserSprite phaserSprite17 = _sprSplash.setTint(14737663u, 255u, 14737663u, (uint)num, flag ? BlendMode.Add : BlendMode.Normal);
						PhaserSprite phaserSprite18 = phaserSprite17.setAlpha(0.65f);
						PhaserSprite phaserSprite19 = _sprGrass.setTint(14737663u, 255u, 14737663u, (uint)num, flag ? BlendMode.Add : BlendMode.Normal);
						PhaserSprite phaserSprite20 = phaserSprite19.setAlpha(0.65f);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_010b: Expected I, but got O
		//IL_0119: Expected I, but got O
		//IL_0129: Expected O, but got I
		//IL_0165: Expected O, but got I
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		ArcadePhysicsCallback collideCallback = onBulletOverlapsBullet;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.collider(_projectilePool, _projectilePool, collideCallback, processCallback, callbackContext);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		ArcadePhysics physics2 = s_scene2.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback2 = onBoomBallOverlapsEnemy;
		Collider collider2 = physics2.add.overlap(_boomBallPool, core.Enemies, collideCallback2, processCallback, callbackContext);
		PrepareArrays(200f);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController2._characterType != CharacterType.TATANKA)
		{
			return;
		}
		nint num = (nint)characterController2;
		nint num2 = (nint)typeof(CharacterControllerOSole);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerOSole>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerOSole>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v25+FFFFFFF8+v247 @ rax_v24*8]");
			if (0 == (nint)typeof(CharacterControllerOSole))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v22 (VampireSurvivors.Objects.Characters.CharacterController)+428]");
				_hasCharacterFlex = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	private void PrepareArrays(float amount)
	{
		//IL_000e: Invalid comparison between I4 and F4
		//IL_006d: Invalid comparison between F4 and I4
		//IL_008d: Expected F4, but got I4
		//IL_0288: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00b7: Invalid comparison between F4 and O
		//IL_0147: Invalid comparison between F4 and I4
		//IL_0167: Expected F4, but got I4
		//IL_0296: Expected F4, but got I4
		List<Vector2> positions = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		_positions = positions;
		float num;
		if (!(0f > amount))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm6\"");
			num = amount;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = amount;
		}
		if (num > 0f)
		{
			float num2 = 0f;
			Vector2 item = default(Vector2);
			do
			{
				object obj = 0;
				do
				{
					_positions.Add(item);
					obj++;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
				num2++;
			}
			while (num > num2);
		}
		Extensions.Shuffle(_positions);
		List<float> offsetsX = new List<float>();
		_offsetsX = offsetsX;
		List<float> offsetsY = new List<float>();
		_offsetsY = offsetsY;
		if (num > 0f)
		{
			float num3 = 0f;
			do
			{
				float num4 = 0f;
				do
				{
					float num5 = num3 / num;
					float num6 = num5 * 16f;
					float item2 = num6 * 0.01f;
					_offsetsX.Add(item2);
					float num7 = num4 / num;
					float num8 = num7 * 16f;
					float item3 = num8 * 0.01f;
					_offsetsY.Add(item3);
					num4++;
				}
				while (num > num4);
				num3++;
			}
			while (num > num3);
		}
		Extensions.Shuffle(_offsetsX);
		Extensions.Shuffle(_offsetsY);
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num + base._003CTotalTime_003Ek__BackingField;
		base._003CTotalTime_003Ek__BackingField = num2;
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = deltaTime2 * 1000f;
		float num4 = frameWalk * 100f;
		float num5 = num3 / _mul;
		float num6 = num5 * num4;
		float num7 = (base._003CTotalTime_003Ek__BackingField = num6 + base._003CTotalTime_003Ek__BackingField);
		float num8 = base.PInterval();
		if (!(num7 < deltaTime2))
		{
			float num9 = base.PInterval();
			float num10 = base._003CTotalTime_003Ek__BackingField - deltaTime2;
			base._003CTotalTime_003Ek__BackingField = num10;
			base.Fire();
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num11 = renderer.width * 0.5f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float wORLD_RIGHT = (float)position + num11;
		float num12 = renderer2.height * 0.5f;
		float wORLD_LEFT = (float)position - num11;
		WORLD_RIGHT = wORLD_RIGHT;
		object obj = default(object);
		float wORLD_TOP = (float)obj - num12;
		float wORLD_BOTTOM = (float)obj + num12;
		WORLD_LEFT = wORLD_LEFT;
		WORLD_TOP = wORLD_TOP;
		WORLD_BOTTOM = wORLD_BOTTOM;
	}

	protected override void OnUpdate()
	{
		if (!_hasFlex && !_hasCharacterFlex)
		{
			createFlex();
			_hasFlex = true;
		}
	}

	private void LateUpdate()
	{
		if (_hasFlex)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		}
	}

	private void UpdateFlex()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_008c: Invalid comparison between F4 and I
		//IL_00ea: Expected F4, but got I
		//IL_0359: Invalid comparison between F4 and I4
		//IL_0370: Expected F4, but got I4
		//IL_0382: Expected F4, but got I4
		//IL_00ba: Expected O, but got I8
		//IL_027d: Expected I, but got O
		//IL_0293: Expected O, but got I
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_0317: Expected I, but got O
		//IL_04a8: Expected O, but got I4
		//IL_04cf: Expected I, but got I8
		//IL_025d: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_02f3: Expected I, but got I8
		//IL_041c: Expected O, but got I4
		//IL_01e6: Invalid comparison between F4 and I4
		//IL_01f4: Expected F4, but got I4
		//IL_01fc: Expected F4, but got I4
		//IL_03e7->IL031c: Incompatible stack heights: 1 vs 0
		//IL_020d->IL00ef: Incompatible stack heights: 2 vs 0
		//IL_0212->IL0212: Incompatible stack heights: 2 vs 0
		//IL_011d->IL031c: Incompatible stack heights: 2 vs 0
		//IL_0146->IL031c: Incompatible stack heights: 2 vs 0
		//IL_016f->IL031c: Incompatible stack heights: 2 vs 0
		//IL_0198->IL031c: Incompatible stack heights: 2 vs 0
		base.Fire(skipTriggers);
		if (_explosionTriggered)
		{
			return;
		}
		Extensions.Shuffle(_positions);
		List<Vector2> positions = _positions;
		_explosionTriggered = true;
		if (_positions == null)
		{
			goto IL_031c;
		}
		float num = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		float num2 = 0f / 10f;
		float num4 = default(float);
		float num3 = num2 * num4;
		float num5 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if (!(num5 > 0f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj = 0 & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_0350;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		num3 = 0f;
		goto IL_0350;
		IL_0350:
		bool flag = !(num3 > 0f);
		Weapon weapon = null;
		float num6 = 0f;
		int num7 = 0;
		float num8 = 0f;
		bool flag2 = default(bool);
		bool useRealTime = flag2;
		if (flag)
		{
			goto IL_0212;
		}
		object obj3 = default(object);
		float2 pos = default(float2);
		while (true)
		{
			bool flag3 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			if ((object)gameObject == null)
			{
				break;
			}
			bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj2 != null)
			{
				if (_positions == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				if (_offsetsX == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
				if (_offsetsY == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
				if (_boomBallPool == null)
				{
					break;
				}
				float num9 = (float)obj3 - num6;
				Projectile projectile = _boomBallPool.SpawnAt(pos, this, num7);
				weapon = this;
			}
			num7++;
			bool flag5 = num3 > (float)num7;
			num6 = num7;
			num8 = num7;
			useRealTime = flag2;
			if (flag5)
			{
				continue;
			}
			goto IL_0212;
		}
		goto IL_031c;
		IL_031c:
		throw new NullReferenceException();
		IL_0212:
		Timer chainTimer = _chainTimer;
		if (_chainTimer != null && !_chainTimer.IsDone)
		{
			num8 = _chainTimer.GetTimeElapsed();
			chainTimer._timeElapsedBeforeCancel = (float?)(object)1;
			chainTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		float num10 = base.PInterval();
		Action action = null;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(Flower2Weapon._003CFire_003Eb__31_0);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj4 = (nint)0 >> 4;
		object obj5 = obj4 & 1;
		nint num12;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num12 = unchecked((nint)6447293664L);
				goto IL_049f;
			}
		}
		num12 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_049f;
		IL_049f:
		object obj6 = 24;
		float duration = num8 * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer chainTimer2 = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_chainTimer = chainTimer2;
	}

	private void DetonateBoomBalls()
	{
		if (_boomBallPool == null)
		{
			return;
		}
		BulletPool boomBallPool = _boomBallPool;
		ObjectPool pool = boomBallPool._pool;
		if (pool._aliveObjects == null)
		{
			return;
		}
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v6 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v6 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		if (num == 0)
		{
			return;
		}
		BulletPool boomBallPool2 = _boomBallPool;
		ObjectPool pool2 = boomBallPool2._pool;
		Dictionary<int, GameObject> aliveObjects2 = pool2._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v8 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v8 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		int maxExclusive = (int)(num2 - 0);
		int num3 = UnityEngine.Random.Range(0, maxExclusive);
		BulletPool boomBallPool3 = _boomBallPool;
		ObjectPool pool3 = boomBallPool3._pool;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF0DA0");
		GameObject gameObject = default(GameObject);
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			BoomBallProjectile component = gameObject.GetComponent<BoomBallProjectile>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				component.Detonate();
			}
		}
	}

	private bool onBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0183: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Flower2Projectile component = gameObject.GetComponent<Flower2Projectile>();
				if (second != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject2 = default(GameObject);
					if ((object)gameObject2 != null)
					{
						Flower2Projectile component2 = gameObject2.GetComponent<Flower2Projectile>();
						if ((object)component2 != null)
						{
							if (component2.HasAlreadyHitObject(component))
							{
								goto IL_016f;
							}
							if ((object)component != null && ((Projectile)component)._objectsHit != null)
							{
								bool flag = ((HashSet<object>)(object)((Projectile)component)._objectsHit).AddIfNotPresent((object)component2);
								if (((Projectile)component2)._objectsHit != null)
								{
									bool flag2 = ((HashSet<object>)(object)((Projectile)component2)._objectsHit).AddIfNotPresent((object)component);
									component.SizeUp();
									component2.SizeUp();
									goto IL_016f;
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_016f:
		return false;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void CheckArcanas()
	{
		if (!_beginningArcana)
		{
			GameManager gameMan = _gameMan;
			List<WeaponType> list = gameMan._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager gameMan2 = _gameMan;
				List<WeaponType> list2 = gameMan2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj = default(object);
				if (obj != null)
				{
					int beginningAmount = _beginningAmount + 3;
					_beginningAmount = beginningAmount;
					WeaponData currentWeaponData = _currentWeaponData;
					_beginningArcana = true;
					int num = currentWeaponData._003Camount_003Ek__BackingField + 3;
					currentWeaponData._003Camount_003Ek__BackingField = num;
				}
			}
			if (!_beginningArcana)
			{
				GameManager gameMan3 = _gameMan;
				List<WeaponType> list3 = gameMan3._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 > (nint)0)
				{
					GameManager gameMan4 = _gameMan;
					List<WeaponType> list4 = gameMan4._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						int beginningAmount2 = _beginningAmount + 1;
						_beginningAmount = beginningAmount2;
						WeaponData currentWeaponData2 = _currentWeaponData;
						_beginningArcana = true;
						int num2 = currentWeaponData2._003Camount_003Ek__BackingField + 1;
						currentWeaponData2._003Camount_003Ek__BackingField = num2;
					}
				}
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list5 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 > -1)
		{
			_explodeOnExpire = true;
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_013b: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				float num = base.PPower();
				WeaponData currentWeaponData = _currentWeaponData;
				HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
				float knockback = base.Knockback;
				float value = default(float);
				component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
				float num2 = base.PPower();
				float num3 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
				base._003CStatsInflictedDamage_003Ek__BackingField = num3;
				if (component._003CIsDead_003Ek__BackingField)
				{
					List<float> critChancesArray = _critChancesArray;
					int critIndex = _critIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					int num4 = (int)((nint)critIndex % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)num4 >= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					int critIndex2 = _critIndex + 1;
					_critIndex = critIndex2;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A10698h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v16+18]");
					if ((nint)num4 >= (nint)0)
					{
						Transform transform = component.transform;
						Vector3 position = transform.position;
						if (!_gameMan.IsStageHost && NetworkItems.IsNetworkItem(ItemType.LITTLEHEART))
						{
							throw new NullReferenceException();
						}
						Vector2 pos = default(Vector2);
						Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
						pickup.GoToLowestHealthPlayer();
						pickup.Time = 1f;
						GameObject gameObject3 = pickup.gameObject;
						LittleHeart component3 = gameObject3.GetComponent<LittleHeart>();
						component3._Volume = 0.1f;
					}
				}
			}
		}
		return false;
	}

	protected bool onBoomBallOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0178: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				float num = config._003CRawRunHeal_003Ek__BackingField / 10000f;
				bool flag = !(100f > num);
				float num2 = 100f;
				if (!flag)
				{
					num2 = num;
				}
				float num3 = base.PPower();
				WeaponData currentWeaponData = _currentWeaponData;
				HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
				float knockback = base.Knockback;
				float value = num2 + num;
				component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
				float num4 = base.PPower();
				float num5 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
				base._003CStatsInflictedDamage_003Ek__BackingField = num5;
				if (component._003CIsDead_003Ek__BackingField)
				{
					List<float> critChancesArray = _critChancesArray;
					int critIndex = _critIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					int num6 = (int)((nint)critIndex % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)num6 >= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					int critIndex2 = _critIndex + 1;
					_critIndex = critIndex2;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A106F8h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v18+18]");
					if ((nint)num6 >= (nint)0)
					{
						Transform transform = component.transform;
						Vector3 position = transform.position;
						if (!_gameMan.IsStageHost && NetworkItems.IsNetworkItem(ItemType.LITTLEHEART))
						{
							throw new NullReferenceException();
						}
						Vector2 pos = default(Vector2);
						Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
						pickup.GoToLowestHealthPlayer();
						pickup.Time = 1f;
						GameObject gameObject3 = pickup.gameObject;
						LittleHeart component3 = gameObject3.GetComponent<LittleHeart>();
						component3._Volume = 0.1f;
					}
				}
			}
		}
		return false;
	}

	public bool CircleOnCircle(float2 v1, float r1, float2 v2, float r2)
	{
		//IL_003b: Invalid comparison between F4 and O
		//IL_0059: Invalid comparison between F4 and I4
		object obj = v1 - v2;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		object obj5 = default(object);
		float num = r1 + (float)obj5;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = num - (float)obj;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public override void Cleanup()
	{
		//IL_006d: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		base.Cleanup();
		if (_boomBallPool != null)
		{
			BulletPool boomBallPool = _boomBallPool;
			ObjectPool pool = boomBallPool._pool;
			if (pool._aliveObjects != null)
			{
				Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v17 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v17 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
				object obj = num - 0;
				object obj2 = obj - 1;
				if ((nint)obj2 > 0)
				{
					GameObject gameObject = default(GameObject);
					do
					{
						BulletPool boomBallPool2 = _boomBallPool;
						ObjectPool pool2 = boomBallPool2._pool;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF0DA0");
						if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
						{
							BoomBallProjectile component = gameObject.GetComponent<BoomBallProjectile>();
							if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
							{
								component.Despawn();
							}
						}
						obj2--;
					}
					while ((nint)obj2 > 0);
				}
			}
		}
		if ((object)_sprCore != null)
		{
			PhaserSprite phaserSprite = _sprCore.setVisible(visible: false);
		}
		if ((object)_sprPond != null)
		{
			PhaserSprite phaserSprite2 = _sprPond.setVisible(visible: false);
		}
		if ((object)_sprGrass != null)
		{
			PhaserSprite phaserSprite3 = _sprGrass.setVisible(visible: false);
		}
		if ((object)_sprSplash != null)
		{
			PhaserSprite phaserSprite4 = _sprSplash.setVisible(visible: false);
		}
		if ((object)_sprFlower != null)
		{
			PhaserSprite phaserSprite5 = _sprFlower.setVisible(visible: false);
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_00bb: Expected O, but got I
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		_isVisible = visible;
		if (!visible)
		{
			if (_chainTimer != null)
			{
				_chainTimer.Cancel();
			}
			if (_boomBallPool != null)
			{
				BulletPool boomBallPool = _boomBallPool;
				ObjectPool pool = boomBallPool._pool;
				if (pool._aliveObjects != null)
				{
					Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v17 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v17 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
					object obj = num - 0;
					object obj2 = obj - 1;
					if ((nint)obj2 > 0)
					{
						GameObject gameObject = default(GameObject);
						do
						{
							BulletPool boomBallPool2 = _boomBallPool;
							ObjectPool pool2 = boomBallPool2._pool;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF0DA0");
							if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
							{
								BoomBallProjectile component = gameObject.GetComponent<BoomBallProjectile>();
								if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
								{
									component.Despawn();
								}
							}
							obj2--;
						}
						while ((nint)obj2 > 0);
					}
					_explosionTriggered = false;
				}
			}
		}
		if ((object)_sprCore != null)
		{
			PhaserSprite phaserSprite = _sprCore.setVisible(visible);
		}
		if ((object)_sprPond != null)
		{
			PhaserSprite phaserSprite2 = _sprPond.setVisible(visible);
		}
		if ((object)_sprGrass != null)
		{
			PhaserSprite phaserSprite3 = _sprGrass.setVisible(visible);
		}
		if ((object)_sprSplash != null)
		{
			PhaserSprite phaserSprite4 = _sprSplash.setVisible(visible);
		}
		if ((object)_sprFlower != null)
		{
			PhaserSprite phaserSprite5 = _sprFlower.setVisible(visible);
		}
	}

	private void _003CFire_003Eb__31_0()
	{
		DetonateBoomBalls();
		_explosionTriggered = false;
	}
}
