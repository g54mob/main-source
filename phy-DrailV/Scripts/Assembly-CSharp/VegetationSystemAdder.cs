using UnityEngine;

public class VegetationSystemAdder : MonoBehaviour
{
	public GameObject vegetationSystemPrefab;

	private GameObject instance;

	private void OnEnable()
	{
		Debug.LogError("DOING NOTHING, VegetationSystemAdder.OnEnable code commented out since VS Pro Beta doesn't have these classes");
	}

	private void OnDisable()
	{
		if ((bool)instance)
		{
			Object.Destroy(instance);
		}
		instance = null;
	}
}
