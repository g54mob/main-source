using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;

namespace VampireSurvivors.App.Data
{
	[Serializable]
	public class StageSetData
	{
		public StageSetType Type { get; set; }

		public Dictionary<StageType, List<StageData>> Data { get; set; }
	}
}
