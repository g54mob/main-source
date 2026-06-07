using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRTK
{
	public class SDK_InputSimulator : MonoBehaviour
	{
		public enum MouseInputMode
		{
			Always = 0,
			RequiresButtonPress = 1
		}

		[Header("General Settings")]
		[Tooltip("Show control information in the upper left corner of the screen.")]
		public bool showControlHints = true;

		[Tooltip("Hide hands when disabling them.")]
		public bool hideHandsAtSwitch;

		[Tooltip("Reset hand position and rotation when enabling them.")]
		public bool resetHandsAtSwitch = true;

		[Tooltip("Displays an axis helper to show which axis the hands will be moved through.")]
		public bool showHandAxisHelpers = true;

		[Header("Mouse Cursor Lock Settings")]
		[Tooltip("Lock the mouse cursor to the game window.")]
		public bool lockMouseToView = true;

		[Tooltip("Whether the mouse movement always acts as input or requires a button press.")]
		public MouseInputMode mouseMovementInput;

		[Header("Manual Adjustment Settings")]
		[Tooltip("Adjust hand movement speed.")]
		public float handMoveMultiplier = 0.002f;

		[Tooltip("Adjust hand rotation speed.")]
		public float handRotationMultiplier = 0.5f;

		[Tooltip("Adjust player movement speed.")]
		public float playerMoveMultiplier = 5f;

		[Tooltip("Adjust player rotation speed.")]
		public float playerRotationMultiplier = 0.5f;

		[Tooltip("Adjust player sprint speed.")]
		public float playerSprintMultiplier = 2f;

		[Tooltip("Adjust the speed of the cursor movement in locked mode.")]
		public float lockedCursorMultiplier = 5f;

		[Tooltip("The Colour of the GameObject representing the left hand.")]
		public Color leftHandColor = Color.red;

		[Tooltip("The Colour of the GameObject representing the right hand.")]
		public Color rightHandColor = Color.green;

		[Header("Operation Key Binding Settings")]
		[Tooltip("Key used to enable mouse input if a button press is required.")]
		public KeyCode mouseMovementKey = KeyCode.Mouse1;

		[Tooltip("Key used to toggle control hints on/off.")]
		public KeyCode toggleControlHints = KeyCode.F1;

		[Tooltip("Key used to toggle control hints on/off.")]
		public KeyCode toggleMouseLock = KeyCode.F4;

		[Tooltip("Key used to switch between left and righ hand.")]
		public KeyCode changeHands = KeyCode.Tab;

		[Tooltip("Key used to switch hands On/Off.")]
		public KeyCode handsOnOff = KeyCode.LeftAlt;

		[Tooltip("Key used to switch between positional and rotational movement.")]
		public KeyCode rotationPosition = KeyCode.LeftShift;

		[Tooltip("Key used to switch between X/Y and X/Z axis.")]
		public KeyCode changeAxis = KeyCode.LeftControl;

		[Tooltip("Key used to distance pickup with left hand.")]
		public KeyCode distancePickupLeft = KeyCode.Mouse0;

		[Tooltip("Key used to distance pickup with right hand.")]
		public KeyCode distancePickupRight = KeyCode.Mouse1;

		[Tooltip("Key used to enable distance pickup.")]
		public KeyCode distancePickupModifier = KeyCode.LeftControl;

		[Header("Movement Key Binding Settings")]
		[Tooltip("Key used to move forward.")]
		public KeyCode moveForward = KeyCode.W;

		[Tooltip("Key used to move to the left.")]
		public KeyCode moveLeft = KeyCode.A;

		[Tooltip("Key used to move backwards.")]
		public KeyCode moveBackward = KeyCode.S;

		[Tooltip("Key used to move to the right.")]
		public KeyCode moveRight = KeyCode.D;

		[Tooltip("Key used to sprint.")]
		public KeyCode sprint = KeyCode.LeftShift;

		[Header("Controller Key Binding Settings")]
		[Tooltip("Key used to simulate trigger button.")]
		public KeyCode triggerAlias = KeyCode.Mouse1;

		[Tooltip("Key used to simulate grip button.")]
		public KeyCode gripAlias = KeyCode.Mouse0;

		[Tooltip("Key used to simulate touchpad button.")]
		public KeyCode touchpadAlias = KeyCode.Q;

		[Tooltip("Key used to simulate button one.")]
		public KeyCode buttonOneAlias = KeyCode.E;

		[Tooltip("Key used to simulate button two.")]
		public KeyCode buttonTwoAlias = KeyCode.R;

		[Tooltip("Key used to simulate start menu button.")]
		public KeyCode startMenuAlias = KeyCode.F;

		[Tooltip("Key used to switch between button touch and button press mode.")]
		public KeyCode touchModifier = KeyCode.T;

		[Tooltip("Key used to switch between hair touch mode.")]
		public KeyCode hairTouchModifier = KeyCode.H;

		protected bool isHand;

		protected GameObject hintCanvas;

		protected Text hintText;

		protected Transform rightHand;

		protected Transform leftHand;

		protected Transform currentHand;

		protected Vector3 oldPos;

		protected Transform neck;

		protected SDK_ControllerSim rightController;

		protected SDK_ControllerSim leftController;

		protected static GameObject cachedCameraRig;

		protected static bool destroyed;

		protected float sprintMultiplier = 1f;

		protected GameObject crossHairPanel;

		protected Transform leftHandHorizontalAxisGuide;

		protected Transform leftHandVerticalAxisGuide;

		protected Transform rightHandHorizontalAxisGuide;

		protected Transform rightHandVerticalAxisGuide;

		public static GameObject FindInScene()
		{
			if (cachedCameraRig == null && !destroyed)
			{
				cachedCameraRig = VRTK_SharedMethods.FindEvenInactiveGameObject<SDK_InputSimulator>(null, searchAllScenes: true);
				if (!cachedCameraRig)
				{
					VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "[VRSimulator_CameraRig]", "SDK_InputSimulator", ". check that the `VRTK/Prefabs/CameraRigs/[VRSimulator_CameraRig]` prefab been added to the scene."));
				}
			}
			return cachedCameraRig;
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			hintCanvas = base.transform.Find("Canvas/Control Hints").gameObject;
			crossHairPanel = base.transform.Find("Canvas/CrosshairPanel").gameObject;
			hintText = hintCanvas.GetComponentInChildren<Text>();
			hintCanvas.SetActive(showControlHints);
			rightHand = base.transform.Find("RightHand");
			rightHand.gameObject.SetActive(value: false);
			leftHand = base.transform.Find("LeftHand");
			leftHand.gameObject.SetActive(value: false);
			leftHandHorizontalAxisGuide = leftHand.Find("Guides/HorizontalPlane");
			leftHandVerticalAxisGuide = leftHand.Find("Guides/VerticalPlane");
			rightHandHorizontalAxisGuide = rightHand.Find("Guides/HorizontalPlane");
			rightHandVerticalAxisGuide = rightHand.Find("Guides/VerticalPlane");
			currentHand = rightHand;
			oldPos = Input.mousePosition;
			neck = base.transform.Find("Neck");
			SetHandColor(leftHand, leftHandColor);
			SetHandColor(rightHand, rightHandColor);
			rightController = rightHand.GetComponent<SDK_ControllerSim>();
			leftController = leftHand.GetComponent<SDK_ControllerSim>();
			rightController.selected = true;
			leftController.selected = false;
			destroyed = false;
			SDK_SimController sDK_SimController = VRTK_SDK_Bridge.GetControllerSDK() as SDK_SimController;
			if (sDK_SimController != null)
			{
				Dictionary<string, KeyCode> keyMappings = new Dictionary<string, KeyCode>
				{
					{ "Trigger", triggerAlias },
					{ "Grip", gripAlias },
					{ "TouchpadPress", touchpadAlias },
					{ "ButtonOne", buttonOneAlias },
					{ "ButtonTwo", buttonTwoAlias },
					{ "StartMenu", startMenuAlias },
					{ "TouchModifier", touchModifier },
					{ "HairTouchModifier", hairTouchModifier }
				};
				sDK_SimController.SetKeyMappings(keyMappings);
			}
			rightHand.gameObject.SetActive(value: true);
			leftHand.gameObject.SetActive(value: true);
			crossHairPanel.SetActive(value: false);
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
			destroyed = true;
		}

		protected virtual void Update()
		{
			if (Input.GetKeyDown(toggleControlHints))
			{
				showControlHints = !showControlHints;
				hintCanvas.SetActive(showControlHints);
			}
			if (Input.GetKeyDown(toggleMouseLock))
			{
				lockMouseToView = !lockMouseToView;
			}
			if (mouseMovementInput == MouseInputMode.RequiresButtonPress)
			{
				if (lockMouseToView)
				{
					Cursor.lockState = (Input.GetKey(mouseMovementKey) ? CursorLockMode.Locked : CursorLockMode.None);
				}
				else if (Input.GetKeyDown(mouseMovementKey))
				{
					oldPos = Input.mousePosition;
				}
			}
			else
			{
				Cursor.lockState = (lockMouseToView ? CursorLockMode.Locked : CursorLockMode.None);
			}
			if (Input.GetKeyDown(handsOnOff))
			{
				if (isHand)
				{
					SetMove();
					ToggleGuidePlanes(horizontalState: false, verticalState: false);
				}
				else
				{
					SetHand();
				}
			}
			if (Input.GetKeyDown(changeHands))
			{
				if (currentHand.name == "LeftHand")
				{
					currentHand = rightHand;
					rightController.selected = true;
					leftController.selected = false;
				}
				else
				{
					currentHand = leftHand;
					rightController.selected = false;
					leftController.selected = true;
				}
			}
			if (isHand)
			{
				UpdateHands();
			}
			else
			{
				UpdateRotation();
				if (Input.GetKeyDown(distancePickupRight) && Input.GetKey(distancePickupModifier))
				{
					TryPickup(rightHand: true);
				}
				else if (Input.GetKeyDown(distancePickupLeft) && Input.GetKey(distancePickupModifier))
				{
					TryPickup(rightHand: false);
				}
				if (Input.GetKey(sprint))
				{
					sprintMultiplier = playerSprintMultiplier;
				}
				else
				{
					sprintMultiplier = 1f;
				}
				if (Input.GetKeyDown(distancePickupModifier))
				{
					crossHairPanel.SetActive(value: true);
				}
				else if (Input.GetKeyUp(distancePickupModifier))
				{
					crossHairPanel.SetActive(value: false);
				}
			}
			UpdatePosition();
			if (showControlHints)
			{
				UpdateHints();
			}
		}

		protected virtual void SetHandColor(Transform hand, Color givenColor)
		{
			Transform transform = hand.Find("Hand");
			if (transform != null && givenColor != Color.clear)
			{
				Renderer[] componentsInChildren = transform.GetComponentsInChildren<Renderer>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].material.color = givenColor;
				}
			}
		}

		protected virtual void TryPickup(bool rightHand)
		{
			if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out var hitInfo) && hitInfo.collider.gameObject.GetComponent<VRTK_InteractableObject>() != null)
			{
				GameObject gameObject = ((!rightHand) ? VRTK_DeviceFinder.GetControllerLeftHand() : VRTK_DeviceFinder.GetControllerRightHand());
				VRTK_InteractGrab component = gameObject.GetComponent<VRTK_InteractGrab>();
				if (component.GetGrabbedObject() == null)
				{
					gameObject.GetComponent<VRTK_InteractTouch>().ForceTouch(hitInfo.collider.gameObject);
					component.AttemptGrab();
				}
			}
		}

		protected virtual void UpdateHands()
		{
			Vector3 mouseDelta = GetMouseDelta();
			if (!IsAcceptingMouseInput())
			{
				return;
			}
			if (Input.GetKey(changeAxis))
			{
				ToggleGuidePlanes(horizontalState: false, verticalState: true);
				if (Input.GetKey(rotationPosition))
				{
					Vector3 zero = Vector3.zero;
					zero.x += (mouseDelta * handRotationMultiplier).y;
					zero.y += (mouseDelta * handRotationMultiplier).x;
					currentHand.transform.Rotate(zero * Time.deltaTime);
				}
				else
				{
					Vector3 zero2 = Vector3.zero;
					zero2 += mouseDelta * handMoveMultiplier;
					currentHand.transform.Translate(zero2 * Time.deltaTime);
				}
				return;
			}
			ToggleGuidePlanes(horizontalState: true, verticalState: false);
			if (Input.GetKey(rotationPosition))
			{
				Vector3 zero3 = Vector3.zero;
				zero3.z += (mouseDelta * handRotationMultiplier).x;
				zero3.x += (mouseDelta * handRotationMultiplier).y;
				currentHand.transform.Rotate(zero3 * Time.deltaTime);
			}
			else
			{
				Vector3 zero4 = Vector3.zero;
				zero4.x += (mouseDelta * handMoveMultiplier).x;
				zero4.z += (mouseDelta * handMoveMultiplier).y;
				currentHand.transform.Translate(zero4 * Time.deltaTime);
			}
		}

		protected virtual void UpdateRotation()
		{
			Vector3 mouseDelta = GetMouseDelta();
			if (IsAcceptingMouseInput())
			{
				Vector3 eulerAngles = base.transform.localRotation.eulerAngles;
				eulerAngles.y += (mouseDelta * playerRotationMultiplier).x;
				base.transform.localRotation = Quaternion.Euler(eulerAngles);
				eulerAngles = neck.rotation.eulerAngles;
				if (eulerAngles.x > 180f)
				{
					eulerAngles.x -= 360f;
				}
				if (eulerAngles.x < 80f && eulerAngles.x > -80f)
				{
					eulerAngles.x += (mouseDelta * playerRotationMultiplier).y * -1f;
					eulerAngles.x = Mathf.Clamp(eulerAngles.x, -79f, 79f);
					neck.rotation = Quaternion.Euler(eulerAngles);
				}
			}
		}

		protected virtual void UpdatePosition()
		{
			float num = Time.deltaTime * playerMoveMultiplier * sprintMultiplier;
			if (Input.GetKey(moveForward))
			{
				base.transform.Translate(base.transform.forward * num, Space.World);
			}
			else if (Input.GetKey(moveBackward))
			{
				base.transform.Translate(-base.transform.forward * num, Space.World);
			}
			if (Input.GetKey(moveLeft))
			{
				base.transform.Translate(-base.transform.right * num, Space.World);
			}
			else if (Input.GetKey(moveRight))
			{
				base.transform.Translate(base.transform.right * num, Space.World);
			}
		}

		protected virtual void SetHand()
		{
			Cursor.visible = false;
			isHand = true;
			rightHand.gameObject.SetActive(value: true);
			leftHand.gameObject.SetActive(value: true);
			oldPos = Input.mousePosition;
			if (resetHandsAtSwitch)
			{
				rightHand.transform.localPosition = new Vector3(0.2f, 1.2f, 0.5f);
				rightHand.transform.localRotation = Quaternion.identity;
				leftHand.transform.localPosition = new Vector3(-0.2f, 1.2f, 0.5f);
				leftHand.transform.localRotation = Quaternion.identity;
			}
		}

		protected virtual void SetMove()
		{
			Cursor.visible = true;
			isHand = false;
			if (hideHandsAtSwitch)
			{
				rightHand.gameObject.SetActive(value: false);
				leftHand.gameObject.SetActive(value: false);
			}
		}

		protected virtual void UpdateHints()
		{
			string text = "";
			Func<KeyCode, string> func = (KeyCode k) => "<b>" + k.ToString() + "</b>";
			string text2 = "";
			if (mouseMovementInput == MouseInputMode.RequiresButtonPress)
			{
				text2 = " (" + func(mouseMovementKey) + ")";
			}
			string text3 = moveForward.ToString() + moveLeft.ToString() + moveBackward.ToString() + moveRight;
			text = text + "Toggle Control Hints: " + func(toggleControlHints) + "\n\n";
			text = text + "Toggle Mouse Lock: " + func(toggleMouseLock) + "\n";
			text = text + "Move Player/Playspace: <b>" + text3 + "</b>\n";
			text = text + "Sprint Modifier: (" + func(sprint) + ")\n\n";
			if (isHand)
			{
				text = ((!Input.GetKey(rotationPosition)) ? (text + "Mouse: <b>Controller Position" + text2 + "</b>\n") : (text + "Mouse: <b>Controller Rotation" + text2 + "</b>\n"));
				text = text + "Modes: HMD (" + func(handsOnOff) + "), Rotation (" + func(rotationPosition) + ")\n";
				text = text + "Controller Hand: " + currentHand.name.Replace("Hand", "") + " (" + func(changeHands) + ")\n";
				string text4 = (Input.GetKey(changeAxis) ? "X/Y" : "X/Z");
				text = text + "Axis: " + text4 + " (" + func(changeAxis) + ")\n";
				string text5 = "Press";
				if (Input.GetKey(hairTouchModifier))
				{
					text5 = "Hair Touch";
				}
				else if (Input.GetKey(touchModifier))
				{
					text5 = "Touch";
				}
				text = text + "\nButton Press Mode Modifiers: Touch (" + func(touchModifier) + "), Hair Touch (" + func(hairTouchModifier) + ")\n";
				text = text + "Trigger " + text5 + ": " + func(triggerAlias) + "\n";
				text = text + "Grip " + text5 + ": " + func(gripAlias) + "\n";
				if (!Input.GetKey(hairTouchModifier))
				{
					text = text + "Touchpad " + text5 + ": " + func(touchpadAlias) + "\n";
					text = text + "Button One " + text5 + ": " + func(buttonOneAlias) + "\n";
					text = text + "Button Two " + text5 + ": " + func(buttonTwoAlias) + "\n";
					text = text + "Start Menu " + text5 + ": " + func(startMenuAlias) + "\n";
				}
			}
			else
			{
				text = text + "Mouse: <b>HMD Rotation" + text2 + "</b>\n";
				text = text + "Modes: Controller (" + func(handsOnOff) + ")\n";
				text = text + "Distance Pickup Modifier: (" + func(distancePickupModifier) + ")\n";
				text = text + "Distance Pickup Left Hand: (" + func(distancePickupLeft) + ")\n";
				text = text + "Distance Pickup Right Hand: (" + func(distancePickupRight) + ")\n";
			}
			hintText.text = text.TrimEnd();
		}

		protected virtual bool IsAcceptingMouseInput()
		{
			if (mouseMovementInput != MouseInputMode.Always)
			{
				return Input.GetKey(mouseMovementKey);
			}
			return true;
		}

		protected virtual Vector3 GetMouseDelta()
		{
			if (Cursor.lockState == CursorLockMode.Locked)
			{
				return new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * lockedCursorMultiplier;
			}
			Vector3 result = Input.mousePosition - oldPos;
			oldPos = Input.mousePosition;
			return result;
		}

		protected virtual void ToggleGuidePlanes(bool horizontalState, bool verticalState)
		{
			if (!showHandAxisHelpers)
			{
				horizontalState = false;
				verticalState = false;
			}
			if (leftHandHorizontalAxisGuide != null)
			{
				leftHandHorizontalAxisGuide.gameObject.SetActive(horizontalState);
			}
			if (leftHandVerticalAxisGuide != null)
			{
				leftHandVerticalAxisGuide.gameObject.SetActive(verticalState);
			}
			if (rightHandHorizontalAxisGuide != null)
			{
				rightHandHorizontalAxisGuide.gameObject.SetActive(horizontalState);
			}
			if (rightHandVerticalAxisGuide != null)
			{
				rightHandVerticalAxisGuide.gameObject.SetActive(verticalState);
			}
		}
	}
}
