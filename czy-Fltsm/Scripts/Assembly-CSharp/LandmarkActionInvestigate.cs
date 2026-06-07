using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Actions/Investigate")]
public class LandmarkActionInvestigate : LandmarkAction
{
	[SerializeField]
	private LandmarkActionInvestigateUI _uiPrefab;

	private Agent _assignedAgent;

	public int Progress { get; private set; }

	public bool MovingToLandmark { get; private set; }

	public override GameEventType InteractableEventType => GameEventType.None;

	protected override void OnActivated()
	{
		throw new NotImplementedException();
	}

	protected override void OnDeactivated()
	{
		throw new NotImplementedException();
	}

	public override Project ReturnProject()
	{
		return new Project(GameManager.Settings.ProjectSettings.InvestigatePOIProperties, _landmarkBehaviour.Landmark.ProjectTarget.gameObject);
	}

	public override void InitializeUI(LandmarkPanel landmarkPanel)
	{
		throw new NotImplementedException();
	}
}
