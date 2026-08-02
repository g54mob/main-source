using UnityEngine;

public class PlayerPushUp : MonoBehaviour
{
	public float pushUpDistance = 1f;

	private void OnTriggerEnter(Collider other)
	{
		CharacterController component = other.GetComponent<CharacterController>();
		if (!(component == null))
		{
			component.enabled = false;
			other.transform.position += Vector3.up * pushUpDistance;
			component.enabled = true;
		}
	}
}
