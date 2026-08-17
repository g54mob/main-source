using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Holy1_Projectile : Projectile
{
	private const float Radius = 32f;

	private const float CrossOffsetY = 0.44f;

	private const float CrossBGScale = 1.1f;

	private const float FadeDuration = 250f;

	private PhaserSprite _areaSprite;

	private PhaserSprite _crossSprite;

	private PhaserSprite _crossSprite2;

	private PhaserSprite _crossSpriteBG;

	private PhaserSprite _crossSpriteBG2;

	private Tween _scaleTween;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _crossTween;

	private MultiTargetTween _crossTween2;

	private const float MaxAlpha = 0.8f;

	private Timer _expireTimer;

	private Timer _hitboxTimer;

	private Timer _healTimer;

	private TP_Holy1_Weapon _parentWeapon;

	private bool _geminiProjectile;

	private float2 _initialPos;

	private float[] _requiemRandomOffsets;

	private int _requiemRandomIndex;

	protected override void Awake()
	{
		//IL_021c: Expected O, but got I4
		//IL_02bf: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Holy05");
		PhaserSprite areaSprite = phaserSprite.setBlendMode(BlendMode.Add);
		_areaSprite = areaSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Holy01");
		PhaserSprite phaserSprite3 = phaserSprite2.setLocalPosition(0f, 0.44f);
		PhaserSprite phaserSprite4 = phaserSprite3.setDepth(1);
		PhaserSprite phaserSprite5 = phaserSprite4.setBlendMode(BlendMode.Normal);
		GameObject gameObject3 = phaserSprite5.gameObject;
		((UnityEngine.Object)gameObject3).SetName("_crossSprite");
		_crossSprite = phaserSprite5;
		GameObject gameObject4 = base.gameObject;
		PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "ThosePeople", "TP_VFX_Holy03");
		PhaserSprite phaserSprite7 = phaserSprite6.setLocalPosition(0f, 0.44f);
		PhaserSprite phaserSprite8 = phaserSprite7.setDepth(1);
		PhaserSprite phaserSprite9 = phaserSprite8.setBlendMode(BlendMode.Normal);
		GameObject gameObject5 = phaserSprite9.gameObject;
		((UnityEngine.Object)gameObject5).SetName("_crossSprite2");
		_crossSprite2 = phaserSprite9;
		GameObject gameObject6 = base.gameObject;
		PhaserSprite phaserSprite10 = RenderingExtensions.AddPhaserSprite(gameObject6, pos, "ThosePeople", "TP_VFX_Holy02");
		PhaserSprite phaserSprite11 = phaserSprite10.setLocalPosition(0f, 0.44f);
		PhaserSprite phaserSprite12 = phaserSprite11.setScale(1.1f, (float?)(object)0);
		PhaserSprite phaserSprite13 = phaserSprite12.setBlendMode(BlendMode.Normal);
		GameObject gameObject7 = phaserSprite13.gameObject;
		((UnityEngine.Object)gameObject7).SetName("_crossSpriteBG");
		_crossSpriteBG = phaserSprite13;
		GameObject gameObject8 = base.gameObject;
		PhaserSprite phaserSprite14 = RenderingExtensions.AddPhaserSprite(gameObject8, pos, "ThosePeople", "TP_VFX_Holy04");
		PhaserSprite phaserSprite15 = phaserSprite14.setLocalPosition(0f, 0.44f);
		PhaserSprite phaserSprite16 = phaserSprite15.setScale(1.1f, (float?)(object)0);
		PhaserSprite phaserSprite17 = phaserSprite16.setBlendMode(BlendMode.Normal);
		GameObject gameObject9 = phaserSprite17.gameObject;
		((UnityEngine.Object)gameObject9).SetName("_crossSpriteBG2");
		_crossSpriteBG2 = phaserSprite17;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0060: Expected I, but got O
		//IL_0068: Expected I, but got O
		//IL_0078: Expected O, but got I
		//IL_00f8: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0774: Expected O, but got I4
		//IL_00b4: Expected O, but got I
		//IL_00ea: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_02b5: Expected F4, but got O
		//IL_042a: Expected I, but got O
		//IL_0482: Expected I, but got O
		//IL_04f4: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		BaseBody baseBody = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		float? parentWeapon;
		if ((object)weapon == null)
		{
			parentWeapon = (float?)(object)0;
			goto IL_074d;
		}
		nint num = (nint)typeof(TP_Holy1_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdx_v91 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Holy1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v79 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdx_v91 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Holy1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v79 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v144+FFFFFFF8+v314 @ rax_v139*8]");
			if (0 == (nint)typeof(TP_Holy1_Weapon))
			{
				obj3 = 1;
				goto IL_075c;
			}
		}
		obj3 = 0;
		goto IL_075c;
		IL_075c:
		bool flag = obj3 == null;
		parentWeapon = (float?)(object)0;
		if (!flag)
		{
			parentWeapon = (float?)weapon;
		}
		goto IL_074d;
		IL_074d:
		_parentWeapon = (TP_Holy1_Weapon)parentWeapon;
		TP_Holy1_Weapon parentWeapon2 = _parentWeapon;
		bool isPrimaryWeapon = parentWeapon2.IsPrimaryWeapon;
		bool geminiProjectile = !isPrimaryWeapon;
		_geminiProjectile = geminiProjectile;
		float2 float5 = (_initialPos = ((Equipment)weapon)._003COwner_003Ek__BackingField.position);
		_ = 3253731328L;
		float num4 = _weapon.PArea();
		float num5 = weapon.PDuration();
		float hitBoxDelay = _weapon.HitBoxDelay;
		float num6 = _weapon.PSpeed();
		float num7 = _weapon.PAmount();
		float num8 = hitBoxDelay + hitBoxDelay;
		float num9 = hitBoxDelay / num8;
		float num10 = _weapon.PHitBoxDelayOverSpeed();
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_Holy1_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__23_1(0f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, (float)float5, 0.25f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rax_v39 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 27;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)_areaSprite != null)
		{
			((TP_Holy1_Projectile)(object)_areaSprite)._003CInitProjectile_003Eb__23_1(0f);
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_crossSpriteBG != null)
		{
			nint num11 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_crossSprite != null)
		{
			nint num12 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite = _areaSprite.setAlpha(0f);
			PhaserSprite phaserSprite2 = _crossSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = _crossSprite2.setAlpha(0f);
			PhaserSprite phaserSprite4 = _crossSpriteBG.setAlpha(0f);
			PhaserSprite phaserSprite5 = _crossSpriteBG2.setAlpha(0f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = DoCrossAnim;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete2 = StartDespawn;
		float duration = (float)float5 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		Action onComplete3 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration2 = num9 * 0.001f;
		Timer hitboxTimer = Timers.Register(duration2, onComplete3, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if (_healTimer != null)
		{
			_healTimer.Cancel();
		}
		Action onComplete4 = HealPlayersInArea;
		float duration3 = num8 * 0.001f;
		Timer healTimer = Timers.Register(duration3, onComplete4, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_healTimer = healTimer;
		HealPlayersInArea();
	}

	public override void InternalUpdate()
	{
		if (_geminiProjectile)
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Weapon weapon2 = _weapon;
			float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			float2 float7 = default(float2);
			base.position = float7;
		}
	}

	private void DoCrossAnim()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_011e: Expected I4, but got I8
		//IL_013a: Expected O, but got I4
		//IL_01d3: Expected I, but got O
		//IL_022b: Expected I, but got O
		//IL_0293: Expected I4, but got I8
		//IL_02af: Expected O, but got I4
		if (_crossTween != null)
		{
			_crossTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_crossSpriteBG != null)
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
		if ((object)_crossSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween crossTween = Tweens.Add(tweenConfig);
		_crossTween = crossTween;
		if (_crossTween2 != null)
		{
			_crossTween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_crossSpriteBG2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_crossSprite2 != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 100f;
		tweenConfig2.repeat = -1;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween crossTween2 = Tweens.Add(tweenConfig2);
		_crossTween2 = crossTween2;
	}

	public override void Despawn()
	{
		//IL_01f7: Expected O, but got I4
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		_isCullable = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_healTimer != null)
		{
			_healTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_crossTween != null)
		{
			_crossTween.Kill();
		}
		if (_crossTween2 != null)
		{
			_crossTween2.Kill();
		}
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float num = weapon.SecondaryPAmount();
			float2 float5 = base.position;
			object obj = default(object);
			if ((nint)obj > 0)
			{
				object obj2 = 0;
				float2 pos = default(float2);
				do
				{
					int requiemRandomIndex = _requiemRandomIndex + 1;
					_requiemRandomIndex = requiemRandomIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
					float num2 = _weapon.PArea();
					int requiemRandomIndex2 = _requiemRandomIndex + 1;
					_requiemRandomIndex = requiemRandomIndex2;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
					float num3 = _weapon.PArea();
					Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
					obj2++;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
			}
		}
		base.Despawn();
	}

	private void StartDespawn()
	{
		//IL_00e9: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_0199: Expected I, but got O
		//IL_01f1: Expected I, but got O
		//IL_0249: Expected I, but got O
		//IL_02bb: Expected O, but got I4
		//IL_02d6: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_crossTween != null)
		{
			_crossTween.Kill();
		}
		if (_crossTween2 != null)
		{
			_crossTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[5];
		if ((object)_crossSprite != null)
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
		if ((object)_crossSprite2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_crossSpriteBG != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_crossSpriteBG2 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_areaSprite != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Holy1_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num6 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void HealPlayersInArea()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		do
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
		}
		while (!IsCharacterInRange(null));
		throw new NullReferenceException();
	}

	private bool IsCharacterInRange(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_01a0: Invalid comparison between F4 and O
		//IL_0122->IL00c9: Incompatible stack heights: 1 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			object obj = default(object);
			float num2 = (float)obj * 32f;
			float num3 = num2 * 0.01f;
			float num4 = num3 * num3;
			if ((object)character != null)
			{
				float2 float5 = character.position;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						object obj2 = (object)ret - (object)float5;
						object obj4 = default(object);
						object obj5 = default(object);
						object obj3 = obj4 - obj5;
						object obj6 = obj2 * obj2;
						object obj7 = obj3 * obj3;
						object obj8 = obj6 + obj7;
						bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8);
						return !flag3;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public TP_Holy1_Projectile()
	{
		float[] requiemRandomOffsets = new float[500];
		_requiemRandomOffsets = requiemRandomOffsets;
		base._002Ector();
	}

	private float _003CInitProjectile_003Eb__23_0()
	{
		return base.scale;
	}

	private void _003CInitProjectile_003Eb__23_1(float x)
	{
		//IL_000f: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(x, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__23_3()
	{
		PhaserSprite phaserSprite = _areaSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _crossSprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = _crossSprite2.setAlpha(0f);
		PhaserSprite phaserSprite4 = _crossSpriteBG.setAlpha(0f);
		PhaserSprite phaserSprite5 = _crossSpriteBG2.setAlpha(0f);
	}

	private void _003CInitProjectile_003Eb__23_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
