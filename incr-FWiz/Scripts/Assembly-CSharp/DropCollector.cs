using System;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.UI;

public class DropCollector : HoverListener
{
	public EventReference DropSoundOverride;

	private bool Set => false;

	private event Action<ItemType> _doTakeItem
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

	private event Func<ItemType, bool> _checkCanTakeItem
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

	private event Func<ItemType, bool> _itemIsPreferred
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

	public void SetTake(Func<ItemType, bool> checkCanTakeItem, Action<ItemType> doTakeItem)
	{
	}

	public void SetPreferred(Func<ItemType, bool> itemIsPreferred)
	{
	}

	public bool IsItemPreferred(ItemType itemType)
	{
		return false;
	}

	public void Clear()
	{
	}

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public bool TakeItem(ItemType item)
	{
		return false;
	}

	public bool CanTakeItem(ItemType item)
	{
		return false;
	}
}
