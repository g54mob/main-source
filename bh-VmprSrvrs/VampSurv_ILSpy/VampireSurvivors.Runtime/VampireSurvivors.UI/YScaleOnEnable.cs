using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace VampireSurvivors.UI;

public class YScaleOnEnable : MonoBehaviour
{
	private float _Duration;

	private Tween _scaleTween;

	private Vector3 _scale;

	private bool _hasInitialized;

	private void Awake()
	{
		_hasInitialized = true;
	}

	private void OnEnable()
	{
		//IL_0107: Expected F4, but got I
		if (_hasInitialized)
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			_scale = ret;
			_ = 0;
			Transform transform2 = base.transform;
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
			Transform target = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.YScaleOnEnable)+34]");
			TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScaleY(target, 0f, _Duration);
			_scaleTween = scaleTween;
		}
		else
		{
			_hasInitialized = true;
		}
	}

	private void OnDisable()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween, complete: true);
		}
	}

	private void OnDestroy()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween, complete: true);
		}
	}

	public YScaleOnEnable()
	{
		//IL_0020: Expected I, but got O
		_Duration = 0.2f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
