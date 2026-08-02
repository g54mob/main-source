using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UltimateRadialMenuInputManager : MonoBehaviour
{
	public class UltimateRadialMenuInfomation
	{
		public UltimateRadialMenu radialMenu;

		public bool lastRadialMenuState;
	}

	public enum InvokeAction
	{
		OnButtonDown = 0,
		OnButtonClick = 1
	}

	private class TouchHoldInformation
	{
		public float currentHoldTime;

		public int interactFingerID = -1;

		public UltimateRadialMenu radialMenu;

		public bool touchActivatedRadialMenu;

		public void ResetMenuPosition()
		{
			if (touchActivatedRadialMenu)
			{
				touchActivatedRadialMenu = false;
				if (radialMenu != null)
				{
					radialMenu.ResetPosition();
				}
			}
		}
	}

	private Camera mainCamera;

	[Header("Interact Settings")]
	[Tooltip("The action required to invoke the radial button.")]
	public InvokeAction invokeAction;

	[Tooltip("Determines whether or not the Ultimate Radial Menu will receive input when the Ultimate Radial Menu is released and disabled.")]
	public bool onMenuRelease;

	[Tooltip("Determines if the Ultimate Radial Menu should be disabled when the interaction occurs. \n\nNOTE: World space radial menus will not be disabled on interact. They must be disabled manually.")]
	public bool disableOnInteract;

	[Header("Mouse and Keyboard Settings")]
	[Tooltip("Determines if mouse and keyboard input should be used to send to the Ultimate Radial Menu.")]
	public bool keyboardInput = true;

	[Tooltip("The mouse button index to use for interacting.")]
	public int mouseButtonIndex;

	[Tooltip("Determines if this Input Manager should handle the Enabling/Disabling of the Ultimate Radial Menu or if the user will do it manually.")]
	public bool enableWithKeyboard = true;

	[Header("Controller Settings")]
	[Tooltip("Determines if controller input should be used to send to the Ultimate Radial Menu.")]
	public bool controllerInput;

	[Tooltip("The input key for the controller horizontal axis.")]
	public string horizontalAxisController = "Horizontal";

	[Tooltip("The input key for the controller vertical axis.")]
	public string verticalAxisController = "Vertical";

	[Tooltip("The input key for the controller button interaction.")]
	public string interactButtonController = "Cancel";

	[Tooltip("Determines if this Input Manager should handle the Enabling/Disabling of the Ultimate Radial Menu or if the user will do it manually.")]
	public bool enableWithController = true;

	[Tooltip("The input key used for enabling and disabling the Ultimate Radial Menu.")]
	public string enableButtonController = "Submit";

	[Tooltip("Determines if the horizontal input should be inverted or not.")]
	public bool invertHorizontal;

	[Tooltip("Determines if the vertical input should be inverted or not.")]
	public bool invertVertical;

	[Header("Touch Settings")]
	[Tooltip("Determines if touch input should be used to send to the Ultimate Radial Menu.")]
	public bool touchInput;

	[Tooltip("Determines if this Input Manager should handle the Enabling/Disabling of the Ultimate Radial Menu or if the user will do it manually.")]
	public bool enableWithTouch = true;

	[Tooltip("Should the radial menu move to the initial touch position?")]
	public bool dynamicPositioning;

	[Range(0f, 2f)]
	[Tooltip("The activation radius for enabling the menu.")]
	public float activationRadius = 0.25f;

	[Tooltip("Time in seconds that the user needs to hold the touch within the activation radius.")]
	public float activationHoldTime = 0.25f;

	private List<TouchHoldInformation> TouchHoldInformations = new List<TouchHoldInformation>();

	private bool touchInformationReset = true;

	[Header("Virtual Reality Settings")]
	[Tooltip("Determines if the menu should activated by the center of the screen.")]
	public bool virtualRealityInput;

	[Tooltip("The input key for the virtual reality button interaction.")]
	public string interactButtonVirtualReality = "Submit";

	[Header("Custom Input Settings")]
	public bool customInput;

	public static UltimateRadialMenuInputManager Instance { get; private set; }

	public List<UltimateRadialMenuInfomation> UltimateRadialMenuInformations { get; private set; }

	[Tooltip("The input key used for enabling and disabling the Ultimate Radial Menu.")]
	public KeyCode enableButtonKeyboard => Singleton<UserPrefencesManager>.Instance.keyData.RadialSelectMenuKey;

	private void Awake()
	{
		if (!GetComponent<EventSystem>())
		{
			Debug.LogError("Ultimate Radial Menu Input Manager\nThis component is not attached to the EventSystem in your scene. Please make sure that you have only one Ultimate Radial Menu Input Manager in your scene and that it is located on the EventSystem.");
			Object.Destroy(this);
		}
		else
		{
			Instance = this;
			UltimateRadialMenuInformations = new List<UltimateRadialMenuInfomation>();
		}
	}

	private void Start()
	{
		UpdateCamera();
	}

	public void AddRadialMenuToList(UltimateRadialMenu radialMenu)
	{
		UltimateRadialMenuInformations.Add(new UltimateRadialMenuInfomation
		{
			radialMenu = radialMenu
		});
		if (touchInput)
		{
			TouchHoldInformations.Add(new TouchHoldInformation
			{
				radialMenu = radialMenu
			});
			radialMenu.OnRadialMenuDisabled += TouchHoldInformations[TouchHoldInformations.Count - 1].ResetMenuPosition;
		}
	}

	private void UpdateCamera()
	{
		Camera[] array = Object.FindObjectsOfType<Camera>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].gameObject.activeInHierarchy && array[i].enabled)
			{
				mainCamera = array[i];
				if (array[i].tag == "MainCamera")
				{
					break;
				}
			}
		}
	}

	public void SetMainCamera(Camera newMainCamera)
	{
		mainCamera = newMainCamera;
	}

	private void RaycastWorldSpaceRadialMenu(ref Vector2 input, ref float distance, Vector2 rayOrigin, int radialMenuIndex)
	{
		if (UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu)
		{
			if (mainCamera == null || !mainCamera.gameObject.activeInHierarchy || !mainCamera.enabled)
			{
				UpdateCamera();
			}
			if (Physics.Raycast(mainCamera.ScreenPointToRay(rayOrigin), out var hitInfo, float.PositiveInfinity) && hitInfo.collider.gameObject == UltimateRadialMenuInformations[radialMenuIndex].radialMenu.gameObject)
			{
				Vector3 vector = UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.InverseTransformPoint(hitInfo.point);
				input = vector;
				distance = Vector3.Distance(Vector2.zero, vector);
			}
		}
	}

	private void Update()
	{
		for (int i = 0; i < UltimateRadialMenuInformations.Count; i++)
		{
			if (UltimateRadialMenuInformations[i].radialMenu == null)
			{
				UltimateRadialMenuInformations.RemoveAt(i);
				if (touchInput)
				{
					TouchHoldInformations.RemoveAt(i);
				}
				break;
			}
			bool enableMenu = false;
			bool disableMenu = false;
			bool inputDown = false;
			bool inputUp = false;
			Vector2 input = Vector2.zero;
			float distance = 0f;
			if (keyboardInput)
			{
				MouseAndKeyboardInput(ref enableMenu, ref disableMenu, ref input, ref distance, ref inputDown, ref inputUp, i);
			}
			if (controllerInput)
			{
				ControllerInput(ref enableMenu, ref disableMenu, ref input, ref distance, ref inputDown, ref inputUp, i);
			}
			if (touchInput)
			{
				TouchInput(ref enableMenu, ref disableMenu, ref input, ref distance, ref inputDown, ref inputUp, i);
			}
			if (virtualRealityInput)
			{
				VirtualRealityInput(ref enableMenu, ref disableMenu, ref input, ref distance, ref inputDown, ref inputUp, i);
			}
			if (customInput)
			{
				CustomInput(ref enableMenu, ref disableMenu, ref input, ref distance, ref inputDown, ref inputUp, i);
			}
			if (onMenuRelease && UltimateRadialMenuInformations[i].lastRadialMenuState && disableMenu)
			{
				inputDown = (inputUp = true);
			}
			UltimateRadialMenuInformations[i].radialMenu.ProcessInput(input, distance, inputDown, inputUp);
			if (enableMenu)
			{
				UltimateRadialMenuInformations[i].radialMenu.EnableRadialMenu();
			}
			if (disableMenu)
			{
				UltimateRadialMenuInformations[i].radialMenu.DisableRadialMenu();
			}
			UltimateRadialMenuInformations[i].lastRadialMenuState = UltimateRadialMenuInformations[i].radialMenu.RadialMenuActive;
		}
	}

	public virtual void MouseAndKeyboardInput(ref bool enableMenu, ref bool disableMenu, ref Vector2 input, ref float distance, ref bool inputDown, ref bool inputUp, int radialMenuIndex)
	{
		if (UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu)
		{
			RaycastWorldSpaceRadialMenu(ref input, ref distance, Input.mousePosition, radialMenuIndex);
		}
		else if (Input.mousePresent)
		{
			Vector2 vector = new Vector2(Input.mousePosition.x, Input.mousePosition.y) / UltimateRadialMenuInformations[radialMenuIndex].radialMenu.ParentCanvas.scaleFactor - UltimateRadialMenuInformations[radialMenuIndex].radialMenu.ParentCanvas.GetComponent<RectTransform>().sizeDelta / 2f;
			input = (vector - (Vector2)UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.localPosition) / (UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.sizeDelta.x / 2f);
			distance = Vector2.Distance(UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.localPosition, vector);
		}
		if (Input.GetMouseButtonDown(mouseButtonIndex))
		{
			inputDown = true;
		}
		if (Input.GetMouseButtonUp(mouseButtonIndex))
		{
			inputUp = true;
		}
		if (enableWithKeyboard && !UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu && !ChatPanelController.isInputFocused)
		{
			if (Input.GetKeyDown(enableButtonKeyboard))
			{
				enableMenu = true;
			}
			else if (Input.GetKeyUp(enableButtonKeyboard))
			{
				disableMenu = true;
			}
		}
	}

	public virtual void ControllerInput(ref bool enableMenu, ref bool disableMenu, ref Vector2 input, ref float distance, ref bool inputDown, ref bool inputUp, int radialMenuIndex)
	{
		Vector2 vector = new Vector2(Input.GetAxis(horizontalAxisController), Input.GetAxis(verticalAxisController));
		if (invertHorizontal)
		{
			vector.x *= -1f;
		}
		if (invertVertical)
		{
			vector.y *= -1f;
		}
		float num = Vector2.Distance(Vector2.zero, vector);
		if (vector != Vector2.zero)
		{
			input = vector;
		}
		if (num >= UltimateRadialMenuInformations[radialMenuIndex].radialMenu.minRange)
		{
			distance = Mathf.Lerp(UltimateRadialMenuInformations[radialMenuIndex].radialMenu.CalculatedMinRange, UltimateRadialMenuInformations[radialMenuIndex].radialMenu.CalculatedMaxRange, 0.5f);
		}
		if (Input.GetButtonDown(interactButtonController))
		{
			inputDown = true;
		}
		else if (Input.GetButtonUp(interactButtonController))
		{
			inputUp = true;
		}
		if (enableWithController && enableButtonController != string.Empty && !UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu)
		{
			if (Input.GetButtonDown(enableButtonController))
			{
				enableMenu = true;
			}
			else if (Input.GetButtonUp(enableButtonController))
			{
				disableMenu = true;
			}
		}
	}

	public virtual void TouchInput(ref bool enableMenu, ref bool disableMenu, ref Vector2 input, ref float distance, ref bool inputDown, ref bool inputUp, int radialMenuIndex)
	{
		if (Input.touchCount > 0)
		{
			if (touchInformationReset)
			{
				touchInformationReset = false;
			}
			for (int i = 0; i < Input.touchCount; i++)
			{
				if (TouchHoldInformations[radialMenuIndex].interactFingerID >= 0 && TouchHoldInformations[radialMenuIndex].interactFingerID != Input.GetTouch(i).fingerId)
				{
					continue;
				}
				float num = UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.sizeDelta.x / 2f;
				Vector2 vector = Input.GetTouch(i).position / UltimateRadialMenuInformations[radialMenuIndex].radialMenu.ParentCanvas.scaleFactor - UltimateRadialMenuInformations[radialMenuIndex].radialMenu.ParentCanvas.GetComponent<RectTransform>().sizeDelta / 2f;
				Vector2 input2 = (vector - (Vector2)UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.localPosition) / num;
				float distance2 = Vector2.Distance(UltimateRadialMenuInformations[radialMenuIndex].radialMenu.BaseTransform.localPosition, vector);
				if (UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu)
				{
					RaycastWorldSpaceRadialMenu(ref input2, ref distance2, Input.GetTouch(i).position, radialMenuIndex);
				}
				if (Input.GetTouch(i).phase == TouchPhase.Began)
				{
					if (!enableWithTouch || distance2 < num * activationRadius)
					{
						TouchHoldInformations[radialMenuIndex].interactFingerID = Input.GetTouch(i).fingerId;
					}
					if (UltimateRadialMenuInformations[radialMenuIndex].radialMenu.RadialMenuActive)
					{
						float num2 = TouchHoldInformations[radialMenuIndex].radialMenu.maxRange;
						if (TouchHoldInformations[radialMenuIndex].radialMenu.infiniteMaxRange)
						{
							num2 = float.PositiveInfinity;
						}
						inputDown = true;
						if (distance2 > UltimateRadialMenuInformations[radialMenuIndex].radialMenu.CalculatedMinRange && distance2 < UltimateRadialMenuInformations[radialMenuIndex].radialMenu.CalculatedMaxRange)
						{
							TouchHoldInformations[radialMenuIndex].interactFingerID = Input.GetTouch(i).fingerId;
						}
						else if (enableWithTouch && (distance2 > num * num2 || distance2 < TouchHoldInformations[radialMenuIndex].radialMenu.CalculatedMinRange) && !UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu && activationRadius > 0f)
						{
							UltimateRadialMenuInformations[radialMenuIndex].radialMenu.DisableRadialMenu();
						}
					}
				}
				if (TouchHoldInformations[radialMenuIndex].interactFingerID == -1)
				{
					continue;
				}
				if (!UltimateRadialMenuInformations[radialMenuIndex].radialMenu.RadialMenuActive && !UltimateRadialMenuInformations[radialMenuIndex].radialMenu.InTransition)
				{
					if (enableWithTouch && distance2 < num * activationRadius)
					{
						TouchHoldInformations[radialMenuIndex].currentHoldTime += Time.deltaTime;
						if (TouchHoldInformations[radialMenuIndex].currentHoldTime >= activationHoldTime)
						{
							TouchHoldInformations[radialMenuIndex].currentHoldTime = 0f;
							UltimateRadialMenuInformations[radialMenuIndex].radialMenu.EnableRadialMenu();
							TouchHoldInformations[radialMenuIndex].touchActivatedRadialMenu = true;
							if (dynamicPositioning && !UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu)
							{
								UltimateRadialMenuInformations[radialMenuIndex].radialMenu.SetPosition(vector, local: true);
							}
						}
					}
				}
				else
				{
					input = input2;
					distance = distance2;
				}
				if (Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					TouchHoldInformations[radialMenuIndex].interactFingerID = -1;
					TouchHoldInformations[radialMenuIndex].currentHoldTime = 0f;
					inputDown = true;
					inputUp = true;
					if (enableWithTouch && UltimateRadialMenuInformations[radialMenuIndex].radialMenu.CurrentButtonIndex < 0 && distance2 > num * activationRadius && !UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu && activationRadius > 0f)
					{
						UltimateRadialMenuInformations[radialMenuIndex].radialMenu.DisableRadialMenu();
					}
				}
			}
		}
		else if (!touchInformationReset)
		{
			touchInformationReset = true;
			for (int j = 0; j < TouchHoldInformations.Count; j++)
			{
				TouchHoldInformations[j].currentHoldTime = 0f;
				TouchHoldInformations[j].interactFingerID = -1;
			}
		}
	}

	public virtual void VirtualRealityInput(ref bool enableMenu, ref bool disableMenu, ref Vector2 input, ref float distance, ref bool inputDown, ref bool inputUp, int radialMenuIndex)
	{
		if (UltimateRadialMenuInformations[radialMenuIndex].radialMenu.IsWorldSpaceRadialMenu)
		{
			RaycastWorldSpaceRadialMenu(ref input, ref distance, new Vector3(Screen.width / 2, Screen.height / 2, 0f), radialMenuIndex);
			if (Input.GetButtonDown(interactButtonVirtualReality))
			{
				inputDown = true;
			}
			else if (Input.GetButtonUp(interactButtonVirtualReality))
			{
				inputUp = true;
			}
		}
	}

	public virtual void CustomInput(ref bool enableMenu, ref bool disableMenu, ref Vector2 input, ref float distance, ref bool inputDown, ref bool inputUp, int radialMenuIndex)
	{
	}
}
