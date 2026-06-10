namespace NSMedieval.State
{
	public struct SkepProductionMultiplierData
	{
		public int PlantsCount;

		public int SkepCount;

		public float LastMultiplier;

		public float TotalPlantBonus;

		public float TotalSkepPenalty;

		public ConcurrentHashSet<PlantMapResourceInstance> Plants;
	}
}
