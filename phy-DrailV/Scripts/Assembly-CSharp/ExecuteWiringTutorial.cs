using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[UnitCategory("Player")]
[TypeIcon(typeof(TrainCar))]
[UnitTitle("Wiring Tutorial")]
[UnitSubtitle("Wire two gadgets together")]
public class ExecuteWiringTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput gadget1;

	[DoNotSerialize]
	public ValueInput gadget2;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput locEquipTool;

	[DoNotSerialize]
	public ValueInput crimpingTool;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput locConnectOne;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput locConnectOther;

	protected override void Definition()
	{
		base.Definition();
		gadget1 = ValueInput<GameObject>("Gadget 1", null);
		gadget2 = ValueInput<GameObject>("Gadget 2", null);
		crimpingTool = ValueInput<GameObject>("Crimping tool", null);
		locEquipTool = ValueInput<string>("LOC Equip tool", null);
		locConnectOne = ValueInput<string>("LOC Connect 1", null);
		locConnectOther = ValueInput<string>("LOC Connect 2", null);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(gadget1);
		GameObject value2 = flow.GetValue<GameObject>(gadget2);
		string value3 = flow.GetValue<string>(locEquipTool);
		string value4 = flow.GetValue<string>(locConnectOne);
		string value5 = flow.GetValue<string>(locConnectOther);
		GameObject value6 = flow.GetValue<GameObject>(crimpingTool);
		ItemBase[] crimpingItems = new ItemBase[1] { value6 ? value6.GetComponentInChildren<ItemBase>() : null };
		return QuickTutorialFactory.WiringTutorial(value, value2, crimpingItems, value3, value4, value5);
	}
}
