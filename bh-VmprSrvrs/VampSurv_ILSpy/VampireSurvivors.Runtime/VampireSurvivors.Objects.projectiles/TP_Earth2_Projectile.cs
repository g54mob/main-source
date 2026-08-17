using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Earth2_Projectile : Projectile
{
	private float _radius = 16f;

	private float _alpha = 0.7f;

	private PhaserSprite _animatedSprite;

	private float _startingAngle;

	private float _rotationSpeed;

	private bool _isDespawning;

	private TP_Earth2_Weapon _parentWeapon;

	private List<uint> _tints;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _tintTween;

	private Timer _expireTimer;

	protected unsafe override void Awake()
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_01f2: Expected O, but got F4
		//IL_018b: Expected O, but got Ref
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Torpor01");
				_animatedSprite = animatedSprite;
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Torpor", 1, 1, vector, text, num, flag);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
					object obj = UnityEngine.Random.value;
					if ((object)_animatedSprite != null)
					{
						Transform transform = _animatedSprite.transform;
						if ((object)transform != null)
						{
							Vector3 value = default(Vector3);
							transform.localEulerAngles = (Vector3)(&value);
							if ((object)_animatedSprite != null)
							{
								Transform transform2 = _animatedSprite.transform;
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
								Transform transform3 = base.transform;
								bool flag3 = (object)transform3 == null;
								bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0751: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00dd: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0768: Expected O, but got F4
		//IL_0172: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_01b0: Expected O, but got Ref
		//IL_01cd: Expected I, but got O
		//IL_0206: Expected O, but got I
		//IL_087a: Expected O, but got F4
		//IL_08a4: Expected O, but got I4
		//IL_0268: Expected O, but got I8
		//IL_0293: Expected O, but got I4
		//IL_027a: Expected O, but got I8
		//IL_07de: Expected O, but got F4
		//IL_082f: Expected O, but got F4
		//IL_03b2: Invalid comparison between F4 and I4
		//IL_0447: Expected I, but got O
		//IL_04a7: Expected O, but got I4
		//IL_054a: Expected I, but got O
		//IL_059c: Expected O, but got I4
		//IL_05c6: Expected O, but got I4
		//IL_05fe: Expected O, but got I4
		//IL_083d: Expected O, but got F4
		//IL_06c2: Expected I4, but got F4
		//IL_026d->IL07a8: Incompatible stack heights: 1 vs 0
		//IL_056d->IL056d: Incompatible stack heights: 2 vs 1
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		_isCullable = false;
		_isDespawning = false;
		float? parentWeapon;
		if ((object)_weapon == null)
		{
			parentWeapon = (float?)(object)0;
			goto IL_072a;
		}
		nint num = (nint)typeof(TP_Earth2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v79 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Earth2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v79 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Earth2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v159+FFFFFFF8+v74 @ rax_v154*8]");
			if (0 == (nint)typeof(TP_Earth2_Weapon))
			{
				obj3 = 1;
				goto IL_0739;
			}
		}
		obj3 = 0;
		goto IL_0739;
		IL_0739:
		bool flag = obj3 == null;
		parentWeapon = (float?)(object)0;
		if (!flag)
		{
			parentWeapon = (float?)_weapon;
		}
		goto IL_072a;
		IL_072a:
		_parentWeapon = (TP_Earth2_Weapon)parentWeapon;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		Weapon weapon3 = _weapon;
		float num4 = weapon3.PArea();
		object obj4 = default(object);
		float maxInclusive = (float)obj4 * 0.75f;
		float minInclusive = (float)obj4 * 0.5f;
		float num5 = UnityEngine.Random.Range(minInclusive, maxInclusive);
		object obj5 = UnityEngine.Random.value;
		float speed = num5 + 2f;
		float num6 = num5 * _radius;
		_speed = speed;
		float radius = num6 * 2.5f;
		BaseBody baseBody2 = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		Transform transform = _renderer.transform;
		object obj6 = default(object);
		transform.localEulerAngles = (Vector3)(&obj6);
		float num7 = UnityEngine.Random.Range(265f, 275f);
		nint num8 = (nint)this;
		_startingAngle = num7;
		float angleAim = num7 * ((float)Math.PI / 180f);
		base.ApplyAngleVelocity(angleAim, rotate: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag2 = (nint)0 != 0;
		TP_Earth2_Projectile tP_Earth2_Projectile = this;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag3 = obj7 == null;
			tP_Earth2_Projectile = (TP_Earth2_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v995 @ rax_v48 (should have been resolved before IL gen)");
		object obj8 = UnityEngine.Random.value;
		float num9 = 0.5f * 60f;
		bool flag4 = 0.5f > 0.5f;
		object obj9 = 1;
		if (!flag4)
		{
			obj9 = 4294967295L;
		}
		float rotationSpeed = (float)obj9 * num9;
		_rotationSpeed = rotationSpeed;
		PhaserSprite phaserSprite = _animatedSprite.setScale(num5, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(_alpha);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		object obj10 = UnityEngine.Random.value;
		TP_Earth2_Weapon parentWeapon2 = _parentWeapon;
		IEnumerable<uint> collection = ((!(0.1f > 0.5f)) ? parentWeapon2._baseTints : parentWeapon2._rainbowTints);
		List<uint> tints = new List<uint>(collection);
		_tints = tints;
		_tints._002Ector(collection);
		uint tint = default(uint);
		PhaserSprite phaserSprite4 = _animatedSprite.setTint(tint);
		Weapon weapon4 = _weapon;
		int num10 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.depth;
		int num11 = num10 + 1;
		PhaserSprite phaserSprite5 = _animatedSprite.setDepth(num11);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
		object obj11 = UnityEngine.Random.value;
		bool flag5 = 0.5f < 0.5f;
		float num12 = 0.5f - 0.5f;
		bool flag6 = num12 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		BlendMode blendMode = ((flag8 & flag7) ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite6 = _animatedSprite.setBlendMode(blendMode);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num13 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj12 = default(object);
		bool flag9 = obj12 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A570");
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_animatedSprite != null)
		{
			nint num14 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj13 = default(object);
			bool flag10 = obj13 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.tint = (uint?)(object)1;
		tweenConfig2.duration = 500f;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween tintTween = Tweens.Add(tweenConfig2);
		_tintTween = tintTween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 0.7f
		};
		object obj14 = UnityEngine.Random.value;
		float num15 = _alpha - 0.5f;
		float num16 = (soundConfig.Detune = num15 * 200f);
		float num17 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_crystal_quick, soundConfig, 50f, 1, num17);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num18 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		float duration = num16 * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num17 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_002b: Expected O, but got F4
		//IL_0021: Expected O, but got Ref
		Transform transform = base.transform;
		object obj = Time.deltaTime;
		object obj2 = default(object);
		transform.Rotate((Vector3)(&obj2), Space.Self);
	}

	private void StartDespawn()
	{
		//IL_0098: Expected I, but got O
		//IL_00fc: Expected O, but got I4
		//IL_0117: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Earth2_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected F4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			float startingAngle = _startingAngle;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float angleAim = startingAngle ^ 0;
			base.ApplyAngleVelocity(angleAim);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
