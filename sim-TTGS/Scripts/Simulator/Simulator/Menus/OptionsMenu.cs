using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class OptionsMenu : Menu
	{
		[Header("Pager")]
		[SerializeField]
		private UI_Pager m_pager;

		[Header("Toggles")]
		[SerializeField]
		private Toggle m_gameplayButton;

		[SerializeField]
		private Toggle m_graphicsButton;

		[SerializeField]
		private Toggle m_soundButton;

		[SerializeField]
		private Toggle m_controlsButton;

		[SerializeField]
		private Toggle m_accessibilityButton;

		[Header("Pages")]
		[SerializeField]
		private UI_GameplayOptions m_gameplayOptions;

		[SerializeField]
		private UI_GraphicsOptions m_graphicsOptions;

		[SerializeField]
		private UI_SoundOptions m_soundOptions;

		[SerializeField]
		private UI_ControlsOptions m_controlsOptions;

		[SerializeField]
		private UI_AccessibilityOptions m_accessibilityOptions;

		[Header("Others")]
		[SerializeField]
		private Button m_resetButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_gameplayButton.onValueChanged.AddListener(OnGameplayToggle);
			m_graphicsButton.onValueChanged.AddListener(OnGraphicsButton);
			m_soundButton.onValueChanged.AddListener(OnSoundButton);
			m_controlsButton.onValueChanged.AddListener(OnControlsButton);
			m_accessibilityButton.onValueChanged.AddListener(OnAccessibilityButton);
			m_resetButton.onClick.AddListener(OnResetButtonClicked_ResetSettings);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_gameplayButton.onValueChanged.RemoveListener(OnGameplayToggle);
			m_graphicsButton.onValueChanged.RemoveListener(OnGraphicsButton);
			m_soundButton.onValueChanged.RemoveListener(OnSoundButton);
			m_controlsButton.onValueChanged.RemoveListener(OnControlsButton);
			m_accessibilityButton.onValueChanged.RemoveListener(OnAccessibilityButton);
			m_resetButton.onClick.RemoveListener(OnResetButtonClicked_ResetSettings);
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_pager.CurrentPage.GameObject.SetActive(value: true);
			m_pager.RefreshCurrentPageNavBox();
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_pager.CurrentPage.GameObject.SetActive(value: false);
		}

		private void OnGameplayToggle(bool isToggled)
		{
			if (isToggled)
			{
				m_pager.GoToPage(m_gameplayOptions.gameObject);
			}
		}

		private void OnGraphicsButton(bool isToggled)
		{
			if (isToggled)
			{
				m_pager.GoToPage(m_graphicsOptions.gameObject);
			}
		}

		private void OnSoundButton(bool isToggled)
		{
			if (isToggled)
			{
				m_pager.GoToPage(m_soundOptions.gameObject);
			}
		}

		private void OnControlsButton(bool isToggled)
		{
			if (isToggled)
			{
				m_pager.GoToPage(m_controlsOptions.gameObject);
			}
		}

		private void OnAccessibilityButton(bool isToggled)
		{
			if (isToggled)
			{
				m_pager.GoToPage(m_accessibilityOptions.gameObject);
			}
		}

		private async void OnResetButtonClicked_ResetSettings()
		{
			UI_Page currentPage = m_pager.CurrentPage;
			UI_GraphicsOptions component2;
			UI_SoundOptions component3;
			UI_ControlsOptions component4;
			UI_AccessibilityOptions component5;
			if (currentPage.GameObject.TryGetComponent<UI_GameplayOptions>(out var _))
			{
				CustomSettings<GameplayApplicationOptions>.I.ResetSettings();
			}
			else if (currentPage.GameObject.TryGetComponent<UI_GraphicsOptions>(out component2))
			{
				CustomSettings<GraphicsApplicationOptions>.I.ResetSettings();
			}
			else if (currentPage.GameObject.TryGetComponent<UI_SoundOptions>(out component3))
			{
				CustomSettings<AudioApplicationOptions>.I.ResetSettings();
			}
			else if (currentPage.GameObject.TryGetComponent<UI_ControlsOptions>(out component4))
			{
				CustomSettings<ControlsApplicationOptions>.I.ResetSettings();
			}
			else if (currentPage.GameObject.TryGetComponent<UI_AccessibilityOptions>(out component5))
			{
				CustomSettings<AccessibilityApplicationOptions>.I.ResetSettings();
			}
			await Awaitable.NextFrameAsync();
			currentPage.GameObject.SetActive(value: false);
			currentPage.GameObject.SetActive(value: true);
			currentPage.SetLayoutGroupDirty();
			currentPage.TryRefreshLayoutGroupsImmediateAndRecursive();
		}
	}
}
