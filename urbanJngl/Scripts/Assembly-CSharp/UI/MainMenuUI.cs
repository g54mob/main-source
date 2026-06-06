using System;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
	public class MainMenuUI : MonoBehaviour
	{
		public class OnResumeButtonEventArgs : EventArgs
		{
			public bool toggleGameMenu;
		}

		[SerializeField]
		private Button resumeButton;

		[SerializeField]
		private Button quitButton;

		[SerializeField]
		private Button wishlistButton;

		[SerializeField]
		private Button creativeModeButton;

		[SerializeField]
		private Button storyModeButton;

		[SerializeField]
		private Button newGameButton;

		[SerializeField]
		private Button restartLevelButton;

		[SerializeField]
		private Button settingsButton;

		[SerializeField]
		private Button closeMainMenuButton;

		[SerializeField]
		private Button creditsButton;

		[SerializeField]
		private RectTransform infoCreativeMode;

		[SerializeField]
		private GameObject firstLaunchBlocker;

		[SerializeField]
		private CutsceneUI cutscene;

		[SerializeField]
		private TextMeshProUGUI version;

		public bool InnerWindowOpen;

		private bool isActive;

		private bool showMenu;

		private ISaveLoadService saveLoadService;

		private IPersistentProgressService progressService;

		private Loader loader;

		private PlayerInputActions playerInputActions;

		private Button[] menuButtons;

		private int currentButtonIndex;

		private Tween infoAnimation;

		private bool doubleClickProtection;

		private string additionalVersion = ".2";

		public static MainMenuUI Instance { get; private set; }

		public event EventHandler<OnResumeButtonEventArgs> OnResumeButton;

		public event EventHandler OnQuitButton;

		public event EventHandler OnNewGameButton;

		public event EventHandler OnRestartLevelButton;

		public event EventHandler OnSettingsButton;

		public event EventHandler OnWishlistButton;

		public event EventHandler OnCreativeModeButton;

		public event EventHandler OnCreditsButton;

		private void Awake()
		{
			Instance = this;
			saveLoadService = AllServices.Container.Single<ISaveLoadService>();
			progressService = AllServices.Container.Single<IPersistentProgressService>();
			loader = AllServices.Container.Single<Loader>();
			playerInputActions = new PlayerInputActions();
			playerInputActions.MainMenu.Enable();
			version.text = "Demo ver 1." + progressService.Progress.version + additionalVersion;
		}

		private void OnEnable()
		{
			playerInputActions.MainMenu.Enable();
		}

		private void OnDisable()
		{
			playerInputActions.MainMenu.Disable();
		}

		private void Start()
		{
			resumeButton.onClick.AddListener(Hide);
			restartLevelButton.onClick.AddListener(StartLevelOver);
			quitButton.onClick.AddListener(Quit);
			playerInputActions.MainMenu.MoveDown.performed += MoveDownButton;
			playerInputActions.MainMenu.MoveUp.performed += MoveUpButton;
			playerInputActions.MainMenu.Submit.performed += SubmitButton;
			playerInputActions.MainMenu.Settings.performed += SettingsButton;
			playerInputActions.MainMenu.ExitGame.performed += ExitGameButton;
			playerInputActions.MainMenu.CloseWindow.performed += CloseWindowButton;
			closeMainMenuButton.onClick.AddListener(CloseMainMenu);
			if (progressService.Progress.IsFirstLaunch)
			{
				restartLevelButton.GetComponent<HoverColorUI>().active = false;
				resumeButton.GetComponent<HoverColorUI>().active = false;
				newGameButton.onClick.AddListener(SetNewGameStarted);
				closeMainMenuButton.gameObject.SetActive(value: false);
			}
			else
			{
				newGameButton.onClick.AddListener(StartNewGame);
				InputManager.Instance.OnEscape += InputManager_OnEscape;
			}
			wishlistButton.onClick.AddListener(delegate
			{
				if (!InnerWindowOpen)
				{
					ToggleMainMenu(value: false);
					this.OnWishlistButton?.Invoke(this, EventArgs.Empty);
				}
			});
			creditsButton.onClick.AddListener(delegate
			{
				if (!InnerWindowOpen)
				{
					ToggleMainMenu(value: false);
					this.OnCreditsButton?.Invoke(this, EventArgs.Empty);
				}
			});
			creativeModeButton.onClick.AddListener(delegate
			{
				if (!InnerWindowOpen)
				{
					ToggleMainMenu(value: false);
					progressService.Progress.showNewCreativeModeLevel = false;
					infoCreativeMode.gameObject.SetActive(progressService.Progress.showNewCreativeModeLevel);
					this.OnCreativeModeButton?.Invoke(this, EventArgs.Empty);
				}
			});
			if (progressService.Progress.CreativeMode)
			{
				storyModeButton.onClick.AddListener(StoryModeButton);
				restartLevelButton.gameObject.SetActive(value: false);
				menuButtons = new Button[5] { resumeButton, newGameButton, creativeModeButton, storyModeButton, wishlistButton };
			}
			else
			{
				storyModeButton.gameObject.SetActive(value: false);
				menuButtons = new Button[5] { resumeButton, newGameButton, restartLevelButton, creativeModeButton, wishlistButton };
			}
			settingsButton.onClick.AddListener(delegate
			{
				ToggleMainMenu(value: false);
				this.OnSettingsButton?.Invoke(this, EventArgs.Empty);
			});
			if (progressService.Progress.OpenedLevels.Count == 0)
			{
				creativeModeButton.GetComponent<HoverColorUI>().active = false;
			}
			Button[] array = menuButtons;
			foreach (Button button in array)
			{
				HoverColorUI component = button.GetComponent<HoverColorUI>();
				if (component != null)
				{
					component.StartHover();
					if (!component.active)
					{
						button.interactable = false;
					}
				}
			}
			firstLaunchBlocker.SetActive(progressService.Progress.IsFirstLaunch);
			showMenu = AllServices.Container.Single<Loader>().showMenu;
			if (showMenu)
			{
				InnerWindowOpen = false;
				ToggleMainMenu(value: true);
				CheckNewCreativeModeLevel();
				base.gameObject.SetActive(value: true);
				UpdateButtonSelection();
				AllServices.Container.Single<Loader>().showMenu = false;
			}
			else
			{
				Hide();
			}
		}

		public void OnButtonPoint(int index)
		{
			if (!InnerWindowOpen)
			{
				currentButtonIndex = index;
			}
		}

		private void SettingsButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				settingsButton.onClick.Invoke();
			}
		}

		private void ExitGameButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				quitButton.onClick.Invoke();
			}
		}

		private void NewGameButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				newGameButton.onClick.Invoke();
			}
		}

		private void SubmitButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				menuButtons[currentButtonIndex].onClick.Invoke();
			}
		}

		private void MoveUpButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				currentButtonIndex = (currentButtonIndex - 1 + menuButtons.Length) % menuButtons.Length;
				UpdateButtonSelection();
			}
		}

		private void MoveDownButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				currentButtonIndex = (currentButtonIndex + 1 + menuButtons.Length) % menuButtons.Length;
				UpdateButtonSelection();
			}
		}

		private void CloseWindowButton(InputAction.CallbackContext obj)
		{
			if (!InnerWindowOpen)
			{
				Hide();
			}
		}

		private void UpdateButtonSelection()
		{
			EventSystem.current.SetSelectedGameObject(menuButtons[currentButtonIndex].gameObject);
			EventTrigger component = menuButtons[currentButtonIndex].GetComponent<EventTrigger>();
			if (component == null)
			{
				return;
			}
			PointerEventData eventData = new PointerEventData(EventSystem.current);
			ExecuteEvents.Execute(component.gameObject, eventData, ExecuteEvents.pointerEnterHandler);
			for (int i = 0; i < menuButtons.Length; i++)
			{
				if (i != currentButtonIndex)
				{
					EventTrigger component2 = menuButtons[i].GetComponent<EventTrigger>();
					if (component2 != null)
					{
						ExecuteEvents.Execute(component2.gameObject, eventData, ExecuteEvents.pointerExitHandler);
					}
				}
			}
		}

		private void OnDestroy()
		{
			InputManager.Instance.OnEscape -= InputManager_OnEscape;
			resumeButton.onClick.RemoveAllListeners();
			newGameButton.onClick.RemoveAllListeners();
			restartLevelButton.onClick.RemoveAllListeners();
			quitButton.onClick.RemoveAllListeners();
			wishlistButton.onClick.RemoveAllListeners();
			settingsButton.onClick.RemoveAllListeners();
			closeMainMenuButton.onClick.RemoveAllListeners();
			creditsButton.onClick.RemoveAllListeners();
			playerInputActions.MainMenu.MoveDown.performed -= MoveDownButton;
			playerInputActions.MainMenu.MoveUp.performed -= MoveUpButton;
			playerInputActions.MainMenu.Submit.performed -= SubmitButton;
			playerInputActions.MainMenu.Settings.performed -= SettingsButton;
			playerInputActions.MainMenu.ExitGame.performed -= ExitGameButton;
			playerInputActions.MainMenu.CloseWindow.performed -= CloseWindowButton;
			infoAnimation.Kill();
		}

		public bool IsActive()
		{
			return isActive;
		}

		public void Hide()
		{
			if (!InnerWindowOpen)
			{
				currentButtonIndex = 0;
				ToggleMainMenu(value: false);
				if (progressService.Progress.IsFirstLaunch)
				{
					progressService.Progress.IsFirstLaunch = false;
					firstLaunchBlocker.SetActive(value: false);
					newGameButton.onClick.RemoveAllListeners();
					newGameButton.onClick.AddListener(StartNewGame);
					cutscene.Show();
				}
				this.OnResumeButton?.Invoke(this, new OnResumeButtonEventArgs
				{
					toggleGameMenu = true
				});
				base.gameObject.SetActive(value: false);
			}
		}

		public void Show()
		{
			InnerWindowOpen = false;
			ToggleMainMenu(value: true);
			this.OnResumeButton?.Invoke(this, new OnResumeButtonEventArgs
			{
				toggleGameMenu = false
			});
			CheckNewCreativeModeLevel();
			base.gameObject.SetActive(value: true);
			UpdateButtonSelection();
		}

		private void CheckNewCreativeModeLevel()
		{
			infoCreativeMode.gameObject.SetActive(progressService.Progress.showNewCreativeModeLevel);
			infoAnimation = infoCreativeMode.DOMoveX(infoCreativeMode.position.x + 10f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
				.Play();
		}

		private void CloseMainMenu()
		{
			if (!GameMenuUI.Instance.IsAnyOverlayWindowActive())
			{
				if (isActive)
				{
					Hide();
				}
				else
				{
					Show();
				}
			}
		}

		private void InputManager_OnEscape(object sender, EventArgs e)
		{
			CloseMainMenu();
		}

		private void Quit()
		{
			ToggleMainMenu(value: false);
			saveLoadService.SaveProgress();
			this.OnQuitButton?.Invoke(this, EventArgs.Empty);
		}

		private void StartNewGame()
		{
			ToggleMainMenu(value: false);
			this.OnNewGameButton?.Invoke(this, EventArgs.Empty);
		}

		private void StartLevelOver()
		{
			ToggleMainMenu(value: false);
			this.OnRestartLevelButton?.Invoke(this, EventArgs.Empty);
		}

		public void SetNewGameStarted()
		{
			if (!doubleClickProtection)
			{
				progressService.Progress.IsFirstLaunch = false;
				doubleClickProtection = true;
				loader.StartNewGame();
			}
		}

		private void StoryModeButton()
		{
			if (!InnerWindowOpen)
			{
				loader.LoadStoryModeLevel();
			}
		}

		public void CreativeModeButton(int levelNumber)
		{
			loader.LoadCreativeModeLevel(levelNumber);
		}

		public void ToggleMainMenu(bool value)
		{
			isActive = value;
		}
	}
}
