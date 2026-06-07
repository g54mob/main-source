using System;

namespace ShellFileDialogs
{
	[Flags]
	internal enum ShellFolderEnumerationOptions : ushort
	{
		CheckingForChildren = 0x10,
		Folders = 0x20,
		NonFolders = 0x40,
		IncludeHidden = 0x80,
		InitializeOnFirstNext = 0x100,
		NetPrinterSearch = 0x200,
		Shareable = 0x400,
		Storage = 0x800,
		NavigationEnum = 0x1000,
		FastItems = 0x2000,
		FlatList = 0x4000,
		EnableAsync = 0x8000
	}
}
