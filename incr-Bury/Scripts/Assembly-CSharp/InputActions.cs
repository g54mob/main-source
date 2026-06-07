using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActionMapActions
	{
		private InputActions m_Wrapper;

		public InputAction Movement => m_Wrapper.m_PlayerActionMap_Movement;

		public InputAction Jump => m_Wrapper.m_PlayerActionMap_Jump;

		public InputAction Sprint => m_Wrapper.m_PlayerActionMap_Sprint;

		public InputAction Throw => m_Wrapper.m_PlayerActionMap_Throw;

		public InputAction Drop => m_Wrapper.m_PlayerActionMap_Drop;

		public InputAction PickUpAndUse => m_Wrapper.m_PlayerActionMap_PickUpAndUse;

		public InputAction BerryBlitz => m_Wrapper.m_PlayerActionMap_BerryBlitz;

		public InputAction GapingMaw => m_Wrapper.m_PlayerActionMap_GapingMaw;

		public InputAction AirBlast => m_Wrapper.m_PlayerActionMap_AirBlast;

		public InputAction MoveHole => m_Wrapper.m_PlayerActionMap_MoveHole;

		public InputAction UpgradePlantBed => m_Wrapper.m_PlayerActionMap_UpgradePlantBed;

		public InputAction Shop => m_Wrapper.m_PlayerActionMap_Shop;

		public InputAction Rotate => m_Wrapper.m_PlayerActionMap_Rotate;

		public InputAction DestroyBuildable => m_Wrapper.m_PlayerActionMap_DestroyBuildable;

		public InputAction PardnerCamLook => m_Wrapper.m_PlayerActionMap_PardnerCamLook;

		public InputAction Crouch => m_Wrapper.m_PlayerActionMap_Crouch;

		public InputAction Escape => m_Wrapper.m_PlayerActionMap_Escape;

		public InputAction ScrollPC => m_Wrapper.m_PlayerActionMap_ScrollPC;

		public InputAction Pointer => m_Wrapper.m_PlayerActionMap_Pointer;

		public InputAction LeftClick => m_Wrapper.m_PlayerActionMap_LeftClick;

		public bool enabled => Get().enabled;

		public PlayerActionMapActions(InputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_PlayerActionMap;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(PlayerActionMapActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IPlayerActionMapActions instance)
		{
			if (instance != null && !m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
				Movement.started += instance.OnMovement;
				Movement.performed += instance.OnMovement;
				Movement.canceled += instance.OnMovement;
				Jump.started += instance.OnJump;
				Jump.performed += instance.OnJump;
				Jump.canceled += instance.OnJump;
				Sprint.started += instance.OnSprint;
				Sprint.performed += instance.OnSprint;
				Sprint.canceled += instance.OnSprint;
				Throw.started += instance.OnThrow;
				Throw.performed += instance.OnThrow;
				Throw.canceled += instance.OnThrow;
				Drop.started += instance.OnDrop;
				Drop.performed += instance.OnDrop;
				Drop.canceled += instance.OnDrop;
				PickUpAndUse.started += instance.OnPickUpAndUse;
				PickUpAndUse.performed += instance.OnPickUpAndUse;
				PickUpAndUse.canceled += instance.OnPickUpAndUse;
				BerryBlitz.started += instance.OnBerryBlitz;
				BerryBlitz.performed += instance.OnBerryBlitz;
				BerryBlitz.canceled += instance.OnBerryBlitz;
				GapingMaw.started += instance.OnGapingMaw;
				GapingMaw.performed += instance.OnGapingMaw;
				GapingMaw.canceled += instance.OnGapingMaw;
				AirBlast.started += instance.OnAirBlast;
				AirBlast.performed += instance.OnAirBlast;
				AirBlast.canceled += instance.OnAirBlast;
				MoveHole.started += instance.OnMoveHole;
				MoveHole.performed += instance.OnMoveHole;
				MoveHole.canceled += instance.OnMoveHole;
				UpgradePlantBed.started += instance.OnUpgradePlantBed;
				UpgradePlantBed.performed += instance.OnUpgradePlantBed;
				UpgradePlantBed.canceled += instance.OnUpgradePlantBed;
				Shop.started += instance.OnShop;
				Shop.performed += instance.OnShop;
				Shop.canceled += instance.OnShop;
				Rotate.started += instance.OnRotate;
				Rotate.performed += instance.OnRotate;
				Rotate.canceled += instance.OnRotate;
				DestroyBuildable.started += instance.OnDestroyBuildable;
				DestroyBuildable.performed += instance.OnDestroyBuildable;
				DestroyBuildable.canceled += instance.OnDestroyBuildable;
				PardnerCamLook.started += instance.OnPardnerCamLook;
				PardnerCamLook.performed += instance.OnPardnerCamLook;
				PardnerCamLook.canceled += instance.OnPardnerCamLook;
				Crouch.started += instance.OnCrouch;
				Crouch.performed += instance.OnCrouch;
				Crouch.canceled += instance.OnCrouch;
				Escape.started += instance.OnEscape;
				Escape.performed += instance.OnEscape;
				Escape.canceled += instance.OnEscape;
				ScrollPC.started += instance.OnScrollPC;
				ScrollPC.performed += instance.OnScrollPC;
				ScrollPC.canceled += instance.OnScrollPC;
				Pointer.started += instance.OnPointer;
				Pointer.performed += instance.OnPointer;
				Pointer.canceled += instance.OnPointer;
				LeftClick.started += instance.OnLeftClick;
				LeftClick.performed += instance.OnLeftClick;
				LeftClick.canceled += instance.OnLeftClick;
			}
		}

		private void UnregisterCallbacks(IPlayerActionMapActions instance)
		{
			Movement.started -= instance.OnMovement;
			Movement.performed -= instance.OnMovement;
			Movement.canceled -= instance.OnMovement;
			Jump.started -= instance.OnJump;
			Jump.performed -= instance.OnJump;
			Jump.canceled -= instance.OnJump;
			Sprint.started -= instance.OnSprint;
			Sprint.performed -= instance.OnSprint;
			Sprint.canceled -= instance.OnSprint;
			Throw.started -= instance.OnThrow;
			Throw.performed -= instance.OnThrow;
			Throw.canceled -= instance.OnThrow;
			Drop.started -= instance.OnDrop;
			Drop.performed -= instance.OnDrop;
			Drop.canceled -= instance.OnDrop;
			PickUpAndUse.started -= instance.OnPickUpAndUse;
			PickUpAndUse.performed -= instance.OnPickUpAndUse;
			PickUpAndUse.canceled -= instance.OnPickUpAndUse;
			BerryBlitz.started -= instance.OnBerryBlitz;
			BerryBlitz.performed -= instance.OnBerryBlitz;
			BerryBlitz.canceled -= instance.OnBerryBlitz;
			GapingMaw.started -= instance.OnGapingMaw;
			GapingMaw.performed -= instance.OnGapingMaw;
			GapingMaw.canceled -= instance.OnGapingMaw;
			AirBlast.started -= instance.OnAirBlast;
			AirBlast.performed -= instance.OnAirBlast;
			AirBlast.canceled -= instance.OnAirBlast;
			MoveHole.started -= instance.OnMoveHole;
			MoveHole.performed -= instance.OnMoveHole;
			MoveHole.canceled -= instance.OnMoveHole;
			UpgradePlantBed.started -= instance.OnUpgradePlantBed;
			UpgradePlantBed.performed -= instance.OnUpgradePlantBed;
			UpgradePlantBed.canceled -= instance.OnUpgradePlantBed;
			Shop.started -= instance.OnShop;
			Shop.performed -= instance.OnShop;
			Shop.canceled -= instance.OnShop;
			Rotate.started -= instance.OnRotate;
			Rotate.performed -= instance.OnRotate;
			Rotate.canceled -= instance.OnRotate;
			DestroyBuildable.started -= instance.OnDestroyBuildable;
			DestroyBuildable.performed -= instance.OnDestroyBuildable;
			DestroyBuildable.canceled -= instance.OnDestroyBuildable;
			PardnerCamLook.started -= instance.OnPardnerCamLook;
			PardnerCamLook.performed -= instance.OnPardnerCamLook;
			PardnerCamLook.canceled -= instance.OnPardnerCamLook;
			Crouch.started -= instance.OnCrouch;
			Crouch.performed -= instance.OnCrouch;
			Crouch.canceled -= instance.OnCrouch;
			Escape.started -= instance.OnEscape;
			Escape.performed -= instance.OnEscape;
			Escape.canceled -= instance.OnEscape;
			ScrollPC.started -= instance.OnScrollPC;
			ScrollPC.performed -= instance.OnScrollPC;
			ScrollPC.canceled -= instance.OnScrollPC;
			Pointer.started -= instance.OnPointer;
			Pointer.performed -= instance.OnPointer;
			Pointer.canceled -= instance.OnPointer;
			LeftClick.started -= instance.OnLeftClick;
			LeftClick.performed -= instance.OnLeftClick;
			LeftClick.canceled -= instance.OnLeftClick;
		}

		public void RemoveCallbacks(IPlayerActionMapActions instance)
		{
			if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IPlayerActionMapActions instance)
		{
			foreach (IPlayerActionMapActions playerActionMapActionsCallbackInterface in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
			{
				UnregisterCallbacks(playerActionMapActionsCallbackInterface);
			}
			m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IPlayerActionMapActions
	{
		void OnMovement(InputAction.CallbackContext context);

		void OnJump(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnThrow(InputAction.CallbackContext context);

		void OnDrop(InputAction.CallbackContext context);

		void OnPickUpAndUse(InputAction.CallbackContext context);

		void OnBerryBlitz(InputAction.CallbackContext context);

		void OnGapingMaw(InputAction.CallbackContext context);

		void OnAirBlast(InputAction.CallbackContext context);

		void OnMoveHole(InputAction.CallbackContext context);

		void OnUpgradePlantBed(InputAction.CallbackContext context);

		void OnShop(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnDestroyBuildable(InputAction.CallbackContext context);

		void OnPardnerCamLook(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);

		void OnEscape(InputAction.CallbackContext context);

		void OnScrollPC(InputAction.CallbackContext context);

		void OnPointer(InputAction.CallbackContext context);

		void OnLeftClick(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_PlayerActionMap;

	private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();

	private readonly InputAction m_PlayerActionMap_Movement;

	private readonly InputAction m_PlayerActionMap_Jump;

	private readonly InputAction m_PlayerActionMap_Sprint;

	private readonly InputAction m_PlayerActionMap_Throw;

	private readonly InputAction m_PlayerActionMap_Drop;

	private readonly InputAction m_PlayerActionMap_PickUpAndUse;

	private readonly InputAction m_PlayerActionMap_BerryBlitz;

	private readonly InputAction m_PlayerActionMap_GapingMaw;

	private readonly InputAction m_PlayerActionMap_AirBlast;

	private readonly InputAction m_PlayerActionMap_MoveHole;

	private readonly InputAction m_PlayerActionMap_UpgradePlantBed;

	private readonly InputAction m_PlayerActionMap_Shop;

	private readonly InputAction m_PlayerActionMap_Rotate;

	private readonly InputAction m_PlayerActionMap_DestroyBuildable;

	private readonly InputAction m_PlayerActionMap_PardnerCamLook;

	private readonly InputAction m_PlayerActionMap_Crouch;

	private readonly InputAction m_PlayerActionMap_Escape;

	private readonly InputAction m_PlayerActionMap_ScrollPC;

	private readonly InputAction m_PlayerActionMap_Pointer;

	private readonly InputAction m_PlayerActionMap_LeftClick;

	private int m_KBMSchemeIndex = -1;

	private int m_ControllerSchemeIndex = -1;

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

	public PlayerActionMapActions PlayerActionMap => new PlayerActionMapActions(this);

	public InputControlScheme KBMScheme
	{
		get
		{
			if (m_KBMSchemeIndex == -1)
			{
				m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
			}
			return asset.controlSchemes[m_KBMSchemeIndex];
		}
	}

	public InputControlScheme ControllerScheme
	{
		get
		{
			if (m_ControllerSchemeIndex == -1)
			{
				m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
			}
			return asset.controlSchemes[m_ControllerSchemeIndex];
		}
	}

	public InputActions()
	{
		asset = InputActionAsset.FromJson("{\n    \"version\": 1,\n    \"name\": \"InputActions\",\n    \"maps\": [\n        {\n            \"name\": \"PlayerActionMap\",\n            \"id\": \"7f27274f-96af-4d03-832c-98a74f3af242\",\n            \"actions\": [\n                {\n                    \"name\": \"Movement\",\n                    \"type\": \"Value\",\n                    \"id\": \"45c5ae03-b262-45e5-a059-b58a3e0ac2c0\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Jump\",\n                    \"type\": \"Button\",\n                    \"id\": \"ef166ccc-aeab-4c80-8a86-d56526844b6b\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Sprint\",\n                    \"type\": \"Button\",\n                    \"id\": \"cf732f15-5a6a-4513-9b1b-e2027a1da29a\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Throw\",\n                    \"type\": \"Button\",\n                    \"id\": \"218f4cf0-79f5-4acf-a095-b8bb8122ba97\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Drop\",\n                    \"type\": \"Button\",\n                    \"id\": \"97a9fef1-ffb6-4a1b-bd72-89326f634468\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"PickUpAndUse\",\n                    \"type\": \"Button\",\n                    \"id\": \"77aa3560-09bb-41d1-ae77-2c091e7c1192\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"BerryBlitz\",\n                    \"type\": \"Button\",\n                    \"id\": \"a6e87785-8259-4937-837a-12aea53271d4\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"GapingMaw\",\n                    \"type\": \"Button\",\n                    \"id\": \"8abbd55e-196a-42b5-849b-8e34b37b8bff\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"AirBlast\",\n                    \"type\": \"Button\",\n                    \"id\": \"8432fdd8-5d34-4724-abbb-bfd6d8b50736\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"MoveHole\",\n                    \"type\": \"Button\",\n                    \"id\": \"ae0ec320-b430-4fab-b045-2f6bde8b451b\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"UpgradePlantBed\",\n                    \"type\": \"Button\",\n                    \"id\": \"2b66e19b-44a6-40fb-9a91-0c028d3f34b7\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Shop\",\n                    \"type\": \"Button\",\n                    \"id\": \"faefaa5f-ef42-475d-ac5a-c1c9fdd9bf3a\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Rotate\",\n                    \"type\": \"Button\",\n                    \"id\": \"cb13e8ea-fadf-40d6-ab04-516a95051e14\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"DestroyBuildable\",\n                    \"type\": \"Button\",\n                    \"id\": \"8dea604d-ce73-48e5-b9bc-8e4130bd5fb5\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"PardnerCamLook\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"48206d07-88a7-4403-9786-f5287fd90f8e\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Crouch\",\n                    \"type\": \"Button\",\n                    \"id\": \"044dbe60-c4d9-4958-b44b-152def1505b5\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"42883911-c867-4e92-8c48-699863b11268\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ScrollPC\",\n                    \"type\": \"Button\",\n                    \"id\": \"88b0d285-944b-42ba-b12f-4e98b4511584\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Pointer\",\n                    \"type\": \"Value\",\n                    \"id\": \"0968e59f-e7cc-45d2-b757-2e035c30ad7a\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"LeftClick\",\n                    \"type\": \"Button\",\n                    \"id\": \"5beda3d3-dec2-4061-b372-56144a0a1614\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"26a8bb6c-2efe-4581-bbe7-cbe56e143661\",\n                    \"path\": \"2DVector(mode=2)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"168361b3-510d-410f-ae03-01660775012a\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"9a41b883-765d-4635-9d3a-ad4e65692480\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"f1ffef22-9090-40d4-b4ab-9b6b31b8bcb9\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"e0f6361f-aa25-4ce8-83f4-2edffe8eca98\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"2D Vector Controller\",\n                    \"id\": \"64696ecb-4285-455d-9c1e-cfe9b08c178c\",\n                    \"path\": \"2DVector(mode=2)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"StickDeadzone\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"41f7f90f-cdb0-4b40-8998-96311e39da69\",\n                    \"path\": \"<Gamepad>/leftStick/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"061310bd-f877-4d23-b069-000e71762bf0\",\n                    \"path\": \"<Gamepad>/leftStick/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"c077863c-ca3b-4996-ae3b-a1b65554bb03\",\n                    \"path\": \"<Gamepad>/leftStick/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"907dc177-2539-455a-956b-db2a614b0825\",\n                    \"path\": \"<Gamepad>/leftStick/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b615bdfa-f207-4efd-8688-d5fe602f1ee4\",\n                    \"path\": \"<Keyboard>/space\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0adea1dd-5a7e-4f8b-aa5e-0dd08308abe4\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d409c8ea-0adc-45c2-9518-f59dcc987c79\",\n                    \"path\": \"<Keyboard>/shift\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Sprint\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"40fb8209-8620-4092-b30d-2b0ed1380dc8\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Sprint\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4accd7b6-840c-44e3-950f-5e32497b66a2\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Throw\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"736479ed-851b-4add-a5a3-26a992cdd179\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Throw\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3a096155-dd6b-4376-93d3-a007a4e95271\",\n                    \"path\": \"<Keyboard>/e\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"PickUpAndUse\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"344fb576-8c34-4297-bf6f-b3c4494012e8\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"PickUpAndUse\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"15830248-9639-4c5a-a87d-9f3261f18587\",\n                    \"path\": \"<Keyboard>/q\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"UpgradePlantBed\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c2b1c59a-8f66-4599-8414-8c1c360abcd9\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"UpgradePlantBed\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"faf5d72f-a8a2-4fdd-b67f-40dab5404334\",\n                    \"path\": \"<Keyboard>/tab\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Shop\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"708fb985-25b3-4df4-a6c9-7bb75f579fe6\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Shop\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7ab20de1-cda6-4b94-8a10-ab839f63c262\",\n                    \"path\": \"<Mouse>/delta\",\n                    \"interactions\": \"\",\n                    \"processors\": \"DeltaTimeScale,ScaleVector2(x=0.1,y=0.1)\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"PardnerCamLook\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4211a7e7-8836-460a-9255-206b79dd1a5a\",\n                    \"path\": \"<Gamepad>/rightStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"StickDeadzone(min=0.05,max=0.95),ScaleVector2(x=20,y=20),StickAcceleration(power=2.1)\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"PardnerCamLook\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"de08ecf2-dfc4-4804-a4fd-dc521553a45b\",\n                    \"path\": \"<Keyboard>/c\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Crouch\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"fa7110ac-a12e-4992-9832-ef19c7fcd866\",\n                    \"path\": \"<Gamepad>/dpad/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Crouch\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"75818c89-2e6a-4502-a094-48bc4a6cd483\",\n                    \"path\": \"<Keyboard>/r\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"bd1bf1ea-960d-4477-a92d-2220aadcd8f9\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b25e0a7f-7ba1-4e5c-8066-bd748b52a07e\",\n                    \"path\": \"<Keyboard>/g\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"DestroyBuildable\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"90d80ffb-4147-4148-8874-033ef54c13b5\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"DestroyBuildable\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b499cfde-fde5-4524-9212-3987856407ce\",\n                    \"path\": \"<Keyboard>/g\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"BerryBlitz\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"80e1a64a-3db2-4e82-adaf-b0cfcf718973\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"BerryBlitz\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a1576277-8215-4edd-b70d-0a80d5bf8983\",\n                    \"path\": \"<Keyboard>/leftCtrl\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"AirBlast\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a2793ba7-30c8-43c6-bcfa-538cdae3a69b\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"AirBlast\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1c95c450-eb37-40d8-9e39-7fa5ee794bc5\",\n                    \"path\": \"<Keyboard>/h\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"GapingMaw\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"243a74a5-1278-4f38-befe-0aa5297fcfbc\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"GapingMaw\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d6c9e653-f61e-4d0c-8270-13819078e816\",\n                    \"path\": \"<Keyboard>/q\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"MoveHole\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c9c48448-5832-4ff7-8ef8-1da0df5229a5\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"MoveHole\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6209f47b-35ae-4194-bd97-6295a8f80843\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e2bc65aa-0fa8-4c3f-8154-2b5250db935e\",\n                    \"path\": \"<Gamepad>/start\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4ce6a1fc-9844-4acb-a386-f1845de89cc5\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"Drop\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4260939c-dd42-4b6f-97b2-ba65503dc4dc\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"Drop\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"MouseScroll\",\n                    \"id\": \"3379dac7-e46b-4236-a3c0-8c6b4cdb2916\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ScrollPC\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"65aa0e7e-4090-4977-aed9-5034ea60560e\",\n                    \"path\": \"<Mouse>/scroll/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"ScrollPC\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"74d2fa7a-927f-44a9-93ae-59539bc9b50b\",\n                    \"path\": \"<Mouse>/scroll/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KBM\",\n                    \"action\": \"ScrollPC\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"DpadUpDown\",\n                    \"id\": \"b2dd686f-c067-4ddc-80e0-b644907f58e1\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ScrollPC\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"5035216f-deea-4ceb-b844-d66346871beb\",\n                    \"path\": \"<Gamepad>/dpad/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"ScrollPC\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"54cb1076-ca53-4d19-8e21-641bcb3f7778\",\n                    \"path\": \"<Gamepad>/dpad/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Controller\",\n                    \"action\": \"ScrollPC\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6d4f2661-63a5-4372-abca-52773b7dd50f\",\n                    \"path\": \"<Mouse>/position\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Pointer\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4f9705b9-1ecd-45a7-990b-33740c7cc1dd\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"LeftClick\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"KBM\",\n            \"bindingGroup\": \"KBM\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Keyboard>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                },\n                {\n                    \"devicePath\": \"<Mouse>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Controller\",\n            \"bindingGroup\": \"Controller\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Gamepad>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                }\n            ]\n        }\n    ]\n}");
		m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
		m_PlayerActionMap_Movement = m_PlayerActionMap.FindAction("Movement", throwIfNotFound: true);
		m_PlayerActionMap_Jump = m_PlayerActionMap.FindAction("Jump", throwIfNotFound: true);
		m_PlayerActionMap_Sprint = m_PlayerActionMap.FindAction("Sprint", throwIfNotFound: true);
		m_PlayerActionMap_Throw = m_PlayerActionMap.FindAction("Throw", throwIfNotFound: true);
		m_PlayerActionMap_Drop = m_PlayerActionMap.FindAction("Drop", throwIfNotFound: true);
		m_PlayerActionMap_PickUpAndUse = m_PlayerActionMap.FindAction("PickUpAndUse", throwIfNotFound: true);
		m_PlayerActionMap_BerryBlitz = m_PlayerActionMap.FindAction("BerryBlitz", throwIfNotFound: true);
		m_PlayerActionMap_GapingMaw = m_PlayerActionMap.FindAction("GapingMaw", throwIfNotFound: true);
		m_PlayerActionMap_AirBlast = m_PlayerActionMap.FindAction("AirBlast", throwIfNotFound: true);
		m_PlayerActionMap_MoveHole = m_PlayerActionMap.FindAction("MoveHole", throwIfNotFound: true);
		m_PlayerActionMap_UpgradePlantBed = m_PlayerActionMap.FindAction("UpgradePlantBed", throwIfNotFound: true);
		m_PlayerActionMap_Shop = m_PlayerActionMap.FindAction("Shop", throwIfNotFound: true);
		m_PlayerActionMap_Rotate = m_PlayerActionMap.FindAction("Rotate", throwIfNotFound: true);
		m_PlayerActionMap_DestroyBuildable = m_PlayerActionMap.FindAction("DestroyBuildable", throwIfNotFound: true);
		m_PlayerActionMap_PardnerCamLook = m_PlayerActionMap.FindAction("PardnerCamLook", throwIfNotFound: true);
		m_PlayerActionMap_Crouch = m_PlayerActionMap.FindAction("Crouch", throwIfNotFound: true);
		m_PlayerActionMap_Escape = m_PlayerActionMap.FindAction("Escape", throwIfNotFound: true);
		m_PlayerActionMap_ScrollPC = m_PlayerActionMap.FindAction("ScrollPC", throwIfNotFound: true);
		m_PlayerActionMap_Pointer = m_PlayerActionMap.FindAction("Pointer", throwIfNotFound: true);
		m_PlayerActionMap_LeftClick = m_PlayerActionMap.FindAction("LeftClick", throwIfNotFound: true);
	}

	~InputActions()
	{
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
