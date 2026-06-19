using UnityEngine;

public class ObjectIndicatorManager : MonoBehaviour
{
	public Sprite whistleIcon;

	private bool choiceMenuActive;

	private GameObject currentlyIndicatedObject;

	private bool mouseOverContextButton;

	private SceneManagerBase sceneRef;

	private CursorController cursorRef;

	private void Start()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
	}

	public void UpdateSceneRef(SceneManagerBase newRef)
	{
		sceneRef = newRef;
	}

	public bool IsMouseOverContextButton()
	{
		return mouseOverContextButton;
	}

	public void ReportMouseOver(GameObject obj)
	{
		if ((!(currentlyIndicatedObject != null) || !(obj != currentlyIndicatedObject)) && !choiceMenuActive)
		{
			ObjectIndicatorController component = obj.GetComponent<ObjectIndicatorController>();
			if (!(component == null))
			{
				component.EnableIndicator();
				choiceMenuActive = false;
				currentlyIndicatedObject = obj;
				mouseOverContextButton = false;
			}
		}
	}

	public void ReportMouseOff(GameObject obj)
	{
		if (!choiceMenuActive && !(obj != currentlyIndicatedObject) && !(currentlyIndicatedObject == null))
		{
			currentlyIndicatedObject.GetComponent<ObjectIndicatorController>().DisableIndicator();
			currentlyIndicatedObject = null;
			mouseOverContextButton = false;
		}
	}

	public void ReportClick(GameObject obj, bool leftClick = true)
	{
		if (sceneRef.GetGameMode() == GameMode.BREEDING)
		{
			return;
		}
		if (obj == null)
		{
			if (!leftClick || (!mouseOverContextButton && !cursorRef.HasOverrideUIElement()))
			{
				choiceMenuActive = false;
				ReportMouseOff(currentlyIndicatedObject);
			}
			return;
		}
		if (obj != currentlyIndicatedObject)
		{
			choiceMenuActive = false;
			ReportMouseOff(currentlyIndicatedObject);
			ReportMouseOver(obj);
		}
		choiceMenuActive = true;
		mouseOverContextButton = false;
		currentlyIndicatedObject.GetComponent<ObjectIndicatorController>().GetIndicatorRef().ShowChoiceMenu();
	}

	public void ReportMouseOverContextButton()
	{
		mouseOverContextButton = true;
	}

	public void ReportMouseOffContextButton()
	{
		mouseOverContextButton = false;
	}

	public bool IsObjectIndicatorActive()
	{
		return currentlyIndicatedObject != null;
	}

	public bool IsContextMenuActiveForObject(GameObject obj)
	{
		if (currentlyIndicatedObject == null || currentlyIndicatedObject != obj)
		{
			return false;
		}
		return currentlyIndicatedObject.GetComponent<ObjectIndicatorController>().GetIndicatorRef().IsChoiceMenuActive();
	}
}
