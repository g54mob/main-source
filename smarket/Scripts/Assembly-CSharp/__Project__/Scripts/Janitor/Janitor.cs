using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using __Project__.Scripts.Janitor.StateMachineSystem;
using __Project__.Scripts.Janitor.States;
using __Project__.Scripts.Multiplayer;

namespace __Project__.Scripts.Janitor
{
	public class Janitor : MonoBehaviour, IInteractable
	{
		public enum CleaningType
		{
			Idle = 0,
			Garbage = 1,
			Dirt = 2,
			Dust = 3
		}

		public enum StateType
		{
			Idle = 0,
			Waiting = 1,
			MoveTarget = 2,
			GarbageCleaning = 3,
			DirtCleaning = 4,
			DustCleaning = 5,
			TrashBag = 6,
			TrashBin = 7
		}

		[CompilerGenerated]
		private sealed class _003CCleaningForJanitorCoroutine_003Ed__113 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Dirt dirt;

			public Janitor _003C_003E4__this;

			public Action endAction;

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
			public _003CCleaningForJanitorCoroutine_003Ed__113(int _003C_003E1__state)
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
		private sealed class _003CWaitCleaningDuration_003Ed__115 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Janitor _003C_003E4__this;

			public Action action;

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
			public _003CWaitCleaningDuration_003Ed__115(int _003C_003E1__state)
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

		[SerializeField]
		private NavMeshAgent m_Agent;

		[SerializeField]
		private JanitorAnimationController m_Animation;

		[SerializeField]
		private Animator m_Animator;

		[SerializeField]
		private BoostIndicator m_BoostIndicator;

		[SerializeField]
		private float m_BoostAmount;

		[SerializeField]
		private float m_BoostCost;

		[SerializeField]
		private float turningSpeed;

		[SerializeField]
		private TrashBag m_TrashBag;

		[SerializeField]
		private GameObject m_Sponge;

		[SerializeField]
		private GameObject m_Mop;

		[SerializeField]
		private Rig m_Rig;

		public float ScanningInterval;

		private int m_JanitorID;

		private int m_CurrentBoostLevel;

		private List<float> m_JanitorWalkingSpeeds;

		private GameObject m_CurrentSpeechObject;

		private NetworkJanitor m_NetworkJanitor;

		public GameObject TargetObject;

		public CleaningType cleaningType;

		private readonly StateMachine _stateMachine;

		private __Project__.Scripts.Janitor.States.IdleState _idleState;

		private WaitingState _waitingState;

		private MoveTargetState _moveTargetState;

		private GarbageCleaningState _garbageCleaningState;

		private DirtCleaningState _dirtCleaningState;

		private DustCleaningState _dustCleaningState;

		private TrashBagState _trashBagState;

		private TrashBinState _trashBinState;

		public StateType sType;

		public NavMeshAgent Agent => null;

		public float TurningSpeed => 0f;

		public InteractactableType Type => default(InteractactableType);

		public bool ContinousInteraction => false;

		public InteractionType InteractionType => default(InteractionType);

		public bool NeedRepair { get; set; }

		public string InstantInteractionHint => null;

		public string HoldingInteractionHint => null;

		public string SecondInteractionHint => null;

		public string RepairInteractionHint => null;

		public BoostIndicator BoostIndicator => null;

		public TrashBag TrashBag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameObject Sponge
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameObject Mop
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Rig Rig
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float CleaningDuration => 0f;

		public NetworkJanitor NetworkJanitor => null;

		public Transform TrashBinPosition => null;

		public Transform WaitingPosition => null;

		public int JanitorID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool RemoteInteract(string userId)
		{
			return false;
		}

		public bool CustomInteract()
		{
			return false;
		}

		public bool HoldingInteract()
		{
			return false;
		}

		public bool InstantInteract()
		{
			return false;
		}

		public void BoostJanitorNetwork()
		{
		}

		public void SetBoostJanitorNetwork(float m_BoostAmount)
		{
		}

		public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
		{
			return false;
		}

		public void NetworkClientHandle()
		{
		}

		public void ManualUpdate()
		{
		}

		public void EnableTrashBag()
		{
		}

		public void DisableTrashBag()
		{
		}

		public void SwitchTrashBag_Network(bool willEnable)
		{
		}

		private void SetJanitorBoost(int boostLevel)
		{
		}

		public void DustCleaningAnimation(bool value)
		{
		}

		public void DirtCleaningAnimation(bool value)
		{
		}

		public void FinishCleaningMopRoutine()
		{
		}

		public void FinishCleaningMopRoutine_Network()
		{
		}

		public void CleanDirt_Network(Dirt dirt)
		{
		}

		public void CleanDust_Network(Dust dust)
		{
		}

		public void FinishCleaningDustRoutine()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SetIdleState()
		{
		}

		public void SetWaitingState()
		{
		}

		public void SetMoveTargetState()
		{
		}

		public void SetGarbageCleaningState()
		{
		}

		public void SetDirtCleaningState()
		{
		}

		public void SetDustCleaningState()
		{
		}

		public void SetTrashBagState()
		{
		}

		public void SetTrashBinState()
		{
		}

		public void Clean()
		{
		}

		public void MoveToWaitingPosition()
		{
		}

		public void RotateAndCheck(Action endAction)
		{
		}

		public void JanitorDirtCleaning(Dirt dirt, Action endAction)
		{
		}

		[IteratorStateMachine(typeof(_003CCleaningForJanitorCoroutine_003Ed__113))]
		private IEnumerator CleaningForJanitorCoroutine(Dirt dirt, Action endAction)
		{
			return null;
		}

		public void DustCleaning(Action action)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitCleaningDuration_003Ed__115))]
		private IEnumerator WaitCleaningDuration(Action action)
		{
			return null;
		}
	}
}
