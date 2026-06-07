using System.Collections.Generic;

public class EnergyGridManager : SceneBehaviour
{
	private static readonly List<EnergyGrid> _grids = new List<EnergyGrid>();

	public static IReadOnlyList<EnergyGrid> Grids => _grids;

	private void LateUpdate()
	{
		foreach (EnergyGrid grid in _grids)
		{
			grid.CalculateEfficiency();
		}
	}

	private void OnDestroy()
	{
		_grids.Clear();
	}

	public static EnergyGrid AddGrid()
	{
		EnergyGrid energyGrid = new EnergyGrid();
		_grids.Add(energyGrid);
		new EnergyGridEvent(GameEventType.EnergyGridsUpdated, energyGrid).Dispatch();
		return energyGrid;
	}

	public static void RemoveGrid(EnergyGrid grid)
	{
		_grids.Remove(grid);
		new EnergyGridEvent(GameEventType.EnergyGridsUpdated, grid).Dispatch();
	}

	public static void RestoreReferences()
	{
		List<KeyValuePair<EnergyGridConnector, EnergyGridConnector>> list = new List<KeyValuePair<EnergyGridConnector, EnergyGridConnector>>();
		foreach (EnergyGrid grid in Grids)
		{
			foreach (EnergyGridConnector link in grid.Links)
			{
				EnergyGridConnector[] connections = link.Connections;
				foreach (EnergyGridConnector energyGridConnector in connections)
				{
					if (energyGridConnector != null && !energyGridConnector.Connections.Contains(link))
					{
						list.Add(new KeyValuePair<EnergyGridConnector, EnergyGridConnector>(energyGridConnector, link));
					}
				}
			}
		}
		foreach (KeyValuePair<EnergyGridConnector, EnergyGridConnector> item in list)
		{
			item.Key.Connect(item.Value);
			if (_grids.Contains(item.Value.EnergyGrid))
			{
				item.Key.EnergyGrid.Merge(item.Value.EnergyGrid);
			}
		}
	}
}
