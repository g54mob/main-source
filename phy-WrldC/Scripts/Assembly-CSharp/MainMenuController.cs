using UnityEngine;

public class MainMenuController : BaseController<MainMenuView>
{
	public MainMenuController(MainMenuView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "MainMenuView.LoadCampaignLevelEvent":
		case "MainMenuView.LoadSandboxLevelEvent":
		case "MainMenuView.LoadTutorialLevelEvent":
		case "MainMenuView.LoadAttackerLevelEvent":
		case "MainMenuView.LoadDefenderLevelEvent":
		{
			LevelModel levelToLoad = (LevelModel)data[0];
			switch (eventName)
			{
			case "MainMenuView.LoadCampaignLevelEvent":
				GameManager.Instance.LevelType = GameManager.LevelTypeState.Campaign;
				break;
			case "MainMenuView.LoadSandboxLevelEvent":
				GameManager.Instance.LevelType = GameManager.LevelTypeState.Sandbox;
				break;
			case "MainMenuView.LoadTutorialLevelEvent":
				GameManager.Instance.LevelType = GameManager.LevelTypeState.Tutorial;
				break;
			default:
				GameManager.Instance.LevelType = GameManager.LevelTypeState.User;
				break;
			}
			if (eventName == "MainMenuView.LoadDefenderLevelEvent")
			{
				GameManager.Instance.GameMode = GameManager.GameModeState.Defender;
			}
			else
			{
				GameManager.Instance.GameMode = GameManager.GameModeState.Attacker;
			}
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.LoadLevelAndChangeState(levelToLoad, StartLevelState.Instance);
			}, levelToLoad);
			break;
		}
		case "MainMenuView.OpenGroupCampaignWindowEvent":
			GameManager.Instance.SetSubState(GroupCampaignState.Instance);
			break;
		case "MainMenuView.OpenOptionsWindowEvent":
			GameManager.Instance.SetSubState(OptionsState.Instance);
			break;
		case "MainMenuView.OpenUserLoadLevelWindowEvent":
			GameManager.Instance.GUIManager.LoadLevelView.SetPanelType(LoadLevelView.PanelType.Play);
			GameManager.Instance.SetSubState(UserLoadLevelState.Instance);
			break;
		case "MainMenuView.LoadLevelEditorEvent":
			GameManager.Instance.GUIManager.LoadLevelView.SetPanelType(LoadLevelView.PanelType.New);
			GameManager.Instance.SetSubState(UserLoadLevelState.Instance);
			break;
		case "MainMenuView.BestPlayersWindowEvent":
			GameManager.Instance.SetSubState(BestUsersState.Instance);
			break;
		case "MainMenuView.OpenWorshopTrendsWindowEvent":
			view.SetWorkshopTrendsVisibility(isPanelVisible: true, isButtonVisible: false);
			GameManager.Instance.OptionsModel.IsWorkshopTrendsPanelVisible = true;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		case "MainMenuView.ExitGameEvent":
			Application.Quit();
			break;
		}
	}
}
