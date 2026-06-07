using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Pathfinding.WindowsStore;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class AstarData
	{
		internal AstarPath active;

		[NonSerialized]
		public NavGraph[] graphs = new NavGraph[0];

		[SerializeField]
		private string dataString;

		public TextAsset file_cachedStartup;

		[SerializeField]
		public bool cacheStartup;

		private List<bool> graphStructureLocked = new List<bool>();

		public NavMeshGraph navmesh { get; private set; }

		public GridGraph gridGraph { get; private set; }

		public LayerGridGraph layerGridGraph { get; private set; }

		public PointGraph pointGraph { get; private set; }

		public RecastGraph recastGraph { get; private set; }

		public LinkGraph linkGraph { get; private set; }

		public Type[] graphTypes { get; private set; }

		private byte[] data
		{
			get
			{
				byte[] array = ((dataString != null) ? Convert.FromBase64String(dataString) : null);
				if (array != null && array.Length == 0)
				{
					return null;
				}
				return array;
			}
			set
			{
				dataString = ((value != null) ? Convert.ToBase64String(value) : null);
			}
		}

		internal AstarData(AstarPath active)
		{
			this.active = active;
		}

		public byte[] GetData()
		{
			return data;
		}

		public void SetData(byte[] data)
		{
			this.data = data;
		}

		public void OnEnable()
		{
			if (graphTypes == null)
			{
				FindGraphTypes();
			}
			if (graphs == null)
			{
				graphs = new NavGraph[0];
			}
			if (cacheStartup && file_cachedStartup != null && Application.isPlaying)
			{
				LoadFromCache();
			}
			else
			{
				DeserializeGraphs();
			}
		}

		internal void LockGraphStructure(bool allowAddingGraphs = false)
		{
			graphStructureLocked.Add(allowAddingGraphs);
		}

		internal void UnlockGraphStructure()
		{
			if (graphStructureLocked.Count == 0)
			{
				throw new InvalidOperationException();
			}
			graphStructureLocked.RemoveAt(graphStructureLocked.Count - 1);
		}

		private PathProcessor.GraphUpdateLock AssertSafe(bool onlyAddingGraph = false)
		{
			if (graphStructureLocked.Count > 0)
			{
				bool flag = true;
				for (int i = 0; i < graphStructureLocked.Count; i++)
				{
					flag &= graphStructureLocked[i];
				}
				if (!(onlyAddingGraph && flag))
				{
					throw new InvalidOperationException("Graphs cannot be added, removed or serialized while the graph structure is locked. This is the case when a graph is currently being scanned and when executing graph updates and work items.\nHowever as a special case, graphs can be added inside work items.");
				}
			}
			PathProcessor.GraphUpdateLock result = active.PausePathfinding();
			if (!active.IsInsideWorkItem)
			{
				active.FlushWorkItems();
				active.pathReturnQueue.ReturnPaths(timeSlice: false);
			}
			return result;
		}

		public void GetNodes(Action<GraphNode> callback)
		{
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					graphs[i].GetNodes(callback);
				}
			}
		}

		public void UpdateShortcuts()
		{
			navmesh = (NavMeshGraph)FindGraphOfType(typeof(NavMeshGraph));
			gridGraph = (GridGraph)FindGraphOfType(typeof(GridGraph));
			layerGridGraph = (LayerGridGraph)FindGraphOfType(typeof(LayerGridGraph));
			pointGraph = (PointGraph)FindGraphOfType(typeof(PointGraph));
			recastGraph = (RecastGraph)FindGraphOfType(typeof(RecastGraph));
			linkGraph = (LinkGraph)FindGraphOfType(typeof(LinkGraph));
		}

		public void LoadFromCache()
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			if (file_cachedStartup != null)
			{
				byte[] bytes = file_cachedStartup.bytes;
				DeserializeGraphs(bytes);
				GraphModifier.TriggerEvent(GraphModifier.EventType.PostCacheLoad);
			}
			else
			{
				Debug.LogError("Can't load from cache since the cache is empty");
			}
			graphUpdateLock.Release();
		}

		public byte[] SerializeGraphs()
		{
			return SerializeGraphs(SerializeSettings.Settings);
		}

		public byte[] SerializeGraphs(SerializeSettings settings)
		{
			uint checksum;
			return SerializeGraphs(settings, out checksum);
		}

		public byte[] SerializeGraphs(SerializeSettings settings, out uint checksum)
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			AstarSerializer astarSerializer = new AstarSerializer(this, settings, active.gameObject);
			astarSerializer.OpenSerialize();
			astarSerializer.SerializeGraphs(graphs);
			astarSerializer.SerializeExtraInfo();
			byte[] result = astarSerializer.CloseSerialize();
			checksum = astarSerializer.GetChecksum();
			graphUpdateLock.Release();
			return result;
		}

		public void DeserializeGraphs()
		{
			byte[] array = data;
			if (array != null)
			{
				DeserializeGraphs(array);
			}
		}

		public void ClearGraphs()
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			ClearGraphsInternal();
			graphUpdateLock.Release();
		}

		private void ClearGraphsInternal()
		{
			if (graphs == null)
			{
				return;
			}
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					active.DirtyBounds(graphs[i].bounds);
					((IGraphInternals)graphs[i]).OnDestroy();
					graphs[i].active = null;
				}
			}
			graphs = new NavGraph[0];
			UpdateShortcuts();
			graphUpdateLock.Release();
		}

		public void DisposeUnmanagedData()
		{
			if (graphs == null)
			{
				return;
			}
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					((IGraphInternals)graphs[i]).DisposeUnmanagedData();
				}
			}
			graphUpdateLock.Release();
		}

		internal void DestroyAllNodes()
		{
			if (graphs == null)
			{
				return;
			}
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					((IGraphInternals)graphs[i]).DestroyAllNodes();
				}
			}
			graphUpdateLock.Release();
		}

		public void OnDestroy()
		{
			ClearGraphsInternal();
		}

		public void DeserializeGraphs(byte[] bytes)
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			ClearGraphs();
			DeserializeGraphsAdditive(bytes);
			graphUpdateLock.Release();
		}

		public void DeserializeGraphsAdditive(byte[] bytes)
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			try
			{
				if (bytes == null)
				{
					throw new ArgumentNullException("bytes");
				}
				AstarSerializer astarSerializer = new AstarSerializer(this, active.gameObject);
				if (astarSerializer.OpenDeserialize(bytes))
				{
					DeserializeGraphsPartAdditive(astarSerializer);
					astarSerializer.CloseDeserialize();
				}
				else
				{
					Debug.Log("Invalid data file (cannot read zip).\nThe data is either corrupt or it was saved using a 3.0.x or earlier version of the system");
				}
				active.VerifyIntegrity();
			}
			catch (Exception innerException)
			{
				Debug.LogError(new Exception("Caught exception while deserializing data.", innerException));
				graphs = new NavGraph[0];
			}
			UpdateShortcuts();
			GraphModifier.TriggerEvent(GraphModifier.EventType.PostGraphLoad);
			graphUpdateLock.Release();
		}

		private void DeserializeGraphsPartAdditive(AstarSerializer sr)
		{
			if (graphs == null)
			{
				graphs = new NavGraph[0];
			}
			List<NavGraph> list = new List<NavGraph>(graphs);
			sr.SetGraphIndexOffset(list.Count);
			FindGraphTypes();
			NavGraph[] newGraphs = sr.DeserializeGraphs(graphTypes);
			list.AddRange(newGraphs);
			if ((long)list.Count > 255L)
			{
				throw new InvalidOperationException("Graph Count Limit Reached. You cannot have more than " + 254u + " graphs.");
			}
			graphs = list.ToArray();
			int i;
			for (i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					graphs[i].GetNodes(delegate(GraphNode node)
					{
						node.GraphIndex = (uint)i;
					});
				}
			}
			for (int num = 0; num < graphs.Length; num++)
			{
				for (int num2 = num + 1; num2 < graphs.Length; num2++)
				{
					if (graphs[num] != null && graphs[num2] != null && graphs[num].guid == graphs[num2].guid)
					{
						Debug.LogWarning("Guid Conflict when importing graphs additively. Imported graph will get a new Guid.\nThis message is (relatively) harmless.");
						graphs[num].guid = Pathfinding.Util.Guid.NewGuid();
						break;
					}
				}
			}
			sr.PostDeserialization();
			active.AddWorkItem(delegate(IWorkItemContext ctx)
			{
				for (int j = 0; j < newGraphs.Length; j++)
				{
					ctx.DirtyBounds(newGraphs[j].bounds);
				}
			});
			active.FlushWorkItems();
		}

		public void FindGraphTypes()
		{
			if (graphTypes != null)
			{
				return;
			}
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				Type[] array = null;
				try
				{
					array = assembly.GetTypes();
				}
				catch
				{
					continue;
				}
				Type[] array2 = array;
				foreach (Type type in array2)
				{
					Type baseType = type.BaseType;
					while (baseType != null)
					{
						if (object.Equals(baseType, typeof(NavGraph)))
						{
							list.Add(type);
							break;
						}
						baseType = baseType.BaseType;
					}
				}
			}
			graphTypes = list.ToArray();
		}

		internal NavGraph CreateGraph(Type type)
		{
			NavGraph obj = Activator.CreateInstance(type) as NavGraph;
			obj.active = active;
			return obj;
		}

		public T AddGraph<T>() where T : NavGraph
		{
			return AddGraph(typeof(T)) as T;
		}

		public NavGraph AddGraph(Type type)
		{
			NavGraph navGraph = null;
			for (int i = 0; i < graphTypes.Length; i++)
			{
				if (object.Equals(graphTypes[i], type))
				{
					navGraph = CreateGraph(graphTypes[i]);
				}
			}
			if (navGraph == null)
			{
				Debug.LogError("No NavGraph of type '" + type?.ToString() + "' could be found, " + graphTypes.Length + " graph types are avaliable");
				return null;
			}
			AddGraph(navGraph);
			return navGraph;
		}

		private void AddGraph(NavGraph graph)
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe(onlyAddingGraph: true);
			bool flag = false;
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] == null)
				{
					graphs[i] = graph;
					graph.graphIndex = (uint)i;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (graphs != null && (long)graphs.Length >= 254L)
				{
					throw new Exception("Graph Count Limit Reached. You cannot have more than " + 254u + " graphs.");
				}
				Memory.Realloc(ref graphs, graphs.Length + 1);
				graphs[graphs.Length - 1] = graph;
				graph.graphIndex = (uint)(graphs.Length - 1);
			}
			UpdateShortcuts();
			graph.active = active;
			graphUpdateLock.Release();
		}

		public bool RemoveGraph(NavGraph graph)
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = AssertSafe();
			active.DirtyBounds(graph.bounds);
			((IGraphInternals)graph).OnDestroy();
			graph.active = null;
			int num = Array.IndexOf(graphs, graph);
			if (num != -1)
			{
				graphs[num] = null;
			}
			UpdateShortcuts();
			active.offMeshLinks.Refresh();
			graphUpdateLock.Release();
			return num != -1;
		}

		public static NavGraph GetGraph(GraphNode node)
		{
			if (node == null || node.Destroyed)
			{
				return null;
			}
			AstarPath astarPath = AstarPath.active;
			if ((object)astarPath == null)
			{
				return null;
			}
			AstarData astarData = astarPath.data;
			if (astarData == null || astarData.graphs == null)
			{
				return null;
			}
			uint graphIndex = node.GraphIndex;
			return astarData.graphs[graphIndex];
		}

		public NavGraph FindGraph(Func<NavGraph, bool> predicate)
		{
			if (graphs != null)
			{
				for (int i = 0; i < graphs.Length; i++)
				{
					if (graphs[i] != null && predicate(graphs[i]))
					{
						return graphs[i];
					}
				}
			}
			return null;
		}

		public NavGraph FindGraphOfType(Type type)
		{
			return FindGraph((NavGraph graph) => object.Equals(graph.GetType(), type));
		}

		public NavGraph FindGraphWhichInheritsFrom(Type type)
		{
			return FindGraph((NavGraph graph) => WindowsStoreCompatibility.GetTypeInfo(type).IsAssignableFrom(WindowsStoreCompatibility.GetTypeInfo(graph.GetType())));
		}

		public IEnumerable FindGraphsOfType(Type type)
		{
			if (graphs == null)
			{
				yield break;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null && object.Equals(graphs[i].GetType(), type))
				{
					yield return graphs[i];
				}
			}
		}

		public IEnumerable GetUpdateableGraphs()
		{
			if (graphs == null)
			{
				yield break;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is IUpdatableGraph)
				{
					yield return graphs[i];
				}
			}
		}

		public int GetGraphIndex(NavGraph graph)
		{
			if (graph == null)
			{
				throw new ArgumentNullException("graph");
			}
			int num = -1;
			if (graphs != null)
			{
				num = Array.IndexOf(graphs, graph);
				if (num == -1)
				{
					Debug.LogError("Graph doesn't exist");
				}
			}
			return num;
		}
	}
}
