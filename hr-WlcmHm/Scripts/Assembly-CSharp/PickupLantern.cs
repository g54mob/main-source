using UnityEngine;

public class PickupLantern : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Vector3 lanternPosition = new Vector3(-0.8f, -0.9f, 1f);

	private bool isPickedUp;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public string GetActionName()
	{
		return "Pick up";
	}

	public string GetActionType()
	{
		return "Press";
	}

	public string GetName()
	{
		return "Lantern";
	}

	public void Interact()
	{
		if (!isPickedUp)
		{
			Transform parent = Camera.main.transform;
			base.transform.SetParent(parent);
			base.transform.localPosition = lanternPosition;
			base.transform.localRotation = Quaternion.identity;
			isPickedUp = true;
			base.transform.GetComponent<Collider>().enabled = false;
			base.transform.GetComponentInChildren<InteractableLight>().transform.gameObject.SetActive(value: false);
		}
	}

	public void PlayInteractSound()
	{
	}
}
