using System.Text.RegularExpressions;

public class EventObjectiveVisitLocationWithCosmetic : EventObjectiveBase
{
	private string locationId;

	private string regexPattern;

	public EventObjectiveVisitLocationWithCosmetic(int goal, string locationId, string locationName, string cosmeticPath)
		: base("visit+cosmetic", goal)
	{
		this.locationId = locationId;
		regexPattern = CreateRegexPattern(cosmeticPath);
		locationName = TranslateIfTID(locationName).Trim();
		description = string.Format(Te.xt("tid_q_basic_visit_cosmetic"), locationName) + "\n" + cosmeticPath;
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
		GameStates.OnQuestStarting += HandleQuestStarted;
	}

	public override void End()
	{
		GameStates.OnQuestStarting -= HandleQuestStarted;
	}

	private void HandleQuestStarted(Data.Quest quest)
	{
		if (!(quest.id == locationId) || !MindStoneController.singleton.enabled)
		{
			return;
		}
		string[] program = MindStoneController.singleton.program;
		foreach (string input in program)
		{
			if (IsMatch(input, regexPattern))
			{
				AddProgress();
				break;
			}
		}
	}
}
