using Bolt;
using Ludiq;
using UnityEngine;

[UnitCategory("Player")]
[UnitSubtitle("Teleport player to coordinates, transform, or a train car.")]
[UnitTitle("Teleport Player")]
[TypeIcon(typeof(CharacterController))]
public class TeleportPlayerUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput teleportedTrigger;

	[DoNotSerialize]
	public ValueInput targetAnchor;

	[DoNotSerialize]
	public ValueInput offsetVector;

	[DoNotSerialize]
	public ValueInput allowTrainCars;

	protected override void Definition()
	{
		teleportedTrigger = ControlOutput("Teleported");
		targetAnchor = ValueInput<GameObject>("Target", null);
		offsetVector = ValueInput("Offset", Vector3.zero);
		allowTrainCars = ValueInput("Allow cars", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(targetAnchor);
			if (value != null && flow.GetValue<bool>(allowTrainCars))
			{
				TrainCar trainCar = TrainCar.Resolve(value);
				if (trainCar != null)
				{
					PlayerManager.TeleportPlayerToCar(trainCar);
					return teleportedTrigger;
				}
			}
			Vector3 vector = flow.GetValue<Vector3>(offsetVector);
			Quaternion rotation = (PlayerManager.PlayerTransform ? PlayerManager.PlayerTransform.rotation : Quaternion.identity);
			if (value != null)
			{
				vector = value.transform.TransformPoint(vector);
				rotation = value.transform.rotation;
			}
			PlayerManager.TeleportPlayer(vector, rotation, value ? value.transform : null, useRotation: true);
			return teleportedTrigger;
		});
	}
}
