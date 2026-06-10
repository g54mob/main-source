using System.Collections.Generic;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Manager
{
	public class ResourceSearchFilter
	{
		public string BlueprintOrCategoryId { get; set; }

		public Resource Blueprint { get; set; }

		public ResourceCategory Category { get; set; }

		public List<Resource> Resources { get; set; }

		public bool AllowedOnly { get; set; }

		public int Count { get; set; }

		public ItemMaterialCategory ItemMaterialCategory { get; set; }

		public bool Check(ResourceInstance instance, bool ignoreCount = false)
		{
			if (instance == null)
			{
				return false;
			}
			if (Blueprint != null && Blueprint == instance.Blueprint)
			{
				if (!ignoreCount)
				{
					return instance.Amount >= Count;
				}
				return true;
			}
			if (ItemMaterialCategory > ItemMaterialCategory.None && instance.Blueprint.ItemMaterialCategory == ItemMaterialCategory)
			{
				if (!ignoreCount)
				{
					return instance.Amount >= Count;
				}
				return true;
			}
			if (!string.IsNullOrEmpty(BlueprintOrCategoryId))
			{
				if (int.TryParse(BlueprintOrCategoryId, out var result))
				{
					ResourceCategory resourceCategory = (ResourceCategory)result;
					if ((instance.Blueprint.Category & resourceCategory) != ResourceCategory.None)
					{
						if (!ignoreCount)
						{
							return instance.Amount >= Count;
						}
						return true;
					}
				}
				else if (instance.Blueprint.GetID().Equals(BlueprintOrCategoryId))
				{
					if (!ignoreCount)
					{
						return instance.Amount >= Count;
					}
					return true;
				}
			}
			if (Category != ResourceCategory.None && (instance.Blueprint.Category & Category) != ResourceCategory.None)
			{
				if (!ignoreCount)
				{
					return instance.Amount >= Count;
				}
				return true;
			}
			if (Resources == null)
			{
				return false;
			}
			foreach (Resource resource in Resources)
			{
				if (instance.Blueprint == resource)
				{
					return ignoreCount || instance.Amount >= Count;
				}
			}
			return false;
		}
	}
}
