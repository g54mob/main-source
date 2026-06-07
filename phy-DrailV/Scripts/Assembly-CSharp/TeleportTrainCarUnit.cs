using System.Collections;
using Bolt;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Teleport train car to coordinates or transform, optionally couple to another.")]
[TypeIcon(typeof(CharacterController))]
[UnitCategory("Train")]
[UnitTitle("Teleport Train Car")]
public class TeleportTrainCarUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput teleportedTrigger;

	[DoNotSerialize]
	public ValueInput trainCarObject;

	[DoNotSerialize]
	public ValueInput targetAnchor;

	[DoNotSerialize]
	public ValueInput offsetVector;

	[DoNotSerialize]
	public ValueInput coupleToObject;

	protected override void Definition()
	{
		teleportedTrigger = ControlOutput("Teleported");
		trainCarObject = ValueInput<GameObject>("Car", null);
		targetAnchor = ValueInput<GameObject>("Target", null);
		offsetVector = ValueInput("Offset", Vector3.zero);
		coupleToObject = ValueInput<GameObject>("Couple to", null);
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(targetAnchor);
		Vector3 vector = flow.GetValue<Vector3>(offsetVector);
		Quaternion quaternion = Quaternion.identity;
		if (value != null)
		{
			vector = value.transform.TransformPoint(vector);
			quaternion = value.transform.rotation;
		}
		int closestNodeIndex;
		RailTrack trackClosestTo = CarSpawner.GetTrackClosestTo(vector, 0.01f, out closestNodeIndex);
		TrainCar car = TrainCar.Resolve(flow.GetValue<GameObject>(trainCarObject));
		TrainCar coupleTo = TrainCar.Resolve(flow.GetValue<GameObject>(coupleToObject));
		car.rb.velocity = Vector3.zero;
		car.rb.angularVelocity = Vector3.zero;
		car.stress.ResetTrainStress();
		if (car.derailed)
		{
			car.Rerail(trackClosestTo, vector, quaternion * Vector3.forward);
		}
		else
		{
			car.MoveToTrackWithCarUncouple(trackClosestTo, vector, quaternion * Vector3.forward);
		}
		while (car.IsTeleporting)
		{
			yield return null;
		}
		car.rb.velocity = Vector3.zero;
		car.rb.angularVelocity = Vector3.zero;
		car.stress.ResetTrainStress();
		yield return WaitFor.FixedUpdate;
		if ((bool)coupleTo)
		{
			int num = 0;
			int num2 = 0;
			float num3 = float.PositiveInfinity;
			float num4 = float.PositiveInfinity;
			for (int i = 0; i < car.couplers.Length; i++)
			{
				float sqrMagnitude = (car.couplers[i].transform.position - coupleTo.transform.position).sqrMagnitude;
				if (sqrMagnitude < num3)
				{
					num = i;
					num3 = sqrMagnitude;
				}
			}
			for (int j = 0; j < coupleTo.couplers.Length; j++)
			{
				float sqrMagnitude2 = (coupleTo.couplers[j].transform.position - car.transform.position).sqrMagnitude;
				if (sqrMagnitude2 < num4)
				{
					num2 = j;
					num4 = sqrMagnitude2;
				}
			}
			Coupler obj = car.couplers[num];
			Coupler other = coupleTo.couplers[num2];
			obj.CoupleTo(other, playAudio: false);
		}
		car.rb.velocity = Vector3.zero;
		car.rb.angularVelocity = Vector3.zero;
		car.stress.ResetTrainStress();
		yield return WaitFor.FixedUpdate;
		car.rb.velocity = Vector3.zero;
		car.rb.angularVelocity = Vector3.zero;
		car.stress.ResetTrainStress();
		yield return teleportedTrigger;
	}
}
