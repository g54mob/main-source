using UnityEngine;

public class DoorOpener : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.TryGetComponent<DoorController>(out var component))
		{
			component.Interact();
		}
		if (c.TryGetComponent<KillDoorController>(out var component2))
		{
			component2.Interact();
		}
	}

	private void OnTriggerExit(Collider c)
	{
		if (c.TryGetComponent<DoorController>(out var component))
		{
			component.Interact();
		}
		if (c.TryGetComponent<KillDoorController>(out var component2))
		{
			component2.Interact();
		}
	}

	private void Update()
	{
	}
}
