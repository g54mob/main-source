using System.Collections.Generic;
using UnityEngine;

public class PipeLandingZone : MonoBehaviour
{
	public int dogCount;

	private List<GameObject> uniqueDogs = new List<GameObject>();

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.CompareTag(Tags.DOG) && !uniqueDogs.Contains(other.transform.root.gameObject))
		{
			dogCount++;
			uniqueDogs.Add(other.transform.root.gameObject);
		}
	}

	public void ClearDogs()
	{
		uniqueDogs.Clear();
	}
}
