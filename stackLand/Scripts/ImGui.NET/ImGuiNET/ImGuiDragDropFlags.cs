using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiDragDropFlags
	{
		None = 0,
		SourceNoPreviewTooltip = 1,
		SourceNoDisableHover = 2,
		SourceNoHoldToOpenOthers = 4,
		SourceAllowNullID = 8,
		SourceExtern = 0x10,
		SourceAutoExpirePayload = 0x20,
		AcceptBeforeDelivery = 0x400,
		AcceptNoDrawDefaultRect = 0x800,
		AcceptNoPreviewTooltip = 0x1000,
		AcceptPeekOnly = 0xC00
	}
}
