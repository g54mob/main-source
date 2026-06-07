using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Workbench : SceneManager, ILogOrigin
{
	public struct SpawnModuleEventArgs
	{
		public ModuleGestaltVariationEnum moduleGestaltVariationId;

		public Vector2 mouseOffset;

		public SpawnModuleEventArgs(ModuleGestaltVariationEnum moduleGestaltVariationId, Vector2 mouseOffset)
		{
			this.moduleGestaltVariationId = default(ModuleGestaltVariationEnum);
			this.mouseOffset = default(Vector2);
		}
	}

	public struct SpawnMotherboardEventArgs
	{
		public MotherboardSectionEnum motherboardSectionId;

		public GadgetCoverMaterial coverMaterial;

		public int rotation;

		public Vector2 mouseOffset;

		public SpawnMotherboardEventArgs(MotherboardSectionEnum motherboardSectionId, GadgetCoverMaterial coverMaterial, int rotation, Vector2 mouseOffset)
		{
			this.motherboardSectionId = default(MotherboardSectionEnum);
			this.coverMaterial = default(GadgetCoverMaterial);
			this.rotation = 0;
			this.mouseOffset = default(Vector2);
		}
	}

	public GameObject workbenchArea;

	public SpriteRenderer editorDesktopBg;

	public Drawer archiveDrawer;

	public Airbrush airbrush;

	public Solderer solderer;

	public Tweezer tweezer;

	public AirbrushTipsBox airbrushTipsBox;

	public DraggableAirbrush tableAirbrush;

	public DraggableSolderer tableSolderer;

	public DraggableTweezer tableTweezer;

	public Lamp lamp;

	public Light2D desktopModeLight;

	public SpriteRenderer fakeDesktopShadow;

	public CuttingMat cuttingMat;

	public Drawer motherboardsDrawer;

	public Transform printedGadgetCardTablePosition;

	public ModulesDrawersGroup modulesDrawersGroup;

	public Drawer[] modulesDrawers;

	public RecordTool recordTool;

	public MiniTool miniTool;

	public Vector2 desktopModeAreaPosition;

	public Ease desktopModeAreaEaseIn;

	public float desktopModeAreaTimeIn;

	public Ease desktopModeAreaEaseOut;

	public float desktopModeAreaTimeOut;

	public VideoCameraZone videoRecorderLeftZone;

	public VideoCameraZone videoRecorderRightZone;

	public bool setLastGadgetOnStartup;

	public bool disableIntroInEditor;

	public bool keepLampOffInIntro;

	public string tutorialGadget;

	public const float leftMovement = 192f;

	public const float rightMovement = 148f;

	public const float areaHeight = 1040f;

	private Motherboard targetMotherboard;

	public Vector2 operatingModuleOffset;

	private Rect operatingModuleRect;

	private bool operatingModuleInvalidPosition;

	private bool operatingModuleIsInsideBoard;

	private bool operatingModuleIsInsideMotherboardCorrectArea;

	private Sticker operatingSticker;

	private Vector2 operatingStickerOffset;

	private bool operatingStickerInvalidPosition;

	private bool isStickerInsideDestroyArea;

	private bool stickerDestroyAreaGracePeriod;

	private Vector3 moveStickerToPrinterVel;

	private int operatingStickerRotation;

	private Vector3 lastMouseWorldPosition;

	private Vector3 mouseWorldVelocity;

	private float paintModeStartTime;

	private float airbrushTriggerTime;

	private float soldererModeStartTime;

	private float soldererTriggerTime;

	private float tweezerModeStartTime;

	private float tweezerTriggerTime;

	private Queue<Action> idleCallbacks;

	private Sequence desktopModeEase;

	private float desktopModeLightIntensity;

	private bool canApplicationQuit;

	private bool lockArchive;

	private bool lockMultitool;

	private bool lockAirbrush;

	private bool lockSolderer;

	private bool lockTweezer;

	private bool lockModules;

	private bool lockMotherboards;

	private SerializedGadgetMetaData tutorialMetadata;

	public (Motherboard, Vector3, int)? overrideOperatingModuleSnappedPosition;

	private SerializedDesktopGadgetState beforeDesktopMode_state;

	private bool mouseIsHoverModuleDrawer => false;

	public override void Setup()
	{
	}

	private void OnTryOpenLockedDrawer()
	{
	}

	private void OnTryOpenLockedTool()
	{
	}

	private IEnumerator CreateExamples()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	protected override void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public override void OnGadgetTurnOn(Gadget.State lastState)
	{
	}

	public override void OnGadgetTurnOff(Gadget.State lastState)
	{
	}

	public override void OnSelectModule(ModuleId id)
	{
	}

	public override void UpdateGameplayInteractions()
	{
	}

	private Motherboard SnapModuleToMotherboard(Module module, out bool invalid, out bool isInsideBoard, out bool isInsideCorrectMotherboardArea, out Vector2 invalidPoint)
	{
		invalid = default(bool);
		isInsideBoard = default(bool);
		isInsideCorrectMotherboardArea = default(bool);
		invalidPoint = default(Vector2);
		return null;
	}

	private void CalculateModuleRect()
	{
	}

	private Vector2 GetModuleMouseOffset(Module module)
	{
		return default(Vector2);
	}

	public void SetAirbrushBrush(BrushGestaltEnum brushEnum, bool immediate = false)
	{
	}

	protected override void UpdateZoom(Vector2 zoomPosition, Vector2 idlePosition, bool disableZoom = false)
	{
	}

	private IEnumerator MoveCameraToZeroPosition()
	{
		return null;
	}

	private IEnumerator MoveCameraToLeftPosition()
	{
		return null;
	}

	private IEnumerator MoveCameraToRightPosition()
	{
		return null;
	}

	public override void SetGadget(Gadget gadget, bool positionImmediatly = false)
	{
	}

	private bool ApplicationWantsToQuit()
	{
		return false;
	}

	private void OnApplicationQuit()
	{
	}

	public void ShowGadget(SerializedGadgetMetaData metadata, bool forceDrawerOpen)
	{
	}

	public void SwitchToDesktopMode()
	{
	}

	public override Rect GetGadgetAreaRect()
	{
		return default(Rect);
	}

	public override void OnDestroyGadget()
	{
	}

	public IEnumerator RunIntroMode()
	{
		return null;
	}

	public IEnumerator SetIdle()
	{
		return null;
	}

	public void RunIdle()
	{
	}

	public void ExitIdle()
	{
	}

	public IEnumerator SetMultitoolMode()
	{
		return null;
	}

	private void OpenArchiveDuringMultitoolState()
	{
	}

	private void OpenMotherboardsDuringMultitoolState()
	{
	}

	public IEnumerator RunMultiToolMode()
	{
		return null;
	}

	public IEnumerator SetPaintMode()
	{
		return null;
	}

	public IEnumerator RunPaintMode()
	{
		return null;
	}

	public IEnumerator EndPaintMode()
	{
		return null;
	}

	public IEnumerator SetSolderingIronMode()
	{
		return null;
	}

	public IEnumerator RunSolderingIronMode()
	{
		return null;
	}

	public IEnumerator EndSolderingIronMode()
	{
		return null;
	}

	public IEnumerator SetTweezerMode()
	{
		return null;
	}

	public IEnumerator RunTweezerMode()
	{
		return null;
	}

	public IEnumerator EndTweezerMode()
	{
		return null;
	}

	public virtual void SpawnModule(SpawnModuleEventArgs spawnModuleArgs)
	{
	}

	public void StartMoveModule()
	{
	}

	public void UpdateMoveModule()
	{
	}

	public void EndMoveModule()
	{
	}

	public void RotateModule()
	{
	}

	private void UpdateOperatingModuleValidPositionMarker()
	{
	}

	public bool ShouldRotateModule()
	{
		return false;
	}

	public virtual void CancelMoveModule()
	{
	}

	public bool ShouldCancelMoveModule()
	{
		return false;
	}

	public virtual void SolderModule()
	{
	}

	public bool ShouldSolderModule()
	{
		return false;
	}

	public void UnsolderModule(ModuleId moduleId)
	{
	}

	public bool IsTweezerActive()
	{
		return false;
	}

	public void PickSticker(Sticker sticker)
	{
	}

	public void StartMoveSticker()
	{
	}

	private void DetachSticker()
	{
	}

	private Vector3 GetStickerPosition()
	{
		return default(Vector3);
	}

	public void UpdateMoveSticker()
	{
	}

	public void EndMoveSticker()
	{
	}

	public void ApplySticker()
	{
	}

	public bool ShouldApplySticker()
	{
		return false;
	}

	public void CancelMoveSticker()
	{
	}

	public void RotateSticker()
	{
	}

	private void SetOperatingStickerRotation(int rotation)
	{
	}

	private void RotateOperatingSticker()
	{
	}

	public bool ShouldCancelMoveSticker()
	{
		return false;
	}

	public bool ShouldRotateSticker()
	{
		return false;
	}

	private void UpdateOperatingStickerValidPositionMarker()
	{
	}

	public virtual void SpawnMotherboard(SpawnMotherboardEventArgs spawnMotherboardArgs)
	{
	}

	public void StartMoveMotherboard()
	{
	}

	public void UpdateMoveMotherboard()
	{
	}

	public void StopMoveMotherboard()
	{
	}

	public virtual void DropMotherboard()
	{
	}

	private void UpdateMovingMotherboardValidPositionMarker()
	{
	}

	public bool ShouldPlaceMotherboard()
	{
		return false;
	}

	private bool IsMovingMotherboardDestroyable()
	{
		return false;
	}

	public bool ShouldDestroyMotherboard()
	{
		return false;
	}

	public virtual IEnumerator DestroyMotherboard()
	{
		return null;
	}

	public IEnumerator RunArchiveMode()
	{
		return null;
	}

	private void OpenMultitoolDuringMultitoolState()
	{
	}

	public void EndArchiveMode()
	{
	}

	public IEnumerator RunGetGadgetMode(GetGadgetEventArgs args)
	{
		return null;
	}

	public IEnumerator RunPrintGadgetMode(PrintGadgetEventArgs args)
	{
		return null;
	}

	public IEnumerator RunDestroyGadgetMode(DestroyGadgetEventArgs args)
	{
		return null;
	}

	public IEnumerator RunChangeGadgetCoverMaterialMode(ChangeGadgetCoverMaterialEventArgs args)
	{
		return null;
	}

	public IEnumerator SetDesktopMode()
	{
		return null;
	}

	public void RunDesktopMode()
	{
	}

	private void EndDesktopMode_RestoreGadgetState(Sequence moveMotherboardsSeq)
	{
	}

	public IEnumerator EndDesktopMode()
	{
		return null;
	}

	public bool ShouldStopDesktopMode()
	{
		return false;
	}

	public override void OnSteamOverlay(bool activated)
	{
	}

	public void StartDesktopMoveMotherboard()
	{
	}

	public void UpdateDesktopMoveMotherboard()
	{
	}

	public void StopDesktopMoveMotherboard()
	{
	}

	public override bool IsLampOn()
	{
		return false;
	}

	public override void SetLampState(bool state)
	{
	}

	public override void SetLampColor(Color color)
	{
	}

	public override void ShowMessage(string message, bool persistent)
	{
	}

	public override void ShowWarning(string message, bool persistent)
	{
	}

	public override void ShowError(string message, bool persistent)
	{
	}

	public override void HideMessage()
	{
	}

	public void OnEndDayInteraction()
	{
	}
}
