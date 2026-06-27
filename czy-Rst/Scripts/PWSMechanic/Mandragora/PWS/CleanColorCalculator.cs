using System.Text;
using Mandragora.Utils;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Mandragora.PWS
{
	public class CleanColorCalculator : MonoBehaviour
	{
		[SerializeField]
		private ComputeShader calculationShader;

		[SerializeField]
		private Color minColor = new Color(0.1f, 0.1f, 0.1f, 0.1f);

		[SerializeField]
		private float minLeftDirtyRatio = 0.005f;

		[SerializeField]
		private float maxLeftDirtyRatio = 0.1f;

		private float[] channeledDirtyPercentage = new float[4];

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool debugMode;

		private string debugText;

		private readonly int[] clearData = new int[4];

		private readonly int[] resultBufferData = new int[4];

		private int computeShaderKernel;

		private CommandBuffer commandBuffer;

		private ComputeBuffer resultBuffer;

		private static readonly int MinColorParam = Shader.PropertyToID("MinColor");

		private static readonly int TextureMaskParam = Shader.PropertyToID("TextureMask");

		private static readonly int ResultParam = Shader.PropertyToID("Result");

		public void Awake()
		{
			if (calculationShader != null)
			{
				computeShaderKernel = calculationShader.FindKernel("CSMain");
				resultBuffer = new ComputeBuffer(1, 16);
			}
			commandBuffer = new CommandBuffer();
			commandBuffer.name = "CleanColorCalculator";
		}

		public void OnDestroy()
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

		public CleaningProgressInPercentage CalculateProgress(TextureMaskHolder textureMaskHolder)
		{
			Execute(textureMaskHolder, async: false, out var _);
			return textureMaskHolder.GetCleaningProgressPercentage();
		}

		public void Execute(TextureMaskHolder textureMaskHolder, bool async, out AffectedColorChannels forcefullyCleanedColorChannels)
		{
			forcefullyCleanedColorChannels = default(AffectedColorChannels);
			if ((bool)textureMaskHolder)
			{
				Texture2D workTexture = textureMaskHolder.WorkTexture;
				Vector2Int vector2Int = new Vector2Int(workTexture.width, workTexture.height);
				resultBuffer.SetData(clearData);
				commandBuffer.Clear();
				commandBuffer.SetComputeVectorParam(calculationShader, MinColorParam, minColor);
				commandBuffer.SetComputeTextureParam(calculationShader, computeShaderKernel, TextureMaskParam, workTexture);
				commandBuffer.SetComputeBufferParam(calculationShader, computeShaderKernel, ResultParam, resultBuffer);
				int threadGroupsX = Mathf.CeilToInt((float)vector2Int.x / 8f);
				int threadGroupsY = Mathf.CeilToInt((float)vector2Int.y / 8f);
				commandBuffer.DispatchCompute(calculationShader, computeShaderKernel, threadGroupsX, threadGroupsY, 1);
				Graphics.ExecuteCommandBuffer(commandBuffer);
				if (async)
				{
					AsyncGPUReadback.Request(resultBuffer, OnResultReadback);
				}
				else
				{
					SetArrayValue(resultBufferData, 0);
					resultBuffer.GetData(resultBufferData);
				}
				int num = resultBufferData[0];
				int num2 = resultBufferData[1];
				int num3 = resultBufferData[2];
				int dirtyPixelsChannelA = resultBufferData[3];
				if (textureMaskHolder.InitialDirtyPixelsCount.Total < 0)
				{
					textureMaskHolder.SetInitialDirtyPixelsCount(num, num2, num3);
					int totalPixelsInMeshCount = textureMaskHolder.TotalPixelsInMeshCount;
					int totalPixelsCountNotNecessaryToCleanForSeveralChannels = GetTotalPixelsCountNotNecessaryToCleanForSeveralChannels(totalPixelsInMeshCount, new DirtyPixelsCount
					{
						R = num,
						G = num2,
						B = 0
					});
					int pixelsCountNotNecessaryToCleanForSingleChannel = GetPixelsCountNotNecessaryToCleanForSingleChannel(totalPixelsInMeshCount, num3);
					textureMaskHolder.SetPixelsToLeaveDirtyCount(totalPixelsCountNotNecessaryToCleanForSeveralChannels, pixelsCountNotNecessaryToCleanForSingleChannel);
				}
				textureMaskHolder.SetCurrentDirtyPixelsCount(num, num2, num3);
				DirtyPixelsCount currentDirtyPixelsCount = textureMaskHolder.GetCurrentDirtyPixelsCount();
				DirtyPixelsCount initialDirtyPixelsCount = textureMaskHolder.GetInitialDirtyPixelsCount();
				CleaningProgressInPercentage obj = new CleaningProgressInPercentage
				{
					RedAndGreenChannel = GetCleaningProgressForSeveralChannels(new DirtyPixelsCount
					{
						R = initialDirtyPixelsCount.R,
						G = initialDirtyPixelsCount.G,
						B = 0
					}, new DirtyPixelsCount
					{
						R = currentDirtyPixelsCount.R,
						G = currentDirtyPixelsCount.G,
						B = 0
					}, textureMaskHolder.PixelsToLeaveDirtyCountRG),
					BlueChannel = GetCleaningProgressForChannel(initialDirtyPixelsCount.B, currentDirtyPixelsCount.B, textureMaskHolder.PixelsToLeaveDirtyCountB)
				};
				if (debugMode)
				{
					PrintDebug(textureMaskHolder.TotalPixelsInMeshCount, initialDirtyPixelsCount, textureMaskHolder.PixelsToLeaveDirtyCountRG, textureMaskHolder.PixelsToLeaveDirtyCountB, num, num2, num3, dirtyPixelsChannelA);
				}
				else
				{
					debugText = string.Empty;
				}
				bool flag = false;
				if (obj.RedAndGreenChannel >= 1f && (currentDirtyPixelsCount.R > 0 || currentDirtyPixelsCount.G > 0))
				{
					num = 0;
					num2 = 0;
					flag = true;
				}
				if (obj.BlueChannel >= 1f && currentDirtyPixelsCount.B > 0)
				{
					num3 = 0;
					flag = true;
				}
				if (flag)
				{
					textureMaskHolder.SetCurrentDirtyPixelsCount(num, num2, num3);
					forcefullyCleanedColorChannels = new AffectedColorChannels
					{
						Red = (num == 0),
						Green = (num2 == 0),
						Blue = (num3 == 0)
					};
				}
			}
		}

		private int GetPixelsCountNotNecessaryToCleanForSingleChannel(int totalPixelsInMesh, int initialDirtyPixels)
		{
			if (totalPixelsInMesh == 0 || initialDirtyPixels == 0)
			{
				return 0;
			}
			float t = (float)initialDirtyPixels / (float)totalPixelsInMesh;
			float num = Mathf.Lerp(minLeftDirtyRatio, maxLeftDirtyRatio, t);
			return (int)((float)totalPixelsInMesh * num);
		}

		private int GetTotalPixelsCountNotNecessaryToCleanForSeveralChannels(int totalPixelsInMesh, DirtyPixelsCount initialDirtyPixels)
		{
			if (totalPixelsInMesh == 0 || initialDirtyPixels.Total == 0)
			{
				return 0;
			}
			float t = (float)initialDirtyPixels.Total / (float)totalPixelsInMesh;
			float num = Mathf.Lerp(minLeftDirtyRatio, maxLeftDirtyRatio, t);
			return (int)((float)totalPixelsInMesh * num);
		}

		private static float GetCleaningProgressForChannel(int initialDirtyPixelsCount, int currentDirtyPixelsCount, int pixelsCountNotNecessaryToClean)
		{
			if (initialDirtyPixelsCount != 0)
			{
				return Mathf.Clamp01(1f - (float)(currentDirtyPixelsCount - pixelsCountNotNecessaryToClean) / (float)(initialDirtyPixelsCount - pixelsCountNotNecessaryToClean));
			}
			return 1f;
		}

		private static float GetCleaningProgressForSeveralChannels(DirtyPixelsCount initialDirtyPixelsCount, DirtyPixelsCount currentDirtyPixelsCount, int pixelsCountNotNecessaryToClean)
		{
			if (initialDirtyPixelsCount.Total != 0)
			{
				return Mathf.Clamp01(1f - (float)(currentDirtyPixelsCount.Total - pixelsCountNotNecessaryToClean) / (float)(initialDirtyPixelsCount.Total - pixelsCountNotNecessaryToClean));
			}
			return 1f;
		}

		private void SetArrayValue(int[] array, int value)
		{
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = value;
				}
			}
		}

		private void OnResultReadback(AsyncGPUReadbackRequest request)
		{
			if (!request.hasError)
			{
				NativeArray<int> data = request.GetData<int>();
				resultBufferData[0] = data[0];
				resultBufferData[1] = data[1];
				resultBufferData[2] = data[2];
				resultBufferData[3] = data[3];
			}
		}

		private void PrintDebug(int totalPixelsInMeshCount, DirtyPixelsCount initialDirtyPixels, int pixelsNotNecessaryToCleanRG, int pixelsNotNecessaryToCleanB, int dirtyPixelsChannelR, int dirtyPixelsChannelG, int dirtyPixelsChannelB, int dirtyPixelsChannelA)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("INITIAL INFO:");
			stringBuilder.AppendLine($"Total pixels in mesh - {totalPixelsInMeshCount}");
			stringBuilder.AppendLine($"Red - {initialDirtyPixels.R} = {(float)initialDirtyPixels.R / (float)totalPixelsInMeshCount * 100f}% from total pixels in mesh");
			stringBuilder.AppendLine($"Green - {initialDirtyPixels.G} = {(float)initialDirtyPixels.G / (float)totalPixelsInMeshCount * 100f}% from total pixels in mesh");
			stringBuilder.AppendLine($"Blue - {initialDirtyPixels.B} = {(float)initialDirtyPixels.B / (float)totalPixelsInMeshCount * 100f}% from total pixels in mesh");
			stringBuilder.AppendLine($"Red and Green to leave dirty - {pixelsNotNecessaryToCleanRG} = {(float)pixelsNotNecessaryToCleanRG / (float)totalPixelsInMeshCount * 100f}% from total pixels in mesh");
			stringBuilder.AppendLine($"Blue to leave dirty - {pixelsNotNecessaryToCleanB} = {(float)pixelsNotNecessaryToCleanB / (float)totalPixelsInMeshCount * 100f}% from total pixels in mesh");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("CURRENT DIRTY PIXELS COUNT:");
			stringBuilder.AppendLine($"Red - {dirtyPixelsChannelR}");
			stringBuilder.AppendLine($"Green - {dirtyPixelsChannelG}");
			stringBuilder.AppendLine($"Blue - {dirtyPixelsChannelB}");
			stringBuilder.AppendLine($"Alpha - {dirtyPixelsChannelA}");
			debugText = stringBuilder.ToString();
		}
	}
}
