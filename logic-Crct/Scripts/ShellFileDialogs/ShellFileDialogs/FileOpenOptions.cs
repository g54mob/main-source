using System;

namespace ShellFileDialogs
{
	[Flags]
	internal enum FileOpenOptions
	{
		None = 0,
		OverwritePrompt = 2,
		StrictFileTypes = 4,
		NoChangeDirectory = 8,
		PickFolders = 0x20,
		ForceFilesystem = 0x40,
		AllNonStorageItems = 0x80,
		NoValidate = 0x100,
		AllowMultiSelect = 0x200,
		PathMustExist = 0x800,
		FileMustExist = 0x1000,
		CreatePrompt = 0x2000,
		ShareAware = 0x4000,
		NoReadOnlyReturn = 0x8000,
		NoTestFileCreate = 0x10000,
		HideMruPlaces = 0x20000,
		HidePinnedPlaces = 0x40000,
		NoDereferenceLinks = 0x100000,
		DontAddToRecent = 0x2000000,
		ForceShowHidden = 0x10000000,
		DefaultNoMiniMode = 0x20000000
	}
}
