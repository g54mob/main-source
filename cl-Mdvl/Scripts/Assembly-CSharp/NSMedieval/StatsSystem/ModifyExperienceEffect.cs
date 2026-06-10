using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Tools.Math;

namespace NSMedieval.StatsSystem
{
	public class ModifyExperienceEffect : EffectorBase
	{
		private float min;

		private float max;

		private SkillType skillType;

		public override bool DontRestartAfterDeserialization => true;

		public ModifyExperienceEffect(StatEffector parent)
			: base(EffectorType.ModifyExperience, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (data.TryGetValue("min", out var value))
			{
				min = float.Parse(value, CultureInfo.InvariantCulture);
			}
			if (data.TryGetValue("max", out var value2))
			{
				max = float.Parse(value2, CultureInfo.InvariantCulture);
			}
			if (data.TryGetValue("skillType", out var value3) && !value3.TryParseEnumNameOrInt<SkillType>(out skillType))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\ModifyExperienceEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse SkillType enum '");
					messageBuilder.AppendFormatted(value3);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.OwnerHumanoidInstance?.AddExperience(skillType, Random.Range(min, max));
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
		}
	}
}
