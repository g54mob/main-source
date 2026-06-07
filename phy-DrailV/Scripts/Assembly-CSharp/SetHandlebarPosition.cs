using System.Linq;
using Bolt;
using LocoSim.Implementations;
using Ludiq;
using UnityEngine;

[UnitTitle("Set Handlebar Position")]
[UnitSubtitle("Set -1 to +1 position of handcar's handlebar")]
[UnitCategory("Train")]
[TypeIcon(typeof(TrainCar))]
public class SetHandlebarPosition : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput trainCarObject;

	[DoNotSerialize]
	public ValueInput positionValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		trainCarObject = ValueInput<GameObject>("Car", null);
		positionValue = ValueInput("Value", 0f);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(trainCarObject));
			if (!trainCar)
			{
				Debug.LogError("Input object is not a train car, skipping.");
				return doneTrigger;
			}
			HandcarDrive handcarDrive = (HandcarDrive)trainCar.SimController.simFlow.OrderedSimComps.FirstOrDefault((SimComponent c) => c is HandcarDrive);
			if (handcarDrive == null)
			{
				Debug.LogError("Handcar drive component not found on train car (" + trainCar.name + "), is this a handcar? Skipping.");
				return doneTrigger;
			}
			handcarDrive.SetHandlebarPosition(flow.GetValue<float>(positionValue));
			return doneTrigger;
		});
		Requirement(trainCarObject, inputTrigger);
	}
}
