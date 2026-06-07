using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class NativeRenderDevice : RenderDevice
	{
		protected class ManagedTexture
		{
			internal object Texture;
		}

		public override DeviceCaps Caps => default(DeviceCaps);

		public override RenderTarget CreateRenderTarget(string label, uint width, uint height, uint sampleCount, bool needsStencil)
		{
			return null;
		}

		public override RenderTarget CloneRenderTarget(string label, RenderTarget surface)
		{
			return null;
		}

		public override void SetRenderTarget(RenderTarget surface)
		{
		}

		public override void ResolveRenderTarget(RenderTarget surface, Tile[] tiles)
		{
		}

		public override Texture CreateTexture(string label, uint width, uint height, uint numLevels, TextureFormat format, IntPtr data)
		{
			return null;
		}

		public override void UpdateTexture(Texture texture, uint level, uint x, uint y, uint width, uint height, IntPtr data)
		{
		}

		public override void BeginOffscreenRender()
		{
		}

		public override void EndOffscreenRender()
		{
		}

		public override void BeginOnscreenRender()
		{
		}

		public override void EndOnscreenRender()
		{
		}

		public override IntPtr MapVertices(uint bytes)
		{
			return (IntPtr)0;
		}

		public override void UnmapVertices()
		{
		}

		public override IntPtr MapIndices(uint bytes)
		{
			return (IntPtr)0;
		}

		public override void UnmapIndices()
		{
		}

		public override void DrawBatch(ref Batch batch)
		{
		}

		internal new static NativeRenderDevice CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal NativeRenderDevice(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		protected static Texture WrapTexture(object texture, IntPtr texPtr)
		{
			return null;
		}

		[PreserveSig]
		private static extern void Noesis_RenderDevice_GetCaps(HandleRef device, ref DeviceCaps caps);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDevice_CreateRenderTarget(HandleRef device, string label, uint width, uint height, uint sampleCount, bool needsStencil);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDevice_CloneRenderTarget(HandleRef device, HandleRef surface);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetRenderTarget(HandleRef device, HandleRef surface);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_ResolveRenderTarget(HandleRef device, HandleRef surface, [In][Out] Tile[] tiles, int numTiles);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDevice_CreateTexture(HandleRef device, string label, uint width, uint height, uint numLevels, int format, IntPtr data);

		[PreserveSig]
		public static extern void Noesis_RenderDevice_UpdateTexture(HandleRef device, HandleRef texture, uint level, uint x, uint y, uint width, uint height, IntPtr data);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_BeginOffscreenRender(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_EndOffscreenRender(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_BeginOnscreenRender(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_EndOnscreenRender(HandleRef device);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDevice_MapVertices(HandleRef device, uint bytes);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_UnmapVertices(HandleRef device);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDevice_MapIndices(HandleRef device, uint bytes);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_UnmapIndices(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_DrawBatch(HandleRef device, ref Batch batch);
	}
}
