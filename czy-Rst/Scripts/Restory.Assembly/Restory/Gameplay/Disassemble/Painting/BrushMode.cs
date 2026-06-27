using System.Threading;
using Mandragora.PWS;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Equipment.DevicePaintingTools.DeviceAdditionalProperties;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.UserInterface.DeviceCustomizations;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Painting
{
	public class BrushMode : IPaintingMode
	{
		private readonly IPlayerInput playerInput;

		private readonly DeviceService deviceService;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly DisassembleRotationController rotationController;

		private readonly TextureSaveLoadService textureSaveLoadService;

		private readonly TextureCacheService textureCacheService;

		private readonly GUI_DeviceCustomizationPanel deviceCustomizationPanel;

		private readonly DevicePainter devicePainter;

		private PaintingBrushSFX brushSoundPlayer;

		private bool IsExecuteButtonPressed => playerInput.GetButton(71);

		public BrushMode(IPlayerInput playerInput, DeviceService deviceService, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, DisassembleRotationController rotationController, TextureSaveLoadService textureSaveLoadService, TextureCacheService textureCacheService, DevicePainter devicePainter, GUI_DeviceCustomizationPanel deviceCustomizationPanel, PaintingBrushSFX brushSoundPlayer)
		{
			this.playerInput = playerInput;
			this.deviceService = deviceService;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.rotationController = rotationController;
			this.textureSaveLoadService = textureSaveLoadService;
			this.textureCacheService = textureCacheService;
			this.devicePainter = devicePainter;
			this.deviceCustomizationPanel = deviceCustomizationPanel;
			this.brushSoundPlayer = brushSoundPlayer;
		}

		public void Enter()
		{
			SyncUsedPalettesForDevice(deviceService.PlacedDeviceContainer, devicePainter.CurrentPaintableDevice);
			Subscribe();
			UpdateProgressInGUI();
		}

		public void OnUpdate(float deltaTime)
		{
			Vector2 mousePosition = playerInput.GetMousePosition();
			rotationController.OnUpdate();
			if (cursorDetectorService.UIDetector.TryToDetect(mousePosition, out var hitObject) && cursorSelectionService.DetectedGameObject == hitObject)
			{
				brushSoundPlayer.StopSound();
				return;
			}
			if ((bool)hitObject)
			{
				cursorSelectionService.SetDetection(hitObject);
				brushSoundPlayer.StopSound();
				return;
			}
			if (IsExecuteButtonPressed)
			{
				devicePainter.Paint(mousePosition);
				brushSoundPlayer.StartOrContinueSound();
				UpdateProgressInGUI();
			}
			cursorSelectionService.ClearDetection();
		}

		public void PressExecuteButton()
		{
			devicePainter.PrePaint();
			devicePainter.SetInitialPaintingScreenPosition(playerInput.GetMousePosition());
		}

		public void ReleaseExecuteButton()
		{
			devicePainter.PostPaint();
			devicePainter.SetInitialPaintingScreenPosition(Vector3.negativeInfinity);
			devicePainter.ClearPreviousPaintingScreenPosition();
			brushSoundPlayer.StopSound();
		}

		public void Redo()
		{
			devicePainter.RedoPaintingStep();
			UpdateProgressInGUI();
		}

		public void Undo()
		{
			devicePainter.UndoPaintingStep();
			UpdateProgressInGUI();
		}

		public void Exit()
		{
			brushSoundPlayer.StopSound();
			Unsubscribe();
			PaintableDevice currentPaintableDevice = devicePainter.CurrentPaintableDevice;
			if (!currentPaintableDevice)
			{
				return;
			}
			if (currentPaintableDevice.AnyPaintApplied)
			{
				CachePaintingTexture();
				if (!deviceService.PlacedDeviceContainer.AdditionalProperties.TryToAddProperty(new DevicePaintedAdditionalProperty(currentPaintableDevice.UsedPaletteCounts)))
				{
					if (deviceService.PlacedDeviceContainer.AdditionalProperties.TryToGetProperty<DevicePaintedAdditionalProperty>(out var foundProperty))
					{
						foundProperty.UpdateAppliedPalettes(currentPaintableDevice.UsedPaletteCounts);
					}
					else
					{
						Debug.LogError("[BrushMode] tried to save used palette counts data to the device's additional properties, but was unable to both add it as a new property and edit an existing property!");
					}
				}
			}
			else
			{
				deviceService.PlacedDeviceContainer.AdditionalProperties.RemoveProperty<DevicePaintedAdditionalProperty>();
			}
		}

		private void CachePaintingTexture()
		{
			Texture2D paintTexture = devicePainter.CurrentPaintableDevice.DevicePaintingTexture;
			textureCacheService.CacheTextureDataAsync(devicePainter.CurrentPaintableDevice, (CancellationToken token) => textureSaveLoadService.ConvertTextureToDataAsync(paintTexture, token), CachedTextureType.PaintingTexture);
		}

		private void UpdateProgressInGUI()
		{
			PaintingProgressInPercentage paintingProgress = devicePainter.CalculateProgress();
			deviceCustomizationPanel.UpdatePaintingProgress(paintingProgress);
		}

		private void SyncUsedPalettesForDevice(DeviceContainer currentDeviceContainer, PaintableDevice currentPaintableDevice)
		{
			if (currentDeviceContainer.AdditionalProperties.TryToGetProperty<DevicePaintedAdditionalProperty>(out var foundProperty))
			{
				currentPaintableDevice.UpdateUsedPalettesCount(foundProperty.UsedPalettesCount);
			}
			else
			{
				currentPaintableDevice.ClearRegisteredPalettes();
			}
		}

		private void Subscribe()
		{
			Unsubscribe();
			devicePainter.OnAnyChange += ResolveOnPaintableDeviceCleared;
		}

		private void Unsubscribe()
		{
			if ((bool)devicePainter.CurrentPaintableDevice)
			{
				devicePainter.OnAnyChange -= ResolveOnPaintableDeviceCleared;
			}
		}

		private void ResolveOnPaintableDeviceCleared()
		{
			UpdateProgressInGUI();
		}
	}
}
