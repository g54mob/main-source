using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class StatEnableDisableEffect : EffectorBase
	{
		private bool isDisabled;

		private StatType statType;

		public StatEnableDisableEffect(StatEffector parent)
			: base(EffectorType.DisableStat, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.TryGetValue("statType", out var value) || !data.TryGetValue("isDisabled", out var value2))
			{
				return;
			}
			if (!value.TryParseEnumNameOrInt<StatType>(out statType))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\StatEnableDisableEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse StatType enum '");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			isDisabled = bool.Parse(value2);
		}

		public override void Start(StatsInstance instance)
		{
			instance.GetStat(statType)?.SetDisabled(isDisabled);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			instance.GetStat(statType)?.SetDisabled(!isDisabled);
		}
	}
}
