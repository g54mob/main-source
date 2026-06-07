using UnityEngine;

public class InMatchResignHelper : MonoBehaviour
{
	public UIFrame classicRetryPopUp;

	public UIFrame etResignPopUp;

	public UIFrame etBackToMapPopUp;

	public void TryResign()
	{
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			UIFrameManager.instance.ChangeActiveFrame(etResignPopUp);
		}
		else
		{
			UIFrameManager.instance.ChangeActiveFrame(classicRetryPopUp);
		}
	}

	public void ApplyResign()
	{
		UIFrameManager.instance.CloseAllFrames();
		LocalGamestate.Instance.SetState(LocalGamestate.State.AfterMatchDefeat);
	}

	public void TryBackToMap()
	{
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial && EternalTrialsRunManager.CurrentRun.inNight)
		{
			UIFrameManager.instance.ChangeActiveFrame(etBackToMapPopUp);
		}
		else
		{
			SceneTransitionManager.instance.TransitionFromLevelToLevelSelect();
		}
	}

	public void AppliedBackToMap()
	{
		SceneTransitionManager.instance.TransitionFromLevelToLevelSelect();
	}
}
