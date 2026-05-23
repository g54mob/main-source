using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiBackendFlags
	{
		None = 0,
		HasGamepad = 1,
		HasMouseCursors = 2,
		HasSetMousePos = 4,
		RendererHasVtxOffset = 8,
		PlatformHasViewports = 0x400,
		HasMouseHoveredViewport = 0x800,
		RendererHasViewports = 0x1000
	}
}
