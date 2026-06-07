using System;
using Bolt;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Money Operation")]
[UnitSubtitle("Change the amount of player's money in various ways")]
[UnitCategory("Player")]
[TypeIcon(typeof(MonoBehaviour))]
public class MoneyOperationUnit : Unit
{
	public enum OpType
	{
		Set = 0,
		Add = 1,
		Subtract = 2,
		MakeGreaterOrEqual = 3,
		MakeLessOrEqual = 4
	}

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput operationType;

	[DoNotSerialize]
	public ValueInput amountValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		operationType = ValueInput("Type", OpType.Set);
		amountValue = ValueInput("Amount", 0.0);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			double num = flow.GetValue<int>(amountValue);
			OpType value = flow.GetValue<OpType>(operationType);
			switch (value)
			{
			case OpType.Set:
				SingletonBehaviour<Inventory>.Instance.SetMoney(num);
				break;
			case OpType.Add:
				SingletonBehaviour<Inventory>.Instance.AddMoney(num);
				break;
			case OpType.Subtract:
				SingletonBehaviour<Inventory>.Instance.RemoveMoney(num);
				break;
			case OpType.MakeGreaterOrEqual:
				SingletonBehaviour<Inventory>.Instance.SetMoney(Math.Max(SingletonBehaviour<Inventory>.Instance.PlayerMoney, num));
				break;
			case OpType.MakeLessOrEqual:
				SingletonBehaviour<Inventory>.Instance.SetMoney(Math.Min(SingletonBehaviour<Inventory>.Instance.PlayerMoney, num));
				break;
			default:
				throw new NotImplementedException(string.Format("OpType {0} not yet implemented, check the code for {1}", value, "MoneyOperationUnit"));
			}
			return doneTrigger;
		});
	}
}
