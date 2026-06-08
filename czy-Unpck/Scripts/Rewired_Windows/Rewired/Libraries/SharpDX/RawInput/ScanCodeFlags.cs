using System;

namespace Rewired.Libraries.SharpDX.RawInput
{
	[Flags]
	[CustomObfuscation(rename = false)]
	internal enum ScanCodeFlags : short
	{
		[CustomObfuscation(rename = false)]
		Make = 0,
		[CustomObfuscation(rename = false)]
		Break = 1,
		[CustomObfuscation(rename = false)]
		E0 = 2,
		[CustomObfuscation(rename = false)]
		E1 = 4
	}
}
