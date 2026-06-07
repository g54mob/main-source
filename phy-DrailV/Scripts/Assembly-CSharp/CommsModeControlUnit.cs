using System;
using System.Linq;
using Bolt;
using DV;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Enable or disable comms radio operation modes.")]
[UnitTitle("Comms Mode Control")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(BoxCollider))]
public class CommsModeControlUnit : Unit
{
	public enum ControlType
	{
		Activate = 0,
		Deactivate = 1,
		Toggle = 2
	}

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput allExceptValue;

	[DoNotSerialize]
	public ValueInput modeValue;

	[DoNotSerialize]
	public ValueInput controlValue;

	[DoNotSerialize]
	public ControlOutput enabledTrigger;

	protected override void Definition()
	{
		enabledTrigger = ControlOutput("Done");
		allExceptValue = ValueInput("All except", @default: false);
		modeValue = ValueInput("Mode", CommsRadioModesEnum.RerailController);
		controlValue = ValueInput("Control", ControlType.Activate);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			bool value = flow.GetValue<bool>(allExceptValue);
			CommsRadioModesEnum targetMode = flow.GetValue<CommsRadioModesEnum>(modeValue);
			CommsRadioModesEnum[] obj = (value ? ((CommsRadioModesEnum[])Enum.GetValues(typeof(CommsRadioModesEnum))).Where((CommsRadioModesEnum m) => m != targetMode).ToArray() : new CommsRadioModesEnum[1] { targetMode });
			CommsRadioController component = SingletonBehaviour<Inventory>.Instance.GetItemByName("CommsRadio", partialNameCheck: false).GetComponent<CommsRadioController>();
			ControlType value2 = flow.GetValue<ControlType>(controlValue);
			CommsRadioModesEnum[] array = obj;
			foreach (CommsRadioModesEnum value3 in array)
			{
				switch (value2)
				{
				case ControlType.Activate:
					component.ActivateMode(value3.ToType());
					break;
				case ControlType.Deactivate:
					component.DeactivateMode(value3.ToType());
					break;
				case ControlType.Toggle:
					if (component.IsModeActivated(value3.ToType()))
					{
						component.DeactivateMode(value3.ToType());
					}
					else
					{
						component.ActivateMode(value3.ToType());
					}
					break;
				}
			}
			return enabledTrigger;
		});
	}
}
