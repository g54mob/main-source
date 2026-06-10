using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using UnityEngine;

namespace NSMedieval.Village.Map.Pathfinding
{
	public static class PathPool
	{
		public static readonly Dictionary<PathType, Stack<Path>> Pool = new Dictionary<PathType, Stack<Path>>();

		private static readonly Dictionary<PathType, int> TotalCreated = new Dictionary<PathType, int>();

		private static readonly Dictionary<PathType, int> InitialAllocationByType = new Dictionary<PathType, int>
		{
			{
				PathType.P2Multi,
				10
			},
			{
				PathType.P2P,
				35
			},
			{
				PathType.P2Production,
				10
			},
			{
				PathType.P2WorldObject,
				35
			},
			{
				PathType.P2GoapTargetable,
				25
			},
			{
				PathType.P2WorldObjRegionExplorerPath,
				35
			},
			{
				PathType.Flee,
				10
			},
			{
				PathType.Siege,
				3
			}
		};

		private const int AllocationBatchSize = 7;

		public static bool IsInitialized
		{
			get
			{
				Dictionary<PathType, Stack<Path>> pool = Pool;
				if (pool == null)
				{
					return false;
				}
				return pool.Count > 0;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			foreach (Stack<Path> value in Pool.Values)
			{
				value.Clear();
			}
			Pool.Clear();
			TotalCreated.Clear();
		}

		public static void Initialize()
		{
			Log.Info("Initializing pools", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\MemoryPool\\PathPool.cs");
			Pool.Clear();
			TotalCreated.Clear();
			int num = 0;
			PathType[] pathTypes = EnumValues.PathTypes;
			foreach (PathType pathType in pathTypes)
			{
				if (pathType != PathType.None)
				{
					int num2 = InitialAllocationByType[pathType];
					TotalCreated.Add(pathType, num2);
					Stack<Path> stack = new Stack<Path>();
					num += num2;
					for (int j = 0; j < num2; j++)
					{
						stack.Push(ProducePathByType(pathType));
					}
					Pool.Add(pathType, stack);
				}
			}
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
		}

		private static void OnMainSceneLeaving()
		{
			Log.Info("Clearing pools (OnMainSceneLeaving)", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\MemoryPool\\PathPool.cs");
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
			}
			foreach (Stack<Path> value in Pool.Values)
			{
				foreach (Path item in value)
				{
					item.ForceResetToDefaultState();
				}
				value.Clear();
			}
			Pool.Clear();
			TotalCreated.Clear();
		}

		public static Path Get(PathType type)
		{
			if (!IsInitialized)
			{
				throw new Exception($"Tried to get pooled path of type {type}, but the pool is not initialized");
			}
			if (type == PathType.None || !Pool.TryGetValue(type, out var value))
			{
				return null;
			}
			lock (value)
			{
				Path path;
				if (value.Count > 0)
				{
					path = value.Pop();
				}
				else
				{
					TotalCreated[type] += 7;
					for (int i = 0; i < 7; i++)
					{
						value.Push(ProducePathByType(type));
					}
					path = value.Pop();
				}
				path.OnRemovedFromPool();
				return path;
			}
		}

		public static void Return(Path path)
		{
			if (path == null || !Pool.TryGetValue(path.Type, out var value))
			{
				return;
			}
			lock (value)
			{
				value.Push(path);
				path.OnReturnedToPool();
			}
		}

		private static Path ProducePathByType(PathType type)
		{
			return type switch
			{
				PathType.P2P => new P2PPath(), 
				PathType.P2Multi => new P2MultiPath(), 
				PathType.P2Production => new P2ProductionPlacePath(), 
				PathType.P2WorldObject => new P2WorldObjectPath(), 
				PathType.P2GoapTargetable => new P2GoapTargetable(), 
				PathType.P2WorldObjRegionExplorerPath => new P2RegionReservableWoExplorerPath(), 
				PathType.Flee => new FleePath(), 
				PathType.Siege => new SiegePath(), 
				_ => throw new Exception("Should never happen! " + type), 
			};
		}
	}
}
