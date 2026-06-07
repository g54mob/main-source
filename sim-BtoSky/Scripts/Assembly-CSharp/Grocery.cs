using System;
using System.Collections.Generic;
using Suburb;
using UnityEngine;

public class Grocery : MonoBehaviour
{
	public bool stolen;

	[SerializeField]
	private NPC shopNpc;

	[SerializeField]
	private SimpleOpenClose[] shopDoors;

	[SerializeField]
	private List<ShopShelf> shelives;

	private float lockedTimer;

	private float stolenPrice;

	public static event Action OnHandleTheft;

	private void Update()
	{
		if (stolen)
		{
			if (lockedTimer > 0f)
			{
				lockedTimer -= Time.deltaTime;
			}
			else
			{
				UnlockStore();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (stolen)
		{
			return;
		}
		Debug.Log(other.gameObject);
		if (other.TryGetComponent<IPayable>(out var component))
		{
			Debug.Log("A");
			float num = 0f;
			foreach (ShopShelf shelife in shelives)
			{
				num += shelife.RefillShelf();
			}
			if (!(num <= 0f) && !component.IsPayed())
			{
				HandleTheft(num);
			}
		}
		else
		{
			if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
			{
				return;
			}
			float num2 = 0f;
			foreach (ShopShelf shelife2 in shelives)
			{
				num2 += shelife2.RefillShelf();
			}
			if (!(num2 <= 0f) && FirstPersonController.S.itemOnHand != null && FirstPersonController.S.itemOnHand.TryGetComponent<IPayable>(out var component2) && !component2.IsPayed())
			{
				HandleTheft(num2);
			}
		}
	}

	private void HandleTheft(float sum)
	{
		stolenPrice = sum;
		stolen = true;
		SimpleOpenClose[] array = shopDoors;
		foreach (SimpleOpenClose simpleOpenClose in array)
		{
			if (simpleOpenClose.objectOpen)
			{
				simpleOpenClose.ObjectClicked();
			}
			simpleOpenClose.locked = true;
		}
		lockedTimer = sum * 30f;
		Grocery.OnHandleTheft?.Invoke();
	}

	public float DonateNeeded()
	{
		return Mathf.Floor(lockedTimer / 30f * 10f) / 10f;
	}

	public float GetStolenPrice()
	{
		return stolenPrice;
	}

	public void UnlockStore()
	{
		SimpleOpenClose[] array = shopDoors;
		foreach (SimpleOpenClose simpleOpenClose in array)
		{
			if (!simpleOpenClose.objectOpen)
			{
				simpleOpenClose.ObjectClicked();
			}
			simpleOpenClose.locked = false;
		}
		stolen = false;
		lockedTimer = 0f;
	}
}
