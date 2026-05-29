using System;
using UnityEngine;

public class MainMenu : BaseMenu
{
	private GameObject m_Panel;

	private GameObject m_BackButton;

	private BaseButton m_ContinueButton;

	private BaseButtonImage m_LanguageButton;

	private BaseText m_Experimental;

	private float m_ExperimentalTimer;

	protected new void Awake()
	{
		base.Awake();
	}

	protected new void Start()
	{
		base.Start();
		string[] array = new string[12]
		{
			"StartButton", "LoadButton", "ContinueButton", "RecordingsButton", "SettingsButton", "AboutButton", "DiscordButton", "WikiButton", "BadgesButton", "QuitButton",
			"LanguageButton", "ModsButton"
		};
		Action<BaseGadget>[] array2 = new Action<BaseGadget>[12]
		{
			OnNewGame, OnLoad, OnContinue, OnRecordings, OnSettings, OnAbout, OnDiscord, OnWiki, OnBadges, OnQuit,
			OnLanguageSelect, OnModsSelect
		};
		for (int i = 0; i < array.Length; i++)
		{
			BaseButton component = base.transform.Find(array[i]).GetComponent<BaseButton>();
			if (array[i] == "ContinueButton")
			{
				component.SetActive(false);
				m_ContinueButton = component;
				UpdateContinueButton();
			}
			AddAction(component, array2[i]);
		}
		BaseText component2 = base.transform.Find("Version").GetComponent<BaseText>();
		string version = SaveLoadManager.GetVersion();
		component2.SetText(version);
		m_Experimental = base.transform.Find("Experimental").GetComponent<BaseText>();
		m_Experimental.SetActive(false);
		AudioManager.Instance.StartMusic("MusicCover");
	}

	private void UpdateContinueButton()
	{
		m_ContinueButton.SetActive(false);
		m_ContinueButton.GetComponent<StandardMainMenuButtonText>().SetRollover("");
		if (SettingsManager.Instance.m_LastSave != "" && new SaveFile().Exists(SettingsManager.Instance.m_LastSave))
		{
			m_ContinueButton.SetActive(true);
			string text = m_ContinueButton.GetComponent<StandardMainMenuButtonText>().GetText();
			text = text + "\n\"" + SettingsManager.Instance.m_LastSave + "\"";
			m_ContinueButton.GetComponent<StandardMainMenuButtonText>().SetRollover(text);
		}
	}

	public void Pushed()
	{
		base.gameObject.SetActive(false);
	}

	public void Popped()
	{
		m_ExperimentalTimer = 0f;
		UpdateContinueButton();
		if (GameStateManager.Instance.m_OldState == GameStateManager.State.NewGame)
		{
			GameObject.Find("SpaceCamera").GetComponent<CameraCrossFade>().StartFade(true);
		}
		base.gameObject.SetActive(true);
	}

	public void OnNewGame(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.NewGame);
		GameOptionsManager.Instance.m_Options.NewMapSeed();
		GameStateManager.Instance.GetCurrentState().GetComponent<GameStateNewGame>().SetDataFromNew();
		GameObject.Find("SpaceCamera").GetComponent<CameraCrossFade>().StartFade(false);
		SpaceAnimation.Instance.StartRocket();
	}

	public void OnLoad(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.Load);
		GameStateManager.Instance.GetCurrentState().GetComponent<GameStateLoad>().Init(false);
	}

	public void OnContinue(BaseGadget NewGadget)
	{
		if (new SaveFile().Exists(SettingsManager.Instance.m_LastSave))
		{
			AudioManager.Instance.StartEvent("UIOptionSelected");
			SessionManager.Instance.m_LoadFileName = SettingsManager.Instance.m_LastSave;
			SessionManager.Instance.LoadLevel(true, "Main");
			GameStateManager.Instance.SetState(GameStateManager.State.SceneChange);
		}
		else
		{
			m_ContinueButton.SetActive(false);
		}
	}

	public void OnRecordings(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.Load);
		GameStateManager.Instance.GetCurrentState().GetComponent<GameStateLoad>().Init(true);
	}

	public void OnSettings(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.Settings);
	}

	public void OnAbout(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.About);
	}

	public void OnDiscord(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		Application.OpenURL("https://discordapp.com/invite/xXRfjsc");
	}

	public void OnWiki(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		Application.OpenURL("https://autonauts.gamepedia.com/Autonauts_Wiki");
	}

	public void OnBadges(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.Badges);
	}

	public void OnQuit(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.Confirm);
		GameStateManager.Instance.GetCurrentState().GetComponent<GameStateConfirm>().SetConfirm(ConfirmQuit, "ConfirmQuitMainMenu");
	}

	public void ConfirmQuit()
	{
		Application.Quit();
	}

	public void OnLanguageSelect(BaseGadget NewGadget)
	{
		GameStateManager.Instance.PushState(GameStateManager.State.LanguageSelect);
	}

	public void OnModsSelect(BaseGadget NewGadget)
	{
		GameStateManager.Instance.PushState(GameStateManager.State.ModsPanel);
	}

	protected new void Update()
	{
		base.Update();
	}
}
