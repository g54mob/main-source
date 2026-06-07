using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class MenuConfirmationPopup : Menu
	{
		[Serializable]
		public struct Terms
		{
			[field: SerializeField]
			[field: TermsPopup("")]
			public string Question { get; private set; }

			[field: SerializeField]
			[field: TermsPopup("")]
			public string Validation { get; private set; }

			[field: SerializeField]
			[field: TermsPopup("")]
			public string Cancel { get; private set; }
		}

		[Header("UI Components")]
		[SerializeField]
		private TextMeshProUGUI m_questionText;

		[SerializeField]
		private TextMeshProUGUI m_validationText;

		[SerializeField]
		private TextMeshProUGUI m_cancelText;

		[SerializeField]
		private Button m_validationButton;

		private Action m_onValidate;

		private Action m_onCancel;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_validationButton.onClick.AddListener(OnButton_Validate);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_validationButton.onClick.RemoveListener(OnButton_Validate);
		}

		public void Show(Terms terms, Action onValidate, Action onCancel = null)
		{
			if (!base.IsActive)
			{
				SetActive(active: true);
			}
			m_questionText.text = LocalizationManager.GetTranslation(terms.Question);
			m_validationText.text = LocalizationManager.GetTranslation(terms.Validation);
			m_cancelText.text = LocalizationManager.GetTranslation(terms.Cancel);
			m_onValidate = onValidate;
			m_onCancel = onCancel;
		}

		protected virtual void OnButton_Validate()
		{
			Cancel();
			m_onValidate?.Invoke();
		}

		protected override void Back()
		{
			Cancel();
			m_onCancel?.Invoke();
		}

		private void Cancel()
		{
			SetActive(active: false);
		}

		protected override void ICancelInputReceiverOnActive()
		{
			ICancelInputReceiver.Stack(this);
		}

		protected override void ICancelInputReceiverOnInactive()
		{
			ICancelInputReceiver.PopCurrent();
		}
	}
}
