using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Actions/Scout")]
public class LandmarkActionScout : LandmarkAction
{
	public override GameEventType InteractableEventType => GameEventType.None;

	protected override void OnCompleted()
	{
		_landmarkBehaviour.SetScouted();
		LandmarkNotificationEvent.Update(_landmarkBehaviour, this);
	}

	public override Project ReturnProject()
	{
		return new Project(GameManager.Settings.ProjectSettings.ScoutLandmark, _landmarkBehaviour.Landmark.ProjectTarget.gameObject);
	}

	public override void InitializeUI(LandmarkPanel landmarkPanel)
	{
		landmarkPanel.ReturnLandmarkActionUI<LandmarkActionScoutUI>().Initialize(this);
	}
}
