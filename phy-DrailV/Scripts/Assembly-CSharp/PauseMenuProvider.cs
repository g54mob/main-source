using DV.Common;
using DV.UI;
using DV.Utils;

public class PauseMenuProvider : APauseMenuProvider
{
	public ASettingsProvider settingsProvider;

	public AUserProfileProvider userProfileProvider;

	public ABugReportDataProvider bugReportDataProvider;

	public ATutorialsMenuProvider tutorialsMenuProvider;

	public override ASettingsProvider SettingsProvider => settingsProvider;

	public override AUserProfileProvider UserProfileProvider => userProfileProvider;

	public override ABugReportDataProvider BugReportDataProvider => bugReportDataProvider;

	public override ATutorialsMenuProvider TutorialsMenuProvider => tutorialsMenuProvider;

	public override IGameSession Session
	{
		get
		{
			if (DevSceneUtil.IsGameScene())
			{
				return userProfileProvider.CurrentSession;
			}
			return null;
		}
	}

	public override bool HasUnsavedProgress
	{
		get
		{
			if (!SingletonBehaviour<SaveGameManager>.Instance)
			{
				return false;
			}
			return SingletonBehaviour<SaveGameManager>.Instance.HasUnsavedProgress;
		}
	}

	public override bool IsVR => VRManager.IsVREnabled();
}
