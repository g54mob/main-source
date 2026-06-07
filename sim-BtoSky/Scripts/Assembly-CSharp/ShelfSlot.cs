using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class ShelfSlot : MonoBehaviour, IInteractable
{
	private LocalizedString interactionString = new LocalizedString("MyTable", "interaction-place");

	private LocalizedString interactionGrabString = new LocalizedString("MyTable", "interaction-grab");

	[SerializeField]
	private Shelf shelf;

	private Item mountedItem;

	public string InteractionText
	{
		get
		{
			if (mountedItem == null)
			{
				if (FirstPersonController.S.itemOnHand != null)
				{
					if (FirstPersonController.S.itemOnHand.TryGetComponent<MotorIngredientItem>(out var _))
					{
						return interactionString.GetLocalizedString();
					}
					return "";
				}
				return "";
			}
			if (FirstPersonController.S.itemOnHand == null)
			{
				return interactionGrabString.GetLocalizedString();
			}
			return "";
		}
	}

	private void Start()
	{
		StartCoroutine(DelayedCheckSlot());
	}

	private IEnumerator DelayedCheckSlot()
	{
		yield return new WaitForSeconds(0.5f);
		if (base.transform.childCount > 0)
		{
			mountedItem = base.transform.GetChild(0).GetComponent<MotorIngredientItem>();
			shelf.items.Add(mountedItem.gameObject);
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		FirstPersonController player = GameManager.S.player;
		if (mountedItem == null)
		{
			if (player.itemOnHand != null && player.itemOnHand.TryGetComponent<MotorIngredientItem>(out var component))
			{
				mountedItem = component;
				shelf.items.Add(mountedItem.gameObject);
				component.transform.parent = base.transform;
				component.transform.localPosition = Vector3.zero;
				component.transform.localRotation = Quaternion.identity;
				player.itemOnHand = null;
				player.ItemOutHand();
				AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
			}
		}
		else if (player.itemOnHand == null)
		{
			shelf.items.Remove(mountedItem.gameObject);
			player.GrabItem(mountedItem.gameObject);
			mountedItem = null;
		}
	}

	public void Comsume()
	{
		shelf.items.Remove(mountedItem.gameObject);
		Object.Destroy(mountedItem.gameObject);
		mountedItem = null;
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}
}
