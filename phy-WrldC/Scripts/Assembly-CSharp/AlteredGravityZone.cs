using System.Collections.Generic;
using UnityEngine;

public class AlteredGravityZone : MonoBehaviour
{
	[SerializeField]
	private Vector3 gravity = Vector3.zero;

	private List<Rigidbody> checkedRigidbodies;

	private void Awake()
	{
		checkedRigidbodies = new List<Rigidbody>();
		TriggerEvents[] componentsInChildren = GetComponentsInChildren<TriggerEvents>(includeInactive: true);
		if (componentsInChildren != null)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnTriggerStayEvent += TriggerStayHandler;
			}
		}
	}

	private void FixedUpdate()
	{
		checkedRigidbodies.Clear();
	}

	private void OnTriggerStay(Collider other)
	{
		AddGravityForce(other);
	}

	private void TriggerStayHandler(Collider other)
	{
		AddGravityForce(other);
	}

	private void AddGravityForce(Collider collider)
	{
		if (!(collider.attachedRigidbody == null) && !checkedRigidbodies.Contains(collider.attachedRigidbody))
		{
			collider.attachedRigidbody.AddForce(gravity, ForceMode.Acceleration);
			checkedRigidbodies.Add(collider.attachedRigidbody);
		}
	}
}
