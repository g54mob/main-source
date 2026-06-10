namespace Models.Production
{
	public enum ProductionStepType
	{
		None = 0,
		Collect = 1,
		WorkerProduce = 2,
		PassiveProduce = 3,
		SpawnProduct = 4,
		SpawnDismantleProduct = 5
	}
}
