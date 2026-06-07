using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadSaveEditSlot : MonoBehaviour
{
	[Serializable]
	public class OnLoadClickedEvent : UnityEvent<string>
	{
	}

	[Serializable]
	public class OnSaveClickedEvent : UnityEvent<string>
	{
	}

	[Serializable]
	public class OnEditClickedEvent : UnityEvent<string>
	{
	}

	public OnLoadClickedEvent onLoadClicked;

	public OnSaveClickedEvent onSaveClicked;

	public OnEditClickedEvent onEditClicked;

	public GameObject loadButton;

	public GameObject saveButton;

	public GameObject editButton;

	public Text slotNumText;

	public Text dateText;

	public bool showLoadButton;

	public bool showSaveButton;

	public bool showEditButton;

	public int slotNum;

	private void Awake()
	{
	}

	public void Refresh()
	{
	}

	private string GetFileFromSlot(int slot)
	{
		return null;
	}

	public void OnLoadClicked()
	{
	}

	public void OnSaveCliced()
	{
	}

	public void OnEditClicked()
	{
	}
}
