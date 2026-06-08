using System.Collections.Generic;

public class SpecificReplacer_Polish : SpecificLanguageReplacer
{
	private readonly Dictionary<string, List<string>> rule1Replacements = new Dictionary<string, List<string>>
	{
		{
			"[additionalHouses_pl]",
			new List<string> { "dodatkowy dom", "dodatkowe domy", "dodatkowych domów", "dodatkowych domów" }
		},
		{
			"[fields_pl]",
			new List<string> { "pole", "pola", "pól", "pól" }
		},
		{
			"[houses_pl]",
			new List<string> { "dom", "domy", "domów", "domów" }
		},
		{
			"[trees_pl]",
			new List<string> { "drzewo", "drzewa", "drzew", "drzew" }
		},
		{
			"[trainTracks_pl]",
			new List<string> { "tor kolejowy", "tory kolejowe", "torów kolejowych", "torów kolejowych" }
		},
		{
			"[waterSegments_pl]",
			new List<string> { "element wodny", "elementy wodne", "elementów wody", "elementów wodnych" }
		},
		{
			"[villages_pl]",
			new List<string> { "wioskę", "wioski", "wiosek", "wiosek" }
		},
		{
			"[forests_pl]",
			new List<string> { "las", "lasy", "lasów", "lasów" }
		},
		{
			"[fieldGroups_pl]",
			new List<string> { "obszar polny", "obszary polne", "obszarów polnych", "obszarów polnych" }
		},
		{
			"[trainRoutes_pl]",
			new List<string> { "trasę kolejową", "trasy kolejowe", "tras kolejowych", "tras kolejowych" }
		},
		{
			"[waterBodies_pl]",
			new List<string> { "akwen wodny", "akweny wodne", "akwenów wodnych", "akwenów wodnych" }
		},
		{
			"[points_pl]",
			new List<string> { "<point>", "Punktami", "Punktami", "Punktów" }
		},
		{
			"[tiles_pl]",
			new List<string> { "kafelek", "kafelki", "kafelków", "kafelków" }
		},
		{
			"[consecutiveTiles_pl]",
			new List<string> { "<consecutiveTile>", "kolejne kafelki", "kolejnych kafelków", "kolejnych kafelków" }
		},
		{
			"[sessions_pl]",
			new List<string> { "partię", "partie", "partii", "partii" }
		},
		{
			"[perfectPlacements_pl]",
			new List<string> { "perfekcyjne dopasowanie", "perfekcyjne dopasowania", "perfekcyjnych dopasowań", "perfekcyjnych dopasowań" }
		},
		{
			"[quests_pl]",
			new List<string> { "zadanie", "zadania", "zadań", "zadań" }
		},
		{
			"[challenges_pl]",
			new List<string> { "wyzwanie", "wyzwania", "wyzwań", "wyzwań" }
		},
		{
			"[windmills_pl]",
			new List<string> { "młyn", "młyny", "młynów", "młynów" }
		}
	};

	public override Language Language => Language.Polish;

	public override string ApplySpecificNumberingGrammar(string inputString, int number)
	{
		DetermineRuleIndices(number, out var rule1Index);
		foreach (KeyValuePair<string, List<string>> rule1Replacement in rule1Replacements)
		{
			inputString = inputString.Replace(rule1Replacement.Key, rule1Replacement.Value[rule1Index]);
		}
		return inputString;
	}

	private static void DetermineRuleIndices(int number, out int rule1Index)
	{
		switch (number)
		{
		case 0:
			rule1Index = 0;
			return;
		case 2:
		case 3:
		case 4:
			rule1Index = 1;
			return;
		}
		if (number == 1000)
		{
			rule1Index = 2;
		}
		else
		{
			rule1Index = 3;
		}
	}
}
