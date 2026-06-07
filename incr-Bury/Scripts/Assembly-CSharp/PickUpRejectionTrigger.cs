using System.Collections.Generic;
using UnityEngine;

public class PickUpRejectionTrigger : MonoBehaviour
{
	public List<PickUpType> rejectTheseTypes;

	[Header("Rejection Force")]
	[SerializeField]
	private float rejection_Force;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp") && ShouldRejectWhatEnteredUs(other.transform.root.GetComponent<PickUppable>()))
		{
			other.transform.root.gameObject.GetComponent<Rigidbody>().AddForce(base.transform.forward * rejection_Force, ForceMode.VelocityChange);
		}
	}

	private bool ShouldRejectWhatEnteredUs(PickUppable _pickup)
	{
		if (rejectTheseTypes.Contains(_pickup.GetPickUpType()))
		{
			return true;
		}
		return false;
	}
}
