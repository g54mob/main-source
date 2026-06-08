using System;
using System.Runtime.InteropServices;
using Unity.Entities;

namespace KitchenData
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CEffectRangeGlobal : IEffectRange, IAttachableProperty, IComponentData
	{
	}
}
