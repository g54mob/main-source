using System.Collections.Generic;

public class CrusaderShieldGoals : LostItemGoals
{
	private int totalDurationDecay;

	public static CrusaderShieldGoals singleton { get; private set; }

	public override List<string> GetTexts()
	{
		List<string> texts = base.GetTexts();
		texts.Add(Te.xt("tid_info_crusader_1").Trim());
		texts.Add(Te.xt("tid_info_crusader_2").Trim());
		texts.Add(Te.xt("tid_info_crusader_3").Trim());
		texts.Add(Te.xt("tid_info_crusader_4").Trim());
		texts.Add(Te.xt("tid_info_crusader_5").Trim());
		texts.Add(Te.xt("tid_info_crusader_6").Trim());
		FormatProgressThresholds(texts);
		return texts;
	}

	public override void SetGoal(int newGoal)
	{
		switch (base.goal.GetValue())
		{
		case 1:
			StatModController.OnDebuffAdded -= HandleDebuffAdded;
			break;
		case 4:
			Character.OnCharacterWasHealed -= HandleCharacterHealed;
			break;
		default:
			if (newGoal != 5 && newGoal == 6)
			{
				StatModController.OnCleanse -= HandleCleanse;
			}
			break;
		case 2:
		case 3:
			break;
		}
		base.SetGoal(newGoal);
		switch (newGoal)
		{
		case 1:
			StatModController.OnDebuffAdded += HandleDebuffAdded;
			break;
		case 4:
			Character.OnCharacterWasHealed += HandleCharacterHealed;
			break;
		case 6:
			StatModController.OnCleanse += HandleCleanse;
			break;
		}
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod newbuff)
	{
		if (newbuff.id == "sanctity")
		{
			ImproveProgress();
		}
	}

	public void ReportDebuffExpired(int remainingDuration)
	{
		if (base.goal.GetValue() == 2 && remainingDuration <= 0)
		{
			ImproveProgress();
		}
	}

	public void ReportDebuffDecay()
	{
		if (base.goal.GetValue() == 3)
		{
			totalDurationDecay++;
			if (totalDurationDecay >= 30)
			{
				totalDurationDecay -= 30;
				ImproveProgress();
			}
		}
	}

	private void HandleCharacterHealed(Character c, Damage heal)
	{
		if (c == GameStates.Singleton.hero && heal.tags.Contains("crusader_shield"))
		{
			ImproveProgress(heal.amount);
		}
	}

	public void ReportPurePreventedDebuff(DebuffStatMod debuff)
	{
		if (base.goal.GetValue() == 5)
		{
			ImproveProgress();
		}
	}

	private void HandleCleanse(Character c, StatModifier debuff)
	{
		if (debuff.id == "pure")
		{
			ImproveProgress();
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
