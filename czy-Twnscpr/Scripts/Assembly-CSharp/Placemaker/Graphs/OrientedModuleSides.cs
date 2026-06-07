using System;
using Placemaker.Modules;

namespace Placemaker.Graphs
{
	[Serializable]
	public struct OrientedModuleSides : IComparable<OrientedModuleSides>
	{
		public SideProfile sides;

		public OrientedModule orientedModule;

		public float cost;

		int IComparable<OrientedModuleSides>.CompareTo(OrientedModuleSides other)
		{
			return 0;
		}
	}
}
