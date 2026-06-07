using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class TeleportArcPassThrough : MonoBehaviour
{
	public bool twoSided = true;

	[SerializeField]
	private Collider[] collidersToPassThrough;

	[NonSerialized]
	public HashSet<Collider> colliders = new HashSet<Collider>();

	private void Awake()
	{
		if (collidersToPassThrough != null)
		{
			Collider[] array = collidersToPassThrough;
			foreach (Collider item in array)
			{
				colliders.Add(item);
			}
		}
	}

	public bool ShouldIgnoreCollidersForHit(RaycastHit hit)
	{
		if (!twoSided)
		{
			return Vector3.Dot(base.transform.forward, hit.normal) > 0f;
		}
		return true;
	}

	public bool ShouldIgnoreCollidersForHit(RaycastHitDV hit)
	{
		if (!twoSided)
		{
			return Vector3.Dot(base.transform.forward, hit.normal) > 0f;
		}
		return true;
	}
}
