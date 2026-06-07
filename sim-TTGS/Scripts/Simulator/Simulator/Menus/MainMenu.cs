using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class MainMenu : Menu
	{
		[Header("UI Components")]
		[SerializeField]
		private Button m_continueButton;

		[SerializeField]
		private Button m_newGameButton;

		[SerializeField]
		private Button m_loadGameButton;

		[SerializeField]
		private Button m_optionsButton;

		[SerializeField]
		private Button m_creditsButton;

		[SerializeField]
		private Button m_quitGameButton;

		[Header("Optional")]
		[SerializeField]
		private Button m_discordButton;

		[SerializeField]
		private Button m_bugButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_continueButton.onClick.AddListener(OnButtonContinue);
			m_newGameButton.onClick.AddListener(OnButtonNewGame);
			m_loadGameButton.onClick.AddListener(OnButtonLoadGame);
			m_optionsButton.onClick.AddListener(OnButtonOptionMenu);
			m_creditsButton.onClick.AddListener(OnButtonCredits);
			m_quitGameButton.onClick.AddListener(OnButtonQuitGame);
			if (m_discordButton != null)
			{
				m_discordButton.onClick.AddListener(OnButtonDiscord);
			}
			if (m_bugButton != null)
			{
				m_bugButton.onClick.AddListener(OnButtonBug);
			}
			EventManager.OnWorldEvent += OnWorldEvent;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_continueButton.onClick.RemoveListener(OnButtonContinue);
			m_newGameButton.onClick.RemoveListener(OnButtonNewGame);
			m_loadGameButton.onClick.RemoveListener(OnButtonLoadGame);
			m_optionsButton.onClick.RemoveListener(OnButtonOptionMenu);
			m_creditsButton.onClick.RemoveListener(OnButtonCredits);
			m_quitGameButton.onClick.RemoveListener(OnButtonQuitGame);
			if (m_discordButton != null)
			{
				m_discordButton.onClick.RemoveListener(OnButtonDiscord);
			}
			if (m_bugButton != null)
			{
				m_bugButton.onClick.RemoveListener(OnButtonBug);
			}
			EventManager.OnWorldEvent -= OnWorldEvent;
		}

		protected override void OnMenuEvent(EMenuEvent menuEvent)
		{
			base.OnMenuEvent(menuEvent);
			if (menuEvent == EMenuEvent.OPEN)
			{
				RefreshVisibilityOfSaveRelatedButtons();
			}
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			if (worldEvent == EWorldEvent.QUIT)
			{
				RefreshVisibilityOfSaveRelatedButtons();
			}
		}

		private void OnButtonContinue()
		{
			SaveManager.SetCurrentSaveFile(SaveManager.GetLastSaveFill().fileInfo);
			TransientManager<SceneManager>.Instance.LoadScene(SceneManager.Map.WORLD);
		}

		private void OnButtonNewGame()
		{
			SaveManager.SetCurrentSaveFile(null);
			TransientManager<SceneManager>.Instance.LoadScene(SceneManager.Map.WORLD);
		}

		private void OnButtonLoadGame()
		{
			base.Manager.OpenLoadMenu();
		}

		private void OnButtonOptionMenu()
		{
			base.Manager.OpenOptionMenu();
		}

		private void OnButtonCredits()
		{
			base.Manager.OpenCredits();
		}

		private void OnButtonQuitGame()
		{
			base.Manager.QuitGame();
		}

		private void OnButtonDiscord()
		{
			Application.OpenURL(DiscordSettings.ServerInvitationURL);
		}

		private void OnButtonBug()
		{
			base.Manager.OpenBugMenu();
		}

		private void RefreshVisibilityOfSaveRelatedButtons()
		{
			SetVisibilityOfSaveRelatedButtons(SaveManager.HasSaveFile());
		}

		private void SetVisibilityOfSaveRelatedButtons(bool visibility)
		{
			m_continueButton.transform.parent.gameObject.SetActive(visibility);
			m_loadGameButton.transform.parent.gameObject.SetActive(visibility);
		}
	}
}
