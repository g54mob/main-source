using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class StatLockUnlockEffect : EffectorBase
	{
		private bool isLocked;

		private StatType statType;

		public StatLockUnlockEffect(StatEffector parent)
			: base(EffectorType.DisableStat, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.TryGetValue("statType", out var value) || !data.TryGetValue("isLocked", out var value2))
			{
				return;
			}
			if (!value.TryParseEnumNameOrInt<StatType>(out statType))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\StatLockUnlockEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse StatType enum '");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			isLocked = bool.Parse(value2);
		}

		public override void Start(StatsInstance instance)
		{
			instance.GetStat(statType)?.SetLocked(isLocked);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			instance.GetStat(statType)?.SetLocked(!isLocked);
		}
	}
}
