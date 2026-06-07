using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class NewsletterDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private BaseInteractable3DUIView _steamLinkButton;

		[SerializeField]
		private TMP_InputField _emailInputField;

		[SerializeField]
		private BaseInteractable3DUIView _submitButton;

		[SerializeField]
		private TextMeshProUGUII18n _feedbackText;

		public static bool HasSeenNewsletter { get; private set; }

		protected override void Awake()
		{
		}

		private void OnSteamLinkButtonClicked()
		{
		}

		protected override void OnEnable()
		{
		}

		private void SetFormEnabled(bool isEnabled)
		{
		}

		protected override void Opened()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private bool ValidateForm()
		{
			return false;
		}

		private void OnSubmitButtonClicked()
		{
		}

		private void Post()
		{
		}

		private void NewsletterSubscribeSuccess(string result)
		{
		}

		private void NewsletterSubscribeError(string result)
		{
		}
	}
}
