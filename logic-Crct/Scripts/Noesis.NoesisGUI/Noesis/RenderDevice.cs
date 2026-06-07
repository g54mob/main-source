using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public abstract class RenderDevice : BaseComponent
	{
		private delegate void Callback_GetCaps(IntPtr cPtr, ref DeviceCaps caps);

		private delegate IntPtr Callback_CreateRenderTarget(IntPtr cPtr, string label, uint width, uint height, uint sampleCount, bool needsStencil);

		private delegate IntPtr Callback_CloneRenderTarget(IntPtr cPtr, string label, IntPtr surface);

		private delegate void Callback_SetRenderTarget(IntPtr cPtr, IntPtr surface);

		private delegate void Callback_ResolveRenderTarget(IntPtr cPtr, IntPtr surface, [In] Tile[] tiles, int numTiles);

		private delegate IntPtr Callback_CreateTexture(IntPtr cPtr, string label, uint width, uint height, uint numLevels, int format, IntPtr data);

		private delegate void Callback_UpdateTexture(IntPtr cPtr, IntPtr texPtr, uint level, uint x, uint y, uint width, uint height, IntPtr data);

		private delegate void Callback_BeginOffscreenRender(IntPtr cPtr);

		private delegate void Callback_EndOffscreenRender(IntPtr cPtr);

		private delegate void Callback_BeginOnscreenRender(IntPtr cPtr);

		private delegate void Callback_EndOnscreenRender(IntPtr cPtr);

		private delegate IntPtr Callback_MapVertices(IntPtr cPtr, uint bytes);

		private delegate void Callback_UnmapVertices(IntPtr cPtr);

		private delegate IntPtr Callback_MapIndices(IntPtr cPtr, uint bytes);

		private delegate void Callback_UnmapIndices(IntPtr cPtr);

		private delegate void Callback_DrawBatch(IntPtr cPtr, [In] ref Batch batch);

		private static Callback_GetCaps _getCaps;

		private static Callback_CreateRenderTarget _createRenderTarget;

		private static Callback_CloneRenderTarget _cloneRenderTarget;

		private static Callback_SetRenderTarget _setRenderTarget;

		private static Callback_ResolveRenderTarget _resolveRenderTarget;

		private static Callback_CreateTexture _createTexture;

		private static Callback_UpdateTexture _updateTexture;

		private static Callback_BeginOffscreenRender _beginOffscreenRender;

		private static Callback_EndOffscreenRender _endOffscreenRender;

		private static Callback_BeginOnscreenRender _beginOnscreenRender;

		private static Callback_EndOnscreenRender _endOnscreenRender;

		private static Callback_MapVertices _mapVertices;

		private static Callback_UnmapVertices _unmapVertices;

		private static Callback_MapIndices _mapIndices;

		private static Callback_UnmapIndices _unmapIndices;

		private static Callback_DrawBatch _drawBatch;

		public uint OffscreenWidth
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint OffscreenHeight
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint OffscreenSampleCount
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint OffscreenDefaultNumSurfaces
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint OffscreenMaxNumSurfaces
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint GlyphCacheWidth
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint GlyphCacheHeight
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public abstract DeviceCaps Caps { get; }

		public abstract RenderTarget CreateRenderTarget(string label, uint width, uint height, uint sampleCount, bool needsStencil);

		public abstract RenderTarget CloneRenderTarget(string label, RenderTarget surface);

		public abstract void SetRenderTarget(RenderTarget surface);

		public abstract void ResolveRenderTarget(RenderTarget surface, Tile[] tiles);

		public abstract Texture CreateTexture(string label, uint width, uint height, uint numLevels, TextureFormat format, IntPtr data);

		public abstract void UpdateTexture(Texture texture, uint level, uint x, uint y, uint width, uint height, IntPtr data);

		public abstract void BeginOffscreenRender();

		public abstract void EndOffscreenRender();

		public abstract void BeginOnscreenRender();

		public abstract void EndOnscreenRender();

		public abstract IntPtr MapVertices(uint bytes);

		public abstract void UnmapVertices();

		public abstract IntPtr MapIndices(uint bytes);

		public abstract void UnmapIndices();

		public abstract void DrawBatch(ref Batch batch);

		static RenderDevice()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		protected RenderDevice()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal RenderDevice(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetCaps))]
		private static void GetCaps(IntPtr cPtr, ref DeviceCaps caps)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_CreateRenderTarget))]
		private static IntPtr CreateRenderTarget(IntPtr cPtr, string label, uint width, uint height, uint sampleCount, bool needsStencil)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_CloneRenderTarget))]
		private static IntPtr CloneRenderTarget(IntPtr cPtr, string label, IntPtr surfacePtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_SetRenderTarget))]
		private static void SetRenderTarget(IntPtr cPtr, IntPtr surfacePtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_ResolveRenderTarget))]
		private static void ResolveRenderTarget(IntPtr cPtr, IntPtr surfacePtr, Tile[] tiles, int numTiles)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_CreateTexture))]
		private static IntPtr CreateTexture(IntPtr cPtr, string label, uint width, uint height, uint numLevels, int format, IntPtr data)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_UpdateTexture))]
		private static void UpdateTexture(IntPtr cPtr, IntPtr texPtr, uint level, uint x, uint y, uint width, uint height, IntPtr data)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_BeginOffscreenRender))]
		private static void BeginOffscreenRender(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_EndOffscreenRender))]
		private static void EndOffscreenRender(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_BeginOnscreenRender))]
		private static void BeginOnscreenRender(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_EndOnscreenRender))]
		private static void EndOnscreenRender(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_MapVertices))]
		private static IntPtr MapVertices(IntPtr cPtr, uint bytes)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_UnmapVertices))]
		private static void UnmapVertices(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_MapIndices))]
		private static IntPtr MapIndices(IntPtr cPtr, uint bytes)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_UnmapIndices))]
		private static void UnmapIndices(IntPtr cPtr)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_DrawBatch))]
		private static void DrawBatch(IntPtr cPtr, ref Batch batch)
		{
		}

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_SetCallbacks(Callback_GetCaps getCaps, Callback_CreateRenderTarget createRenderTarget, Callback_CloneRenderTarget cloneRenderTarget, Callback_SetRenderTarget setRenderTarget, Callback_ResolveRenderTarget resolveRenderTarget, Callback_CreateTexture createTexture, Callback_UpdateTexture updateTexture, Callback_BeginOffscreenRender beginOffscreenRender, Callback_EndOffscreenRender endOffscreenRender, Callback_BeginOnscreenRender beginOnscreenRender, Callback_EndOnscreenRender endOnscreenRender, Callback_MapVertices mapVertices, Callback_UnmapVertices unmapVertices, Callback_MapIndices mapIndices, Callback_UnmapIndices unmapIndices, Callback_DrawBatch drawBatch);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetOffscreenWidth(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetOffscreenWidth(HandleRef device, uint w);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetOffscreenHeight(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetOffscreenHeight(HandleRef device, uint h);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetOffscreenSampleCount(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetOffscreenSampleCount(HandleRef device, uint c);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetOffscreenDefaultNumSurfaces(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetOffscreenDefaultNumSurfaces(HandleRef device, uint n);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetOffscreenMaxNumSurfaces(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetOffscreenMaxNumSurfaces(HandleRef device, uint n);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetGlyphCacheWidth(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetGlyphCacheWidth(HandleRef device, uint w);

		[PreserveSig]
		private static extern uint Noesis_RenderDevice_GetGlyphCacheHeight(HandleRef device);

		[PreserveSig]
		private static extern void Noesis_RenderDevice_SetGlyphCacheHeight(HandleRef device, uint w);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDevice_Extend(IntPtr typeName);
	}
}
