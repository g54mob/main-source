using UnityEngine;

namespace TH20
{
	public class ArrivalMethodEntrance : ArrivalMethod
	{
		public ArrivalMethodEntrance(Level level, IArrivedCallback callback)
			: base(level, callback)
		{
		}

		public override bool Update()
		{
			Vector3 randomHospitalEntrance = _level.WorldState.GetRandomHospitalEntrance();
			Character character = _arrivedCallback.OnArrived(randomHospitalEntrance);
			character.Position = randomHospitalEntrance;
			character.NavPath.PutBackInNavWorld();
			character.NavPath.Warp(randomHospitalEntrance);
			return true;
		}

		public override void RestoreFromSave()
		{
		}

		public override bool IsValid()
		{
			return true;
		}

		public override bool IsArriving(Character character)
		{
			return false;
		}
	}
}
