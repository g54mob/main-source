using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class RefrigerSlot : MonoBehaviour, IInteractable
{
	private LocalizedString interactionString = new LocalizedString("MyTable", "interaction-place");

	private LocalizedString interactionGrabString = new LocalizedString("MyTable", "interaction-grab");

	[SerializeField]
	private Refriger refriger;

	private Food mountedFood;

	public string InteractionText
	{
		get
		{
			if (mountedFood == null)
			{
				if (FirstPersonController.S.itemOnHand != null)
				{
					if (FirstPersonController.S.itemOnHand.TryGetComponent<Food>(out var _))
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
			mountedFood = base.transform.GetChild(0).GetComponent<Food>();
			refriger.foods.Add(mountedFood.gameObject);
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		FirstPersonController player = GameManager.S.player;
		if (mountedFood == null)
		{
			if (player.itemOnHand != null && player.itemOnHand.TryGetComponent<Food>(out var component))
			{
				mountedFood = component;
				refriger.foods.Add(mountedFood.gameObject);
				component.transform.parent = base.transform;
				component.transform.localPosition = Vector3.zero;
				component.transform.localRotation = Quaternion.identity;
				AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
				player.itemOnHand = null;
				player.ItemOutHand();
			}
		}
		else if (player.itemOnHand == null)
		{
			refriger.foods.Remove(mountedFood.gameObject);
			player.GrabItem(mountedFood.gameObject);
			mountedFood = null;
		}
	}

	public void Comsume()
	{
		refriger.foods.Remove(mountedFood.gameObject);
		Object.Destroy(mountedFood.gameObject);
		mountedFood = null;
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}
}
