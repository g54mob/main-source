using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class GUIInputField : MonoBehaviour
{
	public bool IsActivated;

	public void EnableInput(bool enable)
	{
		InputController.InputEnabled = enable;
		IsActivated = !enable;
		if (!enable)
		{
			if (!SteamManager.Initialized)
			{
				return;
			}
			InputField component = GetComponent<InputField>();
			if (component != null)
			{
				RectTransform component2 = component.GetComponent<RectTransform>();
				EFloatingGamepadTextInputMode eKeyboardMode = EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine;
				if (component.multiLine)
				{
					eKeyboardMode = EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeMultipleLines;
				}
				Vector3[] array = new Vector3[4];
				component2.GetWorldCorners(array);
				SteamUtils.ShowFloatingGamepadTextInput(eKeyboardMode, (int)array[0].x, (int)array[0].y, (int)(array[2].x - array[0].x), (int)(array[2].y - array[0].y));
			}
		}
		else if (SteamManager.Initialized)
		{
			SteamUtils.DismissFloatingGamepadTextInput();
		}
	}

	private void OnDisable()
	{
		if (IsActivated)
		{
			EnableInput(true);
		}
	}
}
