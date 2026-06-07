public class UserProfileModel : BaseModel
{
	public GenericCollection<LevelStatus> CampaignLevelStatusList;

	public GenericCollection<LevelStatus> UserLevelStatusList;

	public GenericCollection<LevelStatus> WorkshopLevelStatusList;

	public GenericCollection<LevelStatus> SandboxLevelStatusList;

	public GenericCollection<LevelStatus> TutorialLevelStatusList;

	public UserProfileModel()
	{
		CampaignLevelStatusList = new GenericCollection<LevelStatus>();
		UserLevelStatusList = new GenericCollection<LevelStatus>();
		WorkshopLevelStatusList = new GenericCollection<LevelStatus>();
		SandboxLevelStatusList = new GenericCollection<LevelStatus>();
		TutorialLevelStatusList = new GenericCollection<LevelStatus>();
	}
}
