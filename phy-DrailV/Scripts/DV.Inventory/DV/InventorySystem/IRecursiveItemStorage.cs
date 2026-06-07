using UnityEngine;

namespace DV.InventorySystem
{
	public interface IRecursiveItemStorage
	{
		int Capacity { get; }

		GameObject[] GetItemsArray(bool includingDropped = true);
	}
}
