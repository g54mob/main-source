using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitCategory("Trains")]
[UnitTitle("Get Train By GUID")]
[UnitSubtitle("Get the train car object by its GUID")]
[TypeIcon(typeof(ScriptableObject))]
public class GetTrainCarByGUID : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput guidValue;

	[DoNotSerialize]
	public ValueOutput trainCar;

	[DoNotSerialize]
	public ControlOutput gotTrigger;

	protected override void Definition()
	{
		gotTrigger = ControlOutput("Got");
		guidValue = ValueInput<string>("GUID");
		trainCar = ValueOutput<GameObject>("Train Car");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCarByCarGuid = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(flow.GetValue<string>(guidValue));
			flow.SetValue(trainCar, trainCarByCarGuid.gameObject);
			return gotTrigger;
		});
	}
}
