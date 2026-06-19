using TMPro;
using UnityEngine;

public class GenericChoicePopup : MonoBehaviour
{
	public TextMeshProUGUI headerText;

	public TextMeshProUGUI messageText;

	private string openSound = "tutorial_popup_open";

	private string closeSound = "tutorial_popup_close";

	private CoreButton.OnClickDelegate noCallback;

	private CoreButton.OnClickDelegate yesCallback;

	private bool cancelKeyAllowed;

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private ObjectRegistration regRef;

	private void Awake()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		regRef = ObjectRegistration.GetRegistrationScript();
		guiRef = regRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		penFocusRef.SetInputAllowed(val: false, LockReason.GENERIC_POPUP);
		guiRef.SetGUIInteractiveStatus(status: false, LockReason.GENERIC_POPUP);
		guiRef.RegisterNewPopup(LockReason.GENERIC_POPUP, stomp: false);
		AudioController.Play(openSound);
	}

	private void OnDestroy()
	{
		guiRef.ClearPopupRegistration(LockReason.GENERIC_POPUP);
		penFocusRef.SetInputAllowed(val: true, LockReason.GENERIC_POPUP);
		guiRef.SetGUIInteractiveStatus(status: true, LockReason.GENERIC_POPUP);
	}

	private void Update()
	{
		if (cancelKeyAllowed && GameControls.actions.CloseMenu.WasPressed)
		{
			OnNoButtonPressed();
		}
	}

	public void SetPopupInfo(string header, string message, CoreButton.OnClickDelegate newCallbackYes, CoreButton.OnClickDelegate newCallbackNo = null, bool isCancelKeyAllowed = false)
	{
		string text = "";
		for (int i = 0; i < message.Length; i++)
		{
			if (message[i] == '\\' && i + 1 < message.Length && message[i + 1] == 'n')
			{
				i++;
				text += "\n";
			}
			else
			{
				text += message[i];
			}
		}
		headerText.text = header;
		messageText.text = text;
		noCallback = newCallbackNo;
		yesCallback = newCallbackYes;
		cancelKeyAllowed = isCancelKeyAllowed;
	}

	public void OnYesButtonPressed()
	{
		yesCallback?.Invoke();
		AudioController.Play(closeSound);
		Object.Destroy(base.gameObject);
	}

	public void OnNoButtonPressed()
	{
		noCallback?.Invoke();
		AudioController.Play(closeSound);
		Object.Destroy(base.gameObject);
	}
}
