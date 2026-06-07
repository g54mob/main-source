using System;
using System.Collections.Generic;

namespace Placemaker.Modules
{
	[Serializable]
	public class CornerLookup
	{
		public ByteQube values;

		public List<OrientedModule> orientedModules;
	}
}
