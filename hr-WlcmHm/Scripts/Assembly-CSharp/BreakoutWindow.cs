using UnityEngine;

public class BreakoutWindow : MonoBehaviour
{
	[SerializeField]
	private string itemName = "Bus Key";

	private Collider windowCollider;

	private InteractableLight interactableLight;

	private void Start()
	{
		windowCollider = GetComponent<Collider>();
		windowCollider.enabled = false;
		interactableLight = GetComponentInChildren<InteractableLight>();
		interactableLight.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (InventoryManager.Instance.inventoryItems.Contains(itemName))
		{
			windowCollider.enabled = true;
			interactableLight.gameObject.SetActive(value: true);
		}
	}
}
