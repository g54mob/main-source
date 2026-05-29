using System;
using System.Collections.Generic;
using Placemaker.Modules;

namespace Placemaker
{
	[Serializable]
	public class BaseModule
	{
		public short cost;

		public List<ushort> profileIndexes;

		public List<OrientedModule> orientedModuleMeshes;

		public List<PropPlacement> propPlacements;
	}
}
