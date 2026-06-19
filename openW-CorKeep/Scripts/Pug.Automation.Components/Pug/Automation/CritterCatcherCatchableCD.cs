using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pug.Automation
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CritterCatcherCatchableCD : IComponentData, IQueryTypeParameter
	{
	}
}
