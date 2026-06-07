namespace Brewery.Minigames
{
	public class KernelSortLogic
	{
		private readonly int totalKernels;

		private readonly SortDirection[] directionMap;

		private int resolved;

		private int clogs;

		public int TotalKernels => 0;

		public int Resolved => 0;

		public int Clogs => 0;

		public bool IsRoundComplete => false;

		public bool IsPerfect => false;

		public KernelSortLogic(int totalKernels, SortDirection goodDirection, SortDirection badDirection, SortDirection magentaDirection)
		{
		}

		public SortDirection CorrectDirection(KernelKind kind)
		{
			return default(SortDirection);
		}

		public bool ValidateSort(KernelKind kind, SortDirection direction)
		{
			return false;
		}
	}
}
