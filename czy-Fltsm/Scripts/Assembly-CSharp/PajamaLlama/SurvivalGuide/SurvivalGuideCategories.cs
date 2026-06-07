using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	[Serializable]
	internal class SurvivalGuideCategories
	{
		[Serializable]
		private struct Category
		{
			public string id;

			public string title;

			public Page[] pages;
		}

		[Serializable]
		private struct Page
		{
			public string id;

			public string name;

			public string icon;

			public string path;
		}

		[SerializeField]
		private Category[] categories;

		internal void CreateCategoryPages(List<CategoryPage> categoryPages)
		{
			Category[] array = categories;
			for (int i = 0; i < array.Length; i++)
			{
				Category category = array[i];
				CategoryPage categoryPage = new CategoryPage(category.id, category.title);
				categoryPages.Add(categoryPage);
				if (category.pages.IsNullOrEmpty())
				{
					continue;
				}
				Page[] pages = category.pages;
				for (int j = 0; j < pages.Length; j++)
				{
					Page page = pages[j];
					Sprite icon = null;
					if (!string.IsNullOrEmpty(page.icon))
					{
						Resources.Load<Sprite>(page.icon);
					}
					categoryPage.AddEntry(new JSONPage(page.id, page.name, icon, page.path));
				}
			}
		}
	}
}
