using System.Collections.Generic;
using UnityEngine;

public class ItemBook : MonoBehaviour
{
	public ItemBookItemButton ItemButtonPrefab;

	public Transform LockedItemButtonParent;

	public Transform UnlockedItemButtonParent;

	public List<ItemBookItemButton> Buttons;

	public BigProgressBar BigProgressBar;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void Open()
	{
	}

	public void OnEndMode()
	{
	}

	public void ToggleMode()
	{
	}

	public void Clear()
	{
	}
}
