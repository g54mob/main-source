using UnityEngine;

public class ExpandedCategoryOptionsPane : PaneBase
{
	public enum BoxState
	{
		UNLOADED = 0,
		LOADED = 1,
		UNLOADING = 2,
		LOADING = 3
	}

	public GameObject categoryBoxes;

	public BoxState currentBoxState;

	private float slideInTime = 0.1f;

	private float slideOutTime = 0.1f;

	private Vector3 slideVector = new Vector3(10f, 0f, 0f);

	private void OnEnable()
	{
		ForceImmediateUnload();
	}

	private void OnDisable()
	{
		base.gameObject.SetActive(value: false);
	}

	public override void ForceImmediateUnload()
	{
		currentBoxState = BoxState.UNLOADED;
		categoryBoxes.GetComponent<CategoryOptionsBoxes>().ForceImmediateUnload();
		base.ForceImmediateUnload();
	}

	public void SetBuildCategory(BuildCategoriesPane.BuildCategory newCategory, bool refreshBoxes = true)
	{
		categoryBoxes.GetComponent<CategoryOptionsBoxes>().SetBuildCategory(newCategory, refreshBoxes);
	}

	protected override void LoadBehavior()
	{
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, slideVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnPaneBaseLoaded);
	}

	protected override void UnloadBehavior()
	{
		UnloadBoxes();
	}

	private void OnPaneBaseLoaded()
	{
		LoadBoxes();
	}

	private void LoadBoxes()
	{
		if (currentBoxState != BoxState.UNLOADED)
		{
			Debug.LogError("Attempting to load boxes that haven't been unloaded.");
			return;
		}
		currentBoxState = BoxState.LOADING;
		categoryBoxes.GetComponent<CategoryOptionsBoxes>().Load(BoxesLoadedCallback);
	}

	private void UnloadBoxes()
	{
		if (currentBoxState != BoxState.LOADED)
		{
			Debug.LogError("Attempting to unload boxes that haven't been loaded.");
			return;
		}
		currentBoxState = BoxState.UNLOADING;
		categoryBoxes.GetComponent<CategoryOptionsBoxes>().Unload(BoxesUnloadedCallback);
	}

	private void BoxesLoadedCallback()
	{
		currentBoxState = BoxState.LOADED;
		OnLoadComplete();
		categoryBoxes.GetComponent<CategoryOptionsBoxes>().UpdateScrolling();
	}

	private void BoxesUnloadedCallback()
	{
		currentBoxState = BoxState.UNLOADED;
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, -slideVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnUnloadComplete);
	}
}
