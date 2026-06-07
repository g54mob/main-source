using Presentation.Gametester;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class DisclaimerUI : MonoBehaviour
	{
		[SerializeField]
		private StartScreen _startScreen;

		[SerializeField]
		private Button _continueButton;

		protected virtual void Awake()
		{
			_continueButton.onClick.AddListener(OnContinueButtonClicked);
		}

		protected virtual void OnDestroy()
		{
			_continueButton.onClick.RemoveListener(OnContinueButtonClicked);
		}

		protected virtual void OnContinueButtonClicked()
		{
			if (GametesterGGManager.UseGametesterAPI)
			{
				GametesterGGManager.UnlockTest();
			}
			_startScreen.ShowMainMenu();
			base.gameObject.SetActive(value: false);
		}
	}
}
