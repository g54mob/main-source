using UnityEngine;

public class FileSelectCore : UICoreBase
{
	public GameObject bgObject;

	private int elementsNeeded = 1;

	private int loadedElements;

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		base.Load(loadCallback);
		bgObject.GetComponent<GenericGUIElementLoaderBase>().Load(OnElementLoadedCallback);
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		base.Unload(unloadCallback);
		bgObject.GetComponent<GenericGUIElementLoaderBase>().Unload(OnElementUnloadedCallback);
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
