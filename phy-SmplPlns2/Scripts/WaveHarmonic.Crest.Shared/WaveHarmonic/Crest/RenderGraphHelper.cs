using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace WaveHarmonic.Crest
{
	internal static class RenderGraphHelper
	{
		public struct Handle
		{
			private RTHandle _RTHandle;

			private TextureHandle _TextureHandle;

			public readonly RTHandle Texture
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return _RTHandle ?? ((RTHandle)_TextureHandle);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator Handle(RTHandle handle)
			{
				return new Handle
				{
					_RTHandle = handle
				};
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator Handle(TextureHandle handle)
			{
				return new Handle
				{
					_TextureHandle = handle
				};
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator RTHandle(Handle texture)
			{
				return texture.Texture;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator TextureHandle(Handle texture)
			{
				return texture._TextureHandle;
			}
		}

		internal class PassData
		{
			public UniversalCameraData cameraData;

			public UniversalRenderingData renderingData;

			public Handle colorTargetHandle;

			public Handle depthTargetHandle;

			public void Init(ContextContainer frameData, IUnsafeRenderGraphBuilder builder = null)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				cameraData = frameData.Get<UniversalCameraData>();
				renderingData = frameData.Get<UniversalRenderingData>();
				if (builder == null)
				{
					colorTargetHandle = cameraData.renderer.cameraColorTargetHandle;
					depthTargetHandle = cameraData.renderer.cameraDepthTargetHandle;
					return;
				}
				colorTargetHandle = universalResourceData.activeColorTexture;
				depthTargetHandle = universalResourceData.activeDepthTexture;
				builder.UseTexture((TextureHandle)colorTargetHandle, AccessFlags.ReadWrite);
				builder.UseTexture((TextureHandle)depthTargetHandle, AccessFlags.ReadWrite);
			}
		}

		private static readonly FieldInfo s_WrappedContext = typeof(UnsafeGraphContext).GetField("wrappedContext", BindingFlags.Instance | BindingFlags.NonPublic);

		public static ScriptableRenderContext GetRenderContext(this UnsafeGraphContext unsafeContext)
		{
			return ((InternalRenderGraphContext)s_WrappedContext.GetValue(unsafeContext)).renderContext;
		}

		public static ContextContainer GetFrameData(this ref RenderingData renderingData)
		{
			return renderingData.frameData;
		}
	}
}
