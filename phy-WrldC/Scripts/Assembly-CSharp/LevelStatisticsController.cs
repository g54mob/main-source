using UnityEngine;

public class LevelStatisticsController : BaseController<LevelStatisticsView, LevelModel>
{
	private GameManager gameManager;

	public LevelStatisticsController(LevelStatisticsView view, LevelModel model)
		: base(view, model, false)
	{
		gameManager = GameManager.Instance;
	}

	protected override void SyncViewWithModel()
	{
		var (text, levelName) = LevelUtil.GetLevelNames(model);
		view.SetLevelInfosValues(text + ":", levelName, model.IsLevelCompleted);
		view.SetCollectablesInfos(model.IsThereCollectables, model.LevelStatus);
		if (model.IsLevelCompleted && model.LevelStatus != null)
		{
			if (model.Place == LevelModel.LevelPlace.Campaign || model.Place == LevelModel.LevelPlace.Sandbox)
			{
				LoadBestCreationSlots(model.LevelStatus, LevelStatisticsView.StarFilter.None);
				view.SetPanelType(LevelStatisticsView.PanelType.Creations);
				if (model.IsThereCollectables)
				{
					view.SetStarRowInterativity(model.LevelStatus.AllBothCollectables, model.LevelStatus.AllGoldCollectables, model.LevelStatus.AllSilverCollectables);
				}
				view.SetStarRowVisibility(model.IsThereCollectables);
			}
			else
			{
				view.SetOnlyTextInfos(Util.TimeParser(model.LevelStatus.LowestTimeRecords.NoneStarValue), Mathf.RoundToInt(model.LevelStatus.LowestBlocksRecords.NoneStarValue).ToString(), model.LevelStatus.LowestCostRecords.NoneStarValue.ToString(), model.LevelStatus.LowestWeightRecords.NoneStarValue.ToString("0.##"));
				view.SetPanelType(LevelStatisticsView.PanelType.OnlyText);
			}
		}
		else
		{
			view.SetPanelType(LevelStatisticsView.PanelType.NotCompleted);
		}
		bool leaderboardsTabVisibility = SteamManager.Initialized && (model.Place == LevelModel.LevelPlace.Campaign || (model.Place == LevelModel.LevelPlace.Sandbox && model.IsSandboxWithGoal));
		view.SetLeaderboardsTabVisibility(leaderboardsTabVisibility);
		view.SetRecordsTabOn();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LevelStatisticsView.StarFilterChangedEvent":
		{
			LevelStatisticsView.StarFilter starFilter = (LevelStatisticsView.StarFilter)data[0];
			LoadBestCreationSlots(model.LevelStatus, starFilter);
			break;
		}
		case "LevelStatisticsView.LoadButtonEvent":
		{
			CreationModel creationModel = data[0] as CreationModel;
			gameManager.ConstructionCommandManager.ClearAllCommands();
			gameManager.MainCreationController.SetModel(CreationCloner.Clone(creationModel));
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			break;
		}
		case "LevelStatisticsView.CloseButtonEvent":
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			break;
		}
	}

	private void LoadBestCreationSlots(LevelStatus levelStatus, LevelStatisticsView.StarFilter starFilter)
	{
		string id = levelStatus.LowestTimeRecords.NoneCreationId;
		string id2 = levelStatus.LowestBlocksRecords.NoneCreationId;
		string id3 = levelStatus.LowestCostRecords.NoneCreationId;
		string id4 = levelStatus.LowestWeightRecords.NoneCreationId;
		float seconds = levelStatus.LowestTimeRecords.NoneStarValue;
		float f = levelStatus.LowestBlocksRecords.NoneStarValue;
		float num = levelStatus.LowestCostRecords.NoneStarValue;
		float num2 = levelStatus.LowestWeightRecords.NoneStarValue;
		switch (starFilter)
		{
		case LevelStatisticsView.StarFilter.Both:
			id = levelStatus.LowestTimeRecords.BothCreationId;
			id2 = levelStatus.LowestBlocksRecords.BothCreationId;
			id3 = levelStatus.LowestCostRecords.BothCreationId;
			id4 = levelStatus.LowestWeightRecords.BothCreationId;
			seconds = levelStatus.LowestTimeRecords.BothStarValue;
			f = levelStatus.LowestBlocksRecords.BothStarValue;
			num = levelStatus.LowestCostRecords.BothStarValue;
			num2 = levelStatus.LowestWeightRecords.BothStarValue;
			break;
		case LevelStatisticsView.StarFilter.Gold:
			id = levelStatus.LowestTimeRecords.GoldCreationId;
			id2 = levelStatus.LowestBlocksRecords.GoldCreationId;
			id3 = levelStatus.LowestCostRecords.GoldCreationId;
			id4 = levelStatus.LowestWeightRecords.GoldCreationId;
			seconds = levelStatus.LowestTimeRecords.GoldStarValue;
			f = levelStatus.LowestBlocksRecords.GoldStarValue;
			num = levelStatus.LowestCostRecords.GoldStarValue;
			num2 = levelStatus.LowestWeightRecords.GoldStarValue;
			break;
		case LevelStatisticsView.StarFilter.Silver:
			id = levelStatus.LowestTimeRecords.SilverCreationId;
			id2 = levelStatus.LowestBlocksRecords.SilverCreationId;
			id3 = levelStatus.LowestCostRecords.SilverCreationId;
			id4 = levelStatus.LowestWeightRecords.SilverCreationId;
			seconds = levelStatus.LowestTimeRecords.SilverStarValue;
			f = levelStatus.LowestBlocksRecords.SilverStarValue;
			num = levelStatus.LowestCostRecords.SilverStarValue;
			num2 = levelStatus.LowestWeightRecords.SilverStarValue;
			break;
		}
		CreationModel creationModel = gameManager.CreationCollectionsManager.BestCreationModelCollection.GetCreationModel(id);
		view.SetTimeSlotInfos(Util.TimeParser(seconds), creationModel);
		CreationModel creationModel2 = gameManager.CreationCollectionsManager.BestCreationModelCollection.GetCreationModel(id2);
		view.SetBlocksSlotInfos(Mathf.RoundToInt(f).ToString(), creationModel2);
		CreationModel creationModel3 = gameManager.CreationCollectionsManager.BestCreationModelCollection.GetCreationModel(id3);
		view.SetCostSlotInfos(num.ToString(), creationModel3);
		CreationModel creationModel4 = gameManager.CreationCollectionsManager.BestCreationModelCollection.GetCreationModel(id4);
		view.SetWeightSlotInfos(num2.ToString("0.##"), creationModel4);
	}
}
