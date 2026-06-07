using System;

namespace Borodar.FarlandSkies.Core.Games.Collections
{
	[Flags]
	public enum ReorderableListFlags
	{
		DisableReordering = 1,
		HideAddButton = 2,
		HideRemoveButtons = 4,
		DisableContextMenu = 8,
		DisableDuplicateCommand = 0x10,
		DisableAutoFocus = 0x20,
		ShowIndices = 0x40,
		DisableAutoScroll = 0x100,
		ShowSizeField = 0x200
	}
}
