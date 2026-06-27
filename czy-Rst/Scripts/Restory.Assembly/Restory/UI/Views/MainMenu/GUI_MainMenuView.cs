using System;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.MainMenu
{
	public class GUI_MainMenuView : UIBehaviour
	{
		[SerializeField]
		private Button newGameButton;

		[SerializeField]
		private Button optionsButton;

		[SerializeField]
		private Button quitGameButton;

		[Space]
		[Header("Continue Button")]
		[SerializeField]
		private Button continueButton;

		[SerializeField]
		private GUI_InteractibleView continueButtonInteractibleView;

		[SerializeField]
		private GUI_PresetSwitcher continueButtonPresetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		public bool ContinueButtonVisibility
		{
			get
			{
				return continueButton.enabled;
			}
			set
			{
				continueButton.enabled = value;
				continueButtonInteractibleView.enabled = value;
				continueButtonPresetSwitcher.ActivatePreset(value ? normalPreset : disabledPreset);
			}
		}

		public bool NewButtonVisibility
		{
			get
			{
				return newGameButton.gameObject.activeSelf;
			}
			set
			{
				newGameButton.gameObject.SetActive(value);
			}
		}

		public event Action OnContinueClick;

		public event Action OnNewGameClick;

		public event Action OnSettingsClick;

		public event Action OnQuitClick;

		protected override void OnEnable()
		{
			newGameButton.onClick.AddListener(ResolveNewGameOnClick);
			continueButton.onClick.AddListener(ResolveContinueOnClick);
			optionsButton.onClick.AddListener(ResolveSettingsOnClick);
			quitGameButton.onClick.AddListener(ResolveQuitOnClick);
		}

		protected override void OnDisable()
		{
			newGameButton.onClick.RemoveListener(ResolveNewGameOnClick);
			continueButton.onClick.RemoveListener(ResolveContinueOnClick);
			optionsButton.onClick.RemoveListener(ResolveSettingsOnClick);
			quitGameButton.onClick.RemoveListener(ResolveQuitOnClick);
		}

		private void ResolveNewGameOnClick()
		{
			this.OnNewGameClick?.Invoke();
		}

		private void ResolveContinueOnClick()
		{
			this.OnContinueClick?.Invoke();
		}

		private void ResolveSettingsOnClick()
		{
			this.OnSettingsClick?.Invoke();
		}

		private void ResolveQuitOnClick()
		{
			this.OnQuitClick?.Invoke();
		}
	}
}
