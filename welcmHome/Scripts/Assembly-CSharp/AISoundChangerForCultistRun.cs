using UnityEngine;

public class AISoundChangerForCultistRun : MonoBehaviour
{
	public AISoundEnum TerrainOnEnter;

	public AISoundEnum TerrainOnLeave;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<AISoundForCultistRun>(out var component))
		{
			component.terrain = TerrainOnEnter;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.TryGetComponent<AISoundForCultistRun>(out var component))
		{
			component.terrain = TerrainOnLeave;
		}
	}
}
