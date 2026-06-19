using System.Collections.Generic;
using UnityEngine;

public class CategoryOptionsBoxes : BoxList
{
	public GameObject buildInfoPane;

	public GameObject topArrow;

	public GameObject botArrow;

	public GameObject bubTop;

	public GameObject bubMid;

	public GameObject bubBot;

	private Vector3 disabledScrollObjectScale = new Vector3(0.5f, 0.5f, 0.5f);

	private List<object> allObjects = new List<object>();

	private int elementsNeeded = 2;

	private int elementsLoaded;

	private ScalableUIContainer.LoadCallback currentCallback;

	private BuildCategoriesPane.BuildCategory currentCategory;

	private BuildableManager managerRef;

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		Preload();
		PreloadPreviews();
		buildInfoPane.SetActive(value: true);
		buildInfoPane.GetComponent<BuildInfoPane>().RequestLoad(ElementLoadCompleteCallback);
		currentCallback = loadCallback;
		base.Load(ElementLoadCompleteCallback);
	}

	public override void Preload()
	{
		boxesPerRow = 3;
		rowsPerScreen = 4;
		boxOffsetX = 1.5f;
		boxOffsetY = 1.5f;
		scaleInOffset = 0.01f;
		scaleOutOffset = 0.01f;
		ToggleScrollUp = ToggleScrollTopArrow;
		ToggleScrollDown = ToggleScrollBotArrow;
		ToggleBubs = ToggleScrollBubs;
		managerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<BuildableManager>(GlobalObject.BUILDABLE_MANAGER);
		base.Preload();
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		buildInfoPane.GetComponent<BuildInfoPane>().RequestUnload(InfoPaneUnloaded);
		currentCallback = unloadCallback;
		base.Unload(ElementUnloadCompleteCallback);
	}

	public override void ForceImmediateUnload()
	{
		buildInfoPane.GetComponent<BuildInfoPane>().ForceImmediateUnload();
		elementsLoaded = 0;
		base.ForceImmediateUnload();
	}

	private void ElementLoadCompleteCallback()
	{
		elementsLoaded++;
		if (elementsLoaded >= elementsNeeded)
		{
			currentCallback();
			currentCallback = null;
		}
	}

	private void ElementUnloadCompleteCallback()
	{
		elementsLoaded--;
		if (elementsLoaded <= 0)
		{
			currentCallback();
			currentCallback = null;
		}
	}

	public void SetBuildCategory(BuildCategoriesPane.BuildCategory newCategory, bool refreshBoxes = true)
	{
		currentCategory = newCategory;
		if (refreshBoxes)
		{
			UpdateType();
		}
	}

	private void InfoPaneUnloaded()
	{
		buildInfoPane.SetActive(value: false);
		ElementUnloadCompleteCallback();
	}

	public override object GetSelectedObject()
	{
		if (heldObjectsOfType.Count == 0)
		{
			return null;
		}
		return managerRef.GetObjectForID((ulong)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)]);
	}

	protected override List<object> GetAllObjects()
	{
		if (allObjects.Count == 0)
		{
			foreach (BuildCategoriesPane.BuildCategory value in EnumUtils.GetValues<BuildCategoriesPane.BuildCategory>())
			{
				List<ulong> allBuildableObjectsForCategory = managerRef.GetAllBuildableObjectsForCategory(value);
				for (int i = 0; i < allBuildableObjectsForCategory.Count; i++)
				{
					allObjects.Add(allBuildableObjectsForCategory[i]);
				}
			}
		}
		return allObjects;
	}

	protected override void UpdateHeldObjectsOfType()
	{
		List<ulong> allBuildableObjectsForCategory = managerRef.GetAllBuildableObjectsForCategory(currentCategory);
		heldObjectsOfType.Clear();
		for (int i = 0; i < allBuildableObjectsForCategory.Count; i++)
		{
			heldObjectsOfType.Add(allBuildableObjectsForCategory[i]);
		}
	}

	protected override void SetActiveBox(int index)
	{
		base.SetActiveBox(index);
		buildInfoPane.GetComponent<BuildInfoPane>().SetActiveObject((BuildableObject)GetSelectedObject());
	}

	protected override GameObject GetPreviewObjectForObject(object obj)
	{
		return Object.Instantiate(managerRef.GetObjectForID((ulong)obj).previewObject);
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return managerRef.GetObjectForID((ulong)heldObjectsOfType[index]).GetName();
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return managerRef.GetObjectForID((ulong)heldObjectsOfType[index]).GetDescription();
	}

	private void ToggleScrollTopArrow(bool toggleVal)
	{
		if (toggleVal)
		{
			topArrow.transform.localScale = Vector3.one;
			Clickable component = topArrow.GetComponent<Clickable>();
			if (component == null)
			{
				component = topArrow.AddComponent<Clickable>();
				component.SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
				component.SetClickCallbacks(base.ScrollUp);
			}
		}
		else
		{
			Clickable component = topArrow.GetComponent<Clickable>();
			if (component != null)
			{
				component.ForceCancelEase();
				Object.Destroy(component);
			}
			topArrow.transform.localScale = disabledScrollObjectScale;
		}
	}

	private void ToggleScrollBotArrow(bool toggleVal)
	{
		if (toggleVal)
		{
			botArrow.transform.localScale = Vector3.one;
			Clickable component = botArrow.GetComponent<Clickable>();
			if (component == null)
			{
				component = botArrow.AddComponent<Clickable>();
				component.SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
				component.SetClickCallbacks(base.ScrollDown);
			}
		}
		else
		{
			Clickable component = botArrow.GetComponent<Clickable>();
			if (component != null)
			{
				component.ForceCancelEase();
				Object.Destroy(component);
			}
			botArrow.transform.localScale = disabledScrollObjectScale;
		}
	}

	private void ToggleScrollBubs(bool toggleVal)
	{
		Vector3 one = Vector3.one;
		if (!toggleVal)
		{
			one = disabledScrollObjectScale;
		}
		bubTop.transform.localScale = one;
		bubMid.transform.localScale = one;
		bubBot.transform.localScale = one;
	}
}
