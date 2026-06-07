using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using Valve.VR;

[ExecuteAfter(typeof(PlayerInstantiator))]
public class ControllerMapping : MonoBehaviour
{
	public HashSet<VRTK_ControllerEvents> allControllerEvents = new HashSet<VRTK_ControllerEvents>();

	public List<VRTK_ControllerEvents.ButtonAlias> allButtons = new List<VRTK_ControllerEvents.ButtonAlias>();

	public HeadsetType_DV headsetType;

	public bool initialized;

	public bool rightStateChanged;

	public bool leftStateChanged;

	public GameObject buttonHolder;

	public GameObject indicatorHolderRight;

	public GameObject indicatorHolderLeft;

	public Text[] buttonTexts;

	public RawImage[] buttonIndicatorsRight;

	public RawImage[] buttonIndicatorsLeft;

	public Dictionary<VRTK_ControllerEvents.ButtonAlias, RawImage> indicatorDictionaryRight = new Dictionary<VRTK_ControllerEvents.ButtonAlias, RawImage>();

	public Dictionary<VRTK_ControllerEvents.ButtonAlias, RawImage> indicatorDictionaryLeft = new Dictionary<VRTK_ControllerEvents.ButtonAlias, RawImage>();

	public Text headsetText;

	public Text axisOneRightText;

	public Text axisOneLeftText;

	public Text axisTwoRightText;

	public Text axisTwoLeftText;

	public Text controllerTypeTextLeft;

	public Text controllerTypeTextRight;

	public Text controllerModelTextLeft;

	public Text controllerModelTextRight;

	public Button reloadDefaultAnchorsButton;

	public Button saveAnchorsButton;

	public Button loadAnchorsButton;

