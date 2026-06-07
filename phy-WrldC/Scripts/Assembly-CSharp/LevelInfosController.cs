public class LevelInfosController : BaseController<LevelCreationInfosView, LevelModel>
{
	public LevelInfosController(LevelCreationInfosView view, LevelModel model)
		: base(view, model, false)
	{
		LanguagesManager.Instance.OnLanguageChangedEvent += LanguageChangedHandler;
	}

	protected override void SyncViewWithModel()
	{
		var (text, name) = LevelUtil.GetLevelNames(model);
		view.SetLevelInfosValues(text + ":", name);
		if (model.LevelStatus == null)
		{
			view.SetBestTime(float.PositiveInfinity);
		}
		else if (model.IsThereCollectables && model.IsLevelCompleted)
		{
			view.SetBestTimes(model.LevelStatus.LowestTimeRecords);
		}
		else
		{
			view.SetBestTime(model.LevelStatus.LowestTimeRecords.NoneStarValue);
		}
		view.SetCheatPanelVisibilityAndReset((model.IsLevelCheatable || GameManager.Instance.OptionsModel.IsCheatsEnabled) && model.Place != LevelModel.LevelPlace.Tutorial);
		Schematic[] restrictedBlocksSchematics = GameManager.Instance.GetRestrictedBlocksSchematics(model.RestrictedBlocksEnum);
		if (restrictedBlocksSchematics != null && restrictedBlocksSchematics.Length != 0)
		{
			view.SetRestrictedBlocksPanelVisibility(isVisible: true);
			view.SetRestrictedBlocks(restrictedBlocksSchematics);
		}
		else
		{
			view.SetRestrictedBlocksPanelVisibility(isVisible: false);
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "LevelModel.NewLevelRecordsEvent"))
		{
			if (eventName == "LevelModel.BestTimeChangedEvent" && GameManager.Instance.LevelType == GameManager.LevelTypeState.Test)
			{
				view.SetBestTime(model.BestTime);
			}
		}
		else if (model.IsThereCollectables)
		{
			view.SetBestTimes(model.LevelStatus.LowestTimeRecords);
		}
		else
		{
			view.SetBestTime(model.LevelStatus.LowestTimeRecords.NoneStarValue);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LevelCreationInfosView.CheatsChangedEvent":
			GameManager.Instance.CheatModel.IsUnbreakableCreation = view.GetUnbreakebleToggleValue();
			GameManager.Instance.CheatModel.IsUnlimitedAmmo = view.GetUnlimitedAmmoToggleValue();
			break;
		case "LevelCreationInfosView.DelimitationChangedEvent":
		{
			bool flag = (bool)data[0];
			GameManager.Instance.CheatModel.IsWithoutDelimitationZone = flag;
			LevelManager.Instance.atackerZone.SetActive(!flag);
			break;
		}
		case "LevelCreationInfosView.CloseEvent":
			view.SetVisibility(isVisible: false);
			view.TopButtonsView.SetLevelCreationInfosToggleStatus(isSelected: false);
			GameManager.Instance.OptionsModel.IsLevelCreationInfosWinVisible = false;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		}
	}

	private void LanguageChangedHandler()
	{
		if (model != null)
		{
			string text = LanguagesManager.Instance.GetText("level.name." + model.Id, model.Name);
			view.SetLevelName(text);
		}
	}
}
