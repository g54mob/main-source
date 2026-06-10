using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using ParadoxNotion.Services;
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

		[SerializeField]
		private string _serializedGraph;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private GraphSource _graphSource = new GraphSource();

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
				return _externalSerializationFile;
			}
			internal set
			{
				_externalSerializationFile = value;
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
				return _graphSource;
			}
			set
			{
				_graphSource = value;
			}
		}

		public string category
		{
			get
			{
				return graphSource.category;
			}
			set
			{
				graphSource.category = value;
			}
		}

		public string comments
		{
			get
			{
				return graphSource.comments;
			}
			set
			{
				graphSource.comments = value;
			}
		}

		public Vector2 translation
		{
			get
			{
				return graphSource.translation;
			}
			set
			{
				graphSource.translation = value;
			}
		}

		public float zoomFactor
		{
			get
			{
				return graphSource.zoomFactor;
			}
			set
			{
				graphSource.zoomFactor = value;
			}
		}

		public List<Node> allNodes
		{
			get
			{
				return graphSource.nodes;
			}
			set
			{
				graphSource.nodes = value;
			}
		}

		public List<CanvasGroup> canvasGroups
		{
			get
			{
				return graphSource.canvasGroups;
			}
			set
			{
				graphSource.canvasGroups = value;
			}
		}

		private BlackboardSource localBlackboard
		{
			get
			{
				return graphSource.localBlackboard;
			}
			set
			{
				graphSource.localBlackboard = value;
			}
		}

		private List<Task> allTasks => graphSource.allTasks;

		private List<BBParameter> allParameters => graphSource.allParameters;

		private List<Connection> allConnections => graphSource.connections;

		public Graph rootGraph
		{
			get
			{
				Graph graph = this;
				while (graph.parentGraph != null)
				{
					graph = graph.parentGraph;
				}
				return graph;
			}
		}

		public bool serializationHalted => _haltSerialization;

		public static IEnumerable<Graph> runningGraphs => _runningGraphs;

		public Graph parentGraph { get; private set; }

		public float elapsedTime { get; private set; }

		public float deltaTime { get; private set; }

		public int lastUpdateFrame { get; private set; }

		public bool didUpdateLastFrame => lastUpdateFrame >= Time.frameCount - 1;

		public bool isRunning { get; private set; }

		public bool isPaused { get; private set; }

		public UpdateMode updateMode { get; private set; }

		public Node primeNode
		{
			get
			{
				if (allNodes.Count > 0)
				{
					Node node = allNodes[0];
					if (node.allowAsPrime)
					{
						return node;
					}
				}
				return null;
			}
			set
			{
				if (primeNode == value || value == null || !value.allowAsPrime || !allNodes.Contains(value))
				{
					return;
				}
				if (isRunning)
				{
					if (primeNode != null)
					{
						primeNode.Reset();
					}
					value.Reset();
				}
				allNodes.Remove(value);
				allNodes.Insert(0, value);
				UpdateNodeIDs(alsoReorderList: true);
			}
		}

		public Component agent { get; private set; }

		public IBlackboard blackboard => localBlackboard;

		public IBlackboard parentBlackboard { get; private set; }

		UnityEngine.Object ITaskSystem.contextObject => this;

		public static event Action<Graph> onGraphSerialized;

		public static event Action<Graph> onGraphDeserialized;

		public event Action<bool> onFinish;

		private event Action delayedInitCalls;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			SelfSerialize();
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			SelfDeserialize();
		}

		protected void OnEnable()
		{
			Validate();
			OnGraphObjectEnable();
		}

		protected void OnDisable()
		{
			OnGraphObjectDisable();
		}

		protected void OnDestroy()
		{
			if (Threader.applicationIsPlaying)
			{
				Stop();
			}
			OnGraphObjectDestroy();
		}

		protected void OnValidate()
		{
		}

		protected void Reset()
		{
			OnGraphValidate();
		}

		public bool SelfSerialize()
		{
			if (_haltSerialization)
			{
				return false;
			}
			if (haltForUndo)
			{
				return false;
			}
			List<UnityEngine.Object> list = new List<UnityEngine.Object>();
			string text = Serialize(list);
			if (text != _serializedGraph || !list.SequenceEqual(_objectReferences))
			{
				haltForUndo = true;
				haltForUndo = false;
				_serializedGraph = text;
				_objectReferences = list;
				if (Graph.onGraphSerialized != null)
				{
					Graph.onGraphSerialized(this);
				}
				graphSource.PurgeRedundantReferences();
				flatMetaGraph = null;
				fullMetaGraph = null;
				nestedMetaGraph = null;
				return true;
			}
			return false;
		}

		public bool SelfDeserialize()
		{
			if (Deserialize(_serializedGraph, _objectReferences, validate: false))
			{
				if (Graph.onGraphDeserialized != null)
				{
					Graph.onGraphDeserialized(this);
				}
				return true;
			}
			return false;
		}

		public string Serialize(List<UnityEngine.Object> references)
		{
			if (references == null)
			{
				references = new List<UnityEngine.Object>();
			}
			UpdateNodeIDs(alsoReorderList: true);
			return JSONSerializer.Serialize(typeof(GraphSource), graphSource.Pack(this), references);
		}

		public bool Deserialize(string serializedGraph, List<UnityEngine.Object> references, bool validate)
		{
			if (string.IsNullOrEmpty(serializedGraph))
			{
				return false;
			}
			if (references == null)
			{
				references = _objectReferences;
			}
			try
			{
				JSONSerializer.TryDeserializeOverwrite(graphSource, serializedGraph, references);
				if (graphSource.type != GetType().FullName)
				{
					_haltSerialization = true;
					return false;
				}
				_graphSource = graphSource.Unpack(this);
				_serializedGraph = serializedGraph;
				_objectReferences = references;
				_haltSerialization = false;
				if (validate)
				{
					Validate();
				}
				return true;
			}
			catch (Exception exception)
			{
				ParadoxNotion.Services.Logger.LogException(exception, "Serialization", this);
				_haltSerialization = true;
				return false;
			}
		}

		public GraphSource GetGraphSource()
		{
			return _graphSource;
		}

		public string GetSerializedJsonData()
		{
			return _serializedGraph;
		}

		public List<UnityEngine.Object> GetSerializedReferencesData()
		{
			return _objectReferences?.ToList();
		}

		public GraphSource GetGraphSourceMetaDataCopy()
		{
			return new GraphSource().SetMetaData(graphSource);
		}

		public void SetGraphSourceMetaData(GraphSource source)
		{
			graphSource.SetMetaData(source);
		}

		public string SerializeLocalBlackboard(ref List<UnityEngine.Object> references)
		{
			if (references != null)
			{
				references.Clear();
			}
			return JSONSerializer.Serialize(typeof(BlackboardSource), localBlackboard, references);
		}

		public bool DeserializeLocalBlackboard(string json, List<UnityEngine.Object> references)
		{
			localBlackboard = JSONSerializer.TryDeserializeOverwrite(localBlackboard, json, references);
			return true;
		}

		public static T Clone<T>(T graph, Graph parentGraph) where T : Graph
		{
			T val = UnityEngine.Object.Instantiate(graph);
			val.name = val.name.Replace("(Clone)", string.Empty);
			val.parentGraph = parentGraph;
			return val;
		}

		public void Validate()
		{
			if (string.IsNullOrEmpty(_serializedGraph))
			{
				return;
			}
			for (int i = 0; i < allNodes.Count; i++)
			{
				try
				{
					allNodes[i].Validate(this);
				}
				catch (Exception exception)
				{
					ParadoxNotion.Services.Logger.LogException(exception, "Validation", allNodes[i]);
				}
			}
			for (int j = 0; j < allTasks.Count; j++)
			{
				try
				{
					allTasks[j].Validate(this);
				}
				catch (Exception exception2)
				{
					ParadoxNotion.Services.Logger.LogException(exception2, "Validation", allTasks[j]);
				}
			}
			OnGraphValidate();
		}

		public void UpdateReferencesFromOwner(GraphOwner owner, bool force = false)
		{
			UpdateReferences(owner, (owner != null) ? owner.blackboard : null, force);
		}

		public void UpdateReferences(Component newAgent, IBlackboard newParentBlackboard, bool force = false)
		{
			if ((object)agent != newAgent || parentBlackboard != newParentBlackboard || force)
			{
				agent = newAgent;
				parentBlackboard = newParentBlackboard;
				if (newParentBlackboard != localBlackboard && allowBlackboardOverrides)
				{
					localBlackboard.parent = newParentBlackboard;
				}
				else
				{
					localBlackboard.parent = null;
				}
				localBlackboard.propertiesBindTarget = newAgent;
				localBlackboard.unityContextObject = this;
				UpdateNodeBBFields();
				((ITaskSystem)this).UpdateTasksOwner();
			}
		}

		private void UpdateNodeBBFields()
		{
			for (int i = 0; i < allParameters.Count; i++)
			{
				allParameters[i].bb = blackboard;
			}
		}

		void ITaskSystem.UpdateTasksOwner()
		{
			for (int i = 0; i < allTasks.Count; i++)
			{
				allTasks[i].SetOwnerSystem(this);
			}
		}

		public void UpdateNodeIDs(bool alsoReorderList)
		{
			if (allNodes.Count == 0)
			{
				return;
			}
			int lastID = -1;
			Node[] parsed = new Node[allNodes.Count];
			if (primeNode != null)
			{
				lastID = AssignNodeID(primeNode, lastID, ref parsed);
			}
			foreach (Node item in allNodes.OrderBy((Node n) => ((n.inConnections.Count != 0) ? 1 : 0) + n.priority * -1))
			{
				lastID = AssignNodeID(item, lastID, ref parsed);
			}
			if (alsoReorderList)
			{
				allNodes = parsed.ToList();
			}
		}

		private int AssignNodeID(Node node, int lastID, ref Node[] parsed)
		{
			if (!parsed.Contains(node))
			{
				lastID++;
				node.ID = lastID;
				parsed[lastID] = node;
				for (int i = 0; i < node.outConnections.Count; i++)
				{
					Node targetNode = node.outConnections[i].targetNode;
					lastID = AssignNodeID(targetNode, lastID, ref parsed);
				}
			}
			return lastID;
		}

		protected void ThreadSafeInitCall(Action call)
		{
			if (Threader.isMainThread)
			{
				call();
			}
			else
			{
				delayedInitCalls += call;
			}
		}

		public async void LoadOverwriteAsync(GraphLoadData data, Action callback)
		{
			await System.Threading.Tasks.Task.Run(delegate
			{
				LoadOverwrite(data);
			});
			if (this.delayedInitCalls != null)
			{
				this.delayedInitCalls();
				this.delayedInitCalls = null;
			}
			callback();
		}

		public void LoadOverwrite(GraphLoadData data)
		{
			SetGraphSourceMetaData(data.source);
			Deserialize(data.json, data.references, validate: false);
			UpdateReferences(data.agent, data.parentBlackboard);
			Validate();
			OnGraphInitialize();
			if (data.preInitializeSubGraphs)
			{
				ThreadSafeInitCall(PreInitializeSubGraphs);
			}
			ThreadSafeInitCall(delegate
			{
				localBlackboard.InitializePropertiesBinding(data.agent, callSetter: false);
			});
			hasInitialized = true;
		}

		public void Initialize(Component newAgent, IBlackboard newParentBlackboard, bool preInitializeSubGraphs)
		{
			UpdateReferences(newAgent, newParentBlackboard);
			OnGraphInitialize();
			if (preInitializeSubGraphs)
			{
				PreInitializeSubGraphs();
			}
			localBlackboard.InitializePropertiesBinding(newAgent, callSetter: false);
			hasInitialized = true;
		}

		private void PreInitializeSubGraphs()
		{
			foreach (IGraphAssignable item in allNodes.OfType<IGraphAssignable>())
			{
				Graph graph = item.CheckInstance();
				if (graph != null)
				{
					graph.Initialize(agent, blackboard.parent, preInitializeSubGraphs: true);
				}
			}
		}

		public void StartGraph(Component newAgent, IBlackboard newParentBlackboard, UpdateMode newUpdateMode, Action<bool> callback = null)
		{
			if ((newAgent == null && requiresAgent) || (primeNode == null && requiresPrimeNode) || (isRunning && !isPaused))
			{
				return;
			}
			if (!hasInitialized)
			{
				Initialize(newAgent, newParentBlackboard, preInitializeSubGraphs: false);
			}
			else
			{
				UpdateReferences(newAgent, newParentBlackboard);
			}
			if (callback != null)
			{
				this.onFinish = callback;
			}
			if (isRunning && isPaused)
			{
				Resume();
				return;
			}
			if (_runningGraphs == null)
			{
				_runningGraphs = new List<Graph>();
			}
			_runningGraphs.Add(this);
			elapsedTime = 0f;
			isRunning = true;
			isPaused = false;
			OnGraphStarted();
			for (int i = 0; i < allNodes.Count; i++)
			{
				allNodes[i].OnGraphStarted();
			}
			for (int j = 0; j < allNodes.Count; j++)
			{
				allNodes[j].OnPostGraphStarted();
			}
			if (isRunning)
			{
				updateMode = newUpdateMode;
				if (updateMode != UpdateMode.Manual)
				{
					MonoManager.current.AddUpdateCall((MonoManager.UpdateMode)updateMode, UpdateGraph);
				}
			}
		}

		public void Stop(bool success = true)
		{
			if (!isRunning)
			{
				return;
			}
			_runningGraphs.Remove(this);
			if (updateMode != UpdateMode.Manual)
			{
				MonoManager.current.RemoveUpdateCall((MonoManager.UpdateMode)updateMode, UpdateGraph);
			}
			for (int i = 0; i < allNodes.Count; i++)
			{
				Node node = allNodes[i];
				if (node is IGraphAssignable)
				{
					(node as IGraphAssignable).TryStopSubGraph();
				}
				node.Reset(recursively: false);
				node.OnGraphStoped();
			}
			for (int j = 0; j < allNodes.Count; j++)
			{
				allNodes[j].OnPostGraphStoped();
			}
			OnGraphStoped();
			isRunning = false;
			isPaused = false;
			if (this.onFinish != null)
			{
				this.onFinish(success);
				this.onFinish = null;
			}
			elapsedTime = 0f;
		}

		public void Pause()
		{
			if (!isRunning || isPaused)
			{
				return;
			}
			if (updateMode != UpdateMode.Manual)
			{
				MonoManager.current.RemoveUpdateCall((MonoManager.UpdateMode)updateMode, UpdateGraph);
			}
			isRunning = true;
			isPaused = true;
			for (int i = 0; i < allNodes.Count; i++)
			{
				Node node = allNodes[i];
				if (node is IGraphAssignable)
				{
					(node as IGraphAssignable).TryPauseSubGraph();
				}
				node.OnGraphPaused();
			}
			OnGraphPaused();
		}

		public void Resume()
		{
			if (!isRunning || !isPaused)
			{
				return;
			}
			isRunning = true;
			isPaused = false;
			OnGraphUnpaused();
			for (int i = 0; i < allNodes.Count; i++)
			{
				Node node = allNodes[i];
				if (node is IGraphAssignable)
				{
					(node as IGraphAssignable).TryResumeSubGraph();
				}
				node.OnGraphUnpaused();
			}
			if (updateMode != UpdateMode.Manual)
			{
				MonoManager.current.AddUpdateCall((MonoManager.UpdateMode)updateMode, UpdateGraph);
			}
		}

		public void Restart()
		{
			Stop();
			StartGraph(agent, blackboard, updateMode, this.onFinish);
		}

		public void UpdateGraph()
		{
			UpdateGraph(Time.deltaTime);
		}

		public void UpdateGraph(float deltaTime)
		{
			if (isRunning)
			{
				this.deltaTime = deltaTime;
				elapsedTime += deltaTime;
				lastUpdateFrame = Time.frameCount;
				OnGraphUpdate();
			}
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
			if (!(agent == null) && isRunning)
			{
				EventRouter component = agent.GetComponent<EventRouter>();
				if (component != null)
				{
					component.InvokeCustomEvent(name, value, sender);
				}
			}
		}

		public void SendEvent<T>(string name, T value, object sender)
		{
			if (!(agent == null) && isRunning)
			{
				EventRouter component = agent.GetComponent<EventRouter>();
				if (component != null)
				{
					component.InvokeCustomEvent(name, value, sender);
				}
			}
		}

		public static void SendGlobalEvent(string name, object value, object sender)
		{
			if (_runningGraphs == null)
			{
				return;
			}
			List<GameObject> list = new List<GameObject>();
			Graph[] array = _runningGraphs.ToArray();
			foreach (Graph graph in array)
			{
				if (graph.agent != null && !list.Contains(graph.agent.gameObject))
				{
					list.Add(graph.agent.gameObject);
					graph.SendEvent(name, value, sender);
				}
			}
		}

		public static void SendGlobalEvent<T>(string name, T value, object sender)
		{
			if (_runningGraphs == null)
			{
				return;
			}
			List<GameObject> list = new List<GameObject>();
			Graph[] array = _runningGraphs.ToArray();
			foreach (Graph graph in array)
			{
				if (graph.agent != null && !list.Contains(graph.agent.gameObject))
				{
					list.Add(graph.agent.gameObject);
					graph.SendEvent(name, value, sender);
				}
			}
		}

		public IEnumerable<BBParameter> GetAllParameters()
		{
			return allParameters;
		}

		public IEnumerable<Connection> GetAllConnections()
		{
			return allConnections;
		}

		public IEnumerable<T> GetAllTasksOfType<T>() where T : Task
		{
			return allTasks.OfType<T>();
		}

		public Node GetNodeWithID(int searchID)
		{
			if (searchID < allNodes.Count && searchID >= 0)
			{
				return allNodes.Find((Node n) => n.ID == searchID);
			}
			return null;
		}

		public IEnumerable<T> GetAllNodesOfType<T>() where T : Node
		{
			return allNodes.OfType<T>();
		}

		public T GetNodeWithTag<T>(string tagName) where T : Node
		{
			return allNodes.OfType<T>().FirstOrDefault((T n) => n.tag == tagName);
		}

		public IEnumerable<T> GetNodesWithTag<T>(string tagName) where T : Node
		{
			return from n in allNodes.OfType<T>()
				where n.tag == tagName
				select n;
		}

		public IEnumerable<T> GetAllTagedNodes<T>() where T : Node
		{
			return from n in allNodes.OfType<T>()
				where !string.IsNullOrEmpty(n.tag)
				select n;
		}

		public IEnumerable<Node> GetRootNodes()
		{
			return allNodes.Where((Node n) => n.inConnections.Count == 0);
		}

		public IEnumerable<Node> GetLeafNodes()
		{
			return allNodes.Where((Node n) => n.outConnections.Count == 0);
		}

		public IEnumerable<T> GetAllNestedGraphs<T>(bool recursive) where T : Graph
		{
			List<T> list = new List<T>();
			foreach (IGraphAssignable item in allNodes.OfType<IGraphAssignable>())
			{
				if (item.subGraph is T)
				{
					list.Add((T)item.subGraph);
					if (recursive)
					{
						list.AddRange(item.subGraph.GetAllNestedGraphs<T>(recursive));
					}
				}
			}
			return list.Distinct();
		}

		public IEnumerable<Graph> GetAllInstancedNestedGraphs()
		{
			List<Graph> list = new List<Graph>();
			foreach (IGraphAssignable item in allNodes.OfType<IGraphAssignable>())
			{
				if (item.instances == null)
				{
					continue;
				}
				Dictionary<Graph, Graph>.ValueCollection values = item.instances.Values;
				list.AddRange(values);
				foreach (Graph item2 in values)
				{
					list.AddRange(item2.GetAllInstancedNestedGraphs());
				}
			}
			return list;
		}

		public IEnumerable<BBParameter> GetDefinedParameters()
		{
			return allParameters.Where((BBParameter p) => p?.isDefined ?? false);
		}

		public void PromoteMissingParametersToVariables(IBlackboard bb)
		{
			foreach (BBParameter definedParameter in GetDefinedParameters())
			{
				if (definedParameter.varRef == null && !definedParameter.isPresumedDynamic)
				{
					definedParameter.PromoteToVariable(bb);
				}
			}
		}

		public static Graph GetElementGraph(object obj)
		{
			if (obj is GraphOwner)
			{
				return (obj as GraphOwner).graph;
			}
			if (obj is Graph)
			{
				return (Graph)obj;
			}
			if (obj is Node)
			{
				return (obj as Node).graph;
			}
			if (obj is Connection)
			{
				return (obj as Connection).graph;
			}
			if (obj is Task)
			{
				return (obj as Task).ownerSystem as Graph;
			}
			if (obj is BlackboardSource)
			{
				return (obj as BlackboardSource).unityContextObject as Graph;
			}
			return null;
		}

		public HierarchyTree.Element GetFlatMetaGraph()
		{
			if (flatMetaGraph != null)
			{
				return flatMetaGraph;
			}
			HierarchyTree.Element element = new HierarchyTree.Element(this);
			int lastID = 0;
			for (int i = 0; i < allNodes.Count; i++)
			{
				element.AddChild(GetTreeNodeElement(allNodes[i], recurse: false, ref lastID));
			}
			return flatMetaGraph = element;
		}

		public HierarchyTree.Element GetFullMetaGraph()
		{
			if (fullMetaGraph != null)
			{
				return fullMetaGraph;
			}
			HierarchyTree.Element element = new HierarchyTree.Element(this);
			int lastID = 0;
			if (primeNode != null)
			{
				element.AddChild(GetTreeNodeElement(primeNode, recurse: true, ref lastID));
			}
			for (int i = 0; i < allNodes.Count; i++)
			{
				Node node = allNodes[i];
				if (node.ID > lastID && node.inConnections.Count == 0)
				{
					element.AddChild(GetTreeNodeElement(node, recurse: true, ref lastID));
				}
			}
			return fullMetaGraph = element;
		}

		public HierarchyTree.Element GetNestedMetaGraph()
		{
			if (nestedMetaGraph != null)
			{
				return nestedMetaGraph;
			}
			HierarchyTree.Element element = new HierarchyTree.Element(this);
			DigNestedGraphs(this, element);
			return nestedMetaGraph = element;
		}

		private static void DigNestedGraphs(Graph currentGraph, HierarchyTree.Element currentElement)
		{
			for (int i = 0; i < currentGraph.allNodes.Count; i++)
			{
				if (currentGraph.allNodes[i] is IGraphAssignable graphAssignable && graphAssignable.subGraph != null)
				{
					DigNestedGraphs(graphAssignable.subGraph, currentElement.AddChild(new HierarchyTree.Element(graphAssignable)));
				}
			}
		}

		private static HierarchyTree.Element GetTreeNodeElement(Node node, bool recurse, ref int lastID)
		{
			HierarchyTree.Element element = CollectSubElements(node);
			for (int i = 0; i < node.outConnections.Count; i++)
			{
				HierarchyTree.Element element2 = CollectSubElements(node.outConnections[i]);
				element.AddChild(element2);
				if (recurse)
				{
					Node targetNode = node.outConnections[i].targetNode;
					if (targetNode.ID > node.ID)
					{
						element2.AddChild(GetTreeNodeElement(targetNode, recurse, ref lastID));
					}
				}
			}
			lastID = node.ID;
			return element;
		}

		private static HierarchyTree.Element CollectSubElements(IGraphElement obj)
		{
			HierarchyTree.Element parentElement = null;
			Stack<HierarchyTree.Element> stack = new Stack<HierarchyTree.Element>();
			JSONSerializer.SerializeAndExecuteNoCycles(obj.GetType(), obj, delegate(object o)
			{
				if (o is ISerializationCollectable)
				{
					HierarchyTree.Element element = new HierarchyTree.Element(o);
					if (stack.Count > 0)
					{
						stack.Peek().AddChild(element);
					}
					stack.Push(element);
				}
			}, delegate(object o, fsData d)
			{
				if (o is ISerializationCollectable)
				{
					parentElement = stack.Pop();
				}
			});
			return parentElement;
		}

		public IGraphElement GetTaskParentElement(Task targetTask)
		{
			return GetFlatMetaGraph().FindReferenceElement(targetTask)?.GetFirstParentReferenceOfType<IGraphElement>();
		}

		public IGraphElement GetParameterParentElement(BBParameter targetParameter)
		{
			return GetFlatMetaGraph().FindReferenceElement(targetParameter)?.GetFirstParentReferenceOfType<IGraphElement>();
		}

		public static IEnumerable<Task> GetTasksInElement(IGraphElement target)
		{
			List<Task> result = new List<Task>();
			JSONSerializer.SerializeAndExecuteNoCycles(target.GetType(), target, delegate(object o, fsData d)
			{
				if (o is Task)
				{
					result.Add((Task)o);
				}
			});
			return result;
		}

		public static IEnumerable<BBParameter> GetParametersInElement(IGraphElement target)
		{
			List<BBParameter> result = new List<BBParameter>();
			JSONSerializer.SerializeAndExecuteNoCycles(target.GetType(), target, delegate(object o, fsData d)
			{
				if (o is BBParameter)
				{
					result.Add((BBParameter)o);
				}
			});
			return result;
		}

		public T AddNode<T>() where T : Node
		{
			return (T)AddNode(typeof(T));
		}

		public T AddNode<T>(Vector2 pos) where T : Node
		{
			return (T)AddNode(typeof(T), pos);
		}

		public Node AddNode(Type nodeType)
		{
			return AddNode(nodeType, new Vector2(0f, 0f));
		}

		public Node AddNode(Type nodeType, Vector2 pos)
		{
			if (!nodeType.RTIsSubclassOf(baseNodeType))
			{
				return null;
			}
			Node node = Node.Create(this, nodeType, pos);
			allNodes.Add(node);
			if (primeNode == null)
			{
				primeNode = node;
			}
			UpdateNodeIDs(alsoReorderList: false);
			return node;
		}

		public void RemoveNode(Node node, bool recordUndo = true, bool force = false)
		{
			if ((!force && node.GetType().RTIsDefined<ProtectedSingletonAttribute>(inherited: true) && allNodes.Where((Node n) => n.GetType() == node.GetType()).Count() == 1) || !allNodes.Contains(node))
			{
				return;
			}
			if (!Application.isPlaying && isTree && node.inConnections.Count == 1 && node.outConnections.Count == 1)
			{
				Node targetNode = node.outConnections[0].targetNode;
				if (targetNode != node.inConnections[0].sourceNode)
				{
					RemoveConnection(node.outConnections[0]);
					node.inConnections[0].SetTargetNode(targetNode);
				}
			}
			node.OnDestroy();
			int count = node.inConnections.Count;
			while (count-- > 0)
			{
				RemoveConnection(node.inConnections[count]);
			}
			int count2 = node.outConnections.Count;
			while (count2-- > 0)
			{
				RemoveConnection(node.outConnections[count2]);
			}
			allNodes.Remove(node);
			if (node == primeNode)
			{
				primeNode = GetNodeWithID(primeNode.ID + 1);
			}
			UpdateNodeIDs(alsoReorderList: false);
		}

		public Connection ConnectNodes(Node sourceNode, Node targetNode, int sourceIndex = -1, int targetIndex = -1)
		{
			if (!Node.IsNewConnectionAllowed(sourceNode, targetNode))
			{
				return null;
			}
			Connection result = Connection.Create(sourceNode, targetNode, sourceIndex, targetIndex);
			UpdateNodeIDs(alsoReorderList: false);
			return result;
		}

		public void RemoveConnection(Connection connection, bool recordUndo = true)
		{
			if (Application.isPlaying)
			{
				connection.Reset();
			}
			connection.OnDestroy();
			connection.sourceNode.OnChildDisconnected(connection.sourceNode.outConnections.IndexOf(connection));
			connection.targetNode.OnParentDisconnected(connection.targetNode.inConnections.IndexOf(connection));
			connection.sourceNode.outConnections.Remove(connection);
			connection.targetNode.inConnections.Remove(connection);
			UpdateNodeIDs(alsoReorderList: false);
		}

		public static List<Node> CloneNodes(List<Node> originalNodes, Graph targetGraph = null, Vector2 originPosition = default(Vector2))
		{
			if (targetGraph != null && originalNodes.Any((Node n) => !n.GetType().IsSubclassOf(targetGraph.baseNodeType)))
			{
				return null;
			}
			List<Node> list = new List<Node>();
			Dictionary<Connection, KeyValuePair<int, int>> dictionary = new Dictionary<Connection, KeyValuePair<int, int>>();
			foreach (Node originalNode in originalNodes)
			{
				Node item = ((targetGraph != null) ? originalNode.Duplicate(targetGraph) : JSONSerializer.Clone(originalNode));
				list.Add(item);
				foreach (Connection outConnection in originalNode.outConnections)
				{
					int key = originalNodes.IndexOf(outConnection.sourceNode);
					int value = originalNodes.IndexOf(outConnection.targetNode);
					dictionary[outConnection] = new KeyValuePair<int, int>(key, value);
				}
			}
			foreach (KeyValuePair<Connection, KeyValuePair<int, int>> item2 in dictionary)
			{
				if (item2.Value.Value != -1)
				{
					Node newSource = list[item2.Value.Key];
					Node newTarget = list[item2.Value.Value];
					item2.Key.Duplicate(newSource, newTarget);
				}
			}
			if (originPosition != default(Vector2) && list.Count > 0)
			{
				if (list.Count == 1)
				{
					list[0].position = originPosition;
				}
				else
				{
					Vector2 vector = list[0].position - originPosition;
					list[0].position = originPosition;
					for (int num = 1; num < list.Count; num++)
					{
						list[num].position -= vector;
					}
				}
			}
			if (targetGraph != null)
			{
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					list[num2].Validate(targetGraph);
				}
			}
			return list;
		}

		public void ClearGraph()
		{
			canvasGroups = null;
			Node[] array = allNodes.ToArray();
			foreach (Node node in array)
			{
				RemoveNode(node);
			}
		}

		[Obsolete("Use 'Graph.StartGraph' with the 'Graph.UpdateMode' parameter.")]
		public void StartGraph(Component newAgent, IBlackboard newBlackboard, bool autoUpdate, Action<bool> callback = null)
		{
			StartGraph(newAgent, newBlackboard, (!autoUpdate) ? UpdateMode.Manual : UpdateMode.NormalUpdate, callback);
		}
	}
}
