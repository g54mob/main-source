using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VehicleStopTrigger : MonoBehaviour
{
	[Header("Layer Filter")]
	public LayerMask vehicleLayer;

	private void OnTriggerEnter(Collider other)
	{
		if (((1 << other.gameObject.layer) & (int)vehicleLayer) != 0)
		{
			SCC_Network componentInParent = other.GetComponentInParent<SCC_Network>();
			if (!(componentInParent == null) && componentInParent.isOwned && componentInParent.ShouldAutoStopAtTrigger())
			{
				componentInParent.BeginAutoStop();
			}
		}
	}
}
