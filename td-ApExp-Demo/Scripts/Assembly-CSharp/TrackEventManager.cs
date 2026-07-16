using UnityEngine;

public class TrackEventManager : MonoBehaviour
{
	[Header("Resource Prefabs")]
	[SerializeField]
	private GameObject ammoPrefab;

	[SerializeField]
	private GameObject scrapPrefab;

	[SerializeField]
	private GameObject boomPrefab;

	private GameObject resourceInstance1;

	private GameObject resourceInstance2;

	public void HandleResourceEvent(int trackIndex, GameObject trackGO)
	{
		TrackEventResource currentResourceEvent = LevelManager.Instance.CurrentResourceEvent;
		if (currentResourceEvent != null)
		{
			float num = currentResourceEvent.ScheduledDistance + LevelManager.Instance.CurrentLevel.GlobalStartDistance;
			float num2 = (float)trackIndex * 4.8f;
			if (!(Mathf.Abs(num - num2) >= 0.01f))
			{
				SpawnResources(currentResourceEvent, trackGO);
			}
		}
	}

	private void SpawnResources(TrackEventResource resource, GameObject trackGO)
	{
		Vector3 position = new Vector3(trackGO.transform.position.x - 2.4f, resource.SpawnPos.y);
		GameObject gameObject = null;
		if (resource.ResourceType == ResourceTypes.Ammo)
		{
			gameObject = ammoPrefab;
		}
		else if (resource.ResourceType == ResourceTypes.Scrap)
		{
			gameObject = scrapPrefab;
		}
		else if (resource.ResourceType == ResourceTypes.Rerolls)
		{
			gameObject = boomPrefab;
		}
		if (gameObject == null)
		{
			return;
		}
		resourceInstance1 = Object.Instantiate(gameObject, position, Quaternion.identity, trackGO.transform);
		if (!resource.DoubleSpawn)
		{
			return;
		}
		position = new Vector3(trackGO.transform.position.x - 2.4f, 0f - resource.SpawnPos.y);
		GameObject gameObject2 = null;
		if (resource.ResourceType2 == ResourceTypes.Ammo)
		{
			gameObject2 = ammoPrefab;
		}
		else if (resource.ResourceType2 == ResourceTypes.Scrap)
		{
			gameObject2 = scrapPrefab;
		}
		else if (resource.ResourceType2 == ResourceTypes.Rerolls)
		{
			gameObject2 = boomPrefab;
		}
		if (!(gameObject2 == null))
		{
			resourceInstance2 = Object.Instantiate(gameObject2, position, Quaternion.identity, trackGO.transform);
			if (TrackManager.Instance.destroyNextResourceBox)
			{
				Object.Destroy(resourceInstance1.gameObject);
				Object.Destroy(resourceInstance2.gameObject);
				TrackManager.Instance.destroyNextResourceBox = false;
			}
		}
	}

	public void DestroyResources()
	{
		if ((bool)resourceInstance1)
		{
			Object.Destroy(resourceInstance1);
		}
		if ((bool)resourceInstance2)
		{
			Object.Destroy(resourceInstance2);
		}
	}
}
