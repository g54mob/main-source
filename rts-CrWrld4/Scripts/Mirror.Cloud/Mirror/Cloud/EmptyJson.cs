using System;
using System.Runtime.InteropServices;

namespace Mirror.Cloud
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct EmptyJson : ICanBeJson
	{
	}
}
