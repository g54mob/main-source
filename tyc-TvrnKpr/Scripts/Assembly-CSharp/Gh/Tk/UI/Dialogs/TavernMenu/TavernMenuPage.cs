using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs.MealDesigner;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.TavernMenu
{
	public abstract class TavernMenuPage : MonoBehaviour
	{
		[SerializeField]
		protected GameObject _menuItemPrefab;

		[SerializeField]
		protected Container3DUIView _itemsContainer;

		[SerializeField]
		protected GameObject _tipsPrefab;

		[SerializeField]
		protected TavernMenuCategoryButton3DUIView[] _categoryButtonPrefabs;

		[SerializeField]
		protected Container3DUIView _categoryFilterContainer;

		[SerializeField]
		protected PatronGameItemRatingContainer3DUIView _ratings;

		[SerializeField]
		protected string[] _itemCategories;

		protected string _currentCategory;

		private readonly Dictionary<string, TavernMenuCategoryButton3DUIView> _filterButtons;

		protected virtual void Start()
		{
		}

		private void ClearMenuItems()
		{
		}

		protected virtual void PopulateMenuItems()
		{
		}

		private void RemoveItem(GameObject item)
		{
		}

		public void UpdateMenuItems()
		{
		}

		public void UpdateContainer()
		{
		}

		protected void ItemDeleted(object sender, EventArgs<TavernMenuItem3DUIView> e)
		{
		}

		protected void SettingsChangedEventHandler(object sender, EventArgs e)
		{
		}

		public void UpdateItems()
		{
		}

		public virtual void Refresh()
		{
		}

		private void OnFilterClicked(string category)
		{
		}
	}
}
