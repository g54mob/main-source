using System.Collections.Generic;

public class SpecificReplacer_Russian : SpecificLanguageReplacer
{
	private readonly Dictionary<string, List<string>> rule1Replacements = new Dictionary<string, List<string>>
	{
		{
			"[fields_ru]",
			new List<string> { "полей", "полей", "поле", "поля", "полей" }
		},
		{
			"[houses_ru]",
			new List<string> { "домов", "домов", "дом", "дома", "домов" }
		},
		{
			"[trees_ru]",
			new List<string> { "деревьев", "деревьев", "дерево", "дерева", "деревьев" }
		},
		{
			"[trainTracks_ru]",
			new List<string> { "железнодорожных путей", "железнодорожных путей", "железнодорожный путь", "железнодорожных путя", "железнодорожных путей" }
		},
		{
			"[waterSegments_ru]",
			new List<string> { "плиток с водой", "плиток с водой", "плитку с водой", "плитки с водой", "плиток с водой" }
		},
		{
			"[villages_ru]",
			new List<string> { "деревень", "деревень", "деревню", "деревни", "деревень" }
		},
		{
			"[forests_ru]",
			new List<string> { "лесов", "лесов", "лес", "леса", "лесов" }
		},
		{
			"[fieldGroups_ru]",
			new List<string> { "групп", "групп", "группу", "группы", "групп" }
		},
		{
			"[trainRoutes_ru]",
			new List<string> { "маршрутов", "маршрутов", "маршрут", "маршрута", "маршрутов" }
		},
		{
			"[waterBodies_ru]",
			new List<string> { "акваторий", "акваторий", "акваторию", "акватории", "акваторий" }
		},
		{
			"[points_ru]",
			new List<string> { "очков", "очков", "очко", "очка", "очков" }
		},
		{
			"[tiles_ru]",
			new List<string> { "плиток", "плиток", "плитку", "плитки", "плиток" }
		},
		{
			"[sessions_ru]",
			new List<string> { "игр", "игр", "игру", "игры", "игр" }
		},
		{
			"[placements_ru]",
			new List<string> { "идеальных мест", "идеальных мест", "идеальное место", "идеальных места", "идеальных мест" }
		},
		{
			"[quests_ru]",
			new List<string> { "заданий", "заданий", "задание", "задания", "заданий" }
		},
		{
			"[challenges_ru]",
			new List<string> { "испытаний", "испытаний", "испытание", "испытания", "испытаний" }
		},
		{
			"[windmills_ru]",
			new List<string> { "ориентированных ветряных мельниц", "ориентированных ветряных мельниц", "ориентированную ветряную мельницу", "ориентированные ветряные мельницы", "ориентированных ветряных мельниц" }
		},
		{
			"[tiles_2_ru]",
			new List<string> { "плиток", "плиток", "плитка", "плитки", "плиток" }
		}
	};

	private readonly Dictionary<string, List<string>> rule2Replacements = new Dictionary<string, List<string>>
	{
		{
			"[additionalHouses_ru]",
			new List<string> { "дополнительного дома", "дополнительных домов" }
		},
		{
			"[houses2_ru]",
			new List<string> { "дома", "домов" }
		},
		{
			"[trees2_ru]",
			new List<string> { "дерева", "деревьев" }
		},
		{
			"[fields2_ru]",
			new List<string> { "поля", "полей" }
		},
		{
			"[trainTracks2_ru]",
			new List<string> { "железнодорожного птуи", "железнодорожных путей" }
		},
		{
			"[waterSegments2_ru]",
			new List<string> { "плитки", "плиток" }
		}
	};

	public override Language Language => Language.Russian;

	public override string ApplySpecificNumberingGrammar(string inputString, int number)
	{
		DetermineRuleIndices(number, out var rule1Index, out var rule2Index);
		foreach (KeyValuePair<string, List<string>> rule1Replacement in rule1Replacements)
		{
			inputString = inputString.Replace(rule1Replacement.Key, rule1Replacement.Value[rule1Index]);
		}
		foreach (KeyValuePair<string, List<string>> rule2Replacement in rule2Replacements)
		{
			inputString = inputString.Replace(rule2Replacement.Key, rule2Replacement.Value[rule2Index]);
		}
		return inputString;
	}

	private void DetermineRuleIndices(int number, out int rule1Index, out int rule2Index)
	{
		if (number % 10 == 0)
		{
			rule1Index = 0;
		}
		else if (number > 10 && number < 20)
		{
			rule1Index = 1;
		}
		else if (number % 10 == 1)
		{
			rule1Index = 2;
		}
		else if (number % 10 < 5)
		{
			rule1Index = 3;
		}
		else
		{
			rule1Index = 4;
		}
		rule2Index = ((number != 1) ? 1 : 0);
	}
}
