using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	public struct CProgressionOption : IComponentData
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Selected : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Displayed : IComponentData
		{
		}

		public int ID;

		public bool FromFranchise;
	}
}
