using UnityEngine;

public class DogPenCore : UICoreBase
{
	public GameObject exitButton;

	public DogPenPane dogPenPaneRef;

	private int loadedElements;

	private int neededElements = 1;

	private GUIManagerPens guiRef;

	private void Start()
	{
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
	}

	public void CloseDogPenGUI()
	{
		guiRef.HideDogPenGUI();
	}

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		base.Load(loadCallback);
		dogPenPaneRef.Load(OnElementLoaded);
	}

	private void OnElementLoaded()
	{
		loadedElements++;
		if (loadedElements >= neededElements)
		{
			AllElementsLoadedCallback();
			loadedElements = neededElements;
		}
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		base.Unload(unloadCallback);
		dogPenPaneRef.Unload(OnElementUnloaded);
	}

	private void OnElementUnloaded()
	{
		loadedElements--;
		if (loadedElements <= 0)
		{
			AllElementsUnloadedCallback();
			loadedElements = 0;
		}
	}
}
