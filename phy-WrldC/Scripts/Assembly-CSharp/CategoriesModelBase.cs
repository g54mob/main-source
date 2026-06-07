using System.Collections.Generic;
using UnityEngine;

public abstract class CategoriesModelBase<TItemModel> : BaseModel where TItemModel : class
{
	public const string AddNewItemEvent = "CategoriesModelBase.AddNewItemEvent";

	public const string AddNewCategoryEvent = "CategoriesModelBase.AddNewCategoryEvent";

	public const string RemoveItemEvent = "CategoriesModelBase.RemoveItemEvent";

	public const string RemoveSelectedItemEvent = "CategoriesModelBase.RemoveSelectedItemEvent";

	public const string SelectedCategoryIndexEvent = "CategoriesModelBase.SelectedCategoryIndexEvent";

	public const string SelectedItemIndexEvent = "CategoriesModelBase.SelectedItemIndexEvent";

	private readonly List<GenericCategory<TItemModel>> categories;

	private int selectedCategoryIndex;

	private int selectedItemIndex;

	public int SelectedCategoryIndex
	{
		get
		{
			return selectedCategoryIndex;
		}
		set
		{
			int max = ((CategoriesCount() > 0) ? (CategoriesCount() - 1) : 0);
			selectedCategoryIndex = Mathf.Clamp(value, 0, max);
			NotifyChange("CategoriesModelBase.SelectedCategoryIndexEvent", selectedCategoryIndex);
		}
	}

	public int SelectedItemIndex
	{
		get
		{
			return selectedItemIndex;
		}
		set
		{
			int max = ((GetSelectedCategory().ItemsCount() > 0) ? (GetSelectedCategory().ItemsCount() - 1) : 0);
			selectedItemIndex = Mathf.Clamp(value, 0, max);
			NotifyChange("CategoriesModelBase.SelectedItemIndexEvent", selectedCategoryIndex, selectedItemIndex);
		}
	}

	public CategoriesModelBase()
	{
		categories = new List<GenericCategory<TItemModel>>();
		selectedCategoryIndex = 0;
		selectedItemIndex = 0;
	}

	public void AddCategory(string name, TItemModel item)
	{
		for (int i = 0; i < categories.Count; i++)
		{
			if (categories[i].Name == name)
			{
				categories[i].AddItem(item);
				NotifyChange("CategoriesModelBase.AddNewItemEvent", i, categories[i].ItemsCount() - 1, item);
				return;
			}
		}
		GenericCategory<TItemModel> genericCategory = new GenericCategory<TItemModel>(name);
		genericCategory.AddItem(item);
		categories.Add(genericCategory);
		int num = categories.Count - 1;
		NotifyChange("CategoriesModelBase.AddNewCategoryEvent", num, name);
		NotifyChange("CategoriesModelBase.AddNewItemEvent", num, 0, item);
	}

	public void RemoveSelectedItem()
	{
		GetSelectedCategory().RemoveItem(GetSelectedItem());
		NotifyChange("CategoriesModelBase.RemoveSelectedItemEvent", selectedCategoryIndex, selectedItemIndex);
		if (categories[SelectedCategoryIndex].GetAllItems().Count > 0)
		{
			SelectedItemIndex = 0;
		}
		else if (selectedCategoryIndex > 0)
		{
			SelectedCategoryIndex--;
		}
	}

	public void RemoveItem(string categoryName, TItemModel item)
	{
		for (int i = 0; i < categories.Count; i++)
		{
			if (categories[i].Name == categoryName)
			{
				int itemIndex = categories[i].GetItemIndex(item);
				if (itemIndex >= 0)
				{
					categories[i].RemoveItem(item);
					NotifyChange("CategoriesModelBase.RemoveItemEvent", i, itemIndex);
				}
				break;
			}
		}
		SelectedCategoryIndex = 0;
	}

	public void RemoveItemByFilePath(string categoryName, string filePath)
	{
		TItemModel val = null;
		foreach (GenericCategory<TItemModel> category in categories)
		{
			if (!(category.Name == categoryName))
			{
				continue;
			}
			foreach (TItemModel allItem in category.GetAllItems())
			{
				if (GetItemFilePath(allItem) == filePath)
				{
					val = allItem;
					break;
				}
			}
			if (val != null)
			{
				RemoveItem(category.Name, val);
				break;
			}
		}
	}

	protected abstract string GetItemFilePath(TItemModel item);

	public int CategoriesCount()
	{
		return categories.Count;
	}

	public GenericCategory<TItemModel> GetCategory(int index)
	{
		return categories[index];
	}

	public ICollection<GenericCategory<TItemModel>> GetAllCategories()
	{
		return categories.ToArray();
	}

	public GenericCategory<TItemModel> GetSelectedCategory()
	{
		return GetCategory(selectedCategoryIndex);
	}

	public TItemModel GetSelectedItem()
	{
		return GetCategory(selectedCategoryIndex).GetItem(selectedItemIndex);
	}
}
