using System.Runtime.InteropServices;
using Unity.Entities;

namespace EnvironmentEvents.Components
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TriggerEnvironmentEventOnDeathCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