	private IEnumerator Start()
	{
		if (!VRManager.IsVREnabled())
		{
			Debug.LogError("Non-VR mode detected. This test needs to be done in VR mode. Destroying self.", this);
			UnityEngine.Object.Destroy(this);
			yield break;
		}
		VRTK_SDKManager.instance?.AddBehaviourToToggleOnLoadedSetupChange(this);
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
		while (PlayerManager.PlayerTransform == null)
		{
			yield return null;
		}
		allButtons = Enum.GetValues(typeof(VRTK_ControllerEvents.ButtonAlias)).Cast<VRTK_ControllerEvents.ButtonAlias>().ToList();
		buttonTexts = buttonHolder.GetComponentsInChildren<Text>();
		buttonIndicatorsRight = indicatorHolderRight.GetComponentsInChildren<RawImage>();
		buttonIndicatorsLeft = indicatorHolderLeft.GetComponentsInChildren<RawImage>();
		CreateButtonIndicatorDictionary();
		headsetType = HeadsetUtils.GetHeadsetTypeDV();
		headsetText.text = headsetType.ToString();
		initialized = true;
		reloadDefaultAnchorsButton.onClick.AddListener(PipaUtils.LoadDefaultAnchorData);
		saveAnchorsButton.onClick.AddListener(PipaUtils.SaveAnchorData);
		loadAnchorsButton.onClick.AddListener(PipaUtils.LoadAnchorDataFromDisk);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isQuitting)
		{
			VRTK_SDKManager.instance?.RemoveBehaviourToToggleOnLoadedSetupChange(this);
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand hand)
	{
		switch (hand)
		{
		case SDK_BaseController.ControllerHand.Right:
		{
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			VRTK_ControllerEvents componentInChildren2 = controllerRightHand.GetComponentInChildren<VRTK_ControllerEvents>(includeInactive: true);
			DisplayControllerData(hand);
			if (componentInChildren2 != null)
			{
				if (!allControllerEvents.Contains(componentInChildren2))
				{
					allControllerEvents.Add(componentInChildren2);
					PrintControllerData(controllerRightHand, hand);
				}
			}
			else
			{
				Debug.LogError(string.Format("Could not find '{0}' on '{1}' controller", "VRTK_ControllerEvents", hand), this);
			}
			break;
		}
		case SDK_BaseController.ControllerHand.Left:
		{
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			VRTK_ControllerEvents componentInChildren = controllerLeftHand.GetComponentInChildren<VRTK_ControllerEvents>(includeInactive: true);
			DisplayControllerData(hand);
			if (componentInChildren != null)
			{
				if (!allControllerEvents.Contains(componentInChildren))
				{
					allControllerEvents.Add(componentInChildren);
					PrintControllerData(controllerLeftHand, hand);
				}
			}
			else
			{
				Debug.LogError(string.Format("Could not find '{0}' on '{1}' controller", "VRTK_ControllerEvents", hand), this);
			}
			break;
		}
		default:
			Debug.LogError("Given controller doesn't have a defined hand. This should not happen.");
			break;
		}
		if (TransmogrifyControllers.IsControllerReadyRight && TransmogrifyControllers.IsControllerReadyLeft)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}
	}

	private void DisplayControllerData(SDK_BaseController.ControllerHand hand)
	{
		bool num = hand == SDK_BaseController.ControllerHand.Right;
		Text text = (num ? controllerTypeTextRight : controllerTypeTextLeft);
		Text obj = (num ? controllerModelTextRight : controllerModelTextLeft);
		VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(hand);
		text.text = controllerReferenceForHand.GetControllerTypeDV().ToString();
		obj.text = GetModelNumberValve(controllerReferenceForHand.index);
	}

	private void PrintControllerData(GameObject controller, SDK_BaseController.ControllerHand hand)
	{
		GameObject controllerModel = VRTK_SDK_Bridge.GetControllerModel(controller);
		if (controllerModel == null)
		{
			Debug.LogError($"Controller data for controller '{controller}' could not be determined", this);
			return;
		}
		VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(hand);
		Debug.Log($"Controller data for controller '{controller}' is:");
		Debug.Log($"Controller type is: '{controllerReferenceForHand.GetControllerTypeDV()}'");
		Debug.Log("Controller model number is: '" + GetModelNumberValve(controllerReferenceForHand.index) + "'");
		int childCount = controllerModel.transform.childCount;
		if (childCount <= 0)
		{
			Debug.LogError("Model has no children.");
		}
		for (int i = 0; i < childCount; i++)
		{
			Transform child = controllerModel.transform.GetChild(i);
			string arg = ((child != null) ? child.name : "CHILD NOT FOUND");
			bool flag = child.Find("attach") != null;
			Debug.Log($"Model child[{i}] name is: '{arg}' and attach point is presence is: '{flag}'");
		}
	}

	private string GetModelNumberValve(uint index)
	{
		return ((SteamVR.instance != null) ? SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ModelNumber_String, index) : "").ToLower();
	}

	private void CreateButtonIndicatorDictionary()
	{
		allButtons.Remove(VRTK_ControllerEvents.ButtonAlias.Undefined);
		for (int i = 0; i < allButtons.Count; i++)
		{
			indicatorDictionaryRight.Add(allButtons[i], buttonIndicatorsRight[i]);
			indicatorDictionaryLeft.Add(allButtons[i], buttonIndicatorsLeft[i]);
		}
	}

	private void Update()
	{
		if (!initialized || allControllerEvents.Count <= 0)
		{
			return;
		}
		ResetIndicators();
		foreach (VRTK_ControllerEvents allControllerEvent in allControllerEvents)
		{
			bool flag = VRTK_DeviceFinder.IsControllerRightHand(allControllerEvent.gameObject);
			VRTK_ControllerReference controllerReference = ((!flag) ? VRTK_DeviceFinder.GetControllerReferenceLeftHand() : (controllerReference = VRTK_DeviceFinder.GetControllerReferenceRightHand()));
			Vector2 controllerAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Touchpad, controllerReference);
			Vector2 controllerAxis2 = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.TouchpadTwo, controllerReference);
			if (flag)
			{
				axisOneRightText.text = controllerAxis.ToString();
				axisTwoRightText.text = controllerAxis2.ToString();
			}
			else
			{
				axisOneLeftText.text = controllerAxis.ToString();
				axisTwoLeftText.text = controllerAxis2.ToString();
			}
			foreach (VRTK_ControllerEvents.ButtonAlias allButton in allButtons)
			{
				if (allControllerEvent.IsButtonPressed(allButton))
				{
					if (flag)
					{
						indicatorDictionaryRight[allButton].color = Color.green;
					}
					else
					{
						indicatorDictionaryLeft[allButton].color = Color.green;
					}
				}
			}
		}
	}

	private void ResetIndicators()
	{
		RawImage[] array = buttonIndicatorsRight;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = Color.red;
		}
		array = buttonIndicatorsLeft;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = Color.red;
		}
	}
}
