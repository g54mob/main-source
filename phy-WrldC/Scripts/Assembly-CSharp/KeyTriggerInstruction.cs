using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyTriggerInstruction : Instruction
{
	public string KeyLabel { get; set; }

	public bool WasKeyLabelChanged { get; set; }

	public KeyTriggerType TriggerType { get; set; }

	public KeyCode Key { get; set; }

	public KeyTriggerInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		KeyLabel = LanguagesManager.Instance.GetText("label.text.logic.key.label", "label.text.logic.key.label");
		WasKeyLabelChanged = false;
		base.Type = InstructionType.KeyTrigger;
		TriggerType = KeyTriggerType.Down;
		Key = KeyCode.A;
	}

	public override IEnumerable<int> Execute()
	{
		bool flag = false;
		bool flag2 = false;
		switch (TriggerType)
		{
		case KeyTriggerType.Down:
			if (Input.GetKey(Key))
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case KeyTriggerType.Up:
			if (!Input.GetKey(Key))
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case KeyTriggerType.UpToDown:
			if (Input.GetKeyDown(Key))
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case KeyTriggerType.DownToUp:
			if (Input.GetKeyUp(Key))
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		}
		if (flag)
		{
			foreach (int item in ExecuteAllFirstInstructions())
			{
				yield return item;
			}
		}
		else
		{
			if (!flag2)
			{
				yield break;
			}
			foreach (int item2 in ExecuteAllSecondInstructions())
			{
				yield return item2;
			}
		}
	}
}
