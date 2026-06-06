using System;
using UnityEngine;

[Serializable]
public class DialogueConditionBuildableBuilt : IDialogueCondition
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Buildable Built";

	[SerializeField]
	private BuildableProperties _buildable;

	[SerializeField]
	private int _requiredCount = 1;

	bool IDialogueCondition.IsMet()
	{
		if (_buildable == null)
		{
			Debug.LogError("No buildable was specified for DialogueConditionBuildableBuilt!");
			return true;
		}
		return GameManager.GameStatsManager.GetBuildablesBuiltCount(_buildable) >= _requiredCount;
	}

	public override string ToString()
	{
		string arg = ((_buildable != null) ? _buildable.Name : "NO BUILDABLE SPECIFIED");
		return $"Buildable Built: {arg} ({_requiredCount}+)";
	}
}
