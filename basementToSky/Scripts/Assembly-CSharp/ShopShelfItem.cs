using UnityEngine;
using UnityEngine.Localization;

public class ShopShelfItem : MonoBehaviour, IInteractable
{
	private Outline outLine;

	public GameObject itemPrefab;

	[SerializeField]
	private bool isShoppingBag;

	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

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
	}

	private void Update()
	{
	}

	public virtual void Interact()
	{
		if (FirstPersonController.S.itemOnHand != null)
		{
			if (FirstPersonController.S.itemOnHand.TryGetComponent<ShoppingBag>(out var component) && !isShoppingBag)
			{
				if (component.contents.Count < 5)
				{
					if (component.isPayed)
					{
						GameManager.S.AlreadyPayed();
						return;
					}
					component.PutItemIntheBag(itemPrefab);
					base.gameObject.SetActive(value: false);
				}
				else
				{
					GameManager.S.HandsFull();
				}
			}
			else if (!isShoppingBag)
			{
				GameManager.S.ShoppingBagNeeded();
			}
		}
		else if (isShoppingBag)
		{
			GameObject item = Object.Instantiate(itemPrefab, base.transform.position, Quaternion.identity);
			FirstPersonController.S.GrabItem(item);
			base.gameObject.SetActive(value: false);
		}
		else
		{
			GameManager.S.ShoppingBagNeeded();
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
