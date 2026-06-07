using System;
using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Money Item Operation")]
[UnitCategory("Player")]
[UnitSubtitle("Modify amount on a money item")]
[TypeIcon(typeof(Wallet))]
public class SetMoneyUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput objectValue;

	[DoNotSerialize]
	public ValueInput operationType;

	[DoNotSerialize]
	public ValueInput amountValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		objectValue = ValueInput<GameObject>("Object", null);
		operationType = ValueInput("Type", MoneyOperationUnit.OpType.Set);
		amountValue = ValueInput("Amount", 0.0);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(objectValue);
			if (value == null)
			{
				Debug.LogError("No money item assigned! Skipping");
				return doneTrigger;
			}
			IMoney component = value.GetComponent<IMoney>();
			if (component == null)
			{
				Debug.LogError("No IMoney component found on the given object (" + value.name + "), skipping", value);
				return doneTrigger;
			}
			double num = flow.GetValue<int>(amountValue);
			MoneyOperationUnit.OpType value2 = flow.GetValue<MoneyOperationUnit.OpType>(operationType);
			switch (value2)
			{
			case MoneyOperationUnit.OpType.Set:
				component.Amount = num;
				break;
			case MoneyOperationUnit.OpType.Add:
				component.Amount += num;
				break;
			case MoneyOperationUnit.OpType.Subtract:
				component.Amount -= num;
				break;
			case MoneyOperationUnit.OpType.MakeGreaterOrEqual:
				component.Amount = Math.Max(component.Amount, num);
				break;
			case MoneyOperationUnit.OpType.MakeLessOrEqual:
				component.Amount = Math.Min(component.Amount, num);
				break;
			default:
				throw new NotImplementedException(string.Format("OpType {0} not yet implemented, check the code for {1}", value2, "MoneyOperationUnit"));
			}
			return doneTrigger;
		});
	}
}
