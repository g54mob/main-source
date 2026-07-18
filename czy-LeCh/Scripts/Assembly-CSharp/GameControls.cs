using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GameControls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct GameActions
	{
		private GameControls m_Wrapper;

		public InputAction Move => m_Wrapper.m_Game_Move;

		public InputAction Build => m_Wrapper.m_Game_Build;

		public InputAction Break => m_Wrapper.m_Game_Break;

		public InputAction Rotate => m_Wrapper.m_Game_Rotate;

		public InputAction Zoom => m_Wrapper.m_Game_Zoom;

		public InputAction Pause => m_Wrapper.m_Game_Pause;

		public InputAction NextPrefab => m_Wrapper.m_Game_NextPrefab;

		public InputAction PreviousPrefab => m_Wrapper.m_Game_PreviousPrefab;

		public InputAction RotateCW => m_Wrapper.m_Game_RotateCW;

		public InputAction RotateCCW => m_Wrapper.m_Game_RotateCCW;

		public InputAction UI_Switch => m_Wrapper.m_Game_UI_Switch;

		public InputAction ChangeColor => m_Wrapper.m_Game_ChangeColor;

		public InputAction FinishBuild => m_Wrapper.m_Game_FinishBuild;

		public InputAction Duplicate => m_Wrapper.m_Game_Duplicate;

		public bool enabled => Get().enabled;

		public GameActions(GameControls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Game;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(GameActions set)
		{
			return set.Get();
		}

		public void SetCallbacks(IGameActions instance)
		{
			if (m_Wrapper.m_GameActionsCallbackInterface != null)
			{
				Move.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
				Move.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
				Move.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
				Build.started -= m_Wrapper.m_GameActionsCallbackInterface.OnBuild;
				Build.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnBuild;
				Build.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnBuild;
				Break.started -= m_Wrapper.m_GameActionsCallbackInterface.OnBreak;
				Break.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnBreak;
				Break.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnBreak;
				Rotate.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotate;
				Rotate.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotate;
				Rotate.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotate;
				Zoom.started -= m_Wrapper.m_GameActionsCallbackInterface.OnZoom;
				Zoom.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnZoom;
				Zoom.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnZoom;
				Pause.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
				Pause.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
				Pause.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
				NextPrefab.started -= m_Wrapper.m_GameActionsCallbackInterface.OnNextPrefab;
				NextPrefab.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnNextPrefab;
				NextPrefab.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnNextPrefab;
				PreviousPrefab.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPreviousPrefab;
				PreviousPrefab.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPreviousPrefab;
				PreviousPrefab.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPreviousPrefab;
				RotateCW.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotateCW;
				RotateCW.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotateCW;
				RotateCW.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotateCW;
				RotateCCW.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotateCCW;
				RotateCCW.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotateCCW;
				RotateCCW.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotateCCW;
				UI_Switch.started -= m_Wrapper.m_GameActionsCallbackInterface.OnUI_Switch;
				UI_Switch.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnUI_Switch;
				UI_Switch.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnUI_Switch;
				ChangeColor.started -= m_Wrapper.m_GameActionsCallbackInterface.OnChangeColor;
				ChangeColor.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnChangeColor;
				ChangeColor.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnChangeColor;
				FinishBuild.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFinishBuild;
				FinishBuild.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFinishBuild;
				FinishBuild.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFinishBuild;
				Duplicate.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDuplicate;
				Duplicate.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDuplicate;
				Duplicate.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDuplicate;
			}
			m_Wrapper.m_GameActionsCallbackInterface = instance;
			if (instance != null)
			{
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				Build.started += instance.OnBuild;
				Build.performed += instance.OnBuild;
				Build.canceled += instance.OnBuild;
				Break.started += instance.OnBreak;
				Break.performed += instance.OnBreak;
				Break.canceled += instance.OnBreak;
				Rotate.started += instance.OnRotate;
				Rotate.performed += instance.OnRotate;
				Rotate.canceled += instance.OnRotate;
				Zoom.started += instance.OnZoom;
				Zoom.performed += instance.OnZoom;
				Zoom.canceled += instance.OnZoom;
				Pause.started += instance.OnPause;
				Pause.performed += instance.OnPause;
				Pause.canceled += instance.OnPause;
				NextPrefab.started += instance.OnNextPrefab;
				NextPrefab.performed += instance.OnNextPrefab;
				NextPrefab.canceled += instance.OnNextPrefab;
				PreviousPrefab.started += instance.OnPreviousPrefab;
				PreviousPrefab.performed += instance.OnPreviousPrefab;
				PreviousPrefab.canceled += instance.OnPreviousPrefab;
				RotateCW.started += instance.OnRotateCW;
				RotateCW.performed += instance.OnRotateCW;
				RotateCW.canceled += instance.OnRotateCW;
				RotateCCW.started += instance.OnRotateCCW;
				RotateCCW.performed += instance.OnRotateCCW;
				RotateCCW.canceled += instance.OnRotateCCW;
				UI_Switch.started += instance.OnUI_Switch;
				UI_Switch.performed += instance.OnUI_Switch;
				UI_Switch.canceled += instance.OnUI_Switch;
				ChangeColor.started += instance.OnChangeColor;
				ChangeColor.performed += instance.OnChangeColor;
				ChangeColor.canceled += instance.OnChangeColor;
				FinishBuild.started += instance.OnFinishBuild;
				FinishBuild.performed += instance.OnFinishBuild;
				FinishBuild.canceled += instance.OnFinishBuild;
				Duplicate.started += instance.OnDuplicate;
				Duplicate.performed += instance.OnDuplicate;
				Duplicate.canceled += instance.OnDuplicate;
			}
		}
	}

	public struct UIActions
	{
		private GameControls m_Wrapper;

		public InputAction Navigate => m_Wrapper.m_UI_Navigate;

		public InputAction Submit => m_Wrapper.m_UI_Submit;

		public InputAction Cancel => m_Wrapper.m_UI_Cancel;

		public InputAction Point => m_Wrapper.m_UI_Point;

		public InputAction Click => m_Wrapper.m_UI_Click;

		public InputAction ScrollWheel => m_Wrapper.m_UI_ScrollWheel;

		public InputAction MiddleClick => m_Wrapper.m_UI_MiddleClick;

		public InputAction RightClick => m_Wrapper.m_UI_RightClick;

		public InputAction TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;

		public InputAction TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;

		public InputAction Escape => m_Wrapper.m_UI_Escape;

		public bool enabled => Get().enabled;

		public UIActions(GameControls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_UI;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(UIActions set)
		{
			return set.Get();
		}

		public void SetCallbacks(IUIActions instance)
		{
			if (m_Wrapper.m_UIActionsCallbackInterface != null)
			{
				Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
				Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
				Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
				Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
				Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
				Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
				Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
				Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
				Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
				Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
				Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
				Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
				Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
				Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
				Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
				ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
				ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
				ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
				MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
				MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
				MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
				RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
				RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
				RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
				TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
				TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
				TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
				TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
				TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
				TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
				Escape.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
				Escape.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
				Escape.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
			}
			m_Wrapper.m_UIActionsCallbackInterface = instance;
			if (instance != null)
			{
				Navigate.started += instance.OnNavigate;
				Navigate.performed += instance.OnNavigate;
				Navigate.canceled += instance.OnNavigate;
				Submit.started += instance.OnSubmit;
				Submit.performed += instance.OnSubmit;
				Submit.canceled += instance.OnSubmit;
				Cancel.started += instance.OnCancel;
				Cancel.performed += instance.OnCancel;
				Cancel.canceled += instance.OnCancel;
				Point.started += instance.OnPoint;
				Point.performed += instance.OnPoint;
				Point.canceled += instance.OnPoint;
				Click.started += instance.OnClick;
				Click.performed += instance.OnClick;
				Click.canceled += instance.OnClick;
				ScrollWheel.started += instance.OnScrollWheel;
				ScrollWheel.performed += instance.OnScrollWheel;
				ScrollWheel.canceled += instance.OnScrollWheel;
				MiddleClick.started += instance.OnMiddleClick;
				MiddleClick.performed += instance.OnMiddleClick;
				MiddleClick.canceled += instance.OnMiddleClick;
				RightClick.started += instance.OnRightClick;
				RightClick.performed += instance.OnRightClick;
				RightClick.canceled += instance.OnRightClick;
				TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
				TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
				TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
				TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
				TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
				TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
				Escape.started += instance.OnEscape;
				Escape.performed += instance.OnEscape;
				Escape.canceled += instance.OnEscape;
			}
		}
	}

	public interface IGameActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnBuild(InputAction.CallbackContext context);

		void OnBreak(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnZoom(InputAction.CallbackContext context);

		void OnPause(InputAction.CallbackContext context);

		void OnNextPrefab(InputAction.CallbackContext context);

		void OnPreviousPrefab(InputAction.CallbackContext context);

		void OnRotateCW(InputAction.CallbackContext context);

		void OnRotateCCW(InputAction.CallbackContext context);

		void OnUI_Switch(InputAction.CallbackContext context);

		void OnChangeColor(InputAction.CallbackContext context);

		void OnFinishBuild(InputAction.CallbackContext context);

		void OnDuplicate(InputAction.CallbackContext context);
	}

	public interface IUIActions
	{
		void OnNavigate(InputAction.CallbackContext context);

		void OnSubmit(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnPoint(InputAction.CallbackContext context);

		void OnClick(InputAction.CallbackContext context);

		void OnScrollWheel(InputAction.CallbackContext context);

		void OnMiddleClick(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnTrackedDevicePosition(InputAction.CallbackContext context);

		void OnTrackedDeviceOrientation(InputAction.CallbackContext context);

		void OnEscape(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Game;

	private IGameActions m_GameActionsCallbackInterface;

	private readonly InputAction m_Game_Move;

	private readonly InputAction m_Game_Build;

	private readonly InputAction m_Game_Break;

	private readonly InputAction m_Game_Rotate;

	private readonly InputAction m_Game_Zoom;

	private readonly InputAction m_Game_Pause;

	private readonly InputAction m_Game_NextPrefab;

	private readonly InputAction m_Game_PreviousPrefab;

	private readonly InputAction m_Game_RotateCW;

	private readonly InputAction m_Game_RotateCCW;

	private readonly InputAction m_Game_UI_Switch;

	private readonly InputAction m_Game_ChangeColor;

	private readonly InputAction m_Game_FinishBuild;

	private readonly InputAction m_Game_Duplicate;

	private readonly InputActionMap m_UI;

	private IUIActions m_UIActionsCallbackInterface;

	private readonly InputAction m_UI_Navigate;

	private readonly InputAction m_UI_Submit;

	private readonly InputAction m_UI_Cancel;

	private readonly InputAction m_UI_Point;

	private readonly InputAction m_UI_Click;

	private readonly InputAction m_UI_ScrollWheel;

	private readonly InputAction m_UI_MiddleClick;

	private readonly InputAction m_UI_RightClick;

	private readonly InputAction m_UI_TrackedDevicePosition;

	private readonly InputAction m_UI_TrackedDeviceOrientation;

	private readonly InputAction m_UI_Escape;

	private int m_GamepadSchemeIndex = -1;

	public InputActionAsset asset { get; }

	public InputBinding? bindingMask
	{
		get
		{
			return asset.bindingMask;
		}
		set
		{
			asset.bindingMask = value;
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return asset.devices;
		}
		set
		{
			asset.devices = value;
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

	public IEnumerable<InputBinding> bindings => asset.bindings;

	public GameActions Game => new GameActions(this);

	public UIActions UI => new UIActions(this);

	public InputControlScheme GamepadScheme
	{
		get
		{
			if (m_GamepadSchemeIndex == -1)
			{
				m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
			}
			return asset.controlSchemes[m_GamepadSchemeIndex];
		}
	}

	public GameControls()
	{
		asset = InputActionAsset.FromJson("{\r\n    \"name\": \"GameControls\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Game\",\r\n            \"id\": \"fbcb1d82-d187-43f1-b84c-b88c3bc2949f\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Move\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"c2cec366-c611-452e-b3bc-d6f4363006d4\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Build\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"c39122cf-381b-4c10-91ce-38b3819ef367\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Break\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"dd732499-264d-42cc-bbd9-7cc465986270\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Rotate\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"e0fb3700-2e4b-45cb-b489-2d6307073243\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Zoom\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"222671d3-d16b-4637-b5ed-5d1466a8fcaf\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Pause\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"deda3e0d-fe5d-4f94-9758-41247314b2fb\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"NextPrefab\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"bf7ed56c-e68d-4c56-b301-397250bd518b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"PreviousPrefab\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"abe5116a-65a8-4319-ad6c-7df07f4bd754\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RotateCW\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"1f607a7e-2f97-423e-8f0a-11042e585f8d\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RotateCCW\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c1d151ad-5968-4b92-a82e-be56da97c602\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"UI_Switch\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"662a6343-9a1b-476d-a707-5048151daffe\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ChangeColor\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c0e4bac2-ff87-47fa-a54e-1f357c816744\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"FinishBuild\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"e5fde8d6-ebcc-4bb2-a8b6-7ed1d03c5add\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Duplicate\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"b58ce65a-140d-496e-8457-7112ce383b31\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"579e2654-56d6-452c-99c6-f12aed847724\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"4a0cab3b-8602-423f-b28c-db5108bc4d09\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"f39f0364-f7e5-4b7f-bbe4-7938bfccafd3\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"c6963ecf-6b09-4de3-9ae3-828713d6701c\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"88098b08-b5b0-4e52-a234-4a52ccd1e234\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Arrow Keys\",\r\n                    \"id\": \"8fc591c2-f6d5-4e0a-8d5e-19c0dc491a4f\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"04934b83-ca65-43e4-9637-3ce251a341ba\",\r\n                    \"path\": \"<Keyboard>/upArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"3383f0ff-ab9d-4f57-8b37-3398a14f66bc\",\r\n                    \"path\": \"<Keyboard>/downArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"ea458cef-f1f1-4801-acfd-f55145ce137f\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"8a18be0d-fa54-403d-a80e-0fba258eba4a\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6f2653a7-bdba-4e47-9edd-510fa6d12175\",\r\n                    \"path\": \"<Gamepad>/rightStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"41a5995f-7654-4d63-a7d6-d2ebd3144675\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Build\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a994a179-49c9-4b32-ac78-9cd809b8230d\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Break\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"047a8ac8-2336-4b3e-a5b2-ddac2c20db80\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Break\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1fac770a-d405-459b-b920-184b61fb00db\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Rotate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1a066cfe-55fe-462b-be2e-77d7c2d8eef7\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Rotate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2e6bcc67-406e-4c65-969d-79b5f0a32d0b\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Zoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f3305c6e-ef3f-4643-908f-8bae71c8ae6b\",\r\n                    \"path\": \"<Gamepad>/dpad/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Zoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"98dc9560-a5d1-4290-a0a3-2bcee935a5df\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Pause\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"32696a30-d4c4-45d3-a68f-74cff6bd4aa8\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Pause\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"783dd247-2885-4434-8388-3067394e1997\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Build\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"409e621a-86a9-44c8-8266-e79cd03dab17\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"NextPrefab\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"daec412a-2add-46af-8b35-77bafe33f518\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"NextPrefab\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"aebed7f9-8437-4d57-a73f-1a9b84149702\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PreviousPrefab\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e09bb9d1-78e8-418e-995a-b090e4ef273d\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"PreviousPrefab\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"68b7c16c-36c5-493a-ac6f-d0951a32fd54\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"RotateCW\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"42775048-43eb-4e8b-a405-e00512cfc3ae\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"RotateCW\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d59dcbbe-b940-4578-a2c2-ec1f9fee727d\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"RotateCCW\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b0e99f0a-10f6-4ded-aebd-272b8dddf392\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"RotateCCW\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2ebc10b1-3087-4fb2-8c59-85bf42701eb7\",\r\n                    \"path\": \"<Keyboard>/f1\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"UI_Switch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"35d3d800-077e-48a9-bf35-32eb5357f2e0\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChangeColor\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b03b80a6-f7d7-4698-a4ea-38a0984458e1\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChangeColor\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c8a4e1a3-4d64-469f-a4df-f9dce089daae\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FinishBuild\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"38324873-a3ef-42a2-b524-4d311c44a67d\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Duplicate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"efd81ebd-64db-4f98-8573-58a69fc18ca6\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Duplicate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"UI\",\r\n            \"id\": \"a808cd0e-2f25-464c-b041-88c957afe972\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Navigate\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"c9a0e196-d85b-4e2f-9c56-d2398ffe1c47\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Submit\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"f5715432-aa2e-4935-952b-300ae90f6fb2\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Cancel\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"e68b89d6-6c89-4b9e-884c-78d533466e2b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Point\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"9aa364d0-0089-4bfb-a508-abf1156c5be7\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Click\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"1052e8dc-c209-48b7-8517-b913c357c93d\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ScrollWheel\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"9443aa10-3990-4a45-ae93-4117edac5bc2\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"MiddleClick\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"5f85e97b-408f-449e-8b3c-61517b459be3\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RightClick\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"03da5edc-cd45-4d78-8d01-9a9bd06bf915\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TrackedDevicePosition\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"6532c7e7-033c-453c-a840-ef4587de23ae\",\r\n                    \"expectedControlType\": \"Vector3\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TrackedDeviceOrientation\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"64f60ae6-b8f9-4a24-9cc3-f1cb96c2c9cc\",\r\n                    \"expectedControlType\": \"Quaternion\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Escape\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"406239f1-7c4b-435b-8bd1-aeef3fc065dd\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"87a62804-ea8d-4c19-a35c-1a1a73a18362\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"07b78169-1894-4627-996c-497ad7db17d8\",\r\n                    \"path\": \"<Gamepad>/leftStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"8da08d9b-46ed-404e-9ac7-90e780e5ec3a\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"cae1f3de-fa1a-4781-abae-07bafdcd572b\",\r\n                    \"path\": \"<Gamepad>/leftStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"bef5fc1c-69a5-4473-a88d-60a62ce1e917\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"59e42699-c310-45c7-a8c0-3c138cb33413\",\r\n                    \"path\": \"<Gamepad>/leftStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"525e9227-384f-4b02-bf62-f0f8aa649aac\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"d4507875-23e3-4b2b-8eda-9de1a2a86829\",\r\n                    \"path\": \"<Gamepad>/leftStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"a91a2be9-07eb-4cf4-b981-e3621410d698\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"44d2e0d5-c680-49ee-b3b9-3dff95244d00\",\r\n                    \"path\": \"<Gamepad>/dpad\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Joystick\",\r\n                    \"id\": \"01fd439d-0465-439e-b10e-6a1845b6d44f\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"197e4b6a-4eae-46f0-bf88-cf4a5f8900d6\",\r\n                    \"path\": \"<Joystick>/stick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"69eba67b-fd8e-46dd-9985-bcaafabb3653\",\r\n                    \"path\": \"<Joystick>/stick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"ef98392b-2f5f-48fb-a71d-ed8c22ed5002\",\r\n                    \"path\": \"<Joystick>/stick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"e69b2450-c585-4e12-8a51-0d9d6749dae5\",\r\n                    \"path\": \"<Joystick>/stick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"789c9ece-7903-4546-bef2-44cd2f0926b2\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"a0881103-ef28-4091-aed9-13d7fb5fd6d6\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"d169edfd-6d97-47cf-96f0-5804b82a33a7\",\r\n                    \"path\": \"<Keyboard>/upArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"b9940fa4-8891-47d8-bf07-a566a5628e5c\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"9dc8bff1-dc33-4ef7-92b4-2a7cc7f74a50\",\r\n                    \"path\": \"<Keyboard>/downArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"f9c314f9-9e9b-4721-8d96-fe06dbd6d2f1\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"8dcc09b0-094d-4029-a495-c51d81243e80\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"9632ba34-d67c-4e93-b8ce-106523ffed6b\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"7e8c2400-10e7-476d-a6d8-9e967325b99d\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d6f3e322-df12-4836-9c7a-0233b208362a\",\r\n                    \"path\": \"*/{Submit}\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Submit\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6af914a8-64a7-494f-b30b-220b8dbb1c3d\",\r\n                    \"path\": \"*/{Cancel}\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Cancel\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9137d3de-70e2-47f9-88b5-d3e2fe83667e\",\r\n                    \"path\": \"<Mouse>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6bd454f3-c6f4-419f-b74c-5d5d7a1f984f\",\r\n                    \"path\": \"<Pen>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"22a33a68-6776-4cf4-b6ff-1125e9a54249\",\r\n                    \"path\": \"<Touchscreen>/touch*/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Touch\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"eaec1c9e-8327-4c53-a5ba-4489098e549a\",\r\n                    \"path\": \"<VirtualMouse>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"43c09799-73ab-480e-8cb8-dff66abbe414\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c5c38cff-281f-4b58-b3e0-aa247d2e5294\",\r\n                    \"path\": \"<Pen>/tip\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6f8805d5-ed5e-4d0d-ae18-4f14c4045426\",\r\n                    \"path\": \"<Touchscreen>/touch*/press\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Touch\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5d6f65d6-00f7-4c3f-8908-1cea0dceb150\",\r\n                    \"path\": \"<XRController>/trigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"951e3e8a-c5b9-41c5-873d-a084867e038a\",\r\n                    \"path\": \"<VirtualMouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"41f87b98-b4b4-4f15-a602-fb3c556a98ac\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8d402d74-0650-46cd-99fd-03707c1a2ecf\",\r\n                    \"path\": \"<Mouse>/scroll\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"ScrollWheel\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"02e7a6ee-57d7-46fc-af5f-efa038aaa994\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"MiddleClick\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4eaeb767-b283-462e-84dd-8f623d4fc1c1\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"RightClick\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b220cbdd-2442-4037-b1dc-541242530275\",\r\n                    \"path\": \"<XRController>/devicePosition\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"TrackedDevicePosition\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3482a9f2-ebf6-4d28-935e-bd2e8098425d\",\r\n                    \"path\": \"<XRController>/deviceRotation\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"TrackedDeviceOrientation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d23d7062-9125-40a7-926d-302de1cc2680\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Escape\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"97f47f28-4d3c-4107-afb5-ec50293e4e22\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Escape\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": [\r\n        {\r\n            \"name\": \"Gamepad\",\r\n            \"bindingGroup\": \"Gamepad\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Gamepad>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                },\r\n                {\r\n                    \"devicePath\": \"<VirtualMouse>\",\r\n                    \"isOptional\": true,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        }\r\n    ]\r\n}");
		m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
		m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
		m_Game_Build = m_Game.FindAction("Build", throwIfNotFound: true);
		m_Game_Break = m_Game.FindAction("Break", throwIfNotFound: true);
		m_Game_Rotate = m_Game.FindAction("Rotate", throwIfNotFound: true);
		m_Game_Zoom = m_Game.FindAction("Zoom", throwIfNotFound: true);
		m_Game_Pause = m_Game.FindAction("Pause", throwIfNotFound: true);
		m_Game_NextPrefab = m_Game.FindAction("NextPrefab", throwIfNotFound: true);
		m_Game_PreviousPrefab = m_Game.FindAction("PreviousPrefab", throwIfNotFound: true);
		m_Game_RotateCW = m_Game.FindAction("RotateCW", throwIfNotFound: true);
		m_Game_RotateCCW = m_Game.FindAction("RotateCCW", throwIfNotFound: true);
		m_Game_UI_Switch = m_Game.FindAction("UI_Switch", throwIfNotFound: true);
		m_Game_ChangeColor = m_Game.FindAction("ChangeColor", throwIfNotFound: true);
		m_Game_FinishBuild = m_Game.FindAction("FinishBuild", throwIfNotFound: true);
		m_Game_Duplicate = m_Game.FindAction("Duplicate", throwIfNotFound: true);
		m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
		m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
		m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
		m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
		m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
		m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
		m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
		m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
		m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
		m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
		m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
		m_UI_Escape = m_UI.FindAction("Escape", throwIfNotFound: true);
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(asset);
	}

	public bool Contains(InputAction action)
	{
		return asset.Contains(action);
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

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return asset.FindAction(actionNameOrId, throwIfNotFound);
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		return asset.FindBinding(bindingMask, out action);
	}
}
