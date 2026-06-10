using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class MoodModifyEffect : EffectorBase
	{
		private float baseValue;

		private string description;

		private List<AttributeType> attributes;

		public MoodModifyEffect(StatEffector parent)
			: base(EffectorType.MoodModify, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.TryGetValue("BaseValue", out var value))
			{
				return;
			}
			baseValue = float.Parse(value, CultureInfo.InvariantCulture);
			foreach (KeyValuePair<string, string> datum in data)
			{
				if (!datum.Key.Contains("Attribute"))
				{
					continue;
				}
				if (attributes == null)
				{
					attributes = new List<AttributeType>();
				}
				if (!datum.Value.TryParseEnumNameOrInt<AttributeType>(out var parsedEnumValue))
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\MoodModifyEffect.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Failed to parse attribute enum '");
						messageBuilder.AppendFormatted(value);
						messageBuilder.AppendLiteral("'");
					}
					Log.Error(messageBuilder);
				}
				attributes.Add(parsedEnumValue);
			}
			if (!data.TryGetValue("Description", out value))
			{
				description = base.Parent.GetID();
			}
			else
			{
				description = value;
			}
		}

		public override void Start(StatsInstance instance)
		{
			instance.AddAttributeModifier(new MoodBasicModifierInstance(this, base.Parent.GetID()));
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
			instance.GetModifierInstanceStack(ModifierType.MoodBasic)?.GetByTag(base.Parent.GetID())?.SetStackMultiplier(multiplier);
		}

		public override void End(StatsInstance instance)
		{
			instance.RemoveAttributeModifier(ModifierType.MoodBasic, base.Parent.GetID());
		}

		internal float GetBaseValue()
		{
			return baseValue;
		}

		internal string GetDescription()
		{
			return description;
		}

		internal List<AttributeType> GetAttributes()
		{
			return attributes;
		}
	}
}
