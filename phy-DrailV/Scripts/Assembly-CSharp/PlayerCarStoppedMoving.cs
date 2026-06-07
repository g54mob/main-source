using Bolt;
using Ludiq;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("Trains")]
[UnitTitle("Player Car Stopped")]
[UnitSubtitle("Player's current car comes to a stop")]
public class PlayerCarStoppedMoving : GenericWaitForConditionWithMessage
{
	protected override string DoneFieldName => "Parked";

	protected override void InternalDefinition()
	{
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		if (PlayerManager.Car != null)
		{
			return IsStopped(PlayerManager.Car);
		}
		return false;
	}

	private static bool IsStopped(TrainCar car)
	{
		return car.GetAbsSpeed() <= 0.1f;
	}
}
