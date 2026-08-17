using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStalker_Generic : EnemyController
{
	private float _sineF = 1f;

	private Tween _onEnterTween;

	private Sequence _onSineTween;

	private GameObject _spritte;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_051a: Expected O, but got Ref
		//IL_037b: Expected I4, but got I8
		base.InitEnemy(enemyType, asRemote);
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v2 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v2 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			Vector3 vector = default(Vector3);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 0.3f);
			TweenCallback tweenCallback = delegate
			{
				Transform cachedTransform2 = _cachedTransform;
				bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value2);
			};
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_onEnterTween = tweenerCore;
			EnemyData currentEnemyData = _currentEnemyData;
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 0.8f);
			bool flag = _onSineTween == null;
			_sineF = 1f;
			base._003CIsCullable_003Ek__BackingField = false;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			if (!flag)
			{
				TweenExtensions.Restart(_onSineTween);
				return;
			}
			Sequence onSineTween = DOTween.Sequence();
			_onSineTween = onSineTween;
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyStalker_Generic)(object)dOSetter)._003CInitEnemy_003Eb__4_2(0.8f);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0.1f, 2f);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore2, false))
			{
				Sequence sequence = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore2, 0f);
			}
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(_EnemyRenderer, 0.6f, 2f);
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			if (TweenSettingsExtensions.ValidateAddToSequence(_onSineTween, (Tween)tweenerCore3, false))
			{
				Sequence sequence2 = Sequence.DoInsert(_onSineTween, (Tween)tweenerCore3, 0f);
			}
			Sequence onSineTween2 = _onSineTween;
			if (_onSineTween != null && ((Tween)onSineTween2)._003Cactive_003Ek__BackingField && !((Tween)onSineTween2).creationLocked)
			{
				((Tween)onSineTween2).loops = -1;
				((Tween)onSineTween2).loopType = LoopType.Yoyo;
				if (((ABSSequentiable)onSineTween2).tweenType == TweenType.Tweener)
				{
					((Tween)onSineTween2).fullDuration = 1f / 0f;
				}
			}
			Sequence onSineTween3 = _onSineTween;
			if (_onSineTween != null && ((Tween)onSineTween3)._003Cactive_003Ek__BackingField && !((Tween)onSineTween3).creationLocked)
			{
				((Tween)onSineTween3).autoKill = false;
			}
			Sequence onSineTween4 = _onSineTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			onSineTween4.stringId = "DefaultGameTweenId";
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		if (_onSineTween != null)
		{
			TweenExtensions.Kill(_onSineTween);
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		base.Disappear();
	}

	public override void Despawn()
	{
		if (_onSineTween != null)
		{
			TweenExtensions.Kill(_onSineTween);
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		base.Despawn();
	}

	protected override void OnUpdate()
	{
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
	}

	private void _003CInitEnemy_003Eb__4_0()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private float _003CInitEnemy_003Eb__4_1()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__4_2(float val)
	{
		_sineF = val;
	}
}
