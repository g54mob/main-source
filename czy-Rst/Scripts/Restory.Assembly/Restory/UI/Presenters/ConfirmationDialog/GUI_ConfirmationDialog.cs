using System;
using Restory.UI.Views.ConfirmationDialog;
using UnityEngine;

namespace Restory.UI.Presenters.ConfirmationDialog
{
	public class GUI_ConfirmationDialog : MonoBehaviour
	{
		[SerializeField]
		private GUI_ConfirmationDialogView view;

		[SerializeField]
		private GUI_PanelStack panelStack;

		private bool isShown;

		private Action onPositiveCallback;

		private Action onNegativeCallback;

		private void OnEnable()
		{
			view.OnPositiveClicked += ResolveOnPositiveClicked;
			view.OnNegativeClicked += ResolveOnNegativeClicked;
		}

		private void OnDisable()
		{
			view.OnPositiveClicked -= ResolveOnPositiveClicked;
			view.OnNegativeClicked -= ResolveOnNegativeClicked;
		}

		public void Show(string textLocalizationID, Action onPositiveCallback, Action onNegativeCallback)
		{
			if (!isShown)
			{
				isShown = true;
				panelStack.AddPanel(base.gameObject);
				this.onPositiveCallback = onPositiveCallback;
				this.onNegativeCallback = onNegativeCallback;
				view.SetDescription(textLocalizationID);
				view.Show();
			}
		}

		public void Hide()
		{
			if (isShown)
			{
				isShown = false;
				panelStack.RemovePanel(base.gameObject);
				onPositiveCallback = null;
				onNegativeCallback = null;
				view.Hide();
			}
		}

		private void ResolveOnPositiveClicked()
		{
			onPositiveCallback?.Invoke();
		}

		private void ResolveOnNegativeClicked()
		{
			onNegativeCallback?.Invoke();
		}
	}
}
