using System;
using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ReadyToTraverseOffMeshLink : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
