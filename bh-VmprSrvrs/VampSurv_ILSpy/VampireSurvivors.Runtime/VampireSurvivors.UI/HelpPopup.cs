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
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class HelpPopup : BasePopup
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public HelpPopup _003C_003E4__this;

		public string id;

		public Action callback;

		public string helpUrl;

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

		internal void _003CInitialize_003Eb__1()
		{
			Application.OpenURL(helpUrl);
		}
	}

	private sealed class _003CWaitAndSelect_003Ed__9(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public HelpPopup _003C_003E4__this;

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
			HelpPopup helpPopup = _003C_003E4__this;
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
					helpPopup._previouslySelected = current.m_CurrentSelected;
					if ((object)helpPopup._OkButton != null)
					{
						Selectable componentInChildren = helpPopup._OkButton.GetComponentInChildren<Selectable>();
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

	private Button _HelpButton;

	private RawImage _QrCode;

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Description;

	private TextMeshProUGUI _HelpText;

	private TextMeshProUGUI _HelpButtonText;

	private PopupManager _manager;

	public void Initialize(PopupManager manager, string id, string title, string description, string helpText, string helpUrl, string qrCodeName, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool helpTextIsLocalizationTerm = true)
	{
		//IL_024f: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_011b: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		CS_0024_003C_003E8__locals11.id = id;
		Action callback2 = default(Action);
		CS_0024_003C_003E8__locals11.callback = callback2;
		CS_0024_003C_003E8__locals11.helpUrl = (string)helpTextIsLocalizationTerm;
		_manager = manager;
		_ID = CS_0024_003C_003E8__locals11.id;
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
		string text2;
		if (obj2 != null)
		{
			string translation2 = LocalizationManager.GetTranslation((string)titleIsLocalizationTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text2 = translation2;
		}
		else
		{
			text2 = (string)titleIsLocalizationTerm;
		}
		object obj3 = default(object);
		string text3;
		if (obj3 != null)
		{
			string translation3 = LocalizationManager.GetTranslation((string)descriptionIsLocalizationTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text3 = translation3;
		}
		else
		{
			text3 = (string)descriptionIsLocalizationTerm;
		}
		IntPtr intPtr = default(IntPtr);
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite((string)(nint)intPtr);
		Texture2D texture = unpackedSprite.texture;
		_QrCode.texture = texture;
		_Title.text = text;
		_Description.text = text2;
		_HelpText.text = text3;
		_HelpButtonText.text = CS_0024_003C_003E8__locals11.helpUrl;
		Button okButton = _OkButton;
		UnityAction call = delegate
		{
			CS_0024_003C_003E8__locals11._003C_003E4__this.Hide();
			PopupManager.ClosePopup(CS_0024_003C_003E8__locals11.id);
			Action callback3 = CS_0024_003C_003E8__locals11.callback;
			if (CS_0024_003C_003E8__locals11.callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		okButton.m_OnClick.AddListener(call);
		Button helpButton = _HelpButton;
		UnityAction call2 = delegate
		{
			Application.OpenURL(CS_0024_003C_003E8__locals11.helpUrl);
		};
		helpButton.m_OnClick.AddListener(call2);
		_003CWaitAndSelect_003Ed__9 obj4 = null;
		obj4._003C_003E1__state = 0;
		obj4._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj4);
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__9 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
