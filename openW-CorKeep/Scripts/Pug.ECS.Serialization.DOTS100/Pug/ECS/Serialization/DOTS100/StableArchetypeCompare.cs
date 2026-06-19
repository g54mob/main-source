using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pug.ECS.Serialization.DOTS100
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct StableArchetypeCompare : IComparer<IntPtr>
	{
		public unsafe int Compare(IntPtr x, IntPtr y)
		{
			ulong stableHash = ((Archetype*)(void*)x)->StableHash;
			ulong stableHash2 = ((Archetype*)(void*)y)->StableHash;
			return stableHash.CompareTo(stableHash2);
		}
	}
}
