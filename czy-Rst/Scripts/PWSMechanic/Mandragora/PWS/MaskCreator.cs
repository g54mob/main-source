using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Mandragora.PWS
{
	public class MaskCreator : MonoBehaviour
	{
		[SerializeField]
		private TextureMaskHolder textureMaskHolder;

		[SerializeField]
		private ComputeShader computeShader;

		[SerializeField]
		private MaskCreatorPreset preset;

		[SerializeField]
		private bool setRandomSeed;

		[SerializeField]
		[Range(0f, 1f)]
		private float randomSeed;

		private Texture2D resultTexture;

		private int computeShaderKernel;

		private ComputeBuffer uv0Buffer;

		private CommandBuffer commandBuffer;

		private ComputeBuffer resultBuffer;

		private Color32[] resultData;

		private static readonly int TextureMaskParam = Shader.PropertyToID("BaseColorTexture");

		private static readonly int UVCoordsParam = Shader.PropertyToID("UVCoords");

		private static readonly int ResultTextureParam = Shader.PropertyToID("Result");

		private static readonly int RandomSeedParam = Shader.PropertyToID("RandomSeed");

		private static readonly int RedChannelParam = Shader.PropertyToID("RedChannel");

		private static readonly int GreenChannelParam = Shader.PropertyToID("GreenChannel");

		private static readonly int BlueChannelParam = Shader.PropertyToID("BlueChannel");

		private ComputeBuffer redChannelBuffer;

		private ComputeBuffer greenChannelBuffer;

		private ComputeBuffer blueChannelBuffer;

		private RenderTexture resultRenderTexture;

		private bool isInitialized;

		private readonly float[] colorChannelBufferData = new float[5];

		private float[] uvBufferData;

		private void Awake()
		{
			if (!textureMaskHolder)
			{
				textureMaskHolder = base.gameObject.GetComponent<TextureMaskHolder>();
			}
			if (computeShader != null)
			{
				computeShaderKernel = computeShader.FindKernel("GradientNoiseGenerator");
			}
			commandBuffer = new CommandBuffer();
			commandBuffer.name = "DirtyMaskGeneratorCommandBuffer";
			redChannelBuffer = new ComputeBuffer(1, 20);
			greenChannelBuffer = new ComputeBuffer(1, 20);
			blueChannelBuffer = new ComputeBuffer(1, 20);
			isInitialized = false;
		}

		private void OnDestroy()
		{
			if (uv0Buffer != null)
			{
				uv0Buffer.Release();
			}
			if (commandBuffer != null)
			{
				commandBuffer.Release();
			}
			if (resultBuffer != null)
			{
				resultBuffer.Release();
				resultBuffer = null;
			}
			if (redChannelBuffer != null)
			{
				redChannelBuffer.Release();
			}
			if (greenChannelBuffer != null)
			{
				greenChannelBuffer.Release();
			}
			if (blueChannelBuffer != null)
			{
				blueChannelBuffer.Release();
			}
			if (resultRenderTexture != null)
			{
				resultRenderTexture.Release();
				resultRenderTexture = null;
			}
		}

		private void InitializeResources(Texture2D maskTexture)
		{
			if (!isInitialized || !(resultRenderTexture != null) || resultRenderTexture.width != maskTexture.width || resultRenderTexture.height != maskTexture.height)
			{
				if (resultRenderTexture != null)
				{
					resultRenderTexture.Release();
				}
				resultRenderTexture = new RenderTexture(maskTexture.width, maskTexture.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
				resultRenderTexture.enableRandomWrite = true;
				resultRenderTexture.Create();
				if (resultTexture == null || resultTexture.width != maskTexture.width || resultTexture.height != maskTexture.height)
				{
					resultTexture = new Texture2D(maskTexture.width, maskTexture.height, TextureFormat.RGBA32, mipChain: false);
				}
				if (resultBuffer != null)
				{
					resultBuffer.Release();
				}
				resultBuffer = new ComputeBuffer(maskTexture.width * maskTexture.height, 4);
				if (resultData == null || resultData.Length != maskTexture.width * maskTexture.height)
				{
					resultData = new Color32[maskTexture.width * maskTexture.height];
				}
				isInitialized = true;
			}
		}

		private void Execute()
		{
			if (preset == null)
			{
				return;
			}
			Texture2D workTexture = textureMaskHolder.WorkTexture;
			List<Vector2> attachedUV = textureMaskHolder.AttachedUV0;
			InitializeResources(workTexture);
			InitUVBuffer(attachedUV);
			commandBuffer.Clear();
			commandBuffer.SetComputeBufferParam(computeShader, computeShaderKernel, UVCoordsParam, uv0Buffer);
			commandBuffer.SetComputeTextureParam(computeShader, computeShaderKernel, TextureMaskParam, workTexture);
			commandBuffer.SetComputeTextureParam(computeShader, computeShaderKernel, ResultTextureParam, resultRenderTexture);
			SetChannelBuffer(redChannelBuffer, preset.RedChannel, RedChannelParam);
			SetChannelBuffer(greenChannelBuffer, preset.GreenChannel, GreenChannelParam);
			SetChannelBuffer(blueChannelBuffer, preset.BlueChannel, BlueChannelParam);
			float val = (setRandomSeed ? randomSeed : UnityEngine.Random.value);
			commandBuffer.SetComputeFloatParam(computeShader, RandomSeedParam, val);
			computeShader.GetKernelThreadGroupSizes(computeShaderKernel, out var x, out var y, out var _);
			int threadGroupsX = Mathf.CeilToInt((float)workTexture.width / (float)x);
			int threadGroupsY = Mathf.CeilToInt((float)workTexture.height / (float)y);
			commandBuffer.DispatchCompute(computeShader, computeShaderKernel, threadGroupsX, threadGroupsY, 1);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = resultRenderTexture;
			resultTexture.ReadPixels(new Rect(0f, 0f, resultRenderTexture.width, resultRenderTexture.height), 0, 0);
			resultTexture.Apply();
			RenderTexture.active = active;
			throw new NotImplementedException();
		}

		private void InitUVBuffer(List<Vector2> uvCoords)
		{
			if (uv0Buffer == null || uv0Buffer.count != uvCoords.Count)
			{
				if (uv0Buffer != null)
				{
					uv0Buffer.Release();
				}
				uv0Buffer = new ComputeBuffer(Mathf.Max(1, uvCoords.Count), 8);
				if (uvBufferData == null || uvBufferData.Length != uvCoords.Count * 2)
				{
					uvBufferData = new float[uvCoords.Count * 2];
				}
			}
			for (int i = 0; i < uvCoords.Count; i++)
			{
				uvBufferData[i * 2] = uvCoords[i].x;
				uvBufferData[i * 2 + 1] = uvCoords[i].y;
			}
			uv0Buffer.SetData(uvBufferData);
		}

		private void SetChannelBuffer(ComputeBuffer targetBuffer, ChannelGenerationEntry channelGenerationEntry, int parameterIndex)
		{
			colorChannelBufferData[0] = channelGenerationEntry.NoiseScale;
			colorChannelBufferData[1] = channelGenerationEntry.MinColorValueClamp;
			colorChannelBufferData[2] = channelGenerationEntry.MaxColorValueClamp;
			colorChannelBufferData[3] = channelGenerationEntry.MinEdgeSmoothStepValue;
			colorChannelBufferData[4] = channelGenerationEntry.MaxEdgeSmoothStepValue;
			targetBuffer.SetData(colorChannelBufferData);
			commandBuffer.SetComputeBufferParam(computeShader, computeShaderKernel, parameterIndex, targetBuffer);
		}
	}
}
