using System.Collections.Generic;

namespace ModApi.Input
{
	public interface IGameInputs
	{
		IGameInput AccelerateMovementModifier { get; }

		IGameInput ActivateCameraLook { get; }

		IGameInput ActivateStage { get; }

		IGameInput ActivationGroup1 { get; }

		IGameInput ActivationGroup10 { get; }

		IGameInput ActivationGroup2 { get; }

		IGameInput ActivationGroup3 { get; }

		IGameInput ActivationGroup4 { get; }

		IGameInput ActivationGroup5 { get; }

		IGameInput ActivationGroup6 { get; }

		IGameInput ActivationGroup7 { get; }

		IGameInput ActivationGroup8 { get; }

		IGameInput ActivationGroup9 { get; }

		IReadOnlyList<IGameInput> AllInputs { get; }

		IGameInput Brake { get; }

		IGameInput CameraLookLeftRight { get; }

		IGameInput CameraLookUpDown { get; }

		IGameInput CameraLookZoom { get; }

		IGameInput CameraRollLeftRight { get; }

		IGameInput CameraSwapLeftRightRoll { get; }

		IGameInput CameraSwapUpDownZoom { get; }

		IGameInput CommandPodNext { get; }

		IGameInput CommandPodPrevious { get; }

		IGameInput DecelerateMovementModifier { get; }

		IGameInput DecreaseRotationalSpeed { get; }

		IGameInput DecreaseSpeed { get; }

		IGameInput DeleteSelectedPart { get; }

		IGameInput DesignerCameraInOut { get; }

		IGameInput DesignerCameraLeftRight { get; }

		IGameInput DesignerCameraRotateLeftRight { get; }

		IGameInput DesignerCameraRotateUpDown { get; }

		IGameInput DesignerCameraSwitchMode { get; }

		IGameInput DesignerCameraTranslateInOut { get; }

		IGameInput DesignerCameraTranslateLeftRight { get; }

		IGameInput DesignerCameraTranslateUpDown { get; }

		IGameInput DesignerCameraUpDown { get; }

		IGameInput DesignerCameraZoom { get; }

		IGameInput DesignerDeselectPart { get; }

		IGameInput DesignerFlyoutNext { get; }

		IGameInput DesignerFlyoutPrevious { get; }

		IGameInput DesignerManipulatePartNegative { get; }

		IGameInput DesignerManipulatePartNextMode { get; }

		IGameInput DesignerManipulatePartPositive { get; }

		IGameInput DesignerManipulatePartPreviousMode { get; }

		IGameInput DesignerToggleMenu { get; }

		IGameInput DesignerTogglePartProperties { get; }

		IGameInput DeveloperConsole { get; }

		IGameInput EvaEnableJetpackMovement { get; }

		IGameInput EvaJump { get; }

		IGameInput EvaMoveFwdAft { get; }

		IGameInput EvaMoveUpDown { get; }

		IGameInput EvaMoveUpDownNoModifier { get; }

		IGameInput EvaPitch { get; }

		IGameInput EvaPitchNoModifier { get; }

		IGameInput EvaRoll { get; }

		IGameInput EvaRollNoModifier { get; }

		IGameInput EvaShootTether { get; }

		IGameInput EvaStrafe { get; }

		IGameInput EvaTetherLength { get; }

		IGameInput EvaToggleWalk { get; }

		IGameInput EvaTurn { get; }

		IGameInput FlightOpenMenu { get; }

		IGameInput FullThrottle { get; }

		IGameInput GroupParts { get; }

		IGameInput IncreaseRotationalSpeed { get; }

		IGameInput IncreaseSpeed { get; }

		IGameInput KillThrottle { get; }

		IGameInput LoadContentFromClipboardUrl { get; }

		IGameInput LockHeading { get; }

		IGameInput LockPrograde { get; }

		IGameInput LockRetrograde { get; }

		IGameInput LockTarget { get; }

		IGameInput MapSetTargetModifier { get; }

		IGameInput MirrorSelectedPart { get; }

		IGameInput MoveCameraBackward { get; }

		IGameInput MoveCameraDown { get; }

		IGameInput MoveCameraForward { get; }

