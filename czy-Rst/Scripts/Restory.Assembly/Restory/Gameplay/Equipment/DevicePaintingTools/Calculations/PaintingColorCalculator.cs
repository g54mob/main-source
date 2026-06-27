using Mandragora.PWS;
using Restory.Scripts.Restory.Gameplay.Equipment.DevicePaintingTools.Tables;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools.Calculations
{
	public class PaintingColorCalculator : MonoBehaviour
	{
		private const int RESULT_BUFFER_SIZE = 5;

		private const int MASK_PIXELS_INDEX = 0;

		private const int PAINTED_PIXELS_INDEX = 1;

		private const int RED_PIXELS_INDEX = 2;

		private const int GREEN_PIXELS_INDEX = 3;

		private const int BLUE_PIXELS_INDEX = 4;

		[SerializeField]
		private ComputeShader paintingColorCalculator;

		[SerializeField]
		private Color minColor = new Color(0.001f, 0.001f, 0.001f, 0.001f);

		private uint[] resultBufferData = new uint[5];

		private readonly uint[] clearData = new uint[5];

		private PaintingProgressInPercentage lastCachedProgress;

		private DevicePaintingThresholdsParametersTable devicePaintingThresholdsParametersTable;

		private int computeShaderKernel;

		private CommandBuffer commandBuffer;

		private ComputeBuffer resultBuffer;

		private static readonly int PaintingTextureParam = Shader.PropertyToID("PaintingTexture");

		private static readonly int MaskTextureParam = Shader.PropertyToID("MaskTexture");

		private static readonly int ResultParam = Shader.PropertyToID("Result");

		private static readonly int MinColorParam = Shader.PropertyToID("MinColor");

		[Inject]
		private void Construct(DevicePaintingThresholdsParametersTable devicePaintingThresholdsParametersTable)
		{
			this.devicePaintingThresholdsParametersTable = devicePaintingThresholdsParametersTable;
		}

		private void Awake()
		{
			if (paintingColorCalculator != null)
			{
				computeShaderKernel = paintingColorCalculator.FindKernel("CSMain");
				resultBuffer = new ComputeBuffer(5, 4);
			}
			commandBuffer = new CommandBuffer
			{
				name = "PaintingColorCalculator"
			};
		}

		private void OnDestroy()
		{
			if (commandBuffer != null)
			{
				commandBuffer.Release();
				commandBuffer = null;
			}
			if (resultBuffer != null)
			{
				resultBuffer.Release();
				resultBuffer = null;
			}
		}

		public PaintingProgressInPercentage CalculateAdaptedProgress(PaintableDevice paintableDevice)
		{
			PaintingProgressInPercentage paintingProgressInPercentage = CalculateRawProgress(paintableDevice);
			devicePaintingThresholdsParametersTable.GetParametersOrDefault(paintableDevice.DeviceInfo, out var parameters);
			float paintedArea = paintingProgressInPercentage.PaintedArea;
			Vector2 thresholdRange = parameters.ThresholdRange;
			float paintedArea2 = Mathf.InverseLerp(thresholdRange.x, thresholdRange.y, paintedArea);
			return new PaintingProgressInPercentage
			{
				PaintedArea = paintedArea2,
				RedChannel = paintingProgressInPercentage.RedChannel,
				GreenChannel = paintingProgressInPercentage.GreenChannel,
				BlueChannel = paintingProgressInPercentage.BlueChannel
			};
		}

		private PaintingProgressInPercentage CalculateRawProgress(PaintableDevice paintableDevice)
		{
			if (!paintableDevice || !paintableDevice.DevicePaintingTexture || !paintableDevice.DevicePaintingMaskTexture || paintingColorCalculator == null || resultBuffer == null || commandBuffer == null)
			{
				return PaintingProgressInPercentage.ZeroProgress;
			}
			Texture2D devicePaintingTexture = paintableDevice.DevicePaintingTexture;
			Texture2D devicePaintingMaskTexture = paintableDevice.DevicePaintingMaskTexture;
			resultBuffer.SetData(clearData);
			commandBuffer.Clear();
			commandBuffer.SetComputeTextureParam(paintingColorCalculator, computeShaderKernel, PaintingTextureParam, devicePaintingTexture);
			commandBuffer.SetComputeTextureParam(paintingColorCalculator, computeShaderKernel, MaskTextureParam, devicePaintingMaskTexture);
			commandBuffer.SetComputeBufferParam(paintingColorCalculator, computeShaderKernel, ResultParam, resultBuffer);
			commandBuffer.SetComputeVectorParam(paintingColorCalculator, MinColorParam, minColor);
			int threadGroupsX = Mathf.CeilToInt((float)devicePaintingTexture.width / 8f);
			int threadGroupsY = Mathf.CeilToInt((float)devicePaintingTexture.height / 8f);
			commandBuffer.DispatchCompute(paintingColorCalculator, computeShaderKernel, threadGroupsX, threadGroupsY, 1);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			resultBuffer.GetData(resultBufferData);
			uint num = resultBufferData[0];
			if (num == 0)
			{
				return PaintingProgressInPercentage.ZeroProgress;
			}
			return lastCachedProgress = new PaintingProgressInPercentage
			{
				PaintedArea = GetProgress(resultBufferData[1], num),
				RedChannel = GetProgress(resultBufferData[2], num),
				GreenChannel = GetProgress(resultBufferData[3], num),
				BlueChannel = GetProgress(resultBufferData[4], num)
			};
		}

		public void Clean()
		{
			SetArrayValue(resultBufferData, 0u);
			resultBuffer?.SetData(clearData);
		}

		private float GetProgress(uint paintedPixels, uint maskPixels)
		{
			if (maskPixels != 0)
			{
				return Mathf.Clamp01((float)paintedPixels / (float)maskPixels);
			}
			return 0f;
		}

		private void SetArrayValue(uint[] array, uint value)
		{
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}
	}
}
