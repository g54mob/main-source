using System;
using System.Collections.Generic;
using UnityEngine;

public class StorageStreet : NoktaSingleton<StorageStreet>
{
	public List<Box> boxes;

	public Action<Box> OnTakeBoxFromStreet;

	[SerializeField]
	private Rect m_RestockableArea;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnStartedNewDay()
	{
	}

	public void SubscribeBox(Box box)
	{
	}

	public void UnsubscribeBox(Box box)
	{
	}

	public int GetRandomFreezeBoxID()
	{
		return 0;
	}

	public Box GetFreezeBox(int productID)
	{
		return null;
	}

	public List<Box> GetBoxesFromStreet()
	{
		return null;
	}

	public List<Box> GetAllBoxesFromStreet()
	{
		return null;
	}

	public Box GetBoxFromStreet(int productID, bool includeEmptyBox)
	{
		return null;
	}

	public bool IsWithinRestockableArea(Vector3 point)
	{
		return false;
	}
}
