using System;
using Bolt;
using DV.Customization.Gadgets;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Player")]
[UnitSubtitle("Allow only specific gadgets to be used")]
[UnitTitle("Gadget Restriction")]
public class GadgetRestrictionUnit : Unit
{
	public enum Mode
	{
		AllowAll = 0,
		DenyAll = 1,
		AllowNames = 2,
		AllowInstances = 3
	}

	[DoNotSerialize]
	public ValueInput[] nameValues;

	[DoNotSerialize]
	public ValueInput[] instanceValues;

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[Inspectable]
	[UnitHeaderInspectable("Mode")]
	public Mode MO { get; set; }

	[UnitHeaderInspectable("Count")]
	[Inspectable]
	public int Count { get; set; } = 1;

	protected override void Definition()
	{
		if (MO == Mode.DenyAll || MO == Mode.AllowAll)
		{
			nameValues = null;
			instanceValues = null;
		}
		else if (MO == Mode.AllowNames)
		{
			int num = Mathf.Clamp(Count, 1, 16);
			nameValues = new ValueInput[num];
			for (int i = 0; i < num; i++)
			{
				nameValues[i] = ValueInput("Name " + (i + 1), "");
			}
			instanceValues = null;
		}
		else if (MO == Mode.AllowInstances)
		{
			int num2 = Mathf.Clamp(Count, 1, 16);
			instanceValues = new ValueInput[num2];
			for (int j = 0; j < num2; j++)
			{
				instanceValues[j] = ValueInput<GameObject>("Instance " + (j + 1), null);
			}
			nameValues = null;
		}
		else
		{
			Debug.LogError($"Mode {MO} is not implemented yet in {GetType()}, will just skip over.");
		}
		doneTrigger = ControlOutput("Done");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			switch (MO)
			{
			case Mode.AllowAll:
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = null;
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = null;
				break;
			case Mode.DenyAll:
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = Array.Empty<string>();
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = Array.Empty<GameObject>();
				break;
			case Mode.AllowNames:
			{
				string[] array2 = new string[nameValues.Length];
				for (int l = 0; l < nameValues.Length; l++)
				{
					array2[l] = flow.GetValue<string>(nameValues[l]);
				}
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = array2;
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = null;
				break;
			}
			case Mode.AllowInstances:
			{
				GameObject[] array = new GameObject[nameValues.Length];
				for (int k = 0; k < nameValues.Length; k++)
				{
					array[k] = flow.GetValue<GameObject>(instanceValues[k]);
				}
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetNames = null;
				SingletonBehaviour<GadgetSystemUtility>.Instance.AllowedGadgetInstances = array;
				break;
			}
			default:
				Debug.LogError($"Mode {MO} is not implemented yet in {GetType()}, will just skip over.");
				break;
			}
			return doneTrigger;
		});
	}
}
