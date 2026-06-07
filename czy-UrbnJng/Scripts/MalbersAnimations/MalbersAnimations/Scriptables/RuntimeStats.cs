using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Collections/Runtime Stats Set", order = 1000, fileName = "New Runtime Stats Collection")]
	public class RuntimeStats : RuntimeCollection<Stats>
	{
		public StatsEvent OnItemAdded = new StatsEvent();

		public StatsEvent OnItemRemoved = new StatsEvent();

		public Stats Item_GetClosest(Stats origin)
		{
			items.RemoveAll((Stats x) => x == null);
			Stats result = null;
			float num = float.MaxValue;
			foreach (Stats item in items)
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
			Stats stats = newItem.FindComponent<Stats>();
			if ((bool)stats)
			{
				Item_Add(stats);
			}
		}

		public void Item_Add(GameObject newItem)
		{
			Stats stats = newItem.FindComponent<Stats>();
			if ((bool)stats)
			{
				Item_Add(stats);
			}
		}

		protected override void OnAddEvent(Stats newItem)
		{
			OnItemAdded.Invoke(newItem);
		}

		protected override void OnRemoveEvent(Stats newItem)
		{
			OnItemRemoved.Invoke(newItem);
		}

		public void ItemRemove(Component newItem)
		{
			Stats stats = newItem.FindComponent<Stats>();
			if ((bool)stats)
			{
				Item_Remove(stats);
			}
		}

		public void Item_Remove(GameObject newItem)
		{
			if ((bool)newItem)
			{
				Stats stats = newItem.FindComponent<Stats>();
				if ((bool)stats)
				{
					Item_Remove(stats);
				}
			}
		}
	}
}
