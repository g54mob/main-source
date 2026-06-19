using System.Runtime.InteropServices;
using Unity.Entities;

namespace Interaction
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct IsClosestLocalInteractableCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
