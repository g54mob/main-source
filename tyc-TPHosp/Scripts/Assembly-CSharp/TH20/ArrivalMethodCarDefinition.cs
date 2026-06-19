namespace TH20
{
	public class ArrivalMethodCarDefinition : ArrivalMethodVehicleDefinition
	{
		public override bool IsAvailable()
		{
			return ArrivalCarComponent.IsAvailable();
		}

		public override bool IsSpawnPointFree()
		{
			return ArrivalCarComponent.IsSpawnPointFree();
		}

		public override int Reserve()
		{
			return ArrivalCarComponent.Reserve();
		}

		public override void Free(int spawnID)
		{
			ArrivalCarComponent.Free(spawnID);
		}

		public override bool ValidArrivalComponent(int id)
		{
			return ArrivalCarComponent.ValidArrivalComponent(id);
		}

		public override ArrivalBaseComponent GetArrivalComponent(int id)
		{
			return ArrivalCarComponent.GetArrivalComponent(id);
		}

		public override void RestoreFromSave(int id)
		{
			ArrivalCarComponent.RestoreFromSave(id);
		}

		public override int TotalSpawnPoints()
		{
			return ArrivalCarComponent.TotalSpawnPoints();
		}

		public override int TotalFreeSpawnPoints()
		{
			return ArrivalCarComponent.TotalFreeSpawnPoints();
		}
	}
}
