using UnityEngine;

[RequireComponent(typeof(ElementVisual))]
public class SpawnBasedOnSeed : MonoBehaviour
{
	[SerializeField]
	private float probability = 0.05f;

	[SerializeField]
	private GameObject objectToSpawn;

	[SerializeField]
	private Vector3[] randomLocalPositions;

	[SerializeField]
	private Vector3 localRotation;

	private ElementVisual elementVisual;

	[SerializeField]
	private GameObject spawnedObject;

	[SerializeField]
	private float randomValue;

	[SerializeField]
	private int seed;

	public GameObject ObjectToSpawn => objectToSpawn;

	public float Probability => probability;

	public Vector3[] RandomLocalPositions => randomLocalPositions;

	public Vector3 LocalRotation => localRotation;

	private void OnEnable()
	{
		elementVisual = GetComponent<ElementVisual>();
		if (elementVisual.isSetup)
		{
			SpawnObject(elementVisual.Seed);
		}
		elementVisual.OnSetup += SpawnObject;
		elementVisual.OnLayerChanged += ChangeLayer;
		ChangeLayer(base.gameObject.layer);
	}

	private void ChangeLayer(int targetLayer)
	{
		if ((bool)spawnedObject)
		{
			spawnedObject.layer = targetLayer;
		}
	}

	private void SpawnObject(int seed)
	{
		Random.InitState(seed);
		if ((bool)spawnedObject)
		{
			Object.Destroy(spawnedObject.gameObject);
			spawnedObject = null;
		}
		this.seed = seed;
		randomValue = Random.value;
		if (randomValue <= probability)
		{
			spawnedObject = Object.Instantiate(objectToSpawn, base.transform);
			if (randomLocalPositions.Length != 0)
			{
				spawnedObject.transform.localPosition = randomLocalPositions[Random.Range(0, randomLocalPositions.Length)];
			}
			spawnedObject.transform.localRotation = Quaternion.Euler(localRotation);
		}
		Randomizer.RandomizeSeed();
	}

	private void OnDisable()
	{
		if ((bool)spawnedObject)
		{
			Object.Destroy(spawnedObject);
			spawnedObject = null;
		}
		elementVisual.OnSetup -= SpawnObject;
		elementVisual.OnLayerChanged -= ChangeLayer;
	}

	private void OnDestroy()
	{
		elementVisual.OnSetup -= SpawnObject;
		elementVisual.OnLayerChanged -= ChangeLayer;
	}
}
