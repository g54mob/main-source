using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class ApplicationController : MonoSingleton<ApplicationController>
{
	[SerializeField]
	private LoadingScreen loadingScreen;

	[SerializeField]
	private CorruptProfilePopup corruptProfilePopup;

	[SerializeField]
	private SimulationExceptionPopup exceptionPopup;

	[SerializeField]
	private string mainMenuScene = "MainMenu";

	[SerializeField]
	private string gameScene = "GameScene";

	[SerializeField]
	private string wishlistUrl = "https://store.steampowered.com/developer/bitemegames";

	[SerializeField]
	private string discordUrl = "https://discord.gg/gxETxWaK";

	[SerializeField]
	private string discussionsUrl = "https://steamcommunity.com/app/3907940/discussions/";

	public static LoadingScreen LoadingScreen => MonoSingleton<ApplicationController>.Instance.loadingScreen;

	private async void Awake()
	{
		ReactiveSettings.Initialize(this);
		AuctionItemsReference.Initialize().Forget();
		CatalogProvider.Initialize().Forget();
		await LocalizationSettings.InitializationOperation.ToUniTask();
		Debug.Log(Version.VERSION);
		loadingScreen.LoadScene(MonoSingleton<ApplicationController>.Instance.mainMenuScene, instant: true);
	}

	private void Update()
	{
		if (InputListener.AltF4)
		{
			Application.Quit();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		CatalogProvider.Dispose();
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		HandleAudioFocus(hasFocus);
		if (hasFocus)
		{
			Input.ResetInputAxes();
			InputSystem.ResetHaptics();
			InputSystem.Update();
			Canvas.ForceUpdateCanvases();
			EventSystem.current?.UpdateModules();
		}
	}

	private bool WantsToQuit()
	{
		if (InputListener.Alt)
		{
			return InputListener.AltF4;
		}
		return true;
	}

	private void OnApplicationQuit()
	{
		if (!Database.Disposed)
		{
			if (InputListener.AltF4 && Database.State.Gnorman.Gullibleness == Gullibleness.Listen)
			{
				Database.State.Gnorman.Gullibleness = Gullibleness.Pressed;
			}
			SaveSystem.SaveProfile(Database.Profile, DatabaseSaveDtoMapper.SaveMetaState(), DatabaseSaveDtoMapper.SaveGameState(), DatabaseSaveDtoMapper.SaveGlobalState());
		}
	}

	private void HandleAudioFocus(bool hasFocus)
	{
		if (hasFocus)
		{
			AudioListener.volume = 1f;
		}
		else if (ReactiveSettings.MuteAudioOnFocusLoss.Value)
		{
			AudioListener.volume = 0f;
		}
	}

	public static void LoadMainMenu()
	{
		MonoSingleton<ApplicationController>.Instance.loadingScreen.LoadScene(MonoSingleton<ApplicationController>.Instance.mainMenuScene);
	}

	public static void LoadGame()
	{
		MonoSingleton<ApplicationController>.Instance.loadingScreen.LoadScene(MonoSingleton<ApplicationController>.Instance.gameScene);
	}

	public static void OpenStorePage()
	{
		if (SteamManager.Initialized)
		{
			SteamManager.Overlay.OpenStore(3907940u);
		}
		else
		{
			Application.OpenURL(MonoSingleton<ApplicationController>.Instance.wishlistUrl);
		}
	}

	public static void OpenDiscord()
	{
		Application.OpenURL(MonoSingleton<ApplicationController>.Instance.discordUrl);
	}

	public static void OpenDiscussions()
	{
		if (SteamManager.Initialized)
		{
			SteamManager.Overlay.OpenWebpage(MonoSingleton<ApplicationController>.Instance.discussionsUrl);
		}
		else
		{
			Application.OpenURL(MonoSingleton<ApplicationController>.Instance.discussionsUrl);
		}
	}

	public static void CorruptedProfile(Exception e)
	{
		MonoSingleton<ApplicationController>.Instance.corruptProfilePopup.ShowContentWithData(e);
	}

	public static void SimulationException(SimulationException e)
	{
		MonoSingleton<ApplicationController>.Instance.exceptionPopup.ShowContentWithData(e);
	}

	public static void Quit()
	{
		Application.Quit();
	}
}
