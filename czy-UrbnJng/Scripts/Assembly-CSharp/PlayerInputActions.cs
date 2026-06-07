using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerInputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct CameraActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction Move => m_Wrapper.m_Camera_Move;

		public InputAction Rotate => m_Wrapper.m_Camera_Rotate;

		public InputAction Zoom => m_Wrapper.m_Camera_Zoom;

		public InputAction Drag => m_Wrapper.m_Camera_Drag;

		public InputAction HoldDrag => m_Wrapper.m_Camera_HoldDrag;

		public InputAction HoldRotate => m_Wrapper.m_Camera_HoldRotate;

		public bool enabled => Get().enabled;

		public CameraActions(PlayerInputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Camera;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(CameraActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(ICameraActions instance)
		{
			if (instance != null && !m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				Rotate.started += instance.OnRotate;
				Rotate.performed += instance.OnRotate;
				Rotate.canceled += instance.OnRotate;
				Zoom.started += instance.OnZoom;
				Zoom.performed += instance.OnZoom;
				Zoom.canceled += instance.OnZoom;
				Drag.started += instance.OnDrag;
				Drag.performed += instance.OnDrag;
				Drag.canceled += instance.OnDrag;
				HoldDrag.started += instance.OnHoldDrag;
				HoldDrag.performed += instance.OnHoldDrag;
				HoldDrag.canceled += instance.OnHoldDrag;
				HoldRotate.started += instance.OnHoldRotate;
				HoldRotate.performed += instance.OnHoldRotate;
				HoldRotate.canceled += instance.OnHoldRotate;
			}
		}

		private void UnregisterCallbacks(ICameraActions instance)
		{
			Move.started -= instance.OnMove;
			Move.performed -= instance.OnMove;
			Move.canceled -= instance.OnMove;
			Rotate.started -= instance.OnRotate;
			Rotate.performed -= instance.OnRotate;
			Rotate.canceled -= instance.OnRotate;
			Zoom.started -= instance.OnZoom;
			Zoom.performed -= instance.OnZoom;
			Zoom.canceled -= instance.OnZoom;
			Drag.started -= instance.OnDrag;
			Drag.performed -= instance.OnDrag;
			Drag.canceled -= instance.OnDrag;
			HoldDrag.started -= instance.OnHoldDrag;
			HoldDrag.performed -= instance.OnHoldDrag;
			HoldDrag.canceled -= instance.OnHoldDrag;
			HoldRotate.started -= instance.OnHoldRotate;
			HoldRotate.performed -= instance.OnHoldRotate;
			HoldRotate.canceled -= instance.OnHoldRotate;
		}

		public void RemoveCallbacks(ICameraActions instance)
		{
			if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(ICameraActions instance)
		{
			foreach (ICameraActions cameraActionsCallbackInterface in m_Wrapper.m_CameraActionsCallbackInterfaces)
			{
				UnregisterCallbacks(cameraActionsCallbackInterface);
			}
			m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct PlayerActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction Interact => m_Wrapper.m_Player_Interact;

		public InputAction InteractAlternate => m_Wrapper.m_Player_InteractAlternate;

		public bool enabled => Get().enabled;

		public PlayerActions(PlayerInputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Player;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(PlayerActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IPlayerActions instance)
		{
			if (instance != null && !m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
				Interact.started += instance.OnInteract;
				Interact.performed += instance.OnInteract;
				Interact.canceled += instance.OnInteract;
				InteractAlternate.started += instance.OnInteractAlternate;
				InteractAlternate.performed += instance.OnInteractAlternate;
				InteractAlternate.canceled += instance.OnInteractAlternate;
			}
		}

		private void UnregisterCallbacks(IPlayerActions instance)
		{
			Interact.started -= instance.OnInteract;
			Interact.performed -= instance.OnInteract;
			Interact.canceled -= instance.OnInteract;
			InteractAlternate.started -= instance.OnInteractAlternate;
			InteractAlternate.performed -= instance.OnInteractAlternate;
			InteractAlternate.canceled -= instance.OnInteractAlternate;
		}

		public void RemoveCallbacks(IPlayerActions instance)
		{
			if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IPlayerActions instance)
		{
			foreach (IPlayerActions playerActionsCallbackInterface in m_Wrapper.m_PlayerActionsCallbackInterfaces)
			{
				UnregisterCallbacks(playerActionsCallbackInterface);
			}
			m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct UIActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction Escape => m_Wrapper.m_UI_Escape;

		public InputAction Journal => m_Wrapper.m_UI_Journal;

		public InputAction NewPlant => m_Wrapper.m_UI_NewPlant;

		public InputAction NextRoom => m_Wrapper.m_UI_NextRoom;

		public InputAction FloorUp => m_Wrapper.m_UI_FloorUp;

		public InputAction FloorDown => m_Wrapper.m_UI_FloorDown;

		public InputAction Click => m_Wrapper.m_UI_Click;

		public InputAction RightClick => m_Wrapper.m_UI_RightClick;

		public InputAction MiddleClick => m_Wrapper.m_UI_MiddleClick;

		public InputAction ScrollWheel => m_Wrapper.m_UI_ScrollWheel;

		public InputAction Point => m_Wrapper.m_UI_Point;

		public InputAction Submit => m_Wrapper.m_UI_Submit;

		public InputAction Cancel => m_Wrapper.m_UI_Cancel;

		public InputAction Navigate => m_Wrapper.m_UI_Navigate;

		public InputAction MoveMouse => m_Wrapper.m_UI_MoveMouse;

		public InputAction PlantScrollRight => m_Wrapper.m_UI_PlantScrollRight;

		public InputAction PlantScrollLeft => m_Wrapper.m_UI_PlantScrollLeft;

		public InputAction Space => m_Wrapper.m_UI_Space;

		public InputAction SelectPlant => m_Wrapper.m_UI_SelectPlant;

		public InputAction InfoPlant => m_Wrapper.m_UI_InfoPlant;

		public bool enabled => Get().enabled;

		public UIActions(PlayerInputActions wrapper)
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

		public void AddCallbacks(IUIActions instance)
		{
			if (instance != null && !m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
				Escape.started += instance.OnEscape;
				Escape.performed += instance.OnEscape;
				Escape.canceled += instance.OnEscape;
				Journal.started += instance.OnJournal;
				Journal.performed += instance.OnJournal;
				Journal.canceled += instance.OnJournal;
				NewPlant.started += instance.OnNewPlant;
				NewPlant.performed += instance.OnNewPlant;
				NewPlant.canceled += instance.OnNewPlant;
				NextRoom.started += instance.OnNextRoom;
				NextRoom.performed += instance.OnNextRoom;
				NextRoom.canceled += instance.OnNextRoom;
				FloorUp.started += instance.OnFloorUp;
				FloorUp.performed += instance.OnFloorUp;
				FloorUp.canceled += instance.OnFloorUp;
				FloorDown.started += instance.OnFloorDown;
				FloorDown.performed += instance.OnFloorDown;
				FloorDown.canceled += instance.OnFloorDown;
				Click.started += instance.OnClick;
				Click.performed += instance.OnClick;
				Click.canceled += instance.OnClick;
				RightClick.started += instance.OnRightClick;
				RightClick.performed += instance.OnRightClick;
				RightClick.canceled += instance.OnRightClick;
				MiddleClick.started += instance.OnMiddleClick;
				MiddleClick.performed += instance.OnMiddleClick;
				MiddleClick.canceled += instance.OnMiddleClick;
				ScrollWheel.started += instance.OnScrollWheel;
				ScrollWheel.performed += instance.OnScrollWheel;
				ScrollWheel.canceled += instance.OnScrollWheel;
				Point.started += instance.OnPoint;
				Point.performed += instance.OnPoint;
				Point.canceled += instance.OnPoint;
				Submit.started += instance.OnSubmit;
				Submit.performed += instance.OnSubmit;
				Submit.canceled += instance.OnSubmit;
				Cancel.started += instance.OnCancel;
				Cancel.performed += instance.OnCancel;
				Cancel.canceled += instance.OnCancel;
				Navigate.started += instance.OnNavigate;
				Navigate.performed += instance.OnNavigate;
				Navigate.canceled += instance.OnNavigate;
				MoveMouse.started += instance.OnMoveMouse;
				MoveMouse.performed += instance.OnMoveMouse;
				MoveMouse.canceled += instance.OnMoveMouse;
				PlantScrollRight.started += instance.OnPlantScrollRight;
				PlantScrollRight.performed += instance.OnPlantScrollRight;
				PlantScrollRight.canceled += instance.OnPlantScrollRight;
				PlantScrollLeft.started += instance.OnPlantScrollLeft;
				PlantScrollLeft.performed += instance.OnPlantScrollLeft;
				PlantScrollLeft.canceled += instance.OnPlantScrollLeft;
				Space.started += instance.OnSpace;
				Space.performed += instance.OnSpace;
				Space.canceled += instance.OnSpace;
				SelectPlant.started += instance.OnSelectPlant;
				SelectPlant.performed += instance.OnSelectPlant;
				SelectPlant.canceled += instance.OnSelectPlant;
				InfoPlant.started += instance.OnInfoPlant;
				InfoPlant.performed += instance.OnInfoPlant;
				InfoPlant.canceled += instance.OnInfoPlant;
			}
		}

		private void UnregisterCallbacks(IUIActions instance)
		{
			Escape.started -= instance.OnEscape;
			Escape.performed -= instance.OnEscape;
			Escape.canceled -= instance.OnEscape;
			Journal.started -= instance.OnJournal;
			Journal.performed -= instance.OnJournal;
			Journal.canceled -= instance.OnJournal;
			NewPlant.started -= instance.OnNewPlant;
			NewPlant.performed -= instance.OnNewPlant;
			NewPlant.canceled -= instance.OnNewPlant;
			NextRoom.started -= instance.OnNextRoom;
			NextRoom.performed -= instance.OnNextRoom;
			NextRoom.canceled -= instance.OnNextRoom;
			FloorUp.started -= instance.OnFloorUp;
			FloorUp.performed -= instance.OnFloorUp;
			FloorUp.canceled -= instance.OnFloorUp;
			FloorDown.started -= instance.OnFloorDown;
			FloorDown.performed -= instance.OnFloorDown;
			FloorDown.canceled -= instance.OnFloorDown;
			Click.started -= instance.OnClick;
			Click.performed -= instance.OnClick;
			Click.canceled -= instance.OnClick;
			RightClick.started -= instance.OnRightClick;
			RightClick.performed -= instance.OnRightClick;
			RightClick.canceled -= instance.OnRightClick;
			MiddleClick.started -= instance.OnMiddleClick;
			MiddleClick.performed -= instance.OnMiddleClick;
			MiddleClick.canceled -= instance.OnMiddleClick;
			ScrollWheel.started -= instance.OnScrollWheel;
			ScrollWheel.performed -= instance.OnScrollWheel;
			ScrollWheel.canceled -= instance.OnScrollWheel;
			Point.started -= instance.OnPoint;
			Point.performed -= instance.OnPoint;
			Point.canceled -= instance.OnPoint;
			Submit.started -= instance.OnSubmit;
			Submit.performed -= instance.OnSubmit;
			Submit.canceled -= instance.OnSubmit;
			Cancel.started -= instance.OnCancel;
			Cancel.performed -= instance.OnCancel;
			Cancel.canceled -= instance.OnCancel;
			Navigate.started -= instance.OnNavigate;
			Navigate.performed -= instance.OnNavigate;
			Navigate.canceled -= instance.OnNavigate;
			MoveMouse.started -= instance.OnMoveMouse;
			MoveMouse.performed -= instance.OnMoveMouse;
			MoveMouse.canceled -= instance.OnMoveMouse;
			PlantScrollRight.started -= instance.OnPlantScrollRight;
			PlantScrollRight.performed -= instance.OnPlantScrollRight;
			PlantScrollRight.canceled -= instance.OnPlantScrollRight;
			PlantScrollLeft.started -= instance.OnPlantScrollLeft;
			PlantScrollLeft.performed -= instance.OnPlantScrollLeft;
			PlantScrollLeft.canceled -= instance.OnPlantScrollLeft;
			Space.started -= instance.OnSpace;
			Space.performed -= instance.OnSpace;
			Space.canceled -= instance.OnSpace;
			SelectPlant.started -= instance.OnSelectPlant;
			SelectPlant.performed -= instance.OnSelectPlant;
			SelectPlant.canceled -= instance.OnSelectPlant;
			InfoPlant.started -= instance.OnInfoPlant;
			InfoPlant.performed -= instance.OnInfoPlant;
			InfoPlant.canceled -= instance.OnInfoPlant;
		}

		public void RemoveCallbacks(IUIActions instance)
		{
			if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IUIActions instance)
		{
			foreach (IUIActions uIActionsCallbackInterface in m_Wrapper.m_UIActionsCallbackInterfaces)
			{
				UnregisterCallbacks(uIActionsCallbackInterface);
			}
			m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct JournalActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction RightPage => m_Wrapper.m_Journal_RightPage;

		public InputAction LeftPage => m_Wrapper.m_Journal_LeftPage;

		public InputAction RightSkin => m_Wrapper.m_Journal_RightSkin;

		public InputAction LeftSkin => m_Wrapper.m_Journal_LeftSkin;

		public InputAction BuySkin => m_Wrapper.m_Journal_BuySkin;

		public InputAction Quit => m_Wrapper.m_Journal_Quit;

		public InputAction PlantTab => m_Wrapper.m_Journal_PlantTab;

		public InputAction DiaryTab => m_Wrapper.m_Journal_DiaryTab;

		public bool enabled => Get().enabled;

		public JournalActions(PlayerInputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Journal;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(JournalActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IJournalActions instance)
		{
			if (instance != null && !m_Wrapper.m_JournalActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_JournalActionsCallbackInterfaces.Add(instance);
				RightPage.started += instance.OnRightPage;
				RightPage.performed += instance.OnRightPage;
				RightPage.canceled += instance.OnRightPage;
				LeftPage.started += instance.OnLeftPage;
				LeftPage.performed += instance.OnLeftPage;
				LeftPage.canceled += instance.OnLeftPage;
				RightSkin.started += instance.OnRightSkin;
				RightSkin.performed += instance.OnRightSkin;
				RightSkin.canceled += instance.OnRightSkin;
				LeftSkin.started += instance.OnLeftSkin;
				LeftSkin.performed += instance.OnLeftSkin;
				LeftSkin.canceled += instance.OnLeftSkin;
				BuySkin.started += instance.OnBuySkin;
				BuySkin.performed += instance.OnBuySkin;
				BuySkin.canceled += instance.OnBuySkin;
				Quit.started += instance.OnQuit;
				Quit.performed += instance.OnQuit;
				Quit.canceled += instance.OnQuit;
				PlantTab.started += instance.OnPlantTab;
				PlantTab.performed += instance.OnPlantTab;
				PlantTab.canceled += instance.OnPlantTab;
				DiaryTab.started += instance.OnDiaryTab;
				DiaryTab.performed += instance.OnDiaryTab;
				DiaryTab.canceled += instance.OnDiaryTab;
			}
		}

		private void UnregisterCallbacks(IJournalActions instance)
		{
			RightPage.started -= instance.OnRightPage;
			RightPage.performed -= instance.OnRightPage;
			RightPage.canceled -= instance.OnRightPage;
			LeftPage.started -= instance.OnLeftPage;
			LeftPage.performed -= instance.OnLeftPage;
			LeftPage.canceled -= instance.OnLeftPage;
			RightSkin.started -= instance.OnRightSkin;
			RightSkin.performed -= instance.OnRightSkin;
			RightSkin.canceled -= instance.OnRightSkin;
			LeftSkin.started -= instance.OnLeftSkin;
			LeftSkin.performed -= instance.OnLeftSkin;
			LeftSkin.canceled -= instance.OnLeftSkin;
			BuySkin.started -= instance.OnBuySkin;
			BuySkin.performed -= instance.OnBuySkin;
			BuySkin.canceled -= instance.OnBuySkin;
			Quit.started -= instance.OnQuit;
			Quit.performed -= instance.OnQuit;
			Quit.canceled -= instance.OnQuit;
			PlantTab.started -= instance.OnPlantTab;
			PlantTab.performed -= instance.OnPlantTab;
			PlantTab.canceled -= instance.OnPlantTab;
			DiaryTab.started -= instance.OnDiaryTab;
			DiaryTab.performed -= instance.OnDiaryTab;
			DiaryTab.canceled -= instance.OnDiaryTab;
		}

		public void RemoveCallbacks(IJournalActions instance)
		{
			if (m_Wrapper.m_JournalActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IJournalActions instance)
		{
			foreach (IJournalActions journalActionsCallbackInterface in m_Wrapper.m_JournalActionsCallbackInterfaces)
			{
				UnregisterCallbacks(journalActionsCallbackInterface);
			}
			m_Wrapper.m_JournalActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct ChoosePlantActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction RightSkin => m_Wrapper.m_ChoosePlant_RightSkin;

		public InputAction LeftSkin => m_Wrapper.m_ChoosePlant_LeftSkin;

		public InputAction RightPlant => m_Wrapper.m_ChoosePlant_RightPlant;

		public InputAction LeftPlant => m_Wrapper.m_ChoosePlant_LeftPlant;

		public InputAction SelectPlant => m_Wrapper.m_ChoosePlant_SelectPlant;

		public InputAction Quit => m_Wrapper.m_ChoosePlant_Quit;

		public InputAction BuySkin => m_Wrapper.m_ChoosePlant_BuySkin;

		public InputAction ConfirmChoice => m_Wrapper.m_ChoosePlant_ConfirmChoice;

		public InputAction RandomSkin => m_Wrapper.m_ChoosePlant_RandomSkin;

		public bool enabled => Get().enabled;

		public ChoosePlantActions(PlayerInputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_ChoosePlant;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(ChoosePlantActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IChoosePlantActions instance)
		{
			if (instance != null && !m_Wrapper.m_ChoosePlantActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_ChoosePlantActionsCallbackInterfaces.Add(instance);
				RightSkin.started += instance.OnRightSkin;
				RightSkin.performed += instance.OnRightSkin;
				RightSkin.canceled += instance.OnRightSkin;
				LeftSkin.started += instance.OnLeftSkin;
				LeftSkin.performed += instance.OnLeftSkin;
				LeftSkin.canceled += instance.OnLeftSkin;
				RightPlant.started += instance.OnRightPlant;
				RightPlant.performed += instance.OnRightPlant;
				RightPlant.canceled += instance.OnRightPlant;
				LeftPlant.started += instance.OnLeftPlant;
				LeftPlant.performed += instance.OnLeftPlant;
				LeftPlant.canceled += instance.OnLeftPlant;
				SelectPlant.started += instance.OnSelectPlant;
				SelectPlant.performed += instance.OnSelectPlant;
				SelectPlant.canceled += instance.OnSelectPlant;
				Quit.started += instance.OnQuit;
				Quit.performed += instance.OnQuit;
				Quit.canceled += instance.OnQuit;
				BuySkin.started += instance.OnBuySkin;
				BuySkin.performed += instance.OnBuySkin;
				BuySkin.canceled += instance.OnBuySkin;
				ConfirmChoice.started += instance.OnConfirmChoice;
				ConfirmChoice.performed += instance.OnConfirmChoice;
				ConfirmChoice.canceled += instance.OnConfirmChoice;
				RandomSkin.started += instance.OnRandomSkin;
				RandomSkin.performed += instance.OnRandomSkin;
				RandomSkin.canceled += instance.OnRandomSkin;
			}
		}

		private void UnregisterCallbacks(IChoosePlantActions instance)
		{
			RightSkin.started -= instance.OnRightSkin;
			RightSkin.performed -= instance.OnRightSkin;
			RightSkin.canceled -= instance.OnRightSkin;
			LeftSkin.started -= instance.OnLeftSkin;
			LeftSkin.performed -= instance.OnLeftSkin;
			LeftSkin.canceled -= instance.OnLeftSkin;
			RightPlant.started -= instance.OnRightPlant;
			RightPlant.performed -= instance.OnRightPlant;
			RightPlant.canceled -= instance.OnRightPlant;
			LeftPlant.started -= instance.OnLeftPlant;
			LeftPlant.performed -= instance.OnLeftPlant;
			LeftPlant.canceled -= instance.OnLeftPlant;
			SelectPlant.started -= instance.OnSelectPlant;
			SelectPlant.performed -= instance.OnSelectPlant;
			SelectPlant.canceled -= instance.OnSelectPlant;
			Quit.started -= instance.OnQuit;
			Quit.performed -= instance.OnQuit;
			Quit.canceled -= instance.OnQuit;
			BuySkin.started -= instance.OnBuySkin;
			BuySkin.performed -= instance.OnBuySkin;
			BuySkin.canceled -= instance.OnBuySkin;
			ConfirmChoice.started -= instance.OnConfirmChoice;
			ConfirmChoice.performed -= instance.OnConfirmChoice;
			ConfirmChoice.canceled -= instance.OnConfirmChoice;
			RandomSkin.started -= instance.OnRandomSkin;
			RandomSkin.performed -= instance.OnRandomSkin;
			RandomSkin.canceled -= instance.OnRandomSkin;
		}

		public void RemoveCallbacks(IChoosePlantActions instance)
		{
			if (m_Wrapper.m_ChoosePlantActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IChoosePlantActions instance)
		{
			foreach (IChoosePlantActions choosePlantActionsCallbackInterface in m_Wrapper.m_ChoosePlantActionsCallbackInterfaces)
			{
				UnregisterCallbacks(choosePlantActionsCallbackInterface);
			}
			m_Wrapper.m_ChoosePlantActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct MainMenuActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction Submit => m_Wrapper.m_MainMenu_Submit;

		public InputAction MoveDown => m_Wrapper.m_MainMenu_MoveDown;

		public InputAction MoveUp => m_Wrapper.m_MainMenu_MoveUp;

		public InputAction Settings => m_Wrapper.m_MainMenu_Settings;

		public InputAction ExitGame => m_Wrapper.m_MainMenu_ExitGame;

		public InputAction CloseWindow => m_Wrapper.m_MainMenu_CloseWindow;

		public bool enabled => Get().enabled;

		public MainMenuActions(PlayerInputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_MainMenu;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(MainMenuActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IMainMenuActions instance)
		{
			if (instance != null && !m_Wrapper.m_MainMenuActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_MainMenuActionsCallbackInterfaces.Add(instance);
				Submit.started += instance.OnSubmit;
				Submit.performed += instance.OnSubmit;
				Submit.canceled += instance.OnSubmit;
				MoveDown.started += instance.OnMoveDown;
				MoveDown.performed += instance.OnMoveDown;
				MoveDown.canceled += instance.OnMoveDown;
				MoveUp.started += instance.OnMoveUp;
				MoveUp.performed += instance.OnMoveUp;
				MoveUp.canceled += instance.OnMoveUp;
				Settings.started += instance.OnSettings;
				Settings.performed += instance.OnSettings;
				Settings.canceled += instance.OnSettings;
				ExitGame.started += instance.OnExitGame;
				ExitGame.performed += instance.OnExitGame;
				ExitGame.canceled += instance.OnExitGame;
				CloseWindow.started += instance.OnCloseWindow;
				CloseWindow.performed += instance.OnCloseWindow;
				CloseWindow.canceled += instance.OnCloseWindow;
			}
		}

		private void UnregisterCallbacks(IMainMenuActions instance)
		{
			Submit.started -= instance.OnSubmit;
			Submit.performed -= instance.OnSubmit;
			Submit.canceled -= instance.OnSubmit;
			MoveDown.started -= instance.OnMoveDown;
			MoveDown.performed -= instance.OnMoveDown;
			MoveDown.canceled -= instance.OnMoveDown;
			MoveUp.started -= instance.OnMoveUp;
			MoveUp.performed -= instance.OnMoveUp;
			MoveUp.canceled -= instance.OnMoveUp;
			Settings.started -= instance.OnSettings;
			Settings.performed -= instance.OnSettings;
			Settings.canceled -= instance.OnSettings;
			ExitGame.started -= instance.OnExitGame;
			ExitGame.performed -= instance.OnExitGame;
			ExitGame.canceled -= instance.OnExitGame;
			CloseWindow.started -= instance.OnCloseWindow;
			CloseWindow.performed -= instance.OnCloseWindow;
			CloseWindow.canceled -= instance.OnCloseWindow;
		}

		public void RemoveCallbacks(IMainMenuActions instance)
		{
			if (m_Wrapper.m_MainMenuActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IMainMenuActions instance)
		{
			foreach (IMainMenuActions mainMenuActionsCallbackInterface in m_Wrapper.m_MainMenuActionsCallbackInterfaces)
			{
				UnregisterCallbacks(mainMenuActionsCallbackInterface);
			}
			m_Wrapper.m_MainMenuActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct DialogsActions
	{
		private PlayerInputActions m_Wrapper;

		public InputAction AnswerDown => m_Wrapper.m_Dialogs_AnswerDown;

		public InputAction AnswerUp => m_Wrapper.m_Dialogs_AnswerUp;

		public InputAction ConfirmChoice => m_Wrapper.m_Dialogs_ConfirmChoice;

		public bool enabled => Get().enabled;

		public DialogsActions(PlayerInputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Dialogs;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(DialogsActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IDialogsActions instance)
		{
			if (instance != null && !m_Wrapper.m_DialogsActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_DialogsActionsCallbackInterfaces.Add(instance);
				AnswerDown.started += instance.OnAnswerDown;
				AnswerDown.performed += instance.OnAnswerDown;
				AnswerDown.canceled += instance.OnAnswerDown;
				AnswerUp.started += instance.OnAnswerUp;
				AnswerUp.performed += instance.OnAnswerUp;
				AnswerUp.canceled += instance.OnAnswerUp;
				ConfirmChoice.started += instance.OnConfirmChoice;
				ConfirmChoice.performed += instance.OnConfirmChoice;
				ConfirmChoice.canceled += instance.OnConfirmChoice;
			}
		}

		private void UnregisterCallbacks(IDialogsActions instance)
		{
			AnswerDown.started -= instance.OnAnswerDown;
			AnswerDown.performed -= instance.OnAnswerDown;
			AnswerDown.canceled -= instance.OnAnswerDown;
			AnswerUp.started -= instance.OnAnswerUp;
			AnswerUp.performed -= instance.OnAnswerUp;
			AnswerUp.canceled -= instance.OnAnswerUp;
			ConfirmChoice.started -= instance.OnConfirmChoice;
			ConfirmChoice.performed -= instance.OnConfirmChoice;
			ConfirmChoice.canceled -= instance.OnConfirmChoice;
		}

		public void RemoveCallbacks(IDialogsActions instance)
		{
			if (m_Wrapper.m_DialogsActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IDialogsActions instance)
		{
			foreach (IDialogsActions dialogsActionsCallbackInterface in m_Wrapper.m_DialogsActionsCallbackInterfaces)
			{
				UnregisterCallbacks(dialogsActionsCallbackInterface);
			}
			m_Wrapper.m_DialogsActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface ICameraActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnZoom(InputAction.CallbackContext context);

		void OnDrag(InputAction.CallbackContext context);

		void OnHoldDrag(InputAction.CallbackContext context);

		void OnHoldRotate(InputAction.CallbackContext context);
	}

	public interface IPlayerActions
	{
		void OnInteract(InputAction.CallbackContext context);

		void OnInteractAlternate(InputAction.CallbackContext context);
	}

	public interface IUIActions
	{
		void OnEscape(InputAction.CallbackContext context);

		void OnJournal(InputAction.CallbackContext context);

		void OnNewPlant(InputAction.CallbackContext context);

		void OnNextRoom(InputAction.CallbackContext context);

		void OnFloorUp(InputAction.CallbackContext context);

		void OnFloorDown(InputAction.CallbackContext context);

		void OnClick(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnMiddleClick(InputAction.CallbackContext context);

		void OnScrollWheel(InputAction.CallbackContext context);

		void OnPoint(InputAction.CallbackContext context);

		void OnSubmit(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnNavigate(InputAction.CallbackContext context);

		void OnMoveMouse(InputAction.CallbackContext context);

		void OnPlantScrollRight(InputAction.CallbackContext context);

		void OnPlantScrollLeft(InputAction.CallbackContext context);

		void OnSpace(InputAction.CallbackContext context);

		void OnSelectPlant(InputAction.CallbackContext context);

		void OnInfoPlant(InputAction.CallbackContext context);
	}

	public interface IJournalActions
	{
		void OnRightPage(InputAction.CallbackContext context);

		void OnLeftPage(InputAction.CallbackContext context);

		void OnRightSkin(InputAction.CallbackContext context);

		void OnLeftSkin(InputAction.CallbackContext context);

		void OnBuySkin(InputAction.CallbackContext context);

		void OnQuit(InputAction.CallbackContext context);

		void OnPlantTab(InputAction.CallbackContext context);

		void OnDiaryTab(InputAction.CallbackContext context);
	}

	public interface IChoosePlantActions
	{
		void OnRightSkin(InputAction.CallbackContext context);

		void OnLeftSkin(InputAction.CallbackContext context);

		void OnRightPlant(InputAction.CallbackContext context);

		void OnLeftPlant(InputAction.CallbackContext context);

		void OnSelectPlant(InputAction.CallbackContext context);

		void OnQuit(InputAction.CallbackContext context);

		void OnBuySkin(InputAction.CallbackContext context);

		void OnConfirmChoice(InputAction.CallbackContext context);

		void OnRandomSkin(InputAction.CallbackContext context);
	}

	public interface IMainMenuActions
	{
		void OnSubmit(InputAction.CallbackContext context);

		void OnMoveDown(InputAction.CallbackContext context);

		void OnMoveUp(InputAction.CallbackContext context);

		void OnSettings(InputAction.CallbackContext context);

		void OnExitGame(InputAction.CallbackContext context);

		void OnCloseWindow(InputAction.CallbackContext context);
	}

	public interface IDialogsActions
	{
		void OnAnswerDown(InputAction.CallbackContext context);

		void OnAnswerUp(InputAction.CallbackContext context);

		void OnConfirmChoice(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Camera;

	private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();

	private readonly InputAction m_Camera_Move;

	private readonly InputAction m_Camera_Rotate;

	private readonly InputAction m_Camera_Zoom;

	private readonly InputAction m_Camera_Drag;

	private readonly InputAction m_Camera_HoldDrag;

	private readonly InputAction m_Camera_HoldRotate;

	private readonly InputActionMap m_Player;

	private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();

	private readonly InputAction m_Player_Interact;

	private readonly InputAction m_Player_InteractAlternate;

	private readonly InputActionMap m_UI;

	private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();

	private readonly InputAction m_UI_Escape;

	private readonly InputAction m_UI_Journal;

	private readonly InputAction m_UI_NewPlant;

	private readonly InputAction m_UI_NextRoom;

	private readonly InputAction m_UI_FloorUp;

	private readonly InputAction m_UI_FloorDown;

	private readonly InputAction m_UI_Click;

	private readonly InputAction m_UI_RightClick;

	private readonly InputAction m_UI_MiddleClick;

	private readonly InputAction m_UI_ScrollWheel;

	private readonly InputAction m_UI_Point;

	private readonly InputAction m_UI_Submit;

	private readonly InputAction m_UI_Cancel;

	private readonly InputAction m_UI_Navigate;

	private readonly InputAction m_UI_MoveMouse;

	private readonly InputAction m_UI_PlantScrollRight;

	private readonly InputAction m_UI_PlantScrollLeft;

	private readonly InputAction m_UI_Space;

	private readonly InputAction m_UI_SelectPlant;

	private readonly InputAction m_UI_InfoPlant;

	private readonly InputActionMap m_Journal;

	private List<IJournalActions> m_JournalActionsCallbackInterfaces = new List<IJournalActions>();

	private readonly InputAction m_Journal_RightPage;

	private readonly InputAction m_Journal_LeftPage;

	private readonly InputAction m_Journal_RightSkin;

	private readonly InputAction m_Journal_LeftSkin;

	private readonly InputAction m_Journal_BuySkin;

	private readonly InputAction m_Journal_Quit;

	private readonly InputAction m_Journal_PlantTab;

	private readonly InputAction m_Journal_DiaryTab;

	private readonly InputActionMap m_ChoosePlant;

	private List<IChoosePlantActions> m_ChoosePlantActionsCallbackInterfaces = new List<IChoosePlantActions>();

	private readonly InputAction m_ChoosePlant_RightSkin;

	private readonly InputAction m_ChoosePlant_LeftSkin;

	private readonly InputAction m_ChoosePlant_RightPlant;

	private readonly InputAction m_ChoosePlant_LeftPlant;

	private readonly InputAction m_ChoosePlant_SelectPlant;

	private readonly InputAction m_ChoosePlant_Quit;

	private readonly InputAction m_ChoosePlant_BuySkin;

	private readonly InputAction m_ChoosePlant_ConfirmChoice;

	private readonly InputAction m_ChoosePlant_RandomSkin;

	private readonly InputActionMap m_MainMenu;

	private List<IMainMenuActions> m_MainMenuActionsCallbackInterfaces = new List<IMainMenuActions>();

	private readonly InputAction m_MainMenu_Submit;

	private readonly InputAction m_MainMenu_MoveDown;

	private readonly InputAction m_MainMenu_MoveUp;

	private readonly InputAction m_MainMenu_Settings;

	private readonly InputAction m_MainMenu_ExitGame;

	private readonly InputAction m_MainMenu_CloseWindow;

	private readonly InputActionMap m_Dialogs;

	private List<IDialogsActions> m_DialogsActionsCallbackInterfaces = new List<IDialogsActions>();

	private readonly InputAction m_Dialogs_AnswerDown;

	private readonly InputAction m_Dialogs_AnswerUp;

	private readonly InputAction m_Dialogs_ConfirmChoice;

	private int m_KeyboardSchemeIndex = -1;

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

	public CameraActions Camera => new CameraActions(this);

	public PlayerActions Player => new PlayerActions(this);

	public UIActions UI => new UIActions(this);

	public JournalActions Journal => new JournalActions(this);

	public ChoosePlantActions ChoosePlant => new ChoosePlantActions(this);

	public MainMenuActions MainMenu => new MainMenuActions(this);

	public DialogsActions Dialogs => new DialogsActions(this);

	public InputControlScheme KeyboardScheme
	{
		get
		{
			if (m_KeyboardSchemeIndex == -1)
			{
				m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
			}
			return asset.controlSchemes[m_KeyboardSchemeIndex];
		}
	}

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

	public PlayerInputActions()
	{
		asset = InputActionAsset.FromJson("{\n    \"name\": \"PlayerInputActions\",\n    \"maps\": [\n        {\n            \"name\": \"Camera\",\n            \"id\": \"4b78c967-f88f-49f1-8314-921c13eaf5b9\",\n            \"actions\": [\n                {\n                    \"name\": \"Move\",\n                    \"type\": \"Value\",\n                    \"id\": \"8b93efe3-2266-4540-a8d7-20b603eafa51\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Rotate\",\n                    \"type\": \"Value\",\n                    \"id\": \"439a5764-a4c8-425d-8626-6ef45e24f25e\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Zoom\",\n                    \"type\": \"Value\",\n                    \"id\": \"952ff066-07a1-4f9b-b23e-2554fada4245\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Drag\",\n                    \"type\": \"Value\",\n                    \"id\": \"6e62d8d1-8421-4644-86f2-73bef9d6e4f6\",\n                    \"expectedControlType\": \"Delta\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"HoldDrag\",\n                    \"type\": \"Button\",\n                    \"id\": \"d18186ee-ac9a-4332-a256-3425e36a1ee9\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"HoldRotate\",\n                    \"type\": \"Button\",\n                    \"id\": \"b338e615-1a20-4fd6-bf54-c4fbfde03043\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"WASD\",\n                    \"id\": \"b05115ed-805d-4995-9374-36169246282d\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Move\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"c692b5f8-51c1-4f95-b1fc-130b07db53a9\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"07b2b232-a5c9-4776-aed4-e7461e90a52b\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"067f91c5-d397-4e14-8745-ac0432d1a6e7\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"7eb9885e-8280-49d5-9575-45f447c18b9c\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"Arrow\",\n                    \"id\": \"4d7df45b-41ff-40d1-a610-c11b3c38ae35\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Move\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"dc1be172-7790-4041-8787-fb8d836f0cde\",\n                    \"path\": \"<Keyboard>/upArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"550590a0-d316-4a56-9277-41fbfd2d2151\",\n                    \"path\": \"<Keyboard>/downArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"34a39a8a-15db-474f-8710-e15ebb2021c1\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"b09d96f7-10da-4bf4-87ba-d5ee77d60ce0\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d2ffb0a2-3fb5-4524-a280-1beb9cd22330\",\n                    \"path\": \"<Gamepad>/rightStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"StickDeadzone\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"QE\",\n                    \"id\": \"7cbc43a1-ec80-40dc-89f8-97f77925c349\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"9f845390-9828-41cb-bc09-93deb855bd95\",\n                    \"path\": \"<Keyboard>/q\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"fc82d014-ade7-415d-a8fe-ae998230c812\",\n                    \"path\": \"<Keyboard>/e\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"e1b00523-92be-4650-a2d8-a38e0975b5af\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"ae171283-6557-4ca2-b0a5-78f7293bf075\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"725dcf8a-9dc4-4a80-b40e-29b36cc923bf\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b636231d-0301-4251-a054-3ec90723f27d\",\n                    \"path\": \"<Mouse>/scroll\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"Keyboard\",\n                    \"id\": \"2f18d366-098f-4efc-ad4b-a9fd05646af1\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"c6caffa3-56a1-473e-828f-fbd7ab200036\",\n                    \"path\": \"<Keyboard>/numpadPlus\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"e315342a-33ce-4fd0-987e-fc2c2645f7da\",\n                    \"path\": \"<Keyboard>/numpadMinus\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"8b6e0a81-267d-408f-8604-fd3502cf773d\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"c440eb52-9ead-4a78-bcdd-869ad1d2915b\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"2bd1fc9e-6e61-44d1-b86e-508a576eafbb\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"fc2ef27d-2e7e-4671-92c1-11e6849ffa43\",\n                    \"path\": \"<Mouse>/delta\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";Keyboard\",\n                    \"action\": \"Drag\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"66bf88c9-67ed-4521-ab95-2d0fc9f6a07c\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";Keyboard\",\n                    \"action\": \"HoldDrag\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"606611f9-2623-4af6-87b7-f3522b7f71e5\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";Keyboard\",\n                    \"action\": \"HoldRotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Player\",\n            \"id\": \"2afe4197-befa-4cca-9e63-6b29b0265828\",\n            \"actions\": [\n                {\n                    \"name\": \"Interact\",\n                    \"type\": \"Button\",\n                    \"id\": \"0b296ad6-ac9f-44d1-b8dc-0d39da5e1bc5\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"InteractAlternate\",\n                    \"type\": \"Button\",\n                    \"id\": \"b8bb593b-eaf3-4838-b918-dde8b1479126\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"177979ae-1356-4ab5-8ca9-70bad2f4349b\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"638444c7-b5b9-423f-bd77-4e269c6a9bcd\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"231761d0-019a-43cf-82b9-e868cbc2f15d\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"InteractAlternate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ae758690-4e89-425e-a41b-3731002190f0\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"InteractAlternate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"UI\",\n            \"id\": \"f448f541-0503-43df-9a3f-06900559ec74\",\n            \"actions\": [\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"b6a2d1a9-498e-45df-ac3f-0809d250f2f5\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Journal\",\n                    \"type\": \"Button\",\n                    \"id\": \"48844307-ae5c-4ca6-b0e4-d2dbd6fc5188\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"NewPlant\",\n                    \"type\": \"Button\",\n                    \"id\": \"186c76a0-a658-4e97-9521-b9745bdc1c10\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"NextRoom\",\n                    \"type\": \"Button\",\n                    \"id\": \"7385eb71-d75b-4cc1-a134-09b73ebf1603\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"FloorUp\",\n                    \"type\": \"Button\",\n                    \"id\": \"bfc6a055-d99f-4d02-9ac0-d7052ff5ef92\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"FloorDown\",\n                    \"type\": \"Button\",\n                    \"id\": \"c763104d-2fd9-4650-9183-255a842c4295\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Click\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"36e624ae-cb13-4b55-adde-8a3719a8f2d6\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"RightClick\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"7d92e94c-c5fc-461a-88ef-ed1dcf96a513\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"MiddleClick\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"a75e1f3d-6c20-4c04-8573-ef8e6d680bec\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ScrollWheel\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"456a3b93-9d23-4aeb-9abe-a6cabd3b9052\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Point\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"c2ca1bff-cdc7-4b5e-a1ab-f831c5b82065\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Submit\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"e5ec3cc5-bfb6-41db-90aa-0d91dac4eb1e\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Cancel\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"311debc6-b7fa-42df-a935-83c48c6ce72e\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Navigate\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"03b4eada-b080-4255-afeb-71d563d4fe71\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"MoveMouse\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"e6c4bf5d-88dc-4476-b09f-fad9f50fe73b\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"PlantScrollRight\",\n                    \"type\": \"Button\",\n                    \"id\": \"40a641e2-59b4-443f-8b41-0ddbf82055b7\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"PlantScrollLeft\",\n                    \"type\": \"Button\",\n                    \"id\": \"a343bbb8-88a4-4bc1-a538-b97156bb809b\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Space\",\n                    \"type\": \"PassThrough\",\n                    \"id\": \"ac28c88e-c73b-488f-b2b3-65bac798708b\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"SelectPlant\",\n                    \"type\": \"Button\",\n                    \"id\": \"d5164aae-0b3c-4148-a258-d4a04de07a3c\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"InfoPlant\",\n                    \"type\": \"Button\",\n                    \"id\": \"2dfa7a90-8b98-4e84-85b4-50ee2aa82e13\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"a47f6b6f-a746-4501-8031-bf95687ff5e9\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"29ed64a9-027c-4e38-9788-f9743ab3e9c7\",\n                    \"path\": \"<Gamepad>/start\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"136677c8-ef00-477b-bf7b-702c18cc7153\",\n                    \"path\": \"<Keyboard>/j\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Journal\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"553a9366-4744-4d7f-8d08-e46a06b4a3cd\",\n                    \"path\": \"<Keyboard>/n\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"NewPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"bb246af0-f718-4524-b2fe-4772ec0af568\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"NewPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"32f570c1-eb8d-4709-bf36-7044a2b05985\",\n                    \"path\": \"<Keyboard>/r\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"NextRoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"81c99447-7f38-48c4-af8f-5caedd357b3a\",\n                    \"path\": \"<Gamepad>/rightStickPress\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"NextRoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d5412e1b-453f-4dc0-9bd0-b42f8ae3ac9d\",\n                    \"path\": \"<Keyboard>/pageUp\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"FloorUp\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c0950d7e-36a1-421b-97da-b869198b4970\",\n                    \"path\": \"<Gamepad>/dpad/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"FloorUp\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0c6b6a24-3b8f-4e87-bc3b-c2effef33f65\",\n                    \"path\": \"<Keyboard>/pageDown\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"FloorDown\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6ee8d674-d55d-4125-ae22-0a96fed861ab\",\n                    \"path\": \"<Gamepad>/dpad/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"FloorDown\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7338419f-115a-4024-96f3-4a24ffc390c3\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Click\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"434897f8-5a8c-4f24-b803-f25926877bec\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Click\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3041b448-3a98-4cf3-a4d0-0d73ffb1a2f0\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RightClick\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1a8ca455-ebd3-42ac-a1d7-91b3186bec3c\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RightClick\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b6969ed0-1e81-4eb1-992e-12b74ef4fa89\",\n                    \"path\": \"<Mouse>/middleButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"MiddleClick\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"8abe2db7-17f8-40f1-bb52-27dbc87a1439\",\n                    \"path\": \"<Mouse>/scroll\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"ScrollWheel\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"bdf72cde-b57d-4771-9dd2-06dba6b9b449\",\n                    \"path\": \"<Mouse>/position\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Point\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"56ad2f56-1e59-4bef-841d-b25b83e949ec\",\n                    \"path\": \"*/{Submit}\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard;Gamepad\",\n                    \"action\": \"Submit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4427354e-cd04-4974-adbd-c9fec218e56f\",\n                    \"path\": \"*/{Cancel}\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Cancel\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"06f4587a-2840-4917-b0ca-909b78217f69\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"120750fd-34cb-467f-aaef-f61978848775\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"f0ea7875-5f3d-46d6-9b0a-e2e019ed8c0c\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"1ea5edce-4248-4782-9825-5a9475b5e66a\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"a2116ad1-7b3f-4736-ae25-707cf7cd8796\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"e5aba879-2d72-48c9-9875-eedefb84878f\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"e866aa34-3ee7-4b81-8d4d-35d86693a2de\",\n                    \"path\": \"<Keyboard>/upArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"74e3f5bc-4f76-4151-97bd-cd524709fc86\",\n                    \"path\": \"<Keyboard>/downArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"7dcda234-c11b-4f86-82b1-75ddb622f573\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"0433eb81-beb9-4bdc-8da0-f90949c97a32\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Navigate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b5f5899a-ec2f-4ebd-b1b6-e7b27ae3fcbf\",\n                    \"path\": \"<Gamepad>/leftStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"MoveMouse\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"9e2b6dbf-541b-4be4-9d38-b877c0d9cb4a\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"PlantScrollRight\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"fbff370f-2d26-40ff-bd19-08fd8f82795a\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"PlantScrollLeft\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"544e4571-3d5a-4bd8-a790-ca93c5bcaefa\",\n                    \"path\": \"<Keyboard>/space\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard\",\n                    \"action\": \"Space\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"62ec6821-5f93-457f-b332-683b98c72d8c\",\n                    \"path\": \"<Gamepad>/buttonWest\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"SelectPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6b70b4f0-2adc-4ea1-aa2e-87ae3d2b291a\",\n                    \"path\": \"<Gamepad>/leftStickPress\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Journal\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ba0706e7-ccc1-4ff9-b253-7a3e6ebe7dd8\",\n                    \"path\": \"<Keyboard>/i\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";Keyboard\",\n                    \"action\": \"InfoPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Journal\",\n            \"id\": \"f35f7feb-62af-462e-a27d-7394c1853eaa\",\n            \"actions\": [\n                {\n                    \"name\": \"RightPage\",\n                    \"type\": \"Button\",\n                    \"id\": \"05166575-0e0b-48d4-aacf-23304ad0d4d8\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"LeftPage\",\n                    \"type\": \"Button\",\n                    \"id\": \"c26071c6-af6f-402c-b0d6-ec81a0780ba2\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"RightSkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"211c0a43-4662-490c-a682-9094b386b545\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"LeftSkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"eb343869-9d98-418f-8b4a-8db3fdf41f61\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"BuySkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"df1fb438-f338-4edb-a66f-3b0cda02a687\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Quit\",\n                    \"type\": \"Button\",\n                    \"id\": \"7f2d4631-a4a8-4cf6-9087-683aa7d609ab\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"PlantTab\",\n                    \"type\": \"Button\",\n                    \"id\": \"20f299cb-e884-4a75-9dc0-009eb8c387dd\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"DiaryTab\",\n                    \"type\": \"Button\",\n                    \"id\": \"d39992a5-a865-4c5b-af9e-22a1d981fef2\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"fdb099e3-f451-4919-9800-d0a3f788d7fa\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightPage\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"f9f8db8b-a110-4c59-9bc6-9c98e1f415e8\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftPage\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0e70f441-5c16-40ab-b04b-b9966f1cc533\",\n                    \"path\": \"<Gamepad>/rightStick/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"dbc138f9-9b2f-417a-bdb3-25cf5c7d2e6d\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"77003860-8691-41d5-a9e3-17b1094851e9\",\n                    \"path\": \"<Gamepad>/rightStick/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"da4653d9-2b2d-43cc-85ec-39fdccaacd2c\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6ad81256-0ace-4ee6-b6dc-274aeda8b7dd\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"BuySkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"18f8eb59-7237-4331-8ac9-6bcd4261a16d\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Quit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7ce6b280-612e-4dbe-8db4-63a926a22bfa\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"PlantTab\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"f9606c95-c66a-46bf-9a36-fbdd8130c56f\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"DiaryTab\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"ChoosePlant\",\n            \"id\": \"a426ce24-b698-4114-b084-dc65c0289289\",\n            \"actions\": [\n                {\n                    \"name\": \"RightSkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"923ee1ee-3733-4bc7-82a8-564fbe006bd5\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"LeftSkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"1b906107-9334-4177-a7df-d559510db080\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"RightPlant\",\n                    \"type\": \"Button\",\n                    \"id\": \"98c96a7b-ad59-4084-b5a1-006b909bcd72\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"LeftPlant\",\n                    \"type\": \"Button\",\n                    \"id\": \"be3661bc-5009-4b1e-8d7c-80afbd78bc75\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"SelectPlant\",\n                    \"type\": \"Button\",\n                    \"id\": \"147a4f45-0f0f-4f6d-b459-4fe6cca33d74\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Quit\",\n                    \"type\": \"Button\",\n                    \"id\": \"c34b5687-744c-4c2d-a19a-9b4a94d1d6a4\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"BuySkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"8349447f-f705-45ad-b9e3-483e9a02dd5c\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ConfirmChoice\",\n                    \"type\": \"Button\",\n                    \"id\": \"4c44eb5b-1bd2-4222-bef8-e71ddca5f732\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"RandomSkin\",\n                    \"type\": \"Button\",\n                    \"id\": \"c5a57918-8b6c-4ea0-b0f3-16d3275cc678\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"6d0dcea0-30c0-4ac8-9ecf-46b6f8627cfe\",\n                    \"path\": \"<Gamepad>/rightStick/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0d2f8e4f-4246-4b0a-98a2-b0d57fd23962\",\n                    \"path\": \"<Gamepad>/rightStick/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4884f7cc-04be-4476-9972-2d31dd29aaef\",\n                    \"path\": \"<Gamepad>/buttonWest\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"SelectPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e18e6f73-589a-4f22-a1f8-bdf5b3bae105\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Quit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ed1d0756-0347-4c72-98df-bd6a2e464f14\",\n                    \"path\": \"<Gamepad>/rightStickPress\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"BuySkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ae003fdb-481b-4792-a5fa-0a26df760fe7\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"efa079de-6c17-4a76-a38b-a0cf649e0c8b\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4d19b33c-4ade-4e70-ba3f-5225780c0f27\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"ConfirmChoice\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"251063cb-1657-42ff-8dba-b89f5d49e4de\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"70d8c88d-839f-4e93-beb9-93260e91198d\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"edcc43ed-e00e-4e7c-99e7-4238f5547a48\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RightPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"416b4cf4-e918-4ea1-b4b0-4e7eb1b38967\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"LeftPlant\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"f215b08f-3a5f-43f2-9d79-18d09996e67f\",\n                    \"path\": \"<Gamepad>/leftStickPress\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"RandomSkin\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"MainMenu\",\n            \"id\": \"911de64d-bd08-4f57-a15a-654de45019b5\",\n            \"actions\": [\n                {\n                    \"name\": \"Submit\",\n                    \"type\": \"Button\",\n                    \"id\": \"42d9b2b7-6594-40f8-b6d1-9892e4797ed2\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"MoveDown\",\n                    \"type\": \"Button\",\n                    \"id\": \"6dfc3366-26d7-4f1c-9def-69c3d57de884\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"MoveUp\",\n                    \"type\": \"Button\",\n                    \"id\": \"eaf94556-5df4-4812-aba1-56def5d62ed5\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Settings\",\n                    \"type\": \"Button\",\n                    \"id\": \"72d4d9db-99cc-4893-b527-3276397a1e55\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ExitGame\",\n                    \"type\": \"Button\",\n                    \"id\": \"79d24832-6aa7-4efe-8627-1967b915475c\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"CloseWindow\",\n                    \"type\": \"Button\",\n                    \"id\": \"7e3048b1-1b83-42bf-839e-c1fd2c0dbc40\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"2f222409-8c72-4e86-9570-52bb2b11b2fc\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Submit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"bfcdd3bb-5910-476f-9036-37f4d37d6d01\",\n                    \"path\": \"<Gamepad>/dpad/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"MoveDown\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"2b956bd3-f9c9-4723-abf4-88d46dbff904\",\n                    \"path\": \"<Gamepad>/dpad/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"MoveUp\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d23b8771-91e7-4928-92f3-f848d186ab43\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Settings\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7ab93ca5-8ddc-48af-a59a-f930c24b22dc\",\n                    \"path\": \"<Gamepad>/rightStickPress\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"ExitGame\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ad1fd955-4667-4ace-8bc3-b71e6f9edc5f\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"CloseWindow\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Dialogs\",\n            \"id\": \"c9ee0d38-a685-4fb5-9333-2e901c7e01cf\",\n            \"actions\": [\n                {\n                    \"name\": \"AnswerDown\",\n                    \"type\": \"Button\",\n                    \"id\": \"e3bb1866-92a4-4765-8ccd-03ab8c945bab\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"AnswerUp\",\n                    \"type\": \"Button\",\n                    \"id\": \"56dba265-9967-413a-94ce-5cf354472fb4\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ConfirmChoice\",\n                    \"type\": \"Button\",\n                    \"id\": \"3f29babc-b8db-491a-b2a2-e220e0b52c78\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"30a5ba37-d44f-4cdf-86b7-0303ef14c170\",\n                    \"path\": \"<Gamepad>/dpad/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"AnswerDown\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"f6aed076-4135-4c84-90ce-39fd90bd9dd3\",\n                    \"path\": \"<Gamepad>/dpad/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"AnswerUp\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"777827ef-1c56-4f9b-89e1-76ba97f82095\",\n                    \"path\": \"<Gamepad>/buttonWest\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"ConfirmChoice\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"Keyboard\",\n            \"bindingGroup\": \"Keyboard\",\n            \"devices\": []\n        },\n        {\n            \"name\": \"Gamepad\",\n            \"bindingGroup\": \"Gamepad\",\n            \"devices\": []\n        }\n    ]\n}");
		m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
		m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
		m_Camera_Rotate = m_Camera.FindAction("Rotate", throwIfNotFound: true);
		m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
		m_Camera_Drag = m_Camera.FindAction("Drag", throwIfNotFound: true);
		m_Camera_HoldDrag = m_Camera.FindAction("HoldDrag", throwIfNotFound: true);
		m_Camera_HoldRotate = m_Camera.FindAction("HoldRotate", throwIfNotFound: true);
		m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
		m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
		m_Player_InteractAlternate = m_Player.FindAction("InteractAlternate", throwIfNotFound: true);
		m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
		m_UI_Escape = m_UI.FindAction("Escape", throwIfNotFound: true);
		m_UI_Journal = m_UI.FindAction("Journal", throwIfNotFound: true);
		m_UI_NewPlant = m_UI.FindAction("NewPlant", throwIfNotFound: true);
		m_UI_NextRoom = m_UI.FindAction("NextRoom", throwIfNotFound: true);
		m_UI_FloorUp = m_UI.FindAction("FloorUp", throwIfNotFound: true);
		m_UI_FloorDown = m_UI.FindAction("FloorDown", throwIfNotFound: true);
		m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
		m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
		m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
		m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
		m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
		m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
		m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
		m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
		m_UI_MoveMouse = m_UI.FindAction("MoveMouse", throwIfNotFound: true);
		m_UI_PlantScrollRight = m_UI.FindAction("PlantScrollRight", throwIfNotFound: true);
		m_UI_PlantScrollLeft = m_UI.FindAction("PlantScrollLeft", throwIfNotFound: true);
		m_UI_Space = m_UI.FindAction("Space", throwIfNotFound: true);
		m_UI_SelectPlant = m_UI.FindAction("SelectPlant", throwIfNotFound: true);
		m_UI_InfoPlant = m_UI.FindAction("InfoPlant", throwIfNotFound: true);
		m_Journal = asset.FindActionMap("Journal", throwIfNotFound: true);
		m_Journal_RightPage = m_Journal.FindAction("RightPage", throwIfNotFound: true);
		m_Journal_LeftPage = m_Journal.FindAction("LeftPage", throwIfNotFound: true);
		m_Journal_RightSkin = m_Journal.FindAction("RightSkin", throwIfNotFound: true);
		m_Journal_LeftSkin = m_Journal.FindAction("LeftSkin", throwIfNotFound: true);
		m_Journal_BuySkin = m_Journal.FindAction("BuySkin", throwIfNotFound: true);
		m_Journal_Quit = m_Journal.FindAction("Quit", throwIfNotFound: true);
		m_Journal_PlantTab = m_Journal.FindAction("PlantTab", throwIfNotFound: true);
		m_Journal_DiaryTab = m_Journal.FindAction("DiaryTab", throwIfNotFound: true);
		m_ChoosePlant = asset.FindActionMap("ChoosePlant", throwIfNotFound: true);
		m_ChoosePlant_RightSkin = m_ChoosePlant.FindAction("RightSkin", throwIfNotFound: true);
		m_ChoosePlant_LeftSkin = m_ChoosePlant.FindAction("LeftSkin", throwIfNotFound: true);
		m_ChoosePlant_RightPlant = m_ChoosePlant.FindAction("RightPlant", throwIfNotFound: true);
		m_ChoosePlant_LeftPlant = m_ChoosePlant.FindAction("LeftPlant", throwIfNotFound: true);
		m_ChoosePlant_SelectPlant = m_ChoosePlant.FindAction("SelectPlant", throwIfNotFound: true);
		m_ChoosePlant_Quit = m_ChoosePlant.FindAction("Quit", throwIfNotFound: true);
		m_ChoosePlant_BuySkin = m_ChoosePlant.FindAction("BuySkin", throwIfNotFound: true);
		m_ChoosePlant_ConfirmChoice = m_ChoosePlant.FindAction("ConfirmChoice", throwIfNotFound: true);
		m_ChoosePlant_RandomSkin = m_ChoosePlant.FindAction("RandomSkin", throwIfNotFound: true);
		m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
		m_MainMenu_Submit = m_MainMenu.FindAction("Submit", throwIfNotFound: true);
		m_MainMenu_MoveDown = m_MainMenu.FindAction("MoveDown", throwIfNotFound: true);
		m_MainMenu_MoveUp = m_MainMenu.FindAction("MoveUp", throwIfNotFound: true);
		m_MainMenu_Settings = m_MainMenu.FindAction("Settings", throwIfNotFound: true);
		m_MainMenu_ExitGame = m_MainMenu.FindAction("ExitGame", throwIfNotFound: true);
		m_MainMenu_CloseWindow = m_MainMenu.FindAction("CloseWindow", throwIfNotFound: true);
		m_Dialogs = asset.FindActionMap("Dialogs", throwIfNotFound: true);
		m_Dialogs_AnswerDown = m_Dialogs.FindAction("AnswerDown", throwIfNotFound: true);
		m_Dialogs_AnswerUp = m_Dialogs.FindAction("AnswerUp", throwIfNotFound: true);
		m_Dialogs_ConfirmChoice = m_Dialogs.FindAction("ConfirmChoice", throwIfNotFound: true);
	}

	~PlayerInputActions()
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
