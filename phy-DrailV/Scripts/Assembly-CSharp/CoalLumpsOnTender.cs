using UnityEngine;

public class CoalLumpsOnTender : MonoBehaviour
{
	public GameObject[] coalLumps;

	private void OnDestroy()
	{
		GameObject[] array = coalLumps;
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				RespawnOnDrop component = gameObject.GetComponent<RespawnOnDrop>();
				if (component != null)
				{
					component.respawnOnDropThroughFloor = false;
					component.ignoreDistanceFromSpawnPosition = true;
				}
			}
		}
	}
}
