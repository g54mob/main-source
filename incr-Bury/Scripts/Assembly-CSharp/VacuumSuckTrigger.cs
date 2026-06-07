using System.Collections.Generic;
using UnityEngine;

public class VacuumSuckTrigger : MonoBehaviour
{
	public List<Rigidbody> rbsInSuckZone = new List<Rigidbody>();

	public List<Rigidbody> rbsInSuckZone_NonBerries = new List<Rigidbody>();

	private PickUppable enteredPickUpScript;

	private void OnTriggerEnter(Collider _other)
	{
		if (!_other.transform.root.gameObject.CompareTag("PickUp"))
		{
			return;
		}
		try
		{
			enteredPickUpScript = _other.transform.root.gameObject.GetComponent<PickUppable>();
			if ((bool)enteredPickUpScript && enteredPickUpScript.GetPickUpType() == PickUpType.Berry && enteredPickUpScript.GetItemIdentity() != ItemIdentity.Cultist)
			{
				Rigidbody component = enteredPickUpScript.gameObject.GetComponent<Rigidbody>();
				if (!rbsInSuckZone.Contains(component))
				{
					rbsInSuckZone.Add(component);
					enteredPickUpScript.SetDrag_Held();
				}
			}
		}
		catch
		{
			Debug.Log("Vacuum failed to get references to required components on object, ignoring!");
		}
	}
}
