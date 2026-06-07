using Bolt;
using DV.Simulation.Brake;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Get the handbrake object on a given train car")]
[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitTitle("Get Handbrake")]
public class GetHandbrakeTransformUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput trainCar;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueOutput handbrakeObject;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		trainCar = ValueInput<GameObject>("Car", null);
		handbrakeObject = ValueOutput<GameObject>("Handbrake", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(this.trainCar));
			if (!trainCar.brakeSystem.hasHandbrake)
			{
				flow.SetValue(handbrakeObject, null);
				return doneTrigger;
			}
			HandbrakeFeedersController componentInChildren = trainCar.interior.GetComponentInChildren<HandbrakeFeedersController>();
			Transform transform = null;
			if (componentInChildren.entries == null || componentInChildren.entries.Length == 0)
			{
				Debug.LogError("There are no handbrakes on this car!", trainCar);
				flow.SetValue(handbrakeObject, null);
				return doneTrigger;
			}
			if (componentInChildren.entries.Length == 1 || PlayerManager.PlayerTransform == null)
			{
				transform = componentInChildren.entries[0].transform;
			}
			else
			{
				Vector3 vector = PlayerManager.PlayerTransform.position;
				int num = 0;
				float num2 = (componentInChildren.entries[num].transform.position - vector).sqrMagnitude;
				for (int i = 1; i < componentInChildren.entries.Length; i++)
				{
					float sqrMagnitude = (componentInChildren.entries[i].transform.position - vector).sqrMagnitude;
					if (sqrMagnitude < num2)
					{
						num = i;
						num2 = sqrMagnitude;
					}
				}
				transform = componentInChildren.entries[num].transform;
			}
			flow.SetValue(handbrakeObject, transform.gameObject);
			return doneTrigger;
		});
	}
}
