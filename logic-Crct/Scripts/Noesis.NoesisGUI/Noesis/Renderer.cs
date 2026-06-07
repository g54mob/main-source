using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Renderer : BaseComponent
	{
		private HandleRef CPtr => default(HandleRef);

		public void Init(RenderDevice device)
		{
		}

		public void Shutdown()
		{
		}

		public void SetRenderRegion(float x, float y, float width, float height)
		{
		}

		public bool UpdateRenderTree()
		{
			return false;
		}

		public bool RenderOffscreen()
		{
			return false;
		}

		public void Render(bool flipY = false, bool clear = false)
		{
		}

		internal Renderer(IntPtr cPtr, bool ownMemory)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static Renderer CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		[PreserveSig]
		private static extern void Noesis_Renderer_Init(HandleRef renderer, HandleRef device);

		[PreserveSig]
		private static extern void Noesis_Renderer_Shutdown(HandleRef renderer);

		[PreserveSig]
		private static extern void Noesis_Renderer_SetRenderRegion(HandleRef renderer, float x, float y, float width, float height);

		[PreserveSig]
		private static extern bool Noesis_Renderer_UpdateRenderTree(HandleRef renderer);

		[PreserveSig]
		private static extern bool Noesis_Renderer_RenderOffscreen(HandleRef renderer);

		[PreserveSig]
		private static extern void Noesis_Renderer_Render(HandleRef renderer, bool flipY, bool clear);
	}
}
