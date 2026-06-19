using UnityEngine;

public class ClickableObject : MonoBehaviour
{
	private bool locked;

	private bool ghosted;

	protected GUIManagerPens guiRef;

	private void Start()
	{
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
	}

	public void OnClick()
	{
		if (!ghosted && (!(guiRef != null) || guiRef.GetGUIInteractiveStatus()))
		{
			OnClickInternal();
		}
	}

	public bool CanHighlight()
	{
		if (guiRef != null && !guiRef.GetGUIInteractiveStatus())
		{
			return false;
		}
		if (!ghosted)
		{
			return !locked;
		}
		return false;
	}

	public void SetGhostedStatus(bool val)
	{
		ghosted = val;
	}

	public void SetLockedStatus(bool val)
	{
		locked = val;
	}

	protected virtual void OnClickInternal()
	{
	}
}
