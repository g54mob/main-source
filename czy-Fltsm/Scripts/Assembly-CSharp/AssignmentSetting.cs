using System;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Flotsam/Assignment")]
public class AssignmentSetting : ScriptableObject
{
	[Header("Text")]
	[Tooltip("Localized text of this assignment.")]
	public LocalizedString Name = "";

	public LocalizedString Description = "";

	public bool AppliesEnabledToAllAgents;

	public bool HideInDutiesPanel;

	[Tooltip("Tooltip that says what this assignment is used in.")]
	public LocalizedString UsedIn = "";

	[Tooltip("Tooltip that shows what attributes this assignment is affected by.")]
	public LocalizedString AffectedBy = "";

	[Space]
	[Tooltip("Type of the assignment.")]
	public AssignmentType Type;

	[Tooltip("Sprite of this assignment.")]
	public Sprite Sprite;

	[Tooltip("List of BuildableProperties this assignment is linked to.")]
	public BuildableProperties[] UsedInProperties;

	[Tooltip("When computing the priority score for this assignment, should only the priority assigned by the player be used? (the order and project priorities will be ignored)")]
	public bool AssingmentPriorityOnly;

	public string GetTooltip(DrifterAttributes drifterAttributes, string tooltip = null)
	{
		if (UsedInProperties.Length != 0)
		{
			tooltip = CombineStrings(tooltip, Regex.Replace(UsedIn, "%BUILDINGS%", UsedInPropertiesToString(", ", UsedInProperties), RegexOptions.IgnoreCase));
		}
		if (drifterAttributes.TryReturnAffectedAttributesText(this, out var text))
		{
			tooltip = CombineStrings(tooltip, Regex.Replace(AffectedBy, "%ATTRIBUTES%", text, RegexOptions.IgnoreCase));
		}
		return tooltip;
	}

	private string CombineStrings(string original, string toAppend)
	{
		if (string.IsNullOrEmpty(original))
		{
			return toAppend;
		}
		return original + "\n\n" + toAppend;
	}

	private string UsedInPropertiesToString(string joiner, BuildableProperties[] properties)
	{
		string text = "";
		bool flag = false;
		foreach (BuildableProperties buildableProperties in properties)
		{
			if (flag)
			{
				text += joiner;
			}
			text += buildableProperties.Name;
			flag = true;
		}
		return text;
	}
}
