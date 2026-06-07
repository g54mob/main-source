using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[Serializable]
	public class AstarData
	{
		[CompilerGenerated]
		private sealed class _003CFindGraphsOfType_003Ed__58 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CFindGraphsOfType_003Ed__58(int _003C_003E1__state)
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
		private sealed class _003CGetRaycastableGraphs_003Ed__60 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CGetRaycastableGraphs_003Ed__60(int _003C_003E1__state)
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
		private sealed class _003CGetUpdateableGraphs_003Ed__59 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CGetUpdateableGraphs_003Ed__59(int _003C_003E1__state)
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

		[NonSerialized]
		public NavGraph[] graphs;

		[SerializeField]
		private string dataString;

		[SerializeField]
		[FormerlySerializedAs("data")]
		private byte[] upgradeData;

		public TextAsset file_cachedStartup;

		public byte[] data_cachedStartup;

		[SerializeField]
		public bool cacheStartup;

		private List<bool> graphStructureLocked;

		public static AstarPath active => null;

		public NavMeshGraph navmesh { get; private set; }

		public GridGraph gridGraph { get; private set; }

		public PointGraph pointGraph { get; private set; }

		public Type[] graphTypes { get; private set; }

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

		public byte[] GetData()
		{
			return null;
		}

		public void SetData(byte[] data)
		{
		}

		public void Awake()
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

		public void DeserializeGraphs()
		{
		}

		private void ClearGraphs()
		{
		}

		public void OnDestroy()
		{
		}

		public void DeserializeGraphs(byte[] bytes)
		{
		}

		public void DeserializeGraphsAdditive(byte[] bytes)
		{
		}

		private void DeserializeGraphsPartAdditive(AstarSerializer sr)
		{
		}

		public void FindGraphTypes()
		{
		}

		[Obsolete("If really necessary. Use System.Type.GetType instead.")]
		public Type GetGraphType(string type)
		{
			return null;
		}

		[Obsolete("Use CreateGraph(System.Type) instead")]
		public NavGraph CreateGraph(string type)
		{
			return null;
		}

		internal NavGraph CreateGraph(Type type)
		{
			return null;
		}

		[Obsolete("Use AddGraph(System.Type) instead")]
		public NavGraph AddGraph(string type)
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

		[IteratorStateMachine(typeof(_003CFindGraphsOfType_003Ed__58))]
		public IEnumerable FindGraphsOfType(Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetUpdateableGraphs_003Ed__59))]
		public IEnumerable GetUpdateableGraphs()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetRaycastableGraphs_003Ed__60))]
		[Obsolete("Obsolete because it is not used by the package internally and the use cases are few. Iterate through the graphs array instead.")]
		public IEnumerable GetRaycastableGraphs()
		{
			return null;
		}

		public int GetGraphIndex(NavGraph graph)
		{
			return 0;
		}
	}
}
