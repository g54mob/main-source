using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct GenericActions
	{
		private PlayerControls m_Wrapper;

		public InputAction ToggleMenu => m_Wrapper.m_Generic_ToggleMenu;

		public GenericActions(PlayerControls wrapper)
		{
			m_Wrapper = wrapper;
		}
	}

	public struct TouchActions
	{
		private PlayerControls m_Wrapper;

		public InputAction PrimaryFingerPosition => m_Wrapper.m_Touch_PrimaryFingerPosition;

		public InputAction SecondaryFingerPosition => m_Wrapper.m_Touch_SecondaryFingerPosition;

		public InputAction PrimaryTouchContact => m_Wrapper.m_Touch_PrimaryTouchContact;

		public InputAction SecondaryTouchContact => m_Wrapper.m_Touch_SecondaryTouchContact;

		public InputAction PrimaryTouchDelta => m_Wrapper.m_Touch_PrimaryTouchDelta;

		public InputAction SecondaryTouchDelta => m_Wrapper.m_Touch_SecondaryTouchDelta;

		public TouchActions(PlayerControls wrapper)
		{
			m_Wrapper = wrapper;
		}
	}

	public interface IGenericActions
	{
	}

	public interface ITouchActions
	{
	}

	public interface IMenuActions
	{
	}

	private readonly InputActionAsset _003Casset_003Ek__BackingField;

	private readonly InputActionMap m_Generic;

	private IGenericActions m_GenericActionsCallbackInterface;

	private readonly InputAction m_Generic_ToggleMenu;

	private readonly InputAction m_Generic_PointerClick;

	private readonly InputAction m_Generic_CameraMovement;

	private readonly InputAction m_Generic_CameraRotation;

	private readonly InputAction m_Generic_CameraZoom;

	private readonly InputAction m_Generic_IncreaseCameraSpeed;

	private readonly InputActionMap m_Touch;

	private ITouchActions m_TouchActionsCallbackInterface;

	private readonly InputAction m_Touch_PrimaryFingerPosition;

	private readonly InputAction m_Touch_SecondaryFingerPosition;

	private readonly InputAction m_Touch_PrimaryTouchContact;

	private readonly InputAction m_Touch_SecondaryTouchContact;

	private readonly InputAction m_Touch_TouchInput;

	private readonly InputAction m_Touch_PrimaryTouchDelta;

	private readonly InputAction m_Touch_SecondaryTouchDelta;

	private readonly InputActionMap m_Menu;

	private IMenuActions m_MenuActionsCallbackInterface;

	private readonly InputAction m_Menu_Newaction;

	private int m_MouseKeyboardSchemeIndex = -1;

	private int m_TouchSchemeIndex = -1;

	private int m_GamepadSchemeIndex = -1;

	public InputActionAsset asset => _003Casset_003Ek__BackingField;

	public InputBinding? bindingMask
	{
		set
		{
			asset.bindingMask = value;
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		set
		{
			asset.devices = value;
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

	public GenericActions Generic => new GenericActions(this);

	public TouchActions Touch => new TouchActions(this);

	public PlayerControls()
	{
		_003Casset_003Ek__BackingField = InputActionAsset.FromJson("{\r\n    \"name\": \"PlayerControls\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Generic\",\r\n            \"id\": \"6c4d546d-a54d-4f35-8257-0ea4cc0ccdf9\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"ToggleMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"218d7f56-fe7a-4bc6-bceb-32468b0b38f8\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"PointerClick\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"48f28501-a636-4157-9633-ee3a0977d765\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"CameraMovement\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"223f28f1-0bff-4637-ab6f-38f0385ad715\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"CameraRotation\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"528c7676-b9ae-47ac-ba7b-0740b8a9e459\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"CameraZoom\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"d587e99a-bf18-4637-a24b-5e1314e2bdbb\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"IncreaseCameraSpeed\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"72a68fbb-06fa-4b67-bbcf-d11b1e810148\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"48c6314c-673d-4e7e-a8f9-073f4a0b0dad\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"ToggleMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d39dae06-26f5-48df-b597-8852f2bdcc32\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c3f05b34-f746-4158-95ba-a8c60a59067e\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PointerClick\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3932a8a5-b3c6-401e-a51d-fea7861e442b\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PointerClick\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"a228ddf8-f033-44f4-9bfe-e8910bb721ad\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraMovement\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"fc08f70a-049e-4dfc-8e2d-8cbdc3ea6eeb\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"1b63aa0d-ce24-4525-bb86-e6f1c3404974\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"869464df-4b43-484a-8198-5e61d5d73312\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"7c4667b1-0384-473a-87bb-f1813843e93f\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"54cccfb7-60f7-4d72-aef6-befe93a7c2fa\",\r\n                    \"path\": \"<Gamepad>/rightStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"CameraMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"KeyboardAxis\",\r\n                    \"id\": \"a31d90a4-2969-47c6-a4bf-fbb4d2a7eac1\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"8da27e62-e6f5-4883-8d0b-24efc503b3cc\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"5501dfe9-fd74-4fa9-9793-7e6237778528\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"KeyboardAxis\",\r\n                    \"id\": \"f5ef6f49-64fc-42f4-a895-e9358b13b5b4\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"9c075373-0e81-4f2c-b38f-9bde42430be1\",\r\n                    \"path\": \"<Keyboard>/x\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"a9a75e9f-de51-4ccc-8241-e7fad5517799\",\r\n                    \"path\": \"<Keyboard>/c\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0b9da2b3-eb23-48b2-8cee-ac0b466d2a27\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"Scale\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"166f931a-70e1-4d0d-a619-824869b5a4f9\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"MouseKeyboard\",\r\n                    \"action\": \"IncreaseCameraSpeed\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Touch\",\r\n            \"id\": \"1c7c8961-a709-4da3-bde1-a5f8435242aa\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"PrimaryFingerPosition\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"7b739362-71da-4d07-bf53-b603f8185952\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"SecondaryFingerPosition\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"a1e13308-a928-4833-93ff-22ae979830ff\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"PrimaryTouchContact\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"34212ced-521d-4ea9-ae15-112155c0f34c\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"Press\"\r\n                },\r\n                {\r\n                    \"name\": \"SecondaryTouchContact\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"5be85a39-90c9-4caa-abc9-6d3c67ad7c57\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"Press\"\r\n                },\r\n                {\r\n                    \"name\": \"TouchInput\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"90c7cfd8-d661-4fc5-b7b5-0301d59e1ad8\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"PrimaryTouchDelta\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"6dbdbdb0-10b7-48fe-a516-3d6fcb8ab0b3\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                },\r\n                {\r\n                    \"name\": \"SecondaryTouchDelta\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"248f98c5-d66c-476a-a82d-8fd54b01ec1f\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"00d2c24c-1a10-48cf-8753-d05765ad49c1\",\r\n                    \"path\": \"<Touchscreen>/primaryTouch/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PrimaryFingerPosition\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c1766b24-49b3-45b5-8faf-684d8033b2fb\",\r\n                    \"path\": \"<Mouse>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PrimaryFingerPosition\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8e112584-9684-416f-90c2-084f7b538384\",\r\n                    \"path\": \"<Touchscreen>/touch1/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"SecondaryFingerPosition\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ba95075a-e702-41be-85b1-607c8a5b9888\",\r\n                    \"path\": \"<Mouse>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"SecondaryFingerPosition\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e02ffc51-43b3-46df-af62-d2296752d193\",\r\n                    \"path\": \"<Touchscreen>/touch1/press\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"SecondaryTouchContact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"97af6baf-0338-42f1-9bbc-0a4af3988310\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"SecondaryTouchContact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"12358c85-8ee3-4f2a-9c22-cd0dc8d84c3f\",\r\n                    \"path\": \"<Touchscreen>/primaryTouch\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TouchInput\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b4c46b62-6c01-4736-a005-3278c356878c\",\r\n                    \"path\": \"<Touchscreen>/primaryTouch/press\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PrimaryTouchContact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"711796ba-c928-4da8-b143-2f2553a2b481\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PrimaryTouchContact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"74cff997-f8a6-4c81-abb2-9b2e9f846e0d\",\r\n                    \"path\": \"<Touchscreen>/primaryTouch/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PrimaryTouchDelta\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a64d8b8d-3a71-4458-8d32-1a796e0ec588\",\r\n                    \"path\": \"<Touchscreen>/touch1/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"SecondaryTouchDelta\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Menu\",\r\n            \"id\": \"96819b06-b7a4-4121-872e-57363bce2d4c\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"New action\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"ce885815-d5c3-4a65-bf94-f258ad9c4846\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\"\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"27787968-f673-45f8-a453-d3b5e367011a\",\r\n                    \"path\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"New action\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": [\r\n        {\r\n            \"name\": \"MouseKeyboard\",\r\n            \"bindingGroup\": \"MouseKeyboard\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Mouse>\",\r\n                    \"isOptional\": true,\r\n                    \"isOR\": false\r\n                },\r\n                {\r\n                    \"devicePath\": \"<Keyboard>\",\r\n                    \"isOptional\": true,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Touch\",\r\n            \"bindingGroup\": \"Touch\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Touchscreen>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Gamepad\",\r\n            \"bindingGroup\": \"Gamepad\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Gamepad>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        }\r\n    ]\r\n}");
		m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
		m_Generic_ToggleMenu = m_Generic.FindAction("ToggleMenu", throwIfNotFound: true);
		m_Generic_PointerClick = m_Generic.FindAction("PointerClick", throwIfNotFound: true);
		m_Generic_CameraMovement = m_Generic.FindAction("CameraMovement", throwIfNotFound: true);
		m_Generic_CameraRotation = m_Generic.FindAction("CameraRotation", throwIfNotFound: true);
		m_Generic_CameraZoom = m_Generic.FindAction("CameraZoom", throwIfNotFound: true);
		m_Generic_IncreaseCameraSpeed = m_Generic.FindAction("IncreaseCameraSpeed", throwIfNotFound: true);
		m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
		m_Touch_PrimaryFingerPosition = m_Touch.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
		m_Touch_SecondaryFingerPosition = m_Touch.FindAction("SecondaryFingerPosition", throwIfNotFound: true);
		m_Touch_PrimaryTouchContact = m_Touch.FindAction("PrimaryTouchContact", throwIfNotFound: true);
		m_Touch_SecondaryTouchContact = m_Touch.FindAction("SecondaryTouchContact", throwIfNotFound: true);
		m_Touch_TouchInput = m_Touch.FindAction("TouchInput", throwIfNotFound: true);
		m_Touch_PrimaryTouchDelta = m_Touch.FindAction("PrimaryTouchDelta", throwIfNotFound: true);
		m_Touch_SecondaryTouchDelta = m_Touch.FindAction("SecondaryTouchDelta", throwIfNotFound: true);
		m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
		m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(asset);
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return asset.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Enable()
	{
		asset.Enable();
	}

	public void Disable()
	{
		asset.Disable();
	}
}
