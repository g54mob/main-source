using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ListViewModel
	{
		public ListViewScript ListView { get; private set; }

		public int Page { get; protected set; } = 1;

		public bool PageNextEnabled { get; protected set; }

		public bool PagingEnabled { get; protected set; }

		public virtual void AdvancePage(int amount)
		{
			int num = Page + amount;
			if (num < 1)
			{
				num = 1;
			}
			if (Page != num)
			{
				Page = num;
				ListView.RefreshItems();
			}
		}

		public virtual IEnumerator LoadItems(List<ItemModel> items)
		{
			yield return null;
		}

		public virtual void OnClosing()
		{
		}

		public virtual void OnFiltersChanged()
		{
			Page = 1;
			ListView.RefreshItems();
		}

		public virtual void OnItemsFinishedLoading()
		{
		}

		public virtual void OnListViewInitialized(ListViewScript listView)
		{
			ListView = listView;
		}

		public virtual void OnSelectButtonClicked(ListViewItemScript selectedItem)
		{
		}

		public virtual void OnSelectedNavItemChanged()
		{
			ListView.RefreshItems();
		}

		public virtual void UpdateDetailsPanel(ItemModel model, ListViewDetailsScript details)
		{
		}
	}
}
