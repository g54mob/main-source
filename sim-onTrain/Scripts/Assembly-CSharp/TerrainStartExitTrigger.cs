using UnityEngine;

public class TerrainStartExitTrigger : MonoBehaviour
{
	public TerrainArrivedStatus terrainArrivedPos;

	[SerializeField]
	private bool isTriggered;

	private void OnTriggerEnter(Collider other)
	{
		if (!isTriggered && (other.TryGetComponent<TrainController>(out var _) || other.TryGetComponent<TSPlayerController>(out var _)))
		{
			isTriggered = true;
			switch (terrainArrivedPos)
			{
			case TerrainArrivedStatus.Start:
				TrainGameManager.Instance.trainArrivedIndex = 0;
				break;
			case TerrainArrivedStatus.Middle:
				TrainGameManager.Instance.trainArrivedIndex = 1;
				break;
			case TerrainArrivedStatus.End:
				TrainGameManager.Instance.trainArrivedIndex = 2;
				TrainGameManager.Instance.LoadNewTerrain();
				break;
			}
		}
	}
}
