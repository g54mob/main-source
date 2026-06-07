using UnityEngine;
using UnityEngine.UI;

public class OVRTrackedKeyboardSampleControls : MonoBehaviour
{
	public OVRTrackedKeyboard trackedKeyboard;

	public InputField StartingFocusField;

	public Text NameValue;

	public Text ConnectedValue;

	public Text StateValue;

	public Text SelectKeyboardValue;

	public Text TypeValue;

	public Color GoodStateColor = new Color(0.25f, 1f, 0.25f, 1f);

	public Color BadStateColor = new Color(1f, 0.25f, 0.25f, 1f);

	public Toggle TrackingToggle;

	public Toggle ConnectionToggle;

	public Toggle RemoteKeyboardToggle;

	private void Start()
	{
		StartingFocusField.Select();
		StartingFocusField.ActivateInputField();
		if (TrackingToggle.isOn != trackedKeyboard.TrackingEnabled)
		{
			TrackingToggle.isOn = trackedKeyboard.TrackingEnabled;
		}
		if (ConnectionToggle.isOn != trackedKeyboard.ConnectionRequired)
		{
			ConnectionToggle.isOn = trackedKeyboard.ConnectionRequired;
		}
		if (RemoteKeyboardToggle.isOn != trackedKeyboard.RemoteKeyboard)
		{
			RemoteKeyboardToggle.isOn = trackedKeyboard.RemoteKeyboard;
		}
	}

	private void Update()
	{
		NameValue.text = trackedKeyboard.SystemKeyboardInfo.Name;
		ConnectedValue.text = ((trackedKeyboard.SystemKeyboardInfo.KeyboardFlags & OVRPlugin.TrackedKeyboardFlags.Connected) > (OVRPlugin.TrackedKeyboardFlags)0).ToString();
		StateValue.text = trackedKeyboard.TrackingState.ToString();
		SelectKeyboardValue.text = "Select " + trackedKeyboard.KeyboardQueryFlags.ToString() + " Keyboard";
		TypeValue.text = trackedKeyboard.KeyboardQueryFlags.ToString();
		switch (trackedKeyboard.TrackingState)
		{
		case OVRTrackedKeyboard.TrackedKeyboardState.Uninitialized:
		case OVRTrackedKeyboard.TrackedKeyboardState.StartedNotTracked:
		case OVRTrackedKeyboard.TrackedKeyboardState.Stale:
		case OVRTrackedKeyboard.TrackedKeyboardState.Error:
		case OVRTrackedKeyboard.TrackedKeyboardState.ErrorExtensionFailed:
			StateValue.color = BadStateColor;
			break;
		default:
			StateValue.color = GoodStateColor;
			break;
		}
	}

	public void SetPresentationOpaque()
	{
		trackedKeyboard.Presentation = OVRTrackedKeyboard.KeyboardPresentation.PreferOpaque;
	}

	public void SetPresentationKeyLabels()
	{
		trackedKeyboard.Presentation = OVRTrackedKeyboard.KeyboardPresentation.PreferKeyLabels;
	}

	public void LaunchKeyboardSelection()
	{
		if (trackedKeyboard.RemoteKeyboard)
		{
			trackedKeyboard.LaunchRemoteKeyboardSelectionDialog();
		}
		else
		{
			trackedKeyboard.LaunchLocalKeyboardSelectionDialog();
		}
	}

	public void SetTrackingEnabled(bool value)
	{
		trackedKeyboard.TrackingEnabled = value;
	}
}
