using System;
using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CObfuscateProgressIndicator : IComponentData
	{
	}
}
