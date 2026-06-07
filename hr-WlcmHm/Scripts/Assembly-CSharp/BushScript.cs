using UnityEngine;

public class BushScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player" && collider.gameObject.GetComponent<FirstPersonController>().isCrouched)
		{
			collider.gameObject.GetComponent<FirstPersonController>().isHiding = true;
			collider.gameObject.GetComponentInChildren<PauseMenu>().ShowBushVignette(setActive: true);
		}
	}

	private void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.name == "Player" && collider.gameObject.GetComponent<FirstPersonController>().isCrouched)
		{
			collider.gameObject.GetComponent<FirstPersonController>().isHiding = true;
			collider.gameObject.GetComponentInChildren<PauseMenu>().ShowBushVignette(setActive: true);
		}
		else if (collider.gameObject.name == "Player" && !collider.gameObject.GetComponent<FirstPersonController>().isCrouched)
		{
			collider.gameObject.GetComponent<FirstPersonController>().isHiding = false;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.name == "Player")
		{
			collider.gameObject.GetComponent<FirstPersonController>().isHiding = false;
			collider.gameObject.GetComponentInChildren<PauseMenu>().ShowBushVignette(setActive: false);
		}
	}
}
