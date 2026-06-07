using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class CategoryPage : Page, ICategoryPage
	{
		private Transform _transform;

		public List<IPage> SubPages { get; private set; }

		internal CategoryPage(string id, LocalizedString name)
			: base(id, name, null)
		{
			SubPages = new List<IPage>();
		}

		internal void AddEntry(Page entry)
		{
			SubPages.Add(entry);
		}

		internal void RemoveEntry(Page entry)
		{
			SubPages.Remove(entry);
		}

		internal void SortPages()
		{
			Sorting.SlowSort(SubPages);
		}

		protected override List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties)
		{
			return null;
		}

		public bool TryGetPage<T>(out T page, string pageId) where T : class, IPage
		{
			int count = SubPages.Count;
			while (0 < count--)
			{
				page = SubPages[count] as T;
				if (page != null && page.ID == pageId)
				{
					return true;
				}
			}
			page = null;
			return false;
		}

		public Transform GetTransform(Transform parent)
		{
			if (_transform == null)
			{
				_transform = Object.Instantiate(SurvivalGuideManager.Properties.CategoryParentPrefab, parent).transform;
				_transform.name = "Category_" + base.ID;
			}
			return _transform;
		}
	}
}
