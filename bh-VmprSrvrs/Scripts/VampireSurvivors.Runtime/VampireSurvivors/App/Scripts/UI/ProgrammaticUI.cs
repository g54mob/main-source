using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI
{
	public abstract class ProgrammaticUI : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndActivateInputField_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMP_InputField field;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndActivateInputField_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		protected TextMeshProUGUI _Title;

		[SerializeField]
		protected RectTransform _Content;

		[SerializeField]
		protected GameObject _LabelledButtonPrefab;

		[SerializeField]
		protected GameObject _LabelPrefab;

		[SerializeField]
		protected GameObject _InputPrefab;

		[SerializeField]
		protected GameObject _ButtonPrefab;

		[SerializeField]
		protected GameObject _SaveSlotPrefab;

		[SerializeField]
		protected GameObject _AccountDetailPrefab;

		[SerializeField]
		protected GameObject _PrivacyPolicyGatePrefab;

		[SerializeField]
		protected GameObject _PrivacyPolicyScrollerPrefab;

		[SerializeField]
		protected GameObject _DateOfBirthPrefab;

		[SerializeField]
		protected GameObject _HelpAndSupportPrefab;

		protected List<ISelectableUI> _spawnedSelectables;

		protected List<IUIObject> _spawnedUnselectables;

		[SerializeField]
		private Selectable OnUp;

		[SerializeField]
		private Selectable OnDown;

		protected override void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndActivateInputField_003Ed__17))]
		private IEnumerator WaitAndActivateInputField(TMP_InputField field)
		{
			return null;
		}

		public void AddAccountDetail(bool linked, string account, string detail, string buttonText = "", Action callback = null)
		{
		}

		public void AddSaveSlot(string title, string savedata, string buttonText = "", Action callback = null)
		{
		}

		public LabeledButtonUI AddLabeledButton(string labelText, string buttonText, Action callback, bool textIsLocalizationTerm = true, bool isEnabledByDefault = true)
		{
			return null;
		}

		public AccountHelpAndSupportUI AddHelpAndSupport(string helpText, string privacyPolicyText)
		{
			return null;
		}

		public void AddPrivacyPolicyGate(string warningMessage, string centerButtonText, Action centerButtonCallback, bool textIsLocalizationTerm = true)
		{
		}

		public void AddPrivacyPolicyScroller(string leftButtonText, Action leftButtonCallback, string rightButtonText, Action rightButtonCallback, bool textIsLocalizationTerm = true)
		{
		}

		public GameObject AddDateOfBirth(string label, Action onAllFieldsFilled)
		{
			return null;
		}

		public ButtonUI AddButton(string buttonText, Action callback, bool textIsLocalizationTerm = true)
		{
			return null;
		}

		public void AddLabel(string labelText)
		{
		}

		public LabeledInputUI AddLabeledEmailInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
		{
			return null;
		}

		public LabeledInputUI AddLabeledPasswordInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
		{
			return null;
		}

		private LabeledInputUI AddLabeledInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, TMP_InputField.ContentType contentType = TMP_InputField.ContentType.Alphanumeric, UnityAction<string> onChange = null)
		{
			return null;
		}

		public virtual void Clear()
		{
		}

		private string Translate(string term)
		{
			return null;
		}

		public void ShowLoading(string message)
		{
		}

		public virtual void SelectFirstSelectable()
		{
		}

		public void SelectFirstSelectable(List<GameObject> ignoreObjects)
		{
		}

		public void HideLoading()
		{
		}

		public void ShowOkPopup(string title, string description, Action callback)
		{
		}

		public void ShowAccountErrorPopup(string title, string description, string helpText, Action callback)
		{
		}

		public void ShowYesNoPopup(string title, string description, Action yesCallback, Action noCallback)
		{
		}

		public void GenerateNavigation()
		{
		}
	}
}
