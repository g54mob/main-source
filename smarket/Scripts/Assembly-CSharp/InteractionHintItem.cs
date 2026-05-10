using UnityEngine;

public class InteractionHintItem : MonoBehaviour
{
	public bool IsOnlyGamepad;

	public InputActionID ActionID;

	public string ActionName;

	public string LocalizationEntryKey;

	public void SetData(InputActionID actionID, string actionName, string localizationEntryKey, bool isOnlyGamepad)
	{
	}

	public void HideHint()
	{
	}

	public void ShowHint()
	{
	}
}
