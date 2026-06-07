using UnityEngine;

public class CanEnterDoor : MonoBehaviour
{
	public Enemy enemy;

	public bool cantEnterFrontDoor;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("EntryDoor") && !cantEnterFrontDoor)
		{
			other.gameObject.GetComponent<EntryDoor>().Enter();
		}
		else if (other.CompareTag("Door"))
		{
			if (!other.gameObject.GetComponentInParent<Interactable>().interactable && enemy != null)
			{
				enemy.CheckIfNearBarricade();
				return;
			}
			other.gameObject.GetComponentInParent<Interactable>().interactAnim.SetTrigger("Open");
			other.gameObject.GetComponentInParent<Interactable>().interactSFX.Play();
		}
	}
}
