using UnityEngine;

public class TrackWithObstacle : Track
{
	[SerializeField]
	private TrackObstacle regularObstacle;

	[SerializeField]
	private TrackObstacle trapObstacle;

	private TrackObstacle currentObstacle;

	public GameObject SetupObstacle(bool isTrap)
	{
		if (isTrap)
		{
			currentObstacle = trapObstacle;
			trapObstacle.gameObject.SetActive(value: true);
			regularObstacle.gameObject.SetActive(value: false);
		}
		else
		{
			currentObstacle = regularObstacle;
			trapObstacle.gameObject.SetActive(value: false);
			regularObstacle.gameObject.SetActive(value: true);
		}
		return currentObstacle.gameObject;
	}
}
