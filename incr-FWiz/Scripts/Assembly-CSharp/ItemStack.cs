using System;
using OUSystems.Basics.DataStructures;
using UnityEngine;

[Serializable]
public class ItemStack : IntContainer
{
	[field: SerializeField]
	public ItemType ItemType { get; private set; }

	public bool Valid => false;

	public ItemStack(ItemType type, int count)
	{
	}

	public ItemStack(ItemStack itemStack)
	{
	}
}
