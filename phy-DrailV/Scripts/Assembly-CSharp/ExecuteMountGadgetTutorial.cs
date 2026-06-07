using System;
using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
[UnitSubtitle("Execute gadget mounting tutorial")]
[UnitTitle("Mount Gadget Tutorial")]
public class ExecuteMountGadgetTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput mountName;

	[DoNotSerialize]
	public ValueInput gadgetName;

	[DoNotSerialize]
	public ValueInput gadgetObject;

	[DoNotSerialize]
	public ValueInput modeValue;

	[DoNotSerialize]
	public ValueInput[] toolObjects;

	[DoNotSerialize]
	public ValueInput[] mountObjects;

	[DoNotSerialize]
	public ValueInput targetArea;

	[DoNotSerialize]
	public ValueInput angleLimit;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput locEquipMount;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput locPlaceMount;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput locEquipDrill;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput locDrillHole;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput locEquipGadget;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput locPlaceGadget;

	[DoNotSerialize]
	public ValueOutput firstMounted;

	[DoNotSerialize]
	public ValueOutput secondMounted;

	[DoNotSerialize]
	public ValueOutput firstItem;

	[DoNotSerialize]
	public ValueOutput secondItem;

	[UnitHeaderInspectable("Tool count")]
	[Inspectable]
	public int ToolCount { get; set; } = 1;

	[Inspectable]
	[UnitHeaderInspectable("Mount count")]
	public int MountCount { get; set; } = 1;

	protected override void Definition()
	{
		base.Definition();
		mountName = ValueInput<string>("Mount name", null);
		int num = Mathf.Clamp(MountCount, 1, 10);
		mountObjects = new ValueInput[num];
		for (int i = 0; i < num; i++)
		{
			mountObjects[i] = ValueInput<GameObject>($"Mount {i + 1}", null);
		}
		gadgetName = ValueInput<string>("Gadget name", null);
		gadgetObject = ValueInput<GameObject>("Gadget object", null);
		modeValue = ValueInput("Mode", QuickTutorialFactory.MountingMode.Either);
		int num2 = Mathf.Clamp(ToolCount, 1, 10);
		toolObjects = new ValueInput[num2];
		for (int j = 0; j < num2; j++)
		{
			toolObjects[j] = ValueInput<GameObject>($"Tool {j + 1}", null);
		}
		targetArea = ValueInput<GameObject>("Area", null);
		angleLimit = ValueInput("Angle limit", 180f);
		locEquipMount = ValueInput<string>("LOC Equip mount", null);
		locPlaceMount = ValueInput<string>("LOC Place mount", null);
		locEquipDrill = ValueInput<string>("LOC Equip drill", null);
		locDrillHole = ValueInput<string>("LOC Drill hole", null);
		locEquipGadget = ValueInput<string>("LOC Equip gadget", null);
		locPlaceGadget = ValueInput<string>("LOC Place gadget", null);
		firstMounted = ValueOutput<GameObject>("Mount 1", null);
		secondMounted = ValueOutput<GameObject>("Mount 2", null);
		firstItem = ValueOutput<GameObject>("Item 1", null);
		secondItem = ValueOutput<GameObject>("Item 2", null);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		string value = flow.GetValue<string>(mountName);
		string value2 = flow.GetValue<string>(gadgetName);
		ItemBase[] gadgetItems = new ItemBase[1] { flow.GetValue<GameObject>(gadgetObject)?.GetComponentInChildren<ItemBase>() };
		ItemBase[] array = new ItemBase[toolObjects.Length];
		for (int i = 0; i < toolObjects.Length; i++)
		{
			array[i] = flow.GetValue<GameObject>(toolObjects[i])?.GetComponentInChildren<ItemBase>();
		}
		ItemBase[] array2 = new ItemBase[mountObjects.Length];
		for (int j = 0; j < mountObjects.Length; j++)
		{
			array2[j] = flow.GetValue<GameObject>(mountObjects[j])?.GetComponentInChildren<ItemBase>();
		}
		GameObject value3 = flow.GetValue<GameObject>(targetArea);
		Collider[] allowedPlacement = (value3 ? value3.GetComponentsInChildren<Collider>() : Array.Empty<Collider>());
		float value4 = flow.GetValue<float>(angleLimit);
		string value5 = flow.GetValue<string>(locEquipMount);
		string value6 = flow.GetValue<string>(locPlaceMount);
		string value7 = flow.GetValue<string>(locEquipDrill);
		string value8 = flow.GetValue<string>(locDrillHole);
		string value9 = flow.GetValue<string>(locEquipGadget);
		string value10 = flow.GetValue<string>(locPlaceGadget);
		QuickTutorialFactory.MountingMode value11 = flow.GetValue<QuickTutorialFactory.MountingMode>(modeValue);
		return QuickTutorialFactory.MountGadgetTutorial(allowedPlacement, array, array2, gadgetItems, value4, value, value2, value11, value5, value6, value7, value8, value9, value10);
	}

	protected override void PostTutorialPhase(Flow flow, QuickTutorial tutorial)
	{
		base.PostTutorialPhase(flow, tutorial);
		PlaceGadgetStep[] stepsOfType = tutorial.GetStepsOfType<PlaceGadgetStep>();
		flow.SetValue(firstMounted, (stepsOfType.Length >= 1) ? stepsOfType[0].PlacedGadget.gameObject : null);
		flow.SetValue(secondMounted, (stepsOfType.Length >= 3) ? stepsOfType[2].PlacedGadget.gameObject : null);
		flow.SetValue(firstItem, (stepsOfType.Length >= 1) ? stepsOfType[0].PlacedGadget.GadgetItem.gameObject : null);
		flow.SetValue(secondItem, (stepsOfType.Length >= 3) ? stepsOfType[2].PlacedGadget.GadgetItem.gameObject : null);
	}
}
