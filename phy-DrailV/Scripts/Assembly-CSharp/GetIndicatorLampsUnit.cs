using Bolt;
using DV.HUD;
using Ludiq;
using UnityEngine;

[UnitCategory("Trains")]
[UnitSubtitle("Get LocoLampReader component from a loco")]
[UnitTitle("Get Indicator Lamps")]
[TypeIcon(typeof(Light))]
public class GetIndicatorLampsUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput locoValue;

	[DoNotSerialize]
	public ValueOutput readerValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		locoValue = ValueInput<GameObject>("Loco", null);
		readerValue = ValueOutput<LocoLampReader>("Lamps", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(locoValue));
			if (trainCar == null)
			{
				Debug.LogError("Couldn't find the train, so no indicator lamps can be found!");
				return doneTrigger;
			}
			if (trainCar.interior == null && trainCar.loadedExternalInteractables == null)
			{
				Debug.LogError("Train's controls aren't loaded, nowhere to search for lamps. (no interior nor loadedExternalInteractables)");
				return doneTrigger;
			}
			LocoLampReader locoLampReader = null;
			if (trainCar.interior != null)
			{
				locoLampReader = trainCar.interior.GetComponentInChildren<LocoLampReader>();
			}
			if (locoLampReader == null && trainCar.loadedExternalInteractables != null)
			{
				locoLampReader = trainCar.loadedExternalInteractables.GetComponentInChildren<LocoLampReader>();
			}
			if (locoLampReader == null)
			{
				Debug.LogError("Couldn't find the LocoLampReader component on the train!");
			}
			flow.SetValue(readerValue, locoLampReader);
			return doneTrigger;
		});
	}
}