		IGameInput MoveCameraLeft { get; }

		IGameInput MoveCameraRight { get; }

		IGameInput MoveCameraUp { get; }

		IGameInput NextCameraMode { get; }

		IGameInput NudgePartNegativeX { get; }

		IGameInput NudgePartNegativeY { get; }

		IGameInput NudgePartNegativeZ { get; }

		IGameInput NudgePartPositiveX { get; }

		IGameInput NudgePartPositiveY { get; }

		IGameInput NudgePartPositiveZ { get; }

		IGameInput OpenPhotoLibrary { get; }

		IGameInput OpenSymmetryTool { get; }

		IGameInput Pause { get; }

		IGameInput Pitch { get; }

		IGameInput PlanetStudioMovementModeNext { get; }

		IGameInput PlanetStudioMovementModePrevious { get; }

		IGameInput PlanetStudioOpenMenu { get; }

		IGameInput PlanetStudioRebuildPlanet { get; }

		IGameInput PlanetStudioRecenterCamera { get; }

		IGameInput PreventPartSelection { get; }

		IGameInput PreviousCameraMode { get; }

		IGameInput QuickLoad { get; }

		IGameInput QuickSave { get; }

		IGameInput ReattachSelectedPart { get; }

		IGameInput Redo { get; }

		IGameInput ResetSunTiltAngle { get; }

		IGameInput Roll { get; }

		IGameInput RollCameraLeft { get; }

		IGameInput RollCameraRight { get; }

		IGameInput RotateCameraDown { get; }

		IGameInput RotateCameraLeft { get; }

		IGameInput RotateCameraRight { get; }

		IGameInput RotateCameraUp { get; }

		IGameInput RotateNegativeX { get; }

		IGameInput RotateNegativeY { get; }

		IGameInput RotateNegativeZ { get; }

		IGameInput RotatePlanetLeft { get; }

		IGameInput RotatePlanetRight { get; }

		IGameInput RotatePositiveX { get; }

		IGameInput RotatePositiveY { get; }

		IGameInput RotatePositiveZ { get; }

		IGameInput RotateWithPlanetLeft { get; }

		IGameInput RotateWithPlanetRight { get; }

		IGameInput SaveDesign { get; }

		IGameInput SaveLaunchLocation { get; }

		IGameInput SelectFuselageShapeTool { get; }

		IGameInput SelectMovePartTool { get; }

		IGameInput SelectNudgeTool { get; }

		IGameInput SelectPaintTool { get; }

		IGameInput SelectRotateTool { get; }

		IGameInput Slider1 { get; }

		IGameInput Slider2 { get; }

		IGameInput Slider3 { get; }

		IGameInput Slider4 { get; }

		IGameInput SnapToGround { get; }

		IGameInput SwapEvaStrafeTurn { get; }

		IGameInput SwapRollYaw { get; }

		IGameInput SymmetryModeNext { get; }

		IGameInput SymmetryModePrevious { get; }

		IGameInput Throttle { get; }

		IGameInput TiltSunDown { get; }

		IGameInput TiltSunUp { get; }

		IGameInput TimeWarpDecrease { get; }

		IGameInput TimeWarpIncrease { get; }

		IGameInput ToggleHideUI { get; }

		IGameInput ToggleMapView { get; }

		IGameInput ToggleMouseJoystick { get; }

		IGameInput ToggleMusic { get; }

		IGameInput ToggleNavSphere { get; }

		IGameInput TogglePartConnectionsPanel { get; }

		IGameInput TogglePerformanceAnalyzer { get; }

		IGameInput ToggleTranslationMode { get; }

		IGameInput ToolModifier { get; }

		IGameInput TranslateForwardBackward { get; }

		IGameInput TranslateLeftRight { get; }

		IGameInput TranslateUpDown { get; }

		IGameInput UICancel { get; }

		IGameInput UIHorizontal { get; }

		IGameInput UISubmit { get; }

		IGameInput UIVertical { get; }

		IGameInput Undo { get; }

		IGameInput Yaw { get; }

		IGameInput FindById(string id);

		bool IsActionInMapCategory(string mapCategoryName, string actionName);
	}
}
