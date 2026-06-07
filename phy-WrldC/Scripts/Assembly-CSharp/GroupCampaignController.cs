public class GroupCampaignController : BaseController<GroupCampaignView, GroupCampaignModel>
{
	public GroupCampaignController(GroupCampaignView view, GroupCampaignModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.ClearAllSlots();
		GroupCampaignModel.LevelGroupModel[] allLevelModelGroups = model.GetAllLevelModelGroups();
		for (int i = 0; i < allLevelModelGroups.Length; i++)
		{
			LevelModel[] allLevelModels = allLevelModelGroups[i].GetAllLevelModels();
			for (int j = 0; j < allLevelModels.Length; j++)
			{
				ModelChangeHandler("GroupCampaignModel.AddLevelModelEvent", i, j, allLevelModels[j]);
			}
		}
		model.UpdateLevelGroupStatus();
		model.UpdateLevelGroupNames();
		var (levelsCompleted, levelsTotal) = model.GetLevelsCompletedAndTotal();
		var (collectablesTotal, bothPickedUp, goldPickedUp, silverPickedUp) = model.GetLevelsCollectablesCount();
		view.UpdateLevelsCountText(levelsCompleted, levelsTotal, collectablesTotal, bothPickedUp, goldPickedUp, silverPickedUp);
		view.RefreshPages();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "GroupCampaignModel.AddLevelModelEvent":
		{
			int groupIndex = (int)data[0];
			int slotIndex = (int)data[1];
			LevelModel levelModel = data[2] as LevelModel;
			view.AddLevelLoadSlot(groupIndex, slotIndex, levelModel);
			break;
		}
		case "GroupCampaignModel.NewLevelRecordsEvent":
		{
			int groupIndex = (int)data[0];
			int slotIndex = (int)data[1];
			LevelModel levelModel = data[2] as LevelModel;
			view.UpdateLevelLoadSlotInfos(groupIndex, slotIndex, levelModel);
			var (levelsCompleted, levelsTotal) = model.GetLevelsCompletedAndTotal();
			var (collectablesTotal, bothPickedUp, goldPickedUp, silverPickedUp) = model.GetLevelsCollectablesCount();
			view.UpdateLevelsCountText(levelsCompleted, levelsTotal, collectablesTotal, bothPickedUp, goldPickedUp, silverPickedUp);
			break;
		}
		case "GroupCampaignModel.SelectLevelModelEvent":
		{
			int groupIndex = (int)data[0];
			int slotIndex = (int)data[1];
			LevelModel levelModel = data[2] as LevelModel;
			view.SelectLevelSlot(groupIndex, slotIndex, levelModel);
			break;
		}
		case "GroupCampaignModel.UpdateLevelGroupStatusEvent":
		{
			int groupIndex = (int)data[0];
			int levelsToUnlockDelta = (int)data[1];
			bool isGroupCompleted = (bool)data[2];
			bool isAllBoth = (bool)data[3];
			bool isAllGold = (bool)data[4];
			bool isAllSiver = (bool)data[5];
			view.UpdateLevelGroupStatus(groupIndex, levelsToUnlockDelta, isGroupCompleted, isAllBoth, isAllGold, isAllSiver);
			break;
		}
		case "GroupCampaignModel.UpdateLevelGroupNameEvent":
		{
			int groupIndex = (int)data[0];
			string groupName = (string)data[1];
			view.UpdateLevelGroupName(groupIndex, groupName);
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "GroupCampaignView.PlayLevelEvent":
		{
			LevelModel levelToLoad = (LevelModel)data[0];
			if (levelToLoad != null)
			{
				GameManager.Instance.LevelType = GameManager.LevelTypeState.Campaign;
				GameManager.Instance.GameMode = GameManager.GameModeState.Attacker;
				GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
				{
					GameManager.Instance.LoadLevelAndChangeState(levelToLoad, StartLevelState.Instance);
				}, levelToLoad);
			}
			break;
		}
		case "GroupCampaignView.LevelLeaderboardsEvent":
		{
			LevelModel customTargetLevelModel = data[0] as LevelModel;
			LeaderboardsWindowState.Instance.CustomTargetLevelModel = customTargetLevelModel;
			GameManager.Instance.SetSubState(LeaderboardsWindowState.Instance);
			break;
		}
		case "GroupCampaignView.BackButtonEvent":
			GameManager.Instance.ExitSubState();
			break;
		}
	}
}
