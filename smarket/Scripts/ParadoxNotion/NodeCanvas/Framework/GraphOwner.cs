using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
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
		private GraphSource _boundGraphSource;

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
		private bool _lockBoundGraphPrefabOverrides;

		[SerializeField]
		[Tooltip("If enabled, all subgraphs will be pre-initialized in Awake along with the root graph, but this may have a loading performance cost")]
		private bool _preInitializeSubGraphs;

		[SerializeField]
		[Tooltip("Specify when (if) the behaviour is updated. Changes to this only work when the behaviour starts, or re-starts")]
		private Graph.UpdateMode _updateMode;

		private Dictionary<Graph, Graph> instances;

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
				return null;
			}
			private set
			{
			}
		}

		public string boundGraphSerialization
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public List<UnityEngine.Object> boundGraphObjectReferences
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public bool lockBoundGraphPrefabOverrides
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool preInitializeSubGraphs
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FirstActivation firstActivation
		{
			get
			{
				return default(FirstActivation);
			}
			set
			{
			}
		}

		public EnableAction enableAction
		{
			get
			{
				return default(EnableAction);
			}
			set
			{
			}
		}

		public DisableAction disableAction
		{
			get
			{
				return default(DisableAction);
			}
			set
			{
			}
		}

		public Graph.UpdateMode updateMode
		{
			get
			{
				return default(Graph.UpdateMode);
			}
			set
			{
			}
		}

		public bool graphIsBound => false;

		public bool isRunning => false;

		public bool isPaused => false;

		public float elapsedTime => 0f;

		public static event Action<GraphOwner> onOwnerBehaviourStateChange
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

		public event Action onMonoBehaviourStart
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

		protected Graph GetInstance(Graph originalGraph)
		{
			return null;
		}

		public Graph MakeRuntimeGraphInstance()
		{
			return null;
		}

		public void StartBehaviour()
		{
		}

		public void StartBehaviour(Action<bool> callback)
		{
		}

		public void StartBehaviour(Graph.UpdateMode updateMode, Action<bool> callback = null)
		{
		}

		public void PauseBehaviour()
		{
		}

		public void StopBehaviour(bool success = true)
		{
		}

		public void UpdateBehaviour()
		{
		}

		public void RestartBehaviour()
		{
		}

		public void SendEvent(string eventName)
		{
		}

		public void SendEvent(string eventName, object value, object sender)
		{
		}

		public void SendEvent<T>(string eventName, T eventValue, object sender)
		{
		}

		public T GetExposedParameterValue<T>(string name)
		{
			return default(T);
		}

		public void SetExposedParameterValue<T>(string name, T value)
		{
		}

		public ExposedParameter MakeNewExposedParameter<T>(string name)
		{
			return null;
		}

		protected void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void BindExposedParameters()
		{
		}

		public void UnBindExposedParameters()
		{
		}

		protected void OnEnable()
		{
		}

		protected void Start()
		{
		}

		private void InvokeStartEvent()
		{
		}

		protected void OnDisable()
		{
		}

		protected void OnDestroy()
		{
		}
	}
	public abstract class GraphOwner<T> : GraphOwner
	{
		[SerializeField]
		private T _graph;

		[SerializeField]
		private UnityEngine.Object _blackboard;

		public sealed override Graph graph
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public T behaviour
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public sealed override IBlackboard blackboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public sealed override Type graphType => null;

		public void StartBehaviour(T newGraph)
		{
		}

		public void StartBehaviour(T newGraph, Action<bool> callback)
		{
		}

		public void StartBehaviour(T newGraph, Graph.UpdateMode updateMode, Action<bool> callback = null)
		{
		}

		public void SwitchBehaviour(T newGraph)
		{
		}

		public void SwitchBehaviour(T newGraph, Action<bool> callback)
		{
		}

		public void SwitchBehaviour(T newGraph, Graph.UpdateMode updateMode, Action<bool> callback = null)
		{
		}
	}
}
