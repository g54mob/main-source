using System.Text.RegularExpressions;

public class EventObjectiveDefeatBossWithCosmetic : EventObjectiveBase
{
	private string regexPattern;

	public EventObjectiveDefeatBossWithCosmetic(int goal, string cosmeticPath)
		: base("killboss+cosmetic", goal)
	{
		regexPattern = CreateRegexPattern(cosmeticPath);
		description = Te.xt("tid_q_basic_boss_cosmetic") + "\n" + cosmeticPath;
	}

	private string CreateRegexPattern(string input)
	{
		return Regex.Replace(Regex.Replace(input, "([.$^{[(|)*+?\\\\])", "\\$1"), "[/\\\\]", "[\\\\/]").Replace(" ", "\\s+");
	}

	private bool IsMatch(string input, string pattern)
	{
		return Regex.IsMatch(input.Trim(), pattern, RegexOptions.IgnoreCase);
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
		if (!c.HasTag("boss") || !MindStoneController.singleton.enabled)
		{
			return;
		}
		string[] program = MindStoneController.singleton.program;
		foreach (string input in program)
		{
			if (IsMatch(input, regexPattern))
			{
				Data.Quest questData = GameStates.Singleton.level.QuestData;
				AddProgress(questData.level, questData.level);
				break;
			}
		}
	}
}
