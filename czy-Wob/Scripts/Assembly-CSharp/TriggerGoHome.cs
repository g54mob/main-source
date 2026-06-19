public class TriggerGoHome : TriggerBase
{
	private string homeSceneName = "01_home";

	public override void ProcessTrigger(TriggerCallback callback)
	{
		base.ProcessTrigger(callback);
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION).TransitionToScene(homeSceneName);
	}
}
