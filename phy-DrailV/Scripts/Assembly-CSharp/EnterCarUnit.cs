using Bolt;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Player enters a train car")]
[UnitCategory("Trains")]
[TypeIcon(typeof(TrainCar))]
[UnitTitle("Enter Train Car")]
public class EnterCarUnit : GenericWaitForConditionWithMessage
{
	[DoNotSerialize]
	public ValueInput trainCarObject;

	protected override string DoneFieldName => "Entered";

	protected override void InternalDefinition()
	{
		trainCarObject = ValueInput<GameObject>("Car", null);
	}

	public override object PrepareContext(Flow flow)
	{
		return TrainCar.Resolve(flow.GetValue<GameObject>(trainCarObject));
	}

	protected override GameObject GetMessageAnchor(Flow flow, object context)
	{
		TrainCar trainCar = (TrainCar)context;
		GameObject messageAnchor = base.GetMessageAnchor(flow, context);
		if (!messageAnchor)
		{
			return trainCar.gameObject;
		}
		return messageAnchor;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		TrainCar trainCar = (TrainCar)context;
		return PlayerManager.Car == trainCar;
	}
}
