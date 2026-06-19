using UnityEngine;

public class DogDenGatherTrigger : MonoBehaviour
{
	public DogDen denRef;

	private void OnTriggerEnter(Collider other)
	{
		if (denRef.GetIsSnowy())
		{
			if (other.transform.root.CompareTag(Tags.SNOWBALL))
			{
				denRef.CollectDirt(other.transform.root.gameObject);
			}
		}
		else if (other.transform.root.CompareTag(Tags.DIRT_CLUMP))
		{
			denRef.CollectDirt(other.transform.root.gameObject);
		}
	}
}
