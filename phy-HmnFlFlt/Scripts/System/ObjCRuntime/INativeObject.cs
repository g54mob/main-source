using System;

namespace ObjCRuntime
{
	internal interface INativeObject
	{
		IntPtr Handle { get; }
	}
}
