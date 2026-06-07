using System.Collections;
using UnityEngine;

public class LevelCompletedController : BaseController<LevelCompletedView, LevelModel>
{
	private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

	private bool isScoresCompletedUploaded;

	public LevelCompletedController(LevelCompletedView view, LevelModel model)
		: base(view, model, false)
	{
		isScoresCompletedUploaded = true;
		SteamLeaderboardsManager.Instance.OnNewScoreFailedUploadEvent += NewScoreFailedUploadHandler;
	}

	private void NewScoreFailedUploadHandler()
	{
		string text = LanguagesManager.Instance.GetText("label.text.levelend.leaderboards.uploadfalied");
		view.SetLeaderboardsText(text);
	}

	protected override void SyncViewWithModel()
	{
		LevelModel levelModel = (model.IsSandboxWithGoal ? null : ((model.Place != LevelModel.LevelPlace.Tutorial) ? GameManager.Instance.GroupCampaignModel.GetNextLevelModel(model.Id) : GameManager.Instance.TutorialCampaignModel.GetNextLevelModel(model)));
		switch (model.LevelOverStatusEnum)
		{
		case LevelModel.LevelOverStatus.Successful:
		case LevelModel.LevelOverStatus.SuccessfulWithCheat:
		case LevelModel.LevelOverStatus.SuccessfulWithMod:
		{
			(string groupName, string levelName) levelNames = LevelUtil.GetLevelNames(model);
			string item = levelNames.groupName;
			string item2 = levelNames.levelName;
			int levelsCompletedCount = -1;
			string groupNameJustUnlocked = null;
			bool flag = model.LevelOverStatusEnum == LevelModel.LevelOverStatus.Successful;
			bool cheatEnabledTextVisibility = model.LevelOverStatusEnum == LevelModel.LevelOverStatus.SuccessfulWithCheat;
			bool contentModifiedTextVisibility = model.LevelOverStatusEnum == LevelModel.LevelOverStatus.SuccessfulWithMod;
			if (model.Place == LevelModel.LevelPlace.Campaign && flag)
			{
				levelsCompletedCount = GameManager.Instance.GroupCampaignModel.GetLevelCompletedCountFromGroup(model);
				if (model.IsFirstTimeCompleted)
				{
					groupNameJustUnlocked = GameManager.Instance.GroupCampaignModel.GetGroupNameJustUnlocked();
				}
			}
			view.SetLevelInfos(item, item2, levelsCompletedCount, groupNameJustUnlocked);
			if (model.IsThereCollectables)
			{
				view.SetTimes(model.CurrentTime, model.LevelStatus?.LowestTimeRecords, flag);
			}
			else
			{
				view.SetTimes(model.CurrentTime, model.BestTime, flag);
			}
			view.ShowLevelCompleted(levelModel != null);
			view.SetCheatEnabledTextVisibility(cheatEnabledTextVisibility);
			view.SetContentModifiedTextVisibility(contentModifiedTextVisibility);
			view.SetCollectablesStars(model.IsPickedUpAllGoldCollectables, model.IsPickedUpAllSilverCollectables);
			view.SetCollectablesStarsTextVisibility(model.IsThereCollectables);
			view.SetCollectablesUnlockedTextVisibility(model.IsThereCollectables && model.IsFirstTimeCompleted);
			if (model.Id == "tutorial_4")
			{
				view.ShowFinishButton();
			}
			if (SteamManager.Initialized && flag && (model.Place == LevelModel.LevelPlace.Campaign || (model.Place == LevelModel.LevelPlace.Sandbox && model.IsSandboxWithGoal)))
			{
				view.SetLeaderboardsButtonVisibility(isVisible: true);
				if (isScoresCompletedUploaded)
				{
					view.StartCoroutine(UploadScores());
				}
				else
				{
					view.StartCoroutine(WatingLastScoreUploading());
				}
			}
			else
			{
				view.SetLeaderboardsButtonVisibility(isVisible: false);
				view.SetLeaderboardsTextVisibility(isVisible: false);
			}
			break;
		}
		case LevelModel.LevelOverStatus.Failed:
		{
			bool leaderboardsButtonVisibility = SteamManager.Initialized && (model.Place == LevelModel.LevelPlace.Campaign || (model.Place == LevelModel.LevelPlace.Sandbox && model.IsSandboxWithGoal));
			view.SetLeaderboardsButtonVisibility(leaderboardsButtonVisibility);
			view.ShowLevelFailed(levelModel != null);
			break;
		}
		case LevelModel.LevelOverStatus.BrainBlockDestroyed:
		{
			bool leaderboardsButtonVisibility = SteamManager.Initialized && (model.Place == LevelModel.LevelPlace.Campaign || (model.Place == LevelModel.LevelPlace.Sandbox && model.IsSandboxWithGoal));
			view.SetLeaderboardsButtonVisibility(leaderboardsButtonVisibility);
			view.ShowBrainBlockDestroyed(levelModel != null);
			break;
		}
		}
		if (model.Place == LevelModel.LevelPlace.Test)
		{
			view.ShowEditorButton();
		}
		IEnumerator WatingLastScoreUploading()
		{
			while (!isScoresCompletedUploaded)
			{
				yield return waitForEndOfFrame;
			}
			view.StartCoroutine(UploadScores());
		}
	}

