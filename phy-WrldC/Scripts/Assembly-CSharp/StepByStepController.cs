using System.Collections;

public class StepByStepController : BaseController<StepByStepView>
{
	public StepByStepController(StepByStepView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "StepByStepView.ResetEvent")
		{
			GameManager.Instance.StartCoroutine(ResetCoroutine());
		}
		IEnumerator ResetCoroutine()
		{
			if (GameManager.Instance.GetCurrentState() == ReplayState.Instance || GameManager.Instance.GetCurrentSubState() == ReplayState.Instance)
			{
				if (!ReplayState.Instance.CanExitFromState())
				{
					yield break;
				}
				yield return GameManager.Instance.StartCoroutine(ReplayState.Instance.ExitFromState());
			}
			view.ResetWindowPosition();
			view.SetStepPage(1);
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			GameManager.Instance.ResetCameraPosition();
			GameManager.Instance.QuickInventoryController.RestoreQuickInventoryToDefault();
			string id = GameManager.Instance.LevelController.model.GetId();
			CreationModel clonedCreationModel = GameManager.Instance.TutorialManager.GetClonedCreationModel(id);
			GameManager.Instance.MainCreationController.SetModel(clonedCreationModel);
			GameManager.Instance.ConstructionCommandManager.ClearAllCommands();
		}
	}
}
