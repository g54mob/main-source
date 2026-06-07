using System.Collections.Generic;
using DV.VRTK_Extensions;
using TMPro;
using UnityEngine;
using VRTK;

public class ControllerInputTooltips : MonoBehaviour
{
	[SerializeField]
	private GameObject tooltipPrefab;

	[SerializeField]
	private GameObject lineEndSpherePrefab;

	private const float LINE_BRAK_THRESHOLD = 0.707f;

	private const string TOUCHPAD_TWO_NAME = "thumbstick/attach";

	private const string INDEX_BUTTON_ONE_NAME = "button_a/attach";

	private const string INDEX_BUTTON_TWO_NAME = "button_b/attach";

	private const string INDEX_GRIP_NAME = "squeeze/attach";

	private const string WMR_BUTTON_TWO_NAME = "menu_button/attach";

	private const string COSMOS_TOUCHPAD_NAME = "joystick/attach";

	private const string COSMOS_BUTTON_ONE_NAME = "button/attach";

	private const string COSMOS_BUTTON_TWO_NAME = "buttonB/attach";

	private const string HP_REVERB_G2_BUTTON_ONE_LEFT_NAME = "A/attach";

	private const string HP_REVERB_G2_BUTTON_ONE_RIGHT_NAME = "X/attach";

	private const string HP_REVERB_G2_BUTTON_TWO_NAME = "menu_button/attach";

	private const string HP_REVERB_G2_TOUCHPAD_NAME = "thumbstick/attach";

	private Transform headsetTransform;

	private Vector3 offsetY = new Vector3(0f, 0.125f, 0f);

	private float offsetXZ = -0.05f;

	private bool initialized;

	private Transform referencePipaTransform;

	private Transform currentElementTransform;

	private Transform tooltipTransform;

	private TextMeshPro tooltipText;

	private LineRenderer lineRenderer;

	private Transform lineEndSphere;

	private readonly Dictionary<SDK_BaseController.ControllerElements, string> controllerElementTooltips = new Dictionary<SDK_BaseController.ControllerElements, string>
	{
		{
			SDK_BaseController.ControllerElements.Trigger,
			"Trigger"
		},
		{
			SDK_BaseController.ControllerElements.GripLeft,
			"Grip"
		},
		{
			SDK_BaseController.ControllerElements.GripRight,
			"Grip"
		},
		{
			SDK_BaseController.ControllerElements.Touchpad,
			"Touchpad"
		},
		{
			SDK_BaseController.ControllerElements.ButtonOne,
			"Button one"
		},
		{
			SDK_BaseController.ControllerElements.ButtonTwo,
			"Button two"
		},
		{
			SDK_BaseController.ControllerElements.SystemMenu,
			"System menu"
		},
		{
			SDK_BaseController.ControllerElements.TouchpadTwo,
			"Touchpad two"
		},
		{
			SDK_BaseController.ControllerElements.AttachPoint,
			"Attach point"
		},
		{
			SDK_BaseController.ControllerElements.StartMenu,
			"Start menu"
		},
		{
			SDK_BaseController.ControllerElements.Body,
			"Controller body"
		}
	};

	private readonly HashSet<SDK_BaseController.ControllerElements> topElements = new HashSet<SDK_BaseController.ControllerElements>
	{
		SDK_BaseController.ControllerElements.AttachPoint,
		SDK_BaseController.ControllerElements.Touchpad,
		SDK_BaseController.ControllerElements.ButtonTwo,
		SDK_BaseController.ControllerElements.ButtonTwo,
		SDK_BaseController.ControllerElements.SystemMenu,
		SDK_BaseController.ControllerElements.StartMenu,
		SDK_BaseController.ControllerElements.Body
	};

	private readonly HashSet<SDK_BaseController.ControllerElements> bottomElements = new HashSet<SDK_BaseController.ControllerElements> { SDK_BaseController.ControllerElements.Trigger };

	private readonly HashSet<SDK_BaseController.ControllerElements> sideElements = new HashSet<SDK_BaseController.ControllerElements>
	{
		SDK_BaseController.ControllerElements.GripRight,
		SDK_BaseController.ControllerElements.GripLeft
	};

