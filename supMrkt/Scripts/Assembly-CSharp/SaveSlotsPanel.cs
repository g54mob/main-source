using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class SaveSlotsPanel : Popup
{
	[SerializeField]
	private SaveEntry m_EntryPrefab;

	[SerializeField]
	private Transform m_Content;

	[SerializeField]
	public GamePadUIPanel m_GamePadUIPanel;

	[SerializeField]
	private GamepadSelectableParent m_GamepadSelectableParent;

	[SerializeField]
	private WindowTab m_WindowTab;

	private List<SaveEntry> m_EntryInstances;

	public event Action<SaveInfo> SlotDeleteRequested
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<SaveInfo> SlotPressed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<SaveEntry> EntryLoaded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void OnGamepadConnected(bool isConnected)
	{
	}

	public void GamepadOpen()
	{
	}

	public void LoadFiles()
	{
	}

	private void OnEntryPressed(SaveInfo info)
	{
	}

	private void OnDeleteRequested(SaveInfo info)
	{
	}

	protected override void OnShown()
	{
	}

	public void SubscribeGamepad()
	{
	}

	protected override void OnHidden()
	{
	}

	public void UnsubscribeGamepad()
	{
	}

	public SaveEntry GetEntry(int slotIndex)
	{
		return null;
	}
}
