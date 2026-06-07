using System;
using TNRD;
using UnityEngine;

[Serializable]
public class DialogueConditionSelectedLandmark : IDialogueCondition
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Landmark Selected";

	[SerializeField]
	private SerializableInterface<ILandmarkBehaviourProvider> _specificLandmark;

	bool IDialogueCondition.IsMet()
	{
		if (Selector.SelectedType == ObjectType.Landmark)
		{
			if (_specificLandmark != null)
			{
				if (Selector.Selection.ObjectToSelect.TryGetComponent<Landmark>(out var component))
				{
					return _specificLandmark.Value.ReturnIsLandmarkBehaviour(component.Behaviour);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "Select Landmark: " + ((_specificLandmark.Value != null) ? _specificLandmark.Value.EditorName : "Any");
	}
}
