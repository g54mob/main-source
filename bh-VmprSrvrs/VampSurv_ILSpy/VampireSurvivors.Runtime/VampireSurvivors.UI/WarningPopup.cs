using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class WarningPopup : BasePopup
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public WarningPopup _003C_003E4__this;

		public string id;

		public Action callback;

		internal void _003CInitialize_003Eb__0()
		{
			_003C_003E4__this.Hide();
			PopupManager.ClosePopup(id);
			Action action = callback;
			if (callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__5(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public WarningPopup _003C_003E4__this;

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
			WarningPopup warningPopup = _003C_003E4__this;
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
					warningPopup._previouslySelected = current.m_CurrentSelected;
					if ((object)warningPopup._OkButton != null)
					{
						Selectable componentInChildren = warningPopup._OkButton.GetComponentInChildren<Selectable>();
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

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Description;

	private PopupManager _manager;

	public void Initialize(PopupManager manager, string id, string title, string description, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.id = id;
		Action callback2 = default(Action);
		CS_0024_003C_003E8__locals8.callback = callback2;
		_manager = manager;
		_ID = CS_0024_003C_003E8__locals8.id;
		object obj = default(object);
		bool flag = obj == null;
		string text = title;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		if (!flag)
		{
			string translation = LocalizationManager.GetTranslation(title, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text = translation;
		}
		object obj2 = default(object);
		string text2 = default(string);
		string text3;
		if (obj2 != null)
		{
			string translation2 = LocalizationManager.GetTranslation(text2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text3 = translation2;
		}
		else
		{
			text3 = text2;
		}
		_Title.text = text;
		_Description.text = text3;
		Button okButton = _OkButton;
		UnityAction call = delegate
		{
			CS_0024_003C_003E8__locals8._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals8.id);
			Action callback3 = CS_0024_003C_003E8__locals8.callback;
			if (CS_0024_003C_003E8__locals8.callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		okButton.m_OnClick.AddListener(call);
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
