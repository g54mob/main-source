using UnityEngine;

public class Diggable : MonoBehaviour
{
	private bool hasBeenDugUp;

	public DiggableType diggableType;

	[SerializeField]
	private GameObject surfaceParticles;

	[Header("Spawn Params")]
	[SerializeField]
	private Vector3 spawnOffset;

	[Header("Void Box Spawn Physics")]
	[SerializeField]
	private float upwardSpawnForce;

	[SerializeField]
	private Vector2 xz_SpawnForceRange;

	private bool _hasAddedToDiggableMasterList;

	private void Update()
	{
		if (!_hasAddedToDiggableMasterList && (bool)GameManager.Singleton)
		{
			GameManager.Singleton.diggablesMasterList.Add(this);
			_hasAddedToDiggableMasterList = true;
		}
	}

	private void OnDestroy()
	{
		try
		{
			GameManager.Singleton.diggablesMasterList.Remove(this);
		}
		catch
		{
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!hasBeenDugUp && other.CompareTag("MilestoneActivator"))
		{
			DigUp();
		}
	}

	public void DigUp()
	{
		if (!hasBeenDugUp)
		{
			hasBeenDugUp = true;
			if (diggableType == DiggableType.VoidCubeSpawner)
			{
				Rigidbody component = Object.Instantiate(GameManager.Singleton.prefabBank.voidBox_Prefab, base.transform.position + spawnOffset, Quaternion.identity).GetComponent<Rigidbody>();
				component.AddForce(new Vector3(Random.Range(0f - xz_SpawnForceRange.x, xz_SpawnForceRange.x), upwardSpawnForce, Random.Range(0f - xz_SpawnForceRange.y, xz_SpawnForceRange.y)), ForceMode.VelocityChange);
				component.AddTorque(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
				VoidBoxSpawnManager.Singleton.SpawnedVoidBoxDiggable_OnDigUp();
			}
			Object.Destroy(base.gameObject);
		}
	}
}
