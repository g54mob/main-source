using DV.Logic.Job;
using DV.Utils;

public static class LogicCarExtensions
{
	public static TrainCar TrainCar(this Car car)
	{
		return SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar[car];
	}
}
