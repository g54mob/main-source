using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt_Trigger : MonoBehaviour
{
	[SerializeField]
	private List<Rigidbody> rbsOnBelt;

	private void FixedUpdate()
	{
		if (rbsOnBelt.Count <= 0)
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		foreach (Rigidbody item in rbsOnBelt)
		{
			if ((bool)item)
			{
				item.linearVelocity = Vector3.zero;
				zero2 = base.transform.InverseTransformPoint(item.transform.position);
				zero2.x = 0f;
				zero2 = base.transform.TransformPoint(zero2);
				zero = zero2 - item.transform.position;
				item.AddForce((base.transform.forward + zero) * GameManager.Singleton.conveyorBelt_ForcePower, ForceMode.VelocityChange);
			}
		}
	}

	private void OnTriggerEnter(Collider _other)
	{
		if (_other.gameObject.CompareTag("PickUp"))
		{
			rbsOnBelt.Add(_other.GetComponentInParent<Rigidbody>());
		}
	}

	private void OnTriggerExit(Collider _other)
	{
		if (_other.gameObject.CompareTag("PickUp"))
		{
			rbsOnBelt.Remove(_other.GetComponentInParent<Rigidbody>());
		}
	}
}
