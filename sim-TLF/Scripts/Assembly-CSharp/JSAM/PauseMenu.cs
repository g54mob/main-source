using UnityEngine;

namespace JSAM
{
	public class PauseMenu : MonoBehaviour
	{
		[Tooltip("Button used to toggle the pause menu, incompatible with Unity's new input manager")]
		[SerializeField]
		private KeyCode toggleButton = KeyCode.Escape;

		private Canvas pauseMenu;

		private void Awake()
		{
			pauseMenu = GetComponent<Canvas>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(toggleButton))
			{
				pauseMenu.enabled = !pauseMenu.enabled;
				if (pauseMenu.enabled)
				{
					Time.timeScale = 0f;
				}
				else
				{
					Time.timeScale = 1f;
				}
			}
			if (pauseMenu.enabled && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)))
			{
				Time.timeScale = 0f;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}
}
