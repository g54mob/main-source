using System.Collections.Generic;

namespace TH20
{
	public class ArrivalMethodRandomHospitalLocation : ArrivalMethod
	{
		public ArrivalMethodRandomHospitalLocation(Level level, IArrivedCallback arrivedCallback)
			: base(level, arrivedCallback)
		{
		}

		public override bool Update()
		{
			List<HospitalMap> list = new List<HospitalMap>(_level.WorldState.HospitalMaps);
			list.RemoveAll((HospitalMap map) => !map.Room.IsOpen);
			RoomAlgorithms.GetRandomFreeTile(list.RandomItem().FloorPlan, out var worldPosition);
			Character character = _arrivedCallback.OnArrived(worldPosition);
			character.Position = worldPosition;
			character.NavPath.PutBackInNavWorld();
			character.NavPath.Warp(worldPosition);
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
