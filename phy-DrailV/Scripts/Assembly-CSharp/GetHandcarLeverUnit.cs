using System.Collections.Generic;
using System.Linq;
using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Trains")]
[UnitTitle("Get Handcar Lever")]
[UnitSubtitle("Get handcar lever object and offset for pointing at it")]
[TypeIcon(typeof(TrainCar))]
public class GetHandcarLeverUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput outputTrigger;

	[DoNotSerialize]
	public ValueInput handcarObjectValue;

	[DoNotSerialize]
	public ValueOutput leverTransform;

	[DoNotSerialize]
	public ValueOutput leverOffset;

	protected override void Definition()
	{
		outputTrigger = ControlOutput("Output");
		handcarObjectValue = ValueInput<GameObject>("Handcar", null);
		leverTransform = ValueOutput<GameObject>("Object");
		leverOffset = ValueOutput<Vector3>("Offset");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(handcarObjectValue));
			if (trainCar == null)
			{
				Debug.LogError("Can't find the TrainCar");
				return outputTrigger;
			}
			Transform lever = trainCar.transform.Find("LocoHandcar_Body/crank mechanism/V handlebar");
			List<Vector3> list = new List<Vector3>
			{
				new Vector3(0f, 0f, 0.71f),
				new Vector3(0f, 0f, -0.71f)
			};
			List<Vector3> list2 = list.Select((Vector3 p) => lever.TransformPoint(p)).ToList();
			Vector3 vector = PlayerManager.PlayerCamera.transform.position;
			if ((vector - list2[0]).sqrMagnitude < (vector - list2[1]).sqrMagnitude)
			{
				flow.SetValue(leverOffset, list[0]);
			}
			else
			{
				flow.SetValue(leverOffset, list[1]);
			}
			flow.SetValue(leverTransform, lever.gameObject);
			return outputTrigger;
		});
	}
}
