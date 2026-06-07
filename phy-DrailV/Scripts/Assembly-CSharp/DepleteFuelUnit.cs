using Bolt;
using LocoSim.Resources;
using Ludiq;
using UnityEngine;

[UnitTitle("Deplete Fuel")]
[UnitCategory("Trains")]
[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Make sure fuel is not above a given percentage on a locomotive.")]
public class DepleteFuelUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput depletedTrigger;

	[DoNotSerialize]
	public ValueInput targetLoco;

	[DoNotSerialize]
	public ValueInput percentageMax;

	protected override void Definition()
	{
		depletedTrigger = ControlOutput("Depleted");
		targetLoco = ValueInput<GameObject>("Loco", null);
		percentageMax = ValueInput("Percentage", 80f);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(targetLoco));
			float value = flow.GetValue<float>(percentageMax);
			(trainCar.SimController?.resourceContainerController).ClampResourceContainer(ResourceContainerType.FUEL, value * 0.01f);
			return depletedTrigger;
		});
	}
}
