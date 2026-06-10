using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
	private void Start()
	{
		if (GameManager.Instance != null && GameManager.Instance.currentZone != null)
		{
			GameObject zonePrefab = GameManager.Instance.currentZone.zonePrefab;
			if (zonePrefab != null)
			{
				Object.Instantiate(zonePrefab, Vector3.zero, Quaternion.identity);
			}
			else
			{
				Debug.LogError("The selected zone does not have a prefab assigned!");
			}
		}
		else
		{
			Debug.LogError("GameManager or Current Zone not found! Did you start from the Menu Scene?");
		}
	}
}
