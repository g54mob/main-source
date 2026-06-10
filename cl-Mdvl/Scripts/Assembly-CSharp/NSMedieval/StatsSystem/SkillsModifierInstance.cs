using FoxyVoxel.Logging;
using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public class SkillsModifierInstance : ModifierInstance
	{
		public SkillsModifierInstance()
			: base(ModifierType.Skills)
		{
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			if (!(instance.Owner is HumanoidInstance))
			{
				Log.Error("Owner is not HumanoidInstance type!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Modifiers\\SkillsModifierInstance.cs");
				return;
			}
			foreach (AttributeInstance value in instance.Attributes.Values)
			{
				if (value.Blueprint.HasSkillModifiers())
				{
					base.AffectedAttributes.Add(value);
				}
			}
		}

		public override void Apply()
		{
			foreach (AttributeInstance affectedAttribute in base.AffectedAttributes)
			{
				SkillType[] modifierSkillTypes = affectedAttribute.Blueprint.ModifierSkillTypes;
				foreach (SkillType skillType in modifierSkillTypes)
				{
					float levelModifier = affectedAttribute.Blueprint.GetLevelModifier(skillType, GetSkillLevel(skillType));
					if (!(levelModifier < 0f))
					{
						affectedAttribute.SetMultiplier(affectedAttribute.Multiplier * levelModifier);
					}
				}
			}
		}

		public override bool IsHidden()
		{
			return true;
		}

		private WorkerSkills GetSkills()
		{
			if (base.Owner.Owner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				return humanoidInstance.Skills;
			}
			if (!(base.Owner.Owner is HumanoidInstance humanoidInstance2) || !humanoidInstance2.IsNpc())
			{
				return null;
			}
			return humanoidInstance2.Skills;
		}

		private int GetSkillLevel(SkillType type)
		{
			return (GetSkills()?.GetSkill(type)?.Level).GetValueOrDefault();
		}
	}
}
