using System.Collections;
using System.Linq;
using UnityEngine;

public class GameFXManager : MonoBehaviour
{
	private Transform playerControllerTransform;

	[SerializeField]
	private GameObject windPrefab;

	[SerializeField]
	private float minDelayWindSpawn;

	[SerializeField]
	private float maxDelayWindSpawn;

	[SerializeField]
	private float minMaxDistance;

	[SerializeField]
	private Vector3 lastWindPosition;

	private void Start()
	{
		lastWindPosition = Vector3.zero;
		playerControllerTransform = Object.FindObjectOfType<PlayerController>().transform;
		StartCoroutine(SpawnWindPrefab());
	}

	private IEnumerator SpawnWindPrefab()
	{
		yield return new WaitForSeconds(Random.Range(minDelayWindSpawn, maxDelayWindSpawn));
		_ = Vector3.zero;
		float num = GridController.Instance.GetAllTiles().Max((TileObject x) => x.transform.position.x);
		float num2 = GridController.Instance.GetAllTiles().Max((TileObject x) => x.transform.position.z);
		float y = 6f;
		Vector3 position = new Vector3(Random.Range(0f - num, num), y, Random.Range(0f - num2, num2));
		Object.Destroy(Object.Instantiate(windPrefab, position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y + 180f, Quaternion.identity.z)), 5f);
		lastWindPosition = position;
		StartCoroutine(SpawnWindPrefab());
	}
}
