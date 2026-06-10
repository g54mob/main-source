using System;
using System.Collections.Generic;
using System.Globalization;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.UI.Utils
{
	public static class AttributeUtils
	{
		public static IEnumerable<AttributeLocalized> GetAllLocalized(HumanoidInstance humanoidInstance)
		{
			List<AttributeLocalized> list = new List<AttributeLocalized>();
			foreach (AttributeInstance value in humanoidInstance.Stats.Attributes.Values)
			{
				if ((!humanoidInstance.IsNpc() || !value.Blueprint.HideInUiNpc) && (humanoidInstance.IsNpc() || !value.Blueprint.HideInUiSettler))
				{
					AttributeLocalized attributeLocalized = GetAttributeLocalized(value);
					if (!string.IsNullOrEmpty(attributeLocalized.LocalizedName))
					{
						list.Add(attributeLocalized);
					}
				}
			}
			return list;
		}

		public static IEnumerable<AttributeLocalized> GetAllLocalized(AnimalInstance animalInstance)
		{
			List<AttributeLocalized> list = new List<AttributeLocalized>();
			if (animalInstance == null || animalInstance.HasDisposed)
			{
				return list;
			}
			foreach (AttributeInstance value in animalInstance.Stats.Attributes.Values)
			{
				if (!value.Blueprint.HideInUiAnimal)
				{
					AttributeLocalized attributeLocalized = GetAttributeLocalized(value);
					if (attributeLocalized.LocalizedName != null)
					{
						list.Add(attributeLocalized);
					}
				}
			}
			return list;
		}

		public static AttributeLocalized GetAttributeLocalized(AttributeInstance instance)
		{
			return new AttributeLocalized
			{
				Attribute = instance,
				LocalizedName = GetLocalizedAttributeName(instance),
				LocalizedDescription = GetLocalizedAttributeDescription(instance),
				LocalizedBaseValue = GetLocalizedAttributeBaseValue(instance),
				LocalizedValue = GetLocalizedAttributeValue(instance),
				Group = instance.Blueprint.Group
			};
		}

		public static string GetLocalizedAttributeDescription(AttributeInstance instance)
		{
			if (instance.Blueprint.LocKeys != null)
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetInfo(instance.Blueprint.LocKeys));
			}
			return string.Empty;
		}

		public static string GetLocalizedAttributeModifier(AttributeInstance instance, float value)
		{
			return GetLocalizedAttributeModifier(instance.Blueprint, value);
		}

		public static string GetLocalizedAttributeModifier(NSMedieval.StatsSystem.Attribute blueprint, float value)
		{
			float val = (value - 1f) * 100f;
			float num = Round(ref val);
			return UiUtils.FormatPositiveNegative(string.Format("{0}{1}", num, UiUtils.Localize.GetText("unit_suffix_percent")), val, 0f, blueprint.PositiveIsNegative) ?? "";
		}

		public static string GetLocalizedAttributeGroup(AttributeGroup group)
		{
			return UiUtils.Localize.GetText($"attribute_group_{group}");
		}

		public static string GetLocalizedAttributeBaseValue(AttributeInstance instance)
		{
			float val = instance.Blueprint.Value;
			if (instance.Blueprint.ValueMultiplier != 0f)
			{
				val *= instance.Blueprint.ValueMultiplier;
			}
			return $"{Round(ref val)}{UiUtils.Localize.GetText(instance.Blueprint.ValueSuffix)}";
		}

		public static string GetLocalizedAttributeValue(AttributeInstance instance)
		{
			float val = instance.Value;
			if (instance.Blueprint.ValueMultiplier != 0f)
			{
				val *= instance.Blueprint.ValueMultiplier;
			}
			return Round(ref val).ToString(CultureInfo.InvariantCulture) + UiUtils.Localize.GetText(instance.Blueprint.ValueSuffix);
		}

		public static string GetLocalizedAttributeValue(NSMedieval.StatsSystem.Attribute blueprint, float value)
		{
			if (blueprint.ValueMultiplier != 0f)
			{
				value *= blueprint.ValueMultiplier;
			}
			return $"{Round(ref value)}{UiUtils.Localize.GetText(blueprint.ValueSuffix)}";
		}

		private static float Round(ref float val)
		{
			return val = (float)Math.Round(val, 2);
		}

		public static string GetLocalizedAttributeName(AttributeInstance instance)
		{
			return GetLocalizedAttributeName(instance.Blueprint);
		}

		public static string GetLocalizedAttributeName(NSMedieval.StatsSystem.Attribute attribute)
		{
			if (attribute.LocKeys != null)
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetName(attribute.LocKeys));
			}
			return string.Empty;
		}
	}
}
