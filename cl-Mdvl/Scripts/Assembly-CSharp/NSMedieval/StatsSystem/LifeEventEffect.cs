using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class LifeEventEffect : EffectorBase
	{
		private Dictionary<string, string> parameters;

		public LifeEventEffect(StatEffector parent)
			: base(EffectorType.LifeEvent, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			parameters = data;
		}

		public override void Start(StatsInstance instance)
		{
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				HandleParameterStart(instance, parameter.Key, parameter.Value);
			}
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				HandleParameterEnd(instance, parameter.Key, parameter.Value);
			}
		}

		private void HandleParameterStart(StatsInstance instance, string key, string value)
		{
			if (!(key == "DieFromStarvation"))
			{
				if (key == "StartStarving")
				{
					MonoSingleton<LifeController>.Instance.Starving(instance, isStarted: true);
				}
				else
				{
					Log.Error("Invalid life event key " + key, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\LifeEventEffect.cs");
				}
			}
			else
			{
				MonoSingleton<LifeController>.Instance.DieFromStarvation(instance);
			}
		}

		private void HandleParameterEnd(StatsInstance instance, string key, string value)
		{
			if (!(key == "DieFromStarvation"))
			{
				if (key == "StartStarving")
				{
					MonoSingleton<LifeController>.Instance.Starving(instance, isStarted: false);
				}
				else
				{
					Log.Error("Invalid life event key " + key, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\LifeEventEffect.cs");
				}
			}
		}
	}
}
