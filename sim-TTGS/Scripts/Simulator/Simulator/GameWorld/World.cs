using System.Collections;
using Simulator.Menus;
using Simulator.Preview3D;
using Tabletop;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class World : MonoBehaviour
	{
		protected EventManager m_eventManager;

		protected static World Instance { get; set; }

		public static bool Loaded { get; protected set; }

		public static bool Playing { get; protected set; }

		public static PlayerController PlayerController { get; protected set; }

		public static PlayerCharacter PlayerCharacter { get; protected set; }

		public static PlayerStart PlayerStart { get; protected set; }

		public static GameState GameState { get; protected set; }

		public static TimeController TimeController { get; protected set; }

		public static DeliverySystem DeliverySystem { get; protected set; }

		public static MarketStore MarketStore { get; protected set; }

		public static HUDPopup HUDPopup { get; protected set; }

		public static AINavigationManager AINavigation { get; protected set; }

		public static ClientManager ClientManager { get; protected set; }

		public static Shop Shop { get; protected set; }

		public static ShopSign ShopSign { get; protected set; }

		public static ShopBuilding ShopBuilding { get; protected set; }

		public static DirtManager DirtManager { get; protected set; }

		public static BillsManager BillsManager { get; protected set; }

		public static ProductFactory ProductFactory { get; protected set; }

		public static ScoreManager ScoreManager { get; protected set; }

		public static DayScoreTracker DayScoreTracker { get; protected set; }

		public static GameScoreTracker GameScoreTracker { get; protected set; }

		protected virtual void Awake()
		{
			if (Instance != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			Instance = this;
			Loaded = true;
		}

		protected virtual void Start()
		{
			StartCoroutine(InitializeWorld());
		}

		protected virtual void OnPauseWorld()
		{
			Playing = false;
			Time.timeScale = 0f;
			m_eventManager.TriggerWorldEvent(EWorldEvent.PAUSE);
			m_eventManager.TriggerMenuEvent(EMenuEvent.OPEN);
			m_eventManager.TriggerMenuEvent(EMenuEvent.PAUSE);
		}

		protected virtual void OnUnpauseWorld()
		{
			Playing = true;
			Time.timeScale = 1f;
			m_eventManager.TriggerWorldEvent(EWorldEvent.UNPAUSE);
		}

		protected virtual IEnumerator InitializeWorld()
		{
			m_eventManager = EventManager.GetInstance();
			yield return CloseOrLoadMenus();
			yield return LoadPreview3DIfNecessary();
			m_eventManager.TriggerWorldEvent(EWorldEvent.WORLD_REGISTRATION);
			SaveManager.LoadSelectedSave();
			LoadStaticSystems();
			m_eventManager.TriggerWorldEvent(EWorldEvent.LOADING_PHASE1);
			m_eventManager.TriggerWorldEvent(EWorldEvent.LOADING_PHASE2);
			m_eventManager.TriggerWorldEvent(EWorldEvent.INITIALISATION);
			DayScoreTracker = CreateDayScoreTracker();
			GameScoreTracker = CreateGameScoreTracker();
			m_eventManager.TriggerWorldEvent(EWorldEvent.START);
			Playing = true;
			Time.timeScale = 1f;
			StartDayIfNewSave();
			GameAnalytics.NewDesignEvent("id_analytics_newgame", 1f);
			yield return new WaitForSeconds(1f);
			HideLoadingScreenIfDisplayed();
		}

		protected virtual IEnumerator CloseOrLoadMenus()
		{
			if (Simulator.Menus.Menus.Loaded)
			{
				m_eventManager.TriggerMenuEvent(EMenuEvent.CLOSE);
				yield return null;
			}
			else
			{
				TransientManager<SceneManager>.Instance.LoadScene(SceneManager.Map.MENUS);
				yield return new WaitWhileSceneLoading();
			}
		}

		protected virtual IEnumerator LoadPreview3DIfNecessary()
		{
			if (!Preview3DManager.Loaded && NeedsPreview3D())
			{
				TransientManager<SceneManager>.Instance.LoadScene(SceneManager.Map.PREVIEW3D);
				yield return new WaitWhileSceneLoading();
			}
		}

		protected virtual bool NeedsPreview3D()
		{
			return false;
		}

		protected virtual void HideLoadingScreenIfDisplayed()
		{
			if (LoadingScreen.IsDisplayed)
			{
				TransientManager<LoadingScreen>.Instance.Hide();
			}
		}

		protected virtual void StartDayIfNewSave()
		{
			if (SaveManager.CurrentSave.newSave)
			{
				SaveManager.CurrentSave.newSave = false;
				m_eventManager.TriggerGameEvent(EGameEvent.DAY_START);
			}
		}

		protected virtual void OnQuitWorld()
		{
			Playing = false;
			m_eventManager.TriggerWorldEvent(EWorldEvent.PREPARE_QUIT);
			UnregisterSingletons();
			m_eventManager.TriggerWorldEvent(EWorldEvent.QUIT);
			ClearStaticSystems();
			m_eventManager.ClearGameEvents();
			m_eventManager.ClearWorldEvents();
			Loaded = false;
		}

		protected virtual void ClearStaticSystems()
		{
			PriceManager.Clear();
			Tutorial.Clear();
		}

		public static void Save()
		{
			if (Loaded)
			{
				Instance.OnSave();
			}
		}

		protected virtual void OnSave()
		{
			m_eventManager.TriggerWorldEvent(EWorldEvent.SAVE);
			SaveStaticSystems();
		}

		protected virtual void LoadStaticSystems()
		{
			PriceManager.Load();
			ShopExtensionSystem.Load();
			Tutorial.Load();
			TooltipManager.Init();
			ProfanityManager.Init();
		}

		protected virtual void SaveStaticSystems()
		{
			ShopExtensionSystem.Save();
			PriceManager.Save();
			DayScoreTracker.Save();
			GameScoreTracker.Save();
			Tutorial.Save();
		}

		protected virtual void SendStaticAnalyticsSystems()
		{
			ShopExtensionSystem.SendAnalytics();
			DayScoreTracker.SendAnalytics();
		}

		protected virtual void RegisterSingleton(MonoBehaviour monoBehaviour)
		{
			if (!(monoBehaviour is PlayerController playerController))
			{
				if (!(monoBehaviour is PlayerCharacter playerCharacter))
				{
					if (!(monoBehaviour is PlayerStart playerStart))
					{
						if (!(monoBehaviour is GameState gameState))
						{
							if (!(monoBehaviour is TimeController timeController))
							{
								if (!(monoBehaviour is DeliverySystem deliverySystem))
								{
									if (!(monoBehaviour is MarketStore marketStore))
									{
										if (!(monoBehaviour is HUDPopup hUDPopup))
										{
											if (!(monoBehaviour is AINavigationManager aINavigation))
											{
												if (!(monoBehaviour is ClientManager clientManager))
												{
													if (!(monoBehaviour is Shop shop))
													{
														if (!(monoBehaviour is ShopSign shopSign))
														{
															if (!(monoBehaviour is ShopBuilding shopBuilding))
															{
																if (!(monoBehaviour is BillsManager billsManager))
																{
																	if (!(monoBehaviour is DirtManager dirtManager))
																	{
																		if (!(monoBehaviour is ProductFactory productFactory))
																		{
																			if (monoBehaviour is ScoreManager scoreManager)
																			{
																				ScoreManager = scoreManager;
																			}
																		}
																		else
																		{
																			ProductFactory = productFactory;
																		}
																	}
																	else
																	{
																		DirtManager = dirtManager;
																	}
																}
																else
																{
																	BillsManager = billsManager;
																}
															}
															else
															{
																ShopBuilding = shopBuilding;
															}
														}
														else
														{
															ShopSign = shopSign;
														}
													}
													else
													{
														Shop = shop;
													}
												}
												else
												{
													ClientManager = clientManager;
												}
											}
											else
											{
												AINavigation = aINavigation;
											}
										}
										else
										{
											HUDPopup = hUDPopup;
										}
									}
									else
									{
										MarketStore = marketStore;
									}
								}
								else
								{
									DeliverySystem = deliverySystem;
								}
							}
							else
							{
								TimeController = timeController;
							}
						}
						else
						{
							GameState = gameState;
						}
					}
					else
					{
						PlayerStart = playerStart;
					}
				}
				else
				{
					PlayerCharacter = playerCharacter;
				}
			}
			else
			{
				PlayerController = playerController;
			}
		}

		public static void RegisterSingletonStatic(MonoBehaviour monoBehaviour)
		{
			Instance.RegisterSingleton(monoBehaviour);
		}

		protected virtual void UnregisterSingletons()
		{
			PlayerController = null;
			PlayerCharacter = null;
			PlayerStart = null;
			GameState = null;
			TimeController = null;
			DeliverySystem = null;
			MarketStore = null;
			HUDPopup = null;
			AINavigation = null;
			ClientManager = null;
			Shop = null;
			ShopBuilding = null;
			BillsManager = null;
			ProductFactory = null;
			DirtManager = null;
			ScoreManager = null;
			DayScoreTracker.Unregister();
			DayScoreTracker = null;
			GameScoreTracker.Unregister();
			GameScoreTracker = null;
		}

		public static void Pause()
		{
			if (Instance != null)
			{
				Instance.OnPauseWorld();
			}
		}

		public static void Unpause()
		{
			if (Instance != null)
			{
				Instance.OnUnpauseWorld();
			}
		}

		public static void Quit()
		{
			if (Instance != null)
			{
				Instance.OnQuitWorld();
			}
		}

		public static void SetShopOpen(bool open)
		{
			if (open)
			{
				Instance.m_eventManager.TriggerGameEvent(EGameEvent.OPEN_SHOP);
			}
			else
			{
				Instance.m_eventManager.TriggerGameEvent(EGameEvent.CLOSE_SHOP);
			}
		}

		public static void Evening()
		{
			Instance.m_eventManager.TriggerGameEvent(EGameEvent.EVENING);
		}

		public static void Night()
		{
			Instance.m_eventManager.TriggerGameEvent(EGameEvent.NIGHT);
		}

		public static bool CanEndDay()
		{
			if (HasExecuted(EGameEvent.NIGHT))
			{
				return Shop.ClientCount == 0;
			}
			return false;
		}

		public static void DayEnd()
		{
			Instance.m_eventManager.TriggerGameEvent(EGameEvent.DAY_END);
			HUDPopup.Open(EHUDPopupModuleType.DAY_END);
		}

		public static void TriggerAnalyticsEvent()
		{
			Instance.m_eventManager.TriggerGameEvent(EGameEvent.ANALYTICS);
			Instance.SendStaticAnalyticsSystems();
		}

		public static void NextDay()
		{
			Instance.StartCoroutine(Instance.TransitionToNextDay());
		}

		protected virtual IEnumerator TransitionToNextDay()
		{
			TransientManager<LoadingScreen>.Instance.Show();
			yield return new WaitForSeconds(0.25f);
			m_eventManager.ClearGameEvents();
			Instance.m_eventManager.TriggerGameEvent(EGameEvent.DAY_CLEANUP);
			yield return new WaitForSeconds(0.25f);
			DayScoreTracker.Init();
			Instance.m_eventManager.TriggerGameEvent(EGameEvent.DAY_START);
			yield return new WaitForSeconds(1f);
			TransientManager<LoadingScreen>.Instance.Hide();
		}

		public static bool HasExecuted(EWorldEvent worldEvent)
		{
			return Instance.m_eventManager.Contains(worldEvent);
		}

		public static bool HasExecuted(EGameEvent gameEvent)
		{
			return Instance.m_eventManager.Contains(gameEvent);
		}

		protected virtual DayScoreTracker CreateDayScoreTracker()
		{
			return new DayScoreTracker();
		}

		protected virtual GameScoreTracker CreateGameScoreTracker()
		{
			return new GameScoreTracker();
		}
	}
}
