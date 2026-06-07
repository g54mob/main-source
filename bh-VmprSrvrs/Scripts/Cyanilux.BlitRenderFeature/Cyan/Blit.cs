using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Cyan
{
	public class Blit : ScriptableRendererFeature
	{
		public class BlitPass : ScriptableRenderPass
		{
			private BlitSettings settings;

			private RTHandle source;

			private RTHandle destination;

			private RTHandle temp;

			private RTHandle srcTextureObject;

			private RTHandle dstTextureId;

			private RTHandle dstTextureObject;

			private string m_ProfilerTag;

			public Material blitMaterial
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public BlitPass(RenderPassEvent renderPassEvent, BlitSettings settings, string tag)
			{
			}

			public void Setup(ScriptableRenderer renderer)
			{
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public override void OnCameraCleanup(CommandBuffer cmd)
			{
			}

			public void Dispose()
			{
			}
		}

		[Serializable]
		public class BlitSettings
		{
			public RenderPassEvent Event;

			public Material blitMaterial;

			public int blitMaterialPassIndex;

			public bool setInverseViewMatrix;

			public bool requireDepthNormals;

			public Target srcType;

			public RenderTexture srcTextureObject;

			public Target dstType;

			public string dstTextureId;

			public RenderTexture dstTextureObject;

			public bool overrideGraphicsFormat;

			public GraphicsFormat graphicsFormat;

			public bool canShowInSceneView;
		}

		public enum Target
		{
			CameraColor = 0,
			TextureID = 1,
			RenderTextureObject = 2
		}

		public BlitSettings settings;

		public BlitPass blitPass;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
