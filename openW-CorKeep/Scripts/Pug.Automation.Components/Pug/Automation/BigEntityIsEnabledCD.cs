using System.Runtime.InteropServices;
using Unity.Entities;

namespace Pug.Automation
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BigEntityIsEnabledCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
