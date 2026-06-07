using System;
using UnityEngine;

[Serializable]
public class DialogueConditionSelectedBuildable : IDialogueCondition
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Buildable Selected";

	[SerializeField]
	private BuildableProperties _specificBuildable;

	bool IDialogueCondition.IsMet()
	{
		if (Selector.SelectedType == ObjectType.Buildable)
		{
			if (!(_specificBuildable == null))
			{
				if (Selector.Selection.ObjectToSelect.TryGetComponent<Buildable>(out var component))
				{
					return component.Properties == _specificBuildable;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "Select Buildable: " + ((_specificBuildable != null) ? _specificBuildable.Name : "Any");
	}
}
