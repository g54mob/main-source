using UnityEngine;

public class BuildCategoryButton : DogButtonBase
{
	public BuildCategoriesPane.BuildCategory category;

	public GameObject selectorObject;

	public BuildCategoriesPane categoryPane;

	private void Update()
	{
		if (!(selectorObject == null))
		{
			if (categoryPane.currentBuildCategory == category)
			{
				selectorObject.SetActive(value: true);
			}
			else
			{
				selectorObject.SetActive(value: false);
			}
		}
	}

	protected override void ButtonBehavior()
	{
		categoryPane.ToggleCategory(category);
	}
}
