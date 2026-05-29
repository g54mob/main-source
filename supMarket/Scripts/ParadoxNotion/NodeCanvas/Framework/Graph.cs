using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	public abstract class Graph : ScriptableObject, ITaskSystem, ISerializationCallbackReceiver
	{
		public enum UpdateMode
		{
			NormalUpdate = 0,
			LateUpdate = 1,
			FixedUpdate = 2,
			Manual = 3
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadOverwriteAsync_003Ed__161 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Graph _003C_003E4__this;

			public GraphLoadData data;

			public Action callback;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private string _serializedGraph;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private GraphSource _graphSource;

		[SerializeField]
		private bool _haltSerialization;

		[SerializeField]
		[Tooltip("An external text asset file to serialize the graph on top of the internal serialization")]
		private TextAsset _externalSerializationFile;

		[NonSerialized]
		private bool haltForUndo;

		private static List<Graph> _runningGraphs;

		public TextAsset externalSerializationFile
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		private bool hasInitialized { get; set; }

		private HierarchyTree.Element flatMetaGraph { get; set; }

		private HierarchyTree.Element fullMetaGraph { get; set; }

		private HierarchyTree.Element nestedMetaGraph { get; set; }

		public abstract Type baseNodeType { get; }

		public abstract bool requiresAgent { get; }

		public abstract bool requiresPrimeNode { get; }

		public abstract bool isTree { get; }

		public abstract PlanarDirection flowDirection { get; }

		public abstract bool allowBlackboardOverrides { get; }

		public abstract bool canAcceptVariableDrops { get; }

		private GraphSource graphSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string category
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string comments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 translation
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float zoomFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public List<Node> allNodes
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<CanvasGroup> canvasGroups
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private BlackboardSource localBlackboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private List<Task> allTasks => null;

		private List<BBParameter> allParameters => null;

		private List<Connection> allConnections => null;

		public Graph rootGraph => null;

		public bool serializationHalted => false;

		public static IEnumerable<Graph> runningGraphs => null;

		public Graph parentGraph { get; private set; }

		public float elapsedTime { get; private set; }

		public float deltaTime { get; private set; }

		public int lastUpdateFrame { get; private set; }

		public bool didUpdateLastFrame => false;

		public bool isRunning { get; private set; }

		public bool isPaused { get; private set; }

		public UpdateMode updateMode { get; private set; }

		public Node primeNode
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Component agent { get; private set; }

		public IBlackboard blackboard => null;

		public IBlackboard parentBlackboard { get; private set; }

		UnityEngine.Object ITaskSystem.contextObject => null;

		public static event Action<Graph> onGraphSerialized
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

		public static event Action<Graph> onGraphDeserialized
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

		public event Action<bool> onFinish
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

		private event Action delayedInitCalls
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

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected void OnDestroy()
		{
		}

		protected void OnValidate()
		{
		}

		protected void Reset()
		{
		}

		public bool SelfSerialize()
		{
			return false;
		}

		public bool SelfDeserialize()
		{
			return false;
		}

		public string Serialize(List<UnityEngine.Object> references)
		{
			return null;
		}

		public bool Deserialize(string serializedGraph, List<UnityEngine.Object> references, bool validate)
		{
			return false;
		}

		public GraphSource GetGraphSource()
		{
			return null;
		}

		public string GetSerializedJsonData()
		{
			return null;
		}

		public List<UnityEngine.Object> GetSerializedReferencesData()
		{
			return null;
		}

		public GraphSource GetGraphSourceMetaDataCopy()
		{
			return null;
		}

		public void SetGraphSourceMetaData(GraphSource source)
		{
		}

		public string SerializeLocalBlackboard(ref List<UnityEngine.Object> references)
		{
			return null;
		}

		public bool DeserializeLocalBlackboard(string json, List<UnityEngine.Object> references)
		{
			return false;
		}

		public static T Clone<T>(T graph, Graph parentGraph)
		{
			return default(T);
		}

		public void Validate()
		{
		}

		public void UpdateReferencesFromOwner(GraphOwner owner, bool force = false)
		{
		}

		public void UpdateReferences(Component newAgent, IBlackboard newParentBlackboard, bool force = false)
		{
		}

		private void UpdateNodeBBFields()
		{
		}

		void ITaskSystem.UpdateTasksOwner()
		{
		}

		public void UpdateNodeIDs(bool alsoReorderList)
		{
		}

		private int AssignNodeID(Node node, int lastID, ref Node[] parsed)
		{
			return 0;
		}

		protected void ThreadSafeInitCall(Action call)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadOverwriteAsync_003Ed__161))]
		public void LoadOverwriteAsync(GraphLoadData data, Action callback)
		{
		}

		public void LoadOverwrite(GraphLoadData data)
		{
		}

		public void Initialize(Component newAgent, IBlackboard newParentBlackboard, bool preInitializeSubGraphs)
		{
		}

		private void PreInitializeSubGraphs()
		{
		}

		public void StartGraph(Component newAgent, IBlackboard newParentBlackboard, UpdateMode newUpdateMode, Action<bool> callback = null)
		{
		}

		public void Stop(bool success = true)
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public void Restart()
		{
		}

		public void UpdateGraph()
		{
		}

		public void UpdateGraph(float deltaTime)
		{
		}

		public virtual object OnDerivedDataSerialization()
		{
			return null;
		}

		public virtual void OnDerivedDataDeserialization(object data)
		{
		}

		protected virtual void OnGraphInitialize()
		{
		}

		protected virtual void OnGraphStarted()
		{
		}

		protected virtual void OnGraphUpdate()
		{
		}

		protected virtual void OnGraphStoped()
		{
		}

		protected virtual void OnGraphPaused()
		{
		}

		protected virtual void OnGraphUnpaused()
		{
		}

		protected virtual void OnGraphObjectEnable()
		{
		}

		protected virtual void OnGraphObjectDisable()
		{
		}

		protected virtual void OnGraphObjectDestroy()
		{
		}

		protected virtual void OnGraphValidate()
		{
		}

		public void SendEvent(string name, object value, object sender)
		{
		}

		public void SendEvent<T>(string name, T value, object sender)
		{
		}

		public static void SendGlobalEvent(string name, object value, object sender)
		{
		}

		public static void SendGlobalEvent<T>(string name, T value, object sender)
		{
		}

		public IEnumerable<BBParameter> GetAllParameters()
		{
			return null;
		}

		public IEnumerable<Connection> GetAllConnections()
		{
			return null;
		}

		public IEnumerable<T> GetAllTasksOfType<T>()
		{
			return null;
		}

		public Node GetNodeWithID(int searchID)
		{
			return null;
		}

		public IEnumerable<T> GetAllNodesOfType<T>()
		{
			return null;
		}

		public T GetNodeWithTag<T>(string tagName)
		{
			return default(T);
		}

		public IEnumerable<T> GetNodesWithTag<T>(string tagName)
		{
			return null;
		}

		public IEnumerable<T> GetAllTagedNodes<T>()
		{
			return null;
		}

		public IEnumerable<Node> GetRootNodes()
		{
			return null;
		}

		public IEnumerable<Node> GetLeafNodes()
		{
			return null;
		}

		public IEnumerable<T> GetAllNestedGraphs<T>(bool recursive)
		{
			return null;
		}

		public IEnumerable<Graph> GetAllInstancedNestedGraphs()
		{
			return null;
		}

		public IEnumerable<BBParameter> GetDefinedParameters()
		{
			return null;
		}

		public void PromoteMissingParametersToVariables(IBlackboard bb)
		{
		}

		public static Graph GetElementGraph(object obj)
		{
			return null;
		}

		public HierarchyTree.Element GetFlatMetaGraph()
		{
			return null;
		}

		public HierarchyTree.Element GetFullMetaGraph()
		{
			return null;
		}

		public HierarchyTree.Element GetNestedMetaGraph()
		{
			return null;
		}

		private static void DigNestedGraphs(Graph currentGraph, HierarchyTree.Element currentElement)
		{
		}

		private static HierarchyTree.Element GetTreeNodeElement(Node node, bool recurse, ref int lastID)
		{
			return null;
		}

		private static HierarchyTree.Element CollectSubElements(IGraphElement obj)
		{
			return null;
		}

		public IGraphElement GetTaskParentElement(Task targetTask)
		{
			return null;
		}

		public IGraphElement GetParameterParentElement(BBParameter targetParameter)
		{
			return null;
		}

		public static IEnumerable<Task> GetTasksInElement(IGraphElement target)
		{
			return null;
		}

		public static IEnumerable<BBParameter> GetParametersInElement(IGraphElement target)
		{
			return null;
		}

		public T AddNode<T>()
		{
			return default(T);
		}

		public T AddNode<T>(Vector2 pos)
		{
			return default(T);
		}

		public Node AddNode(Type nodeType)
		{
			return null;
		}

		public Node AddNode(Type nodeType, Vector2 pos)
		{
			return null;
		}

		public void RemoveNode(Node node, bool recordUndo = true, bool force = false)
		{
		}

		public Connection ConnectNodes(Node sourceNode, Node targetNode, int sourceIndex = -1, int targetIndex = -1)
		{
			return null;
		}

		public void RemoveConnection(Connection connection, bool recordUndo = true)
		{
		}

		public static List<Node> CloneNodes(List<Node> originalNodes, Graph targetGraph = null, Vector2 originPosition = default(Vector2))
		{
			return null;
		}

		public void ClearGraph()
		{
		}

		[Obsolete("Use 'Graph.StartGraph' with the 'Graph.UpdateMode' parameter.")]
		public void StartGraph(Component newAgent, IBlackboard newBlackboard, bool autoUpdate, Action<bool> callback = null)
		{
		}
	}
}
