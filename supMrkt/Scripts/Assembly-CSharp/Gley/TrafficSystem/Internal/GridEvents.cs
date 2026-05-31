using System.Runtime.CompilerServices;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	public class GridEvents
	{
		public delegate void ActiveGridCellsChanged(CellData[] activeCells);

		public static event ActiveGridCellsChanged OnActiveGridCellsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void TriggerActiveGridCellsChangedEvent(CellData[] activeCells)
		{
		}
	}
}
