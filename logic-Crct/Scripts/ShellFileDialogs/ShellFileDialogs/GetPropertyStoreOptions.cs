using System;

namespace ShellFileDialogs
{
	[Flags]
	internal enum GetPropertyStoreOptions
	{
		Default = 0,
		HandlePropertiesOnly = 1,
		ReadWrite = 2,
		Temporary = 4,
		FastPropertiesOnly = 8,
		OpensLowItem = 0x10,
		DelayCreation = 0x20,
		BestEffort = 0x40,
		MaskValid = 0xFF
	}
}
