using UnityEngine;
using UnityEngine.Localization;

public class JunkShopDevice : MonoBehaviour, IInteractable
{
	private Outline outLine;

	public GameObject itemPrefab;

	private int value;

	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "junkshopDevice_interact");

	public virtual string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Grab";
		}
	}

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		value = (int)itemPrefab.GetComponent<Device>().value;
		interactionText.Arguments = new object[1] { value };
	}

	public virtual void Interact()
	{
		if (FirstPersonController.S.itemOnHand == null)
		{
			itemPrefab.GetComponent<Device>();
			if (FirstPersonController.S.ticket >= value)
			{
				FirstPersonController.S.ticket -= value;
				GameManager.S.TicketUpdated();
				GameObject item = Object.Instantiate(itemPrefab, base.transform.position, Quaternion.identity);
				FirstPersonController.S.GrabItem(item);
				base.gameObject.SetActive(value: false);
				AudioManager.S.PlaySFX(AudioManager.S.money);
			}
			else
			{
				GameManager.S.NotEnoughMoney();
			}
		}
		else
		{
			GameManager.S.HandsFull();
		}
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}
}
