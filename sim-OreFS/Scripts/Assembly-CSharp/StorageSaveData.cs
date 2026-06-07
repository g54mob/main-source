using System;
using System.Collections.Generic;

[Serializable]
public class StorageSaveData
{
	public List<ItemStack> itemStacks = new List<ItemStack>();

	public StorageSaveData()
	{
	}

	public StorageSaveData(IEnumerable<ItemStack> stacks)
	{
		foreach (ItemStack stack in stacks)
		{
			if (stack != null && stack.IsValid())
			{
				itemStacks.Add(new ItemStack(stack.itemId, stack.count));
			}
		}
	}
}
