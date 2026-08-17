using System;
using System.Collections.Generic;
using System.Globalization;
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

public class LEM_Inferno2_Projectile : Projectile
{
	private SpriteRenderer _FireRendererBlue;

	private SpriteRenderer _FireRendererRed;

	private Texture _BlueTexture;

	private Texture _RedTexture;

	private GenericShadowText _TextCounterBlue;

	private GenericShadowText _TextCounterRed;

	private GenericShadowText _MultiplierText;

	private readonly float2 BodySize;

	private const float TweenInDurationMillis = 100f;

	private LEM_Inferno2_Weapon _trueWeapon;

	private float _currentAngleDeg;

	private int _lastBlueKillScore;

	private int _lastRedKillScore;

	private Material _instancedMaterialRed;

	private Material _instancedMaterialBlue;

	private MorphVFX _morphVFX;

	private Tween _alphaTween;

	private Tween _alphaTween2;

	private MultiTargetTween _textWobbleTweenBlue;

	private MultiTargetTween _textWobbleTweenRed;

	private Timer _expireTimer;

	private Timer _hitBoxTimer;

	private Timer _tweenInTimer;

	public float CurrentAngle => _currentAngleDeg;

	private float RotationDegreesPerSecond
	{
		get
		{
			float deltaTime = PauseSystem.DeltaTime;
			return deltaTime * 135f;
		}
	}

