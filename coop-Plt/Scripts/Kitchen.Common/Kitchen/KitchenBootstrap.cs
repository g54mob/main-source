using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct KitchenBootstrap : ICustomBootstrap
	{
		public bool Initialize(string defaultWorldName)
		{
			World.DefaultGameObjectInjectionWorld = new World(defaultWorldName);
			return true;
		}
	}
}
