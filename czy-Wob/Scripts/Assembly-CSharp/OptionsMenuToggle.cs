using UnityEngine;

public class OptionsMenuToggle : MonoBehaviour
{
	public GameObject toggleActiveGraphic;

	public CoreButtonUnityGUI toggleButtonRef;

	private bool toggleState;

	public void SetToggleState(bool state)
	{
		toggleState = state;
		toggleActiveGraphic.SetActive(toggleState);
	}

	public void SetLockedStatus(bool isLocked)
	{
		toggleButtonRef.interactable = !isLocked;
	}

	public bool GetLockedStatus()
	{
		return toggleButtonRef.interactable;
	}
}
