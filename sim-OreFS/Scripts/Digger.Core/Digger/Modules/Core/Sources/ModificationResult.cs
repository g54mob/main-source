namespace Digger.Modules.Core.Sources
{
	public struct ModificationResult
	{
		public double RemovedMatterQuantity;

		public double AddedMatterQuantity;

		public int TotalModifiedVoxels;

		public double AverageChangePerVoxel
		{
			get
			{
				if (TotalModifiedVoxels <= 0)
				{
					return 0.0;
				}
				return (RemovedMatterQuantity + AddedMatterQuantity) / (double)TotalModifiedVoxels;
			}
		}

		public static ModificationResult Empty => new ModificationResult
		{
			RemovedMatterQuantity = 0.0,
			AddedMatterQuantity = 0.0,
			TotalModifiedVoxels = 0
		};

		public static ModificationResult Aggregate(ModificationResult a, ModificationResult b)
		{
			return new ModificationResult
			{
				RemovedMatterQuantity = a.RemovedMatterQuantity + b.RemovedMatterQuantity,
				AddedMatterQuantity = a.AddedMatterQuantity + b.AddedMatterQuantity,
				TotalModifiedVoxels = a.TotalModifiedVoxels + b.TotalModifiedVoxels
			};
		}

		public void Add(ModificationResult other)
		{
			RemovedMatterQuantity += other.RemovedMatterQuantity;
			AddedMatterQuantity += other.AddedMatterQuantity;
			TotalModifiedVoxels += other.TotalModifiedVoxels;
		}
	}
}
