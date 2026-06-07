using System;
using System.ComponentModel;
using System.Diagnostics;
using Coherence.Connection;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Coherence Input")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CoherenceSync))]
	[DefaultExecutionOrder(-800)]
	[NonBindable]
	[HelpURL("https://docs.coherence.io/v/1.6/manual/authority/server-authoritative-setup")]
	public class CoherenceInput : MonoBehaviour, ICoherenceInput
	{
		public const int MaxInputs = 32;

		[Tooltip("Initial size of the input buffer. Defines how many simulation frames worth of inputs can be stored.")]
		public int InitialBufferSize;

		[FormerlySerializedAs("InitialBufferDelay")]
		[Tooltip("Initial input delay. Defines how into the future inputs are scheduled (in frames).")]
		public int InitialInputDelay;

		[Tooltip("Defines whether the client should automatically disconnect in case of unexpected time reset (resync with the server). Works only with the client-side simulation.")]
		public bool DisconnectOnTimeReset;

		[Tooltip("Defines whether the host that has the state authority over this entity should destroy it when the client with input authority disconnects from the session. Works with server-side simulation.")]
		public bool DestroyOnInputAuthorityDisconnected;

		[Tooltip("If true the input system will use the client fixed simulation frame (otherwise the standard client simulation frame will be used). Recommended for deterministic output.")]
		public bool UseFixedSimulationFrames;

		[SerializeField]
		[FormerlySerializedAs("_fields")]
		private Field[] fields;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, bool> internalSetButton;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, bool> internalGetButton;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, float> internalSetAxis;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, float> internalGetAxis;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, Vector2> internalSetAxis2D;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, Vector2> internalGetAxis2D;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, Vector3> internalSetAxis3D;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, Vector3> internalGetAxis3D;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, Quaternion> internalSetRotation;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, Quaternion> internalGetRotation;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, int> internalSetInteger;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, int> internalGetInteger;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<string, string> internalSetString;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<string, long?, string> internalGetString;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Action<IEntityInput, long> internalOnInputReceived;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Func<IInputBuffer> internalRequestBuffer;

		private Coherence.Log.Logger logger;

		private IInputBuffer inputBuffer;

		private ICoherenceSync coherenceSync;

		private ICoherenceBridge bridge;

		private IClient client;

		private int timeResetsAllowed;

		private bool autoRequestingAuthority;

		public Field[] Fields => null;

		private bool ShouldDestroyOnInputAuthorityGained => false;

		public bool IsServerSimulated => false;

		public long CurrentSimulationFrame => 0L;

		public bool IsReadyToProcessInputs => false;

		public bool IsInputOwner => false;

		public bool IsProducer => false;

		public bool ProcessingEnabled { get; set; }

		public int BufferSize => 0;

		public int Delay
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public long LastFrame => 0L;

		public long LastSentFrame => 0L;

		public long LastReceivedFrame => 0L;

		public long LastAcknowledgedFrame => 0L;

		public long LastConsumedFrame => 0L;

		public long? MispredictionFrame => null;

		public IInputBuffer Buffer => null;

		internal CoherenceInputDebugger Debugger { get; set; }

		internal bool isSimulatorOrHostConnected { get; private set; }

		public event StaleInputHandler OnStaleInput
		{
			add
			{
			}
			remove
			{
			}
		}

		private CoherenceInput()
		{
		}

		private void Awake()
		{
		}

		internal void Setup(ICoherenceSync sync, ICoherenceBridge bridge)
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		internal void SetAutoRequestingAuthority()
		{
		}

		private void DestroySelf()
		{
		}

		private void SetAllowedTimeResets(ClientID _)
		{
		}

		private void HandleTimeReset()
		{
		}

		protected void Update()
		{
		}

		private void DetectHost()
		{
		}

		internal void ProcessAutoRequestingAuthority()
		{
		}

		public bool ShouldPause(long commonReceivedFrame)
		{
			return false;
		}

		public void SetButton(string buttonName, bool value)
		{
		}

		public void SetAxis(string axisName, float value)
		{
		}

		public void SetAxis2D(string axis2DName, Vector2 value)
		{
		}

		public void SetAxis3D(string axis3DName, Vector3 value)
		{
		}

		public void SetRotation(string rotationName, Quaternion value)
		{
		}

		public void SetInteger(string integerName, int value)
		{
		}

		public void SetString(string stringName, string value)
		{
		}

		public bool GetButton(string buttonName, long? simulationFrame = null)
		{
			return false;
		}

		public float GetAxis(string axisName, long? simulationFrame = null)
		{
			return 0f;
		}

		public Vector2 GetAxis2D(string axis2DName, long? simulationFrame = null)
		{
			return default(Vector2);
		}

		public Vector3 GetAxis3D(string axis3DName, long? simulationFrame = null)
		{
			return default(Vector3);
		}

		public Quaternion GetRotation(string rotationName, long? simulationFrame = null)
		{
			return default(Quaternion);
		}

		public int GetInteger(string integerName, long? simulationFrame = null)
		{
			return 0;
		}

		public string GetString(string stringName, long? simulationFrame = null)
		{
			return null;
		}

		internal void HandleInputReceived(IEntityInput input, long inputFrame)
		{
		}

		private void PrintMethodMissingError(string methodName)
		{
		}

		private bool AssertValidInputProducer(string setterName, string getterName)
		{
			return false;
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void DebugOnInputReceived(long frame, object input)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void DebugOnInputSent(long frame, object input)
		{
		}

		private bool VerifyCoherenceSync()
		{
			return false;
		}
	}
}
