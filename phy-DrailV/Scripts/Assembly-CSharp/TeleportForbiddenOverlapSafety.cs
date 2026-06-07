using System;
using UnityEngine;

public class TeleportForbiddenOverlapSafety : MonoBehaviour
{
	public const string NO_TELEPORT_TAG = "NO_TELEPORT";

	private const float ILLEGAL_OVERLAP_RADIUS = 0.01f;

	[NonSerialized]
	public bool isInsideForbiddenCollider;

	private Collider[] illegalOverlaps = new Collider[8];

	private int illegalLayers;

	private int overlapCount;

	private void Start()
	{
		if (GetComponent<Rigidbody>() == null)
		{
			Debug.LogWarning("TeleportForbiddenOverlapSafety was added to object that doesn't have a Rigidbody ('" + base.gameObject.name + "'), detection won't work", this);
		}
		illegalLayers = LayerMask.GetMask("Default", "Train_Walkable");
	}

	public bool CheckOverlap(Vector3 origin)
	{
		int num = Physics.OverlapSphereNonAlloc(origin, 0.01f, illegalOverlaps, illegalLayers, QueryTriggerInteraction.Collide);
		for (int i = 0; i < num; i++)
		{
			if (illegalOverlaps[i].CompareTag("NO_TELEPORT"))
			{
				return true;
			}
		}
		return false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("NO_TELEPORT"))
		{
			overlapCount++;
			isInsideForbiddenCollider = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("NO_TELEPORT"))
		{
			overlapCount--;
			if (overlapCount == 0)
			{
				isInsideForbiddenCollider = false;
			}
		}
	}
}
