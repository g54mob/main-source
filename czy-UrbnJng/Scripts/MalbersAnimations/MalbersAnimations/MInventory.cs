using System.Collections.Generic;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Weapons/MInventory Basic")]
	public class MInventory : MonoBehaviour
	{
		public List<GameObject> Inventory;

		public GameObjectEvent OnEquipItem;

		public virtual void EquipItem(int Slot)
		{
			if (Slot < Inventory.Count)
			{
				OnEquipItem.Invoke(Inventory[Slot]);
			}
		}

		public virtual void AddItem(GameObject item)
		{
			Inventory.Add(item);
		}
	}
}
