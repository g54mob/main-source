using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class ScrollEnhancer : MonoBehaviour
{
	private bool _DEBUGTHIS;

	private bool _AutoInitialize;

	private bool _HideSliderWhenNotNeeded;

	public bool RequiresMouseOverForScroll;

	private float _scrollSpeed;

	private RectTransform _scroll;

	private RectTransform _content;

	private Scrollbar _scrollbar;

	private Slider _Slider;

	private float _OffsetWhenSliderShown;

	private GameObject _previouslySelected;

	private Vector3 _baseScrollViewPosition;

	private void Awake()
	{
		if (_AutoInitialize)
		{
			Slider slider = default(Slider);
			float offset = default(float);
			Initialize(_scrollSpeed, _content, _scrollbar, slider, offset);
		}
	}

	private void Update()
	{
		//IL_015b: Invalid comparison between F4 and I4
		//IL_00d9: Expected O, but got F4
		//IL_04fd: Expected O, but got F4
		//IL_02c8: Invalid comparison between F4 and O
		//IL_02e6: Invalid comparison between F4 and I4
		//IL_03c5: Expected O, but got I4
		//IL_041c: Expected I, but got O
		//IL_0576->IL042b: Incompatible stack heights: 1 vs 0
		//IL_0510->IL0454: Incompatible stack heights: 1 vs 0
		//IL_02bb->IL042b: Incompatible stack heights: 1 vs 0
		//IL_031c->IL0510: Incompatible stack heights: 1 vs 0
		Rect ret;
		object obj = default(object);
		if (!RequiresMouseOverForScroll)
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			if (controllers != null)
			{
				Mouse mouse = controllers.Mouse;
				if (mouse != null)
				{
					float axis = mouse.GetAxis(2);
					if ((object)_content != null)
					{
						Vector2 anchoredPosition = _content.anchoredPosition;
						if ((object)_content != null)
						{
							Vector2 anchoredPosition2 = _content.anchoredPosition;
							float num = default(float);
							_content.anchoredPosition = (Vector2)num;
							float num2 = num;
							goto IL_0454;
						}
					}
				}
			}
		}
		else
		{
			ReInput.ControllerHelper controllers2 = ReInput.controllers;
			if (controllers2 != null)
			{
				Mouse mouse2 = controllers2.Mouse;
				if (mouse2 != null)
				{
					float num2 = mouse2.GetAxis(2);
					bool flag = num2 == 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D82439h\"");
					if (flag)
					{
						goto IL_0454;
					}
					ScrollRect component = GetComponent<ScrollRect>();
					if ((object)component != null)
					{
						RectTransform content = component.m_Content;
						if ((object)component.m_Content != null)
						{
							bool flag2 = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
							RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out ret);
							float num3 = (float)obj * _scrollSpeed;
							float scrollSensitivity = num3 / 65f;
							component.m_ScrollSensitivity = scrollSensitivity;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
							float num4 = default(float);
							component.m_Velocity = (Vector2)num4;
							num2 = num4;
							goto IL_0454;
						}
					}
				}
			}
		}
		goto IL_042b;
		IL_0510:
		GameObject gameObject;
		bool active;
		gameObject.SetActive(active);
		Slider slider = _Slider;
		if ((object)_Slider == null || ((UnityEngine.Object)slider).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		RectTransform slider2 = (RectTransform)(object)_Slider;
		Scrollbar scrollbar = _scrollbar;
		if ((object)_scrollbar != null)
		{
			float value = scrollbar.m_Value;
			if (scrollbar.m_NumberOfSteps > 1)
			{
				object obj2 = scrollbar.m_NumberOfSteps - 1;
				float num5 = (float)obj2 * scrollbar.m_Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				float num6 = (float)scrollbar.m_NumberOfSteps - 1f;
				value = num5 / num6;
				float num2 = num6;
			}
			if ((object)_Slider != null)
			{
				nint num7 = (nint)slider2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v910 @ rax_v23 (Il2CppClass<UnityEngine.RectTransform>)+428] (should have been resolved before IL gen)");
				return;
			}
		}
		goto IL_042b;
		IL_042b:
		throw new NullReferenceException();
		IL_0454:
		ScrollWithSelection(_scroll, _content);
		if (!_HideSliderWhenNotNeeded)
		{
			if ((object)_Slider != null)
			{
				gameObject = _Slider.gameObject;
				if ((object)gameObject != null)
				{
					active = true;
					goto IL_0510;
				}
			}
		}
		else if ((object)_content != null)
		{
			Vector2 sizeDelta = _content.sizeDelta;
			RectTransform scroll = _scroll;
			if ((object)_scroll != null)
			{
				bool flag3 = ((UnityEngine.Object)scroll).m_CachedPtr == (IntPtr)0;
				RectTransform.get_rect_Injected(((UnityEngine.Object)scroll).m_CachedPtr, out ret);
				if ((object)_Slider != null)
				{
					gameObject = _Slider.gameObject;
					if ((object)gameObject != null)
					{
						float num8 = default(float);
						bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
						float num9 = num8 - (float)obj;
						bool flag5 = num9 == 0f;
						bool flag6 = !flag4;
						bool flag7 = !flag5;
						active = flag7 & flag6;
						float num2 = num8;
						goto IL_0510;
					}
				}
			}
		}
		goto IL_042b;
	}

	public void Initialize(float scrollSpeed, RectTransform content, Scrollbar scrollbar, Slider slider, float offset)
	{
		_scrollSpeed = scrollSpeed;
		RectTransform component = GetComponent<RectTransform>();
		_scroll = component;
		_content = content;
		_scrollbar = scrollbar;
		Slider slider2 = default(Slider);
		_Slider = slider2;
		Slider slider3 = _Slider;
		float offsetWhenSliderShown = default(float);
		_OffsetWhenSliderShown = offsetWhenSliderShown;
		if ((object)_Slider != null && ((UnityEngine.Object)slider3).m_CachedPtr != (IntPtr)0)
		{
			Slider slider4 = _Slider;
			UnityAction<float> unityAction = null;
			((ScrollEnhancer)(object)unityAction).OnSliderDrag(scrollSpeed);
			slider4.m_OnValueChanged.AddListener(unityAction);
			if (_HideSliderWhenNotNeeded)
			{
				GameObject gameObject = _Slider.gameObject;
				gameObject.SetActive(value: false);
			}
		}
		Vector2 anchoredPosition = _scroll.anchoredPosition;
		Vector3 baseScrollViewPosition = default(Vector3);
		_baseScrollViewPosition = baseScrollViewPosition;
		_ = 0;
	}

	protected void OnSliderDrag(float val)
	{
		_scrollbar.Set(val, true);
	}

	public void ForceScrollAlignment()
	{
		//IL_00ae: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
		Canvas.ForceUpdateCanvases();
		Slider slider = _Slider;
		if ((object)_Slider != null && ((UnityEngine.Object)slider).m_CachedPtr != (IntPtr)0)
		{
			Scrollbar scrollbar = _scrollbar;
			float value = scrollbar.m_Value;
			if (scrollbar.m_NumberOfSteps > 1)
			{
				object obj = scrollbar.m_NumberOfSteps - 1;
				float num = (float)obj * scrollbar.m_Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
				object obj2 = scrollbar.m_NumberOfSteps - 1;
				value = num / (float)obj2;
			}
			_Slider.value = value;
			Vector2 sizeDelta = _content.sizeDelta;
			Vector2 sizeDelta2 = _scroll.sizeDelta;
			object obj3 = default(object);
			object obj4 = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
			object obj5 = obj3 - obj4;
			bool flag2 = obj5 == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			GameObject gameObject = _Slider.gameObject;
			gameObject.SetActive(flag5);
			Vector2 vector = default(Vector2);
			Vector2 anchoredPosition = ((!flag5) ? vector : vector);
			_scroll.anchoredPosition = anchoredPosition;
		}
	}

	public void LogOnValueChange(float val)
	{
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(val, null, currentInfo);
		string message = "val : " + text;
		Debug.Log(message);
	}

	public void SetScrollbarActive(bool on)
	{
		Slider slider = _Slider;
		if ((object)_Slider != null && ((UnityEngine.Object)slider).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Slider.gameObject;
			gameObject.SetActive(on);
		}
	}

	protected void ScrollWithSelection(RectTransform _scrollRect, RectTransform _content)
	{
		//IL_026e: Expected O, but got I4
		//IL_06c7: Invalid comparison between I4 and F4
		//IL_0717: Invalid comparison between F4 and O
		//IL_0447->IL0447: Incompatible stack heights: 0 vs 1
		//IL_07a7->IL04b2: Incompatible stack heights: 2 vs 0
		//IL_04b1->IL04b1: Incompatible stack heights: 3 vs 0
		EventSystem current = EventSystem.current;
		RectTransform rectTransform;
		object obj3;
		if ((object)current != null)
		{
			GameObject currentSelected = current.m_CurrentSelected;
			if ((object)current.m_CurrentSelected == null || ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			bool flag;
			if ((object)_previouslySelected != null)
			{
				object obj = (object)current.m_CurrentSelected - (object)_previouslySelected;
				flag = obj == null;
			}
			else
			{
				flag = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (flag)
			{
				return;
			}
			Transform transform = current.m_CurrentSelected.transform;
			if ((object)transform != null)
			{
				if (!transform.IsChildOf(_content))
				{
					return;
				}
				RectTransform component = current.m_CurrentSelected.GetComponent<RectTransform>();
				if ((object)_content != null)
				{
					LayoutGroup[] componentsInChildren = _content.GetComponentsInChildren<LayoutGroup>();
					if (componentsInChildren != null)
					{
						bool flag2 = componentsInChildren.Length > 1;
						rectTransform = component;
						if (flag2)
						{
							goto IL_0517;
						}
						if ((object)component != null)
						{
							Transform parent = component.parent;
							bool flag3;
							if ((object)parent != null)
							{
								object obj2 = (object)parent - (object)_content;
								flag3 = obj2 == null;
							}
							else
							{
								flag3 = ((UnityEngine.Object)_content).m_CachedPtr == (IntPtr)0;
							}
							obj3 = component;
							if (flag3)
							{
								goto IL_0258;
							}
							Transform parent2 = component.parent;
							if ((object)parent2 != null)
							{
								RectTransform component2 = parent2.GetComponent<RectTransform>();
								rectTransform = component2;
								goto IL_0517;
							}
						}
					}
				}
			}
		}
		goto IL_04b2;
		IL_04b2:
		throw new NullReferenceException();
		IL_0517:
		bool flag4 = (object)rectTransform == null;
		obj3 = rectTransform;
		if (!flag4)
		{
			goto IL_0258;
		}
		goto IL_04b2;
		IL_0258:
		Vector2 anchoredPosition = ((RectTransform)obj3).anchoredPosition;
		object obj4 = 0;
		Transform transform2 = (Transform)obj3;
		object obj5 = default(object);
		Transform parent5 = default(Transform);
		object obj8 = default(object);
		Vector2 vector = default(Vector2);
		object obj9 = default(object);
		while (true)
		{
			obj4 -= obj5;
			Transform parent3 = transform2.parent;
			if ((object)parent3 == null)
			{
				break;
			}
			RectTransform component3 = parent3.GetComponent<RectTransform>();
			bool flag5;
			if ((object)component3 != null)
			{
				object obj6 = (object)component3 - (object)_content;
				flag5 = obj6 == null;
			}
			else
			{
				flag5 = ((UnityEngine.Object)_content).m_CachedPtr == (IntPtr)0;
			}
			if (!flag5)
			{
				if ((object)component3 == null)
				{
					break;
				}
				RectTransform component4 = component3.GetComponent<RectTransform>();
				if ((object)component4 == null)
				{
					break;
				}
				Vector2 anchoredPosition2 = component4.anchoredPosition;
				transform2 = component3;
				continue;
			}
			Vector2 anchoredPosition3 = _content.anchoredPosition;
			object obj7 = obj4 - obj5;
			Transform parent4 = ((Transform)obj3).parent;
			if ((object)parent4 == null)
			{
				break;
			}
			GridLayoutGroup component5 = parent4.GetComponent<GridLayoutGroup>();
			if ((object)component5 == null || ((UnityEngine.Object)component5).m_CachedPtr == (IntPtr)0)
			{
				parent5 = ((Transform)obj3).parent;
				if ((object)parent5 == null)
				{
					break;
				}
			}
			HorizontalLayoutGroup component6 = parent5.GetComponent<HorizontalLayoutGroup>();
			if ((object)component6 != null)
			{
			}
			Transform parent6 = ((Transform)obj3).parent;
			if ((object)parent6 == null)
			{
				break;
			}
			VerticalLayoutGroup component7 = parent6.GetComponent<VerticalLayoutGroup>();
			if ((object)component7 == null || ((UnityEngine.Object)component7).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v12 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v12 (System.Object)+10]");
			RectTransform.get_rect_Injected((IntPtr)0, out Rect ret);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v12 (System.Object)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v12 (System.Object)+10]");
			RectTransform.get_rect_Injected((IntPtr)0, out Rect _);
			float num = (float)obj8 * 0.5f;
			float num2 = (float)obj7 - num;
			if (0f > num2)
			{
				Rect rect = ((RectTransform)obj3).rect;
				num = (float)vector * 0.5f;
			}
			float num3 = (float)obj9 * 0.5f;
			float num4 = num3 + (float)obj7;
			if ((object)_scrollRect == null)
			{
				break;
			}
			bool flag8 = ((UnityEngine.Object)_scrollRect).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)_scrollRect).m_CachedPtr, out ret);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
			{
				Rect rect2 = _scrollRect.rect;
				Rect rect3 = ((RectTransform)obj3).rect;
			}
			Vector2 anchoredPosition4 = _content.anchoredPosition;
			Vector2 anchoredPosition5 = _content.anchoredPosition;
			_content.anchoredPosition = vector;
			_previouslySelected = current.m_CurrentSelected;
			return;
		}
		goto IL_04b2;
	}

	public ScrollEnhancer()
	{
		//IL_002b: Expected I, but got O
		//IL_0066: Expected I, but got O
		_HideSliderWhenNotNeeded = true;
		_scrollSpeed = 3f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_baseScrollViewPosition = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
