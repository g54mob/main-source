using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class NetworkRackPlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseDoor_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkRackPlayer _003C_003E4__this;

		public bool stepAwayDevice;

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
		public _003CCloseDoor_003Ed__59(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003COpenDoor_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkRackPlayer _003C_003E4__this;

		private Vector3 _003ClookRotationLadderToRack_003E5__2;

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
		public _003COpenDoor_003Ed__56(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003CUpdateUIRestore_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkRackPlayer _003C_003E4__this;

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
		public _003CUpdateUIRestore_003Ed__57(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003CanimObject_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform obj;

		public Vector3 targetRotation;

		public bool stepAwayDevice;

		public float time;

		public Vector3 targetPosition;

		private Vector3 _003CstartPosition_003E5__2;

		private Quaternion _003CstartRotation_003E5__3;

		private Quaternion _003CtargetQuaternion_003E5__4;

		private float _003CelapsedTime_003E5__5;

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
		public _003CanimObject_003Ed__63(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003CanimObjectLocal_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform obj;

		public Vector3 targetRotation;

		public bool stepAwayDevice;

		public float time;

		public Vector3 targetPosition;

		private Vector3 _003CstartPosition_003E5__2;

		private Quaternion _003CstartRotation_003E5__3;

		private Quaternion _003CtargetQuaternion_003E5__4;

		private float _003CelapsedTime_003E5__5;

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
		public _003CanimObjectLocal_003Ed__64(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003CanimObjectRotationGlobal_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform obj;

		public Vector3 targetRotation;

		public bool stepAwayDevice;

		public float time;

		private Quaternion _003CstartRotation_003E5__2;

		private Quaternion _003CtargetQuaternion_003E5__3;

		private float _003CelapsedTime_003E5__4;

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
		public _003CanimObjectRotationGlobal_003Ed__62(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003CanimObjectRotationLocal_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform obj;

		public Vector3 targetRotation;

		public bool stepAwayDevice;

		public float time;

		private Quaternion _003CstartRotation_003E5__2;

		private Quaternion _003CtargetQuaternion_003E5__3;

		private float _003CelapsedTime_003E5__4;

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
		public _003CanimObjectRotationLocal_003Ed__61(int _003C_003E1__state)
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
	}

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Components")]
	public ButtonInformationByDevice buttonInformationByDevice;

	[Header("Status")]
	public RackStatus rackStatus;

	[Header("Player")]
	public Transform player;

	public Transform playerCamera;

	public PlayerController playerController;

	public PlayerControllerDepthOfField playerControllerDepthOfField;

	public PostProcessProfile processProfile;

	[Header("Other")]
	public Transform[] animPoint;

	public Transform Ladder;

	public Transform Door;

	public Vector3 RotationCameraToRack;

	public bool usingRack;

	[Header("Canvas")]
	public RectTransform UIEQ;

	public RectTransform UICanvas;

	public RectTransform IconRestore;

	public RectTransform IconRestart;

	public TMP_Text ButtonRestoreText;

	public TMP_Text ButtonRestartText;

	public TMP_Text TextDevice;

	public TMP_Text TextIP;

	public UnityEngine.Object DeviceScript;

	public Button ButtonRestore;

	public Button ButtonRestart;

	public Button ButtonDisconnect;

	public Button ButtonConnect;

	[Header("Audio Settings")]
	public AudioSource audioSource;

	public AudioClip clip;

	public float clipStartTime;

	public AudioClip ladderUp;

	public float ladderUpStartTime;

	public AudioClip ladderMoreStepBack;

	public float ladderMoreStepBackStartTime;

	public AudioClip ladderDown;

	public float ladderDownStartTime;

	public AudioClip openRACK;

	public float openRACKStartTime;

	public AudioClip closeRACK;

	public float closeRACKStartTime;

	[Header("Actions")]
	public UnityEvent DisconnectAction;

	public UnityEvent ConnectAction;

	public UnityEvent RestorAction;

	public UnityEvent RestartAction;

	public UnityEvent ActionClose;

	private Vector3 cameraPositionPlayer;

	private Vector3 cameraRotationPlayer;

	private Vector3 LadderPositionPlayer;

	private Vector3 LadderRotationPlayer;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private bool CanOpedDoor()
	{
		return false;
	}

	private bool CanCloseDoor()
	{
		return false;
	}

	private void InteractionCodeOpen(KeyCode key, object[] param)
	{
	}

	private void InteractionCodeClose(KeyCode key, object[] param)
	{
	}

	[IteratorStateMachine(typeof(_003COpenDoor_003Ed__56))]
	public IEnumerator OpenDoor()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CUpdateUIRestore_003Ed__57))]
	private IEnumerator UpdateUIRestore()
	{
		return null;
	}

	public Vector3 CalculateRotation(Vector3 posStart, Vector3 posEnd)
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003CCloseDoor_003Ed__59))]
	public IEnumerator CloseDoor(bool stepAwayDevice = false)
	{
		return null;
	}

	public void StepAwayDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CanimObjectRotationLocal_003Ed__61))]
	public IEnumerator animObjectRotationLocal(Transform obj, Vector3 targetRotation, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CanimObjectRotationGlobal_003Ed__62))]
	public IEnumerator animObjectRotationGlobal(Transform obj, Vector3 targetRotation, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CanimObject_003Ed__63))]
	public IEnumerator animObject(Transform obj, Vector3 targetPosition, Vector3 targetRotation, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CanimObjectLocal_003Ed__64))]
	public IEnumerator animObjectLocal(Transform obj, Vector3 targetPosition, Vector3 targetRotation, float time, bool stepAwayDevice = false)
	{
		return null;
	}
}
