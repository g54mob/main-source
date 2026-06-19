using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffRank
	{
		public const int MaxLevels = 5;

		[SerializeField]
		private readonly LocalisedString TitleLocalised;

		[SerializeField]
		private readonly LocalisedString TitleLocalisedFemale;

		public readonly float MaximumXP;

		public readonly float SalaryMin;

		public readonly float SalaryMax;

		public readonly float SalaryPremiumMultiplier = 1f;

		public readonly float Prestige = 1f;

		public readonly float WalkSpeedMultiplier = 1f;

		public readonly float DiagnosisCertaintyMultiplier = 1f;

		public readonly int FurtherDiagnosisChoiceCount = 1;

		public readonly float TreatmentSkillRating = 1f;

		public readonly float TrainingMultiplier = 1f;

		public readonly float TraineeLearningSpeed = 1f;

		public readonly float HappinessModifier = 1f;

		public readonly float ResearchRate = 1f;

		public readonly float MarketingSkill = 1f;

		public readonly float UpgradeItemSkill = 1f;

		public readonly float MaintenanceSkill = 1f;

		public readonly float ServiceSkill = 1f;

		public const float DurationReduction = 0f;

		public LocalisedString GetTitleLocalised(Character.Sex sex)
		{
			if (sex != Character.Sex.Male)
			{
				return TitleLocalisedFemale;
			}
			return TitleLocalised;
		}

		public int GetSalary(float xp)
		{
			return (int)Mathf.Lerp(Mathf.Max(SalaryMin, 1f), SalaryMax, Mathf.Clamp01(xp / MaximumXP));
		}

		public static string GetBenefitsText(StaffRank rank, StaffRank nextRank)
		{
			string text = ScriptLocalization.Staff.Rank_Benefit_TrainingSlot_CS + "\n";
			float num = nextRank.WalkSpeedMultiplier - rank.WalkSpeedMultiplier;
			if (num > 0f)
			{
				text += ScriptLocalization.Staff.Rank_Benefit_MovementSpeed_CS.Replace("{[SPEED]}", StringUtils.FormatPercentageValue(num, prefixPlus: true));
				text += "\n";
			}
			float num2 = nextRank.DiagnosisCertaintyMultiplier - rank.DiagnosisCertaintyMultiplier;
			if (num2 > 0f)
			{
				text += ScriptLocalization.Staff.Rank_Benefit_DiagnosisSkill_CS.Replace("{[SKILL]}", StringUtils.FormatPercentageValue(num2, prefixPlus: true));
				text += "\n";
			}
			float num3 = nextRank.TreatmentSkillRating - rank.TreatmentSkillRating;
			if (num3 > 0f)
			{
				text += ScriptLocalization.Staff.Rank_Benefit_TreatmentSkill_CS.Replace("{[SKILL]}", StringUtils.FormatPercentageValue(num3, prefixPlus: true));
				text += "\n";
			}
			float num4 = nextRank.MarketingSkill - rank.MarketingSkill;
			if (num4 > 0f)
			{
				text += ScriptLocalization.Staff.Rank_Benefit_MarketingSkill_CS.Replace("{[SKILL]}", StringUtils.FormatPercentageValue(num4, prefixPlus: true));
				text += "\n";
			}
			float num5 = nextRank.UpgradeItemSkill - rank.UpgradeItemSkill;
			if (num5 > 0f)
			{
				text += ScriptLocalization.Staff.Rank_Benefit_UpgradeSkill_CS.Replace("{[SKILL]}", StringUtils.FormatPercentageValue(num5, prefixPlus: true));
				text += "\n";
			}
			float num6 = nextRank.MaintenanceSkill - rank.MaintenanceSkill;
			if (num6 > 0f)
			{
				text += ScriptLocalization.Staff.Rank_Benefit_MaintenanceSkill_CS.Replace("{[SKILL]}", StringUtils.FormatPercentageValue(num6, prefixPlus: true));
				text += "\n";
			}
			return text;
		}
	}
}
