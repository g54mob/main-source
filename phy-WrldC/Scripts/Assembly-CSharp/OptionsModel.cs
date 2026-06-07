using System;
using UnityEngine;

[Serializable]
public class OptionsModel : BaseModel
{
	public enum FPSLimit
	{
		Unlimited = 0,
		FPS30 = 1,
		FPS60 = 2,
		FPS120 = 3,
		FPS144 = 4
	}

	public enum ReplayAccuracy
	{
		Low = 0,
		Normal = 1,
		High = 2
	}

	public enum GraphicQuality
	{
		Low = 0,
		High = 5
	}

	public const string ValuesChangedEvent = "OptionsModel.ValuesChangedEvent";

	public const string SaveValuesOnDiskEvent = "OptionsModel.SaveValuesOnDiskEvent";

	public string Language { get; set; }

	public float MasterVolume { get; set; }

	public float MusicVolume { get; set; }

	public float EffectsVolume { get; set; }

	public bool IsCheatsEnabled { get; set; }

	public int DisplayIndex { get; set; }

	public int ScreenWidth { get; set; }

	public int ScreenHeight { get; set; }

	public int ScreenRefreshRate { get; set; }

	public bool IsNativeResolution { get; set; }

	public bool IsFullscreen { get; set; }

	public bool IsBorderless { get; set; }

	public bool IsVSyncActivated { get; set; }

	public FPSLimit FPSLimitValue { get; set; }

	public GraphicQuality GraphicQualityValue { get; set; }

	public float CameraSensitivity { get; set; }

	public bool IsCameraKeysDisabled { get; set; }

	public KeyCode CameraForwardKey { get; set; }

	public KeyCode CameraBackwardKey { get; set; }

	public KeyCode CameraLeftKey { get; set; }

	public KeyCode CameraRightKey { get; set; }

	public KeyCode CameraUpKey { get; set; }

	public KeyCode CameraDownKey { get; set; }

	public bool IsJoystickAxesDisabled { get; set; }

	public bool IsJoystickCameraControlDisabled { get; set; }

	public bool IsLevelCreationInfosWinVisible { get; set; }

	public bool IsKeyListWinVisible { get; set; }

	public bool IsKeyListWinCompact { get; set; }

	public int ConnectorGridSize { get; set; }

	public bool IsAutoFocusActivated { get; set; }

	public bool IsAutoConnectionsActivated { get; set; }

	public bool IsReplayDisabled { get; set; }

	public ReplayAccuracy ReplayAccuracyValue { get; set; }

	public bool ShouldRemoveAudiosReplay { get; set; }

	public bool ShouldRemoveDecalsReplay { get; set; }

	public bool ShouldRemoveParticlesReplay { get; set; }

	public int GifDuration { get; set; }

	public int GifFPS { get; set; }

	public float GifSize { get; set; }

	public int GifQuality { get; set; }

	public bool IsWorkshopTrendsPanelVisible { get; set; }

	public OptionsModel()
	{
		Language = "en";
		MasterVolume = 10f;
		MusicVolume = 10f;
		EffectsVolume = 10f;
		IsCheatsEnabled = false;
		DisplayIndex = 0;
		ScreenWidth = 1920;
		ScreenHeight = 1080;
		ScreenRefreshRate = 60;
		IsNativeResolution = true;
		IsFullscreen = true;
		IsBorderless = false;
		IsVSyncActivated = true;
		FPSLimitValue = FPSLimit.Unlimited;
		GraphicQualityValue = GraphicQuality.High;
		CameraSensitivity = 5f;
		IsCameraKeysDisabled = false;
		CameraForwardKey = KeyCode.W;
		CameraBackwardKey = KeyCode.S;
		CameraLeftKey = KeyCode.A;
		CameraRightKey = KeyCode.D;
		CameraUpKey = KeyCode.Q;
		CameraDownKey = KeyCode.E;
		IsJoystickAxesDisabled = false;
		IsJoystickCameraControlDisabled = true;
		IsLevelCreationInfosWinVisible = true;
		IsKeyListWinVisible = false;
		IsKeyListWinCompact = false;
		ConnectorGridSize = 1;
		IsAutoFocusActivated = true;
		IsAutoConnectionsActivated = true;
		IsReplayDisabled = false;
		ReplayAccuracyValue = ReplayAccuracy.Normal;
		ShouldRemoveAudiosReplay = false;
		ShouldRemoveDecalsReplay = false;
		ShouldRemoveParticlesReplay = false;
		GifDuration = 5;
		GifFPS = 20;
		GifSize = 0.25f;
		GifQuality = 80;
		IsWorkshopTrendsPanelVisible = true;
	}

	public void ApplyOptions(bool shouldApplyLanguageToo = true)
	{
		NotifyChange("OptionsModel.ValuesChangedEvent", shouldApplyLanguageToo);
	}

	public void SaveValuesOnDisk()
	{
		NotifyChange("OptionsModel.SaveValuesOnDiskEvent");
	}
}
