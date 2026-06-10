using System;
using Models.Production;
using NSMedieval.Model;

namespace NSMedieval.State
{
	public static class ProductionStepFactory
	{
		public static ProductionStepInstance ProduceStep(ProductionInstance owner, ProductionStep blueprint)
		{
			return blueprint.Type switch
			{
				ProductionStepType.WorkerProduce => new ProductionStepWorker(), 
				ProductionStepType.Collect => new ProductionStepCollect(), 
				ProductionStepType.PassiveProduce => new ProductionStepPassive(), 
				ProductionStepType.SpawnProduct => new ProductionStepSpawnProduct(), 
				ProductionStepType.SpawnDismantleProduct => new ProductionStepSpawnDismantleProduct(), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
