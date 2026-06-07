using UnityEngine;

public static class TrainCarPhysicsExtensions
{
	public static Vector3 GetNextInteriorPositionOffset(this TrainCar car)
	{
		return car.transform.position - car.interior.position;
	}
}
