using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FlashArrowProjectile : Projectile
{
	private bool _hasHitFirstEnemy;

	private ParticleEmitterManager _pfxEmitter;

	private MultiTargetTween _lineTween;

	private MultiTargetTween _flashTween;

	private PhaserSprite _lineSprite;

	private PhaserSprite _flashSprite;

	private PhaserSprite _discSprite;

	private IMillionaire _trueWeapon;

	public bool _canMillionaire = true;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0148: Expected O, but got Ref
		//IL_015d: Expected native int or pointer, but got O
		//IL_0177: Expected O, but got I
		//IL_0197: Expected O, but got Ref
		//IL_01ac: Expected native int or pointer, but got O
		//IL_03e3: Expected O, but got I
		//IL_01e4: Expected O, but got Ref
		//IL_020b: Expected O, but got I
		//IL_0220: Expected native int or pointer, but got O
		//IL_023a: Expected O, but got I
		//IL_025a: Expected O, but got Ref
		//IL_0274: Expected native int or pointer, but got O
		//IL_041d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileArrow", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		base.angle = 90f;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"WhiteDot");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-1]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _pfxEmitter.CreateEmitter(particleSystemConfig);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "disc");
		PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
		PhaserSprite discSprite = phaserSprite2.setBlendMode(BlendMode.Add);
		_discSprite = discSprite;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserSprite phaserSprite3 = RenderingExtensions.sprite(s_scene2.add, pos, "vfx", "WhiteLineH");
		PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
		PhaserSprite lineSprite = phaserSprite4.setBlendMode(BlendMode.Add);
		_lineSprite = lineSprite;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserSprite phaserSprite5 = RenderingExtensions.sprite(s_scene3.add, pos, "vfx", "blurredSharpStar");
		PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
		PhaserSprite flashSprite = phaserSprite6.setBlendMode(BlendMode.Add);
		_flashSprite = flashSprite;
		_bounceActivated = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002b: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_00c9: Expected F4, but got I
		//IL_00d8: Expected O, but got Ref
		//IL_03b0: Expected O, but got I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0307: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_0292: Expected O, but got I4
		//IL_0292: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_canMillionaire = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		IMillionaire trueWeapon = default(IMillionaire);
		_trueWeapon = trueWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		_speed = 2f;
		SetScaleToArea();
		float2 float5 = base.position;
		object obj = default(object);
		float num = (float)obj + 0.22f;
		float2 float6 = default(float2);
		base.position = float6;
		if (!weapon.IsHoming)
		{
			Weapon weapon2 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v45 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			num = 0f;
			object obj2 = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj2));
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
		Weapon weapon3 = _weapon;
		_hasHitFirstEnemy = false;
		WeaponData currentWeaponData = weapon3._currentWeaponData;
		if ((object)currentWeaponData._003Cvolume_003Ek__BackingField != null)
		{
			Weapon weapon4 = _weapon;
			if (weapon4._currentWeaponData == null)
			{
				goto IL_030d;
			}
			bool flag = (nint)obj < 0;
			bool flag2 = !flag;
			object obj3 = (_003F?)currentWeaponData._003Cvolume_003Ek__BackingField & flag2;
			if (obj3 != null && (object)currentWeaponData._003Cvolume_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		int num2 = _weapon.PBounces();
		if (num2 > 0)
		{
			if (_bounceActivated)
			{
				goto IL_02f2;
			}
			_bounceActivated = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if ((object)s_scene.physics == null)
			{
				goto IL_030d;
			}
			WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			Weapon weapon5 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon5)._003COwner_003Ek__BackingField;
			Body body = base.body.setBoundsRectangle(characterController2._worldBoxCollider);
			BaseBody baseBody2 = base.body;
			baseBody2._onWorldBounds = true;
		}
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_02f2;
		IL_02f2:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		return;
		IL_030d:
		throw new NullReferenceException();
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_008a: Expected O, but got F4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (b == body)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			BaseBody baseBody = body;
			float num = (float)baseBody._velocity * -1f;
			baseBody._velocity = (float2)num;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v6 (BaseBody)+74]");
			float num2 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_01e6: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00c8: Expected I, but got O
		//IL_00a7: Expected O, but got I4
		//IL_015c: Expected O, but got F4
		//IL_010b: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		BaseBody baseBody = body;
		BaseBody baseBody2;
		if (body == null)
		{
			baseBody2 = null;
			goto IL_01f9;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v18+FFFFFFF8+v47 @ rax_v14*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_01c9;
			}
		}
		obj3 = 0;
		goto IL_01c9;
		IL_01c9:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(Body);
		baseBody2 = null;
		if (!flag)
		{
			num4 = (nint)typeof(Body);
			baseBody2 = body;
		}
		goto IL_01f9;
		IL_01f9:
		if (baseBody2 == body)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			BaseBody baseBody3 = body;
			float num5 = (float)baseBody3._velocity * -1f;
			baseBody3._velocity = (float2)num5;
			BaseBody baseBody4 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v8 (BaseBody)+74]");
			float num6 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		//IL_00f2: Expected O, but got I
		//IL_017f: Expected F4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && (_hasHitFirstEnemy ? 1 : 0) == (nint)obj)
		{
			_hasHitFirstEnemy = true;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				PlayUselessVfx();
			}
			BaseBody baseBody = body;
			float2 velocity = baseBody._velocity + baseBody._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v10 (BaseBody)+74]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v10 (BaseBody)+74]");
			object obj2 = num + 0;
			baseBody._velocity = velocity;
			if (_canMillionaire)
			{
				float2 float5 = base.position;
				float2 float6 = base.position;
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				Vector3 localEulerAngles = cachedTrans.localEulerAngles;
				float y = default(float);
				_trueWeapon.Millionaire((float)float5, y, localEulerAngles.z, 0);
			}
		}
	}

	public override void InternalUpdate()
	{
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		_pfxEmitter.EmitParticleAt(pos);
	}

	private unsafe void PlayUselessVfx()
	{
		//IL_0038: Expected O, but got Ref
		//IL_0052: Expected O, but got I4
		//IL_00e6: Expected O, but got Ref
		//IL_0100: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_025f: Expected I, but got O
		//IL_02b5: Expected O, but got I4
		//IL_02d1: Expected O, but got I4
		//IL_033b: Expected I, but got O
		//IL_0391: Expected O, but got I4
		//IL_039f: Expected O, but got I4
		//IL_03ad: Expected O, but got I4
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		Transform transform = _discSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite = _discSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
		PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: true);
		float2 float5 = base.position;
		PhaserSprite phaserSprite4 = phaserSprite3.setPosition(float5);
		Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles2 = cachedTrans2.localEulerAngles;
		Transform transform2 = _lineSprite.transform;
		transform2.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite5 = _lineSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(1f);
		PhaserSprite phaserSprite7 = phaserSprite6.setVisible(visible: true);
		float2 float6 = base.position;
		PhaserSprite phaserSprite8 = phaserSprite7.setPosition(float6);
		PhaserSprite phaserSprite9 = _flashSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(1f);
		PhaserSprite phaserSprite11 = phaserSprite10.setVisible(visible: true);
		float2 float7 = base.position;
		PhaserSprite phaserSprite12 = phaserSprite11.setPosition(float7);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_lineSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_discSprite != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 100f;
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween lineTween = Tweens.Add(tweenConfig);
		_lineTween = lineTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_flashSprite != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.angle = (float?)(object)1;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 200f;
		MultiTargetTween flashTween = Tweens.Add(tweenConfig2);
		_flashTween = flashTween;
	}
}
