using System;
using System.Collections.Generic;

namespace Restory.Gameplay.Soldering
{
	[Serializable]
	public class BurntTraceData
	{
		public List<SolderPointData> SolderPoints { get; set; } = new List<SolderPointData>();
	}
}
