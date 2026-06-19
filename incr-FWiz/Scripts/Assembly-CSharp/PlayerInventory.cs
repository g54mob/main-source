using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	[field: SerializeField]
	public List<ItemStack> ItemStacks { get; private set; }

	[field: SerializeField]
	public IntContainer MaxItemCount { get; private set; }

	public IntContainer ItemCount { get; private set; }

	public IntContainer StackCount { get; private set; }

	public ItemStack SelectedItemStack => null;

	public bool Full => false;

	public event Action<ItemType> AnnounceItemCollected
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

	public event Action<ItemStack> AnnounceAddStack
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

	public event Action<ItemStack> AnnounceKillStack
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

	public event Action<int> AnnounceRotation
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

	public event Action AnnounceIncreaseSize
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

	public event Action AnnounceTooFull
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

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void ResetLastScroll()
	{
	}

	public bool TryApplyScroll(int scroll)
	{
		return false;
	}

	public bool RotateInventory(int amount)
	{
		return false;
	}

	public bool Pop(out ItemType item)
	{
		item = null;
		return false;
	}

	public bool Peek(out ItemType item)
	{
		item = null;
		return false;
	}

	public bool AddItem(ItemType itemType, bool forced = false)
	{
		return false;
	}

	public void AddMaxCapacity(int amount)
	{
	}
}
