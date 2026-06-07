using System.Runtime.InteropServices;
using Unity.Entities;

namespace DV.ECS.Components
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CopyTransformFromGameObjectLateUpdate : IComponentData
	{
	}
}
