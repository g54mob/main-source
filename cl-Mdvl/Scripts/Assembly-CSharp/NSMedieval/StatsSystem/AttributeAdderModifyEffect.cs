using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class AttributeAdderModifyEffect : EffectorBase
	{
		private AttributeType attribute;

		private float value;

		public AttributeAdderModifyEffect(StatEffector parent)
			: base(EffectorType.AttributeAdderModify, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.TryGetValue("Attribute", out var text))
			{
				return;
			}
			if (!text.TryParseEnumNameOrInt<AttributeType>(out attribute))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\AttributeAdderModifyEffect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to parse attribute enum '");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			if (data.TryGetValue("Value", out text))
			{
				value = float.Parse(text, CultureInfo.InvariantCulture);
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.AddAttributeModifier(new CustomAttributeAdderModifierInstance(attribute, value, base.Parent.GetID()));
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
			instance.GetModifierInstanceStack(ModifierType.CustomAttribute)?.GetByTag(base.Parent.GetID()).SetStackMultiplier(multiplier);
		}

		public override void End(StatsInstance instance)
		{
			instance.RemoveAttributeModifier(ModifierType.CustomAttributeAdder, base.Parent.GetID());
		}
	}
}
