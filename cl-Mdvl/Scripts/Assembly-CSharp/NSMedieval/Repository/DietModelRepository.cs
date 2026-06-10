using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class DietModelRepository : DynamicJsonRepository<DietModelRepository, DietModel>
	{
		public const string WorkerDietModelId = "worker";

		public const string WorkerDrinkDietModelId = "worker_drink";

		private DietModel workerDietModel;

		public DietModel WorkerDietModel
		{
			get
			{
				if (workerDietModel == null)
				{
					workerDietModel = GetByID("worker");
				}
				return workerDietModel;
			}
		}

		protected override string JsonFile()
		{
			return "Creature/DietModelRepository.json";
		}
	}
}
