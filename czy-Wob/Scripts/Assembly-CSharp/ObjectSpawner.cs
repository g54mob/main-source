using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	public GameObject objectToSpawn;

	private void Start()
	{
		Object.Instantiate(objectToSpawn, base.transform.position, base.transform.rotation);
		Object.Destroy(base.gameObject);
	}
}
