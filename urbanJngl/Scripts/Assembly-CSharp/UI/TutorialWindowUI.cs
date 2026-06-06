using System;
using UnityEngine;

namespace UI
{
	public class TutorialWindowUI : MonoBehaviour
	{
		private void Start()
		{
			InputManager.Instance.OnEscape += OnEscapeButton;
		}

		private void OnDestroy()
		{
			InputManager.Instance.OnEscape -= OnEscapeButton;
		}

		private void OnEscapeButton(object sender, EventArgs e)
		{
			if (base.isActiveAndEnabled)
			{
				Hide();
			}
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			MainMenuUI.Instance.InnerWindowOpen = true;
			MainMenuUI.Instance.ToggleMainMenu(value: true);
		}

		public void Hide()
		{
			MainMenuUI.Instance.InnerWindowOpen = false;
			MainMenuUI.Instance.ToggleMainMenu(value: false);
			base.gameObject.SetActive(value: false);
		}

		public void ToggleWindow()
		{
			if (base.isActiveAndEnabled)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}
	}
}
