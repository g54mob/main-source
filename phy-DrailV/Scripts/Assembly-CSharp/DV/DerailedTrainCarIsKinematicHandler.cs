using DV.Utils;

namespace DV
{
	public class DerailedTrainCarIsKinematicHandler
	{
		private readonly TrainCar train;

		public DerailedTrainCarIsKinematicHandler(TrainCar train)
		{
			this.train = train;
			UpdateIsKinematicDependingOnLoadedCells();
			SingletonBehaviour<WorldStreamingInit>.Instance.TerrainsOrScenesLoadStateChanged += UpdateIsKinematicDependingOnLoadedCells;
		}

		public void Destroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<WorldStreamingInit>.Instance.TerrainsOrScenesLoadStateChanged -= UpdateIsKinematicDependingOnLoadedCells;
				train.rb.isKinematic = false;
			}
		}

		protected void UpdateIsKinematicDependingOnLoadedCells()
		{
			bool flag = SingletonBehaviour<WorldStreamingInit>.Instance.IsSceneAndTerrainCellLoaded(train.transform.position);
			train.rb.isKinematic = !flag;
		}
	}
}
