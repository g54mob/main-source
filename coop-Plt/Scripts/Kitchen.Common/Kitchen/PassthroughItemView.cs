using System.Collections.Generic;
using KitchenData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen
{
	public class PassthroughItemView : SerializedMonoBehaviour, IItemSpecificView
	{
		[SerializeField]
		protected List<ItemGroupView> SubItems = new List<ItemGroupView>();

		public virtual void PerformUpdate(int item_id, ItemList components, bool is_order = false)
		{
			foreach (ItemGroupView subItem in SubItems)
			{
				if (subItem != null)
				{
					subItem.PerformUpdate(item_id, components);
				}
			}
		}
	}
}
