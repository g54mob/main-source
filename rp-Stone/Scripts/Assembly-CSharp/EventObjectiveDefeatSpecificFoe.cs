public class EventObjectiveDefeatSpecificFoe : EventObjectiveBase
{
	private string foeId;

	private bool pointsByDifficulty;

	public EventObjectiveDefeatSpecificFoe(int goal, string foeId, string foeName, bool pointsByDifficulty)
		: base("kill_foe", goal)
	{
		this.foeId = foeId;
		this.pointsByDifficulty = pointsByDifficulty;
		description = string.Format(Te.xt("tid_q_basic_boss"), TranslateIfTID(foeName));
	}

	public override void Init()
	{
		Character.OnCharacterDied += HandleCharacterDied;
	}

	public override void End()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if ((reason == Character.DeathReason.DamageTaken || reason == Character.DeathReason.Unmake) && c.id.Contains(foeId))
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
}
