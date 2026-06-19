using UnityEngine;

public class FanTriggerArea : MonoBehaviour
{
	public IndustrialFan fanRef;

	private void OnTriggerStay(Collider other)
	{
		fanRef.OnColliderInTriggerArea(other);
	}
}
