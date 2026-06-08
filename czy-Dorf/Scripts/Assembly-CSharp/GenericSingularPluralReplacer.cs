using System.Collections.Generic;

public class GenericSingularPluralReplacer : SpecificLanguageReplacer
{
	private readonly Language _003CLanguage_003Ek__BackingField;

	private readonly Dictionary<string, List<string>> replacements = new Dictionary<string, List<string>>
	{
		{
			"[tiles]",
			new List<string> { "countable_tile", "countables_tile" }
		},
		{
			"[element_tree]",
			new List<string> { "element_tree", "elements_tree" }
		},
		{
			"[element_house]",
			new List<string> { "element_house", "elements_house" }
		},
		{
			"[element_field]",
			new List<string> { "element_field", "elements_field" }
		},
		{
			"[element_traintrack]",
			new List<string> { "element_traintrack", "elements_traintrack" }
		},
		{
			"[element_water]",
			new List<string> { "element_water", "elements_water" }
		},
		{
			"[group_forest]",
			new List<string> { "group_forest", "groups_forest" }
		},
		{
			"[group_village]",
			new List<string> { "group_village", "groups_village" }
		},
		{
			"[group_field]",
			new List<string> { "group_field", "groups_field" }
		},
		{
			"[group_traintrack]",
			new List<string> { "group_traintrack", "groups_traintrack" }
		},
		{
			"[group_water]",
			new List<string> { "group_water", "groups_water" }
		}
	};

	public override Language Language => _003CLanguage_003Ek__BackingField;

	public override string ApplySpecificNumberingGrammar(string inputString, int number)
	{
		foreach (KeyValuePair<string, List<string>> replacement in replacements)
		{
			inputString = ((number != 1) ? inputString.Replace(replacement.Key, LocalizationManager.Instance.GetLocalizedValue(replacement.Value[1])) : inputString.Replace(replacement.Key, LocalizationManager.Instance.GetLocalizedValue(replacement.Value[0])));
		}
		return inputString;
	}
}
