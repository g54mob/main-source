using System;
using PathCreation;
using UnityEngine;

public class Track : MonoBehaviour
{
	public TrackTypes trackType;

	public PathCreator pathStraight;

	public PathCreator pathOther;

	public TerrainObstacleCointainer ObstacleCointainer;

	public static event Action OnObstacleDisabled;

	public event Action OnTrackSet;

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
		if (trackType == TrackTypes.DRODR || trackType == TrackTypes.DLODL)
		{
			Track.OnObstacleDisabled?.Invoke();
			TrackEventSwitch.IsTurnNorth = false;
			TrackEventSwitch.IsTurnSouth = false;
			TrackEventSwitch.IsTurnSignalActivated = false;
		}
		GetComponentInChildren<TerrainObstacleCointainer>()?.DisableAllObstacles();
	}

	public void SetObstacleContainer(GameObject newObstacleContainer)
	{
		if (ObstacleCointainer != null)
		{
			UnityEngine.Object.Destroy(ObstacleCointainer.gameObject);
		}
		if (trackType != TrackTypes.Hub && trackType != TrackTypes.Yard && trackType != TrackTypes.YardBefore && trackType != TrackTypes.YardAfter)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(newObstacleContainer, base.transform);
			ObstacleCointainer = gameObject.GetComponent<TerrainObstacleCointainer>();
		}
	}

	public void TrackSet()
	{
		this.OnTrackSet?.Invoke();
	}
}
