using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace WaveHarmonic.Crest
{
	internal sealed class UnderwaterEffectPassURP : ScriptableRenderPass
	{
		private const string k_Name = "Crest.DrawWater/Volume";

		private UnderwaterRenderer _Renderer;

		internal static UnderwaterEffectPassURP s_Instance;

		private UnderwaterEffectPass _UnderwaterEffectPass;

		private CopyDepthBufferPassURP _CopyDepthBufferPass;

		private RTHandle _ColorBuffer;

		private RTHandle _DepthBuffer;

		private bool _ErrorMissingColorTarget;

		private readonly RenderGraphHelper.PassData _PassData = new RenderGraphHelper.PassData();

		public UnderwaterEffectPassURP()
		{
			ConfigureInput(ScriptableRenderPassInput.Depth | ScriptableRenderPassInput.Color);
		}

		public static void Enable(UnderwaterRenderer renderer)
		{
			if (s_Instance == null)
			{
				s_Instance = new UnderwaterEffectPassURP();
				s_Instance._Renderer = renderer;
				s_Instance._CopyDepthBufferPass = new CopyDepthBufferPassURP(RenderPassEvent.AfterRenderingOpaques);
			}
			RenderPipelineManager.activeRenderPipelineTypeChanged -= Disable;
			RenderPipelineManager.activeRenderPipelineTypeChanged += Disable;
		}

		public static void Disable()
		{
			RenderPipelineManager.activeRenderPipelineTypeChanged -= Disable;
			s_Instance?._UnderwaterEffectPass?.Release();
			s_Instance?._CopyDepthBufferPass?.Release();
			s_Instance = null;
		}

		internal void EnqueuePass(ScriptableRenderContext context, Camera camera)
		{
			if (_Renderer._Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.Volume))
			{
				s_Instance.renderPassEvent = (_Renderer.RenderBeforeTransparency ? RenderPassEvent.BeforeRenderingTransparents : RenderPassEvent.AfterRenderingTransparents);
				ScriptableRenderer scriptableRenderer = camera.GetUniversalAdditionalCameraData().scriptableRenderer;
				if (_Renderer.UseStencilBuffer)
				{
					scriptableRenderer.EnqueuePass(_CopyDepthBufferPass);
				}
				if (_UnderwaterEffectPass == null)
				{
					_UnderwaterEffectPass = new UnderwaterEffectPass(_Renderer);
				}
				scriptableRenderer.EnqueuePass(s_Instance);
			}
		}

		private void OnSetup(CommandBuffer buffer, RenderGraphHelper.PassData data)
		{
			_ColorBuffer = data.colorTargetHandle.Texture;
			_DepthBuffer = data.depthTargetHandle.Texture;
			if (_ColorBuffer?.rt == null)
			{
				if (!_ErrorMissingColorTarget)
				{
					Debug.LogError("Crest: Your current URP setup has a Unity bug which prevents underwater from rendering on this camera (" + data.cameraData.camera.name + "). It is too complicated for us to advise which combination of settings are the issue (sorry), but they will be on either the URP asset or renderer file.");
					_ErrorMissingColorTarget = true;
				}
			}
			else
			{
				_UnderwaterEffectPass.ReAllocate(_ColorBuffer.rt.descriptor);
			}
		}

		private void Execute(ScriptableRenderContext context, CommandBuffer buffer, RenderGraphHelper.PassData data)
		{
			if (!(_ColorBuffer?.rt == null))
			{
				if (_Renderer.UseStencilBuffer)
				{
					_DepthBuffer = _CopyDepthBufferPass._DepthBufferCopy;
				}
				_UnderwaterEffectPass.Execute(data.cameraData.camera, buffer, _ColorBuffer, _DepthBuffer);
			}
		}

		public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
		{
			RenderGraphHelper.PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = graph.AddUnsafePass<RenderGraphHelper.PassData>("Crest.DrawWater/Volume", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Volume\\UnderwaterEffectPassURP.RenderGraph.cs", 19);
			passData.Init(frame, unsafeRenderGraphBuilder);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(RenderGraphHelper.PassData data, UnsafeGraphContext context)
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				OnSetup(nativeCommandBuffer, data);
				Execute(context.GetRenderContext(), nativeCommandBuffer, data);
			});
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer buffer, ref RenderingData data)
		{
			_PassData.Init(data.GetFrameData());
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData data)
		{
			_PassData.Init(data.GetFrameData());
			CommandBuffer commandBuffer = CommandBufferPool.Get("Crest.DrawWater/Volume");
			OnSetup(commandBuffer, _PassData);
			Execute(context, commandBuffer, _PassData);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
