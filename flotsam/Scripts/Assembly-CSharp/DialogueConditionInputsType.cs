using System;
using UnityEngine;

[Serializable]
public class DialogueConditionInputsType : IDialogueCondition
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Inputs Type";

	[SerializeField]
	private InputFlags _inputsTypes;

	bool IDialogueCondition.IsMet()
	{
		return (FlotsamInputManager.ActiveInput & _inputsTypes) != 0;
	}

	public override string ToString()
	{
		return "Inputs Type: " + _inputsTypes;
	}
}
