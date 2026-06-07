using System;
using Bolt;
using DV.ServicePenalty.UI;
using Ludiq;
using UnityEngine;

[UnitCategory("Interaction")]
[UnitTitle("Find Closest Career Manager")]
[UnitSubtitle("Get the closest Career Manager relative to a given origin point")]
[TypeIcon(typeof(CareerManagerInputHandler))]
public class FindClosestCareerManager : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput foundTrigger;

	[DoNotSerialize]
	public ValueInput originObject;

	[DoNotSerialize]
	public ValueOutput managerOutput;

	protected override void Definition()
	{
		foundTrigger = ControlOutput("Found");
		originObject = ValueInput<GameObject>("Origin", null);
		managerOutput = ValueOutput<GameObject>("Manager");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			Vector3 origin = flow.GetValue<GameObject>(originObject).transform.position;
			CareerManagerInputHandler[] array = UnityEngine.Object.FindObjectsOfType<CareerManagerInputHandler>();
			if (array.Length == 0)
			{
				flow.SetValue(managerOutput, null);
			}
			else if (array.Length == 1)
			{
				flow.SetValue(managerOutput, array[0].gameObject);
			}
			else
			{
				Array.Sort(array, (CareerManagerInputHandler a, CareerManagerInputHandler b) => (a.transform.position - origin).sqrMagnitude.CompareTo((b.transform.position - origin).sqrMagnitude));
				flow.SetValue(managerOutput, array[0].gameObject);
			}
			return foundTrigger;
		});
	}
}
