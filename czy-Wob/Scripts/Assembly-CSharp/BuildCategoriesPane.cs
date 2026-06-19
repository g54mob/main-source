using UnityEngine;

public class BuildCategoriesPane : PaneBase
{
	public enum BuildCategory
	{
		PEN = 0,
		PIPE = 1,
		MISC = 2
	}

	public BuildCategory currentBuildCategory;

	public GameObject expandedCategoryOptionsPane;

	private float slideInTime = 0.1f;

	private float slideOutTime = 0.1f;

	private Vector3 slideVector = new Vector3(2f, 0f, 0f);

	public override void ForceImmediateUnload()
	{
		expandedCategoryOptionsPane.GetComponent<ExpandedCategoryOptionsPane>().ForceImmediateUnload();
		currentBuildCategory = BuildCategory.PEN;
		currentState = PaneState.UNLOADED;
	}

	protected override void LoadBehavior()
	{
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, slideVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBasePaneLoaded);
	}

	private void OnBasePaneLoaded()
	{
		expandedCategoryOptionsPane.SetActive(value: true);
		expandedCategoryOptionsPane.GetComponent<ExpandedCategoryOptionsPane>().SetBuildCategory(currentBuildCategory, refreshBoxes: false);
		expandedCategoryOptionsPane.GetComponent<ExpandedCategoryOptionsPane>().RequestLoad(OnChildrenLoaded);
	}

	protected override void UnloadBehavior()
	{
		expandedCategoryOptionsPane.GetComponent<ExpandedCategoryOptionsPane>().RequestUnload(OnChildrenUnloaded);
	}

	private void OnChildrenUnloaded()
	{
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, -slideVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnUnloadComplete);
	}

	public void ToggleCategory(BuildCategory newCategory)
	{
		if (currentState == PaneState.LOADED)
		{
			currentBuildCategory = newCategory;
			expandedCategoryOptionsPane.GetComponent<ExpandedCategoryOptionsPane>().SetBuildCategory(currentBuildCategory);
		}
	}

	private void OnChildrenLoaded()
	{
		OnLoadComplete();
	}
}
