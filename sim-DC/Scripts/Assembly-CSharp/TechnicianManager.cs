using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TechnicianManager : MonoBehaviour
{
	public struct RepairJob
	{
		public NetworkSwitch networkSwitch;

		public Server server;

		public Technician assignedTechnician;

		public string DeviceName => null;
	}

	[CompilerGenerated]
	private sealed class _003CProcessDispatchQueue_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TechnicianManager _003C_003E4__this;

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
		public _003CProcessDispatchQueue_003Ed__21(int _003C_003E1__state)
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

	public static TechnicianManager instance;

	public List<Technician> technicians;

	public Transform[] transformIdle;

	public Transform transformContainer;

	public Transform transformDumpster;

	public Transform transformDeviceSpawnPosition;

	private int lastAssignedIndex;

	public int[] hiredTechnicians;

	private Queue<RepairJob> jobQueue;

	private const float DISPATCH_INTERVAL = 2f;

	private float lastDispatchTime;

	private Queue<RepairJob> pendingDispatches;

	private Coroutine dispatchCoroutine;

	public int QueuedJobCount => 0;

	private void Awake()
	{
	}

	public void AddTechnician(Technician technician)
	{
	}

	public void SendTechnician(NetworkSwitch networkSwitch, Server server)
	{
	}

	public void RequestNextJob(Technician technician)
	{
	}

	private void EnqueueDispatch(RepairJob job)
	{
	}

	[IteratorStateMachine(typeof(_003CProcessDispatchQueue_003Ed__21))]
	private IEnumerator ProcessDispatchQueue()
	{
		return null;
	}

	public List<RepairJob> GetQueuedJobs()
	{
		return null;
	}

	public List<RepairJob> GetActiveJobs()
	{
		return null;
	}

	public bool IsDeviceAlreadyAssigned(NetworkSwitch networkSwitch, Server server)
	{
		return false;
	}

	public void RestoreJobQueue(List<RepairJobSaveData> savedJobs)
	{
	}

	public void FireTechnician(int technicianID)
	{
	}
}
