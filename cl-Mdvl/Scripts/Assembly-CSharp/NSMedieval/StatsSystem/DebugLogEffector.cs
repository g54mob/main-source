using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class DebugLogEffector : EffectorBase
	{
		private string name;

		public DebugLogEffector(StatEffector parent)
			: base(EffectorType.DebugEffect, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (data.ContainsKey("name"))
			{
				name = data["name"];
			}
		}

		public override void Start(StatsInstance instance)
		{
			Log.Debug("STARTED " + name, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\DebugLogEffector.cs");
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
			Log.Debug("STACKED " + name + " MULT: " + multiplier, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\DebugLogEffector.cs");
		}

		public override void End(StatsInstance instance)
		{
			Log.Debug("ENDED " + name, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\DebugLogEffector.cs");
		}
	}
}
