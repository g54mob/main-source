using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodPlanetProjectile : Projectile
{
	private SpriteAnimation _SpriteAnimation;

	public EggFloat _Radius;

	private readonly List<float> _angles;

	private readonly List<string> _animNames;

	private float2 _ground;

	private float _myRotationAngle;

	private float _angleUnit;

	private float _angleRotUnit;

	public float _RadiusMulY;

	private float _radiusMulX;

	private float _amount;

	private BloodAstronomiaWeapon _trueWeapon;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Timer _expireTimer;

	private readonly List<float> _durations;

	private readonly List<float> _bodyRadii;

	private Timer _activationTimer;

	protected unsafe override void Awake()
	{
		//IL_024a: Expected O, but got I4
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected I4, but got Unknown
		//IL_00d7: Expected O, but got Ref
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		base.Awake();
		_angleUnit = (float)Math.PI * 2f / 9f;
		object obj = 0;
		object obj5 = default(object);
		int num3 = default(int);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		do
		{
			List<float> angles = _angles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj3 = 0;
			float item = (float)obj * _angleUnit;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v4+18]");
			if (num >= 0)
			{
				angles.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			int value = obj + 1;
			string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj5), null);
			string text2 = "p0" + text + "_";
			List<object> animNames = (List<object>)(object)_animNames;
			int version = animNames._version + 1;
			animNames._version = version;
			object[] items = animNames._items;
			if (animNames._size >= items.Length)
			{
				animNames.AddWithResize((object)text2);
			}
			else
			{
				int num2 = animNames._size + 1;
				animNames._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(text2, 1, 16, "vfx", num3);
			_SpriteAnimation.AddAnimation(text2, animationFrames, 16, (byte)num3 != 0, startRandomFrame, onComplete, autoSetAnimation);
			obj++;
		}
		while ((nint)obj < 9);
		_radiusMulX = 1f;
		_RadiusMulY = 1f;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		bool flag = (object)weapon == null;
		Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_0101;
		}
		nint num = (nint)typeof(BloodAstronomiaWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v16+FFFFFFF8+v59 @ rax_v12*8]");
			if (0 == (nint)typeof(BloodAstronomiaWeapon))
			{
				obj3 = 1;
				goto IL_0110;
			}
		}
		obj3 = 0;
		goto IL_0110;
		IL_0101:
		_trueWeapon = (BloodAstronomiaWeapon)trueWeapon;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		return;
		IL_0110:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = weapon;
		}
		goto IL_0101;
	}

	public void OverrideWeaponData(Weapon weapon)
	{
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Expected O, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Expected O, but got Unknown
		//IL_0080: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_089e: Expected O, but got I4
		//IL_019e: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_013a: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_013a: Expected F4, but got I
		//IL_023a: Expected I, but got O
		//IL_02db: Expected O, but got I4
		//IL_02f0: Expected F4, but got I
		//IL_0310: Expected I4, but got I8
		//IL_031e: Expected O, but got I4
		//IL_04f6: Expected I, but got O
		//IL_054c: Expected O, but got I4
		//IL_065e: Expected O, but got I
		//IL_0675: Expected F4, but got I
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Expected O, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
		object obj = (object)weapon >> 1;
		object obj2 = obj >> 31;
		object obj3 = obj + obj2;
		object obj4 = obj3 * 8;
		object obj5 = obj3 + obj4;
		object obj6 = _indexInWeapon - obj5;
		BaseBody baseBody = body;
		baseBody._enable = false;
		List<string> animNames = _animNames;
		if ((nint)obj6 >= animNames._size)
		{
			goto IL_0804;
		}
		string[] items = animNames._items;
		_SpriteAnimation.SetAnimation(items[obj6]);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		if ((nint)obj6 >= 0)
		{
			List<float> bodyRadii = _bodyRadii;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v150 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj6 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v150 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)obj6 >= 0)
				{
					goto IL_0804;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v150 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj7 = 0;
				BaseBody baseBody2 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r11_v7+20+v57 @ rbp_v2*4]");
				BaseBody baseBody3 = baseBody2.setCircle(0f, (float?)(object)0, (float?)(object)0);
				goto IL_088e;
			}
		}
		BaseBody baseBody4 = body.setCircle(0f, (float?)(object)0, (float?)(object)0);
		goto IL_088e;
		IL_08e8:
		float num2;
		float num = num2 * 8f;
		float num3 = (_angleRotUnit = (float)Math.PI / num);
		float num4 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PAmount();
		float num5;
		if (!(num3 > 10f))
		{
			object obj8 = 10f & -2147483649L;
			bool flag = (nint)obj8 <= 2139095040;
			num5 = num3;
			if (flag)
			{
				goto IL_0917;
			}
		}
		num5 = 10f;
		goto IL_0917;
		IL_0804:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_088e:
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setVisible(visible: true);
		List<float> durations = _durations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)obj6 < 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rcx_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj9 = 0;
			EggFloat radius = new EggFloat(0f);
			_Radius = radius;
			_radiusMulX = 1f;
			_RadiusMulY = 1f;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			if (obj10 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_RadiusMulY", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.scaleX = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v16+20+v57 @ rbp_v2*4]");
			tweenConfig.duration = 0f;
			tweenConfig.yoyo = true;
			tweenConfig.repeat = -1;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_001b: Expected O, but got I4
				_RadiusMulY = 1f;
				ArcadeSprite arcadeSprite5 = setScale(1f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_activationTimer != null)
			{
				_activationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				if (_activationTimer != null)
				{
					_activationTimer.Cancel();
				}
				BaseBody baseBody5 = body;
				baseBody5._enable = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer activationTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_activationTimer = activationTimer;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			float num7 = weapon.PInterval();
			float num8 = weapon.PDuration();
			Action onComplete2 = delegate
			{
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				FadeOut();
			};
			float num9 = 1f + 1000f;
			float num10 = num9 + 1f;
			float duration = num10 * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			ArcadeSprite arcadeSprite4 = setAlpha(0.1f);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num11 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			MagnetZone magnet = characterController._magnet;
			bool flag3 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_Radius", (object)magnet.Radius, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary2;
			tweenConfig2.duration = 200f;
			TweenCallback onStart2 = delegate
			{
				ArcadeSprite arcadeSprite5 = setAlpha(0.1f);
			};
			tweenConfig2.onStart = onStart2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
			float2 ground = base.position;
			List<float> angles = _angles;
			_ground = ground;
			_ = 1058642330;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v71 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj6 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v71 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v72+20+v57 @ rbp_v2*4]");
				_myRotationAngle = 0f;
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				MagnetZone magnet2 = characterController2._magnet;
				EggFloat radius2 = magnet2.Radius;
				num2 = radius2._eggVal + radius2._val;
				object obj13 = num2 & -2147483649L;
				if ((nint)obj13 != 2139095040)
				{
					object obj14 = num2 & -2147483649L;
					if ((nint)obj14 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF6C47h\"");
						if (num2 == -1f / 0f)
						{
							num2 = -3.4028235E+38f;
						}
						goto IL_08e8;
					}
				}
				num2 = 3.4028235E+38f;
				goto IL_08e8;
			}
		}
		goto IL_0804;
		IL_0917:
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float amount = (float)currentWeaponData._003Camount_003Ek__BackingField + num5;
		_amount = amount;
	}

	public override void InternalUpdate()
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * _angleRotUnit;
		float myRotationAngle = num2 + _myRotationAngle;
		_myRotationAngle = myRotationAngle;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		EggFloat radius = _Radius;
		if (_Radius != null)
		{
			float eggValue = default(float);
			float value = default(float);
			EggFloat eggFloat = new EggFloat(value, eggValue);
			eggValue = radius._eggVal * 0.01f;
			value = radius._val * 0.01f;
			if (eggFloat != null)
			{
				float num3 = eggFloat._eggVal + eggFloat._val;
				object obj = num3 & -2147483649L;
				if ((nint)obj != 2139095040)
				{
					object obj2 = num3 & -2147483649L;
					if ((nint)obj2 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF6EA0h\"");
						if (num3 != -1f / 0f)
						{
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				EggFloat radius2 = _Radius;
				if (_Radius != null)
				{
					float eggValue2 = default(float);
					float value2 = default(float);
					EggFloat eggFloat2 = new EggFloat(value2, eggValue2);
					eggValue2 = radius2._eggVal * 0.01f;
					value2 = radius2._val * 0.01f;
					if (eggFloat2 != null)
					{
						float num4 = eggFloat2._eggVal + eggFloat2._val;
						object obj3 = num4 & -2147483649L;
						if ((nint)obj3 != 2139095040)
						{
							object obj4 = num4 & -2147483649L;
							if ((nint)obj4 <= 2139095040)
							{
								bool flag = num4 == -1f / 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF6F73h\"");
								if (flag)
								{
								}
							}
						}
						BloodPlanetProjectile cachedTransform = (BloodPlanetProjectile)(object)_cachedTransform;
						bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
						Vector3 value3 = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value3);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		base.Despawn();
	}

	public override bool CanExplode()
	{
		return true;
	}

	public override void Explode(Vector2? pos = null)
	{
		//IL_00cf: Expected O, but got I4
		//IL_0056: Expected F4, but got I
		//IL_0056: Expected F4, but got I
		//IL_007b: Invalid comparison between I4 and F4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 200f, 3, num);
		BloodAstronomiaWeapon trueWeapon = _trueWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pos @ rdx (System.Nullable`1<UnityEngine.Vector2>)+4]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pos @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
		trueWeapon.SpawnBloodExplosionVfxAt(num2, 0f, 10f, num);
		if (!(0f < --_amount))
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			FadeOut();
		}
	}

	private void FadeOut()
	{
		//IL_00cc: Expected I, but got O
		//IL_0130: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0167: Expected I, but got O
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.scaleY = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPlanetProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public BloodPlanetProjectile()
	{
		//IL_0055: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_084d: Expected O, but got I
		//IL_0119: Expected O, but got I
		//IL_0875: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_089d: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_08c5: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_08ed: Expected O, but got I
		//IL_02c1: Expected O, but got I
		//IL_0915: Expected O, but got I
		//IL_032b: Expected O, but got I
		//IL_093d: Expected O, but got I
		//IL_0395: Expected O, but got I
		//IL_0965: Expected O, but got I
		//IL_03ff: Expected O, but got I
		//IL_098d: Expected O, but got I
		//IL_0469: Expected O, but got I
		//IL_04b0: Expected O, but got I
		//IL_050a: Expected O, but got I
		//IL_09c4: Expected O, but got I
		//IL_0574: Expected O, but got I
		//IL_09ec: Expected O, but got I
		//IL_05de: Expected O, but got I
		//IL_0a14: Expected O, but got I
		//IL_0648: Expected O, but got I
		//IL_0a3c: Expected O, but got I
		//IL_06b2: Expected O, but got I
		//IL_0a64: Expected O, but got I
		//IL_071c: Expected O, but got I
		//IL_0a8c: Expected O, but got I
		//IL_0786: Expected O, but got I
		//IL_0ab4: Expected O, but got I
		//IL_07f0: Expected O, but got I
		List<float> angles = new List<float>();
		_angles = angles;
		_animNames = new List<string>();
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v8+18]");
		if (num >= 0)
		{
			list.AddWithResize(2399f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1159065600;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v9+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(2441f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1159237632;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v10+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(1861f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1156096000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v11+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(1009f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1148993536;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(1217f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1150820352;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rdx_v13+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(2341f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1158828032;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdx_v14+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(2467f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1159344128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdx_v15+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(2099f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1157836800;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdx_v16+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(1489f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1153048576;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v17+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(1619f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1154113536;
		}
		_durations = list;
		List<float> list2 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v20+18]");
		if (num11 >= 0)
		{
			list2.AddWithResize(16f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1098907648;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v37+18]");
		if (num12 >= 0)
		{
			list2.AddWithResize(24f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1103101952;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rdx_v22+18]");
		if (num13 >= 0)
		{
			list2.AddWithResize(24f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1103101952;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v23+18]");
		if (num14 >= 0)
		{
			list2.AddWithResize(24f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1103101952;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v43+18]");
		if (num15 >= 0)
		{
			list2.AddWithResize(32f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1107296256;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rdx_v25+18]");
		if (num16 >= 0)
		{
			list2.AddWithResize(32f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1107296256;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdx_v26+18]");
		if (num17 >= 0)
		{
			list2.AddWithResize(32f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 1107296256;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v27+18]");
		if (num18 >= 0)
		{
			list2.AddWithResize(8f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 1090519040;
		}
		_bodyRadii = list2;
		base._002Ector();
	}

	private void _003COverrideWeaponData_003Eb__20_2()
	{
		//IL_001b: Expected O, but got I4
		_RadiusMulY = 1f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	private void _003COverrideWeaponData_003Eb__20_0()
	{
		if (_activationTimer != null)
		{
			_activationTimer.Cancel();
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003COverrideWeaponData_003Eb__20_1()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}

	private void _003COverrideWeaponData_003Eb__20_3()
	{
		ArcadeSprite arcadeSprite = setAlpha(0.1f);
	}
}
