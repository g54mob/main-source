using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Collections/Runtime Damageable Set", order = 1000, fileName = "New Runtime Damageable Set")]
	public class RuntimeDamageableSet : RuntimeCollection<MDamageable>
	{
		public DamageableEvent OnItemAdded = new DamageableEvent();

		public DamageableEvent OnItemRemoved = new DamageableEvent();

		public MDamageable Item_GetClosest(MDamageable origin)
		{
			items.RemoveAll((MDamageable x) => x == null);
			MDamageable result = null;
			float num = float.MaxValue;
			foreach (MDamageable item in items)
			{
				float num2 = Vector3.Distance(item.transform.position, origin.transform.position);
				if (num2 < num)
				{
					result = item;
					num = num2;
				}
			}
			return result;
		}

		public void ItemAdd(Component newItem)
		{
			MDamageable mDamageable = newItem.FindComponent<MDamageable>();
			if ((bool)mDamageable)
			{
				Item_Add(mDamageable);
			}
		}

		public void Item_Add(GameObject newItem)
		{
			MDamageable mDamageable = newItem.FindComponent<MDamageable>();
			if ((bool)mDamageable)
			{
				Item_Add(mDamageable);
			}
		}

		protected override void OnAddEvent(MDamageable newItem)
		{
			OnItemAdded.Invoke(newItem);
		}

		protected override void OnRemoveEvent(MDamageable newItem)
		{
			OnItemRemoved.Invoke(newItem);
		}

		public void ItemRemove(Component newItem)
		{
			MDamageable mDamageable = newItem.FindComponent<MDamageable>();
			if ((bool)mDamageable)
			{
				Item_Remove(mDamageable);
			}
		}

		public void Item_Remove(GameObject newItem)
		{
			if ((bool)newItem)
			{
				MDamageable mDamageable = newItem.FindComponent<MDamageable>();
				if ((bool)mDamageable)
				{
					Item_Remove(mDamageable);
				}
			}
		}
	}
}
