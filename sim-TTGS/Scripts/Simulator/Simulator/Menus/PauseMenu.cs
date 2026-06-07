using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class PauseMenu : Menu
	{
		[Header("UI Components")]
		[SerializeField]
		private Button m_resumeButton;

		[SerializeField]
		private Button m_optionsButton;

		[SerializeField]
		private Button m_saveButton;

		[SerializeField]
		private Button m_loadButton;

		[SerializeField]
		private Button m_mainMenuButton;

		[SerializeField]
		private Button m_quitButton;

		[SerializeField]
		private Button m_bugButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_resumeButton.onClick.AddListener(Back);
			m_optionsButton.onClick.AddListener(OnButtonOptionMenu);
			m_saveButton.onClick.AddListener(OnButtonSave);
			m_loadButton.onClick.AddListener(OnButtonLoad);
			m_mainMenuButton.onClick.AddListener(OnButtonMainMenu);
			if ((bool)m_quitButton)
			{
				m_quitButton.onClick.AddListener(OnQuitButton);
			}
			if ((bool)m_bugButton)
			{
				m_bugButton.onClick.AddListener(OnBugButton);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_resumeButton.onClick.RemoveListener(Back);
			m_optionsButton.onClick.RemoveListener(OnButtonOptionMenu);
			m_saveButton.onClick.RemoveListener(OnButtonSave);
			m_loadButton.onClick.RemoveListener(OnButtonLoad);
			m_mainMenuButton.onClick.RemoveListener(OnButtonMainMenu);
			if ((bool)m_quitButton)
			{
				m_quitButton.onClick.RemoveListener(OnQuitButton);
			}
			if ((bool)m_bugButton)
			{
				m_bugButton.onClick.RemoveListener(OnBugButton);
			}
		}

		private void OnButtonOptionMenu()
		{
			base.Manager.OpenOptionMenu();
		}

		private void OnButtonSave()
		{
			base.Manager.OpenSaveMenu();
		}

		private void OnButtonLoad()
		{
			base.Manager.OpenLoadMenu();
		}

		private void OnButtonMainMenu()
		{
			base.Manager.BackToMainMenu();
		}

		private void OnQuitButton()
		{
			base.Manager.QuitGame();
		}

		private void OnBugButton()
		{
			base.Manager.OpenBugMenu();
		}
	}
}
