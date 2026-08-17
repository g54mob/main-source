using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStalkerTrappedSorceress : EnemyController
{
	private float _sineF = 1f;

	private float _fireTime;

	private float _fireDelay = 2f;

	private EnemyType _bulletType;

	private int _activated;

	private Tween _onEnterTween;

	private Tween _onFireTimer;

	private Sequence _onSineTween;

	public Action OnDefeat;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0096: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_047f: Expected I4, but got O
		//IL_0234: Expected O, but got I4
		//IL_023d: Expected F4, but got I4
		//IL_032c: Expected I4, but got I8
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
		_sineF = 1f;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 0.8f);
		_activated = 0;
		float val;
		if (_onSineTween != null)
		{
			TweenExtensions.Restart(_onSineTween);
			object obj = 0;
			float num = -1f;
			val = 0.8f;
		}
		else
		{
			Sequence onSineTween = DOTween.Sequence();
			_onSineTween = onSineTween;
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyStalkerTrappedSorceress)(object)dOSetter)._003CInitEnemy_003Eb__9_1(0.8f);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.1f, 2f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rax_v56 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore, false))
			{
				Sequence sequence = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore, 0f);
			}
			TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_EnemyRenderer, 0.6f, 2f);
			bool flag = TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)t, false);
			bool flag2 = !flag;
			object obj = 0;
			float num = 2f;
			if (!flag2)
			{
				Sequence sequence2 = Sequence.DoInsert(_onSineTween, (Tween)t, 0f);
				obj = 0;
				num = 0f;
			}
			Sequence onSineTween2 = _onSineTween;
			if (_onSineTween != null && ((Tween)onSineTween2)._003Cactive_003Ek__BackingField)
			{
				((Tween)onSineTween2).easeType = Ease.InOutSine;
				((Tween)onSineTween2).customEase = null;
			}
			Sequence onSineTween3 = _onSineTween;
			if (_onSineTween != null && ((Tween)onSineTween3)._003Cactive_003Ek__BackingField && !((Tween)onSineTween3).creationLocked)
			{
				((Tween)onSineTween3).loops = -1;
				((Tween)onSineTween3).loopType = LoopType.Yoyo;
				if (((ABSSequentiable)onSineTween3).tweenType == TweenType.Tweener)
				{
					((Tween)onSineTween3).fullDuration = 1f / 0f;
				}
			}
			Sequence onSineTween4 = _onSineTween;
			if (_onSineTween != null && ((Tween)onSineTween4)._003Cactive_003Ek__BackingField && !((Tween)onSineTween4).creationLocked)
			{
				((Tween)onSineTween4).autoKill = false;
			}
			Sequence onSineTween5 = _onSineTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			onSineTween5.stringId = "DefaultGameTweenId";
			val = 0.6f;
		}
		EnemyData currentEnemyData2 = _currentEnemyData;
		_fireTime = 0f;
		float num3 = default(float);
		float num2 = (((object)currentEnemyData2._003CfireDelay_003Ek__BackingField == null) ? 2000f : num3);
		float fireDelay = num2 * 0.001f;
		EnemyData currentEnemyData3 = _currentEnemyData;
		_fireDelay = fireDelay;
		EnemyType bulletType = (((object)currentEnemyData3._003CbulletType_003Ek__BackingField == null) ? EnemyType.BULLET_2 : ((EnemyType)((object?)currentEnemyData3._003CbulletType_003Ek__BackingField >> 32)));
		_bulletType = bulletType;
		if (_onFireTimer != null)
		{
			TweenExtensions.Restart(_onFireTimer);
			return;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((EnemyStalkerTrappedSorceress)(object)dOSetter2)._003CInitEnemy_003Eb__9_3(val);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 1f, _fireDelay);
		TweenCallback tweenCallback2;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
					TweenCallback tweenCallback = Fire;
					tweenCallback2 = tweenCallback;
					goto IL_05e1;
				}
			}
		}
		TweenCallback tweenCallback3 = Fire;
		bool flag3 = tweenerCore2 == null;
		tweenCallback2 = tweenCallback3;
		if (!flag3)
		{
			goto IL_05e1;
		}
		goto IL_0775;
		IL_0775:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_onFireTimer = tweenerCore2;
		return;
		IL_05e1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
		}
		goto IL_0775;
	}

	public override void Disappear()
	{
		Sequence sequence = TweenExtensions.Pause(_onSineTween);
		_sineF = -2f;
		base._003CIsCullable_003Ek__BackingField = true;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((EnemyStalkerTrappedSorceress)(object)dOSetter)._003CDisappear_003Eb__10_1(val);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, -10f, 2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onFireTimer != null)
		{
			Tween tween = TweenExtensions.Pause(_onFireTimer);
		}
	}

	protected override void OnUpdate()
	{
		//IL_0102: Invalid comparison between F4 and O
		float num = _sineF * _defaultSpeed;
		float num2 = num * (float)_activated;
		base._003CSpeed_003Ek__BackingField = num2;
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-819.2f)) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					_activated = 1;
				}
				base.OnUpdate();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (_activated > 0)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_onFireTimer != null)
		{
			Tween tween = TweenExtensions.Pause(_onFireTimer);
		}
		Action onDefeat = OnDefeat;
		if (OnDefeat != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v48.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void Fire()
	{
		//IL_00a3->IL005d: Incompatible stack heights: 1 vs 0
		if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
		{
			Transform cachedTransform = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			base.FireEnemyAsBullet(spawnPos, _bulletType);
		}
	}

	private float _003CInitEnemy_003Eb__9_0()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__9_1(float val)
	{
		_sineF = val;
	}

	private float _003CInitEnemy_003Eb__9_2()
	{
		return _fireTime;
	}

	private void _003CInitEnemy_003Eb__9_3(float val)
	{
		_fireTime = val;
	}

	private float _003CDisappear_003Eb__10_0()
	{
		return _sineF;
	}

	private void _003CDisappear_003Eb__10_1(float val)
	{
		_sineF = val;
	}
}
