using System.Collections.Generic;

public class EventObjectiveDefeatFoeUsingBuff : EventObjectiveBase
{
	private string foeId;

	private string buffId;

	private bool pointsByDifficulty;

	private List<Character> foesCounted { get; set; }

	public EventObjectiveDefeatFoeUsingBuff(int goal, string buffId, string buffName, string foeId, string foeName, bool pointsByDifficulty = false)
		: base("defeat_with_buff", goal)
	{
		this.foeId = foeId;
		this.buffId = buffId;
		this.pointsByDifficulty = pointsByDifficulty;
		description = string.Format(Te.xt("tid_q_basic_defeat_with_buff"), TranslateIfTID(foeName), TranslateIfTID(buffName));
	}

	public override void Init()
	{
		StatModController.OnDebuffAdded += HandleDebuffAdded;
		Character.OnCharacterDied += HandleCharacterDied;
	}

	public override void End()
	{
		StatModController.OnDebuffAdded -= HandleDebuffAdded;
		Character.OnCharacterDied -= HandleCharacterDied;
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		if (!(debuff.id == buffId) || !(c == GameStates.Singleton.hero))
		{
			return;
		}
		Character targetEnemy = GameStates.Singleton.hero.GetComponent<HeroAI>().targetEnemy;
		if (targetEnemy != null && targetEnemy.id == foeId)
		{
			if (foesCounted == null)
			{
				foesCounted = new List<Character>();
			}
			if (!foesCounted.Contains(targetEnemy))
			{
				foesCounted.Add(targetEnemy);
			}
		}
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (!(c.id == foeId) || (reason != Character.DeathReason.Unmake && reason != Character.DeathReason.DamageTaken))
		{
			return;
		}
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController == null || hero.statModController.debuffs == null)
		{
			return;
		}
		bool flag = false;
		if (foesCounted == null)
		{
			foesCounted = new List<Character>();
		}
		List<List<StatModifier>> debuffs = hero.statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == buffId)
			{
				flag = true;
				break;
			}
		}
		if (flag && !foesCounted.Contains(c))
		{
			CalcProgress();
		}
		if (foesCounted.Contains(c))
		{
			CalcProgress();
			foesCounted.Remove(c);
		}
	}

	private void CalcProgress()
	{
		if (pointsByDifficulty)
		{
			Data.Quest questData = GameStates.Singleton.level.QuestData;
			AddProgress(questData.level, questData.level);
		}
		else
		{
			AddProgress();
		}
	}
}
