using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class AttributeTooltipView : CreatureBaseTooltipView
	{
		[NonSerialized]
		private StatsInstance stats;

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			stats = GetStats();
			if (stats == null)
			{
				return lines;
			}
			AttributeLocalized attributeLocalized = AttributeUtils.GetAttributeLocalized(stats.Attributes.Values.FirstOrDefault((AttributeInstance att) => att.Blueprint.GetID() == base.KeyId));
			AppendLine(attributeLocalized.LocalizedName, TooltipStyles.TooltipTitle);
			AppendLine(attributeLocalized.LocalizedDescription, TooltipStyles.TooltipDescriptionLine);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("general_base_value") + ": " + attributeLocalized.LocalizedBaseValue, TooltipStyles.TooltipAttribute);
			AppendPerkModifiers(attributeLocalized.Attribute);
			AppendSkillModifiers(attributeLocalized.Attribute);
			AppendEffectorModifiers(attributeLocalized.Attribute);
			AppendEquipmentModifiers(attributeLocalized.Attribute);
			return lines;
		}

		private void AppendEquipmentModifiers(AttributeInstance attribute)
		{
			if (attribute.Type == AttributeType.AgentFlammabilityInternal && !base.Humanoid.HasDisposed && base.Humanoid.Inventory != null)
			{
				foreach (EquipmentInstance equipment in base.Humanoid.Inventory.GetEquipments())
				{
					float agentFlammability = equipment.Blueprint.AgentFlammability;
					if (agentFlammability > 0f && agentFlammability < 1f)
					{
						AppendLine($"{equipment.Blueprint.GetID()}: x {100f * agentFlammability:F1}%", TooltipStyles.TooltipAttribute);
					}
				}
			}
			if (attribute.Type != AttributeType.AgentFireDamageMultiplierInternal || base.Humanoid.HasDisposed || base.Humanoid.Inventory == null)
			{
				return;
			}
			foreach (EquipmentInstance equipment2 in base.Humanoid.Inventory.GetEquipments())
			{
				float agentFireDamageMultiplier = equipment2.Blueprint.AgentFireDamageMultiplier;
				if (agentFireDamageMultiplier > 0f && agentFireDamageMultiplier < 1f)
				{
					AppendLine($"{equipment2.Blueprint.GetID()}: x {100f * agentFireDamageMultiplier:F1}%", TooltipStyles.TooltipAttribute);
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			stats = null;
		}

		private void AppendEffectorModifiers(AttributeInstance attribute)
		{
			if (stats == null)
			{
				return;
			}
			bool flag = false;
			foreach (ActiveEffectorInfo activeEffector in stats.Stats.First().Value.Owner.GetActiveEffectors())
			{
				if (activeEffector.Blueprint == null || activeEffector.Blueprint.Effects == null || activeEffector.Blueprint.UIGroup.Equals(EffectorUiGroup.None))
				{
					continue;
				}
				EffectDetailsHolder[] effects = activeEffector.Blueprint.Effects;
				foreach (EffectDetailsHolder effectDetailsHolder in effects)
				{
					if ((effectDetailsHolder.Type != EffectorType.AttributeModify && effectDetailsHolder.Type != EffectorType.AttributeAdderModify) || !effectDetailsHolder.Parameters.ContainsKey("Attribute"))
					{
						continue;
					}
					string text = ((int)attribute.Type).ToString();
					string text2 = attribute.Type.ToString();
					if (effectDetailsHolder.Parameters["Attribute"] != text && effectDetailsHolder.Parameters["Attribute"] != text2)
					{
						continue;
					}
					string text3 = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(activeEffector.Blueprint.LocKeys));
					if (text3 == string.Empty)
					{
						continue;
					}
					if (effectDetailsHolder.Parameters.ContainsKey("Multiplier") && float.TryParse(effectDetailsHolder.Parameters["Multiplier"], out var result))
					{
						if (activeEffector.WoundInfo != null && activeEffector.Blueprint is StatEffectorWound statEffectorWound)
						{
							float num = activeEffector.WoundInfo.CurrentSeverity / statEffectorWound.Severity;
							float num2 = 1f - result;
							float value = result + num2 - num2 * num;
							text3 = text3 + ": " + AttributeUtils.GetLocalizedAttributeModifier(attribute, value);
						}
						else
						{
							text3 = text3 + ": " + AttributeUtils.GetLocalizedAttributeModifier(attribute, result);
						}
					}
					if (effectDetailsHolder.Parameters.ContainsKey("Value") && float.TryParse(effectDetailsHolder.Parameters["Value"], out var result2))
					{
						text3 = text3 + ": " + AttributeUtils.GetLocalizedAttributeModifier(attribute, result2);
					}
					if (!text3.Equals(string.Empty))
					{
						if (!flag)
						{
							flag = true;
							AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("menu_modifiers"), TooltipStyles.TooltipSubtitleLineStyle);
						}
						AppendLine(text3, TooltipStyles.TooltipAttribute);
					}
				}
			}
		}

		private void AppendSkillModifiers(AttributeInstance attInstance)
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed && attInstance.Blueprint.HasSkillModifiers())
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("menu_skills"), TooltipStyles.TooltipSubtitleLineStyle);
				_ = MonoSingleton<LocalizationController>.Instance;
				NSMedieval.StatsSystem.Attribute.AttributeSkillModifier[] skillModifiers = attInstance.Blueprint.SkillModifiers;
				foreach (NSMedieval.StatsSystem.Attribute.AttributeSkillModifier attributeSkillModifier in skillModifiers)
				{
					int level = base.Humanoid.Skills.GetSkill(attributeSkillModifier.Type).Level;
					SkillValuePair skill = new SkillValuePair(attributeSkillModifier.Type, level);
					AppendLine(TooltipStyles.ApplyStyle(HumanoidUtils.StillNameOptionalValue(skill) + ": " + AttributeUtils.GetLocalizedAttributeModifier(attInstance, attributeSkillModifier.PerLevelModifier[level]), TooltipStyles.TooltipAttribute));
				}
			}
		}

		private void AppendPerkModifiers(AttributeInstance attributeInstance)
		{
			if (base.Humanoid == null)
			{
				return;
			}
			List<Perk> list = base.Humanoid.Perks.FindAll((Perk perk) => perk.AttributeModifiers.FirstOrDefault((AttributeModifierPair modifier) => modifier.Key == attributeInstance.Type && Math.Abs(modifier.Value - 1f) > 0.01f) != null);
			if (list.Count == 0)
			{
				return;
			}
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("menu_perks"), TooltipStyles.TooltipSubtitleLineStyle);
			foreach (Perk item in list)
			{
				foreach (AttributeModifierPair attributeModifier in item.AttributeModifiers)
				{
					if (attributeModifier.Key == attributeInstance.Type)
					{
						AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(item.LocKeys)) + ": " + AttributeUtils.GetLocalizedAttributeModifier(attributeInstance, attributeModifier.Value), TooltipStyles.TooltipAttribute);
					}
				}
			}
		}
	}
}
