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

public class TextInputPopup : BasePopup
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public TextInputPopup _003C_003E4__this;

		public string id;

		public Action<string> button1Callback;

		internal void _003CInitialize_003Eb__0()
		{
			_003C_003E4__this.Hide();
			PopupManager.ClosePopup(id);
			Action<string> action = button1Callback;
			if (button1Callback != null)
			{
				TextInputPopup textInputPopup = _003C_003E4__this;
				TMP_InputField inputField = textInputPopup._InputField;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ rax_v6 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__5(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TextInputPopup _003C_003E4__this;

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
			TextInputPopup textInputPopup = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null && (object)textInputPopup._Button1 != null)
				{
					Selectable componentInChildren = textInputPopup._Button1.GetComponentInChildren<Selectable>();
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

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Button1Text;

	private TMP_InputField _InputField;

	public void Initialize(PopupManager manager, string id, string title, string button1Text, Action<string> button1Callback, bool titleIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true)
	{
		//IL_002b: Expected I4, but got O
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		CS_0024_003C_003E8__locals9.id = id;
		Action<string> button1Callback2 = default(Action<string>);
		CS_0024_003C_003E8__locals9.button1Callback = button1Callback2;
		_ID = CS_0024_003C_003E8__locals9.id;
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
		string text2 = default(string);
		if (obj2 != null)
		{
			string translation2 = LocalizationManager.GetTranslation(text2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			flag2 = true;
			string text3 = translation2;
		}
		else
		{
			string text3 = text2;
		}
		_Title.text = text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Button button = _Button1;
		UnityAction call = delegate
		{
			CS_0024_003C_003E8__locals9._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals9.id);
			Action<string> button1Callback3 = CS_0024_003C_003E8__locals9.button1Callback;
			if (CS_0024_003C_003E8__locals9.button1Callback != null)
			{
				TextInputPopup textInputPopup = CS_0024_003C_003E8__locals9._003C_003E4__this;
				TMP_InputField inputField = textInputPopup._InputField;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ rax_v6 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		};
		button.m_OnClick.AddListener(call);
		EventSystem current = EventSystem.current;
		_previouslySelected = current.m_CurrentSelected;
		Selectable componentInChildren = _Button1.GetComponentInChildren<Selectable>();
		componentInChildren.Select();
		base._refreshLayouts = true;
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rdi_v4 (Il2CppMethodInfo)+38]");
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
		_003CWaitAndSelect_003Ed__5 obj3 = null;
		obj3._003C_003E1__state = 0;
		obj3._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj3);
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__5 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
