using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.UI;

public class MobileConfig : MonoBehaviour
{
	private sealed class _003CApplyRoutine_003Ed__33(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MobileConfig _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_012b: Expected I4, but got I8
			//IL_013e: Expected I4, but got O
			//IL_00cf: Expected I, but got O
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					LayoutGroup component2 = _003C_003E4__this.GetComponent<LayoutGroup>();
					if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+25]");
						if ((nint)0 != 0)
						{
							_ = 1;
							goto IL_018c;
						}
						RectTransform component3 = _003C_003E4__this.GetComponent<RectTransform>();
						LayoutRebuilder.ForceRebuildLayoutImmediate(component3);
						Canvas.ForceUpdateCanvases();
					}
					nint num = (nint)component;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v249 @ rax_v20 (Il2CppClass<UnityEngine.Component>)+1A8] (should have been resolved before IL gen)");
					goto IL_018c;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
			IL_018c:
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private bool _DEBUGTHIS;

	private bool _ShouldDisableInPortrait;

	private bool _ShouldDisableInLandscape;

	protected bool _ShouldReparent;

	protected bool _StealChildren;

	protected bool _WaitForFormatBeforeScaling;

	protected RectTransform _NewParent;

	protected bool _SetAsFirstSibling;

	protected bool _MatchSize;

	protected bool _ForcePositionReset;

	protected List<RectTransform> _ChildrenToSteal;

	protected bool _ShouldScaleToFitWidth;

	protected bool _ShouldForceRectTransformSize;

	protected Vector2 _ForcedSize;

	protected bool _ShouldAnchorPosFromRelativePosition;

	protected Vector2 _RelativeAnchorPosition;

	protected bool _ShouldExtendRectTransformToFillScreenY;

	protected List<RectTransform> _objectsToExtend;

	protected float _Padding;

	protected float _MaxHeightPercentage;

	protected float _MaxWidthPercentage;

	protected float _myWidth;

	protected float _screenWidth;

	protected float _scaleAmount;

	protected List<float> _baseHeights;

	protected Vector3 _baseScale;

	protected bool _IsPortrait;

	protected bool _hasInitialized;

	private bool _doLateFormat;

	protected virtual void Awake()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		_baseScale = ret;
		_ = 0;
		List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
		while (enumerator.MoveNext())
		{
			Transform transform2 = null;
		}
		_hasInitialized = true;
	}

	protected virtual void OnEnable()
	{
		//IL_000a: Expected I, but got O
		Action<Vector2> value = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049E0C0");
		ResolutionManager.OnResolutionChange += value;
		IEnumerator routine = ApplyRoutine();
		Coroutine coroutine = StartCoroutine(routine);
	}

	private void OnDisable()
	{
		//IL_000a: Expected I, but got O
		Action<Vector2> value = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049E0C0");
		ResolutionManager.OnResolutionChange -= value;
	}

	public virtual void OnResolutionChanged(Vector2 newRes)
	{
		//IL_0037: Expected O, but got I4
		object obj = Application.isPlaying;
		if (obj != null)
		{
			IEnumerator routine = ApplyRoutine();
			Coroutine coroutine = StartCoroutine(routine);
		}
	}

	private IEnumerator ApplyRoutine()
	{
		_003CApplyRoutine_003Ed__33 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void LateUpdate()
	{
		if (_doLateFormat)
		{
			RectTransform component = GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			Canvas.ForceUpdateCanvases();
			Apply();
			_doLateFormat = false;
		}
	}

	protected virtual void Apply()
	{
		if (_hasInitialized)
		{
			_IsPortrait = false;
			_IsPortrait = false;
			Transform transform = base.transform;
			if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				throw new NullReferenceException();
			}
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if (_ShouldDisableInLandscape)
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
		}
	}

	public void Refresh()
	{
		Apply();
	}

	public MobileConfig()
	{
		List<RectTransform> childrenToSteal = new List<RectTransform>();
		_ChildrenToSteal = childrenToSteal;
		_ShouldScaleToFitWidth = true;
		List<RectTransform> objectsToExtend = new List<RectTransform>();
		_objectsToExtend = objectsToExtend;
		_MaxHeightPercentage = 1f;
		_MaxWidthPercentage = 1f;
		List<float> baseHeights = new List<float>();
		_baseHeights = baseHeights;
	}
}
