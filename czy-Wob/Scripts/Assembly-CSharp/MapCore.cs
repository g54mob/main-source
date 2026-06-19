using UnityEngine;

public class MapCore : UICoreBase
{
	public GameObject mapTitle;

	public GameObject exitButton;

	public GameObject mapGraphics;

	private int elementsNeeded = 3;

	private int loadedElements;

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		base.Load(loadCallback);
		mapTitle.GetComponent<StandardGUIElementLoader>().Load(OnElementLoadedCallback);
		exitButton.GetComponent<MapExitButton>().Load(OnElementLoadedCallback);
		mapGraphics.GetComponent<MapGraphics>().Load(OnElementLoadedCallback);
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		base.Unload(unloadCallback);
		mapTitle.GetComponent<StandardGUIElementLoader>().Unload(OnElementUnloadedCallback);
		exitButton.GetComponent<MapExitButton>().Unload(OnElementUnloadedCallback);
		mapGraphics.GetComponent<MapGraphics>().Unload(OnElementUnloadedCallback);
	}

	private void OnElementLoadedCallback()
	{
		loadedElements++;
		if (loadedElements >= elementsNeeded)
		{
			AllElementsLoadedCallback();
		}
	}

	private void OnElementUnloadedCallback()
	{
		loadedElements--;
		if (loadedElements <= 0)
		{
			AllElementsUnloadedCallback();
		}
	}
}
