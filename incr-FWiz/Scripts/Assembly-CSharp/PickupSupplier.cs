using System;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.UI;

public class PickupSupplier : HoverListener
{
	public EventReference PickupSoundOverride;

	private bool Set => false;

	private event Func<bool> _spendItem
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

	private event Func<ItemType> _peek
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

	public void SetTake(Func<ItemType> peek, Func<bool> spendItem)
	{
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

	public bool SpendItem()
	{
		return false;
	}

	public ItemType Peek()
	{
		return null;
	}
}
