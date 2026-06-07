using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assets.Packages.SocialPlatforms;
using Assets.Scripts.Logging;
using Assets.Scripts.Menu;
using Assets.Scripts.State;
using Assets.Scripts.Tools;
using Jundroo.Services;
using Jundroo.Services.Ads;
using Jundroo.Services.Analytics;
using Jundroo.Services.Purchasing;
using ModApi;
using ModApi.Scenes.Events;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Startup
{
	public class StartupScript : MonoBehaviour
	{
		private class CommandLineArgs
		{
			public string Arg { get; set; }

			public string[] OriginalArguments { get; set; }

			public bool Uninstall { get; set; }

			public void CheckSocialPlatformLaunchParameters()
			{
				try
				{
					if (SocialExt.IsSteam)
					{
						string launchQueryParam = SocialExt.Steam.GetLaunchQueryParam("arg");
						if (!string.IsNullOrWhiteSpace(launchQueryParam))
						{
							Arg = launchQueryParam;
						}
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("An error occurred retrieving social platform launch parameters arguments.");
					Debug.LogException(exception);
				}
			}
		}

		protected virtual void Awake()
		{
			Debug.Log("StartupScript.Awake");
			Culture.Original.ToString();
			Thread.Sleep(500);
		}

		protected virtual async void Start()
		{
			try
			{
				CommandLineArgs args = GetCommandLineArgs();
				if (args.Uninstall)
				{
					StartupUtilities.Uninstall();
					Application.Quit();
					return;
				}
				LogHistory.Initialize(100, 100, StartupUtilities.GetDeviceInformation);
				MobileLogger.Initialize();
				Game.EnsureInitialized();
				Screen.sleepTimeout = -1;
				StartupUtilities.LogDeviceInformation();
				PartViewerScript.RegeneratePartIcons = true;
				try
				{
					if (Game.Instance.Device.IsWindowsBuild)
					{
						StartupUtilities.UpdateFileAssociation("simplerockets2");
						StartupUtilities.UpdateFileAssociation("sr2");
						StartupUtilities.UpdateFileAssociation("sr2-craft");
						StartupUtilities.UpdateFileAssociation("sr2-sandbox");
						StartupUtilities.UpdateFileAssociation("sr2-mod");
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("Something failed when adjusting file associations.");
					Debug.LogException(exception);
				}
				Game.Instance.Settings.NumberOfApplicationRuns++;
				Game.Instance.Settings.Save();
				ConfigureServices();
				await ServicesCommon.InitializeStartupServices(Game.Instance.Device.IsUnityEditor ? "development" : "beta");
				Game.Instance.SceneManager.SceneTransitionCompleted += async delegate(object s, SceneTransitionEventArgs e)
				{
					if (e.TransitionToScene == "Flight" || e.TransitionToScene == "Design" || e.TransitionToScene == "PlanetStudio")
					{
						await ServicesCommon.InitializeDialogBasedServicesIfNecessary();
					}
				};
				args.CheckSocialPlatformLaunchParameters();
				if (!string.IsNullOrWhiteSpace(args.Arg))
				{
					ApplicationState.ClearState();
					Game.Instance.UrlHandler.HandleUrl(args.Arg);
					return;
				}
				string text = "Menu";
				if (ApplicationState.CrashDetectedOnPreviousRun)
				{
					MenuScript.PreviousCrashDetected = true;
					Debug.Log("A crash on the previous run as been detected. The main menu will be loaded in 'safe' mode.");
				}
				else if (!string.IsNullOrWhiteSpace(ApplicationState.CurrentActivity))
				{
					if (ApplicationState.AppSuspended)
					{
						GameStateType gameStateType = ApplicationState.GameStateType;
						if (gameStateType == GameStateType.Default || gameStateType == GameStateType.Simulation)
						{
							if (ApplicationState.DesignInProgress)
							{
								text = "Design";
								Debug.Log("App suspended. Resuming in designer.");
							}
							else if (ApplicationState.FlightInProgress)
							{
								text = "Flight";
								Debug.Log("App suspended. Resuming in flight.");
							}
							if (gameStateType == GameStateType.Simulation && text != "Menu")
							{
								GameState gameState = Game.Instance.GameState;
								string gameStateTag = "Simulation.Active";
								if (Game.Instance.GameStateManager.CheckGameStateTagExists(gameState.Id, gameStateTag) && !Game.Instance.LoadGameState(gameState.Id, gameStateTag))
								{
									Debug.LogError("Failed to restore the suspended simulation game state.");
								}
							}
						}
					}
					else if (ApplicationState.FlightInProgress)
					{
						GameStateType gameStateType2 = ApplicationState.GameStateType;
						if (gameStateType2 == GameStateType.Default)
						{
							if (Game.Instance.GameStateManager.CheckGameStateTagExists(Game.Instance.GameState.Id, "PreFlight"))
							{
								MenuScript.DisplayInProgressFlightDialog = true;
								Debug.Log("Previous flight detected. Prompting user to keep or undo.");
							}
							else
							{
								Debug.Log("Previous flight detected but there is no pre-flight state to restore.");
							}
						}
						else
						{
							Debug.Log($"Previous flight detected with game state type '{gameStateType2}'. The game state's default active tag will be loaded instead.");
						}
					}
				}
				ApplicationState.ClearState();
				Game.Instance.SceneManager.LoadScene(text);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		private static void ConfigureServices()
		{
			ServicesCommon.ConfigurePurchasingService(new PurchasingService.InitializationParameters
			{
				PurchasingManager = (PurchasingManagerBase)Game.Instance.InAppPurchases
			});
			ServicesCommon.ConfigureAdsService(new AdsService.InitializationParameters
			{
				ForceTestAdsOnly = Device.IsUnityEditor,
				UnderAgeOfConsent = false,
				ResetConsentInformation = false,
				LoggingFlags = AdLoggingFlags.Default,
				DebugGeography = DebugGeography.Disabled,
				TestDeviceIds = new List<string>()
			});
			ServicesCommon.ConfigureAnalyticsService(new AnalyticsService.InitializationParameters
			{
				GetConsentStateDelegate = () => Game.Instance.Settings.Game.User.AnalyticsConsent,
				ShowConsentDialogDelegate = Game.Instance.Settings.Game.User.ShowAnalyticsConsentDialog
			});
		}

		private static CommandLineArgs GetCommandLineArgs()
		{
			CommandLineArgs commandLineArgs = new CommandLineArgs();
			try
			{
				string[] source = (commandLineArgs.OriginalArguments = Environment.GetCommandLineArgs() ?? new string[0]);
				commandLineArgs.Uninstall = source.Contains("-uninstall");
				commandLineArgs.Arg = source.Skip(1).FirstOrDefault((string x) => !x.StartsWith("-"));
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred retrieving command line arguments.");
				Debug.LogException(exception);
			}
			return commandLineArgs;
		}

		private void InitializeSingleInstanceServer(string commandLineArgument)
		{
			try
			{
				(UnityEngine.Object.Instantiate(Resources.Load("SingleInstanceServer")) as GameObject).GetComponent<SingleInstanceServerScript>().Initialize(commandLineArgument);
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Error creating SingleInstanceServer.\n{0}", ex.Message);
				Game.Instance.UrlHandler.HandleUrl(commandLineArgument);
			}
		}
	}
}
