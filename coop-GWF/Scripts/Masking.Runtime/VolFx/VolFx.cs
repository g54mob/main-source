using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace VolFx
{
	public static class VolFx
	{
		public abstract class InitApi
		{
			public int Width { get; internal set; }

			public int Height { get; internal set; }

			public abstract void Allocate(RenderTarget rt, int width, int height, GraphicsFormat format, TextureWrapMode wrap = TextureWrapMode.Repeat, FilterMode filter = FilterMode.Bilinear);
		}

		public abstract class CallApi
		{
			public abstract RTHandle CamColor { get; }

			public abstract MaterialPropertyBlock Mat { get; }

			public abstract CameraType CamType { get; }

			public abstract void Blit(RTHandle source, RTHandle dest, Material mat, int pass = 0);

			public abstract void Blit(RTHandle source, RTHandle dest);

			public abstract void EndSample(ProfilingSampler sampler);

			public abstract void BeginSample(ProfilingSampler sampler);
		}

		public class InitApiRg : InitApi
		{
			internal IUnsafeRenderGraphBuilder _builder;

			internal RenderGraph _renderGraph;

			internal ContextContainer _frameData;

			public override void Allocate(RenderTarget rt, int width, int height, GraphicsFormat format, TextureWrapMode wrap = TextureWrapMode.Repeat, FilterMode filter = FilterMode.Bilinear)
			{
				RenderTextureDescriptor descriptor = new RenderTextureDescriptor(width, height, format, GraphicsFormat.None, 0);
				RenderingUtils.ReAllocateHandleIfNeeded(ref rt.Handle, in descriptor, filter, wrap);
				TextureHandle input = _renderGraph.ImportTexture(rt.Handle);
				_builder.UseTexture(in input, AccessFlags.ReadWrite);
			}
		}

		public class CallApiRg : CallApi
		{
			internal static MaterialPropertyBlock _mat = new MaterialPropertyBlock();

			internal UnsafeCommandBuffer _cmd;

			internal Camera _cam;

			public Material _blit;

			internal RTHandle _camColor;

			public override CameraType CamType => _cam.cameraType;

			public override MaterialPropertyBlock Mat => _mat;

			public override RTHandle CamColor => _camColor;

			public override void Blit(RTHandle source, RTHandle dest, Material mat, int pass = 0)
			{
				_mat.SetTexture(Utils.s_MainTexId, source);
				_cmd.SetRenderTarget(dest, 0);
				_cmd.DrawMesh(Utils.FullscreenMesh, Matrix4x4.identity, mat, 0, pass, _mat);
			}

			public override void Blit(RTHandle source, RTHandle dest)
			{
				_mat.SetTexture(Utils.s_MainTexId, source);
				_mat.SetTexture(s_BlitTexture, source);
				_mat.SetVector(s_BlitScaleBias, Vector4.one);
				_cmd.SetRenderTarget(dest, 0);
				_cmd.DrawMesh(Utils.FullscreenMesh, Matrix4x4.identity, _blit, 0, 0, _mat);
			}

			public override void BeginSample(ProfilingSampler sampler)
			{
			}

			public override void EndSample(ProfilingSampler sampler)
			{
			}
		}

		public class InitApiLeg : InitApi
		{
			internal CommandBuffer _cmd;

			public override void Allocate(RenderTarget rt, int width, int height, GraphicsFormat format, TextureWrapMode wrap = TextureWrapMode.Repeat, FilterMode filter = FilterMode.Bilinear)
			{
				RenderTextureDescriptor descriptor = new RenderTextureDescriptor(width, height, format, GraphicsFormat.None, 0);
				RenderingUtils.ReAllocateHandleIfNeeded(ref rt.Handle, in descriptor, filter, wrap);
				_cmd.GetTemporaryRT(rt.Id, width, height, 0, filter, format);
			}
		}

		public class CallApiLeg : CallApi
		{
			internal static MaterialPropertyBlock _mat = new MaterialPropertyBlock();

			internal CommandBuffer _cmd;

			internal Camera _cam;

			public Material _blit;

			internal RTHandle _camColor;

			private ProfilingSampler _sampler;

			public override CameraType CamType => _cam.cameraType;

			public override MaterialPropertyBlock Mat => _mat;

			public override RTHandle CamColor => _camColor;

			public override void Blit(RTHandle source, RTHandle dest, Material mat, int pass = 0)
			{
				_cmd.SetGlobalTexture(Utils.s_MainTexId, source);
				_cmd.SetRenderTarget(dest, 0);
				_cmd.DrawMesh(Utils.FullscreenMesh, Matrix4x4.identity, mat, 0, pass, _mat);
			}

			public override void Blit(RTHandle source, RTHandle dest)
			{
				Blit(source, dest, _blit);
			}

			public override void EndSample(ProfilingSampler sampler)
			{
			}

			public override void BeginSample(ProfilingSampler sampler)
			{
			}
		}

		[Serializable]
		public abstract class Pass : ScriptableObject
		{
			[SerializeField]
			[HideInInspector]
			private Shader _shader;

			protected Material _material;

			private bool _isActive;

			public VolumeStack Stack => VolumeManager.instance.stack;

			protected virtual bool Invert => false;

			protected virtual int MatPass => 0;

			internal bool IsActiveCheck
			{
				get
				{
					if (_isActive)
					{
						return _material != null;
					}
					return false;
				}
				set
				{
					_isActive = value;
				}
			}

			public abstract string ShaderName { get; }

			protected virtual bool _editorValidate => false;

			internal void _init()
			{
				if (_shader != null)
				{
					_material = new Material(_shader);
				}
				Init();
			}

			public virtual void Init(InitApi initApi)
			{
			}

			public virtual void Invoke(RTHandle source, RTHandle dest, CallApi callApi)
			{
				callApi.Blit(source, dest, _material, MatPass);
			}

			public void Validate()
			{
				IsActiveCheck = Validate(_material);
			}

			public virtual void Init()
			{
			}

			public abstract bool Validate(Material mat);

			public virtual void Cleanup(CommandBuffer cmd)
			{
			}

			protected virtual void _editorSetup(string folder, string asset)
			{
			}
		}

		private static readonly int s_BlitTexture = Shader.PropertyToID("_BlitTexture");

		private static readonly int s_BlitScaleBias = Shader.PropertyToID("_BlitScaleBias");
	}
}
