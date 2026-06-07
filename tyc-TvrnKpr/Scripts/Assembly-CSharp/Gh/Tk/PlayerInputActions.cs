using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gh.Tk
{
	public class PlayerInputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
	{
		public struct GeneralActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction LeftButton => null;

			public InputAction RightButton => null;

			public InputAction ShiftButton => null;

			public InputAction AlternateButton => null;

			public InputAction CycleVariantLeft => null;

			public InputAction CycleVariantRight => null;

			public InputAction PreviousPage => null;

			public InputAction NextPage => null;

			public InputAction LongLeftClick => null;

			public InputAction Cancel => null;

			public InputAction ToggleFeedbackWindow => null;

			public InputAction ToggleDirectorsToolbar => null;

			public InputAction ToggleLevelEditorToolbar => null;

			public InputAction ToggleUI => null;

			public InputAction SkipNarrator => null;

			public InputAction PlayAiSpeech => null;

			public InputAction ToggleHandbook => null;

			public InputAction TooltipLock => null;

			public InputAction ToggleEnglishLanguage => null;

			public InputAction LeftClick => null;

			public InputAction NextLanguage => null;

			public bool enabled => false;

			public GeneralActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(GeneralActions set)
			{
				return null;
			}

			public void AddCallbacks(IGeneralActions instance)
			{
			}

			private void UnregisterCallbacks(IGeneralActions instance)
			{
			}

			public void RemoveCallbacks(IGeneralActions instance)
			{
			}

			public void SetCallbacks(IGeneralActions instance)
			{
			}
		}

		public struct GamePlayActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction ToggleCheat => null;

			public InputAction ToggleMap => null;

			public InputAction ToggleBuildProps => null;

			public InputAction ToggleZoning => null;

			public InputAction ToggleDeleteProp => null;

			public InputAction ToggleDecorationMode => null;

			public InputAction ToggleCloneTool => null;

			public bool enabled => false;

			public GamePlayActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(GamePlayActions set)
			{
				return null;
			}

			public void AddCallbacks(IGamePlayActions instance)
			{
			}

			private void UnregisterCallbacks(IGamePlayActions instance)
			{
			}

			public void RemoveCallbacks(IGamePlayActions instance)
			{
			}

			public void SetCallbacks(IGamePlayActions instance)
			{
			}
		}

		public struct GameSpeedActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Speed0 => null;

			public InputAction Speed1 => null;

			public InputAction Speed2 => null;

			public InputAction Speed3 => null;

			public InputAction TogglePause => null;

			public InputAction IncreaseSpeed => null;

			public InputAction DecreaseSpeed => null;

			public bool enabled => false;

			public GameSpeedActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(GameSpeedActions set)
			{
				return null;
			}

			public void AddCallbacks(IGameSpeedActions instance)
			{
			}

			private void UnregisterCallbacks(IGameSpeedActions instance)
			{
			}

			public void RemoveCallbacks(IGameSpeedActions instance)
			{
			}

			public void SetCallbacks(IGameSpeedActions instance)
			{
			}
		}

		public struct PlaceDecorationsActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction SuppressAutoRotation => null;

			public InputAction Build => null;

			public InputAction Rotate => null;

			public bool enabled => false;

			public PlaceDecorationsActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(PlaceDecorationsActions set)
			{
				return null;
			}

			public void AddCallbacks(IPlaceDecorationsActions instance)
			{
			}

			private void UnregisterCallbacks(IPlaceDecorationsActions instance)
			{
			}

			public void RemoveCallbacks(IPlaceDecorationsActions instance)
			{
			}

			public void SetCallbacks(IPlaceDecorationsActions instance)
			{
			}
		}

		public struct EditDecorationsActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Duplicate => null;

			public InputAction Delete => null;

			public InputAction SelectAllPropEntities => null;

			public InputAction Group => null;

			public InputAction UnGroup => null;

			public InputAction ToggleHierarchy => null;

			public InputAction PickUp => null;

			public bool enabled => false;

			public EditDecorationsActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(EditDecorationsActions set)
			{
				return null;
			}

			public void AddCallbacks(IEditDecorationsActions instance)
			{
			}

			private void UnregisterCallbacks(IEditDecorationsActions instance)
			{
			}

			public void RemoveCallbacks(IEditDecorationsActions instance)
			{
			}

			public void SetCallbacks(IEditDecorationsActions instance)
			{
			}
		}

		public struct CameraActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction RotateLeft => null;

			public InputAction RotateRight => null;

			public InputAction Move => null;

			public InputAction MoveWithMouse => null;

			public InputAction ToggleFreeCam => null;

			public InputAction ToggleFocus => null;

			public InputAction ResetCamera => null;

			public InputAction Zoom => null;

			public InputAction FreeRotateTilt => null;

			public InputAction ZoomIn => null;

			public InputAction ZoomOut => null;

			public bool enabled => false;

			public CameraActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(CameraActions set)
			{
				return null;
			}

			public void AddCallbacks(ICameraActions instance)
			{
			}

			private void UnregisterCallbacks(ICameraActions instance)
			{
			}

			public void RemoveCallbacks(ICameraActions instance)
			{
			}

			public void SetCallbacks(ICameraActions instance)
			{
			}
		}

		public struct UGUIActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Navigate => null;

			public InputAction Submit => null;

			public InputAction Cancel => null;

			public InputAction Point => null;

			public InputAction Click => null;

			public InputAction ScrollWheel => null;

			public InputAction MiddleClick => null;

			public InputAction RightClick => null;

			public InputAction TrackedDevicePosition => null;

			public InputAction TrackedDeviceOrientation => null;

			public bool enabled => false;

			public UGUIActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(UGUIActions set)
			{
				return null;
			}

			public void AddCallbacks(IUGUIActions instance)
			{
			}

			private void UnregisterCallbacks(IUGUIActions instance)
			{
			}

			public void RemoveCallbacks(IUGUIActions instance)
			{
			}

			public void SetCallbacks(IUGUIActions instance)
			{
			}
		}

		public struct PropBuildingActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Rotate => null;

			public InputAction FreeRotate => null;

			public InputAction EnableFreeRotate => null;

			public InputAction Build => null;

			public bool enabled => false;

			public PropBuildingActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(PropBuildingActions set)
			{
				return null;
			}

			public void AddCallbacks(IPropBuildingActions instance)
			{
			}

			private void UnregisterCallbacks(IPropBuildingActions instance)
			{
			}

			public void RemoveCallbacks(IPropBuildingActions instance)
			{
			}

			public void SetCallbacks(IPropBuildingActions instance)
			{
			}
		}

		public struct ZoningActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction ConfirmZoning => null;

			public bool enabled => false;

			public ZoningActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(ZoningActions set)
			{
				return null;
			}

			public void AddCallbacks(IZoningActions instance)
			{
			}

			private void UnregisterCallbacks(IZoningActions instance)
			{
			}

			public void RemoveCallbacks(IZoningActions instance)
			{
			}

			public void SetCallbacks(IZoningActions instance)
			{
			}
		}

		public struct DemolishActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Demolish => null;

			public bool enabled => false;

			public DemolishActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(DemolishActions set)
			{
				return null;
			}

			public void AddCallbacks(IDemolishActions instance)
			{
			}

			private void UnregisterCallbacks(IDemolishActions instance)
			{
			}

			public void RemoveCallbacks(IDemolishActions instance)
			{
			}

			public void SetCallbacks(IDemolishActions instance)
			{
			}
		}

		public struct WallAddOnBuildingActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Rotate => null;

			public InputAction Build => null;

			public bool enabled => false;

			public WallAddOnBuildingActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(WallAddOnBuildingActions set)
			{
				return null;
			}

			public void AddCallbacks(IWallAddOnBuildingActions instance)
			{
			}

			private void UnregisterCallbacks(IWallAddOnBuildingActions instance)
			{
			}

			public void RemoveCallbacks(IWallAddOnBuildingActions instance)
			{
			}

			public void SetCallbacks(IWallAddOnBuildingActions instance)
			{
			}
		}

		public struct DecorationsActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Select => null;

			public InputAction CycleSnappingPoints => null;

			public InputAction RotateLeft => null;

			public InputAction RotateRight => null;

			public InputAction ScaleUp => null;

			public InputAction ScaleDown => null;

			public InputAction Undo => null;

			public InputAction Redo => null;

			public InputAction ReleaseLockedProp => null;

			public InputAction ParentToDiffProp => null;

			public InputAction ExtractToNewProp => null;

			public InputAction ToggleGizmo => null;

			public bool enabled => false;

			public DecorationsActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(DecorationsActions set)
			{
				return null;
			}

			public void AddCallbacks(IDecorationsActions instance)
			{
			}

			private void UnregisterCallbacks(IDecorationsActions instance)
			{
			}

			public void RemoveCallbacks(IDecorationsActions instance)
			{
			}

			public void SetCallbacks(IDecorationsActions instance)
			{
			}
		}

		public struct InputFormActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Submit => null;

			public bool enabled => false;

			public InputFormActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(InputFormActions set)
			{
				return null;
			}

			public void AddCallbacks(IInputFormActions instance)
			{
			}

			private void UnregisterCallbacks(IInputFormActions instance)
			{
			}

			public void RemoveCallbacks(IInputFormActions instance)
			{
			}

			public void SetCallbacks(IInputFormActions instance)
			{
			}
		}

		public struct QuickSaveLoadActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction QuickSave => null;

			public InputAction QuickLoad => null;

			public bool enabled => false;

			public QuickSaveLoadActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(QuickSaveLoadActions set)
			{
				return null;
			}

			public void AddCallbacks(IQuickSaveLoadActions instance)
			{
			}

			private void UnregisterCallbacks(IQuickSaveLoadActions instance)
			{
			}

			public void RemoveCallbacks(IQuickSaveLoadActions instance)
			{
			}

			public void SetCallbacks(IQuickSaveLoadActions instance)
			{
			}
		}

		public struct DirectorsToolbarActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction ToggleMouseFocusMode => null;

			public InputAction DisableUIWarning => null;

			public InputAction ToggleCameraAnimation => null;

			public InputAction SaveCameraPreset1 => null;

			public InputAction SaveCameraPreset2 => null;

			public InputAction SaveCameraPreset3 => null;

			public InputAction LoadCameraPreset1 => null;

			public InputAction LoadCameraPreset2 => null;

			public InputAction LoadCameraPreset3 => null;

			public InputAction TakeScreenshot => null;

			public bool enabled => false;

			public DirectorsToolbarActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(DirectorsToolbarActions set)
			{
				return null;
			}

			public void AddCallbacks(IDirectorsToolbarActions instance)
			{
			}

			private void UnregisterCallbacks(IDirectorsToolbarActions instance)
			{
			}

			public void RemoveCallbacks(IDirectorsToolbarActions instance)
			{
			}

			public void SetCallbacks(IDirectorsToolbarActions instance)
			{
			}
		}

		public struct LevelEditorActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction Clear => null;

			public InputAction Reduce => null;

			public InputAction Expand => null;

			public InputAction Outside => null;

			public InputAction Inside => null;

			public InputAction RegenerateWalls => null;

			public bool enabled => false;

			public LevelEditorActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(LevelEditorActions set)
			{
				return null;
			}

			public void AddCallbacks(ILevelEditorActions instance)
			{
			}

			private void UnregisterCallbacks(ILevelEditorActions instance)
			{
			}

			public void RemoveCallbacks(ILevelEditorActions instance)
			{
			}

			public void SetCallbacks(ILevelEditorActions instance)
			{
			}
		}

		public struct QuickRotateZoomActions
		{
			private PlayerInputActions m_Wrapper;

			public InputAction QuickRotateZoom => null;

			public InputAction MouseMove => null;

			public bool enabled => false;

			public QuickRotateZoomActions(PlayerInputActions wrapper)
			{
				m_Wrapper = null;
			}

			public InputActionMap Get()
			{
				return null;
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public static implicit operator InputActionMap(QuickRotateZoomActions set)
			{
				return null;
			}

			public void AddCallbacks(IQuickRotateZoomActions instance)
			{
			}

			private void UnregisterCallbacks(IQuickRotateZoomActions instance)
			{
			}

			public void RemoveCallbacks(IQuickRotateZoomActions instance)
			{
			}

			public void SetCallbacks(IQuickRotateZoomActions instance)
			{
			}
		}

		public interface IGeneralActions
		{
			void OnLeftButton(InputAction.CallbackContext context);

			void OnRightButton(InputAction.CallbackContext context);

			void OnShiftButton(InputAction.CallbackContext context);

			void OnAlternateButton(InputAction.CallbackContext context);

			void OnCycleVariantLeft(InputAction.CallbackContext context);

			void OnCycleVariantRight(InputAction.CallbackContext context);

			void OnPreviousPage(InputAction.CallbackContext context);

			void OnNextPage(InputAction.CallbackContext context);

			void OnLongLeftClick(InputAction.CallbackContext context);

			void OnCancel(InputAction.CallbackContext context);

			void OnToggleFeedbackWindow(InputAction.CallbackContext context);

			void OnToggleDirectorsToolbar(InputAction.CallbackContext context);

			void OnToggleLevelEditorToolbar(InputAction.CallbackContext context);

			void OnToggleUI(InputAction.CallbackContext context);

			void OnSkipNarrator(InputAction.CallbackContext context);

			void OnPlayAiSpeech(InputAction.CallbackContext context);

			void OnToggleHandbook(InputAction.CallbackContext context);

			void OnTooltipLock(InputAction.CallbackContext context);

			void OnToggleEnglishLanguage(InputAction.CallbackContext context);

			void OnLeftClick(InputAction.CallbackContext context);

			void OnNextLanguage(InputAction.CallbackContext context);
		}

		public interface IGamePlayActions
		{
			void OnToggleCheat(InputAction.CallbackContext context);

			void OnToggleMap(InputAction.CallbackContext context);

			void OnToggleBuildProps(InputAction.CallbackContext context);

			void OnToggleZoning(InputAction.CallbackContext context);

			void OnToggleDeleteProp(InputAction.CallbackContext context);

			void OnToggleDecorationMode(InputAction.CallbackContext context);

			void OnToggleCloneTool(InputAction.CallbackContext context);
		}

		public interface IGameSpeedActions
		{
			void OnSpeed0(InputAction.CallbackContext context);

			void OnSpeed1(InputAction.CallbackContext context);

			void OnSpeed2(InputAction.CallbackContext context);

			void OnSpeed3(InputAction.CallbackContext context);

			void OnTogglePause(InputAction.CallbackContext context);

			void OnIncreaseSpeed(InputAction.CallbackContext context);

			void OnDecreaseSpeed(InputAction.CallbackContext context);
		}

		public interface IPlaceDecorationsActions
		{
			void OnSuppressAutoRotation(InputAction.CallbackContext context);

			void OnBuild(InputAction.CallbackContext context);

			void OnRotate(InputAction.CallbackContext context);
		}

		public interface IEditDecorationsActions
		{
			void OnDuplicate(InputAction.CallbackContext context);

			void OnDelete(InputAction.CallbackContext context);

			void OnSelectAllPropEntities(InputAction.CallbackContext context);

			void OnGroup(InputAction.CallbackContext context);

			void OnUnGroup(InputAction.CallbackContext context);

			void OnToggleHierarchy(InputAction.CallbackContext context);

			void OnPickUp(InputAction.CallbackContext context);
		}

		public interface ICameraActions
		{
			void OnRotateLeft(InputAction.CallbackContext context);

			void OnRotateRight(InputAction.CallbackContext context);

			void OnMove(InputAction.CallbackContext context);

			void OnMoveWithMouse(InputAction.CallbackContext context);

			void OnToggleFreeCam(InputAction.CallbackContext context);

			void OnToggleFocus(InputAction.CallbackContext context);

			void OnResetCamera(InputAction.CallbackContext context);

			void OnZoom(InputAction.CallbackContext context);

			void OnFreeRotateTilt(InputAction.CallbackContext context);

			void OnZoomIn(InputAction.CallbackContext context);

			void OnZoomOut(InputAction.CallbackContext context);
		}

		public interface IUGUIActions
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
		}

		public interface IPropBuildingActions
		{
			void OnRotate(InputAction.CallbackContext context);

			void OnFreeRotate(InputAction.CallbackContext context);

			void OnEnableFreeRotate(InputAction.CallbackContext context);

			void OnBuild(InputAction.CallbackContext context);
		}

		public interface IZoningActions
		{
			void OnConfirmZoning(InputAction.CallbackContext context);
		}

		public interface IDemolishActions
		{
			void OnDemolish(InputAction.CallbackContext context);
		}

		public interface IWallAddOnBuildingActions
		{
			void OnRotate(InputAction.CallbackContext context);

			void OnBuild(InputAction.CallbackContext context);
		}

		public interface IDecorationsActions
		{
			void OnSelect(InputAction.CallbackContext context);

			void OnCycleSnappingPoints(InputAction.CallbackContext context);

			void OnRotateLeft(InputAction.CallbackContext context);

			void OnRotateRight(InputAction.CallbackContext context);

			void OnScaleUp(InputAction.CallbackContext context);

			void OnScaleDown(InputAction.CallbackContext context);

			void OnUndo(InputAction.CallbackContext context);

			void OnRedo(InputAction.CallbackContext context);

			void OnReleaseLockedProp(InputAction.CallbackContext context);

			void OnParentToDiffProp(InputAction.CallbackContext context);

			void OnExtractToNewProp(InputAction.CallbackContext context);

			void OnToggleGizmo(InputAction.CallbackContext context);
		}

		public interface IInputFormActions
		{
			void OnSubmit(InputAction.CallbackContext context);
		}

		public interface IQuickSaveLoadActions
		{
			void OnQuickSave(InputAction.CallbackContext context);

			void OnQuickLoad(InputAction.CallbackContext context);
		}

		public interface IDirectorsToolbarActions
		{
			void OnToggleMouseFocusMode(InputAction.CallbackContext context);

			void OnDisableUIWarning(InputAction.CallbackContext context);

			void OnToggleCameraAnimation(InputAction.CallbackContext context);

			void OnSaveCameraPreset1(InputAction.CallbackContext context);

			void OnSaveCameraPreset2(InputAction.CallbackContext context);

			void OnSaveCameraPreset3(InputAction.CallbackContext context);

			void OnLoadCameraPreset1(InputAction.CallbackContext context);

			void OnLoadCameraPreset2(InputAction.CallbackContext context);

			void OnLoadCameraPreset3(InputAction.CallbackContext context);

			void OnTakeScreenshot(InputAction.CallbackContext context);
		}

		public interface ILevelEditorActions
		{
			void OnClear(InputAction.CallbackContext context);

			void OnReduce(InputAction.CallbackContext context);

			void OnExpand(InputAction.CallbackContext context);

			void OnOutside(InputAction.CallbackContext context);

			void OnInside(InputAction.CallbackContext context);

			void OnRegenerateWalls(InputAction.CallbackContext context);
		}

		public interface IQuickRotateZoomActions
		{
			void OnQuickRotateZoom(InputAction.CallbackContext context);

			void OnMouseMove(InputAction.CallbackContext context);
		}

		private readonly InputActionMap m_General;

		private List<IGeneralActions> m_GeneralActionsCallbackInterfaces;

		private readonly InputAction m_General_LeftButton;

		private readonly InputAction m_General_RightButton;

		private readonly InputAction m_General_ShiftButton;

		private readonly InputAction m_General_AlternateButton;

		private readonly InputAction m_General_CycleVariantLeft;

		private readonly InputAction m_General_CycleVariantRight;

		private readonly InputAction m_General_PreviousPage;

		private readonly InputAction m_General_NextPage;

		private readonly InputAction m_General_LongLeftClick;

		private readonly InputAction m_General_Cancel;

		private readonly InputAction m_General_ToggleFeedbackWindow;

		private readonly InputAction m_General_ToggleDirectorsToolbar;

		private readonly InputAction m_General_ToggleLevelEditorToolbar;

		private readonly InputAction m_General_ToggleUI;

		private readonly InputAction m_General_SkipNarrator;

		private readonly InputAction m_General_PlayAiSpeech;

		private readonly InputAction m_General_ToggleHandbook;

		private readonly InputAction m_General_TooltipLock;

		private readonly InputAction m_General_ToggleEnglishLanguage;

		private readonly InputAction m_General_LeftClick;

		private readonly InputAction m_General_NextLanguage;

		private readonly InputActionMap m_GamePlay;

		private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces;

		private readonly InputAction m_GamePlay_ToggleCheat;

		private readonly InputAction m_GamePlay_ToggleMap;

		private readonly InputAction m_GamePlay_ToggleBuildProps;

		private readonly InputAction m_GamePlay_ToggleZoning;

		private readonly InputAction m_GamePlay_ToggleDeleteProp;

		private readonly InputAction m_GamePlay_ToggleDecorationMode;

		private readonly InputAction m_GamePlay_ToggleCloneTool;

		private readonly InputActionMap m_GameSpeed;

		private List<IGameSpeedActions> m_GameSpeedActionsCallbackInterfaces;

		private readonly InputAction m_GameSpeed_Speed0;

		private readonly InputAction m_GameSpeed_Speed1;

		private readonly InputAction m_GameSpeed_Speed2;

		private readonly InputAction m_GameSpeed_Speed3;

		private readonly InputAction m_GameSpeed_TogglePause;

		private readonly InputAction m_GameSpeed_IncreaseSpeed;

		private readonly InputAction m_GameSpeed_DecreaseSpeed;

		private readonly InputActionMap m_PlaceDecorations;

		private List<IPlaceDecorationsActions> m_PlaceDecorationsActionsCallbackInterfaces;

		private readonly InputAction m_PlaceDecorations_SuppressAutoRotation;

		private readonly InputAction m_PlaceDecorations_Build;

		private readonly InputAction m_PlaceDecorations_Rotate;

		private readonly InputActionMap m_EditDecorations;

		private List<IEditDecorationsActions> m_EditDecorationsActionsCallbackInterfaces;

		private readonly InputAction m_EditDecorations_Duplicate;

		private readonly InputAction m_EditDecorations_Delete;

		private readonly InputAction m_EditDecorations_SelectAllPropEntities;

		private readonly InputAction m_EditDecorations_Group;

		private readonly InputAction m_EditDecorations_UnGroup;

		private readonly InputAction m_EditDecorations_ToggleHierarchy;

		private readonly InputAction m_EditDecorations_PickUp;

		private readonly InputActionMap m_Camera;

		private List<ICameraActions> m_CameraActionsCallbackInterfaces;

		private readonly InputAction m_Camera_RotateLeft;

		private readonly InputAction m_Camera_RotateRight;

		private readonly InputAction m_Camera_Move;

		private readonly InputAction m_Camera_MoveWithMouse;

		private readonly InputAction m_Camera_ToggleFreeCam;

		private readonly InputAction m_Camera_ToggleFocus;

		private readonly InputAction m_Camera_ResetCamera;

		private readonly InputAction m_Camera_Zoom;

		private readonly InputAction m_Camera_FreeRotateTilt;

		private readonly InputAction m_Camera_ZoomIn;

		private readonly InputAction m_Camera_ZoomOut;

		private readonly InputActionMap m_UGUI;

		private List<IUGUIActions> m_UGUIActionsCallbackInterfaces;

		private readonly InputAction m_UGUI_Navigate;

		private readonly InputAction m_UGUI_Submit;

		private readonly InputAction m_UGUI_Cancel;

		private readonly InputAction m_UGUI_Point;

		private readonly InputAction m_UGUI_Click;

		private readonly InputAction m_UGUI_ScrollWheel;

		private readonly InputAction m_UGUI_MiddleClick;

		private readonly InputAction m_UGUI_RightClick;

		private readonly InputAction m_UGUI_TrackedDevicePosition;

		private readonly InputAction m_UGUI_TrackedDeviceOrientation;

		private readonly InputActionMap m_PropBuilding;

		private List<IPropBuildingActions> m_PropBuildingActionsCallbackInterfaces;

		private readonly InputAction m_PropBuilding_Rotate;

		private readonly InputAction m_PropBuilding_FreeRotate;

		private readonly InputAction m_PropBuilding_EnableFreeRotate;

		private readonly InputAction m_PropBuilding_Build;

		private readonly InputActionMap m_Zoning;

		private List<IZoningActions> m_ZoningActionsCallbackInterfaces;

		private readonly InputAction m_Zoning_ConfirmZoning;

		private readonly InputActionMap m_Demolish;

		private List<IDemolishActions> m_DemolishActionsCallbackInterfaces;

		private readonly InputAction m_Demolish_Demolish;

		private readonly InputActionMap m_WallAddOnBuilding;

		private List<IWallAddOnBuildingActions> m_WallAddOnBuildingActionsCallbackInterfaces;

		private readonly InputAction m_WallAddOnBuilding_Rotate;

		private readonly InputAction m_WallAddOnBuilding_Build;

		private readonly InputActionMap m_Decorations;

		private List<IDecorationsActions> m_DecorationsActionsCallbackInterfaces;

		private readonly InputAction m_Decorations_Select;

		private readonly InputAction m_Decorations_CycleSnappingPoints;

		private readonly InputAction m_Decorations_RotateLeft;

		private readonly InputAction m_Decorations_RotateRight;

		private readonly InputAction m_Decorations_ScaleUp;

		private readonly InputAction m_Decorations_ScaleDown;

		private readonly InputAction m_Decorations_Undo;

		private readonly InputAction m_Decorations_Redo;

		private readonly InputAction m_Decorations_ReleaseLockedProp;

		private readonly InputAction m_Decorations_ParentToDiffProp;

		private readonly InputAction m_Decorations_ExtractToNewProp;

		private readonly InputAction m_Decorations_ToggleGizmo;

		private readonly InputActionMap m_InputForm;

		private List<IInputFormActions> m_InputFormActionsCallbackInterfaces;

		private readonly InputAction m_InputForm_Submit;

		private readonly InputActionMap m_QuickSaveLoad;

		private List<IQuickSaveLoadActions> m_QuickSaveLoadActionsCallbackInterfaces;

		private readonly InputAction m_QuickSaveLoad_QuickSave;

		private readonly InputAction m_QuickSaveLoad_QuickLoad;

		private readonly InputActionMap m_DirectorsToolbar;

		private List<IDirectorsToolbarActions> m_DirectorsToolbarActionsCallbackInterfaces;

		private readonly InputAction m_DirectorsToolbar_ToggleMouseFocusMode;

		private readonly InputAction m_DirectorsToolbar_DisableUIWarning;

		private readonly InputAction m_DirectorsToolbar_ToggleCameraAnimation;

		private readonly InputAction m_DirectorsToolbar_SaveCameraPreset1;

		private readonly InputAction m_DirectorsToolbar_SaveCameraPreset2;

		private readonly InputAction m_DirectorsToolbar_SaveCameraPreset3;

		private readonly InputAction m_DirectorsToolbar_LoadCameraPreset1;

		private readonly InputAction m_DirectorsToolbar_LoadCameraPreset2;

		private readonly InputAction m_DirectorsToolbar_LoadCameraPreset3;

		private readonly InputAction m_DirectorsToolbar_TakeScreenshot;

		private readonly InputActionMap m_LevelEditor;

		private List<ILevelEditorActions> m_LevelEditorActionsCallbackInterfaces;

		private readonly InputAction m_LevelEditor_Clear;

		private readonly InputAction m_LevelEditor_Reduce;

		private readonly InputAction m_LevelEditor_Expand;

		private readonly InputAction m_LevelEditor_Outside;

		private readonly InputAction m_LevelEditor_Inside;

		private readonly InputAction m_LevelEditor_RegenerateWalls;

		private readonly InputActionMap m_QuickRotateZoom;

		private List<IQuickRotateZoomActions> m_QuickRotateZoomActionsCallbackInterfaces;

		private readonly InputAction m_QuickRotateZoom_QuickRotateZoom;

		private readonly InputAction m_QuickRotateZoom_MouseMove;

		private int m_KeyboardMouseSchemeIndex;

		public InputActionAsset asset { get; }

		public InputBinding? bindingMask
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ReadOnlyArray<InputDevice>? devices
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ReadOnlyArray<InputControlScheme> controlSchemes => default(ReadOnlyArray<InputControlScheme>);

		public IEnumerable<InputBinding> bindings => null;

		public GeneralActions General => default(GeneralActions);

		public GamePlayActions GamePlay => default(GamePlayActions);

		public GameSpeedActions GameSpeed => default(GameSpeedActions);

		public PlaceDecorationsActions PlaceDecorations => default(PlaceDecorationsActions);

		public EditDecorationsActions EditDecorations => default(EditDecorationsActions);

		public CameraActions Camera => default(CameraActions);

		public UGUIActions UGUI => default(UGUIActions);

		public PropBuildingActions PropBuilding => default(PropBuildingActions);

		public ZoningActions Zoning => default(ZoningActions);

		public DemolishActions Demolish => default(DemolishActions);

		public WallAddOnBuildingActions WallAddOnBuilding => default(WallAddOnBuildingActions);

		public DecorationsActions Decorations => default(DecorationsActions);

		public InputFormActions InputForm => default(InputFormActions);

		public QuickSaveLoadActions QuickSaveLoad => default(QuickSaveLoadActions);

		public DirectorsToolbarActions DirectorsToolbar => default(DirectorsToolbarActions);

		public LevelEditorActions LevelEditor => default(LevelEditorActions);

		public QuickRotateZoomActions QuickRotateZoom => default(QuickRotateZoomActions);

		public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

		~PlayerInputActions()
		{
		}

		public void Dispose()
		{
		}

		public bool Contains(InputAction action)
		{
			return false;
		}

		public IEnumerator<InputAction> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
		{
			return null;
		}

		public int FindBinding(InputBinding bindingMask, out InputAction action)
		{
			action = null;
			return 0;
		}
	}
}
