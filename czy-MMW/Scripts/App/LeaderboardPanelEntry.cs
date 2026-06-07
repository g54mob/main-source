using Factory;
using Motorways.Themes;
using TMPro;
using UnityEngine;

public class LeaderboardPanelEntry : MonoBehaviour
{
	public const string NoRankSymbol = "-";

	public LocalizedTextUI rank;

	public LocalizedTextUI player;

	public LocalizedTextUI score;

	[SerializeField]
	private ThemeTypeToggler _toggler;

	private IScope _scope;

	private LocaleDatabase _localeDatabase;

	public void InitializeWithScope(IScope scope)
	{
		_scope = scope;
		_localeDatabase = _scope.Get<LocaleDatabase>();
	}

	public void SetAsBlankEntry(bool evenRow)
	{
		_toggler.SetSelectedTheme(evenRow);
		rank.TextField.text = "";
		player.TextField.text = "";
		score.TextField.text = "";
	}

	public void UpdateFromLeaderboardEntry(LeaderboardEntry fromEntry, bool evenRow, long totalLeaderboardEntryCount)
	{
		_toggler.SetSelectedTheme(evenRow);
		string nonLocalizedString;
		if (fromEntry.Rank == 0L)
		{
			nonLocalizedString = "-";
			score.LocString = StandaloneLocString.CreateNonLocalizedString(_scope, "-");
		}
		else
		{
			nonLocalizedString = ((fromEntry.Rank != -1) ? _localeDatabase.CurrentLocale.FormatNumber(fromEntry.Rank) : "");
			score.LocString = StandaloneLocString.CreateLocalizedNumberString(_scope, fromEntry.Score);
		}
		StandaloneLocString locString;
		if (fromEntry.Type == LeaderboardEntryType.Local)
		{
			locString = fromEntry.FormatLocalUserString(_scope, totalLeaderboardEntryCount);
			rank.TextField.fontStyle = FontStyles.Bold;
			player.TextField.fontStyle = FontStyles.Bold;
			score.TextField.fontStyle = FontStyles.Bold;
		}
		else
		{
			locString = StandaloneLocString.CreateNonLocalizedString(_scope, fromEntry.Name);
			rank.TextField.fontStyle = FontStyles.Normal;
			player.TextField.fontStyle = FontStyles.Normal;
			score.TextField.fontStyle = FontStyles.Normal;
		}
		rank.LocString = StandaloneLocString.CreateNonLocalizedString(_scope, nonLocalizedString);
		player.LocString = locString;
	}
}
