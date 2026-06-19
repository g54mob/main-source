using System;
using System.Collections.Generic;
using System.Linq;

public class RadicalOptionsMenuOption_SeasonOverride : RadicalPauseMenuOption
{
	private const string seasonsTerm = "Seasons/";

	private const string dontOverrideTerm = "DontOverrideSeason";

	private const string turnOffTerm = "TurnOffSeasons";

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		UpdateText();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		NextSeason();
	}

	public override bool OnSkimLeft()
	{
		return NextSeason(-1);
	}

	public override bool OnSkimRight()
	{
		return NextSeason();
	}

	public bool NextSeason(int offset = 1)
	{
		List<Season> list = Enum.GetValues(typeof(Season)).Cast<Season>().ToList();
		int serverSeasonOverride = Manager.prefs.serverSeasonOverride;
		serverSeasonOverride += offset;
		if (serverSeasonOverride >= list.Count)
		{
			serverSeasonOverride = -1;
		}
		else if (serverSeasonOverride < -1)
		{
			serverSeasonOverride = list.Count - 1;
		}
		Manager.prefs.serverSeasonOverride = serverSeasonOverride;
		Manager.prefs.UpdateSeason();
		UpdateText();
		return true;
	}

	private void UpdateText()
	{
		int serverSeasonOverride = Manager.prefs.serverSeasonOverride;
		if (serverSeasonOverride == 0)
		{
			valueText.Render("TurnOffSeasons");
		}
		else if (serverSeasonOverride > 0)
		{
			PugText pugText = valueText;
			Season season = (Season)serverSeasonOverride;
			pugText.Render("Seasons/" + season);
		}
		else if (serverSeasonOverride == -1)
		{
			valueText.Render("DontOverrideSeason");
		}
	}
}
