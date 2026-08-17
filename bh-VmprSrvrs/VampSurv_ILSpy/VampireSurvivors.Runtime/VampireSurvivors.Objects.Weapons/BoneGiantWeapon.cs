using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class BoneGiantWeapon : BoneWeapon
{
	private float2 _headOffset;

	private float2 _inv_headOffset;

	private float2 _haloOffset;

	private float2 _inv_haloOffset;

	private float2 _inv_frontOffset;

	private float2 _inv_backOffset;

	private float2 _frontOffset;

	private float2 _backOffset;

	private bool _hasSkeleton;

	private bool _hasCharacterSkeleton;

	private bool _areArmsAttached;

	private int _firedTimes;

	private int _secondaryFireCounter;

	private BulletPool _giantArmPool;

	private BoneGiantProjectile _frontArm;

	private BoneGiantProjectile _backArm;

	private PhaserSprite _head;

	private PhaserSprite _torso;

	private MultiTargetTween _armsSpinTween;

	private MultiTargetTween _armsSpinTween2;

	private bool _isAttacking;

	private PhaserSprite _halo;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0095: Expected I, but got O
		//IL_00a3: Expected I, but got O
		//IL_00b3: Expected O, but got I
		//IL_00ef: Expected O, but got I
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		((Weapon)this).InitWeapon(characterController, weaponType);
		GameManager core = GM.Core;
		Projectile projectilePrefab = core._projectileFactory.GetProjectilePrefab(WeaponType.BONE_ARM);
		BulletPool giantArmPool = new BulletPool(projectilePrefab);
		_giantArmPool = giantArmPool;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		_hasSkeleton = false;
		_isAttacking = false;
		if (characterController2._characterType != CharacterType.MORTACCIO)
		{
			return;
		}
		nint num = (nint)characterController2;
		nint num2 = (nint)typeof(CharacterControllerMortaccio);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerMortaccio>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerMortaccio>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v15+FFFFFFF8+v119 @ rax_v14*8]");
			if (0 == (nint)typeof(CharacterControllerMortaccio))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v12 (VampireSurvivors.Objects.Characters.CharacterController)+410]");
				_hasCharacterSkeleton = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0148: Expected I, but got O
		//IL_00fc: Expected O, but got I4
		base.Fire(skipTriggers);
		if (++_firedTimes < _secondaryFireCounter || _isAttacking)
		{
			return;
		}
		_firedTimes = 0;
		if (!_hasSkeleton)
		{
			return;
		}
		nint num = (nint)this;
		_isAttacking = true;
		_areArmsAttached = true;
		float num2 = base.PDuration();
		object obj = default(object);
		float num3 = (float)obj / 500f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		int num4 = default(int);
		bool flag = num4 >= 8;
		int num5 = num4;
		if (!flag)
		{
			num5 = 8;
		}
		_frontArm.Spinnn(-359f, 500f, num5);
		_backArm.Spinnn(359f, 500f, num5);
		Action onComplete = delegate
		{
			//IL_007d: Invalid comparison between F4 and I
			//IL_00ad: Expected F4, but got I
			_areArmsAttached = false;
			_frontArm.Detach(360f);
			Action onComplete2 = delegate
			{
				_backArm.Detach(-360f);
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			float num6 = base.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
			bool flag2 = !(0.1f < 0f);
			float num7 = 0.1f;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
				num7 = 0f;
			}
			Action onComplete3 = delegate
			{
				_areArmsAttached = true;
				_frontArm.Attach();
				Action onComplete4 = delegate
				{
					_backArm.Attach();
				};
				bool useRealTime3 = default(bool);
				MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
				int repeat3 = default(int);
				TimerType type3 = default(TimerType);
				Timer timer4 = Timers.Register(0.1f, onComplete4, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
				_isAttacking = false;
			};
			float duration2 = num7 * 0.001f;
			Timer timer3 = Timers.Register(duration2, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
		};
		object obj2 = num5 * 500;
		float duration = (float)obj2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00b9: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_0157: Expected O, but got I4
		//IL_0113: Expected O, but got I
		//IL_0149: Expected O, but got I4
		GameManager core = GM.Core;
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
			{
				return null;
			}
			if (_projectilePool != null)
			{
				float2 pos2 = default(float2);
				projectile = _projectilePool.SpawnAt(pos2, this, index);
				bool flag = (object)projectile == null;
				projectile2 = null;
				if (!flag)
				{
					nint num = (nint)projectile;
					nint num2 = (nint)typeof(BoneProjectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneProjectile>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneProjectile>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v26+FFFFFFF8+v194 @ rax_v22*8]");
						if (0 == (nint)typeof(BoneProjectile))
						{
							obj3 = 1;
							goto IL_01e1;
						}
					}
					obj3 = 0;
					goto IL_01e1;
				}
				goto IL_0208;
			}
		}
		return (Projectile)(object)new NullReferenceException();
		IL_01e1:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0208;
		IL_0208:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			_ = 1;
		}
		return projectile2;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (!_hasSkeleton && !_hasCharacterSkeleton)
		{
			InitSkeleton();
			_hasSkeleton = true;
		}
	}

	private void LateUpdate()
	{
		if (_hasSkeleton)
		{
			UpdateSkeleton();
		}
	}

	private void InitSkeleton()
	{
		//IL_00df: Expected I, but got O
		//IL_00ed: Expected I, but got O
		//IL_00fd: Expected O, but got I
		//IL_017d: Expected O, but got I4
		//IL_0139: Expected O, but got I
		//IL_016f: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_023b: Expected I, but got O
		//IL_024b: Expected O, but got I
		//IL_02cb: Expected O, but got I4
		//IL_0287: Expected O, but got I
		//IL_02bd: Expected O, but got I4
		//IL_064d: Expected I4, but got I8
		//IL_0669: Expected O, but got I4
		//IL_05a5: Expected I4, but got I8
		//IL_05c1: Expected O, but got I4
		//IL_06c6: Expected I4, but got I8
		//IL_06e2: Expected O, but got I4
		//IL_0768: Expected O, but got I4
		//IL_0768: Expected O, but got I4
		//IL_07dc: Expected I, but got O
		//IL_080b: Expected O, but got I4
		//IL_080b: Expected O, but got I4
		if (_giantArmPool == null)
		{
			GameManager core = GM.Core;
			Projectile projectilePrefab = core._projectileFactory.GetProjectilePrefab(WeaponType.BONE2);
			BulletPool giantArmPool = new BulletPool(projectilePrefab);
			_giantArmPool = giantArmPool;
		}
		BoneGiantProjectile frontArm = _frontArm;
		if ((object)_frontArm != null && ((UnityEngine.Object)frontArm).m_CachedPtr != (IntPtr)0)
		{
			goto IL_019f;
		}
		float2 pos = default(float2);
		Projectile projectile = _giantArmPool.SpawnAt(pos, this);
		Projectile frontArm2;
		if ((object)projectile == null)
		{
			frontArm2 = null;
			goto IL_085d;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(BoneGiantProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1188 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneGiantProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ r8_v60 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1188 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneGiantProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ r8_v60 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1263 @ rax_v175+FFFFFFF8+v1189 @ rax_v170*8]");
			if (0 == (nint)typeof(BoneGiantProjectile))
			{
				obj3 = 1;
				goto IL_086c;
			}
		}
		obj3 = 0;
		goto IL_086c;
		IL_08b2:
		Projectile backArm;
		_backArm = (BoneGiantProjectile)backArm;
		_backArm.Attach();
		goto IL_02ed;
		IL_086c:
		bool flag = obj3 == null;
		frontArm2 = null;
		if (!flag)
		{
			frontArm2 = projectile;
		}
		goto IL_085d;
		IL_085d:
		_frontArm = (BoneGiantProjectile)frontArm2;
		_frontArm.Attach();
		goto IL_019f;
		IL_019f:
		BoneGiantProjectile backArm2 = _backArm;
		if ((object)_backArm != null && ((UnityEngine.Object)backArm2).m_CachedPtr != (IntPtr)0)
		{
			goto IL_02ed;
		}
		Projectile projectile2 = _giantArmPool.SpawnAt(pos, this, 1);
		if ((object)projectile2 == null)
		{
			backArm = null;
			goto IL_08b2;
		}
		nint num4 = (nint)projectile2;
		nint num5 = (nint)typeof(BoneGiantProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1492 @ rdx_v50 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneGiantProjectile>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r8_v52 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1492 @ rdx_v50 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneGiantProjectile>)+130]");
		object obj6;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r8_v52 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1567 @ rax_v152+FFFFFFF8+v1493 @ rax_v147*8]");
			if (0 == (nint)typeof(BoneGiantProjectile))
			{
				obj6 = 1;
				goto IL_08c1;
			}
		}
		obj6 = 0;
		goto IL_08c1;
		IL_08c1:
		bool flag2 = obj6 == null;
		backArm = null;
		if (!flag2)
		{
			backArm = projectile2;
		}
		goto IL_08b2;
		IL_0810:
		throw new NullReferenceException();
		IL_05f9:
		uint num7;
		bool flag3 = default(bool);
		PhaserSprite phaserSprite = _head.setTint(14737663u, 255u, 14737663u, num7, flag3 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = phaserSprite2.setDepth(-1);
		PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(0f, (float?)(object)1);
		PhaserSprite phaserSprite5 = _torso.setTint(14737663u, 255u, 14737663u, num7, flag3 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0.65f);
		PhaserSprite phaserSprite7 = phaserSprite6.setDepth(-2);
		PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(0.5f, (float?)(object)1);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core2 = GM.Core;
			ArcadePhysicsCallback collideCallback = OnGiantArmOverlapsEnemy;
			Collider collider = physics.add.overlap(_giantArmPool, core2.Enemies, collideCallback, (ArcadePhysicsCallback)num7, (CallbackContext)flag3);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core3 = GM.Core;
				PhysicsManager physicsManager = core3._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2364 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.BoneGiantWeapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num8 = (nint)this;
				Collider collider2 = physics2.add.overlap(_giantArmPool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)num7, (CallbackContext)flag3);
				return;
			}
		}
		goto IL_0810;
		IL_02ed:
		PhaserSprite head = _head;
		int num9 = default(int);
		if ((object)_head == null || ((UnityEngine.Object)head).m_CachedPtr == (IntPtr)0)
		{
			if ((object)GM.Core == null)
			{
				goto IL_0810;
			}
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserSprite phaserSprite9 = RenderingExtensions.sprite(s_scene3.add, pos, "anima", "Gash_head_i01");
			GameObject gameObject = phaserSprite9.gameObject;
			((UnityEngine.Object)gameObject).SetName("head");
			_head = phaserSprite9;
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Gash_head_i", 1, 5, "anima", num9);
			PhaserSprite head2 = _head;
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			head2._spriteAnimation.AddAnimation("idle", animationFrames, 24, (byte)num9 != 0, flag3, onComplete, autoSetAnimation);
			PhaserSprite head3 = _head;
			head3._spriteAnimation.SetAnimation("idle");
		}
		PhaserSprite torso = _torso;
		if ((object)_torso == null || ((UnityEngine.Object)torso).m_CachedPtr == (IntPtr)0)
		{
			if ((object)GM.Core == null)
			{
				goto IL_0810;
			}
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			PhaserSprite phaserSprite10 = RenderingExtensions.sprite(s_scene4.add, pos, "anima", "Gash_body_i01");
			GameObject gameObject2 = phaserSprite10.gameObject;
			((UnityEngine.Object)gameObject2).SetName("torso");
			_torso = phaserSprite10;
		}
		PhaserSprite halo = _halo;
		if ((object)_halo != null)
		{
			bool flag4 = ((UnityEngine.Object)halo).m_CachedPtr != (IntPtr)0;
			num7 = (uint)num9;
			if (flag4)
			{
				goto IL_05f9;
			}
		}
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			num7 = (uint)num9;
			PhaserSprite phaserSprite11 = RenderingExtensions.sprite(s_scene5.add, pos, "anima", "Halo");
			PhaserSprite phaserSprite12 = phaserSprite11.setDepth(-1);
			PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0.5f, (float?)(object)1);
			GameObject gameObject3 = phaserSprite13.gameObject;
			((UnityEngine.Object)gameObject3).SetName("halo");
			_halo = phaserSprite13;
			goto IL_05f9;
		}
		goto IL_0810;
	}

	private void UpdateSkeleton()
	{
		//IL_02a9: Expected O, but got I4
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_0386: Expected O, but got I4
		//IL_03b0: Expected O, but got I4
		//IL_04a5: Expected O, but got F4
		//IL_0537: Expected O, but got F4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		PhaserSprite phaserSprite = _torso.setFlipX(flipX);
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int depth2 = depth - 2;
		PhaserSprite phaserSprite2 = _torso.setDepth(depth2);
		float x = _torso.X;
		float num = x - 0.31f;
		float y = _torso.Y;
		float num2 = y + 0.48999998f;
		bool flipX2 = _torso.flipX;
		PhaserSprite phaserSprite3 = _head.setFlipX(flipX2);
		float2 float5 = ((!_torso.flipX) ? _headOffset : _inv_headOffset);
		float x2 = (float)float5 + num;
		_head.X = x2;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.BoneGiantWeapon)+15C]");
		float y2 = num3 - 0f;
		_head.Y = y2;
		int depth3 = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int depth4 = depth3 - 1;
		PhaserSprite phaserSprite4 = _head.setDepth(depth4);
		float2 float6 = ((!_torso.flipX) ? _haloOffset : _inv_haloOffset);
		float x3 = _head.X;
		float x4 = x3 + (float)float6;
		_halo.X = x4;
		float y3 = _head.Y;
		float num4 = y3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.BoneGiantWeapon)+16C]");
		float y4 = num4 - 0f;
		_halo.Y = y4;
		bool flipX3 = _torso.flipX;
		object obj = (flipX3 ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		float xScale = (float)obj2 - 1f;
		BoneGiantProjectile frontArm = _frontArm;
		PhaserSprite displaySprite;
		int depth8;
		if (_areArmsAttached)
		{
			PhaserSprite phaserSprite5 = frontArm._displaySprite.setScale(xScale, (float?)(object)1);
			BoneGiantProjectile backArm = _backArm;
			PhaserSprite phaserSprite6 = backArm._displaySprite.setScale(xScale, (float?)(object)1);
			BoneGiantProjectile frontArm2 = _frontArm;
			int depth5 = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
			int depth6 = depth5 + 1;
			PhaserSprite phaserSprite7 = frontArm2._displaySprite.setDepth(depth6);
			BoneGiantProjectile backArm2 = _backArm;
			displaySprite = backArm2._displaySprite;
			int depth7 = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
			depth8 = depth7 - 3;
		}
		else
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserSprite phaserSprite8 = frontArm._displaySprite.setDepth(renderer.pixelHeight);
			BoneGiantProjectile backArm3 = _backArm;
			displaySprite = backArm3._displaySprite;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			depth8 = renderer2.pixelHeight;
		}
		PhaserSprite phaserSprite9 = displaySprite.setDepth(depth8);
		float2 float7 = ((!_torso.flipX) ? _frontOffset : _inv_frontOffset);
		BoneGiantProjectile frontArm3 = _frontArm;
		float num5 = (float)float7 + num;
		frontArm3._anchorPosition = (Vector2)num5;
		BoneGiantProjectile frontArm4 = _frontArm;
		float num6 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.BoneGiantWeapon)+18C]");
		float num7 = num6 - 0f;
		float2 float8 = ((!_torso.flipX) ? _backOffset : _inv_backOffset);
		BoneGiantProjectile backArm4 = _backArm;
		float num8 = (float)float8 + num;
		backArm4._anchorPosition = (Vector2)num8;
		BoneGiantProjectile backArm5 = _backArm;
		float num9 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.BoneGiantWeapon)+194]");
		float num10 = num9 - 0f;
	}

	private void AttachArms()
	{
		_areArmsAttached = true;
		_frontArm.Attach();
		Action onComplete = delegate
		{
			_backArm.Attach();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_isAttacking = false;
	}

	private void DetachArms()
	{
		//IL_007d: Invalid comparison between F4 and I
		//IL_00ad: Expected F4, but got I
		_areArmsAttached = false;
		_frontArm.Detach(360f);
		Action onComplete = delegate
		{
			_backArm.Detach(-360f);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		float num = base.PDuration();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
		bool flag = !(0.1f < 0f);
		float num2 = 0.1f;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
			num2 = 0f;
		}
		Action onComplete2 = delegate
		{
			_areArmsAttached = true;
			_frontArm.Attach();
			Action onComplete3 = delegate
			{
				_backArm.Attach();
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timer3 = Timers.Register(0.1f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_isAttacking = false;
		};
		float duration = num2 * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SpinArms()
	{
		//IL_00ba: Expected I, but got O
		//IL_006e: Expected O, but got I4
		nint num = (nint)this;
		_isAttacking = true;
		_areArmsAttached = true;
		float num2 = base.PDuration();
		object obj = default(object);
		float num3 = (float)obj / 500f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		int num4 = default(int);
		bool flag = num4 >= 8;
		int num5 = num4;
		if (!flag)
		{
			num5 = 8;
		}
		_frontArm.Spinnn(-359f, 500f, num5);
		_backArm.Spinnn(359f, 500f, num5);
		Action onComplete = delegate
		{
			//IL_007d: Invalid comparison between F4 and I
			//IL_00ad: Expected F4, but got I
			_areArmsAttached = false;
			_frontArm.Detach(360f);
			Action onComplete2 = delegate
			{
				_backArm.Detach(-360f);
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			float num6 = base.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
			bool flag2 = !(0.1f < 0f);
			float num7 = 0.1f;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
				num7 = 0f;
			}
			Action onComplete3 = delegate
			{
				_areArmsAttached = true;
				_frontArm.Attach();
				Action onComplete4 = delegate
				{
					_backArm.Attach();
				};
				bool useRealTime3 = default(bool);
				MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
				int repeat3 = default(int);
				TimerType type3 = default(TimerType);
				Timer timer4 = Timers.Register(0.1f, onComplete4, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
				_isAttacking = false;
			};
			float duration2 = num7 * 0.001f;
			Timer timer3 = Timers.Register(duration2, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
		};
		object obj2 = num5 * 500;
		float duration = (float)obj2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private bool OnGiantArmOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_028f: Expected I4, but got O
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_0118: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_0310: Expected I, but got O
		if (first == null)
		{
			goto IL_0281;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v25+FFFFFFF8+v53 @ rax_v4*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_02ac;
			}
		}
		obj3 = 0;
		goto IL_02ac;
		IL_0281:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02ac:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		if (arcadeColliderType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v3 (ArcadeColliderType)+260]");
			if ((nint)0 != 0)
			{
				return false;
			}
			if (second != null)
			{
				nint num4 = (nint)typeof(Projectile);
				nint num5 = (nint)second;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v9+FFFFFFF8+v76 @ rax_v8*8]");
					if (0 == (nint)typeof(Projectile))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v9+FFFFFFF8+v294 @ rcx_v6*8]");
						object obj7 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
						bool flag2 = obj7 == null;
						ArcadeColliderType arcadeColliderType2 = null;
						if (!flag2)
						{
							arcadeColliderType2 = second;
						}
						if (!((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
						{
							float num7 = base.PPower();
							float num8 = base.PAmount();
							WeaponData currentWeaponData = _currentWeaponData;
							object obj8 = default(object);
							float num9 = (float)obj8 * 0.5f;
							float num10 = num9 * (float)obj8;
							if (_currentWeaponData != null)
							{
								HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
							}
							else
							{
								HitVfxType hitVfxType = HitVfxType.Default;
							}
							float knockback = base.Knockback;
							nint num11 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v370 @ rdx_v12 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
							float num12 = num10 + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
							((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num12;
						}
						return true;
					}
				}
			}
		}
		goto IL_0281;
	}

	public override void SetVisible(bool visible)
	{
		BoneGiantProjectile frontArm = _frontArm;
		_isVisible = visible;
		if ((object)_frontArm != null && ((UnityEngine.Object)frontArm).m_CachedPtr != (IntPtr)0)
		{
			_frontArm.SetProjectileVisible(visible);
		}
		BoneGiantProjectile backArm = _backArm;
		if ((object)_backArm != null && ((UnityEngine.Object)backArm).m_CachedPtr != (IntPtr)0)
		{
			_backArm.SetProjectileVisible(visible);
		}
		PhaserSprite head = _head;
		if ((object)_head != null && ((UnityEngine.Object)head).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _head.setVisible(visible);
		}
		PhaserSprite torso = _torso;
		if ((object)_torso != null && ((UnityEngine.Object)torso).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _torso.setVisible(visible);
		}
		PhaserSprite halo = _halo;
		if ((object)_halo != null && ((UnityEngine.Object)halo).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite3 = _halo.setVisible(visible);
		}
	}

	public override void Cleanup()
	{
		PhaserSprite head = _head;
		if ((object)_head != null && ((UnityEngine.Object)head).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _head.setVisible(visible: false);
		}
		PhaserSprite torso = _torso;
		if ((object)_torso != null && ((UnityEngine.Object)torso).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _torso.setVisible(visible: false);
		}
		PhaserSprite halo = _halo;
		if ((object)_halo != null && ((UnityEngine.Object)halo).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite3 = _halo.setVisible(visible: false);
		}
		if (_giantArmPool != null)
		{
			_giantArmPool.Cleanup();
		}
		BoneGiantProjectile frontArm = _frontArm;
		if ((object)_frontArm != null && ((UnityEngine.Object)frontArm).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite arcadeSprite = _frontArm.setVisible(visible: false);
		}
		BoneGiantProjectile backArm = _backArm;
		if ((object)_backArm != null && ((UnityEngine.Object)backArm).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite arcadeSprite2 = _backArm.setVisible(visible: false);
		}
		base.Cleanup();
	}

	public BoneGiantWeapon()
	{
		//IL_000b: Expected O, but got I4
		//IL_0024: Expected O, but got I8
		//IL_0039: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		_headOffset = (float2)1057300152;
		_ = 3193375293L;
		_inv_headOffset = (float2)3196395192L;
		_ = 3193375293L;
		_haloOffset = (float2)1039516303;
		_ = 3156465418L;
		_inv_haloOffset = (float2)1050253721;
		_ = 3156465418L;
		_inv_frontOffset = (float2)1045891645;
		_ = 1036831948;
		_inv_backOffset = (float2)1025758986;
		_ = 1046562734;
		_frontOffset = (float2)1054951342;
		_ = 1036831948;
		_backOffset = (float2)1058810102;
		_ = 1046562734;
		_areArmsAttached = true;
		_secondaryFireCounter = 6;
		((Weapon)this)._002Ector();
	}

	private void _003CAttachArms_003Eb__29_0()
	{
		_backArm.Attach();
	}

	private void _003CDetachArms_003Eb__30_0()
	{
		_backArm.Detach(-360f);
	}

	private void _003CDetachArms_003Eb__30_1()
	{
		_areArmsAttached = true;
		_frontArm.Attach();
		Action onComplete = delegate
		{
			_backArm.Attach();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_isAttacking = false;
	}

	private void _003CSpinArms_003Eb__31_0()
	{
		//IL_007d: Invalid comparison between F4 and I
		//IL_00ad: Expected F4, but got I
		_areArmsAttached = false;
		_frontArm.Detach(360f);
		Action onComplete = delegate
		{
			_backArm.Detach(-360f);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		float num = base.PDuration();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
		bool flag = !(0.1f < 0f);
		float num2 = 0.1f;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11100]");
			num2 = 0f;
		}
		Action onComplete2 = delegate
		{
			_areArmsAttached = true;
			_frontArm.Attach();
			Action onComplete3 = delegate
			{
				_backArm.Attach();
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timer3 = Timers.Register(0.1f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_isAttacking = false;
		};
		float duration = num2 * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}
}
