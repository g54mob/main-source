using UnityEngine;

public class TownheartTracker : Tracker
{
	private void Start()
	{
		Initialize(CameraController.Instance.Camera, CameraController.Instance.transform);
	}

	public override Vector3 GetTrackingPosition()
	{
		if ((bool)Construction.Townheart)
		{
			return Construction.Townheart.transform.position;
		}
		return Vector3.zero;
	}
}
