using System.Collections.Generic;

public class LinearCampaignModel : BaseModel
{
	private List<CampaignLevelModel> campaignlevelModelsList;

	public LinearCampaignModel()
	{
		campaignlevelModelsList = new List<CampaignLevelModel>();
	}

	public void AddLevelModel(LevelModel levelModel, int index)
	{
		CampaignLevelModel campaignLevelModel = new CampaignLevelModel(levelModel, index.ToString());
		if (campaignlevelModelsList.Count == 0 || levelModel.IsLevelCompleted || (campaignlevelModelsList.Count > 0 && campaignlevelModelsList[campaignlevelModelsList.Count - 1].LevelModel.IsLevelCompleted))
		{
			campaignLevelModel.IsLevelPlayable = true;
		}
		levelModel.NotifyChangeEvent += LevelModelChangeHandler;
		campaignlevelModelsList.Add(campaignLevelModel);
	}

	public LevelModel GetNextLevelModel(LevelModel currentLevelModel)
	{
		int num = 1 + campaignlevelModelsList.FindIndex((CampaignLevelModel campaignLevelModel) => campaignLevelModel.LevelModel == currentLevelModel);
		if (num >= campaignlevelModelsList.Count)
		{
			return null;
		}
		return campaignlevelModelsList[num].LevelModel;
	}

	public ICollection<CampaignLevelModel> GetAllCampaignLevelModels()
	{
		return campaignlevelModelsList;
	}

	private void LevelModelChangeHandler(string eventName, object[] data)
	{
		if (eventName == "LevelModel.BestTimeChangedEvent")
		{
			LevelModel levelModel = data[0] as LevelModel;
			int num = 1 + campaignlevelModelsList.FindIndex((CampaignLevelModel campaignLevelModel) => campaignLevelModel.LevelModel == levelModel);
			if (num < campaignlevelModelsList.Count)
			{
				campaignlevelModelsList[num].IsLevelPlayable = true;
			}
		}
	}
}
