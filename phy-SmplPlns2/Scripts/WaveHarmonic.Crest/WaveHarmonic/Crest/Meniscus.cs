using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class Meniscus : Versioned
	{
		internal abstract class MeniscusRenderer
		{
			private protected const string k_Draw = "Crest.DrawWater/Meniscus";

			private protected readonly WaterRenderer _Water;

			internal readonly Meniscus _Meniscus;

			public abstract void OnBeginCameraRendering(Camera camera);

			public abstract void OnEndCameraRendering(Camera camera);

			public MeniscusRenderer(WaterRenderer water, Meniscus meniscus)
			{
				_Water = water;
				_Meniscus = meniscus;
			}

			public virtual void Enable()
			{
			}

			public virtual void Disable()
			{
			}

			public virtual void Destroy()
			{
			}

			internal bool ShouldExecute(Camera camera)
			{
				if (_Meniscus.ForceRenderingOff)
				{
					return false;
				}
				if (!WaterRenderer.ShouldRender(camera, _Meniscus.Layer, _Meniscus._CameraExclusions))
				{
					return false;
				}
				if (!_Water._ActiveModules.HasFlag(WaterRenderer.ActiveModules.SurfaceAndVolume))
				{
					return false;
				}
				_Water.UpdatePerCameraHeight(camera);
				float viewerHeightAboveWaterPerCamera = _Water._ViewerHeightAboveWaterPerCamera;
				if (viewerHeightAboveWaterPerCamera > 2f || viewerHeightAboveWaterPerCamera < -8f)
				{
					return false;
				}
				return true;
			}

			internal void Execute<T>(Camera camera, T commands) where T : ICommandWrapper
			{
				bool flag = false;
				int num = 1;
				if (true)
				{
					int num2 = (flag ? 1 : 0);
					MaterialPropertyBlock block = _Water.Surface._SurfaceDataMPB;
					if (_Water._Underwater.UseLegacyMask)
					{
						num2 += num;
						block = null;
					}
					commands.DrawFullScreenTriangle(_Meniscus.Material, num2, block);
				}
			}
		}

		internal sealed class MeniscusRendererBIRP : MeniscusRenderer
		{
			private CommandBuffer _Commands;

			private bool _CommandsRegistered;

			public MeniscusRendererBIRP(WaterRenderer water, Meniscus meniscus)
				: base(water, meniscus)
			{
			}

			public override void OnBeginCameraRendering(Camera camera)
			{
				if (ShouldExecute(camera))
				{
					if (_Commands == null)
					{
						_Commands = new CommandBuffer
						{
							name = "Crest.DrawWater/Meniscus"
						};
					}
					_Commands.Clear();
					Execute(camera, new CommandWrapper(_Commands));
					camera.AddCommandBuffer(CameraEvent.AfterForwardAlpha, _Commands);
					_CommandsRegistered = true;
				}
			}

			public override void OnEndCameraRendering(Camera camera)
			{
				if (_CommandsRegistered)
				{
					camera.RemoveCommandBuffer(CameraEvent.AfterForwardAlpha, _Commands);
					_CommandsRegistered = false;
				}
			}
		}

		internal sealed class MeniscusRendererURP : MeniscusRenderer
		{
			private sealed class MeniscusRenderPass : ScriptableRenderPass
			{
				private class PassData
				{
					public UniversalCameraData _CameraData;

					public MeniscusRenderer _Renderer;
				}

				private const string k_Name = "Crest.DrawWater/Meniscus";

				internal MeniscusRenderer _Renderer;

				private bool _RequiresOpaqueTexture;

				public MeniscusRenderPass()
				{
					base.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
				}

				internal void EnqueuePass(Camera camera)
				{
					ScriptableRenderer scriptableRenderer = camera.GetUniversalAdditionalCameraData().scriptableRenderer;
					_RequiresOpaqueTexture = _Renderer._Meniscus.RequiresOpaqueTexture;
					ConfigureInput(_RequiresOpaqueTexture ? ScriptableRenderPassInput.Color : ScriptableRenderPassInput.None);
					scriptableRenderer.EnqueuePass(this);
				}

				public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
				{
					PassData passData;
					using IRasterRenderGraphBuilder rasterRenderGraphBuilder = graph.AddRasterRenderPass<PassData>("Crest.DrawWater/Meniscus", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Meniscus\\Meniscus.Universal.cs", 81);
					rasterRenderGraphBuilder.AllowPassCulling(value: false);
					UniversalResourceData universalResourceData = frame.Get<UniversalResourceData>();
					if (_RequiresOpaqueTexture)
					{
						rasterRenderGraphBuilder.UseTexture(universalResourceData.cameraOpaqueTexture);
					}
					passData._CameraData = frame.Get<UniversalCameraData>();
					passData._Renderer = _Renderer;
					rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
					rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
					{
						data._Renderer.Execute(data._CameraData.camera, new RasterCommandWrapper(context.cmd));
					});
				}

				[Obsolete]
				public override void Execute(ScriptableRenderContext context, ref RenderingData data)
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get("Crest.DrawWater/Meniscus");
					_Renderer.Execute(data.cameraData.camera, new CommandWrapper(commandBuffer));
					context.ExecuteCommandBuffer(commandBuffer);
					CommandBufferPool.Release(commandBuffer);
				}
			}

			private readonly MeniscusRenderPass _MaskRenderPass = new MeniscusRenderPass();

			public MeniscusRendererURP(WaterRenderer water, Meniscus meniscus)
				: base(water, meniscus)
			{
			}

			public override void OnBeginCameraRendering(Camera camera)
			{
				if (ShouldExecute(camera))
				{
					_MaskRenderPass._Renderer = this;
					_MaskRenderPass.EnqueuePass(camera);
				}
			}

			public override void OnEndCameraRendering(Camera camera)
			{
			}
		}

		[Tooltip("Whether the meniscus is enabled.")]
		[SerializeField]
		internal bool _Enabled = true;

		[Tooltip("Any camera with this layer in its culling mask will render the meniscus.")]
		[SerializeField]
		private int _Layer = 4;

		[Tooltip("The meniscus material.")]
		[SerializeField]
		internal Material _Material;

		[Tooltip("Rules to exclude cameras from rendering the meniscus.\n\nThese are exclusion rules, so for all cameras, select Nothing. These rules are applied on top of the Layer rules.")]
		[SerializeField]
		private WaterCameraExclusion _CameraExclusions = WaterCameraExclusion.Hidden | WaterCameraExclusion.Reflection;

		private WaterRenderer _Water;

		public WaterCameraExclusion CameraExclusions
		{
			get
			{
				return _CameraExclusions;
			}
			set
			{
				_CameraExclusions = value;
			}
		}

		public bool Enabled
		{
			get
			{
				return GetEnabled();
			}
			set
			{
				SetEnabled(_Enabled, _Enabled = value);
			}
		}

		public int Layer
		{
			get
			{
				return _Layer;
			}
			set
			{
				_Layer = value;
			}
		}

		public Material Material
		{
			get
			{
				return _Material;
			}
			set
			{
				SetMaterial(_Material, _Material = value);
			}
		}

		internal MeniscusRenderer Renderer { get; private set; }

		internal bool RequiresOpaqueTexture
		{
			get
			{
				if (Enabled && Material != null)
				{
					return Material.IsKeywordEnabled("d_Crest_Refraction");
				}
				return false;
			}
		}

		public bool ForceRenderingOff { get; set; }

		internal void Enable()
		{
			Initialize(_Water);
			Renderer?.Enable();
		}

		internal void Disable()
		{
			Renderer?.Disable();
		}

		internal void Destroy()
		{
			Renderer?.Destroy();
			Renderer = null;
		}

		internal void OnActiveRenderPipelineTypeChanged()
		{
			Destroy();
			Initialize(_Water);
		}

		internal void Initialize(WaterRenderer water)
		{
			_Water = water;
			if (!Enabled)
			{
				return;
			}
			if (RenderPipelineHelper.IsUniversal)
			{
				if (Renderer == null)
				{
					MeniscusRenderer meniscusRenderer = (Renderer = new MeniscusRendererURP(water, this));
				}
			}
			else if (Renderer == null)
			{
				MeniscusRenderer meniscusRenderer = (Renderer = new MeniscusRendererBIRP(water, this));
			}
		}

		internal bool ShouldRender(Camera camera)
		{
			if (!Enabled)
			{
				return false;
			}
			return Renderer.ShouldExecute(camera);
		}

		private bool GetEnabled()
		{
			if (_Enabled)
			{
				return _Material != null;
			}
			return false;
		}

		private void SetEnabled(bool previous, bool current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled)
			{
				if (_Enabled)
				{
					Enable();
				}
				else
				{
					Disable();
				}
			}
		}

		private void SetMaterial(Material previous, Material current)
		{
			if (!(previous == current) && !(_Water == null) && _Water.isActiveAndEnabled)
			{
				if (previous == null)
				{
					Enable();
				}
				else if (current == null)
				{
					Disable();
				}
			}
		}
	}
}
