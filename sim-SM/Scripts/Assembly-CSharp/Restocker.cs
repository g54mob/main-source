using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Restocker : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CDropBox_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CDropBox_003Ed__107(int _003C_003E1__state)
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
	private sealed class _003CGoTo_003Ed__113 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		public Vector3 target;

		public Quaternion rotation;

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
		public _003CGoTo_003Ed__113(int _003C_003E1__state)
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
	private sealed class _003CGoToIdle_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CGoToIdle_003Ed__92(int _003C_003E1__state)
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
	private sealed class _003CGoToWaiting_003Ed__122 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		public RestockerState state;

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
		public _003CGoToWaiting_003Ed__122(int _003C_003E1__state)
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
	private sealed class _003CMergeBox_003Ed__106 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		public RackSlot targetSlot;

		private Box _003CminTargetBox_003E5__2;

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
		public _003CMergeBox_003Ed__106(int _003C_003E1__state)
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
	private sealed class _003CMoveTo_003Ed__114 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 target;

		public Restocker _003C_003E4__this;

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
		public _003CMoveTo_003Ed__114(int _003C_003E1__state)
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
	private sealed class _003CPerformRestocking_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CPerformRestocking_003Ed__108(int _003C_003E1__state)
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
	private sealed class _003CPickUpBox_003Ed__116 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool isFromRack;

		public Restocker _003C_003E4__this;

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
		public _003CPickUpBox_003Ed__116(int _003C_003E1__state)
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
	private sealed class _003CPlaceBoxFromStreet_003Ed__103 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		private List<int> _003CproductList_003E5__2;

		private List<int>.Enumerator _003C_003E7__wrap2;

		private int _003CproductId_003E5__4;

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
		public _003CPlaceBoxFromStreet_003Ed__103(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		private void _003C_003Em__Finally2()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CPlaceBoxFromVehicle_003Ed__102 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		private IEnumerator<GameObject> _003C_003E7__wrap1;

		private GameObject _003CvehicleGO_003E5__3;

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
		public _003CPlaceBoxFromVehicle_003Ed__102(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CPlaceBoxToRack_003Ed__109 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CPlaceBoxToRack_003Ed__109(int _003C_003E1__state)
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
	private sealed class _003CPlaceProducts_003Ed__118 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CPlaceProducts_003Ed__118(int _003C_003E1__state)
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
	private sealed class _003CRotateTo_003Ed__115 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		public Quaternion rotation;

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
		public _003CRotateTo_003Ed__115(int _003C_003E1__state)
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
	private sealed class _003CSoftResetRestocker_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CSoftResetRestocker_003Ed__98(int _003C_003E1__state)
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
	private sealed class _003CThrowBoxToTrashBin_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

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
		public _003CThrowBoxToTrashBin_003Ed__110(int _003C_003E1__state)
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
	private sealed class _003CTryRestocking_003Ed__99 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003CcurrentIndex_003E5__3;

		private bool _003CisBoxFromRack_003E5__4;

		private bool _003CfoundAvailableDisplaySlot_003E5__5;

		private bool _003CfoundAvailableRack_003E5__6;

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
		public _003CTryRestocking_003Ed__99(int _003C_003E1__state)
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
	private sealed class _003CTryRestockingWhileWaitingForEmptyRack_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Restocker _003C_003E4__this;

		private bool _003CfoundAvailableDisplaySlot_003E5__2;

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
		public _003CTryRestockingWhileWaitingForEmptyRack_003Ed__111(int _003C_003E1__state)
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

	private const float m_RotationSmoothness = 5f;

	private const float m_RotatingTime = 0.3f;

	private const float m_BoxTransitionTime = 0.3f;

	private const float m_TaskCheckInterval = 5f;

	private const float m_FullRacksWarningInterval = 20f;

	private List<float> m_RestockerAnimationSpeeds;

	private List<float> m_RestockerWalkingSpeeds;

	private List<float> m_RestockerPlacingSpeeds;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private RestockerAnimationController m_Animation;

	[SerializeField]
	private BoostIndicator m_BoostIndicator;

	[SerializeField]
	private float m_PlacingProductsInterval;

	[SerializeField]
	private float m_BoostAmount;

	[SerializeField]
	private float m_BoostCost;

	[SerializeField]
	private Transform m_BoxHolder;

	[Space]
	[SerializeField]
	[Range(0f, 1f)]
	private float m_MinFillRateForDisplaySlotsToRestock;

	private int m_RestockerID;

	private int m_CurrentBoostLevel;

	private int __tpd;

	private bool m_UsingVehicle;

	private RackSlot m_TargetRackSlot;

	private Box m_Box;

	private Box m_TargetBox;

	private LayerMask m_CurrentBoxLayer;

	private bool m_CarryingBox;

	private RestockerState m_State;

	private bool m_CheckTasks;

	private float m_LastTaskCheckTime;

	private float m_LastFullRacksWarningTime;

	private bool m_IsCarryBoxToRack;

	private bool m_Available;

	private GameObject m_CurrentSpeechObject;

	[SerializeField]
	private RestockerManagementData m_ManagementData;

	private IceCreamStand m_TargetStand;

	private NetworkRestocker m_NetworkRestocker;

	private List<DisplaySlot> m_CachedSlots;

	private List<DisplaySlot> m_AvailableDisplaySlotsCache;

	private int m_TargetProductID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private DisplaySlot m_TargetDisplaySlot { get; set; }

	public int RestockerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool CarryingBox
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public RestockerManagementData ManagementData => null;

	public GameObject CurrentSpeechObject
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public BoostIndicator BoostIndicator
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public NetworkRestocker NetworkRestocker => null;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnEmployeeManagerLoadDone()
	{
	}

	public void ManualUpdate()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void BoostRestockerNetwork()
	{
	}

	public void SetBoostRestockerNetwork(float m_BoostAmount)
	{
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	private void OnRestockerFired(Restocker restocker)
	{
	}

	private void LoadRestockerManagementData()
	{
	}

	public Box GetCurrentBox()
	{
		return null;
	}

	public void SetRestockerManagementData(RestockerManagementData ManagementData)
	{
	}

	[IteratorStateMachine(typeof(_003CGoToIdle_003Ed__92))]
	public IEnumerator GoToIdle()
	{
		return null;
	}

	public void ResetRestocker()
	{
	}

	public void FreeTargetDisplaySlot()
	{
	}

	public void DropTheBox()
	{
	}

	public void DropBoxToGround()
	{
	}

	public void DropBoxToGround_Network(Box _box)
	{
	}

	[IteratorStateMachine(typeof(_003CSoftResetRestocker_003Ed__98))]
	[ContextMenu("SoftResetRestocker")]
	public IEnumerator SoftResetRestocker()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CTryRestocking_003Ed__99))]
	private IEnumerator TryRestocking()
	{
		return null;
	}

	public List<int> GetAvailableProductIDList()
	{
		return null;
	}

	public List<int> GetAvailableProductIDListForMerge()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPlaceBoxFromVehicle_003Ed__102))]
	private IEnumerator PlaceBoxFromVehicle()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPlaceBoxFromStreet_003Ed__103))]
	private IEnumerator PlaceBoxFromStreet()
	{
		return null;
	}

	private RackSlot HasBoxAtRackForMerge(Box box)
	{
		return null;
	}

	private bool HasEmptySpaceForMergeInAnyRack(Box targetBox)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CMergeBox_003Ed__106))]
	private IEnumerator MergeBox(RackSlot targetSlot)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDropBox_003Ed__107))]
	private IEnumerator DropBox()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPerformRestocking_003Ed__108))]
	private IEnumerator PerformRestocking()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPlaceBoxToRack_003Ed__109))]
	private IEnumerator PlaceBoxToRack()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CThrowBoxToTrashBin_003Ed__110))]
	private IEnumerator ThrowBoxToTrashBin()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CTryRestockingWhileWaitingForEmptyRack_003Ed__111))]
	private IEnumerator TryRestockingWhileWaitingForEmptyRack()
	{
		return null;
	}

	private void ResetTargets()
	{
	}

	[IteratorStateMachine(typeof(_003CGoTo_003Ed__113))]
	private IEnumerator GoTo(Vector3 target, Quaternion rotation)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveTo_003Ed__114))]
	private IEnumerator MoveTo(Vector3 target)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRotateTo_003Ed__115))]
	private IEnumerator RotateTo(Quaternion rotation)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPickUpBox_003Ed__116))]
	private IEnumerator PickUpBox(bool isFromRack)
	{
		return null;
	}

	public void PickUpBox_Network(bool isFromRack, Box box, RackSlot rackSlot = null)
	{
	}

	[IteratorStateMachine(typeof(_003CPlaceProducts_003Ed__118))]
	private IEnumerator PlaceProducts()
	{
		return null;
	}

	public void PlaceProduct_Network(DisplaySlot displaySlot, Box box, int productId)
	{
	}

	private void PlaceBox()
	{
	}

	public void PlaceBox_Network(RackSlot targetRackSlot, Box box)
	{
	}

	[IteratorStateMachine(typeof(_003CGoToWaiting_003Ed__122))]
	private IEnumerator GoToWaiting(RestockerState state)
	{
		return null;
	}

	private bool GetAvailableDisplaySlotToRestock()
	{
		return false;
	}

	private bool IsDisplaySlotAvailableToRestock(DisplaySlot displaySlot)
	{
		return false;
	}

	public int GetAvailableDisplaySlotsNonAlloc(IEnumerable<DisplaySlot> from, List<DisplaySlot> to)
	{
		return 0;
	}

	private bool CheckForAvailableRackSlotToTakeBox()
	{
		return false;
	}

	private bool IsAvailableRackSlotToPlaceBox(int productID, int boxID)
	{
		return false;
	}

	private bool IsAvailableRackSlotToMerge(int productID, int boxID)
	{
		return false;
	}

	private bool CheckForAvailableRackSlotToPlaceBox()
	{
		return false;
	}

	private bool IsRackSlotStillAvailable(RackSlot rackSlot, int targetProductID)
	{
		return false;
	}

	private void SetRestockerBoost(int boostLevel)
	{
	}
}
