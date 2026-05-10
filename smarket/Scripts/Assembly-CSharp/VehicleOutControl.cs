using System.Collections.Generic;
using UnityEngine;

public class VehicleOutControl : MonoBehaviour
{
	[SerializeField]
	private Transform m_RayPoint;

	[SerializeField]
	private List<SphereCollider> spawnTrigger;

	private const float DISTANCE = 5f;

	private LayerMask layerMask;

	private void Start()
	{
	}

	public bool IsVehicleResetAvailable()
	{
		return false;
	}

	public Vector3 TryPlayerSpawn()
	{
		return default(Vector3);
	}
}
