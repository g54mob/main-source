using System.Runtime.InteropServices;
using Unity.Entities;

namespace SiphonMana.Components
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SiphonManaActiveTag : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
