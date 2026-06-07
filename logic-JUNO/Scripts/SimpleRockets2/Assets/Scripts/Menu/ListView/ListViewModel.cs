using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModApi.Ui;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewModel : IListViewModel
	{
		public delegate void ListViewDelegate(ListViewModel model);

		public virtual ListViewDetailsScript Details { get; }

		public bool DoubleClickIsPrimaryClick { get; set; } = true;

		public virtual List<ListViewItemScript> Items { get; private set; }

		public ListViewScript ListView { get; private set; }

		public string NoItemsFoundMessage { get; set; } = "No items found";

		public bool UseGrid { get; set; }

		public event ListViewDelegate Closed;

		public ListViewModel()
		{
			Items = new List<ListViewItemScript>();
		}

		public virtual IEnumerator LoadItems()
		{
			yield return null;
		}

		public virtual void OnAddButtonClicked(ListViewItemScript selectedItem)
		{
		}

		public virtual void OnCanceled()
		{
		}

		public virtual void OnClosed()
		{
			if (this.Closed != null)
			{
				this.Closed(this);
				this.Closed = null;
			}
		}

		public virtual void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
		}

		public void OnFiltersChanged(string searchText, IReadOnlyList<ListViewFilter> filters)
		{
			if (searchText == null)
			{
				searchText = string.Empty;
			}
			foreach (ListViewItemScript item in Items)
			{
				bool flag = true;
				if (filters.Count > 0)
				{
					flag = item.FilterKeywords.Count == 0;
					foreach (ListViewFilter filter in filters)
					{
						bool flag2 = (filter.InvertEnabledLogic ? (!filter.Enabled) : filter.Enabled);
						if (filter.Type == ListViewFilterType.Exclusive)
						{
							flag = item.FilterKeywords.Any((string x) => filter.Keywords.Contains(x)) == flag2;
						}
						else
						{
							if (!flag2 || item.FilterKeywords.Count <= 0)
							{
								continue;
							}
							if (filter.Type == ListViewFilterType.Exclude)
							{
								if (item.FilterKeywords.Any((string x) => filter.Keywords.Contains(x)))
								{
									flag = false;
									break;
								}
							}
							else if (!flag && filter.Type == ListViewFilterType.Include && item.FilterKeywords.Any((string x) => filter.Keywords.Contains(x)))
							{
								flag = true;
							}
						}
					}
				}
				if (flag && !MatchesSearchCriteria(item, searchText))
				{
					flag = false;
				}
				item.Visible = flag;
			}
		}

		public virtual void OnItemsLoaded()
		{
		}

		public virtual void OnListViewInitialized(ListViewScript listView)
		{
			ListView = listView;
		}

		public virtual void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
		}

		public virtual void OnSelectedItemChanged(ListViewItemScript item)
		{
		}

		public virtual void OnSelectedItemChanging(ListViewItemScript item, Action completeCallback)
		{
			completeCallback?.Invoke();
		}

		public virtual void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			completeCallback?.Invoke();
		}

		public virtual void UpdatePreview(ListViewItemScript item, IListViewObjectViewer objectViewer, Action completeCallback)
		{
			completeCallback?.Invoke();
		}

		protected virtual bool MatchesSearchCriteria(ListViewItemScript item, string searchTextLower)
		{
			return item.Title.ToLower().Contains(searchTextLower);
		}
	}
}
