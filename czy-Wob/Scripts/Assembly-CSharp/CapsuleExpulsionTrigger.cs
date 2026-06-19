using UnityEngine;

public class CapsuleExpulsionTrigger : MonoBehaviour
{
	private float expulsionForce = 300f;

	private CapsuleMachine machineRef;

	public void Initialize(CapsuleMachine newRef)
	{
		machineRef = newRef;
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.transform.root.gameObject.CompareTag("capsule"))
		{
			machineRef.OnCapsuleExpulled(c.transform.root.gameObject);
		}
	}

	private void OnTriggerStay(Collider c)
	{
		if (c.transform.root.gameObject.CompareTag("capsule"))
		{
			machineRef.OnCapsuleExpulled(c.transform.root.gameObject);
			c.transform.root.GetComponentInChildren<Rigidbody>().AddForce(-machineRef.transform.forward * expulsionForce);
		}
	}
}
