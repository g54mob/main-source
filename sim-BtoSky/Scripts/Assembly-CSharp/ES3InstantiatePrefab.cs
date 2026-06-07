using UnityEngine;

public class ES3InstantiatePrefab : MonoBehaviour
{
	public GameObject prefab;

	public void CreateRandomPrefab()
	{
		Object.Instantiate(prefab, Random.insideUnitSphere * 5f, Random.rotation);
	}
}
