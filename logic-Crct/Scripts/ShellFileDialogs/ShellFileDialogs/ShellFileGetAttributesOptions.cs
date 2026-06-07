using System;

namespace ShellFileDialogs
{
	[Flags]
	internal enum ShellFileGetAttributesOptions
	{
		CanCopy = 1,
		CanMove = 2,
		CanLink = 4,
		Storage = 8,
		CanRename = 0x10,
		CanDelete = 0x20,
		HasPropertySheet = 0x40,
		DropTarget = 0x100,
		CapabilityMask = 0x177,
		System = 0x1000,
		Encrypted = 0x2000,
		IsSlow = 0x4000,
		Ghosted = 0x8000,
		Link = 0x10000,
		Share = 0x20000,
		ReadOnly = 0x40000,
		Hidden = 0x80000,
		DisplayAttributeMask = 0xFC000,
		FileSystemAncestor = 0x10000000,
		Folder = 0x20000000,
		FileSystem = 0x40000000,
		HasSubFolder = int.MinValue,
		ContentsMask = int.MinValue,
		Validate = 0x1000000,
		Removable = 0x2000000,
		Compressed = 0x4000000,
		Browsable = 0x8000000,
		Nonenumerated = 0x100000,
		NewContent = 0x200000,
		CanMoniker = 0x400000,
		HasStorage = 0x400000,
		Stream = 0x400000,
		StorageAncestor = 0x800000,
		StorageCapabilityMask = 0x70C50008,
		PkeyMask = -2130427904
	}
}
