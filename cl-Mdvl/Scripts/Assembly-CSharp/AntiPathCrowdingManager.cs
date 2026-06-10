using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

public class AntiPathCrowdingManager : IGameDisposable, IDisposable
{
	private readonly Dictionary<MapNode, uint> nodeToPenalty;

	private readonly Dictionary<PathfinderAgentDriver, List<MapNode>> driverToLastStartedPath;

	private readonly object penaltiesLock;

	public bool HasDisposed { get; private set; }

	public event Action<IGameDisposable> OnDisposedEvent;

	public AntiPathCrowdingManager()
	{
		nodeToPenalty = new Dictionary<MapNode, uint>();
		driverToLastStartedPath = new Dictionary<PathfinderAgentDriver, List<MapNode>>();
		penaltiesLock = new object();
	}

	public uint GetPathCount(MapNode node)
	{
		if (HasDisposed)
		{
			return 0u;
		}
		lock (penaltiesLock)
		{
			return nodeToPenalty.GetValueOrDefault(node, 0u);
		}
	}

	public void OnAgentStartTraversingPath(PathfinderAgentDriver driver)
	{
		if (HasDisposed)
		{
			return;
		}
		lock (penaltiesLock)
		{
			if (!driverToLastStartedPath.TryGetValue(driver, out var value))
			{
				value = new List<MapNode>();
				driverToLastStartedPath[driver] = value;
			}
			value.Clear();
			foreach (MapNode item in driver.CurrentPath.NodePath)
			{
				value.Add(item);
				nodeToPenalty.TryAdd(item, 0u);
				nodeToPenalty[item]++;
			}
			RefreshNodePenalties(value, value.Count);
		}
	}

	public void OnAgentStopTraversingPath(PathfinderAgentDriver driver, PathDriverCompletionState completionState)
	{
		if (HasDisposed)
		{
			return;
		}
		lock (penaltiesLock)
		{
			if (!driverToLastStartedPath.TryGetValue(driver, out var value))
			{
				return;
			}
			int num = 0;
			foreach (MapNode item in value)
			{
				if (!nodeToPenalty.TryGetValue(item, out var value2))
				{
					continue;
				}
				if (value2 == 0)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(96, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AntiPathCrowdingManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("NodeToPenalty tried to decrement penalty for node ");
						messageBuilder.AppendFormatted(item.Position);
						messageBuilder.AppendLiteral(", but it was already 0. This should not happen");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					nodeToPenalty[item]--;
					num++;
				}
			}
			RefreshNodePenalties(value, -num);
			driverToLastStartedPath.Remove(driver);
		}
	}

	private static void RefreshNodePenalties(List<MapNode> nodes, int delta)
	{
		foreach (MapNode node in nodes)
		{
			node.DirectIncrementPenalties((PathfindingPenalty penalty) => penalty.AntiPathCrowdingPenaltyEnabled, 20 * delta);
		}
	}

	public void Dispose()
	{
		HasDisposed = true;
		nodeToPenalty.Clear();
		driverToLastStartedPath.Clear();
		if (!LoadingController.IsLeavingMainScene)
		{
			this.OnDisposedEvent?.Invoke(this);
		}
		this.OnDisposedEvent = null;
		nodeToPenalty.Clear();
		driverToLastStartedPath.Clear();
	}
}
