using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Technician : MonoBehaviour
{
	private enum TechnicianState
	{
		Idle = 0,
		GoingForNewServer = 1,
		BringingNewServer = 2,
		GoingBackWithOldServer = 3,
		EndingHisWork = 4
	}

	[CompilerGenerated]
	private sealed class _003CGettingNewServer_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

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
		public _003CGettingNewServer_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CReplacingServer_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

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
		public _003CReplacingServer_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003CRequestJobDelayed_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

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
		public _003CRequestJobDelayed_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CSendToContainer_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

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
		public _003CSendToContainer_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003CSetHandIKWeight_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

		public float duration;

		public float targetWeight;

		private float _003CstartLeft_003E5__2;

		private float _003CstartRight_003E5__3;

		private float _003Celapsed_003E5__4;

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
		public _003CSetHandIKWeight_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003CStartTextingAnimation_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

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
		public _003CStartTextingAnimation_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003CThrowingOutServer_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Technician _003C_003E4__this;

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
		public _003CThrowingOutServer_003Ed__32(int _003C_003E1__state)
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

	public int technicianID;

	public string technicianName;

	public int salary;

	[SerializeField]
	private Transform transformIdle;

	[SerializeField]
	private Transform transformContainer;

	[SerializeField]
	private Transform transformDumpster;

	[SerializeField]
	private Transform transformInHandPosition;

	[SerializeField]
	private Transform transformDeviceSpawnPosition;

	private AICharacterControl characterControl;

	private Transform positionOfDeviceToBeReplaced;

	private GameObject deviceInHand;

	private NetworkSwitch networkSwitch;

	private Server server;

	[Header("Hand IK (Animation Rigging)")]
	[SerializeField]
	private TwoBoneIKConstraint leftHandIK;

	[SerializeField]
	private TwoBoneIKConstraint rightHandIK;

	[SerializeField]
	private Transform leftHandTarget;

	[SerializeField]
	private Transform rightHandTarget;

	private TechnicianState currentState;

	public bool isBusy;

	private TechnicianManager.RepairJob? currentJob;

	public TechnicianManager.RepairJob? CurrentJob => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CRequestJobDelayed_003Ed__25))]
	private IEnumerator RequestJobDelayed()
	{
		return null;
	}

	public void AssignJob(TechnicianManager.RepairJob job)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CStartTextingAnimation_003Ed__28))]
	private IEnumerator StartTextingAnimation()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CSendToContainer_003Ed__29))]
	private IEnumerator SendToContainer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGettingNewServer_003Ed__30))]
	private IEnumerator GettingNewServer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CReplacingServer_003Ed__31))]
	private IEnumerator ReplacingServer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CThrowingOutServer_003Ed__32))]
	private IEnumerator ThrowingOutServer()
	{
		return null;
	}

	private void RepairDevice()
	{
	}

	private GameObject GetCorrectDevicePrefab()
	{
		return null;
	}

	private void RotateTowardsGoal(Vector3 goal)
	{
	}

	[IteratorStateMachine(typeof(_003CSetHandIKWeight_003Ed__36))]
	private IEnumerator SetHandIKWeight(float targetWeight, float duration = 0.1f)
	{
		return null;
	}

	private void PositionHandTargetsOnDevice(GameObject device)
	{
	}

	private void OnLoadingStarted()
	{
	}

	private void OnDestroy()
	{
	}
}
