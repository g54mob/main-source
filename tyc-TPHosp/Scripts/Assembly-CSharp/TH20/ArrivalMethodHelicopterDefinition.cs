namespace TH20
{
	public class ArrivalMethodHelicopterDefinition : ArrivalMethodVehicleDefinition
	{
		public override bool IsAvailable()
		{
			return ArrivalHelipadComponent.IsAvailable();
		}

		public override bool IsSpawnPointFree()
		{
			return ArrivalHelipadComponent.IsSpawnPointFree();
		}

		public override int Reserve()
		{
			return ArrivalHelipadComponent.Reserve();
		}

		public override void Free(int id)
		{
			ArrivalHelipadComponent.Free(id);
		}

		public override bool ValidArrivalComponent(int id)
		{
			return ArrivalHelipadComponent.ValidArrivalComponent(id);
		}

		public override ArrivalBaseComponent GetArrivalComponent(int id)
		{
			return ArrivalHelipadComponent.GetArrivalComponent(id);
		}

		public override void RestoreFromSave(int id)
		{
			ArrivalHelipadComponent.RestoreFromSave(id);
		}

		public override int TotalSpawnPoints()
		{
			return ArrivalHelipadComponent.TotalSpawnPoints();
		}

		public override int TotalFreeSpawnPoints()
		{
			return ArrivalHelipadComponent.TotalFreeSpawnPoints();
		}
	}
}
