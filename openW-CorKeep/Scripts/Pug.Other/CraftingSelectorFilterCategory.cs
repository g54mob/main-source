using System.Collections.Generic;

public class CraftingSelectorFilterCategory : CraftingSelectorFilter
{
	public bool clearWhenNotSet;

	private ObjectIDCategory _category;

	private HashSet<ObjectID> _objectIdFilter = new HashSet<ObjectID>();

	public ObjectIDCategory Category
	{
		get
		{
			return _category;
		}
		set
		{
			_category = value;
			_objectIdFilter.Clear();
			if (_category != null)
			{
				foreach (ObjectID objectId in _category.ObjectIds)
				{
					_objectIdFilter.Add(objectId);
				}
			}
			UpdateFilter();
		}
	}

	private void Awake()
	{
		Category = _category;
	}

	public override void FilterObjects(List<CraftingSelectorData.RecipeSlot> recipeSlots)
	{
		if (_category == null)
		{
			if (clearWhenNotSet)
			{
				recipeSlots.Clear();
			}
			return;
		}
		for (int num = recipeSlots.Count - 1; num >= 0; num--)
		{
			CraftingSelectorData.RecipeSlot recipeSlot = recipeSlots[num];
			if (!_objectIdFilter.Contains(recipeSlot.ObjectData.objectID))
			{
				recipeSlots.RemoveAt(num);
			}
		}
	}
}
