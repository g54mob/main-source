using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColonyFilters : MonoBehaviour
{
	public ColonySector colonySector;

	public Toggle favoritesToggle;

	public Toggle inProgressToggle;

	public Toggle completedToggle;

	public Toggle notPlayedToggle;

	public Toggle downloadedToggle;

	public Toggle viewHiddenToggle;

	public Toggle objNullifyToggle;

	public Toggle objTotemToggle;

	public Toggle objReclaimToggle;

	public Toggle objSurviveToggle;

	public Toggle objCollectToggle;

	public Toggle objCustomToggle;

	public TMP_InputField textTitleInput;

	public TMP_InputField textAuthorInput;

	public TMP_InputField textTagsInput;

	public TMP_Dropdown tagsDropdown;

	public Toggle notTextTagsToggle;

	public TMP_InputField startNumInput;

	public void OnApplyFiltersClicked()
	{
	}

	public void OnClearClicked()
	{
	}

	public void Refresh()
	{
	}

	public static void RefreshDropdown(TMP_Dropdown tagsDropdown, List<ColonySector.TagCountStruct> mt)
	{
	}

	public void OnRefresh()
	{
	}

	public void OnTagsDropdown(int ddval)
	{
	}

	public static string AppendString(string startString, string newString)
	{
		return null;
	}
}
