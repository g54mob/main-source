using Presentation.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.Gametester
{
	public class GametesterGGWindow : MonoBehaviour
	{
		[SerializeField]
		private StartScreen _startScreen;

		[SerializeField]
		private TextMeshProUGUI _authResultText;

		[SerializeField]
		private Button _submitButton;

		[SerializeField]
		private InputField UserPinField;

		private void Awake()
		{
			_submitButton.onClick.AddListener(OnSubmitButton);
		}

		private void OnDestroy()
		{
			_submitButton.onClick.RemoveListener(OnSubmitButton);
		}

		private void OnSubmitButton()
		{
			string userPin = UserPinField.text ?? string.Empty;
			GametesterGGManager.Instance.Submit(userPin);
		}

		public void Hide()
		{
			_startScreen.GameTesterPanelHidden();
			base.gameObject.SetActive(value: false);
		}

		public void ShowErrorResult(string errCode)
		{
			_authResultText.gameObject.SetActive(value: true);
			_authResultText.SetText(errCode);
		}
	}
}
