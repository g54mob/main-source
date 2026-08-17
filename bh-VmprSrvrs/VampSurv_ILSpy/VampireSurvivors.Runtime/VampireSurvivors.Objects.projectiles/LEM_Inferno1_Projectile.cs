using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Inferno1_Projectile : Projectile
{
	private SpriteRenderer _FireRenderer;

	private Texture _RedTexture;

	private Texture _BlueTexture;

	private GenericShadowText _TextCounter;

	private readonly float2 BodySize;

	private const float TweenInDurationMillis = 500f;

	private LEM_Inferno1_Weapon _trueWeapon;

	private float _currentAngleDeg;

	private int _lastKillCount;

	private Material _instancedMaterial;

	private Tween _alphaTween;

	private MultiTargetTween _textWobbleTween;

	private Timer _expireTimer;

	private Timer _hitBoxTimer;

	private Timer _tweenInTimer;

	public float CurrentAngle => _currentAngleDeg;

	private bool IsCounterProj
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = _indexInWeapon - 1;
			return obj == null;
		}
	}

	private float RotationDegreesPerSecond
	{
		get
		{
			float num = ((_indexInWeapon != 1) ? 180f : 90f);
			float deltaTime = PauseSystem.DeltaTime;
			return deltaTime * num;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		Material instancedMaterial = _instancedMaterial;
		if ((object)_instancedMaterial == null || ((UnityEngine.Object)instancedMaterial).m_CachedPtr == (IntPtr)0)
		{
			Material material = ((Renderer)_FireRenderer).GetMaterial();
			_instancedMaterial = material;
			((Renderer)_FireRenderer).SetMaterial(_instancedMaterial);
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0027: Expected I, but got O
		//IL_002f: Expected I4, but got O
		//IL_003f: Expected O, but got I
		//IL_00bf: Expected O, but got I4
		//IL_007b: Expected O, but got I
		//IL_00b1: Expected O, but got I4
		//IL_012b: Expected O, but got I8
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_0161: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_0142: Expected O, but got I4
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_019e: Expected O, but got I4
		//IL_0204: Expected O, but got Ref
		int index2 = default(int);
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index2);
		Weapon weapon2 = _weapon;
		LEM_Inferno1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0254;
		}
		nint num = (nint)typeof(LEM_Inferno1_Weapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r9_v3 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno1_Weapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r9_v3 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v40+FFFFFFF8+v68 @ rax_v35*8]");
			if (0 == (nint)typeof(LEM_Inferno1_Weapon))
			{
				obj3 = 1;
				goto IL_0263;
			}
		}
		obj3 = 0;
		goto IL_0263;
		IL_0263:
		bool flag = obj3 == null;
		pool2 = (BulletPool)(object)typeof(LEM_Inferno1_Weapon);
		trueWeapon = null;
		if (!flag)
		{
			pool2 = (BulletPool)(object)typeof(LEM_Inferno1_Weapon);
			trueWeapon = (LEM_Inferno1_Weapon)_weapon;
		}
		goto IL_0254;
		IL_0254:
		_trueWeapon = trueWeapon;
		Weapon weapon3 = _weapon;
		_isCullable = false;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
		bool flag2 = _indexInWeapon == 1;
		object obj4 = 4294967295L;
		if (!flag2)
		{
			obj4 = 1;
		}
		object obj5 = (object)characterController._lastMovementDirection * obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v6 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		object obj6 = 0 * obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float currentAngleDeg = (float)obj6 * 57.29578f;
		_lastKillCount = 0;
		_currentAngleDeg = currentAngleDeg;
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		object obj7 = BodySize ^ -0f;
		float x = (float)obj7 * 0.5f;
		BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		InitSprites();
		GenericShadowText genericShadowText = RenderingExtensions.SetScale(_TextCounter, 1f);
		Transform transform = _TextCounter.transform;
		object obj8 = default(object);
		transform.localEulerAngles = (Vector3)(&obj8);
		StartTimers();
		TweenIn();
	}

	private void InitSprites()
	{
		Material instancedMaterial = _instancedMaterial;
		if ((object)_instancedMaterial != null && ((UnityEngine.Object)instancedMaterial).m_CachedPtr != (IntPtr)0)
		{
			Texture value = ((_indexInWeapon != 1) ? _RedTexture : _BlueTexture);
			int num = Shader.PropertyToID("_GradientLookUp");
			_instancedMaterial.SetTextureImpl(num, value);
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_FireRenderer, 0f);
		_TextCounter.SetAlpha(0f);
		_FireRenderer.sortingOrder = 999;
		_TextCounter.SetDepth(1001);
	}

	private unsafe void InitText()
	{
		//IL_003f: Expected O, but got Ref
		GenericShadowText genericShadowText = RenderingExtensions.SetScale(_TextCounter, 1f);
		Transform transform = _TextCounter.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void StartTimers()
	{
		//IL_0177: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		LEM_Inferno1_Weapon trueWeapon = _trueWeapon;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!trueWeapon._InfiniteDuration)
		{
			float num = _weapon.PDuration();
			Action onComplete = FadeOut;
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete2 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration2 = hitBoxDelay * 0.001f;
		Timer hitBoxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitBoxTimer = hitBoxTimer;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_tweenInTimer != null)
		{
			_tweenInTimer.Cancel();
		}
		Timer tweenInTimer = Timers.Register(0.5f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tweenInTimer = tweenInTimer;
	}

	private unsafe void TweenIn()
	{
		//IL_001d: Invalid comparison between F4 and O
		//IL_0082: Expected O, but got Ref
		//IL_003d: Invalid comparison between O and F4
		float num = _weapon.PArea();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3.5f))
		{
		}
		if (_alphaTween != null)
		{
			TweenExtensions.Kill(_alphaTween);
		}
		object obj2 = default(object);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOColor(_FireRenderer, (Color)(&obj2), 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_alphaTween = tweenerCore;
	}

	private float GetAlphaFromScale(float scale)
	{
		bool flag = !(1f < scale);
		float result = 1f;
		if (!flag)
		{
			if (scale < 3.5f)
			{
				float num = scale - 1f;
				float num2 = num * 0.5f;
				float num3 = num2 / 2.5f;
				return 1f - num3;
			}
			result = 0.5f;
		}
		return result;
	}

	public override void InternalUpdate()
	{
		//IL_005f: Expected F4, but got I4
		//IL_006c: Expected F4, but got I4
		//IL_003a: Expected F4, but got I4
		//IL_0043: Expected F4, but got I4
		//IL_020e: Expected O, but got I4
		LEM_Inferno1_Weapon trueWeapon = _trueWeapon;
		float num;
		float num2;
		if (0 <= trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
			num = 0f;
			num2 = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
			num2 = trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
		}
		bool flag = _tweenInTimer == null;
		float num3 = num * 0.05f;
		float num4 = num3 + 1f;
		float num5;
		if (!flag)
		{
			Timer tweenInTimer = _tweenInTimer;
			num2 = _tweenInTimer.GetTimeElapsed();
			num5 = num2 / tweenInTimer._003CDuration_003Ek__BackingField;
		}
		else
		{
			num5 = 1f;
		}
		float num6 = _weapon.PArea();
		float num7 = num2 * num4;
		float num8 = num7 * num5;
		bool flag2 = !(5f > num8);
		float num9 = 5f;
		if (!flag2)
		{
			num9 = num8;
		}
		ArcadeSprite arcadeSprite = setScale(num9, (float?)(object)0);
		bool flag3 = !(1f < num9);
		float alpha = 1f;
		if (!flag3)
		{
			if (num9 < 3.5f)
			{
				float num10 = num9 - 1f;
				float num11 = num10 * 0.5f;
				float num12 = num11 / 2.5f;
				alpha = 1f - num12;
			}
			else
			{
				alpha = 0.5f;
			}
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_FireRenderer, alpha);
		UpdatePosition();
		UpdateText();
	}

	private void UpdateScale()
	{
		//IL_005f: Expected F4, but got I4
		//IL_006c: Expected F4, but got I4
		//IL_003a: Expected F4, but got I4
		//IL_0043: Expected F4, but got I4
		//IL_01fd: Expected O, but got I4
		LEM_Inferno1_Weapon trueWeapon = _trueWeapon;
		float num;
		float num2;
		if (0 <= trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
			num = 0f;
			num2 = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
			num2 = trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
		}
		bool flag = _tweenInTimer == null;
		float num3 = num * 0.05f;
		float num4 = num3 + 1f;
		float num5;
		if (!flag)
		{
			Timer tweenInTimer = _tweenInTimer;
			num2 = _tweenInTimer.GetTimeElapsed();
			num5 = num2 / tweenInTimer._003CDuration_003Ek__BackingField;
		}
		else
		{
			num5 = 1f;
		}
		float num6 = _weapon.PArea();
		float num7 = num2 * num4;
		float num8 = num7 * num5;
		bool flag2 = !(5f > num8);
		float num9 = 5f;
		if (!flag2)
		{
			num9 = num8;
		}
		ArcadeSprite arcadeSprite = setScale(num9, (float?)(object)0);
		bool flag3 = !(1f < num9);
		float alpha = 1f;
		if (!flag3)
		{
			if (num9 < 3.5f)
			{
				float num10 = num9 - 1f;
				float num11 = num10 * 0.5f;
				float num12 = num11 / 2.5f;
				alpha = 1f - num12;
			}
			else
			{
				alpha = 0.5f;
			}
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_FireRenderer, alpha);
	}

	private float GetPlayerFacingAngleDeg(bool invert = false)
	{
		//IL_002f: Expected O, but got I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		object obj = (invert ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		object obj4 = (object)characterController._lastMovementDirection * obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rcx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		object obj5 = 0 * obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		return (float)obj5 * 57.29578f;
	}

	private void UpdatePosition()
	{
		//IL_003f: Expected O, but got I8
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0056: Expected O, but got I4
		//IL_01d2: Invalid comparison between I4 and F4
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		bool flag = _indexInWeapon == 1;
		object obj = 4294967295L;
		if (!flag)
		{
			obj = 1;
		}
		object obj2 = (object)characterController._lastMovementDirection * obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rcx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		object obj3 = 0 * obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float target = (float)obj3 * 57.29578f;
		float num = ((_indexInWeapon != 1) ? 180f : 90f);
		float deltaTime = PauseSystem.DeltaTime;
		float maxDelta = deltaTime * num;
		float num2 = Mathf.MoveTowardsAngle(_currentAngleDeg, target, maxDelta);
		bool flag2 = _tweenInTimer == null;
		_currentAngleDeg = num2;
		float num3 = num2 * ((float)Math.PI / 180f);
		if (!flag2)
		{
			float timeElapsed = _tweenInTimer.GetTimeElapsed();
		}
		float num4 = base.scale;
		float num5 = num4 * 0.5f;
		if (!(0f > num5))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm1\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		Weapon weapon2 = _weapon;
		float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float6 = default(float2);
		base.position = float6;
	}

	private unsafe void UpdateText()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_01a7: Expected I, but got O
		//IL_01af: Expected I, but got O
		//IL_01bf: Expected O, but got I
		//IL_02a0: Expected O, but got Ref
		//IL_00b3: Expected I, but got O
		//IL_00bb: Expected I, but got O
		//IL_00cb: Expected O, but got I
		//IL_01fb: Expected O, but got I
		//IL_0107: Expected O, but got I
		//IL_0238: Expected O, but got I
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0144: Expected O, but got I
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_03d6: Expected O, but got Ref
		//IL_0409: Expected O, but got Ref
		LEM_Inferno1_Weapon trueWeapon = _trueWeapon;
		Weapon weapon = _weapon;
		int num = trueWeapon._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
		object obj = weapon + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		Weapon weapon2 = default(Weapon);
		if (obj4 == weapon2)
		{
			Weapon weapon3 = _weapon;
			if (_indexInWeapon == 1)
			{
				nint num2 = (nint)typeof(LEM_Inferno2_Weapon);
				nint num3 = (nint)weapon3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v40+FFFFFFF8+v136 @ rax_v39*8]");
					if (0 == (nint)typeof(LEM_Inferno2_Weapon))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v40+FFFFFFF8+v484 @ rcx_v31*8]");
						object obj8 = 0 - typeof(LEM_Inferno2_Weapon);
						bool flag = obj8 == null;
						bool flag2 = !flag;
						Weapon weapon4 = null;
						if (!flag2)
						{
							weapon4 = weapon3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rbp_v8 (VampireSurvivors.Objects.Weapons.Weapon)+180]");
						num = 0;
						goto IL_0292;
					}
				}
			}
			else
			{
				nint num5 = (nint)typeof(LEM_Inferno2_Weapon);
				nint num6 = (nint)weapon3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v37+FFFFFFF8+v138 @ rax_v36*8]");
					if (0 == (nint)typeof(LEM_Inferno2_Weapon))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v37+FFFFFFF8+v483 @ rcx_v29*8]");
						object obj12 = 0 - typeof(LEM_Inferno2_Weapon);
						bool flag3 = obj12 == null;
						bool flag4 = !flag3;
						Weapon weapon5 = null;
						if (!flag4)
						{
							weapon5 = weapon3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rbp_v6 (VampireSurvivors.Objects.Weapons.Weapon)+184]");
						num = 0;
						goto IL_0292;
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0292;
		IL_0292:
		object obj13 = default(object);
		string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj13), null);
		GenericShadowText textCounter = _TextCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		if (num > _lastKillCount)
		{
			DoTextWobble(num);
			if (_indexInWeapon != 1)
			{
				_trueWeapon.PlayRedTextSfx(num);
			}
			else
			{
				_trueWeapon.PlayBlueTextSfx();
			}
		}
		bool flag5 = _alphaTween == null;
		_lastKillCount = num;
		if (!flag5)
		{
			float num8 = TweenExtensions.ElapsedPercentage(_alphaTween);
			BaseBody baseBody = body;
			if (!baseBody._enable)
			{
			}
		}
		GenericShadowText textCounter2 = _TextCounter;
		Color color = textCounter2._Text.color;
		textCounter2._Text.color = (Color)(&obj13);
		GenericShadowText textCounter3 = _TextCounter;
		Color color2 = textCounter3._ShadowText.color;
		textCounter3._ShadowText.color = (Color)(&obj13);
	}

	private unsafe void DoTextWobble(int killCount = 0)
	{
		//IL_00ee: Expected O, but got Ref
		//IL_0178: Expected I, but got O
		//IL_01db: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField || (_textWobbleTween != null && _textWobbleTween.IsAlive()))
		{
			return;
		}
		float num = (float)killCount / 3000f;
		if (!(1f > num))
		{
			num = 1f;
		}
		float num2 = num * 200f;
		float num3 = num + 2f;
		float duration = 400f - num2;
		GenericShadowText genericShadowText = RenderingExtensions.SetScale(_TextCounter, num3);
		Transform transform = _TextCounter.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		if (_textWobbleTween != null)
		{
			_textWobbleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform2 = _TextCounter.transform;
		if ((object)transform2 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = duration;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.rotateMode = RotateMode.LocalAxisAdd;
		tweenConfig.ease = Ease.OutBack;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween textWobbleTween = Tweens.Add(tweenConfig);
		_textWobbleTween = textWobbleTween;
	}

	private unsafe void FadeOut()
	{
		//IL_005b: Expected O, but got Ref
		//IL_007f: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_alphaTween != null)
		{
			TweenExtensions.Kill(_alphaTween);
		}
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOColor(_FireRenderer, (Color)(&obj), 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Inferno1_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_alphaTween = tweenerCore;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_tweenInTimer != null)
		{
			_tweenInTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			TweenExtensions.Kill(_alphaTween);
		}
		if (_textWobbleTween != null)
		{
			_textWobbleTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_01fb->IL0162: Incompatible stack heights: 1 vs 0
		//IL_0161->IL0161: Incompatible stack heights: 1 vs 0
		if (other != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Transform component = gameObject.GetComponent<Transform>();
				if ((object)component == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v12 (UnityEngine.Transform)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				if ((object)_weapon != null)
				{
					if (!_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
					{
						return;
					}
					Weapon weapon = _weapon;
					if ((object)_weapon != null)
					{
						GameManager gameMan = weapon._gameMan;
						if ((object)weapon._gameMan != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v12 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v12 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							if (gameMan._arcanaManager != null)
							{
								Vector2 pos = default(Vector2);
								gameMan._arcanaManager.TriggerFireExplosion(pos);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public LEM_Inferno1_Projectile()
	{
		//IL_0017: Expected O, but got I4
		BodySize = (float2)1111490560;
		_ = 1108344832;
		base._002Ector();
	}

	private void _003CStartTimers_003Eb__25_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
