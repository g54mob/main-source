using System;
using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class StatModifyCurrentEffect : EffectorBase
	{
		private float amount;

		private float min;

		private float max;

		private StatType stat;

		private static readonly Random Random = new Random();

		public override bool DontRestartAfterDeserialization => true;

		public float Amount => amount;

		public StatModifyCurrentEffect(StatEffector parent)
			: base(EffectorType.StatModifyCurrent, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (data.TryGetValue("amountMin", out var value))
			{
				min = float.Parse(value, CultureInfo.InvariantCulture);
			}
			if (data.TryGetValue("amountMax", out var value2))
			{
				max = float.Parse(value2, CultureInfo.InvariantCulture);
			}
			if (data.TryGetValue("stat", out var value3) && !value3.TryParseEnumNameOrInt<StatType>(out stat))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\StatModifyCurrentEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse StatType '");
					messageBuilder.AppendFormatted(value3);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
		}

		public override void Start(StatsInstance instance)
		{
			AddRandomAmount(instance);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
			AddRandomAmount(instance);
		}

		public override void End(StatsInstance instance)
		{
		}

		private void AddRandomAmount(StatsInstance instance)
		{
			amount = (float)Random.NextDouble() * (max - min) + min;
			instance.GetStat(stat)?.AddCurrent(amount);
		}
	}
}
