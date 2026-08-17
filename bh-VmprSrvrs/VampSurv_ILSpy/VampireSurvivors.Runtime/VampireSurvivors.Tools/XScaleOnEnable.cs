using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace VampireSurvivors.Tools;

public class XScaleOnEnable : MonoBehaviour
{
	private float _Duration;

	private Vector3 _scale;

	private Tween _scaleTween;

	private void OnEnable()
	{
		//IL_00d6: Expected F4, but got O
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
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScaleX(target, (float)_scale, _Duration);
		_scaleTween = scaleTween;
	}

	private void OnDisable()
	{
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
	}

	private void OnDestroy()
	{
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
	}

	public XScaleOnEnable()
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
