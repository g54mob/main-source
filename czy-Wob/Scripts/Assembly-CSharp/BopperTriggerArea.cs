using UnityEngine;

public class BopperTriggerArea : MonoBehaviour
{
	public InteractablePawBopper bopperRef;

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.root.CompareTag(Tags.DOG))
		{
			bopperRef.OnDogInTriggerArea(other);
		}
	}
}
