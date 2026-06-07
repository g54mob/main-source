using DV.Simulation.Cars;

public class RearConnectedDualCarAutomaticHeadlightsController : AutomaticHeadlightsController
{
	protected override bool HoseConnected(bool front)
	{
		Coupler coupler;
		if (front)
		{
			coupler = trainCar.frontCoupler;
		}
		else
		{
			Coupler rearCoupler = trainCar.rearCoupler;
			if (rearCoupler == null)
			{
				return false;
			}
			Coupler coupledTo = rearCoupler.coupledTo;
			if (coupledTo == null)
			{
				return false;
			}
			TrainCar train = coupledTo.train;
			coupler = ((train != null) ? train.rearCoupler : null);
		}
		if (coupler != null && coupler.hoseAndCock != null)
		{
			return coupler.hoseAndCock.IsHoseConnected;
		}
		return false;
	}
}