	private List<GenericShadowText> TextCounters
	{
		get
		{
			List<GenericShadowText> list = new List<GenericShadowText>();
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD1D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD1D0");
				return list;
			}
			return (List<GenericShadowText>)(object)new NullReferenceException();
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
		Material instancedMaterialBlue = _instancedMaterialBlue;
		if ((object)_instancedMaterialBlue == null || ((UnityEngine.Object)instancedMaterialBlue).m_CachedPtr == (IntPtr)0)
		{
			Material material = ((Renderer)_FireRendererBlue).GetMaterial();
			_instancedMaterialBlue = material;
			((Renderer)_FireRendererBlue).SetMaterial(_instancedMaterialBlue);
		}
		Material instancedMaterialRed = _instancedMaterialRed;
		if ((object)_instancedMaterialRed == null || ((UnityEngine.Object)instancedMaterialRed).m_CachedPtr == (IntPtr)0)
		{
			Material material2 = ((Renderer)_FireRendererRed).GetMaterial();
			_instancedMaterialRed = material2;
			((Renderer)_FireRendererRed).SetMaterial(_instancedMaterialRed);
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_013b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		LEM_Inferno2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_01e0;
		}
		nint num = (nint)typeof(LEM_Inferno2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Inferno2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v27+FFFFFFF8+v65 @ rax_v22*8]");
			if (0 == (nint)typeof(LEM_Inferno2_Weapon))
			{
				obj3 = 1;
				goto IL_01ef;
			}
		}
		obj3 = 0;
		goto IL_01ef;
		IL_01ef:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (LEM_Inferno2_Weapon)_weapon;
		}
		goto IL_01e0;
		IL_01e0:
		_trueWeapon = trueWeapon;
		_isCullable = false;
		_lastBlueKillScore = 0;
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		object obj4 = BodySize ^ -0f;
		float x = (float)obj4 * 0.5f;
		BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		InitSprites();
		InitText();
		StartTimers();
		MakeMorphVFX();
		Weapon weapon3 = _weapon;
		_morphVFX.PlaySparkle(((Equipment)weapon3)._003COwner_003Ek__BackingField);
	}

	private void InitSprites()
	{
		Material instancedMaterialBlue = _instancedMaterialBlue;
		if ((object)_instancedMaterialBlue != null && ((UnityEngine.Object)instancedMaterialBlue).m_CachedPtr != (IntPtr)0)
		{
			int num = Shader.PropertyToID("_GradientLookUp");
			_instancedMaterialBlue.SetTextureImpl(num, _BlueTexture);
		}
		Material instancedMaterialRed = _instancedMaterialRed;
		if ((object)_instancedMaterialRed != null && ((UnityEngine.Object)instancedMaterialRed).m_CachedPtr != (IntPtr)0)
		{
			int num2 = Shader.PropertyToID("_GradientLookUp");
			_instancedMaterialRed.SetTextureImpl(num2, _RedTexture);
		}
		_FireRendererBlue.sortingOrder = 999;
		_FireRendererRed.sortingOrder = 999;
		List<GenericShadowText> textCounters = TextCounters;
		List<GenericShadowText>.Enumerator enumerator = default(List<GenericShadowText>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	private void InitText()
	{
		List<GenericShadowText> textCounters = TextCounters;
		if (textCounters != null)
		{
			List<GenericShadowText>.Enumerator enumerator = default(List<GenericShadowText>.Enumerator);
			if (enumerator.MoveNext())
			{
				GenericShadowText genericShadowText = null;
				GenericShadowText genericShadowText2 = RenderingExtensions.SetScale<GenericShadowText>(null, 1f);
				LEM_Inferno2_Projectile lEM_Inferno2_Projectile = null;
				throw new NullReferenceException();
			}
			if ((object)_MultiplierText != null)
			{
				_MultiplierText.SetAlpha(1f);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void StartTimers()
	{
		//IL_018f: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		LEM_Inferno2_Weapon trueWeapon = _trueWeapon;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!((LEM_Inferno1_Weapon)trueWeapon)._InfiniteDuration)
		{
			float num = _weapon.PDuration();
			Action onComplete = FadeOut;
			object obj2 = default(object);
			object obj = obj2 + obj2;
			float duration = (float)obj * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		float num2 = hitBoxDelay * 0.5f;
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		Action onComplete2 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration2 = num2 * 0.001f;
		Timer hitBoxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitBoxTimer = hitBoxTimer;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_tweenInTimer != null)
		{
			_tweenInTimer.Cancel();
		}
		Timer tweenInTimer = Timers.Register(0.1f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tweenInTimer = tweenInTimer;
	}

	private void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			morphVFX._burstTint = new uint[4] { 37886u, 16731200u, 37886u, 16731200u };
			morphVFX._sparkName = "blurredSharpStar.png";
			morphVFX._diskName = "disc.png";
			_morphVFX = morphVFX;
			_morphVFX.Make();
		}
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

	public unsafe override void InternalUpdate()
	{
		//IL_005f: Expected F4, but got I4
		//IL_006c: Expected F4, but got I4
		//IL_003a: Expected F4, but got I4
		//IL_0043: Expected F4, but got I4
		//IL_00b9: Expected I, but got O
		//IL_049d: Expected O, but got I4
		//IL_0277: Invalid comparison between I4 and F4
		LEM_Inferno2_Weapon trueWeapon = _trueWeapon;
		float num;
		float num2;
		if (0 <= ((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
			num = 0f;
			num2 = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = ((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
			num2 = ((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
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
		Weapon weapon = _weapon;
		nint num6 = (nint)weapon;
		float num7 = weapon.PArea();
		float num8 = num2 * num4;
		float num9 = num8 * num5;
		bool flag2 = !(5f > num9);
		float num10 = 5f;
		if (!flag2)
		{
			num10 = num9;
		}
		ArcadeSprite arcadeSprite = setScale(num10, (float?)(object)0);
		bool flag3 = !(1f < num10);
		float alpha = 1f;
		if (!flag3)
		{
			if (num10 < 3.5f)
			{
				float num11 = num10 - 1f;
				float num12 = num11 * 0.5f;
				float num13 = num12 / 2.5f;
				alpha = 1f - num13;
			}
			else
			{
				alpha = 0.5f;
			}
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_FireRendererBlue, alpha);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_FireRendererRed, alpha);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		float deltaTime = PauseSystem.DeltaTime;
		float maxDelta = deltaTime * 135f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v9 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float target = 0f * 57.29578f;
		float num14 = (_currentAngleDeg = Mathf.MoveTowardsAngle(_currentAngleDeg, target, maxDelta)) * ((float)Math.PI / 180f);
		float num15 = base.scale;
		float num16 = num15 * 0.5f;
		if (!(0f > num16))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		Weapon weapon3 = _weapon;
		float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		if ((object)_trueWeapon != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float2 float6 = default(float2);
			base.position = float6;
			UpdateText();
			LEM_Inferno2_Weapon trueWeapon2 = _trueWeapon;
			if (((LEM_Inferno1_Weapon)trueWeapon2)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField >= 3080)
			{
				Weapon weapon4 = _weapon;
				_morphVFX.PlaySparkle(((Equipment)weapon4)._003COwner_003Ek__BackingField);
				LEM_Inferno2_Weapon trueWeapon3 = _trueWeapon;
				_trueWeapon.DoCoinRosary();
				_trueWeapon.DoNaneinfTextAnim();
				Action action = _trueWeapon.DoJimboSpriteAnim;
				action._002Ector(_trueWeapon, (nint)__ldftn(LEM_Inferno2_Weapon.DoJimboSpriteAnim));
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.25f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				((LEM_Inferno1_Weapon)_trueWeapon).DespawnActiveProjectiles();
				float num17 = _trueWeapon.PInterval();
				if (!(((Weapon)trueWeapon3)._003CTotalTime_003Ek__BackingField < 0.25f))
				{
					float num18 = _trueWeapon.PInterval();
					float num19 = 0.25f - 2000f;
					((Weapon)trueWeapon3)._003CTotalTime_003Ek__BackingField = num19;
				}
			}
			return;
		}
		throw new NullReferenceException();
	}

	private void UpdateScale()
	{
		//IL_005f: Expected F4, but got I4
		//IL_006c: Expected F4, but got I4
		//IL_003a: Expected F4, but got I4
		//IL_0043: Expected F4, but got I4
		//IL_0215: Expected O, but got I4
		LEM_Inferno2_Weapon trueWeapon = _trueWeapon;
		float num;
		float num2;
		if (0 <= ((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
			num = 0f;
			num2 = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = ((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
			num2 = ((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
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
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_FireRendererBlue, alpha);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_FireRendererRed, alpha);
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
		//IL_00ba: Invalid comparison between I4 and F4
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		float deltaTime = PauseSystem.DeltaTime;
		float maxDelta = deltaTime * 135f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rcx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float target = 0f * 57.29578f;
		float num = (_currentAngleDeg = Mathf.MoveTowardsAngle(_currentAngleDeg, target, maxDelta)) * ((float)Math.PI / 180f);
		float num2 = base.scale;
		float num3 = num2 * 0.5f;
		if (!(0f > num3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm1\"");
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
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Ref, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Ref, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected Ref, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Ref, but got Unknown
		//IL_040a: Expected O, but got Ref
		LEM_Inferno2_Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			if (trueWeapon._003CBlueKillScore_003Ek__BackingField <= _lastBlueKillScore)
			{
				goto IL_0451;
			}
			GenericShadowText textCounterBlue = _TextCounterBlue;
			string formattedKillText = GetFormattedKillText(trueWeapon._003CBlueKillScore_003Ek__BackingField);
			if ((object)_TextCounterBlue != null && (object)textCounterBlue._Text != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				if ((object)textCounterBlue._ShadowText != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
					DoTextWobble(ref *(GenericShadowText*)(this + 240), ref *(MultiTargetTween*)(this + 336), trueWeapon._003CBlueKillScore_003Ek__BackingField);
					if ((object)_trueWeapon != null)
					{
						_trueWeapon.PlayBlueTextSfx();
						_lastBlueKillScore = trueWeapon._003CBlueKillScore_003Ek__BackingField;
						goto IL_0451;
					}
				}
			}
		}
		goto IL_040b;
		IL_0451:
		LEM_Inferno2_Weapon trueWeapon2 = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			if (trueWeapon2._003CRedKillScore_003Ek__BackingField <= _lastRedKillScore)
			{
				goto IL_047a;
			}
			GenericShadowText textCounterRed = _TextCounterRed;
			string formattedKillText2 = GetFormattedKillText(trueWeapon2._003CRedKillScore_003Ek__BackingField);
			if ((object)_TextCounterRed != null && (object)textCounterRed._Text != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				if ((object)textCounterRed._ShadowText != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
					DoTextWobble(ref *(GenericShadowText*)(this + 248), ref *(MultiTargetTween*)(this + 344), trueWeapon2._003CRedKillScore_003Ek__BackingField);
					if ((object)_trueWeapon != null)
					{
						_trueWeapon.PlayRedTextSfx(trueWeapon2._003CRedKillScore_003Ek__BackingField);
						_lastRedKillScore = trueWeapon2._003CRedKillScore_003Ek__BackingField;
						goto IL_047a;
					}
				}
			}
		}
		goto IL_040b;
		IL_047a:
		float alpha;
		if (_alphaTween != null)
		{
			float num = TweenExtensions.ElapsedPercentage(_alphaTween);
			alpha = 1f - num;
		}
		else
		{
			alpha = 1f;
		}
		List<GenericShadowText> textCounters = TextCounters;
		if (textCounters != null)
		{
			List<GenericShadowText> list = textCounters;
			List<GenericShadowText>.Enumerator enumerator = default(List<GenericShadowText>.Enumerator);
			if (enumerator.MoveNext())
			{
				List<GenericShadowText> list2 = null;
				nint num2 = (nint)(&enumerator);
				throw new NullReferenceException();
			}
			if ((object)_MultiplierText != null)
			{
				_MultiplierText.SetAlpha(alpha);
				GenericShadowText multiplierText = _MultiplierText;
				if ((object)_MultiplierText != null && (object)multiplierText._ShadowText != null)
				{
					Color color = multiplierText._ShadowText.color;
					List<GenericShadowText> list3 = default(List<GenericShadowText>);
					multiplierText._ShadowText.color = (Color)(&list3);
					return;
				}
			}
		}
		goto IL_040b;
		IL_040b:
		throw new NullReferenceException();
	}

	private string GetFormattedKillText(int kills)
	{
		//IL_0083: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0221: Expected O, but got I4
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4B02]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num5 = default(int);
		if (kills >= 20)
		{
			if (kills >= 110)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
				int num = kills >> 2;
				int num2 = num >> 31;
				object obj = num + num2;
				object obj2 = obj * 4;
				object obj3 = obj + obj2;
				object obj4 = obj3 + obj3;
				float value;
				if (kills == (nint)obj4)
				{
					float num3 = UnityEngine.Random.Range(0.01f, 0.09f);
					value = num3 + 1f;
				}
				else
				{
					float num4 = UnityEngine.Random.Range(0.1f, 0.99f);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
					object obj5 = obj >> 2;
					object obj6 = obj5 >> 31;
					object obj7 = obj5 + obj6;
					object obj8 = obj7 * 4;
					object obj9 = obj7 + obj8;
					object obj10 = obj9 + obj9;
					object obj11 = kills - obj10;
					value = num4 + (float)obj11;
				}
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string text = System.Number.FormatSingle(value, "0.00", currentInfo);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
				string text2 = num5.ToString();
				return text + "e" + text2;
			}
			float num6 = (float)kills / 10f;
			float num7 = num6 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			object obj12 = default(object);
			if ((nint)obj12 > 8)
			{
				obj12 = 8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
			float num8 = UnityEngine.Random.Range(1f, 10f);
			float num9 = (float)kills * 10f;
			float value2 = num8 + num9;
			NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
			return System.Number.FormatSingle(value2, "N0", currentInfo2);
		}
		return num5.ToString();
	}

	private unsafe void DoTextWobble(ref GenericShadowText textCounter, ref MultiTargetTween tween, int killCount = 0)
	{
		//IL_00ea: Expected O, but got Ref
		//IL_0171: Expected I, but got O
		//IL_01d4: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField || (tween != null && tween.IsAlive()))
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
		GenericShadowText genericShadowText = RenderingExtensions.SetScale(textCounter, num3);
		Transform transform = textCounter.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		if (tween != null)
		{
			tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform2 = textCounter.transform;
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
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		ref MultiTargetTween reference = ref *(MultiTargetTween*)multiTargetTween;
	}

	private unsafe void CheckForNaneInf()
	{
		LEM_Inferno2_Weapon trueWeapon = _trueWeapon;
		if (((LEM_Inferno1_Weapon)trueWeapon)._003CKillsWhileCurrentProjectileActive_003Ek__BackingField >= 3080)
		{
			Weapon weapon = _weapon;
			_morphVFX.PlaySparkle(((Equipment)weapon)._003COwner_003Ek__BackingField);
			LEM_Inferno2_Weapon trueWeapon2 = _trueWeapon;
			_trueWeapon.DoCoinRosary();
			_trueWeapon.DoNaneinfTextAnim();
			Action action = _trueWeapon.DoJimboSpriteAnim;
			action._002Ector(_trueWeapon, (nint)__ldftn(LEM_Inferno2_Weapon.DoJimboSpriteAnim));
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.25f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			((LEM_Inferno1_Weapon)_trueWeapon).DespawnActiveProjectiles();
			float num = _trueWeapon.PInterval();
			if (!(((Weapon)trueWeapon2)._003CTotalTime_003Ek__BackingField < 0.25f))
			{
				float num2 = _trueWeapon.PInterval();
				float num3 = 0.25f - 2000f;
				((Weapon)trueWeapon2)._003CTotalTime_003Ek__BackingField = num3;
			}
		}
	}

	public void SetAngle(float angleDegrees)
	{
		_currentAngleDeg = angleDegrees;
	}

	private unsafe void FadeOut()
	{
		//IL_005c: Expected O, but got Ref
		//IL_0080: Expected I, but got O
		//IL_0188: Expected O, but got Ref
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_alphaTween != null)
		{
			TweenExtensions.Kill(_alphaTween);
		}
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOColor(_FireRendererRed, (Color)(&obj), 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Inferno2_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
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
		if (_alphaTween2 != null)
		{
			TweenExtensions.Kill(_alphaTween2);
		}
		TweenerCore<Color, Color, ColorOptions> alphaTween = DOTweenModuleSprite.DOColor(_FireRendererBlue, (Color)(&obj), 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_alphaTween2 = alphaTween;
	}

	public override void Despawn()
	{
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
		if (_alphaTween2 != null)
		{
			TweenExtensions.Kill(_alphaTween2);
		}
		if (_textWobbleTweenBlue != null)
		{
			_textWobbleTweenBlue.Kill();
		}
		if (_textWobbleTweenRed != null)
		{
			_textWobbleTweenRed.Kill();
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

	public LEM_Inferno2_Projectile()
	{
		//IL_0017: Expected O, but got I4
		BodySize = (float2)1121714176;
		_ = 1108344832;
		base._002Ector();
	}

	private void _003CStartTimers_003Eb__33_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
