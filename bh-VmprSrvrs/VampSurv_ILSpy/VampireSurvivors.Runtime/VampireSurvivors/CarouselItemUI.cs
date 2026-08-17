using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace VampireSurvivors;

public class CarouselItemUI : MonoBehaviour
{
	protected CanvasGroup _cg;

	protected float _maxDistance;

	protected float _minAlpha;

	protected float _minScale;

	protected RectTransform _mTrans;

	protected RectTransform _tTrans;

	protected float _progress;

	protected RectTransform _target;

	private Tween _moveTween;

	private Tween _scaleTween;

	public virtual void Initialize(float maxDistance)
	{
		_maxDistance = maxDistance;
		RectTransform component = GetComponent<RectTransform>();
		_mTrans = component;
		Transform transform = base.transform;
		Transform parent = transform.parent;
		RectTransform component2 = parent.GetComponent<RectTransform>();
		_tTrans = component2;
		CanvasGroup component3 = GetComponent<CanvasGroup>();
		_cg = component3;
		CanvasGroup cg = _cg;
		if ((object)_cg == null || ((UnityEngine.Object)cg).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			CanvasGroup cg2 = gameObject.AddComponent<CanvasGroup>();
			_cg = cg2;
		}
	}

	private void OnDestroy()
	{
		Tween moveTween = _moveTween;
		if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_moveTween);
		}
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
	}

	private void KillAllTweens()
	{
		Tween moveTween = _moveTween;
		if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_moveTween);
		}
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
	}

	public unsafe Tween SetTarget(Transform t, bool completeImmediately = false)
	{
		//IL_0164: Expected O, but got Ref
		//IL_01c7: Expected O, but got Ref
		Transform target = base.transform;
		bool flag = ((UnityEngine.Object)t).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)t).m_CachedPtr, out Vector3 ret);
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(target, (Vector3)(&obj), 0.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 9;
				_ = 0;
			}
		}
		_moveTween = tweenerCore;
		Transform target2 = base.transform;
		bool flag2 = ((UnityEngine.Object)t).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)t).m_CachedPtr, out ret);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, (Vector3)(&obj), 0.2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 9;
				_ = 0;
			}
		}
		_scaleTween = tweenerCore2;
		bool flag3 = default(bool);
		if (flag3)
		{
			TweenExtensions.Complete(_moveTween, withCallbacks: false);
			TweenExtensions.Complete(_scaleTween, withCallbacks: false);
		}
		RectTransform component = t.GetComponent<RectTransform>();
		_target = component;
		return _moveTween;
	}

	private void Update()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_003e: Invalid comparison between I4 and F4
		//IL_0089: Expected F4, but got I4
		Vector2 anchoredPosition = _mTrans.anchoredPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = default(object);
		object obj = obj2 & 0;
		float num = (float)obj / _maxDistance;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float progress = 1f - num;
		_progress = progress;
		ApplyProgress();
	}

	protected virtual void ApplyProgress()
	{
	}

	public virtual void Deselect(bool completeImmediately = false)
	{
	}

	public virtual void Select(bool completeImmediately = false)
	{
	}

	public CarouselItemUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
