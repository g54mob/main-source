using System.Collections.Generic;
using UnityEngine;

public class SuspendPlayerCollisionUntilNoOverlap : MonoBehaviour
{
	public bool triggerOnEnable = true;

	public LayerMask scanLayer;

	private List<Collider> targetColliders = new List<Collider>();

	private Collider[] overlaps;

	private bool suspended;

	private CharacterController trackedTarget;

	private const float EXTEND_PLAYER_RADIUS_MULTI = 3.5f;

	private void Awake()
	{
		targetColliders.AddRange(GetComponentsInChildren<Collider>());
		for (int num = targetColliders.Count - 1; num >= 0; num--)
		{
			if (targetColliders[num].isTrigger)
			{
				targetColliders.RemoveAt(num);
			}
		}
	}

	private void OnEnable()
	{
		if (triggerOnEnable)
		{
			Trigger();
		}
	}

	public void Trigger()
	{
		if (!PlayerManager.Instance)
		{
			return;
		}
		suspended = true;
		PlayerMovement closestPlayer = PlayerManager.GetClosestPlayer(base.transform.position);
		if ((bool)closestPlayer)
		{
			trackedTarget = closestPlayer.GetComponent<CharacterController>();
		}
		foreach (Collider targetCollider in targetColliders)
		{
			targetCollider.isTrigger = true;
		}
	}

	private void SwitchBack()
	{
		suspended = false;
		foreach (Collider targetCollider in targetColliders)
		{
			targetCollider.isTrigger = false;
		}
	}

	private void Update()
	{
		if (!suspended)
		{
			return;
		}
		if ((bool)trackedTarget)
		{
			float num = trackedTarget.height / 2f * 3.5f;
			Vector3 point = trackedTarget.transform.position + Vector3.down * num;
			Vector3 point2 = trackedTarget.transform.position + Vector3.up * num;
			overlaps = Physics.OverlapCapsule(point, point2, trackedTarget.radius * 3.5f, scanLayer, QueryTriggerInteraction.Collide);
			bool flag = true;
			Collider[] array = overlaps;
			foreach (Collider item in array)
			{
				if (targetColliders.Contains(item))
				{
					flag = false;
				}
			}
			if (flag)
			{
				SwitchBack();
			}
		}
		else
		{
			SwitchBack();
		}
	}
}
