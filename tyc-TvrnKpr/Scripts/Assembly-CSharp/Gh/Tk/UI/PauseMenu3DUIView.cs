using System;
using System.Runtime.CompilerServices;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class PauseMenu3DUIView : ShowHideAnimation3DUIView
	{
		private bool _waitingForDialog;

		[SerializeField]
		private ShowHideAnimation3DUIView _menuRoot;

		[SerializeField]
		private Button3DUIView _resumeButton;

		[SerializeField]
		private Button3DUIView _handbookButton;

		[SerializeField]
		private Button3DUIView _trophyCaseButton;

		[SerializeField]
		private Button3DUIView _saveButton;

		[SerializeField]
		private SaveGameDialog3DUIView _saveGameDialog;

		[SerializeField]
		private Button3DUIView _loadButton;

		[SerializeField]
		private Button3DUIView _importButton;

		[SerializeField]
		private Button3DUIView _settingsButton;

		[SerializeField]
		private Button3DUIView _quitToMainMenuButton;

		[SerializeField]
		private Button3DUIView _saveAndQuitButton;

		[SerializeField]
		private Button3DUIView _quitButton;

		public bool IsActive => false;

		public bool IsMenuActive => false;

		public static event EventHandler OpenStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		private void OnDialogClosing(object sender, EventArgs e)
		{
		}

		private void OnDialogClosed(object sender, EventArgs e)
		{
		}

		private void OnLevelLoadingBegun(object sender, EventArgs e)
		{
		}

		private void OnHandbookButtonClicked()
		{
		}

		private void OnTrophyCaseButtonClicked()
		{
		}

		public void OpenCollectibleCards()
		{
		}

		private void WaitForDialogAndClose()
		{
		}

		private void OnResetUI(object sender, EventArgs eventArgs)
		{
		}

		private void OnResumeButtonClicked()
		{
		}

		private void OnSaveButtonClicked()
		{
		}

		private void OnLoadButtonClicked()
		{
		}

		private void OnImportButtonClicked()
		{
		}

		private void OnSettingsButtonClicked()
		{
		}

		private string GetQuitMessage()
		{
			return null;
		}

		private void OnQuitToMainMenuButtonClicked()
		{
		}

		private void OnSaveAndQuitButtonClicked()
		{
		}

		private void OnQuitButtonClicked()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private void OpenMenuRoot()
		{
		}

		private void CloseMenuRoot()
		{
		}

		public void BackOrClose()
		{
		}
	}
}
