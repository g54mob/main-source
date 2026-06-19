using UnityEngine;

public class StorageContainerUI : MonoBehaviour
{
	public StorageStackUI StorageStackUI;

	public StorageContainer StorageContainer { get; private set; }

	public ItemStack Stack { get; private set; }

	public void Set(ItemStack itemStack, int capacity)
	{
	}
}