	private IEnumerator UploadScores()
	{
		isScoresCompletedUploaded = false;
		view.SetLeaderboardsButtonInteractive(isInteractable: false);
		view.SetLeaderboardsTextVisibility(isVisible: true);
		string text = LanguagesManager.Instance.GetText("label.text.levelend.leaderboards.uploading");
		view.SetLeaderboardsText(text);
		view.SetLoadingIconsVisibility(isVisible: true);
		string levelId = model.Id;
		int time = Mathf.RoundToInt(model.CurrentTime * 1000f);
		int blocks = GameManager.Instance.MainCreationController.model.BlockModelCount;
		int cost = Mathf.RoundToInt(GameManager.Instance.MainCreationController.model.TotalCost());
		int weight = Mathf.RoundToInt(GameManager.Instance.MainCreationController.model.TotalWeight() * 100f);
		LeaderboardDifficult leaderboardDifficult = SteamLeaderboardsManager.Instance.GetLeaderboardDifficult(model.IsPickedUpAllGoldCollectables, model.IsPickedUpAllSilverCollectables);
		int realDifficult = (int)leaderboardDifficult;
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Time, LeaderboardDifficult.AnyStar, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Blocks, LeaderboardDifficult.AnyStar, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Cost, LeaderboardDifficult.AnyStar, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Weight, LeaderboardDifficult.AnyStar, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Time, leaderboardDifficult, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Blocks, leaderboardDifficult, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Cost, leaderboardDifficult, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		SteamLeaderboardsManager.Instance.UploadScore(levelId, LeaderboardType.Weight, leaderboardDifficult, time, blocks, cost, weight, realDifficult);
		while (!SteamLeaderboardsManager.Instance.IsUploadFinished)
		{
			yield return waitForEndOfFrame;
		}
		view.SetLeaderboardsButtonInteractive(isInteractable: true);
		string text2 = LanguagesManager.Instance.GetText("label.text.levelend.leaderboards.uploaded");
		view.SetLeaderboardsText(text2);
		view.SetLoadingIconsVisibility(isVisible: false);
		isScoresCompletedUploaded = true;
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LevelCompletedView.RetryButtonEvent":
			GameManager.Instance.ResetLevel();
			break;
		case "LevelCompletedView.MenuButtonEvent":
		case "LevelCompletedView.FinishButtonEvent":
			if (model.Place != LevelModel.LevelPlace.Test)
			{
				GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
				{
					GameManager.Instance.CameraManager.RestoresMainCamera();
					GameManager.Instance.ClearAllCreations();
					GameManager.Instance.UnloadCurrentLevel();
					GameManager.Instance.ChangeState(MenuState.Instance);
				});
			}
			else
			{
				GUIManager.Instance.MessageBoxController.SetModel(MessageBoxModelCollection.ReturnToMainMenuFromLevelTest);
				GameManager.Instance.SetSubState(MessageBoxState.Instance);
			}
			break;
		case "LevelCompletedView.BuildButtonEvent":
			GameManager.Instance.RestoresCreationsAndLevel();
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			break;
		case "LevelCompletedView.ReplayButtonEvent":
			GameManager.Instance.SetSubState(ReplayState.Instance);
			break;
		case "LevelCompletedView.LeaderboardsButtonEvent":
			GameManager.Instance.SetSubState(LeaderboardsWindowState.Instance);
			break;
		case "LevelCompletedView.NextButtonEvent":
		{
			LevelModel nextLevelModel = null;
			if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Campaign)
			{
				nextLevelModel = GameManager.Instance.GroupCampaignModel.GetNextLevelModel(model.Id);
			}
			else if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Tutorial)
			{
				nextLevelModel = GameManager.Instance.TutorialCampaignModel.GetNextLevelModel(model);
			}
			if (nextLevelModel != null)
			{
				GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
				{
					GameManager.Instance.CameraManager.SaveMainCameraStatus(GameManager.Instance.MainCreationController.model);
					GameManager.Instance.CameraManager.RestoresMainCamera();
					GameManager.Instance.ClearAllCreations();
					GameManager.Instance.UnloadCurrentLevel();
					GameManager.Instance.LoadLevelAndChangeState(nextLevelModel, StartLevelState.Instance);
				}, nextLevelModel);
			}
			break;
		}
		case "LevelCompletedView.EditorButtonEvent":
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.ClearAllCreations();
				GameManager.Instance.UnloadCurrentLevel();
				GameManager.Instance.LoadLevelEditorAndChangeState(LevelEditorState.Instance);
			});
			break;
		}
	}
}
