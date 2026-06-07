using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	public class OutlineJFAInitPass : ScriptableRenderPass
	{
		private Material _jumpMaterial;

		private Dictionary<EOutline, Material> _compositeMaterials;

		private static readonly int RTCollection = Shader.PropertyToID("_OutlineCollection");

		private static readonly int RTWrite = Shader.PropertyToID("_OutlineRenderTextureWrite");

		private static readonly int RTRead = Shader.PropertyToID("_OutlineRenderTextureRead");

		private static readonly int RTGrab = Shader.PropertyToID("_ScreenGrab");

		private static readonly int SHStep = Shader.PropertyToID("_Step");

		private static readonly int SHPower = Shader.PropertyToID("_Power");

		private static readonly int SHColorPower = Shader.PropertyToID("_ColorPower");

		private static readonly int SHSmoothness = Shader.PropertyToID("_Smoothness");

		private static readonly int SHColor = Shader.PropertyToID("_Color");

		private static readonly int SHColorEdge = Shader.PropertyToID("_ColorEdge");

		private static readonly int SHRatio = Shader.PropertyToID("_ScreenRatio");

		public OutlineJFAInitPass()
		{
			_jumpMaterial = CoreUtils.CreateEngineMaterial(Resources.Load<Shader>("Outline/SH_JFAInit"));
			_compositeMaterials = new Dictionary<EOutline, Material>();
			EOutline[] array = (EOutline[])Enum.GetValues(typeof(EOutline));
			foreach (EOutline key in array)
			{
				_compositeMaterials.Add(key, CoreUtils.CreateEngineMaterial(Resources.Load<Shader>("Outline/SH_Outline")));
			}
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (!MonoSingleton<Outlines>.InstanceExists())
			{
				return;
			}
			Shader.SetGlobalFloat(SHRatio, 1f / (float)renderingData.cameraData.camera.pixelWidth / (1f / (float)renderingData.cameraData.camera.pixelHeight));
			foreach (var (eOutline2, outlineData2) in MonoSingleton<Outlines>.Instance.Data)
			{
				if (outlineData2 == null || outlineData2.Renderers.Count <= 0 || !outlineData2.Enabled)
				{
					continue;
				}
				CommandBuffer commandBuffer = CommandBufferPool.Get($"Jump Flood Outline: {eOutline2}");
				RenderTextureDescriptor desc = new RenderTextureDescriptor(renderingData.cameraData.camera.pixelWidth, renderingData.cameraData.camera.pixelHeight, GraphicsFormat.R16G16_SNorm, 24, 0);
				commandBuffer.GetTemporaryRT(RTCollection, desc);
				commandBuffer.SetRenderTarget(RTCollection);
				commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, new Color(-1f, -1f, 0f));
				foreach (Renderer renderer in outlineData2.Renderers)
				{
					if ((bool)renderer && renderer.enabled && renderer.gameObject.activeInHierarchy)
					{
						for (int i = 0; i < renderer.sharedMaterials.Length; i++)
						{
							commandBuffer.DrawRenderer(renderer, _jumpMaterial, i, 0);
						}
					}
				}
				commandBuffer.GetTemporaryRT(RTRead, desc);
				commandBuffer.GetTemporaryRT(RTWrite, desc);
				int num = Mathf.RoundToInt(outlineData2.PixelRadius * (float)renderingData.cameraData.camera.pixelHeight);
				int num2 = Mathf.NextPowerOfTwo(num + 1) >> 1;
				commandBuffer.CopyTexture(RTCollection, RTRead);
				int num3 = RTWrite;
				while (num2 > 0)
				{
					commandBuffer.SetGlobalFloat(SHStep, num2);
					if (num3 == RTWrite)
					{
						commandBuffer.Blit(RTRead, RTWrite, _jumpMaterial, 1);
						num3 = RTRead;
					}
					else
					{
						commandBuffer.Blit(RTWrite, RTRead, _jumpMaterial, 1);
						num3 = RTWrite;
					}
					num2 >>= 1;
				}
				commandBuffer.SetGlobalTexture(RTWrite, (num3 == RTWrite) ? RTRead : RTWrite);
				commandBuffer.GetTemporaryRT(RTGrab, renderingData.cameraData.cameraTargetDescriptor);
				commandBuffer.Blit(renderingData.cameraData.renderer.cameraColorTarget, RTGrab);
				_compositeMaterials[eOutline2].SetFloat(SHStep, num);
				_compositeMaterials[eOutline2].SetColor(SHColor, outlineData2.Color);
				_compositeMaterials[eOutline2].SetColor(SHColorEdge, outlineData2.ColorEdge);
				_compositeMaterials[eOutline2].SetFloat(SHPower, outlineData2.Power);
				_compositeMaterials[eOutline2].SetFloat(SHColorPower, outlineData2.ColorPower);
				_compositeMaterials[eOutline2].SetFloat(SHSmoothness, outlineData2.Smoothness);
				commandBuffer.Blit(RTGrab, renderingData.cameraData.renderer.cameraColorTarget, _compositeMaterials[eOutline2]);
				commandBuffer.ReleaseTemporaryRT(RTWrite);
				commandBuffer.ReleaseTemporaryRT(RTRead);
				commandBuffer.ReleaseTemporaryRT(RTCollection);
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}
	}
}
