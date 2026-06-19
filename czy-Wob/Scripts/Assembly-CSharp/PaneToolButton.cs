using UnityEngine;

public class PaneToolButton : DogButtonBase
{
	public BuildGUI.PaneType paneType;

	public GameObject selectorObject;

	private BuildGUI buildGUIRef;

	protected override void OnStart()
	{
		base.OnStart();
		buildGUIRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI).buildModeGUI.GetComponent<BuildGUI>();
	}

	private void Update()
	{
		if (!(selectorObject == null))
		{
			if (buildGUIRef.currentPaneType == paneType)
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
		buildGUIRef.SetPaneType(paneType);
	}
}
