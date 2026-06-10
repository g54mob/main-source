using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class AttributeModifyEffect : EffectorBase
	{
		private AttributeType attribute;

		private float multiplier;

		private bool isNegativeStacking;

		public AttributeModifyEffect(StatEffector parent)
			: base(EffectorType.AttributeModify, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.TryGetValue("Attribute", out var value))
			{
				return;
			}
			if (!value.TryParseEnumNameOrInt<AttributeType>(out attribute))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\AttributeModifyEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse attribute enum '");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			if (data.TryGetValue("Multiplier", out value))
			{
				multiplier = float.Parse(value, CultureInfo.InvariantCulture);
				if (data.TryGetValue("NegativeStacking", out value))
				{
					isNegativeStacking = bool.Parse(value);
				}
				else
				{
					isNegativeStacking = false;
				}
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.AddAttributeModifier(new CustomAttributeModifierInstance(attribute, multiplier, base.Parent.GetID(), isNegativeStacking));
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
			if (!instance.HasDisposed)
			{
				instance.GetModifierInstanceStack(ModifierType.CustomAttribute)?.GetByTag(base.Parent.GetID()).SetStackMultiplier(multiplier);
			}
		}

		public override void End(StatsInstance instance)
		{
			if (instance != null && !instance.HasDisposed)
			{
				instance.RemoveAttributeModifier(ModifierType.CustomAttribute, base.Parent?.GetID());
			}
		}
	}
}
