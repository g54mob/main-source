using UnityEngine;

public class Area_DeepCave : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Animal"))
		{
			other.GetComponent<AnimalPrefab>().SetPitch(0.5f);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Animal"))
		{
			other.GetComponent<AnimalPrefab>().SetPitch(1f);
		}
	}
}
