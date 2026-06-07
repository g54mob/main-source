using System.Collections.Generic;
using UnityEngine;

public class PoolVacuumTrigger : MonoBehaviour
{
	[SerializeField]
	private List<Rigidbody> berryRBsInPool = new List<Rigidbody>();

	[SerializeField]
	private float vacuumPower;

	[Header("Cultist Rejection")]
	[SerializeField]
	private Vector3 cultistEjection_AddDir;

	[SerializeField]
	private float cultistEjection_AwayBoost;

	[SerializeField]
	private float cultistEjection_Force;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (berryRBsInPool.Count <= 0)
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		for (int num = berryRBsInPool.Count - 1; num >= 0; num--)
		{
			if ((bool)berryRBsInPool[num])
			{
				zero = (base.transform.position - berryRBsInPool[num].transform.position).normalized;
				berryRBsInPool[num].AddForce(zero * vacuumPower, ForceMode.Force);
			}
			else
			{
				berryRBsInPool.RemoveAt(num);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			PickUppable component = other.gameObject.transform.root.GetComponent<PickUppable>();
			if (component.GetItemIdentity() == ItemIdentity.Cultist || component.GetItemIdentity() == ItemIdentity.BlenderBot)
			{
				Vector3 normalized = (other.gameObject.transform.position - base.transform.position).normalized;
				Rigidbody component2 = other.gameObject.transform.root.GetComponent<Rigidbody>();
				component2.linearVelocity = Vector3.zero;
				component2.AddForce(normalized * cultistEjection_AwayBoost + cultistEjection_AddDir * cultistEjection_Force, ForceMode.VelocityChange);
			}
		}
		else if (other.gameObject.CompareTag("SuckUppable"))
		{
			Vector3 normalized2 = (other.gameObject.transform.position - base.transform.position).normalized;
			Rigidbody component3 = other.gameObject.transform.root.GetComponent<Rigidbody>();
			component3.linearVelocity = Vector3.zero;
			component3.AddForce(normalized2 * cultistEjection_AwayBoost + cultistEjection_AddDir * cultistEjection_Force, ForceMode.VelocityChange);
		}
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
