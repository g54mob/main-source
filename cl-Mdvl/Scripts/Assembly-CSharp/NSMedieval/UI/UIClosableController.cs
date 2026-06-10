using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.UI
{
	public class UIClosableController : MonoSingleton<UIClosableController>
	{
		private HashSet<UIView> closables = new HashSet<UIView>();

		public void AddToClosables(UIView closable)
		{
			closables.Add(closable);
		}

		public void RemoveFromClosables(UIView closable)
		{
			closables.Remove(closable);
		}

		public void CloseAll()
		{
			using PooledList<UIView> pooledList = closables.ToPooledListJanitor();
			foreach (UIView item in pooledList)
			{
				if (!(item == null) && !(item.name == "InGameMenuView"))
				{
					item.Hide();
				}
			}
		}
	}
}
