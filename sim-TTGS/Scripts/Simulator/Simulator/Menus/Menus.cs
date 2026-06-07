using System.Collections;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator.Menus
{
	public class Menus : MonoBehaviour
	{
		[SerializeField]
		private ObjectStackActivator m_menusActivator;

		private EventManager m_eventManager;

		private static Menus Instance { get; set; }

		public static bool Loaded { get; private set; }

		public static MainMenu MainMenu { get; private set; }

		public static PauseMenu PauseMenu { get; private set; }

		public static OptionsMenu OptionsMenu { get; private set; }

		public static LoadMenu LoadMenu { get; private set; }

		public static SaveMenu SaveMenu { get; private set; }

		public static Credits Credits { get; private set; }

		public static MenuConfirmationPopup ConfirmationPopup { get; private set; }

		private void Awake()
		{
			if (Instance != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			Instance = this;
			Loaded = true;
		}

		private void OnEnable()
		{
			EventManager.OnMenuEvent += OnMenuEvent;
		}

		private void OnDisable()
		{
			EventManager.OnMenuEvent -= OnMenuEvent;
		}

		private void Start()
		{
			m_eventManager = EventManager.GetInstance();
			m_eventManager.TriggerMenuEvent(EMenuEvent.MENU_REGISTRATION);
			InitStaticSystems();
			m_eventManager.TriggerMenuEvent(EMenuEvent.INITIALISATION);
			if (!World.Loaded)
			{
				ShowMainMenu();
			}
		}

		private void ShowMainMenu()
		{
			CursorManager.SetBaseState(MenuSettings.DefaultCursor);
			m_eventManager.TriggerMenuEvent(EMenuEvent.START);
			m_menusActivator.Init(MainMenu);
			m_eventManager.TriggerMenuEvent(EMenuEvent.OPEN);
			m_eventManager.TriggerMenuEvent(EMenuEvent.MAIN_MENU);
		}

		protected virtual void InitStaticSystems()
		{
		}

		private IEnumerator OnBackToMainMenu()
		{
			World.Quit();
			TransientManager<SceneManager>.Instance.UnloadScene(SceneManager.Map.PREVIEW3D);
			yield return new WaitWhileSceneLoading();
			TransientManager<SceneManager>.Instance.UnloadScene(SceneManager.Map.WORLD);
			yield return new WaitWhileSceneLoading();
			ClearMenus();
			OpenMainMenu();
			CursorManager.SetBaseState(MenuSettings.DefaultCursor);
			m_eventManager.TriggerMenuEvent(EMenuEvent.BACK_TO_MENU);
			yield return null;
			TransientManager<LoadingScreen>.Instance.Hide();
		}

		private void OnQuitGame()
		{
			Quit();
			void Quit()
			{
				World.Quit();
				m_eventManager.TriggerMenuEvent(EMenuEvent.CLOSE);
				m_eventManager.TriggerMenuEvent(EMenuEvent.PREPARE_QUIT);
				QuitStaticSystems();
				UnregisterSingletons();
				m_eventManager.TriggerMenuEvent(EMenuEvent.QUIT);
				Application.Quit();
			}
		}

		protected virtual void QuitStaticSystems()
		{
		}

		public static void RegisterSingleton(MonoBehaviour monoBehaviour)
		{
		}

		private static void UnregisterSingletons()
		{
			MainMenu = null;
			PauseMenu = null;
			OptionsMenu = null;
			LoadMenu = null;
			SaveMenu = null;
			Credits = null;
			ConfirmationPopup = null;
		}

		public static void RegisterMenu(Menu menu, out Menus menus)
		{
			menus = Instance;
			menu.WantsBack += Instance.OnWantsBack;
			if (!(menu is MainMenu mainMenu))
			{
				if (!(menu is PauseMenu pauseMenu))
				{
					if (!(menu is OptionsMenu optionsMenu))
					{
						if (!(menu is SaveMenu saveMenu))
						{
							if (!(menu is LoadMenu loadMenu))
							{
								if (!(menu is Credits credits))
								{
									if (menu is MenuConfirmationPopup confirmationPopup)
									{
										ConfirmationPopup = confirmationPopup;
									}
								}
								else
								{
									Credits = credits;
								}
							}
							else
							{
								LoadMenu = loadMenu;
							}
						}
						else
						{
							SaveMenu = saveMenu;
						}
					}
					else
					{
						OptionsMenu = optionsMenu;
					}
				}
				else
				{
					PauseMenu = pauseMenu;
				}
			}
			else
			{
				MainMenu = mainMenu;
			}
		}

		private void OnWantsBack(IActivable activable)
		{
			if (!m_menusActivator.Back() && World.Loaded)
			{
				m_eventManager.TriggerMenuEvent(EMenuEvent.CLOSE);
				World.Unpause();
			}
		}

		private void OpenMainMenu()
		{
			m_menusActivator.Init(MainMenu);
		}

		private void OpenPauseMenu()
		{
			CursorManager.SetBaseState(MenuSettings.DefaultCursor);
			m_menusActivator.Init(PauseMenu);
		}

		public void OpenLoadMenu()
		{
			Activate(LoadMenu);
		}

		public void OpenSaveMenu()
		{
			Activate(SaveMenu);
		}

		public void OpenOptionMenu()
		{
			Activate(OptionsMenu);
		}

		public void OpenCredits()
		{
			Activate(Credits);
		}

		public void OpenBugMenu()
		{
			Application.OpenURL(DiscordSettings.ServerInvitationURL);
		}

		public void Activate(IActivable activable)
		{
			m_menusActivator.Activate(activable);
		}

		private void ClearMenus()
		{
			m_menusActivator.Clear();
		}

		public void BackToMainMenu()
		{
			StartCoroutine(OnBackToMainMenu());
		}

		public void QuitGame()
		{
			OnQuitGame();
		}

		private void OnMenuEvent(EMenuEvent menuEvent)
		{
			switch (menuEvent)
			{
			case EMenuEvent.MAIN_MENU:
				OpenMainMenu();
				break;
			case EMenuEvent.PAUSE:
				OpenPauseMenu();
				break;
			case EMenuEvent.CLOSE:
				ClearMenus();
				break;
			}
		}
	}
}
