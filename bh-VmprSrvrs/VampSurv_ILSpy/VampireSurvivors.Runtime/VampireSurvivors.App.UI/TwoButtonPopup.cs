using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI;

public class TwoButtonPopup : BasePopup
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public TwoButtonPopup _003C_003E4__this;

		public string id;

		public Action button1Callback;

		public Action button2Callback;

		internal void _003CInitialize_003Eb__0()
		{
			_003C_003E4__this.Hide();
			PopupManager.ClosePopup(id);
			Action action = button1Callback;
			if (button1Callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CInitialize_003Eb__1()
		{
			_003C_003E4__this.Hide();
			PopupManager.ClosePopup(id);
			Action action = button2Callback;
			if (button2Callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__7(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TwoButtonPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00ee: Expected I4, but got O
			TwoButtonPopup twoButtonPopup = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null && (object)twoButtonPopup._Button1 != null)
				{
					Selectable componentInChildren = twoButtonPopup._Button1.GetComponentInChildren<Selectable>();
					if ((object)componentInChildren != null)
					{
						componentInChildren.Select();
						goto IL_011a;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_011a;
			IL_011a:
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

	private Button _Button1;

	private Button _Button2;

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Description;

	private TextMeshProUGUI _Button1Text;

	private TextMeshProUGUI _Button2Text;

	public void Initialize(PopupManager manager, string id, string title, string description, string button1Text, string button2Text, Action button1Callback, Action button2Callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true, bool button2TextIsLocalizationTerm = true)
	{
		//IL_0416: Expected O, but got I4
		//IL_038b: Expected O, but got I
		//IL_002b: Expected I4, but got O
		//IL_00d7: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		CS_0024_003C_003E8__locals13.id = id;
		CS_0024_003C_003E8__locals13.button1Callback = (Action)button2TextIsLocalizationTerm;
		IntPtr intPtr = default(IntPtr);
		CS_0024_003C_003E8__locals13.button2Callback = (Action)(nint)intPtr;
		_ID = CS_0024_003C_003E8__locals13.id;
		object obj = default(object);
		bool flag = obj == null;
		bool flag2 = (byte)(int)title != 0;
		string text = title;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		if (!flag)
		{
			string translation = LocalizationManager.GetTranslation(title, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			flag2 = true;
			text = translation;
		}
		object obj2 = default(object);
		string text2;
		if (obj2 != null)
		{
			string translation2 = LocalizationManager.GetTranslation((string)titleIsLocalizationTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text2 = translation2;
			flag2 = true;
		}
		else
		{
			text2 = (string)titleIsLocalizationTerm;
		}
		object obj3 = default(object);
		if (obj3 != null)
		{
			string translation3 = LocalizationManager.GetTranslation((string)descriptionIsLocalizationTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string text3 = translation3;
			flag2 = true;
		}
		else
		{
			string text3 = (string)descriptionIsLocalizationTerm;
		}
		object obj4 = default(object);
		if (obj4 != null)
		{
			string translation4 = LocalizationManager.GetTranslation((string)button1TextIsLocalizationTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			flag2 = true;
			string text4 = translation4;
		}
		else
		{
			string text4 = (string)button1TextIsLocalizationTerm;
		}
		_Title.text = text;
		_Description.text = text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Button button = _Button1;
		UnityAction call = delegate
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals13.id);
			Action button1Callback2 = CS_0024_003C_003E8__locals13.button1Callback;
			if (CS_0024_003C_003E8__locals13.button1Callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		button.m_OnClick.AddListener(call);
		Button button2 = _Button2;
		UnityAction call2 = delegate
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals13.id);
			Action button2Callback2 = CS_0024_003C_003E8__locals13.button2Callback;
			if (CS_0024_003C_003E8__locals13.button2Callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		button2.m_OnClick.AddListener(call2);
		EventSystem current = EventSystem.current;
		_previouslySelected = current.m_CurrentSelected;
		Selectable componentInChildren = _Button1.GetComponentInChildren<Selectable>();
		componentInChildren.Select();
		base._refreshLayouts = true;
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rdi_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		CanvasGroup canvasGroup;
		if (gameObject.TryGetComponent<CanvasGroup>(out var component))
		{
			canvasGroup = component;
		}
		else
		{
			CanvasGroup canvasGroup2 = gameObject.AddComponent<CanvasGroup>();
			canvasGroup = canvasGroup2;
		}
		canvasGroup.alpha = 0f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(canvasGroup, 1f, 0.125f);
		_003CWaitAndSelect_003Ed__7 obj5 = null;
		obj5._003C_003E1__state = 0;
		obj5._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj5);
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__7 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
