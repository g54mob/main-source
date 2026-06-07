using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Tutorial.QT;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Player")]
[UnitSubtitle("Execute gadget soldering tutorial")]
[UnitTitle("Soldering Tutorial")]
public class ExecuteSolderingTutorial : ExecuteLocoTutorial
{
	[DoNotSerialize]
	public ValueInput gadget;

	[DoNotSerialize]
	public ValueInput locEquipSolderingGun;

	[DoNotSerialize]
	public ValueInput solderingGun;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput locUnloadSolderingGun;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput lodLoadInInventory;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput locEquipCoil;

	[DoNotSerialize]
	public ValueInput[] solderReels;

	[DoNotSerialize]
	public ValueInput locLoadCoild;

	[DoNotSerialize]
	public ValueInput locSolder;

	[Inspectable]
	[UnitHeaderInspectable("Reel count")]
	public int Count { get; set; } = 1;

	protected override void Definition()
	{
		base.Definition();
		gadget = ValueInput<GameObject>("Gadget", null);
		solderingGun = ValueInput<GameObject>("Soldering gun", null);
		int num = Mathf.Clamp(Count, 1, 10);
		solderReels = new ValueInput[num];
		for (int i = 0; i < num; i++)
		{
			solderReels[i] = ValueInput<GameObject>("Reel " + (i + 1), null);
		}
		locEquipSolderingGun = ValueInput<string>("LOC Equip gun", null);
		locUnloadSolderingGun = ValueInput<string>("LOC Unload gun", null);
		lodLoadInInventory = ValueInput<string>("LOC Load in inventory", null);
		locEquipCoil = ValueInput<string>("LOC Equip coil", null);
		locLoadCoild = ValueInput<string>("LOC Load coil", null);
		locSolder = ValueInput<string>("LOC Solder", null);
	}

	protected override QuickTutorial ConstructTutorial(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(gadget);
		GameObject value2 = flow.GetValue<GameObject>(solderingGun);
		ItemBase[] toolItems = new ItemBase[1] { value2 ? value2.GetComponent<ItemBase>() : null };
		ItemBase[] array = new ItemBase[solderReels.Length];
		for (int i = 0; i < solderReels.Length; i++)
		{
			GameObject value3 = flow.GetValue<GameObject>(solderReels[i]);
			if ((bool)value3)
			{
				ItemBase component = value3.GetComponent<ItemBase>();
				InventoryItemSpec component2 = value3.GetComponent<InventoryItemSpec>();
				if ((bool)component && (bool)component2 && component2.ItemPrefabName == "SolderingWireReel")
				{
					array[i] = component;
				}
			}
		}
		string value4 = flow.GetValue<string>(locEquipSolderingGun);
		string value5 = flow.GetValue<string>(locUnloadSolderingGun);
		string value6 = flow.GetValue<string>(lodLoadInInventory);
		string value7 = flow.GetValue<string>(locEquipCoil);
		string value8 = flow.GetValue<string>(locLoadCoild);
		string value9 = flow.GetValue<string>(locSolder);
		return QuickTutorialFactory.SolderGadgetTutorial(value, toolItems, array, value4, value5, value6, value7, value8, value9);
	}
}
