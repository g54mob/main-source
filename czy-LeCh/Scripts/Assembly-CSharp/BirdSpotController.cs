using UnityEngine;

public class BirdSpotController : MonoBehaviour
{
	[SerializeField]
	private GameObject birdPrefab;

	private float currentTime;

	private float timeTillNextSpawn;

	[SerializeField]
	private int minTimeNextSpawn;

	[SerializeField]
	private int maxTimeNextSpawn;

	private void Start()
	{
		timeTillNextSpawn = Random.Range(minTimeNextSpawn, maxTimeNextSpawn);
	}

	private void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime >= timeTillNextSpawn)
		{
			currentTime = 0f;
			timeTillNextSpawn = Random.Range(minTimeNextSpawn, maxTimeNextSpawn);
			Object.Instantiate(birdPrefab);
		}
	}
}