	private void Start()
	{
		tooltipTransform = Object.Instantiate(tooltipPrefab).transform;
		tooltipText = tooltipTransform.GetComponentInChildren<TextMeshPro>(includeInactive: true);
		lineRenderer = tooltipTransform.GetComponentInChildren<LineRenderer>(includeInactive: true);
		lineRenderer.positionCount = 2;
		LineRenderer obj = lineRenderer;
		float startWidth = (lineRenderer.endWidth = 0.002f);
		obj.startWidth = startWidth;
		lineEndSphere = Object.Instantiate(lineEndSpherePrefab).transform;
		tooltipTransform.gameObject.SetActive(value: false);
		initialized = true;
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			Object.Destroy(tooltipTransform.gameObject);
			Object.Destroy(lineEndSphere.gameObject);
		}
	}

	private Transform GetElementTransformAndSetDependecies(SDK_BaseController.ControllerElements element, SDK_BaseController.ControllerHand hand, bool isIndex)
	{
		if (hand == SDK_BaseController.ControllerHand.None)
		{
			Debug.LogError(string.Format("{0} needs a proper hand value to find the element '{1}'.", "ControllerInputTooltips", element), this);
			return null;
		}
		string text;
		switch (VRTK_DeviceFinder.GetControllerReferenceForHand(hand).GetControllerTypeDV())
		{
		case ControllerType_DV.ValveIndex:
			switch (element)
			{
			case SDK_BaseController.ControllerElements.GripLeft:
			case SDK_BaseController.ControllerElements.GripRight:
				text = "squeeze/attach";
				break;
			case SDK_BaseController.ControllerElements.ButtonOne:
				text = "button_a/attach";
				break;
			case SDK_BaseController.ControllerElements.ButtonTwo:
				text = "button_b/attach";
				break;
			case SDK_BaseController.ControllerElements.TouchpadTwo:
				text = "thumbstick/attach";
				break;
			default:
				text = VRTK_SDK_Bridge.GetControllerElementPath(element, hand, fullPath: true);
				break;
			}
			break;
		case ControllerType_DV.QuestTouch:
			if (VRManager.GetCurrentSDK() != VRManager.SDK.Oculus)
			{
				switch (element)
				{
				case SDK_BaseController.ControllerElements.Trigger:
					text = "trigger/attach";
					break;
				case SDK_BaseController.ControllerElements.GripLeft:
					text = "handgrip/attach";
					break;
				case SDK_BaseController.ControllerElements.GripRight:
					text = "handgrip/attach";
					break;
				case SDK_BaseController.ControllerElements.Touchpad:
					text = "thumbstick/attach";
					break;
				case SDK_BaseController.ControllerElements.ButtonOne:
					text = ((hand == SDK_BaseController.ControllerHand.Left) ? "button_x/attach" : "button_a/attach");
					break;
				case SDK_BaseController.ControllerElements.ButtonTwo:
					text = ((hand == SDK_BaseController.ControllerHand.Left) ? "button_y/attach" : "button_b/attach");
					break;
				case SDK_BaseController.ControllerElements.TouchpadTwo:
					text = "thumbstick/attach";
					break;
				default:
					text = null;
					break;
				}
			}
			else
			{
				text = VRTK_SDK_Bridge.GetControllerElementPath(element, hand, fullPath: true);
			}
			break;
		case ControllerType_DV.WMR:
			text = ((element != SDK_BaseController.ControllerElements.ButtonTwo) ? VRTK_SDK_Bridge.GetControllerElementPath(element, hand, fullPath: true) : "menu_button/attach");
			break;
		case ControllerType_DV.HPReverbG2:
			switch (element)
			{
			case SDK_BaseController.ControllerElements.Touchpad:
			case SDK_BaseController.ControllerElements.TouchpadTwo:
				text = "thumbstick/attach";
				break;
			case SDK_BaseController.ControllerElements.ButtonOne:
				text = ((hand == SDK_BaseController.ControllerHand.Left) ? "A/attach" : "X/attach");
				break;
			case SDK_BaseController.ControllerElements.ButtonTwo:
				text = "menu_button/attach";
				break;
			default:
				text = VRTK_SDK_Bridge.GetControllerElementPath(element, hand, fullPath: true);
				break;
			}
			break;
		case ControllerType_DV.Cosmos:
			switch (element)
			{
			case SDK_BaseController.ControllerElements.Touchpad:
			case SDK_BaseController.ControllerElements.TouchpadTwo:
				text = "joystick/attach";
				break;
			case SDK_BaseController.ControllerElements.ButtonOne:
				text = "button/attach";
				break;
			case SDK_BaseController.ControllerElements.ButtonTwo:
				text = "buttonB/attach";
				break;
			default:
				text = VRTK_SDK_Bridge.GetControllerElementPath(element, hand, fullPath: true);
				break;
			}
			break;
		default:
			text = ((element != SDK_BaseController.ControllerElements.TouchpadTwo) ? VRTK_SDK_Bridge.GetControllerElementPath(element, hand, fullPath: true) : "thumbstick/attach");
			break;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		GameObject gameObject = ((hand == SDK_BaseController.ControllerHand.Right) ? VRTK_DeviceFinder.GetControllerRightHand() : VRTK_DeviceFinder.GetControllerLeftHand());
		Transform result = (VRTK_SDK_Bridge.GetControllerModel(gameObject)?.transform)?.Find(text);
		referencePipaTransform = PipaUtils.PipaTransform(gameObject);
		return result;
	}

	public void HideTooltip()
	{
		tooltipText.text = string.Empty;
		referencePipaTransform = null;
		currentElementTransform = null;
		lineEndSphere.gameObject.SetActive(value: false);
		tooltipTransform.gameObject.SetActive(value: false);
	}

	public void ShowTooltip(string text, SDK_BaseController.ControllerElements element, SDK_BaseController.ControllerHand hand, bool checkForIndexMissingStrings)
	{
		if (headsetTransform == null)
		{
			headsetTransform = VRTK_DeviceFinder.HeadsetCamera().transform;
		}
		currentElementTransform = GetElementTransformAndSetDependecies(element, hand, checkForIndexMissingStrings);
		if (currentElementTransform == null)
		{
			HideTooltip();
			return;
		}
		tooltipText.text = text;
		lineEndSphere.gameObject.SetActive(value: true);
		tooltipTransform.gameObject.SetActive(value: true);
	}

	private void Update()
	{
		if (initialized && !(tooltipTransform == null) && !(currentElementTransform == null))
		{
			Vector3 normalized = (tooltipTransform.position - headsetTransform.position).normalized;
			Vector3 vector = normalized * offsetXZ;
			vector.y = 0f;
			tooltipTransform.position = currentElementTransform.position + vector + offsetY;
			tooltipTransform.rotation = Quaternion.LookRotation(normalized, Vector3.up);
			lineRenderer.SetPosition(0, lineRenderer.transform.position);
			lineRenderer.SetPosition(1, currentElementTransform.position);
			lineEndSphere.position = currentElementTransform.position;
		}
	}
}
