using System;
using System.Collections.Generic;

namespace GRP
{
	[Serializable]
	public class KitData
	{
		public string key;

		public ExhibitData exhibit;

		public List<KitPartData> parts;

		public List<KitStepData> steps;
	}
}
