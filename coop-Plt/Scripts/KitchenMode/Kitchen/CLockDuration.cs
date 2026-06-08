using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CLockDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
	}
}
