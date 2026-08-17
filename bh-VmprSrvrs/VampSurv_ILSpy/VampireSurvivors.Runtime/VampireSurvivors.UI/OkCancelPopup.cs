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

namespace VampireSurvivors.UI;

public class OkCancelPopup : BasePopup
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public OkCancelPopup _003C_003E4__this;

		public string id;

		public Action<bool> callback;

		internal void _003CInitialize_003Eb__0()
		{
			_003C_003E4__this.Hide();
			PopupManager.ClosePopup(id);
			Action<bool> action = callback;
			if (callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v28 @ rax_v5 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CInitialize_003Eb__1()
		{
			_003C_003E4__this.Hide();
			PopupManager.ClosePopup(id);
			Action<bool> action = callback;
			if (callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v28 @ rax_v5 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__6(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OkCancelPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0130: Expected I4, but got O
			OkCancelPopup okCancelPopup = _003C_003E4__this;
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
				EventSystem current = EventSystem.current;
				if ((object)current != null && (object)_003C_003E4__this != null)
				{
					okCancelPopup._previouslySelected = current.m_CurrentSelected;
					if ((object)okCancelPopup._OkButton != null)
					{
						Selectable componentInChildren = okCancelPopup._OkButton.GetComponentInChildren<Selectable>();
						if ((object)componentInChildren != null)
						{
							componentInChildren.Select();
							goto IL_015c;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_015c;
			IL_015c:
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

	private Button _OkButton;

	private Button _CancelButton;

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Description;

	private PopupManager _manager;

	public void Initialize(string id, string title, string description, Action<bool> callback, bool textIsLocalizationTerm = true)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals12._003C_003E4__this = this;
		CS_0024_003C_003E8__locals12.id = id;
		Action<bool> callback2 = default(Action<bool>);
		CS_0024_003C_003E8__locals12.callback = callback2;
		_ID = CS_0024_003C_003E8__locals12.id;
		object obj = default(object);
		bool flag = obj == null;
		string text = title;
		string text2 = description;
		if (!flag)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(title, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string translation2 = LocalizationManager.GetTranslation(description, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text = translation;
			text2 = translation2;
		}
		_Title.text = text;
		_Description.text = text2;
		Button okButton = _OkButton;
		UnityAction call = delegate
		{
			CS_0024_003C_003E8__locals12._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals12.id);
			Action<bool> callback3 = CS_0024_003C_003E8__locals12.callback;
			if (CS_0024_003C_003E8__locals12.callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v28 @ rax_v5 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		};
		okButton.m_OnClick.AddListener(call);
		Button cancelButton = _CancelButton;
		UnityAction call2 = delegate
		{
			CS_0024_003C_003E8__locals12._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals12.id);
			Action<bool> callback3 = CS_0024_003C_003E8__locals12.callback;
			if (CS_0024_003C_003E8__locals12.callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v28 @ rax_v5 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		};
		cancelButton.m_OnClick.AddListener(call2);
		_003CWaitAndSelect_003Ed__6 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rbx_v4 (Il2CppMethodInfo)+38]");
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
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__6 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
