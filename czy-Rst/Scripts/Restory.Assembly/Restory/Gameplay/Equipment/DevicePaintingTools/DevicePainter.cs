using System;
using System.Collections.Generic;
using Mandragora.PWS;
using Mandragora.Utils;
using Restory.Data.Equipment;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools.Calculations;
using Restory.Gameplay.Equipment.DevicePaintingTools.Services;
using Restory.Gameplay.TextureMasks;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class DevicePainter : MonoBehaviour
	{
		[SerializeField]
		private PaintingBrush paintingBrush;

		[SerializeField]
		private PaintingBrushPositionMover brushPositionMover;

		[SerializeField]
		private ComputeShader paintedAreaCheckComputeShader;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool useSmoothedMovement;

		private TextureCacheService textureCacheService;

		private PaintingColorCalculator paintingColorCalculator;

		private DevicePainterTextureLoggingService devicePainterTextureLoggingService;

		private PaintingSettings settings;

		private DeviceContainer targetDeviceContainer;

		private PaintableDevice targetPaintableDevice;

		private readonly List<PaintableElement> targetPaintableElements = new List<PaintableElement>();

		private int paintedAreaCheckComputeShaderKernelIndex;

		private bool wasPaintAppliedDuringCurrentStroke;

		public bool IsAbleToUndo => !devicePainterTextureLoggingService.FirstIndexReached;

		public bool IsAbleToRedo => !devicePainterTextureLoggingService.LastIndexReached;

		public PaintableDevice CurrentPaintableDevice => targetPaintableDevice;

		public IReadOnlyList<PaintableElement> TargetPaintableElements => targetPaintableElements;

		public event Action OnAnyChange;

		public event Action OnPaintingProcessStarted;

		public event Action OnPaintingProcessCompleted;

		[Inject]
		private void Construct(TextureCacheService textureCacheService, PaintingColorCalculator paintingColorCalculator, DevicePainterTextureLoggingService devicePainterTextureLoggingService, PaintingSettings settings)
		{
			this.paintingColorCalculator = paintingColorCalculator;
			this.devicePainterTextureLoggingService = devicePainterTextureLoggingService;
			this.textureCacheService = textureCacheService;
			this.settings = settings;
		}

		private void Awake()
		{
			paintedAreaCheckComputeShaderKernelIndex = paintedAreaCheckComputeShader.FindKernel("CSMain");
		}

		private void OnEnable()
		{
			paintingBrush.OnPaintAppliedToTarget += ResolvePaintAppliedToTarget;
		}

		private void OnDisable()
		{
			paintingBrush.OnPaintAppliedToTarget -= ResolvePaintAppliedToTarget;
		}

		public void SetTarget(DeviceContainer device)
		{
			if (device.Device.TryGetComponent<PaintableDevice>(out targetPaintableDevice))
			{
				targetDeviceContainer = device;
				targetPaintableDevice.InitializeTextures(settings);
				CollectPaintableElements();
				SwitchDeviceElementSocketsBehaviours(device);
				paintingBrush.SetTarget(targetPaintableDevice, targetPaintableElements);
				devicePainterTextureLoggingService.Initialize(settings, targetPaintableDevice, targetPaintableElements);
				wasPaintAppliedDuringCurrentStroke = false;
			}
		}

		private void SwitchDeviceElementSocketsBehaviours(DeviceContainer device)
		{
			foreach (ElementSocket elementSocket in device.Device.ElementSockets)
			{
				if ((bool)elementSocket && (bool)elementSocket.NestedElement)
				{
					if (IsElementPaintable(elementSocket.NestedElement))
					{
						elementSocket.NestedElement.BehaviorSwitcher.SwitchToTextureEditingBehavior();
					}
					else
					{
						elementSocket.NestedElement.BehaviorSwitcher.SwitchToPackedBehavior();
					}
				}
			}
		}

		private void CollectPaintableElements()
		{
			targetPaintableElements.Clear();
			foreach (ElementSocket elementSocket in targetDeviceContainer.Device.ElementSockets)
			{
				if ((bool)elementSocket.NestedElement && elementSocket.NestedElement.TryGetComponent<PaintableElement>(out var component))
				{
					targetPaintableElements.Add(component);
				}
			}
		}

		public void ClearAllPaintInTargetDevice()
		{
			if ((bool)targetDeviceContainer && (targetPaintableDevice.AnyPaintApplied || targetPaintableDevice.PaintTextureId > 0))
			{
				if (targetPaintableDevice.PaintTextureId > 0)
				{
					textureCacheService.RemoveTextureData(targetPaintableDevice.PaintTextureId);
					targetPaintableDevice.ClearPaintTextureId();
				}
				targetPaintableDevice.CleanPaintingTexture();
				devicePainterTextureLoggingService.RegisterSnapshot(targetPaintableDevice, targetPaintableElements, null, clearsPalettes: true);
				wasPaintAppliedDuringCurrentStroke = false;
				this.OnAnyChange?.Invoke();
			}
		}

		private bool IsElementPaintable(ElementBase element)
		{
			foreach (PaintableElement targetPaintableElement in targetPaintableElements)
			{
				if (targetPaintableElement.Element == element)
				{
					return true;
				}
			}
			return false;
		}

		private bool HasPaintInsideMask(Texture2D inputTexture, Texture2D maskTexture)
		{
			ComputeBuffer computeBuffer = new ComputeBuffer(1, 4);
			computeBuffer.SetData(new uint[1]);
			paintedAreaCheckComputeShader.SetTexture(paintedAreaCheckComputeShaderKernelIndex, "InputTexture", inputTexture);
			paintedAreaCheckComputeShader.SetTexture(paintedAreaCheckComputeShaderKernelIndex, "MaskTexture", maskTexture);
			paintedAreaCheckComputeShader.SetBuffer(paintedAreaCheckComputeShaderKernelIndex, "ResultBuffer", computeBuffer);
			paintedAreaCheckComputeShader.SetInt("Width", inputTexture.width);
			paintedAreaCheckComputeShader.SetInt("Height", inputTexture.height);
			int threadGroupsX = Mathf.CeilToInt((float)inputTexture.width / 8f);
			int threadGroupsY = Mathf.CeilToInt((float)inputTexture.height / 8f);
			paintedAreaCheckComputeShader.Dispatch(paintedAreaCheckComputeShaderKernelIndex, threadGroupsX, threadGroupsY, 1);
			AsyncGPUReadbackRequest asyncGPUReadbackRequest = AsyncGPUReadback.Request(computeBuffer);
			asyncGPUReadbackRequest.WaitForCompletion();
			uint num = 0u;
			if (!asyncGPUReadbackRequest.hasError)
			{
				num = asyncGPUReadbackRequest.GetData<uint>()[0];
			}
			computeBuffer.Release();
			return num != 0;
		}

		public void SetInitialPaintingScreenPosition(Vector2 initialScreenPosition)
		{
			brushPositionMover.SetInitialPaintingScreenPosition(initialScreenPosition);
		}

		public void ClearPreviousPaintingScreenPosition()
		{
			paintingBrush.ClearPreviousBrushPosition();
		}

		public void PrePaint()
		{
			wasPaintAppliedDuringCurrentStroke = false;
			this.OnPaintingProcessStarted?.Invoke();
		}

		public void Paint(Vector3 screenPosition)
		{
			if (useSmoothedMovement)
			{
				brushPositionMover.MoveTowardsPosition(screenPosition);
				paintingBrush.Execute(brushPositionMover.CurrentScreenPosition);
			}
			else
			{
				paintingBrush.Execute(screenPosition);
			}
		}

		public void PostPaint()
		{
			RegisterPendingPaintingSnapshot();
			this.OnPaintingProcessCompleted?.Invoke();
		}

		public void ResetTarget()
		{
			if ((bool)targetDeviceContainer)
			{
				foreach (ElementSocket elementSocket in targetDeviceContainer.Device.ElementSockets)
				{
					if ((bool)elementSocket.NestedElement)
					{
						elementSocket.NestedElement.ResetInstalledBehavior();
					}
				}
			}
			targetDeviceContainer = null;
			targetPaintableDevice = null;
			paintingBrush.UnsetTarget();
			targetPaintableElements.Clear();
			devicePainterTextureLoggingService.ClearSnapshots();
			wasPaintAppliedDuringCurrentStroke = false;
			paintingColorCalculator.Clean();
		}

		private void RegisterPendingPaintingSnapshot()
		{
			if (wasPaintAppliedDuringCurrentStroke && (bool)targetPaintableDevice)
			{
				devicePainterTextureLoggingService.RegisterSnapshot(targetPaintableDevice, targetPaintableElements, paintingBrush.CurrentPaintingPalette);
				wasPaintAppliedDuringCurrentStroke = false;
				this.OnAnyChange?.Invoke();
			}
		}

		public void RedoPaintingStep()
		{
			if ((bool)targetPaintableDevice)
			{
				paintingBrush.ClearPreviousBrushPosition();
				devicePainterTextureLoggingService.StepForward(targetPaintableDevice, targetPaintableElements);
				wasPaintAppliedDuringCurrentStroke = false;
				this.OnAnyChange?.Invoke();
			}
		}

		public void UndoPaintingStep()
		{
			if ((bool)targetPaintableDevice)
			{
				paintingBrush.ClearPreviousBrushPosition();
				devicePainterTextureLoggingService.StepBackward(targetPaintableDevice, targetPaintableElements);
				wasPaintAppliedDuringCurrentStroke = false;
				this.OnAnyChange?.Invoke();
			}
		}

		private void ResolvePaintAppliedToTarget()
		{
			wasPaintAppliedDuringCurrentStroke = true;
			this.OnAnyChange?.Invoke();
		}

		public PaintingProgressInPercentage CalculateProgress()
		{
			PaintingProgressInPercentage paintingProgressInPercentage = paintingColorCalculator.CalculateAdaptedProgress(targetPaintableDevice);
			targetPaintableDevice.SetPaintingProgress(paintingProgressInPercentage);
			return paintingProgressInPercentage;
		}
	}
}
