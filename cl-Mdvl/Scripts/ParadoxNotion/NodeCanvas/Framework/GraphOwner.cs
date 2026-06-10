using System;
using System.Collections.Generic;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using ParadoxNotion.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace NodeCanvas.Framework
{
	public abstract class GraphOwner : MonoBehaviour, ISerializationCallbackReceiver
	{
		public enum EnableAction
		{
			EnableBehaviour = 0,
			DoNothing = 1
		}

		public enum DisableAction
		{
			DisableBehaviour = 0,
			PauseBehaviour = 1,
			DoNothing = 2
		}

		public enum FirstActivation
		{
			OnEnable = 0,
			OnStart = 1,
			Async = 2
		}

		[SerializeField]
		private SerializationPair[] _serializedExposedParameters;

		[SerializeField]
		[FormerlySerializedAs("boundGraphSerialization")]
		private string _boundGraphSerialization;

		[SerializeField]
		[FormerlySerializedAs("boundGraphObjectReferences")]
		private List<UnityEngine.Object> _boundGraphObjectReferences;

		[SerializeField]
		private GraphSource _boundGraphSource = new GraphSource();

		[SerializeField]
		[FormerlySerializedAs("firstActivation")]
		[Tooltip("When the graph will first activate. Async mode will load the graph on a separate thread (thus no spikes), but the graph will activate a few frames later.")]
		private FirstActivation _firstActivation;

		[SerializeField]
		[FormerlySerializedAs("enableAction")]
		[Tooltip("What will happen when the GraphOwner is enabled")]
		private EnableAction _enableAction;

		[SerializeField]
		[FormerlySerializedAs("disableAction")]
		[Tooltip("What will happen when the GraphOwner is disabled")]
		private DisableAction _disableAction;

		[SerializeField]
		[Tooltip("If enabled, bound graph prefab overrides in instances will not be possible")]
		private bool _lockBoundGraphPrefabOverrides = true;

		[SerializeField]
		[Tooltip("If enabled, all subgraphs will be pre-initialized in Awake along with the root graph, but this may have a loading performance cost")]
		private bool _preInitializeSubGraphs;

		[SerializeField]
		[Tooltip("Specify when (if) the behaviour is updated. Changes to this only work when the behaviour starts, or re-starts")]
		private Graph.UpdateMode _updateMode;

		private Dictionary<Graph, Graph> instances = new Dictionary<Graph, Graph>();

		public List<ExposedParameter> exposedParameters { get; set; }

		public abstract Graph graph { get; set; }

		public abstract IBlackboard blackboard { get; set; }

		public abstract Type graphType { get; }

		public bool initialized { get; private set; }

		public bool enableCalled { get; private set; }

		public bool startCalled { get; private set; }

		public GraphSource boundGraphSource
		{
			get
			{
				return _boundGraphSource;
			}
			private set
			{
				_boundGraphSource = value;
			}
		}

		public string boundGraphSerialization
		{
			get
			{
				return _boundGraphSerialization;
			}
			private set
			{
				_boundGraphSerialization = value;
			}
		}

		public List<UnityEngine.Object> boundGraphObjectReferences
		{
			get
			{
				return _boundGraphObjectReferences;
			}
			private set
			{
				_boundGraphObjectReferences = value;
			}
		}

		public bool lockBoundGraphPrefabOverrides
		{
			get
			{
				if (_lockBoundGraphPrefabOverrides)
				{
					return graphIsBound;
				}
				return false;
			}
			set
			{
				_lockBoundGraphPrefabOverrides = value;
			}
		}

		public bool preInitializeSubGraphs
		{
			get
			{
				return _preInitializeSubGraphs;
			}
			set
			{
				_preInitializeSubGraphs = value;
			}
		}

		public FirstActivation firstActivation
		{
			get
			{
				return _firstActivation;
			}
			set
			{
				_firstActivation = value;
			}
		}

		public EnableAction enableAction
		{
			get
			{
				return _enableAction;
			}
			set
			{
				_enableAction = value;
			}
		}

		public DisableAction disableAction
		{
			get
			{
				return _disableAction;
			}
			set
			{
				_disableAction = value;
			}
		}

		public Graph.UpdateMode updateMode
		{
			get
			{
				return _updateMode;
			}
			set
			{
				_updateMode = value;
			}
		}

		public bool graphIsBound => !string.IsNullOrEmpty(boundGraphSerialization);

		public bool isRunning
		{
			get
			{
				if (!(graph != null))
				{
					return false;
				}
				return graph.isRunning;
			}
		}

		public bool isPaused
		{
			get
			{
				if (!(graph != null))
				{
					return false;
				}
				return graph.isPaused;
			}
		}

		public float elapsedTime
		{
			get
			{
				if (!(graph != null))
				{
					return 0f;
				}
				return graph.elapsedTime;
			}
		}

		public static event Action<GraphOwner> onOwnerBehaviourStateChange;

		public event Action onMonoBehaviourStart;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (exposedParameters == null || exposedParameters.Count == 0)
			{
				_serializedExposedParameters = null;
				return;
			}
			_serializedExposedParameters = new SerializationPair[exposedParameters.Count];
			for (int i = 0; i < _serializedExposedParameters.Length; i++)
			{
				SerializationPair serializationPair = new SerializationPair();
				serializationPair._json = JSONSerializer.Serialize(typeof(ExposedParameter), exposedParameters[i], serializationPair._references);
				_serializedExposedParameters[i] = serializationPair;
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_serializedExposedParameters != null)
			{
				if (exposedParameters == null)
				{
					exposedParameters = new List<ExposedParameter>();
				}
				else
				{
					exposedParameters.Clear();
				}
				for (int i = 0; i < _serializedExposedParameters.Length; i++)
				{
					ExposedParameter item = JSONSerializer.Deserialize<ExposedParameter>(_serializedExposedParameters[i]._json, _serializedExposedParameters[i]._references);
					exposedParameters.Add(item);
				}
			}
		}

		protected Graph GetInstance(Graph originalGraph)
		{
			if (originalGraph == null)
			{
				return null;
			}
			if (!Application.isPlaying)
			{
				return originalGraph;
			}
			if (instances.ContainsValue(originalGraph))
			{
				return originalGraph;
			}
			if (!instances.TryGetValue(originalGraph, out var value))
			{
				value = Graph.Clone(originalGraph, null);
				instances[originalGraph] = value;
			}
			return value;
		}

		public Graph MakeRuntimeGraphInstance()
		{
			return graph = GetInstance(graph);
		}

		public void StartBehaviour()
		{
			StartBehaviour(updateMode);
		}

		public void StartBehaviour(Action<bool> callback)
		{
			StartBehaviour(updateMode, callback);
		}

		public void StartBehaviour(Graph.UpdateMode updateMode, Action<bool> callback = null)
		{
			graph = GetInstance(graph);
			if (graph != null)
			{
				graph.StartGraph(this, blackboard, updateMode, callback);
				GraphOwner.onOwnerBehaviourStateChange?.Invoke(this);
			}
		}

		public void PauseBehaviour()
		{
			if (graph != null)
			{
				graph.Pause();
				GraphOwner.onOwnerBehaviourStateChange?.Invoke(this);
			}
		}

		public void StopBehaviour(bool success = true)
		{
			if (graph != null)
			{
				graph.Stop(success);
				GraphOwner.onOwnerBehaviourStateChange?.Invoke(this);
			}
		}

		public void UpdateBehaviour()
		{
			graph?.UpdateGraph();
		}

		public void RestartBehaviour()
		{
			StopBehaviour();
			StartBehaviour();
		}

		public void SendEvent(string eventName)
		{
			graph?.SendEvent(eventName, null, null);
		}

		public void SendEvent(string eventName, object value, object sender)
		{
			graph?.SendEvent(eventName, value, sender);
		}

		public void SendEvent<T>(string eventName, T eventValue, object sender)
		{
			graph?.SendEvent(eventName, eventValue, sender);
		}

		public T GetExposedParameterValue<T>(string name)
		{
			ExposedParameter exposedParameter = exposedParameters.Find((ExposedParameter x) => x.varRefBoxed != null && x.varRefBoxed.name == name);
			if (exposedParameter == null)
			{
				return default(T);
			}
			return (exposedParameter as ExposedParameter<T>).value;
		}

		public void SetExposedParameterValue<T>(string name, T value)
		{
			ExposedParameter exposedParameter = exposedParameters?.Find((ExposedParameter x) => x.varRefBoxed != null && x.varRefBoxed.name == name);
			if (exposedParameter == null)
			{
				exposedParameter = MakeNewExposedParameter<T>(name);
			}
			if (exposedParameter != null)
			{
				(exposedParameter as ExposedParameter<T>).value = value;
			}
		}

		public ExposedParameter MakeNewExposedParameter<T>(string name)
		{
			if (exposedParameters == null)
			{
				exposedParameters = new List<ExposedParameter>();
			}
			Variable<T> variable = graph.blackboard.GetVariable<T>(name);
			if (variable != null && variable.isExposedPublic && !variable.isPropertyBound)
			{
				ExposedParameter exposedParameter = ExposedParameter.CreateInstance(variable);
				exposedParameter.Bind(graph.blackboard);
				exposedParameters.Add(exposedParameter);
				return exposedParameter;
			}
			return null;
		}

		protected void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (initialized || (this.graph == null && !graphIsBound))
			{
				return;
			}
			Graph graph = (Graph)ScriptableObject.CreateInstance(graphType);
			GraphSource graphSource;
			string serializedJsonData;
			List<UnityEngine.Object> serializedReferencesData;
			if (graphIsBound)
			{
				graph.name = graphType.Name;
				graphSource = boundGraphSource;
				serializedJsonData = boundGraphSerialization;
				serializedReferencesData = boundGraphObjectReferences;
				instances[graph] = graph;
			}
			else
			{
				graph.name = this.graph.name;
				graphSource = this.graph.GetGraphSource();
				serializedJsonData = this.graph.GetSerializedJsonData();
				serializedReferencesData = this.graph.GetSerializedReferencesData();
				instances[this.graph] = graph;
			}
			this.graph = graph;
			GraphLoadData data = new GraphLoadData
			{
				source = graphSource,
				json = serializedJsonData,
				references = serializedReferencesData,
				agent = this,
				parentBlackboard = blackboard,
				preInitializeSubGraphs = preInitializeSubGraphs
			};
			if (firstActivation == FirstActivation.Async)
			{
				this.graph.LoadOverwriteAsync(data, delegate
				{
					BindExposedParameters();
					if (!isRunning && enableAction == EnableAction.EnableBehaviour && base.gameObject.activeInHierarchy)
					{
						StartBehaviour();
						InvokeStartEvent();
					}
					initialized = true;
				});
			}
			else
			{
				this.graph.LoadOverwrite(data);
				BindExposedParameters();
				initialized = true;
			}
		}

		public void BindExposedParameters()
		{
			if (exposedParameters != null && graph != null)
			{
				for (int i = 0; i < exposedParameters.Count; i++)
				{
					exposedParameters[i].Bind(graph.blackboard);
				}
			}
		}

		public void UnBindExposedParameters()
		{
			if (exposedParameters != null)
			{
				for (int i = 0; i < exposedParameters.Count; i++)
				{
					exposedParameters[i].UnBind();
				}
			}
		}

		protected void OnEnable()
		{
			if ((firstActivation == FirstActivation.OnEnable || enableCalled) && (!isRunning || isPaused) && enableAction == EnableAction.EnableBehaviour)
			{
				StartBehaviour();
			}
			enableCalled = true;
		}

		protected void Start()
		{
			if (firstActivation == FirstActivation.OnStart && !isRunning && enableAction == EnableAction.EnableBehaviour)
			{
				StartBehaviour();
			}
			InvokeStartEvent();
			startCalled = true;
		}

		private void InvokeStartEvent()
		{
			if (this.onMonoBehaviourStart != null)
			{
				this.onMonoBehaviourStart();
				this.onMonoBehaviourStart = null;
			}
		}

		protected void OnDisable()
		{
			if (disableAction == DisableAction.DisableBehaviour)
			{
				StopBehaviour();
			}
			if (disableAction == DisableAction.PauseBehaviour)
			{
				PauseBehaviour();
			}
		}

		protected void OnDestroy()
		{
			if (Threader.applicationIsPlaying)
			{
				StopBehaviour();
			}
			foreach (Graph value in instances.Values)
			{
				foreach (Graph allInstancedNestedGraph in value.GetAllInstancedNestedGraphs())
				{
					UnityEngine.Object.Destroy(allInstancedNestedGraph);
				}
				UnityEngine.Object.Destroy(value);
			}
		}
	}
	public abstract class GraphOwner<T> : GraphOwner where T : Graph
	{
		[SerializeField]
		private T _graph;

		[SerializeField]
		private UnityEngine.Object _blackboard;

		public sealed override Graph graph
		{
			get
			{
				return _graph;
			}
			set
			{
				_graph = (T)value;
			}
		}

		public T behaviour
		{
			get
			{
				return (T)graph;
			}
			set
			{
				graph = value;
			}
		}

		public sealed override IBlackboard blackboard
		{
			get
			{
				if (!(_blackboard != null))
				{
					return null;
				}
				return _blackboard as IBlackboard;
			}
			set
			{
				if (_blackboard != value)
				{
					_blackboard = (UnityEngine.Object)value;
					graph?.UpdateReferences(this, value);
				}
			}
		}

		public sealed override Type graphType => typeof(T);

		public void StartBehaviour(T newGraph)
		{
			StartBehaviour(newGraph, base.updateMode);
		}

		public void StartBehaviour(T newGraph, Action<bool> callback)
		{
			StartBehaviour(newGraph, base.updateMode, callback);
		}

		public void StartBehaviour(T newGraph, Graph.UpdateMode updateMode, Action<bool> callback = null)
		{
			SwitchBehaviour(newGraph, updateMode, callback);
		}

		public void SwitchBehaviour(T newGraph)
		{
			SwitchBehaviour(newGraph, base.updateMode);
		}

		public void SwitchBehaviour(T newGraph, Action<bool> callback)
		{
			SwitchBehaviour(newGraph, base.updateMode, callback);
		}

		public void SwitchBehaviour(T newGraph, Graph.UpdateMode updateMode, Action<bool> callback = null)
		{
			StopBehaviour();
			graph = newGraph;
			StartBehaviour(updateMode, callback);
		}
	}
}
