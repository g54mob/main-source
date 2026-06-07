using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class TownQueryCache : MonoBehaviour
{
	public class Path : IPathfindingNodeDisposedListener
	{
		private float _leveledDistanceSquared;

		public IPathfindingNodeProvider From { get; private set; }

		public IPathfindingNodeProvider To { get; private set; }

		public TownQuery Query { get; private set; }

		public ListPool<PathfindingNode>.List Nodes { get; private set; }

		public Path(IPathfindingNodeProvider from, IPathfindingNodeProvider to)
		{
			From = from;
			To = to;
			_leveledDistanceSquared = From.transform.position.DistanceToLeveledSquared(To.transform.position);
			TryQueueQuery();
		}

		public void OnPathfindingNodeDisposed(PathfindingNode disposedNode)
		{
			if (Nodes == null)
			{
				Debug.LogException(new Exception("TownQueryCache.Path.Nodes == NULL"));
			}
			else
			{
				ClearNodes();
			}
		}

		public void Dispose()
		{
			Query?.CompletedEvent.RemoveListener(OnQueryCompleted);
			ClearNodes();
		}

		private bool TryQueueQuery()
		{
			if (IsDead() || Query != null)
			{
				return false;
			}
			Query = TownQuery.Get(From, To);
			Query.CompletedEvent.AddListener(OnQueryCompleted);
			Pathfinder.QueueQuery(Query);
			return true;
		}

		private void OnQueryCompleted(TownQuery query)
		{
			query.CompletedEvent.RemoveListener(OnQueryCompleted);
			if (Query == query)
			{
				if (query.PathFound)
				{
					Nodes = ListPool<PathfindingNode>.Get(query.Path);
					foreach (PathfindingNode node in Nodes)
					{
						node.SubscribeDisposedListener(this);
					}
				}
				Query = null;
			}
			else
			{
				Debug.LogException(new Exception("TownQueryCache.Path.OnQueryCompleted queries do not match!"));
			}
		}

		private void ClearNodes()
		{
			if (Nodes == null)
			{
				return;
			}
			foreach (PathfindingNode node in Nodes)
			{
				if (node == null)
				{
					Debug.LogException(new Exception("TownQueryCache.Path is subscribed to PathfindingNode == NULL"));
				}
				else
				{
					node.UnsubscribeDisposedListener(this);
				}
			}
			Nodes.Dispose();
			Nodes = null;
		}

		public bool IsMatch(IPathfindingNodeProvider fromToMatch, IPathfindingNodeProvider toToMatch)
		{
			if (fromToMatch != From || toToMatch != To)
			{
				if (fromToMatch == To)
				{
					return toToMatch == From;
				}
				return false;
			}
			return true;
		}

		public bool IsDead()
		{
			if (From != null)
			{
				return To == null;
			}
			return true;
		}

		public float ReturnDistance()
		{
			if (Nodes.IsNullOrEmpty())
			{
				TryQueueQuery();
				return _leveledDistanceSquared;
			}
			return Nodes.Count;
		}
	}

	private static TownQueryCache _instance;

	private Dictionary<IPathfindingNodeProvider, List<Path>> _paths = new Dictionary<IPathfindingNodeProvider, List<Path>>();

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
		Dictionary<IPathfindingNodeProvider, List<Path>>.Enumerator enumerator = _paths.GetEnumerator();
		while (enumerator.MoveNext())
		{
			foreach (Path item in enumerator.Current.Value)
			{
				item.Dispose();
			}
		}
		_paths.Clear();
	}

	private Path AddPath(IPathfindingNodeProvider from, IPathfindingNodeProvider to)
	{
		Path path = new Path(from, to);
		if (_paths.TryGetValue(from, out var value))
		{
			value.Add(path);
		}
		else
		{
			_paths.Add(from, new List<Path> { path });
		}
		if (_paths.TryGetValue(to, out value))
		{
			value.Add(path);
		}
		else
		{
			_paths.Add(to, new List<Path> { path });
		}
		return path;
	}

	public static Path ReturnPath(IPathfindingNodeProvider from, IPathfindingNodeProvider to)
	{
		if (_instance == null)
		{
			return null;
		}
		return _instance.i_ReturnPath(from, to);
	}

	public static T ReturnClosestDestination<T>(IPathfindingNodeProvider from, List<T> destinations) where T : IPathfindingNodeProvider
	{
		float num = float.MaxValue;
		T result = default(T);
		foreach (T destination in destinations)
		{
			float num2 = ReturnPath(from, destination).ReturnDistance();
			if (num2 < num)
			{
				num = num2;
				result = destination;
			}
		}
		return result;
	}

	private Path i_ReturnPath(IPathfindingNodeProvider from, IPathfindingNodeProvider to)
	{
		if (!_paths.TryGetValue(from, out var value) || !TryReturnCachedPath(value, from, to, out var path))
		{
			return AddPath(from, to);
		}
		return path;
	}

	private bool TryReturnCachedPath(List<Path> cachedPaths, IPathfindingNodeProvider from, IPathfindingNodeProvider to, out Path path)
	{
		int count = cachedPaths.Count;
		while (0 < count--)
		{
			Path path2 = cachedPaths[count];
			if (path2.IsDead())
			{
				cachedPaths.RemoveAt(count);
			}
			else if (path2.IsMatch(from, to))
			{
				path = path2;
				return true;
			}
		}
		path = null;
		return false;
	}
}
