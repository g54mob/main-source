using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects.VFX;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyRedBlue : EnemyController
{
	protected bool _isBlue;

	protected bool _isRed;

	protected bool _invertFlip;

	protected float _defaultScale;

	public static readonly List<WeaponType> BlueWeapons;

	public static readonly List<WeaponType> RedWeapons;

	private readonly List<uint> _003CTints_003Ek__BackingField;

	protected virtual List<uint> Tints => _003CTints_003Ek__BackingField;

	protected unsafe override void OnUpdate()
	{
		//IL_00af: Expected O, but got I4
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Expected O, but got Unknown
		//IL_00f4: Expected O, but got I4
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_01af: Expected O, but got F4
		//IL_01c6: Expected O, but got I4
		//IL_06f5: Expected O, but got F4
		//IL_09ab: Expected O, but got I4
		//IL_0590: Expected I4, but got I8
		//IL_0674->IL0674: Incompatible stack heights: 3 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		if (base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (base._003CConditionalCanMove_003Ek__BackingField)
		{
			RetargetIfNecessary();
			if (!base._fixedDirection)
			{
				goto IL_010c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187742FCDh\"");
			bool flag = (object)_currentDirection != null;
			object obj = 0;
			Transform transform = null;
			Vector2 vector = (Vector2)this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187742FCDh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRedBlue)+1E4]");
				bool flag2 = (nint)0 != 0;
				obj = 0;
				transform = null;
				vector = (Vector2)this;
				if (!flag2)
				{
					goto IL_010c;
				}
			}
			goto IL_01cb;
		}
		goto IL_07d0;
		IL_010c:
		object obj3 = default(object);
		if ((object)base._targetTransform != null)
		{
			Vector3 vector2 = base._targetTransform.position;
			Transform transform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Vector3 vector3 = _cachedTransform.position;
				float num2 = vector2.x - vector3.x;
				object obj2 = default(object);
				float num3 = (float)obj2 - (float)obj3;
				Vector2 vector = (Vector2)(this + 480);
				_currentDirection = (Vector2)num2;
				((Vector2*)vector)->Normalize();
				object obj = 0;
				goto IL_01cb;
			}
		}
		goto IL_07ef;
		IL_07d0:
		if (!_selfDestruct || _isSelfDestructionTriggered)
		{
			goto IL_0674;
		}
		if ((object)_cachedTransform != null)
		{
			Vector3 vector4 = _cachedTransform.position;
			float num4 = (float)obj3 * 100f;
			float num5 = vector4.x * 100f;
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform2 = gameSessionData._activeCharacter.transform;
				if ((object)transform2 != null)
				{
					Vector3 vector5 = transform2.position;
					float num6 = (float)obj3 * 100f;
					float num7 = vector5.x * 100f;
					float num8 = num5 - num7;
					float num9 = num4 - num6;
					float num10 = num8 * num8;
					float num11 = num9 * num9;
					float num12 = num10 + num11;
					if (!(base._003CSelfDestDistance_003Ek__BackingField > num12))
					{
						goto IL_0674;
					}
					if ((object)_AlertSpriteRenderer != null)
					{
						Transform target = _AlertSpriteRenderer.transform;
						_isSelfDestructionTriggered = true;
						if ((object)_AlertSpriteRenderer != null)
						{
							_AlertSpriteRenderer.forceRenderingOff = false;
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AlertSpriteRenderer, 1f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rax_v40 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rax_v40 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							Vector3 localPosition = _enemyRendererTransform.localPosition;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rax_v40 (UnityEngine.Transform)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rax_v40 (UnityEngine.Transform)+10]");
							float value2 = default(float);
							Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value2));
							Tween alertTween = _alertTween;
							if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
							{
								DG.Tweening.TweenExtensions.Kill(_alertTween);
							}
							Sequence alertTween2 = DOTween.Sequence();
							_alertTween = alertTween2;
							Sequence sequence = TweenSettingsExtensions.Insert(t: DOTweenModuleSprite.DOFade(_AlertSpriteRenderer, 0f, 0.2f), s: _alertTween, atPosition: 0f);
							Sequence sequence2 = TweenSettingsExtensions.Insert(t: ShortcutExtensions.DOScale(target, 0.9f, 0.2f), s: _alertTween, atPosition: 0f);
							Sequence alertTween3 = _alertTween;
							if (_alertTween != null && ((Tween)alertTween3)._003Cactive_003Ek__BackingField && !((Tween)alertTween3).creationLocked)
							{
								((Tween)alertTween3).loops = -1;
								((Tween)alertTween3).loopType = LoopType.Yoyo;
								if (((ABSSequentiable)alertTween3).tweenType == TweenType.Tweener)
								{
									((Tween)alertTween3).fullDuration = 1f / 0f;
								}
							}
							TweenCallback tweenCallback = delegate
							{
								//IL_003e: Expected O, but got I4
								Sequence alertTween5 = _alertTween;
								float timeScale = alertTween5.timeScale * 1.1f;
								alertTween5.timeScale = timeScale;
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								soundConfig.Volume = (float?)(object)1;
								soundConfig.Rate = 1f;
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Alert, soundConfig, 250f, 3, time);
							};
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DEC0");
							Sequence alertTween4 = _alertTween;
							bool flag5 = _alertTween == null;
							alertTween4.timeScale = 1f;
							Sequence sequence3 = VampireSurvivors.Tools.TweenExtensions.SetGameId(_alertTween);
							Action onComplete = base.OnSelfDestruct;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer selfDestructTimer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_selfDestructTimer = selfDestructTimer;
							goto IL_0674;
						}
					}
				}
			}
		}
		goto IL_07ef;
		IL_0674:
		if (!base._003CConditionalCanMove_003Ek__BackingField)
		{
			return;
		}
		bool flag6 = !_receivingDamage;
		float num13 = 1f;
		if (!flag6)
		{
			float num14 = base._003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj4 = num14 ^ 0;
			num13 = (float)obj4 * _damageKb;
		}
		bool flag7 = (nint)_currentDirection < 0;
		bool flag8 = (object)_currentDirection == null;
		bool flag9 = !flag7;
		bool flag10 = !flag8;
		bool flag11 = flag10 & flag9;
		base.SetFlipX(flag11);
		float num15 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
		float num16 = num15 / 100f;
		float num17 = num16 * num13;
		float num18 = num17 * base._003CSlow_003Ek__BackingField;
		float num19 = (float)_currentDirection * num18;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRedBlue)+1E4]");
		float num20 = 0f * num18;
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._velocity = (float2)num19;
			base.ProcessWiggle();
			float num21 = base.scale;
			float num22;
			if (!(_defaultScale > num21))
			{
				num22 = num21 - 0.01f;
				if (num22 < _defaultScale)
				{
					num22 = _defaultScale;
				}
			}
			else
			{
				num22 = num21 + 0.01f;
				if (num22 > _defaultScale)
				{
					num22 = _defaultScale;
				}
			}
			ArcadeSprite arcadeSprite2 = setScale(num22, (float?)(object)0);
			return;
		}
		goto IL_07ef;
		IL_01cb:
		if (_medusa)
		{
			float medusaElapsed = _medusaElapsed + 0.05f;
			_medusaElapsed = medusaElapsed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		}
		goto IL_07d0;
		IL_07ef:
		throw new NullReferenceException();
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		float num = default(float);
		float defaultScale = (((object)currentEnemyData._003Cscale_003Ek__BackingField == null) ? 1f : num);
		_defaultScale = defaultScale;
		GameManager core = GM.Core;
		CommonVfxManager commonVfxManager = core._commonVfxManager;
		commonVfxManager._pxfEmitterBlue.Stop();
		GameManager core2 = GM.Core;
		CommonVfxManager commonVfxManager2 = core2._commonVfxManager;
		commonVfxManager2._pfxEmitterRed.Stop();
	}

	public override void OnMusicBeat()
	{
		if (!_isRed)
		{
			TurnRed();
		}
		else
		{
			TurnBlue();
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_009a: Expected F4, but got I4
		//IL_02d2: Invalid comparison between F4 and I4
		//IL_015c: Invalid comparison between I4 and F4
		//IL_0060: Expected F4, but got I4
		//IL_0276: Expected O, but got I4
		//IL_0292: Expected O, but got F4
		//IL_0133: Expected O, but got F4
		//IL_01eb: Expected O, but got F4
		float num;
		List<WeaponType> redWeapons;
		if (!_isBlue)
		{
			if (!_isRed)
			{
				goto IL_00a8;
			}
			if (!_isBlue)
			{
				bool flag = !_isRed;
				num = 0f;
				if (!flag)
				{
					redWeapons = RedWeapons;
					goto IL_0078;
				}
				goto IL_0221;
			}
		}
		redWeapons = BlueWeapons;
		goto IL_0078;
		IL_0221:
		if (_damageWeakness > 1f)
		{
			num *= _damageWeakness;
		}
		float num2 = default(float);
		if (num > 0f)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CDamageNumbersEnabled_003Ek__BackingField)
			{
				float2 float5 = base.position;
				GM.Core.ShowDamageAt((Vector2)num2, num);
			}
		}
		float num3 = (_hp -= num);
		if (0f < num3)
		{
			_damageKb = damageKb;
		}
		else
		{
			base.Die();
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float num4 = num3 - 0.5f;
		float detune = num4 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, time);
		if (showHitVfx != HitVfxType.None)
		{
			float2 float6 = base.position;
			VFXManager.SpawnImpactVFX(showHitVfx, (Vector2)num2);
		}
		bool hasKb2 = default(bool);
		base.OnGetDamaged(showHitVfx, hasKb2);
		return;
		IL_0078:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj2 = default(object);
		bool flag2 = obj2 == null;
		num = 0f;
		if (!flag2)
		{
			goto IL_00a8;
		}
		goto IL_0221;
		IL_00a8:
		num = value;
		goto IL_0221;
	}

	protected override void OnRecycleEnemy()
	{
		//IL_0027: Expected I, but got O
		base.OnRecycleEnemy();
		nint num = (nint)this;
		List<uint> tints = Tints;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A570");
		uint num2 = default(uint);
		_saveTint = num2;
		ArcadeSprite arcadeSprite = setTint(num2);
		_isBlue = false;
		_invertFlip = false;
	}

	public virtual void TurnBlue()
	{
		//IL_0045: Expected O, but got I4
		//IL_00ba: Expected I4, but got I8
		if (!base._003CIsDead_003Ek__BackingField)
		{
			_isBlue = true;
			_invertFlip = false;
			_saveTint = 8947967u;
			ArcadeSprite arcadeSprite = setTint(8947967u);
			ArcadeSprite arcadeSprite2 = setScale(1.2f, (float?)(object)0);
			if (!base._003CIsTimeStopped_003Ek__BackingField)
			{
				GameManager core = GM.Core;
				CommonVfxManager commonVfxManager = core._commonVfxManager;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(commonVfxManager._pxfEmitterBlue, pos, -1);
			}
			else
			{
				ArcadeSprite arcadeSprite3 = setTint(255u);
			}
		}
	}

	public virtual void TurnRed()
	{
		//IL_003a: Expected O, but got I4
		//IL_00af: Expected I4, but got I8
		if (!base._003CIsDead_003Ek__BackingField)
		{
			_isBlue = false;
			_saveTint = 16746632u;
			ArcadeSprite arcadeSprite = setTint(16746632u);
			ArcadeSprite arcadeSprite2 = setScale(1.2f, (float?)(object)0);
			if (!base._003CIsTimeStopped_003Ek__BackingField)
			{
				GameManager core = GM.Core;
				CommonVfxManager commonVfxManager = core._commonVfxManager;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(commonVfxManager._pfxEmitterRed, pos, -1);
			}
			else
			{
				ArcadeSprite arcadeSprite3 = setTint(255u);
			}
		}
	}

	private static float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
	}

	public EnemyRedBlue()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01a9: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01d1: Expected O, but got I
		//IL_0156: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(8947814u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 8947814;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8939110u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8939110;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(8947780u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 8947780;
		}
		_003CTints_003Ek__BackingField = list;
		base._002Ector();
	}

	static EnemyRedBlue()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_25ee: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_2616: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_263e: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_2666: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_268e: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_26b6: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_26de: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_2706: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_272e: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_2756: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_277e: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_27a6: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_27ce: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_27f6: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_281e: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_2846: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_286e: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_2896: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_28be: Expected O, but got I
		//IL_0860: Expected O, but got I
		//IL_28e6: Expected O, but got I
		//IL_08ca: Expected O, but got I
		//IL_290e: Expected O, but got I
		//IL_0934: Expected O, but got I
		//IL_2936: Expected O, but got I
		//IL_099e: Expected O, but got I
		//IL_295e: Expected O, but got I
		//IL_0a08: Expected O, but got I
		//IL_2986: Expected O, but got I
		//IL_0a72: Expected O, but got I
		//IL_29ae: Expected O, but got I
		//IL_0add: Expected O, but got I
		//IL_0c81: Expected O, but got I
		//IL_0cdc: Expected O, but got I
		//IL_254d: Expected O, but got I
		//IL_25a7: Expected O, but got I
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v6+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rcx_v8+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v10+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v12+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v14+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 14;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v16+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v18+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)22);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 22;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v20+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)23);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v22+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)73);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 73;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v24+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)43);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 43;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v26+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)90);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 90;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v28+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)85);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 85;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v30+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)29);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 29;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v32+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)31);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 31;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rcx_v34+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)78);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 78;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v36+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)92);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 92;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v38+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)111);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 111;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v40+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)116);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 116;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v42+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)101);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 101;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v44+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)119);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 119;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v46+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)126);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 126;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v48+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)124);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 124;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v50+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)125);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 125;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v52+18]");
		if (num24 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)127);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 127;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v54+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v56+18]");
		if (num26 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 8;
		}
		list.Add(WeaponType.HEAVENSWORD);
		list.Add(WeaponType.BORA);
		list.Add(WeaponType.TRIASSO1);
		list.Add(WeaponType.TRIASSO2);
		list.Add(WeaponType.TRIASSO3);
		list.Add(WeaponType.MIRAGEROBE);
		list.Add(WeaponType.MIRAGEROBE2);
		list.Add(WeaponType.CONEOFCOLD);
		list.Add(WeaponType.CONEOFCOLD_COUNTER);
		list.Add(WeaponType.COLDEXPLOSION);
		list.Add(WeaponType.JUBILEE);
		list.Add(WeaponType.JUBILEE_RAYS);
		list.Add(WeaponType.ROCHER);
		list.Add(WeaponType.PARTY_COUNTER);
		list.Add(WeaponType.SONG);
		list.Add(WeaponType.MANNAGGIA);
		list.Add(WeaponType.ICELANCE);
		list.Add(WeaponType.ICELANCE2);
		list.Add(WeaponType.STARRYHEAVENDAMAGE);
		list.Add(WeaponType.SANTAJAVELIN);
		list.Add(WeaponType.SANTAJAVELIN2);
		list.Add(WeaponType.SANTAJAVELINCOUNTER);
		list.Add(WeaponType.SANTAJAVELIN2EXPLO);
		list.Add(WeaponType.PURIFYWEIRDSOULS);
		list.Add(WeaponType.EX_MAGISTONE1);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v81+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)164);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 164;
		}
		list.Add(WeaponType.ROSARY);
		list.Add(WeaponType.PENTAGRAM);
		list.Add(WeaponType.SIRE);
		list.Add(WeaponType.PRISMATICMISS);
		list.Add(WeaponType.PRISMATICMISS2);
		list.Add(WeaponType.CHERRY);
		list.Add(WeaponType.CHERRY2);
		list.Add(WeaponType.CHERRY_STAR);
		list.Add(WeaponType.CHERRY_STAR_EXPLO);
		list.Add(WeaponType.BONE);
		list.Add(WeaponType.BONE2);
		list.Add(WeaponType.FLOWER);
		list.Add(WeaponType.FLOWER2);
		list.Add(WeaponType.CART2);
		list.Add(WeaponType.CART2EVO);
		list.Add(WeaponType.FOURSEASONS);
		list.Add(WeaponType.FOURSEASONS2);
		list.Add(WeaponType.C1_SWIPECARD2);
		list.Add(WeaponType.C1_VENT2);
		list.Add(WeaponType.C1_SAMPLES1);
		list.Add(WeaponType.C1_HATCOLLECTION1);
		list.Add(WeaponType.C1_HATCOLLECTION_EXPLO);
		list.Add(WeaponType.C1_SWIPECARD1_SPARK);
		list.Add(WeaponType.C1_TONGUE1_COUNTER);
		list.Add(WeaponType.C1_SAMPLES1_EXPLOSION);
		list.Add(WeaponType.NOVA_ICEE);
		list.Add(WeaponType.FB_LASER);
		list.Add(WeaponType.FB_CRUSH);
		list.Add(WeaponType.FB_PRISMCUTLASS);
		list.Add(WeaponType.FB_PROTONBEAM);
		list.Add(WeaponType.FB_TIMEWARP);
		list.Add(WeaponType.FB_DIVERMINES);
		list.Add(WeaponType.FB_PRISMCUTLASS_COUNTER);
		list.Add(WeaponType.TP_ALUCARDSPEAR1);
		list.Add(WeaponType.TP_ALUCARDSPEAR1_BODY);
		list.Add(WeaponType.TP_ALUCARDSPEAR2);
		list.Add(WeaponType.TP_ALUCARDSPEAR_POMMEL);
		list.Add(WeaponType.TP_ALUCARDSWORD1);
		list.Add(WeaponType.TP_IRONBALL1);
		list.Add(WeaponType.TP_IRONBALL2);
		list.Add(WeaponType.TP_JAVELIN1);
		list.Add(WeaponType.TP_JAVELIN2);
		list.Add(WeaponType.TP_BWAKA1);
		list.Add(WeaponType.TP_BWAKA2);
		list.Add(WeaponType.TP_SHURIKEN1);
		list.Add(WeaponType.TP_SHURIKEN2);
		list.Add(WeaponType.TP_DISCUS1);
		list.Add(WeaponType.TP_DISCUS2);
		list.Add(WeaponType.TP_PLATINUMWHIP1);
		list.Add(WeaponType.TP_PLATINUMWHIP2);
		list.Add(WeaponType.TP_DRAGONWATER1);
		list.Add(WeaponType.TP_DRAGONWATER1_NODE);
		list.Add(WeaponType.TP_DRAGONWATER2);
		list.Add(WeaponType.TP_ALUCARDSHIELD);
		list.Add(WeaponType.TP_ACID1);
		list.Add(WeaponType.TP_ACID1_COUNTER);
		list.Add(WeaponType.TP_ACID2);
		list.Add(WeaponType.TP_EARTH1);
		list.Add(WeaponType.TP_EARTH1_COUNTER);
		list.Add(WeaponType.TP_EARTH2);
		list.Add(WeaponType.TP_ELEC1);
		list.Add(WeaponType.TP_ELEC1_COUNTER);
		list.Add(WeaponType.TP_ELEC2);
		list.Add(WeaponType.TP_ICE1);
		list.Add(WeaponType.TP_ICE1_COUNTER);
		list.Add(WeaponType.TP_ICE2);
		list.Add(WeaponType.TP_HOLY1);
		list.Add(WeaponType.TP_HOLY1_COUNTER);
		list.Add(WeaponType.TP_WIND1);
		list.Add(WeaponType.TP_WIND1_COUNTER);
		list.Add(WeaponType.TP_WIND2);
		list.Add(WeaponType.TP_SONICWHIP1);
		list.Add(WeaponType.TP_SONICWHIP2);
		list.Add(WeaponType.TP_WINDWHIP1);
		list.Add(WeaponType.TP_WINDWHIP1_EXPLOSION);
		list.Add(WeaponType.TP_WINDWHIP1_FIRE);
		list.Add(WeaponType.TP_WINDWHIP1_NODE);
		list.Add(WeaponType.TP_WINDWHIP2);
		list.Add(WeaponType.TP_MACE1);
		list.Add(WeaponType.TP_MACE1_CRIT);
		list.Add(WeaponType.TP_MACE1_CRIT_LINGER);
		list.Add(WeaponType.TP_MACE1_LINGER);
		list.Add(WeaponType.TP_SLASH2);
		list.Add(WeaponType.TP_SACREDBEASTS1);
		list.Add(WeaponType.TP_SACREDBEASTS2);
		list.Add(WeaponType.TP_STARFLAIL1);
		list.Add(WeaponType.TP_STARFLAIL1_BLADE);
		list.Add(WeaponType.TP_STARFLAIL1_BODY);
		list.Add(WeaponType.TP_STARFLAIL2);
		list.Add(WeaponType.TP_STARFLAIL2_BLADE);
		list.Add(WeaponType.TP_SHIELD1);
		list.Add(WeaponType.TP_SHIELD1_BLADE);
		list.Add(WeaponType.TP_SHIELD2);
		list.Add(WeaponType.TP_SHIELD2_METEORS);
		list.Add(WeaponType.TP_DARK1);
		list.Add(WeaponType.TP_DARK2);
		list.Add(WeaponType.TP_ENERGY1);
		list.Add(WeaponType.TP_ENERGY1_COUNTER);
		list.Add(WeaponType.TP_ENERGY2);
		list.Add(WeaponType.TP_LIGHT1);
		list.Add(WeaponType.TP_LIGHT2);
		list.Add(WeaponType.TP_LIGHT2_ORBIT);
		list.Add(WeaponType.TP_UNIVERSITAS);
		list.Add(WeaponType.TP_RAPIDUS1);
		list.Add(WeaponType.TP_RAPIDUS2);
		list.Add(WeaponType.TP_NEUTRON_PICKUP);
		list.Add(WeaponType.TP_NEUTRON_WEAPON);
		list.Add(WeaponType.TP_NEUTRON_WEAPON2);
		list.Add(WeaponType.TP_HYDROSTORM);
		list.Add(WeaponType.TP_HYDROSTORM_WATERDRAGONWHIP);
		list.Add(WeaponType.TP_HYDROSTORM2);
		list.Add(WeaponType.TP_GRANDCROSS);
		list.Add(WeaponType.TP_GRANDCROSS_PLATINUMWHIP);
		list.Add(WeaponType.TP_GRANDCROSS2);
		list.Add(WeaponType.TP_SONICWHIP1_NODE);
		list.Add(WeaponType.TP_DARKRIFT);
		list.Add(WeaponType.TP_DARKRIFT_JETBLACKWHIP);
		list.Add(WeaponType.TP_DARKRIFT2);
		list.Add(WeaponType.TP_VALMANWAY);
		list.Add(WeaponType.TP_VALMANWAY_SONICWHIP);
		list.Add(WeaponType.TP_VALMANWAY2);
		list.Add(WeaponType.TP_BLUEFIRE_WEAPON);
		list.Add(WeaponType.TP_ICEBRAND);
		list.Add(WeaponType.TP_ICEBRAND2);
		list.Add(WeaponType.TP_SUMMON_SPIRIT);
		list.Add(WeaponType.TP_SUMMON_SPIRIT2);
		list.Add(WeaponType.TP_SWORD_BROTHERS);
		list.Add(WeaponType.TP_SWORD_BROTHERS2);
		list.Add(WeaponType.TP_SPIRITTORNADO);
		list.Add(WeaponType.TP_SPIRITTORNADO_WINDWHIP);
		list.Add(WeaponType.TP_SPIRITTORNADO2);
		list.Add(WeaponType.TP_SOULSTEAL_WEAPON);
		list.Add(WeaponType.TP_SOULSTEAL_WEAPON2);
		list.Add(WeaponType.TP_POWEROFLIRE);
		list.Add(WeaponType.TP_GEARS_WEAPON);
		list.Add(WeaponType.TP_PENDULUM_WEAPON);
		list.Add(WeaponType.TP_ELEVATOR_WEAPON);
		list.Add(WeaponType.TP_HEADS_WEAPON);
		list.Add(WeaponType.TP_CLOCKTOWER_WEAPON);
		list.Add(WeaponType.TP_SHAFTORB);
		list.Add(WeaponType.TP_DEATHHAND);
		list.Add(WeaponType.TP_DRACULAHAND);
		list.Add(WeaponType.TP_FROG);
		list.Add(WeaponType.TP_FROG_COUNTER);
		list.Add(WeaponType.TP_FROG2);
		list.Add(WeaponType.TP_POCKET2);
		list.Add(WeaponType.EME_RAPIER1);
		list.Add(WeaponType.EME_RAPIER2);
		list.Add(WeaponType.EME_RAPIER3);
		list.Add(WeaponType.EME_DUAL1);
		list.Add(WeaponType.EME_DUAL2);
		list.Add(WeaponType.EME_PUNCH1);
		list.Add(WeaponType.EME_PUNCH2);
		list.Add(WeaponType.EME_PUNCH3);
		list.Add(WeaponType.EME_MAGIC1);
		list.Add(WeaponType.EME_MAGIC2);
		list.Add(WeaponType.EME_RING_WOOD);
		list.Add(WeaponType.EME_KNIFE1);
		list.Add(WeaponType.EME_KNIFE2);
		list.Add(WeaponType.EME_SPEAR1);
		list.Add(WeaponType.EME_SPEAR2);
		list.Add(WeaponType.EME_SPEAR3);
		list.Add(WeaponType.EME_PISTOL1);
		list.Add(WeaponType.EME_PISTOL2);
		list.Add(WeaponType.EME_LONGSWORD1);
		list.Add(WeaponType.EME_LONGSWORD2);
		list.Add(WeaponType.EME_LONGSWORD3);
		list.Add(WeaponType.EME_KICK1);
		list.Add(WeaponType.EME_KICK2);
		list.Add(WeaponType.EME_WAVE);
		list.Add(WeaponType.EME_WAVE2);
		list.Add(WeaponType.EME_MECH_RAVE);
		list.Add(WeaponType.LEM_INFERNO2);
		list.Add(WeaponType.LEM_BANANA1);
		list.Add(WeaponType.LEM_BANANA1);
		list.Add(WeaponType.LEM_FIBONACCI1);
		list.Add(WeaponType.LEM_FIBONACCI2);
		list.Add(WeaponType.LEM_PLANETS1);
		list.Add(WeaponType.LEM_PLANETS2);
		BlueWeapons = list;
		List<WeaponType> list2 = new List<WeaponType>
		{
			WeaponType.FIREBALL,
			WeaponType.SILF2_COUNTER,
			WeaponType.SILF3,
			WeaponType.GUNS,
			WeaponType.GUNS_COUNTER,
			WeaponType.TRAPANO,
			WeaponType.SHROUD,
			WeaponType.CORRIDOR,
			WeaponType.VENTO2,
			WeaponType.VENTO2_EXPLO,
			WeaponType.VENTO2_EXTRA,
			WeaponType.MISSPELL,
			WeaponType.SUMMONNIGHT,
			WeaponType.NIGHTSWORD,
			WeaponType.NIGHTSWORD2,
			WeaponType.LEGIONNAIRE,
			WeaponType.VAMPIRICA,
			WeaponType.HEAVENSWORD,
			WeaponType.SCYTHE,
			WeaponType.VESPERS,
			WeaponType.HELLFIRE,
			WeaponType.TRAPANO2,
			WeaponType.MIRAGEROBE2,
			WeaponType.FIREEXPLOSION,
			WeaponType.NDUJA,
			WeaponType.NDUJA_COUNTER,
			WeaponType.ASTRONOMIA,
			WeaponType.BLOOD_GARLIC,
			WeaponType.BLOOD_LANCET,
			WeaponType.BLOOD_LAUREL,
			WeaponType.BLOOD_PENTAGRAM,
			WeaponType.BLOOD_SONG,
			WeaponType.JUBILEE,
			WeaponType.JUBILEE_RAYS,
			WeaponType.PARTY,
			WeaponType.SONG,
			WeaponType.MANNAGGIA,
			WeaponType.BOCCE,
			WeaponType.EX_MAGISTONE1,
			WeaponType.EX_MAGISTONE2,
			WeaponType.ROSARY,
			WeaponType.PENTAGRAM,
			WeaponType.SIRE,
			WeaponType.PRISMATICMISS,
			WeaponType.PRISMATICMISS2,
			WeaponType.CHERRY,
			WeaponType.CHERRY2,
			WeaponType.CHERRY_STAR,
			WeaponType.CHERRY_STAR_EXPLO,
			WeaponType.FLOWER,
			WeaponType.FLOWER2,
			WeaponType.ROBBA,
			WeaponType.LAROBBA2,
			WeaponType.FOURSEASONS,
			WeaponType.FOURSEASONS2,
			WeaponType.C1_SWIPECARD2,
			WeaponType.C1_VENT2,
			WeaponType.C1_TONGUE1,
			WeaponType.C1_TONGUE2,
			WeaponType.C1_SAMPLES1,
			WeaponType.C1_HATCOLLECTION1,
			WeaponType.C1_HATCOLLECTION_EXPLO,
			WeaponType.C1_SAMPLES1_EXPLOSION,
			WeaponType.C1_SAMPLES2_REACTOR,
			WeaponType.NOVA_FIRE,
			WeaponType.FB_SPREAD,
			WeaponType.FB_SONIC,
			WeaponType.FB_BLADECROSSBOW,
			WeaponType.FB_WAVE,
			WeaponType.FB_FIREARM,
			WeaponType.FB_METALCLAW,
			WeaponType.FB_CRUSH,
			WeaponType.FB_HOMING,
			WeaponType.FB_MULTISTAGE,
			WeaponType.FB_DIVERMINES,
			WeaponType.FB_FIREEXPLOSION,
			WeaponType.TP_CONFODERE1,
			WeaponType.TP_CONFODERE2,
			WeaponType.TP_CONFODERE3,
			WeaponType.TP_ALCHEMYWHIP1,
			WeaponType.TP_ALCHEMYWHIP2,
			WeaponType.TP_ALUCARDSWORD2,
			WeaponType.TP_CHAUVE1,
			WeaponType.TP_CHAUVE2,
			WeaponType.TP_WINEGLASS1,
			WeaponType.TP_WINEGLASS2,
			WeaponType.TP_CUSTOS1,
			WeaponType.TP_CUSTOS2,
			WeaponType.TP_CUSTOS3,
			WeaponType.TP_CUSTOS4,
			WeaponType.TP_GUN1,
			WeaponType.TP_GUN1_GUN,
			WeaponType.TP_GUN1_SHRAPNEL,
			WeaponType.TP_GUN2,
			WeaponType.TP_RPG1,
			WeaponType.TP_RPG2,
			WeaponType.TP_ALUCARDSHIELD,
			WeaponType.TP_FIRE1,
			WeaponType.TP_FIRE1_COUNTER,
			WeaponType.TP_FIRE2,
			WeaponType.TP_EVIL1,
			WeaponType.TP_EVIL1_COUNTER,
			WeaponType.TP_EVIL2,
			WeaponType.TP_DCUSTOS_FIRE,
			WeaponType.TP_DCUSTOS_EXPLOSION,
			WeaponType.TP_SCUSTOS_MIRAGE,
			WeaponType.TP_SCUSTOS_EXPLOSION,
			WeaponType.TP_MACE2,
			WeaponType.TP_MACE2_CRIT,
			WeaponType.TP_MACE2_INVIS,
			WeaponType.TP_MACE2_STANDARD,
			WeaponType.TP_SLASH1,
			WeaponType.TP_DOMINUS1,
			WeaponType.TP_DOMINUS2,
			WeaponType.TP_DOMINUS4,
			WeaponType.TP_SACREDBEASTS1,
			WeaponType.TP_SACREDBEASTS2,
			WeaponType.TP_DARK1,
			WeaponType.TP_DARK2,
			WeaponType.TP_ENERGY1,
			WeaponType.TP_ENERGY1_COUNTER,
			WeaponType.TP_ENERGY2,
			WeaponType.TP_LIGHT1,
			WeaponType.TP_LIGHT2,
			WeaponType.TP_LIGHT2_ORBIT,
			WeaponType.TP_UNIVERSITAS,
			WeaponType.TP_HOLYWHIP1,
			WeaponType.TP_HOLYWHIP1_NODE,
			WeaponType.TP_HOLYWHIP1_SMOKE,
			WeaponType.TP_HOLYWHIP2,
			WeaponType.TP_MARTIALWHIP1,
			WeaponType.TP_MARTIALWHIP2,
			WeaponType.TP_LEMURIA1,
			WeaponType.TP_LEMURIA1_NODE,
			WeaponType.TP_LEMURIA1_SPIKE,
			WeaponType.TP_LEMURIA2,
			WeaponType.TP_RPG1_EXPLOSION,
			WeaponType.TP_WINEGLASS1_SHARD,
			WeaponType.TP_SAVROG_WEAPON,
			WeaponType.TP_SAVROG_WEAPON2,
			WeaponType.TP_CHAUVE2_BEAM,
			WeaponType.TP_CUSTOS3_BITE,
			WeaponType.TP_CUSTOS4_FIREBALL,
			WeaponType.TP_GOTH_MISSILE,
			WeaponType.TP_GOTH_MISSILE_HOLYWHIP2,
			WeaponType.TP_GOTH_MISSILE2,
			WeaponType.TP_FIRE2_TAIL,
			WeaponType.TP_DARKRIFT,
			WeaponType.TP_DARKRIFT_JETBLACKWHIP,
			WeaponType.TP_DARKRIFT2,
			WeaponType.TP_SWORD_BROTHERS,
			WeaponType.TP_SWORD_BROTHERS2,
			WeaponType.TP_AURABLAST_WEAPON,
			WeaponType.TP_AURABLAST_MARTIALWHIP,
			WeaponType.TP_AURABLAST_WEAPON2,
			WeaponType.TP_SOULSTEAL_WEAPON,
			WeaponType.TP_SOULSTEAL_WEAPON2,
			WeaponType.TP_POWEROFLIRE,
			WeaponType.TP_GEARS_WEAPON,
			WeaponType.TP_PENDULUM_WEAPON,
			WeaponType.TP_ELEVATOR_WEAPON,
			WeaponType.TP_HEADS_WEAPON,
			WeaponType.TP_CLOCKTOWER_WEAPON,
			WeaponType.TP_SHAFTORB,
			WeaponType.TP_DEATHHAND,
			WeaponType.TP_DRACULAHAND,
			WeaponType.TP_LAPISTE1,
			WeaponType.TP_LAPISTE2,
			WeaponType.TP_POCKET1,
			WeaponType.EME_MECH1,
			WeaponType.EME_MECH2,
			WeaponType.EME_MECH3,
			WeaponType.EME_KATANA1,
			WeaponType.EME_KATANA2,
			WeaponType.EME_BLOOD1,
			WeaponType.EME_BLOOD2,
			WeaponType.EME_MAGIC1,
			WeaponType.EME_MAGIC2,
			WeaponType.EME_AXE1,
			WeaponType.EME_AXE2,
			WeaponType.EME_LONGSWORD1,
			WeaponType.EME_LONGSWORD2,
			WeaponType.EME_LONGSWORD3,
			WeaponType.EME_CANNON1,
			WeaponType.EME_CANNON2,
			WeaponType.EME_CANNON3,
			WeaponType.EME_KICK1,
			WeaponType.EME_KICK2,
			WeaponType.EME_GREATSWORD1,
			WeaponType.EME_GREATSWORD2,
			WeaponType.EME_GREATSWORD3,
			WeaponType.EME_WAVE,
			WeaponType.EME_WAVE2,
			WeaponType.EME_MECH_BALLMISS,
			WeaponType.EME_MECH_RAVE,
			WeaponType.LEM_INFERNO1,
			WeaponType.LEM_INFERNO2,
			WeaponType.LEM_PLANETS1
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2348 @ rax_v242 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2348 @ rax_v242 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2348 @ rax_v242 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v56+18]");
		if (num28 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1708);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2348 @ rax_v242 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 1708;
		}
		RedWeapons = list2;
	}

	private void _003COnUpdate_003Eb__9_0()
	{
		//IL_003e: Expected O, but got I4
		Sequence alertTween = _alertTween;
		float timeScale = alertTween.timeScale * 1.1f;
		alertTween.timeScale = timeScale;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Alert, soundConfig, 250f, 3, time);
	}
}
