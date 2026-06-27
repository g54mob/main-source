using System;
using System.Collections;
using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public class GUI_SettingsMenuSFX : MonoBehaviour
	{
		private const float DelayBeforePlayingSliderSound = 0.2f;

		[SerializeField]
		private GUI_SettingsMenu mainSettingsMenu;

		[SerializeField]
		private GUI_BaseSettingPanel[] settingsPanels = Array.Empty<GUI_BaseSettingPanel>();

		[SerializeField]
		private EventReference toggleSwitchedOnSound;

		[SerializeField]
		private EventReference toggleSwitchedOffSound;

		[SerializeField]
		private EventReference dropDownOptionClickedSound;

		[SerializeField]
		private EventReference sliderChangedValueSound;

		[SerializeField]
		private EventReference panelsSwitchedSound;

		[SerializeField]
		private EventReference keyRemappingProcessStartedSound;

		[SerializeField]
		private EventReference keyRemappingSuccessSound;

		[SerializeField]
		private EventReference keyRemappingFailSound;

		private IAudioPlayerService audioPlayer;

		private Coroutine playSliderSoundAfterDelayCoroutine;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
			if (base.isActiveAndEnabled)
			{
				mainSettingsMenu.OnShown.AddListener(ResolveMenuShown);
				mainSettingsMenu.OnHidden.AddListener(ResolveMenuHidden);
				mainSettingsMenu.OnClosed.AddListener(ResolveMenuClosed);
			}
		}

		private void OnEnable()
		{
			if (audioPlayer != null)
			{
				mainSettingsMenu.OnShown.AddListener(ResolveMenuShown);
				mainSettingsMenu.OnHidden.AddListener(ResolveMenuHidden);
				mainSettingsMenu.OnClosed.AddListener(ResolveMenuClosed);
			}
		}

		private void OnDisable()
		{
			if (audioPlayer != null)
			{
				mainSettingsMenu.OnShown.RemoveListener(ResolveMenuShown);
				mainSettingsMenu.OnHidden.RemoveListener(ResolveMenuHidden);
				mainSettingsMenu.OnClosed.RemoveListener(ResolveMenuClosed);
			}
			UnsubscribeFromPanelsEvents();
		}

		private void ResolveMenuShown()
		{
			SubscribeToPanelsEvents();
		}

		private void ResolveMenuHidden()
		{
			UnsubscribeFromPanelsEvents();
		}

		private void ResolveMenuClosed()
		{
			UnsubscribeFromPanelsEvents();
		}

		private void SubscribeToPanelsEvents()
		{
			GUI_BaseSettingPanel[] array = settingsPanels;
			foreach (GUI_BaseSettingPanel gUI_BaseSettingPanel in array)
			{
				if (!(gUI_BaseSettingPanel == null))
				{
					gUI_BaseSettingPanel.OnPanelShown.AddListener(ResolvePanelShown);
					gUI_BaseSettingPanel.OnSliderChangedValue.AddListener(ResolveSliderChangedValue);
					gUI_BaseSettingPanel.OnDropdownChangedValue.AddListener(ResolveDropdownChangedValue);
					gUI_BaseSettingPanel.OnToggleSwitchedToNewValue.AddListener(ResolveToggleSwitchedToNewValue);
					if (gUI_BaseSettingPanel is GUI_KeyboardControlsSettingPanel gUI_KeyboardControlsSettingPanel)
					{
						gUI_KeyboardControlsSettingPanel.OnRemappingInputListeningStarted.AddListener(ResolveRemappingInputListeningStarted);
						gUI_KeyboardControlsSettingPanel.OnRemappingSuccessfullyCompleted.AddListener(ResolveRemappingSucceeded);
						gUI_KeyboardControlsSettingPanel.OnRemappingFailed.AddListener(ResolveRemappingFailed);
					}
				}
			}
		}

		private void UnsubscribeFromPanelsEvents()
		{
			GUI_BaseSettingPanel[] array = settingsPanels;
			foreach (GUI_BaseSettingPanel gUI_BaseSettingPanel in array)
			{
				if (!(gUI_BaseSettingPanel == null))
				{
					gUI_BaseSettingPanel.OnPanelShown.RemoveListener(ResolvePanelShown);
					gUI_BaseSettingPanel.OnSliderChangedValue.RemoveListener(ResolveSliderChangedValue);
					gUI_BaseSettingPanel.OnDropdownChangedValue.RemoveListener(ResolveDropdownChangedValue);
					gUI_BaseSettingPanel.OnToggleSwitchedToNewValue.RemoveListener(ResolveToggleSwitchedToNewValue);
					if (gUI_BaseSettingPanel is GUI_KeyboardControlsSettingPanel gUI_KeyboardControlsSettingPanel)
					{
						gUI_KeyboardControlsSettingPanel.OnRemappingInputListeningStarted.RemoveListener(ResolveRemappingInputListeningStarted);
						gUI_KeyboardControlsSettingPanel.OnRemappingSuccessfullyCompleted.RemoveListener(ResolveRemappingSucceeded);
						gUI_KeyboardControlsSettingPanel.OnRemappingFailed.RemoveListener(ResolveRemappingFailed);
					}
				}
			}
		}

		private void ResolveRemappingInputListeningStarted()
		{
			audioPlayer.PlaySoundEventOneShot(keyRemappingProcessStartedSound);
		}

		private void ResolveRemappingSucceeded()
		{
			audioPlayer.PlaySoundEventOneShot(keyRemappingSuccessSound);
		}

		private void ResolveRemappingFailed()
		{
			audioPlayer.PlaySoundEventOneShot(keyRemappingFailSound);
		}

		private void ResolvePanelShown(GUI_BaseSettingPanel panel)
		{
			audioPlayer.PlaySoundEventOneShot(panelsSwitchedSound);
		}

		private void ResolveToggleSwitchedToNewValue(bool newValue)
		{
			audioPlayer.PlaySoundEventOneShot(newValue ? toggleSwitchedOnSound : toggleSwitchedOffSound);
		}

		private void ResolveDropdownChangedValue()
		{
			audioPlayer.PlaySoundEventOneShot(dropDownOptionClickedSound);
		}

		private void ResolveSliderChangedValue()
		{
			if (playSliderSoundAfterDelayCoroutine != null)
			{
				StopCoroutine(playSliderSoundAfterDelayCoroutine);
				playSliderSoundAfterDelayCoroutine = null;
			}
			playSliderSoundAfterDelayCoroutine = StartCoroutine(PlaySliderSoundAfterDelayCoroutine());
		}

		private IEnumerator PlaySliderSoundAfterDelayCoroutine()
		{
			yield return new WaitForSecondsRealtime(0.2f);
			audioPlayer.PlaySoundEventOneShot(sliderChangedValueSound);
			playSliderSoundAfterDelayCoroutine = null;
		}
	}
}
