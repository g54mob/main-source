using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class AspectMask : MonoBehaviour
{
	private sealed class _003CWait_003Ed__29(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AspectMask _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			AspectMask aspectMask = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				_003C_003E4__this.CalculateHeight();
				object rectTransform = aspectMask._rectTransform;
				bool flag2 = (object)aspectMask._rectTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v2 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v2 (System.Object)+10]");
				RectTransform.get_rect_Injected((IntPtr)0, out Rect _);
				float screenWidth = UIHelper.ScreenWidth;
				float screenHeight = UIHelper.ScreenHeight;
				bool flag4 = (object)aspectMask._Left == null;
				Vector2 sizeDelta = default(Vector2);
				aspectMask._Left.sizeDelta = sizeDelta;
				float screenHeight2 = UIHelper.ScreenHeight;
				bool flag5 = (object)aspectMask._Right == null;
				aspectMask._Right.sizeDelta = sizeDelta;
				return false;
			}
			return false;
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

	private RectTransform _Top;

	private RectTransform _Bottom;

	private RectTransform _Left;

	private RectTransform _Right;

	private Canvas _Canvas;

	private RectTransform _rectTransform;

	private AspectRatioFitter _fitter;

	private int _prevWidth;

	private int _prevHeight;

	private static AspectMask _003CInstance_003Ek__BackingField;

	public static AspectMask Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public RectTransform Top => _Top;

	public RectTransform Bottom => _Bottom;

	public RectTransform Left => _Left;

	public RectTransform Right => _Right;

	private void Awake()
	{
		AspectMask aspectMask = _003CInstance_003Ek__BackingField;
		if ((object)_003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)aspectMask).m_CachedPtr != (IntPtr)0)
		{
			Debug.LogError("Uh oh, we have more than on AspectMask component in the scene!");
			return;
		}
		_003CInstance_003Ek__BackingField = this;
		SetImageEnabled(_Top, isEnabled: false);
		SetImageEnabled(_Bottom, isEnabled: false);
		SetImageEnabled(_Left, isEnabled: false);
		SetImageEnabled(_Right, isEnabled: false);
		RectTransform component = GetComponent<RectTransform>();
		_rectTransform = component;
		AspectRatioFitter component2 = GetComponent<AspectRatioFitter>();
		_fitter = component2;
	}

	public void Enable()
	{
		SetImageEnabled(_Top, isEnabled: true);
		SetImageEnabled(_Bottom, isEnabled: true);
		SetImageEnabled(_Left, isEnabled: true);
		SetImageEnabled(_Right, isEnabled: true);
	}

	public void Disable()
	{
		SetImageEnabled(_Top, isEnabled: false);
		SetImageEnabled(_Bottom, isEnabled: false);
		SetImageEnabled(_Left, isEnabled: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 25 Invalid \"Jump target not found in method: 0x186B7F670\"");
	}

	private void SetImageEnabled(RectTransform obj, bool isEnabled)
	{
		Image component = obj.GetComponent<Image>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.enabled = isEnabled;
		}
	}

	private void Start()
	{
		GameManager core = GM.Core;
		PlayerOptions.OnInitialized value = OnResize;
		core._playerOptions.PlayerOptionsInitialized += value;
	}

	private void Update()
	{
		//IL_001a: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		object obj = Screen.height;
		if (_prevHeight == (nint)obj)
		{
			object obj2 = Screen.width;
			if (_prevWidth == (nint)obj2)
			{
				return;
			}
		}
		int width = Screen.width;
		_prevWidth = width;
		int height = Screen.height;
		_prevHeight = height;
		OnResize();
	}

	private void OnResize()
	{
		if ((object)this == null || ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		_003CWait_003Ed__29 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = config == null;
		float alpha = 0.65f;
		if (!flag)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			bool flag2 = config2._003CBorderType_003Ek__BackingField != BorderType.SOLID;
			alpha = 0.65f;
			if (!flag2)
			{
				alpha = 1f;
			}
		}
		int sortingOrder = (UIHelper.IsPortrait ? 1 : 999999);
		_Canvas.sortingOrder = sortingOrder;
		Image component = _Top.GetComponent<Image>();
		SetImageAlpha(component, alpha);
		Image component2 = _Bottom.GetComponent<Image>();
		SetImageAlpha(component2, alpha);
		Image component3 = _Left.GetComponent<Image>();
		SetImageAlpha(component3, alpha);
		Image component4 = _Right.GetComponent<Image>();
		SetImageAlpha(component4, alpha);
	}

	private unsafe void SetImageAlpha(Image image, float alpha)
	{
		//IL_001a: Expected O, but got Ref
		Color color = image.color;
		object obj = default(object);
		image.color = (Color)(&obj);
	}

	private IEnumerator Wait()
	{
		_003CWait_003Ed__29 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void CalculateHeight()
	{
		//IL_007c->IL00cd: Incompatible stack heights: 1 vs 0
		//IL_00b8->IL00cd: Incompatible stack heights: 1 vs 0
		RectTransform rectTransform = _rectTransform;
		if ((object)_rectTransform != null)
		{
			bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
			float screenHeight = UIHelper.ScreenHeight;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			float value = default(float);
			string text = System.Number.FormatSingle(value, null, currentInfo);
			string message = "My height : " + text;
			Debug.Log(message);
			float screenWidth = UIHelper.ScreenWidth;
			if ((object)_Top != null)
			{
				Vector2 sizeDelta = default(Vector2);
				_Top.sizeDelta = sizeDelta;
				float screenWidth2 = UIHelper.ScreenWidth;
				if ((object)_Bottom != null)
				{
					_Bottom.sizeDelta = sizeDelta;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CalculateWidth()
	{
		//IL_0040->IL0091: Incompatible stack heights: 1 vs 0
		//IL_007c->IL0091: Incompatible stack heights: 1 vs 0
		RectTransform rectTransform = _rectTransform;
		if ((object)_rectTransform != null)
		{
			bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
			float screenWidth = UIHelper.ScreenWidth;
			float screenHeight = UIHelper.ScreenHeight;
			if ((object)_Left != null)
			{
				Vector2 sizeDelta = default(Vector2);
				_Left.sizeDelta = sizeDelta;
				float screenHeight2 = UIHelper.ScreenHeight;
				if ((object)_Right != null)
				{
					_Right.sizeDelta = sizeDelta;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public AspectMask()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
