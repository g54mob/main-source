using System;
using UnityEngine;

[Serializable]
public class QuelinePoint
{
	[SerializeField]
	private Transform transform;

	[SerializeField]
	private GameObject preview;

	[SerializeField]
	private GameObject lockedPreview;

	private Transform bookedBy;

	private bool locked;

	public void LockPoint()
	{
		locked = true;
	}

	public void UnlockPoint()
	{
		locked = false;
	}

	public bool IsLocked()
	{
		return locked;
	}

	public void ShowPreview()
	{
		lockedPreview.SetActive(locked);
		preview.SetActive(!locked);
	}

	public void HidePreview()
	{
		preview.SetActive(value: false);
		lockedPreview.SetActive(value: false);
	}

	public bool IsVisible()
	{
		if (preview == null)
		{
			return false;
		}
		return preview.activeInHierarchy;
	}

	public Transform GetPoint()
	{
		return transform;
	}

	public CustomerCore GetCustomer()
	{
		if (!(bookedBy != null))
		{
			return null;
		}
		return bookedBy.GetComponent<CustomerCore>();
	}

	public bool HasCustomer(Transform customer)
	{
		return bookedBy == customer;
	}

	public bool IsTaken()
	{
		return bookedBy != null;
	}

	public void BookPoint(Transform customer)
	{
		bookedBy = customer;
		CafeShopManager.OnUpdateCustomersInQueue.Invoke();
	}

	public void Free()
	{
		bookedBy = null;
		CafeShopManager.OnUpdateCustomersInQueue.Invoke();
	}
}
