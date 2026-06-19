using UnityEngine;

public class DropInventoryHandler : MonoBehaviour
{
	private Chest container;

	public bool disableInteractionWhenEmpty;

	[Header("Optional references")]
	public Transform optionalDropPosition;

	public GameObject optionalObjectToShowWhenFilled;

	public GameObject optionalObjectToShowWhenEmpty;

	public InteractableObject interactable;

	private void Start()
	{
		container = GetComponent<Chest>();
	}

	private void Update()
	{
		bool flag = true;
		if (container != null && container.entityExist && container.inventoryHandler != null)
		{
			flag = container.inventoryHandler.IsEmpty();
		}
		if (optionalObjectToShowWhenFilled != null && optionalObjectToShowWhenFilled.gameObject.activeSelf == flag)
		{
			optionalObjectToShowWhenFilled.SetActive(!flag);
		}
		if (optionalObjectToShowWhenEmpty != null && optionalObjectToShowWhenEmpty.gameObject.activeSelf != flag)
		{
			optionalObjectToShowWhenEmpty.SetActive(flag);
		}
		if (disableInteractionWhenEmpty && interactable != null && interactable.gameObject.activeSelf == flag)
		{
			interactable.gameObject.SetActive(!flag);
		}
	}

	public void DropItems()
	{
		PlayerController player = Manager.main.player;
		if (container != null && container.entityExist && container.inventoryHandler != null && player != null)
		{
			Vector3 renderPosition = ((optionalDropPosition != null) ? optionalDropPosition.position : base.transform.position);
			container.inventoryHandler.DropAllItemsWithRandomOffset(player, renderPosition);
		}
	}
}
