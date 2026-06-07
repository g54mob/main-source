using System.Collections.Generic;
using UnityEngine;

public class NebulaBerryManager : MonoBehaviour
{
	public static NebulaBerryManager Singleton;

	[SerializeField]
	private List<NebulaBerrySpawnHandler> spawnHandlers;

	[Header("Spawning")]
	[SerializeField]
	private GameObject nebulaBerrySpawnPoint;

	[SerializeField]
	private GameObject nebulaBerryLaunchTarget;

	[SerializeField]
	private float spawnForce;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		FindNewNebulaBerrySpawnTarget();
	}

	private void Update()
	{
	}

	public void SpawnNebulaBerry(GameObject _prefab)
	{
		Berry component = Object.Instantiate(_prefab, nebulaBerrySpawnPoint.transform.position, Quaternion.identity).GetComponent<Berry>();
		component.ChangeToNebulaBerry();
		Rigidbody component2 = component.gameObject.GetComponent<Rigidbody>();
		Vector3 normalized = (nebulaBerryLaunchTarget.transform.position - component.gameObject.transform.position).normalized;
		component2.AddForce(normalized * spawnForce, ForceMode.VelocityChange);
		FindNewNebulaBerrySpawnTarget();
	}

	private void FindNewNebulaBerrySpawnTarget()
	{
		nebulaBerryLaunchTarget.transform.position = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-35f, 10f));
	}
}
