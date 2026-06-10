using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class WorkerBaseRepository : DynamicJsonRepository<WorkerBaseRepository, Worker>
	{
		private Worker baseWorker;

		public Worker BaseWorker
		{
			get
			{
				if (!(baseWorker == null))
				{
					return baseWorker;
				}
				return baseWorker = GetFirst();
			}
		}

		protected override string JsonFile()
		{
			return "Worker/WorkerBase.json";
		}
	}
}
