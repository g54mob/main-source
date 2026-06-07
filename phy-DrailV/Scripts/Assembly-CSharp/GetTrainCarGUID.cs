using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Get Train Car GUID")]
[UnitSubtitle("Get the unique identified of a given train car")]
[UnitCategory("Trains")]
[TypeIcon(typeof(ScriptableObject))]
public class GetTrainCarGUID : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput trainCar;

	[DoNotSerialize]
	public ValueOutput guidValue;

	[DoNotSerialize]
	public ControlOutput gotTrigger;

	protected override void Definition()
	{
		gotTrigger = ControlOutput("Got");
		trainCar = ValueInput<GameObject>("Train Car", null);
		guidValue = ValueOutput<string>("GUID");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(this.trainCar));
			flow.SetValue(guidValue, trainCar.CarGUID);
			return gotTrigger;
		});
	}
}
