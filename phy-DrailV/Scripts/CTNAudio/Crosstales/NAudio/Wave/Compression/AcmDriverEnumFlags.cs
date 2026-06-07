using System;

namespace Crosstales.NAudio.Wave.Compression
{
	[Flags]
	internal enum AcmDriverEnumFlags
	{
		NoLocal = 0x40000000,
		Disabled = int.MinValue
	}
}
