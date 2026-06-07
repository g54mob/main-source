using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class DesignerPartCategories : ScriptableObject
	{
		public static class StockCategoryIds
		{
			public const string Descent = "Descent";

			public const string Gizmos = "Gizmos";

			public const string Payloads = "Payloads";

			public const string Propulsion = "Propulsion";

			public const string Structural = "Structural";

			public const string Subassemblies = "Sub Assemblies";
		}

		public const int DefaultDisplayOrder = 2000;

		private static DesignerPartCategories _instance;

		[SerializeField]
		private List<DesignerPartCategory> _categories;

		public static IReadOnlyList<DesignerPartCategory> Categories => Instance._categories;

		protected static DesignerPartCategories Instance
		{
			get
			{
				if ((object)_instance == null)
				{
					_instance = Initialize();
				}
				return _instance;
			}
		}

		public static DesignerPartCategory GetCategory(string id, bool create)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				id = "Other";
			}
			List<DesignerPartCategory> categories = Instance._categories;
			DesignerPartCategory designerPartCategory = categories.FirstOrDefault((DesignerPartCategory x) => x.Id == id);
			if (designerPartCategory == null && create)
			{
				Sprite resource = Game.Instance.UserInterface.ResourceDatabase.GetResource<Sprite>("Ui/Sprites/Design/IconPartCategoryFallback");
				categories.Add(designerPartCategory = DesignerPartCategory.Create(id, id, 2000, id, resource));
			}
			return designerPartCategory;
		}

		public static void Register(DesignerPartCategory category)
		{
			List<DesignerPartCategory> categories = Instance._categories;
			if (categories.FirstOrDefault((DesignerPartCategory x) => x.Id == category.Id) == null)
			{
				if (category.Icon != null)
				{
					Game.Instance.UserInterface.ResourceDatabase.AddResource(category.IconPath, category.Icon);
				}
				categories.Add(category);
			}
		}

		public void ReplaceCategories(IEnumerable<DesignerPartCategory> categories)
		{
			if (_categories == null)
			{
				_categories = new List<DesignerPartCategory>(categories);
				return;
			}
			_categories.Clear();
			_categories.AddRange(categories);
		}

		private static DesignerPartCategories Initialize()
		{
			DesignerPartCategories designerPartCategories = Game.Instance.ResourceLoader.Load<DesignerPartCategories>("Craft/Parts/DesignerPartCategories");
			if (designerPartCategories == null)
			{
				Debug.LogError("Part categories could not be loaded!");
				return ScriptableObject.CreateInstance<DesignerPartCategories>();
			}
			designerPartCategories = Object.Instantiate(designerPartCategories);
			foreach (DesignerPartCategory item in designerPartCategories._categories ?? new List<DesignerPartCategory>())
			{
				if (item.Icon == null)
				{
					Debug.LogError("Icon not found for part category '" + (item.Id ?? item.name) + "'.");
				}
				else
				{
					Game.Instance.UserInterface.ResourceDatabase.AddResource(item.IconPath, item.Icon);
				}
			}
			return designerPartCategories;
		}
	}
}
