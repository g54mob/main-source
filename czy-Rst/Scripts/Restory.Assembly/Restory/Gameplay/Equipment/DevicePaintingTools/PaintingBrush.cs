using System;
using System.Collections.Generic;
using Mandragora.PWS;
using Restory.Data.Equipment;
using UnityEngine;
using UnityEngine.Rendering;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingBrush : MonoBehaviour
	{
		private const int REFERENCE_RESOLUTION = 1024;

		[SerializeField]
		private ConcentricCirclesPaintingBrushMultiRaycaster multiRaycaster;

		[SerializeField]
		private PaintingBrushSingleAndLineRaycaster singleRaycaster;

		[SerializeField]
		private ComputeShader brushComputeShader;

		[SerializeField]
		private float segmentUvContinuityToleranceInBrushSizes = 2f;

		private Texture2D currentMultiBrushStampTexture;

		private Texture2D currentMultiBrushStampTextureSource;

		private Texture2D currentSingleBrushStampTexture;

		private Texture2D currentSingleBrushStampTextureSource;

		private int brushStrokeBufferComputeShaderKernel;

		private int brushSegmentBufferComputeShaderKernel;

		private int brushCommitShaderKernel;

		private CommandBuffer commandBuffer;

		private RenderTexture strokeBaseRenderTexture;

		private RenderTexture workRenderTexture;

		private RenderTexture strokeBufferTexture;

		private Texture2D lastProcessedWorkTexture;

		private List<PaintableTargetRaycastData> paintingTargetsRaycastData = new List<PaintableTargetRaycastData>();

		private Vector2Int currentMultiRaycastBrushSingleStampSize;

		private Vector2Int currentSingleRaycastBrushStampSize;

		private Vector2 cursorSize;

		private PaintingPaletteInfo paintingPalette;

		private Color paintingColor = Color.blue;

		private float multiBrushStrength = 1f;

		private float smallBrushStrength = 1f;

		private bool isPaintingStrokeActive;

		private BrushRaycastingMode brushRaycastingMode;

		private PaintableDevice targetPaintableDevice;

		public PaintingPaletteInfo CurrentPaintingPalette => paintingPalette;

		public Vector2 CursorSize
		{
			get
			{
				return cursorSize;
			}
			set
			{
				if (!Mathf.Approximately(value.x, cursorSize.x) && !Mathf.Approximately(value.y, cursorSize.y))
				{
					cursorSize = value;
					this.OnCursorSizeChanged?.Invoke();
				}
			}
		}

		public BrushRaycastingMode BrushRaycastingMode => brushRaycastingMode;

		public event Action OnExecute;

		public event Action OnPaintAppliedToTarget;

		public event Action OnCursorSizeChanged;

		private void OnEnable()
		{
			if (brushComputeShader != null)
			{
				brushStrokeBufferComputeShaderKernel = brushComputeShader.FindKernel("CSAddToBuffer");
				brushSegmentBufferComputeShaderKernel = brushComputeShader.FindKernel("CSAddSegmentToBuffer");
				brushCommitShaderKernel = brushComputeShader.FindKernel("CSCommit");
			}
			commandBuffer = new CommandBuffer();
			commandBuffer.name = "BrushApplyBuffer";
		}

		private void OnDisable()
		{
			if (commandBuffer != null)
			{
				commandBuffer.Release();
				commandBuffer = null;
			}
			if (workRenderTexture != null)
			{
				workRenderTexture.Release();
				workRenderTexture = null;
			}
			if (strokeBaseRenderTexture != null)
			{
				strokeBaseRenderTexture.Release();
				strokeBaseRenderTexture = null;
			}
			if (strokeBufferTexture != null)
			{
				strokeBufferTexture.Release();
				strokeBufferTexture = null;
			}
		}

		public void SetTarget(PaintableDevice targetPaintableDevice, IEnumerable<PaintableElement> paintableElements)
		{
			this.targetPaintableDevice = targetPaintableDevice;
			foreach (PaintableElement paintableElement in paintableElements)
			{
				if ((bool)paintableElement && (bool)paintableElement.PaintingTextureHolder && (bool)paintableElement.RaycastTarget)
				{
					paintingTargetsRaycastData.Add(new PaintableTargetRaycastData
					{
						PaintableElement = paintableElement,
						HitTextureCoordinates = new Vector2Int[GetMaxRaysCount()]
					});
				}
			}
		}

		public void UnsetTarget()
		{
			EndPaintingStroke();
			paintingTargetsRaycastData.Clear();
			targetPaintableDevice = null;
		}

		public void Execute(Vector3 screenPosition)
		{
			PerformPaintingOperation(screenPosition);
			this.OnExecute?.Invoke();
		}

		public void ChangeRayCastingMode(BrushRaycastingMode newMode)
		{
			brushRaycastingMode = newMode;
			foreach (PaintableTargetRaycastData paintingTargetsRaycastDatum in paintingTargetsRaycastData)
			{
				paintingTargetsRaycastDatum.HitTextureCoordinates = new Vector2Int[GetMaxRaysCount()];
			}
		}

		public void ClearPreviousBrushPosition()
		{
			EndPaintingStroke();
			singleRaycaster.ClearPreviousPoints();
		}

		public void SetMultiBrushSizeDependentParameters(Vector2 newSingleStampSize, float newRaycastRingsSpacing, float rayMaxRandomDeviation, Vector2 newCursorSize)
		{
			currentMultiRaycastBrushSingleStampSize = GetBrushStampTextureSize(newSingleStampSize);
			currentMultiBrushStampTexture = TextureScaler.Scaled(currentMultiBrushStampTextureSource, currentMultiRaycastBrushSingleStampSize.x, currentMultiRaycastBrushSingleStampSize.y);
			multiRaycaster.SetBrushSettings(newRaycastRingsSpacing, rayMaxRandomDeviation);
			CursorSize = newCursorSize;
		}

		public void SetSingleCastBrushSize(Vector2 brushSize, Vector2 newCursorSize)
		{
			currentSingleRaycastBrushStampSize = GetBrushStampTextureSize(brushSize);
			currentSingleBrushStampTexture = TextureScaler.Scaled(currentSingleBrushStampTextureSource, currentSingleRaycastBrushStampSize.x, currentSingleRaycastBrushStampSize.y);
			CursorSize = newCursorSize;
		}

		public void SetMultiBrush(Texture2D newSingleBrushStampTexture, Vector2 newSingleStampSize, float newRaycastRingsSpacing, float rayMaxRandomDeviation, Vector2 newCursorSize, bool shouldRaysGoParallelInWorldSpace = false)
		{
			currentMultiBrushStampTextureSource = newSingleBrushStampTexture;
			currentMultiRaycastBrushSingleStampSize = GetBrushStampTextureSize(newSingleStampSize);
			currentMultiBrushStampTexture = TextureScaler.Scaled(newSingleBrushStampTexture, currentMultiRaycastBrushSingleStampSize.x, currentMultiRaycastBrushSingleStampSize.y);
			multiRaycaster.SetBrushSettings(newRaycastRingsSpacing, rayMaxRandomDeviation, shouldRaysGoParallelInWorldSpace);
			CursorSize = newCursorSize;
		}

		public void SetSmallBrush(Texture2D brushTexture, Vector2 brushSize, Vector2 brushCursorSize)
		{
			currentSingleBrushStampTextureSource = brushTexture;
			currentSingleRaycastBrushStampSize = GetBrushStampTextureSize(brushSize);
			currentSingleBrushStampTexture = TextureScaler.Scaled(brushTexture, currentSingleRaycastBrushStampSize.x, currentSingleRaycastBrushStampSize.y);
			CursorSize = brushCursorSize;
		}

		public void SetBrushStrength(float multiBrushStrength, float smallBrushStrength)
		{
			this.multiBrushStrength = multiBrushStrength;
			this.smallBrushStrength = smallBrushStrength;
		}

		public void SetPaintingColor(Color newColor)
		{
			paintingColor = newColor.linear;
		}

		public void SetActivePalette(PaintingPaletteInfo newPalette)
		{
			paintingPalette = newPalette;
		}

		private int GetMaxRaysCount()
		{
			return brushRaycastingMode switch
			{
				BrushRaycastingMode.ConcentricCirclesMultiRaycasts => multiRaycaster.MaxRaysCount, 
				BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine => singleRaycaster.MaxRaycasts, 
				_ => throw new NotImplementedException(), 
			};
		}

		private void PerformPaintingOperation(Vector3 screenPosition)
		{
			switch (brushRaycastingMode)
			{
			case BrushRaycastingMode.ConcentricCirclesMultiRaycasts:
				if (multiRaycaster.TryGetPaintingMultiRaycastResults(paintingTargetsRaycastData, screenPosition))
				{
					ApplyConcentricCirclesPaintingComputeShader();
				}
				break;
			case BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine:
				if (singleRaycaster.TryGetRaycastSegmentResult(paintingTargetsRaycastData, screenPosition, GetSegmentUvContinuityTolerance()))
				{
					ApplySegmentPaintingComputeShader();
				}
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void ApplySegmentPaintingComputeShader()
		{
			foreach (PaintableTargetRaycastData paintingTargetsRaycastDatum in paintingTargetsRaycastData)
			{
				if (paintingTargetsRaycastDatum.HasLineSegment)
				{
					Texture2D paintingTexture = paintingTargetsRaycastDatum.PaintableElement.PaintingTextureHolder.PaintingTexture;
					EnsurePaintingStrokeTextures(paintingTexture, "ApplySegmentBrushComputeShader.SetupStrokeTextures");
					Vector2Int segmentStartTextureCoordinate = paintingTargetsRaycastDatum.SegmentStartTextureCoordinate;
					Vector2Int segmentEndTextureCoordinate = paintingTargetsRaycastDatum.SegmentEndTextureCoordinate;
					int x = currentSingleRaycastBrushStampSize.x;
					int y = currentSingleRaycastBrushStampSize.y;
					int num = Mathf.CeilToInt((float)x * 0.5f) + 1;
					int num2 = Mathf.CeilToInt((float)y * 0.5f) + 1;
					int num3 = Mathf.Clamp(Mathf.Min(segmentStartTextureCoordinate.x, segmentEndTextureCoordinate.x) - num, 0, workRenderTexture.width);
					int num4 = Mathf.Clamp(Mathf.Min(segmentStartTextureCoordinate.y, segmentEndTextureCoordinate.y) - num2, 0, workRenderTexture.height);
					int num5 = Mathf.Clamp(Mathf.Max(segmentStartTextureCoordinate.x, segmentEndTextureCoordinate.x) + num, 0, workRenderTexture.width);
					int num6 = Mathf.Clamp(Mathf.Max(segmentStartTextureCoordinate.y, segmentEndTextureCoordinate.y) + num2, 0, workRenderTexture.height);
					int num7 = num5 - num3;
					int num8 = num6 - num4;
					if (num7 > 0 && num8 > 0)
					{
						commandBuffer.Clear();
						commandBuffer.SetComputeTextureParam(brushComputeShader, brushSegmentBufferComputeShaderKernel, "BrushTexture", currentSingleBrushStampTexture);
						commandBuffer.SetComputeTextureParam(brushComputeShader, brushSegmentBufferComputeShaderKernel, "StrokeBuffer", strokeBufferTexture);
						commandBuffer.SetComputeTextureParam(brushComputeShader, brushSegmentBufferComputeShaderKernel, "MaskTexture", paintingTargetsRaycastDatum.PaintableElement.PaintingTextureHolder.PaintableAreaMaskTexture);
						commandBuffer.SetComputeVectorParam(brushComputeShader, "TextureSize", new Vector4(paintingTexture.width, paintingTexture.height, 0f, 0f));
						commandBuffer.SetComputeVectorParam(brushComputeShader, "BrushSize", new Vector4(x, y, 0f, 0f));
						commandBuffer.SetComputeVectorParam(brushComputeShader, "OverrideBrushColor", paintingColor);
						commandBuffer.SetComputeVectorParam(brushComputeShader, "RectOffset", new Vector4(num3, num4, 0f, 0f));
						commandBuffer.SetComputeVectorParam(brushComputeShader, "SegmentStartCoord", new Vector4(segmentStartTextureCoordinate.x, segmentStartTextureCoordinate.y, 0f, 0f));
						commandBuffer.SetComputeVectorParam(brushComputeShader, "SegmentEndCoord", new Vector4(segmentEndTextureCoordinate.x, segmentEndTextureCoordinate.y, 0f, 0f));
						commandBuffer.SetComputeIntParam(brushComputeShader, "SegmentStartCapEnabled", paintingTargetsRaycastDatum.SegmentHasStartCap ? 1 : 0);
						commandBuffer.SetComputeFloatParam(brushComputeShader, "BrushPower", smallBrushStrength);
						int threadGroupsX = Mathf.CeilToInt((float)num7 / 8f);
						int threadGroupsY = Mathf.CeilToInt((float)num8 / 8f);
						commandBuffer.DispatchCompute(brushComputeShader, brushSegmentBufferComputeShaderKernel, threadGroupsX, threadGroupsY, 1);
						Graphics.ExecuteCommandBuffer(commandBuffer);
						ApplyStrokeBufferToPaintingTexture(paintingTargetsRaycastDatum, paintingTexture, "ApplySegmentBrushComputeShader.ApplyStroke");
					}
				}
			}
		}

		private void ApplyConcentricCirclesPaintingComputeShader()
		{
			foreach (PaintableTargetRaycastData paintingTargetsRaycastDatum in paintingTargetsRaycastData)
			{
				if (paintingTargetsRaycastDatum.ValidCoordinatesCount <= 0)
				{
					continue;
				}
				Texture2D paintingTexture = paintingTargetsRaycastDatum.PaintableElement.PaintingTextureHolder.PaintingTexture;
				EnsureImmediatePaintingTextures(paintingTexture, "ApplyBrushComputeShader.SetupWorkTextures");
				Texture2D texture2D = currentMultiBrushStampTexture;
				int x = currentMultiRaycastBrushSingleStampSize.x;
				int y = currentMultiRaycastBrushSingleStampSize.y;
				commandBuffer.Clear();
				commandBuffer.SetComputeTextureParam(brushComputeShader, brushStrokeBufferComputeShaderKernel, "BrushTexture", texture2D);
				commandBuffer.SetComputeTextureParam(brushComputeShader, brushStrokeBufferComputeShaderKernel, "StrokeBuffer", strokeBufferTexture);
				commandBuffer.SetComputeTextureParam(brushComputeShader, brushStrokeBufferComputeShaderKernel, "MaskTexture", paintingTargetsRaycastDatum.PaintableElement.PaintingTextureHolder.PaintableAreaMaskTexture);
				commandBuffer.SetComputeVectorParam(brushComputeShader, "TextureSize", new Vector4(paintingTexture.width, paintingTexture.height, 0f, 0f));
				commandBuffer.SetComputeVectorParam(brushComputeShader, "BrushSize", new Vector4(x, y, 0f, 0f));
				commandBuffer.SetComputeVectorParam(brushComputeShader, "OverrideBrushColor", paintingColor);
				commandBuffer.SetComputeFloatParam(brushComputeShader, "BrushPower", multiBrushStrength);
				int threadGroupsX = Mathf.CeilToInt((float)x / 8f);
				int threadGroupsY = Mathf.CeilToInt((float)y / 8f);
				int num = int.MaxValue;
				int num2 = int.MaxValue;
				int num3 = int.MinValue;
				int num4 = int.MinValue;
				int num5 = x;
				for (int i = 0; i < paintingTargetsRaycastDatum.ValidCoordinatesCount; i++)
				{
					Vector2Int vector2Int = paintingTargetsRaycastDatum.HitTextureCoordinates[i];
					commandBuffer.SetComputeVectorParam(brushComputeShader, "TargetCoord", new Vector4(vector2Int.x, vector2Int.y, 0f, 0f));
					commandBuffer.DispatchCompute(brushComputeShader, brushStrokeBufferComputeShaderKernel, threadGroupsX, threadGroupsY, 1);
					if (vector2Int.x - num5 < num)
					{
						num = vector2Int.x - num5;
					}
					if (vector2Int.x + num5 > num3)
					{
						num3 = vector2Int.x + num5;
					}
					if (vector2Int.y - num5 < num2)
					{
						num2 = vector2Int.y - num5;
					}
					if (vector2Int.y + num5 > num4)
					{
						num4 = vector2Int.y + num5;
					}
				}
				Graphics.ExecuteCommandBuffer(commandBuffer);
				num = Mathf.Clamp(num, 0, workRenderTexture.width);
				num2 = Mathf.Clamp(num2, 0, workRenderTexture.height);
				num3 = Mathf.Clamp(num3, 0, workRenderTexture.width);
				num4 = Mathf.Clamp(num4, 0, workRenderTexture.height);
				int num6 = num3 - num;
				int num7 = num4 - num2;
				if (num6 > 0 && num7 > 0)
				{
					ApplyStrokeBufferRectToPaintingTexture(paintingTargetsRaycastDatum, paintingTexture, num, num2, num6, num7, "ApplyBrushComputeShader.ApplyStroke");
				}
			}
		}

		private int WrapTextureCoordinate(int value, int maxValue)
		{
			return (value % maxValue + maxValue) % maxValue;
		}

		private void EnsurePaintingStrokeTextures(Texture2D paintingTexture, string profilerSampleName)
		{
			if (!workRenderTexture || !strokeBaseRenderTexture || !strokeBufferTexture || workRenderTexture.width != paintingTexture.width || workRenderTexture.height != paintingTexture.height)
			{
				RecreatePaintingStrokeRenderTextures(paintingTexture.width, paintingTexture.height);
			}
			if (!isPaintingStrokeActive || lastProcessedWorkTexture != paintingTexture)
			{
				Graphics.Blit(paintingTexture, strokeBaseRenderTexture);
				ClearRenderTexture(strokeBufferTexture);
				lastProcessedWorkTexture = paintingTexture;
				isPaintingStrokeActive = true;
			}
		}

		private void EnsureImmediatePaintingTextures(Texture2D paintingTexture, string profilerSampleName)
		{
			if (!workRenderTexture || !strokeBufferTexture || workRenderTexture.width != paintingTexture.width || workRenderTexture.height != paintingTexture.height)
			{
				RecreatePaintingStrokeRenderTextures(paintingTexture.width, paintingTexture.height);
			}
			if (isPaintingStrokeActive || lastProcessedWorkTexture != paintingTexture)
			{
				Graphics.Blit(paintingTexture, workRenderTexture);
				lastProcessedWorkTexture = paintingTexture;
				isPaintingStrokeActive = false;
			}
			ClearRenderTexture(strokeBufferTexture);
		}

		private void RecreatePaintingStrokeRenderTextures(int width, int height)
		{
			ReleaseRenderTexture(ref workRenderTexture);
			ReleaseRenderTexture(ref strokeBaseRenderTexture);
			ReleaseRenderTexture(ref strokeBufferTexture);
			workRenderTexture = CreatePaintingRenderTexture(width, height);
			strokeBaseRenderTexture = CreatePaintingRenderTexture(width, height);
			strokeBufferTexture = CreatePaintingRenderTexture(width, height);
		}

		private RenderTexture CreatePaintingRenderTexture(int width, int height)
		{
			RenderTexture renderTexture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear)
			{
				enableRandomWrite = true
			};
			renderTexture.Create();
			ClearRenderTexture(renderTexture);
			return renderTexture;
		}

		private void ReleaseRenderTexture(ref RenderTexture renderTexture)
		{
			if ((bool)renderTexture)
			{
				renderTexture.Release();
				renderTexture = null;
			}
		}

		private void ClearRenderTexture(RenderTexture renderTexture)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			GL.Clear(clearDepth: true, clearColor: true, new Color(0f, 0f, 0f, 0f));
			RenderTexture.active = active;
		}

		private void ApplyStrokeBufferToPaintingTexture(PaintableTargetRaycastData paintingTarget, Texture2D paintingTexture, string profilerSampleName)
		{
			Graphics.Blit(strokeBaseRenderTexture, workRenderTexture);
			commandBuffer.Clear();
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushCommitShaderKernel, "StrokeBuffer", strokeBufferTexture);
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushCommitShaderKernel, "WorkTexture", workRenderTexture);
			commandBuffer.SetComputeVectorParam(brushComputeShader, "TextureSize", new Vector4(paintingTexture.width, paintingTexture.height, 0f, 0f));
			commandBuffer.SetComputeVectorParam(brushComputeShader, "RectOffset", new Vector4(0f, 0f, 0f, 0f));
			int threadGroupsX = Mathf.CeilToInt((float)paintingTexture.width / 8f);
			int threadGroupsY = Mathf.CeilToInt((float)paintingTexture.height / 8f);
			commandBuffer.DispatchCompute(brushComputeShader, brushCommitShaderKernel, threadGroupsX, threadGroupsY, 1);
			commandBuffer.CopyTexture(workRenderTexture, paintingTexture);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			this.OnPaintAppliedToTarget?.Invoke();
		}

		private void ApplyStrokeBufferRectToPaintingTexture(PaintableTargetRaycastData paintingTarget, Texture2D paintingTexture, int minX, int minY, int rectWidth, int rectHeight, string profilerSampleName)
		{
			commandBuffer.Clear();
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushCommitShaderKernel, "StrokeBuffer", strokeBufferTexture);
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushCommitShaderKernel, "WorkTexture", workRenderTexture);
			commandBuffer.SetComputeVectorParam(brushComputeShader, "TextureSize", new Vector4(paintingTexture.width, paintingTexture.height, 0f, 0f));
			commandBuffer.SetComputeVectorParam(brushComputeShader, "RectOffset", new Vector4(minX, minY, 0f, 0f));
			int threadGroupsX = Mathf.CeilToInt((float)rectWidth / 8f);
			int threadGroupsY = Mathf.CeilToInt((float)rectHeight / 8f);
			commandBuffer.DispatchCompute(brushComputeShader, brushCommitShaderKernel, threadGroupsX, threadGroupsY, 1);
			commandBuffer.CopyTexture(workRenderTexture, paintingTexture);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			this.OnPaintAppliedToTarget?.Invoke();
		}

		private void EndPaintingStroke()
		{
			isPaintingStrokeActive = false;
			lastProcessedWorkTexture = null;
		}

		private Vector2Int GetBrushStampTextureSize(Vector2 newSingleStampSize)
		{
			float num = (float)(targetPaintableDevice.PaintingTextureSize.x / 1024) * targetPaintableDevice.PaintingBrushSizeMultiplier;
			int x = Mathf.CeilToInt(newSingleStampSize.x * num);
			int y = Mathf.CeilToInt(newSingleStampSize.y * num);
			return new Vector2Int(x, y);
		}

		private float GetSegmentUvContinuityTolerance()
		{
			int num = Mathf.Max(currentSingleRaycastBrushStampSize.x, currentSingleRaycastBrushStampSize.y);
			return Mathf.Max(1f, (float)num * segmentUvContinuityToleranceInBrushSizes);
		}
	}
}
