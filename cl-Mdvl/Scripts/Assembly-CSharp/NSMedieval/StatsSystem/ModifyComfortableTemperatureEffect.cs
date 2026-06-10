using System.Collections.Generic;
using System.Globalization;

namespace NSMedieval.StatsSystem
{
	public class ModifyComfortableTemperatureEffect : EffectorBase
	{
		private float min;

		private float max;

		public override bool DontRestartAfterDeserialization => true;

		public ModifyComfortableTemperatureEffect(StatEffector parent)
			: base(EffectorType.ModifyTemperature, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (data.ContainsKey("min"))
			{
				min = float.Parse(data["min"], CultureInfo.InvariantCulture);
			}
			if (data.ContainsKey("max"))
			{
				max = float.Parse(data["max"], CultureInfo.InvariantCulture);
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.OwnerHumanoidInstance?.WarmthInstance?.AddToEffectorMinMaxTemperature(min, max);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
			instance.OwnerHumanoidInstance?.WarmthInstance?.AddToEffectorMinMaxTemperature(min, max);
		}

		public override void End(StatsInstance instance)
		{
			instance.OwnerHumanoidInstance?.WarmthInstance?.AddToEffectorMinMaxTemperature(0f - min, 0f - max);
		}
	}
}
