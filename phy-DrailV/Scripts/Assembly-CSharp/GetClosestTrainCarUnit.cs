using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(TrainCar))]
[UnitSubtitle("Find the closest train car within a given radius")]
[UnitTitle("Get Closest Train Car")]
[UnitCategory("Trains")]
public class GetClosestTrainCarUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput foundTrigger;

	[DoNotSerialize]
	public ControlOutput notFoundTrigger;

	[DoNotSerialize]
	public ValueInput targetAnchor;

	[DoNotSerialize]
	public ValueInput searchRadius;

	[DoNotSerialize]
	public ValueInput hasToBeLoco;

	[DoNotSerialize]
	public ValueOutput foundTrainCar;

	protected override void Definition()
	{
		foundTrigger = ControlOutput("Found");
		notFoundTrigger = ControlOutput("Not Found");
		targetAnchor = ValueInput<GameObject>("Origin", null);
		searchRadius = ValueInput("Radius", 10f);
		hasToBeLoco = ValueInput("Only Locos", @default: true);
		foundTrainCar = ValueOutput<GameObject>("Train Car", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(targetAnchor);
			Collider[] array = new Collider[32];
			Vector3 origin = value.transform.position;
			int num = Physics.OverlapSphereNonAlloc(origin, flow.GetValue<float>(searchRadius), array, LayerMask.GetMask("Train_Big_Collider"));
			bool value2 = flow.GetValue<bool>(hasToBeLoco);
			List<TrainCar> list = new List<TrainCar>();
			for (int i = 0; i < num; i++)
			{
				TrainCar trainCar = TrainCar.Resolve(array[i].gameObject);
				if ((bool)trainCar && !trainCar.derailed && (!value2 || trainCar.IsLoco) && !list.Contains(trainCar))
				{
					list.Add(trainCar);
				}
			}
			if (list.Count == 0)
			{
				flow.SetValue(foundTrainCar, null);
				return notFoundTrigger;
			}
			if (list.Count == 1)
			{
				flow.SetValue(foundTrainCar, list[0].gameObject);
				return foundTrigger;
			}
			list.Sort((TrainCar a, TrainCar b) => (a.transform.position - origin).sqrMagnitude.CompareTo((b.transform.position - origin).sqrMagnitude));
			flow.SetValue(foundTrainCar, list[0].gameObject);
			return foundTrigger;
		});
	}
}
