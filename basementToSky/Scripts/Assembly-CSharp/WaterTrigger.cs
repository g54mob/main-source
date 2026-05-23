using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Buoyancy componentInParent = other.GetComponentInParent<Buoyancy>();
		if ((bool)componentInParent)
		{
			componentInParent.inWater = true;
			componentInParent.SetCenterOfMass();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Buoyancy componentInParent = other.GetComponentInParent<Buoyancy>();
		if ((bool)componentInParent)
		{
			componentInParent.inWater = false;
			componentInParent.rb.ResetCenterOfMass();
		}
	}
}
