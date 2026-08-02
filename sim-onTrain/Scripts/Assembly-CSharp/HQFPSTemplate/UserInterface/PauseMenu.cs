using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	public class PauseMenu : MonoBehaviour
	{
		[SerializeField]
		private Panel m_Panel;

		[SerializeField]
		private Panel m_MapSelectionPanel;

		[SerializeField]
		private bool m_UseKeyToPause = true;

		[SerializeField]
		[ShowIf("m_UseKeyToPause", true, 10f)]
		private KeyCode m_PauseKey = KeyCode.Escape;

		public void TogglePause(bool enable)
		{
			Player currentPlayer = Singleton<GameManager>.Instance.CurrentPlayer;
			if (enable)
			{
				currentPlayer.Pause.ForceStart();
			}
			else
			{
				currentPlayer.Pause.ForceStop();
				m_MapSelectionPanel.TryShow(show: false);
			}
			Time.timeScale = (enable ? 0f : 1f);
			m_Panel.TryShow(enable);
			Cursor.lockState = ((!enable) ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = enable;
		}

		public void LoadScene(int index)
		{
			TogglePause(enable: false);
			Singleton<GameManager>.Instance.StartGame(index);
		}

		public void ToggleMapSelection()
		{
			m_MapSelectionPanel.TryShow(!m_MapSelectionPanel.IsVisible);
		}

		public void Quit()
		{
			Singleton<GameManager>.Instance.Quit();
		}

		private void Start()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			if (m_UseKeyToPause && Input.GetKeyDown(m_PauseKey))
			{
				TogglePause(!Singleton<GameManager>.Instance.CurrentPlayer.Pause.Active);
			}
		}
	}
}
