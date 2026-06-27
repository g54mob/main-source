using System;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWindowsXpScreenView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Button exitButton;

		public bool IsVisible
		{
			get
			{
				if ((bool)canvasGroup)
				{
					return canvasGroup.interactable;
				}
				return false;
			}
		}

		public event Action OnExitButtonClicked;

		public void Show()
		{
			exitButton.onClick.AddListener(ResolveExitButtonClicked);
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			if (exitButton.MonoShellExists())
			{
				exitButton.onClick.RemoveListener(ResolveExitButtonClicked);
			}
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0f;
		}

		private void ResolveExitButtonClicked()
		{
			this.OnExitButtonClicked?.Invoke();
		}
	}
}
