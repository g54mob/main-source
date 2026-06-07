using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace VolFx
{
	[DisallowMultipleRendererFeature("VhsFx")]
	public class VhsFx : ScriptableRendererFeature
	{
		public class PassExecution : ScriptableRenderPass
		{
			public class PassData
			{
				public TextureHandle _camera;

				public TextureHandle _buffer;
			}

			public VhsFx _owner;

			private RenderTarget _output;

			private VolFx.InitApiRg _initApiRg;

			private VolFx.CallApiRg _callApiRg;

			private VolFx.InitApiLeg _initApiLeg;

			private VolFx.CallApiLeg _callApiLeg;

			private ProfilingSampler _profiler;

			public void Init()
			{
				base.renderPassEvent = _owner._event;
				_output = new RenderTarget().Allocate(_owner.name);
				_initApiRg = new VolFx.InitApiRg();
				_callApiRg = new VolFx.CallApiRg();
				_initApiLeg = new VolFx.InitApiLeg();
				_callApiLeg = new VolFx.CallApiLeg();
				_profiler = new ProfilingSampler(_owner.name);
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				ref RenderTextureDescriptor cameraTargetDescriptor = ref universalCameraData.cameraTargetDescriptor;
				int width = cameraTargetDescriptor.width;
				int height = cameraTargetDescriptor.height;
				VolFx.InitApiRg initApiRg = _initApiRg;
				VolFx.CallApiRg callApiRg = _callApiRg;
				initApiRg.Width = width;
				initApiRg.Height = height;
				_owner._pass.Validate();
				if (!_owner._pass.IsActiveCheck)
				{
					return;
				}
				PassData passData;
				using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>(base.passName, out passData, _profiler, "C:\\Users\\Trevo\\OneDrive\\Documents\\BerryBarry_Repo\\Assets\\Vhs\\Runtime\\VhsFx.cs", 114);
				TextureDesc desc = new TextureDesc(cameraTargetDescriptor.width, cameraTargetDescriptor.height);
				desc.format = universalCameraData.cameraTargetDescriptor.graphicsFormat;
				desc.depthBufferBits = DepthBits.None;
				initApiRg._builder = unsafeRenderGraphBuilder;
				initApiRg._frameData = frameData;
				initApiRg._renderGraph = renderGraph;
				_owner._pass.Init(initApiRg);
				callApiRg._cam = universalCameraData.camera;
				callApiRg._blit = _owner._blit;
				callApiRg._cam = universalCameraData.camera;
				passData._camera = universalResourceData.cameraColor;
				passData._buffer = unsafeRenderGraphBuilder.CreateTransientTexture(in desc);
				unsafeRenderGraphBuilder.UseTexture(in passData._buffer, AccessFlags.ReadWrite);
				unsafeRenderGraphBuilder.AllowPassCulling(value: false);
				unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
				{
					Execute(data, context);
				});
			}

			private void Execute(PassData data, UnsafeGraphContext context)
			{
				_ = context.cmd;
				VolFx.CallApiRg callApiRg = _callApiRg;
				callApiRg._cmd = context.cmd;
				_owner._pass.Invoke(data._camera, data._buffer, callApiRg);
				callApiRg.Blit(data._buffer, data._camera);
			}

			[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				_owner._pass.Validate();
				if (_owner._pass.IsActiveCheck)
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get(_owner.name);
					ref CameraData cameraData = ref renderingData.cameraData;
					ref RenderTextureDescriptor cameraTargetDescriptor = ref cameraData.cameraTargetDescriptor;
					_output.Get(commandBuffer, in cameraTargetDescriptor);
					VolFx.InitApiLeg initApiLeg = _initApiLeg;
					VolFx.CallApiLeg callApiLeg = _callApiLeg;
					initApiLeg.Width = cameraData.cameraTargetDescriptor.width;
					initApiLeg.Height = cameraData.cameraTargetDescriptor.height;
					initApiLeg._cmd = commandBuffer;
					callApiLeg._cmd = commandBuffer;
					RTHandle rTHandle = _getCameraTex(ref renderingData);
					_owner._pass.Init(initApiLeg);
					_owner._pass.Invoke(rTHandle, _output.Handle, callApiLeg);
					_owner.Blit(commandBuffer, _output.Handle, rTHandle);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					CommandBufferPool.Release(commandBuffer);
				}
				static RTHandle _getCameraTex(ref RenderingData reference)
				{
					return reference.cameraData.renderer.cameraColorTargetHandle;
				}
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
				_output.Release(cmd);
				_output.Release(cmd);
				_owner._pass.Cleanup(cmd);
			}
		}

		protected static List<ShaderTagId> k_ShaderTags;

		public static int s_BlitTexId = Shader.PropertyToID("_BlitTexture");

		public static int s_BlitScaleBiasId = Shader.PropertyToID("_BlitScaleBias");

		[Tooltip("When to execute")]
		public RenderPassEvent _event = RenderPassEvent.AfterRenderingPostProcessing;

		public VhsPass _pass;

		[HideInInspector]
		public Shader _blitShader;

		[NonSerialized]
		public Material _blit;

		[NonSerialized]
		public PassExecution _execution;

		public void Blit(CommandBuffer cmd, RTHandle source, RTHandle destination)
		{
			cmd.SetGlobalVector(s_BlitScaleBiasId, new Vector4(1f, 1f, 0f));
			cmd.SetGlobalTexture(s_BlitTexId, source);
			cmd.SetRenderTarget(destination, 0);
			cmd.DrawMesh(Utils.FullscreenMesh, Matrix4x4.identity, _blit, 0, 0);
		}

		public override void Create()
		{
			_blit = new Material(_blitShader);
			_execution = new PassExecution
			{
				_owner = this
			};
			_execution.Init();
			if (_pass != null)
			{
				_pass._init();
			}
			if (k_ShaderTags == null)
			{
				k_ShaderTags = new List<ShaderTagId>(new ShaderTagId[3]
				{
					new ShaderTagId("SRPDefaultUnlit"),
					new ShaderTagId("UniversalForward"),
					new ShaderTagId("UniversalForwardOnly")
				});
			}
		}

		private void Reset()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(_execution);
		}

		private void OnDestroy()
		{
		}
	}
}
