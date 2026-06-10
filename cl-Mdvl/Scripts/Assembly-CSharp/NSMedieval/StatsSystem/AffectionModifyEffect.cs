using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public class AffectionModifyEffect : EffectorBase
	{
		private float baseValue;

		private AttributeType attributeType;

		public AffectionModifyEffect(StatEffector parent)
			: base(EffectorType.AffectionModify, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (data.TryGetValue("BaseValue", out var value))
			{
				baseValue = float.Parse(value, CultureInfo.InvariantCulture);
			}
			if (!data.TryGetValue("Attribute_01", out var value2))
			{
				return;
			}
			if (!value2.TryParseEnumNameOrInt<AttributeType>(out var parsedEnumValue))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\AffectionModifyEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse AttributeType '");
					messageBuilder.AppendFormatted(value2);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			if (parsedEnumValue != AttributeType.None)
			{
				attributeType = parsedEnumValue;
			}
		}

		public override void Start(StatsInstance instance)
		{
			if (instance.Owner is HumanoidInstance humanoidInstance && humanoidInstance.Stats.AffectionTarget is HumanoidInstance humanoidInstance2 && humanoidInstance.WorkerBehaviour != null && humanoidInstance2.WorkerBehaviour != null)
			{
				float num = baseValue;
				if (humanoidInstance2.Stats.Attributes.TryGetValue(attributeType, out var value))
				{
					num *= value.Multiplier;
				}
				humanoidInstance.WorkerBehaviour.WorkerSocial.FireAffectionEffector(base.Parent.GetID(), num, humanoidInstance2);
			}
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
		}
	}
}
