using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Michsky.UI.Heat
{
	public class PauseMenuManager : MonoBehaviour
	{
		public enum CursorVisibility
		{
			Default = 0,
			Invisible = 1,
			Visible = 2
		}

		public GameObject pauseMenuCanvas;

		[SerializeField]
		private ButtonManager continueButton;

		[SerializeField]
		private PanelManager panelManager;

		[SerializeField]
		private ImageFading background;

		[SerializeField]
		private bool setTimeScale = true;

		[Range(0f, 1f)]
		public float inputBlockDuration = 0.2f;

		public CursorLockMode menuCursorState;

		public CursorLockMode gameCursorState = CursorLockMode.Locked;

		public CursorVisibility menuCursorVisibility = CursorVisibility.Visible;

		public CursorVisibility gameCursorVisibility;

		[SerializeField]
		private InputAction hotkey;

		public UnityEvent onOpen = new UnityEvent();

		public UnityEvent onClose = new UnityEvent();

		private bool isOn;

		private bool allowClosing = true;

		private float disableAfter = 0.6f;

		private void Awake()
		{
			if (pauseMenuCanvas == null)
			{
				Debug.LogError("<b>[Pause Menu Manager]</b> Pause Menu Canvas is missing!", this);
				base.enabled = false;
			}
			else
			{
				pauseMenuCanvas.SetActive(value: true);
			}
		}

		private void Start()
		{
			if (panelManager != null)
			{
				disableAfter = HeatUIInternalTools.GetAnimatorClipLength(panelManager.panels[panelManager.currentPanelIndex].panelObject, "MainPanel_Out");
			}
			if (continueButton != null)
			{
				continueButton.onClick.AddListener(ClosePauseMenu);
			}
			pauseMenuCanvas.SetActive(value: false);
			hotkey.Enable();
		}

		private void Update()
		{
			if (hotkey.triggered)
			{
				AnimatePauseMenu();
			}
		}

		public void AnimatePauseMenu()
		{
			if (!isOn)
			{
				OpenPauseMenu();
			}
			else
			{
				ClosePauseMenu();
			}
		}

		public void OpenPauseMenu()
		{
			if (!isOn)
			{
				if (setTimeScale)
				{
					Time.timeScale = 0f;
				}
				if (inputBlockDuration > 0f)
				{
					AllowClosing(value: false);
					StopCoroutine("InputBlockProcess");
					StartCoroutine("InputBlockProcess");
				}
				StopCoroutine("DisablePauseCanvas");
				isOn = true;
				onOpen.Invoke();
				pauseMenuCanvas.SetActive(value: false);
				pauseMenuCanvas.SetActive(value: true);
				FadeInBackground();
				Cursor.lockState = menuCursorState;
				if (menuCursorVisibility == CursorVisibility.Visible)
				{
					Cursor.visible = true;
				}
				else if (menuCursorVisibility != CursorVisibility.Default)
				{
					Cursor.visible = false;
				}
				if (continueButton != null && Gamepad.current != null)
				{
					EventSystem.current.SetSelectedGameObject(null);
					EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
				}
			}
		}

		public void ClosePauseMenu()
		{
			if (isOn && allowClosing)
			{
				if (setTimeScale)
				{
					Time.timeScale = 1f;
				}
				if (panelManager != null)
				{
					panelManager.HideCurrentPanel();
				}
				StopCoroutine("DisablePauseCanvas");
				StartCoroutine("DisablePauseCanvas");
				if (gameCursorVisibility == CursorVisibility.Visible)
				{
					Cursor.visible = true;
				}
				else if (gameCursorVisibility != CursorVisibility.Default)
				{
					Cursor.visible = false;
				}
				isOn = false;
				onClose.Invoke();
				FadeOutBackground();
				Cursor.lockState = gameCursorState;
			}
		}

		public void FadeInBackground()
		{
			if (!(background == null))
			{
				background.FadeIn();
			}
		}

		public void FadeOutBackground()
		{
			if (!(background == null))
			{
				background.FadeOut();
			}
		}

		public void AllowClosing(bool value)
		{
			allowClosing = value;
		}

		private IEnumerator DisablePauseCanvas()
		{
			yield return new WaitForSecondsRealtime(disableAfter);
			pauseMenuCanvas.SetActive(value: false);
		}

		private IEnumerator InputBlockProcess()
		{
			yield return new WaitForSecondsRealtime(inputBlockDuration);
			AllowClosing(value: true);
		}
	}
}
