using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class AstarData
	{
		[CompilerGenerated]
		private sealed class _003CFindGraphsOfType_003Ed__77 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public AstarData _003C_003E4__this;

			private Type type;

			public Type _003C_003E3__type;

			private int _003Ci_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFindGraphsOfType_003Ed__77(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetUpdateableGraphs_003Ed__78 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public AstarData _003C_003E4__this;

			private int _003Ci_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetUpdateableGraphs_003Ed__78(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private AstarPath active;

		[NonSerialized]
		public NavGraph[] graphs;

		[SerializeField]
		private string dataString;

		public TextAsset file_cachedStartup;

		[SerializeField]
		public bool cacheStartup;

		private List<bool> graphStructureLocked;

		private static readonly ProfilerMarker MarkerLoadFromCache;

		private static readonly ProfilerMarker MarkerDeserializeGraphs;

		private static readonly ProfilerMarker MarkerSerializeGraphs;

		private static readonly ProfilerMarker MarkerFindGraphTypes;

		[Obsolete("Use navmeshGraph instead")]
		public NavMeshGraph navmesh => null;

		public NavMeshGraph navmeshGraph { get; private set; }

		public GridGraph gridGraph { get; private set; }

		public LayerGridGraph layerGridGraph { get; private set; }

		public PointGraph pointGraph { get; private set; }

		public RecastGraph recastGraph { get; private set; }

		public LinkGraph linkGraph { get; private set; }

		public static Type[] graphTypes { get; private set; }

		private byte[] data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal AstarData(AstarPath active)
		{
		}

		public byte[] GetData()
		{
			return null;
		}

		public void SetData(byte[] data)
		{
		}

		public void OnEnable()
		{
		}

		internal void LockGraphStructure(bool allowAddingGraphs = false)
		{
		}

		internal void UnlockGraphStructure()
		{
		}

		private PathProcessor.GraphUpdateLock AssertSafe(bool onlyAddingGraph = false)
		{
			return default(PathProcessor.GraphUpdateLock);
		}

		public void GetNodes(Action<GraphNode> callback)
		{
		}

		public void UpdateShortcuts()
		{
		}

		public void LoadFromCache()
		{
		}

		public byte[] SerializeGraphs()
		{
			return null;
		}

		public byte[] SerializeGraphs(SerializeSettings settings)
		{
			return null;
		}

		public byte[] SerializeGraphs(SerializeSettings settings, out uint checksum)
		{
			checksum = default(uint);
			return null;
		}

		private byte[] SerializeGraphs(SerializeSettings settings, out uint checksum, NavGraph[] graphs)
		{
			checksum = default(uint);
			return null;
		}

		public void DeserializeGraphs()
		{
		}

		public void ClearGraphs()
		{
		}

		private void ClearGraphsInternal()
		{
		}

		public void DisposeUnmanagedData()
		{
		}

		internal void DestroyAllNodes()
		{
		}

		public void OnDestroy()
		{
		}

		public NavGraph[] DeserializeGraphs(byte[] bytes)
		{
			return null;
		}

		public NavGraph[] DeserializeGraphsAdditive(byte[] bytes)
		{
			return null;
		}

		private NavGraph[] DeserializeGraphsPartAdditive(AstarSerializer sr)
		{
			return null;
		}

		public void FindGraphTypes()
		{
		}

		internal NavGraph CreateGraph(Type type)
		{
			return null;
		}

		public T AddGraph<T>() where T : NavGraph
		{
			return null;
		}

		public NavGraph AddGraph(Type type)
		{
			return null;
		}

		private void AddGraph(NavGraph graph)
		{
		}

		public bool RemoveGraph(NavGraph graph)
		{
			return false;
		}

		public NavGraph DuplicateGraph(NavGraph graph)
		{
			return null;
		}

		public static NavGraph GetGraph(GraphNode node)
		{
			return null;
		}

		public NavGraph FindGraph(Func<NavGraph, bool> predicate)
		{
			return null;
		}

		public NavGraph FindGraphOfType(Type type)
		{
			return null;
		}

		public NavGraph FindGraphWhichInheritsFrom(Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFindGraphsOfType_003Ed__77))]
		public IEnumerable FindGraphsOfType(Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetUpdateableGraphs_003Ed__78))]
		public IEnumerable GetUpdateableGraphs()
		{
			return null;
		}

		public int GetGraphIndex(NavGraph graph)
		{
			return 0;
		}
	}
}
