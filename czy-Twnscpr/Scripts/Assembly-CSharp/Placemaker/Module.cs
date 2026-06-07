using System;
using System.Collections.Generic;
using Placemaker.Modules;

namespace Placemaker
{
	[Serializable]
	public class Module : BaseModule
	{
		public List<OrientedModule> decorModules;

		public int cornerLinks;
	}
}
