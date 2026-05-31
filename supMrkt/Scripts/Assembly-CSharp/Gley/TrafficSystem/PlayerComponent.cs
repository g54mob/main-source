using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gley.TrafficSystem.Internal;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem
{
	public class PlayerComponent : MonoBehaviour, ITrafficParticipant
	{
		public delegate void LaneChange();

		[CompilerGenerated]
		private sealed class _003CInitialize_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerComponent _003C_003E4__this;

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
			public _003CInitialize_003Ed__18(int _003C_003E1__state)
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

		private Rigidbody _rb;

		private List<TrafficWaypoint> _allWaypoints;

		private List<Vector2Int> _cellNeighbors;

		private Transform _myTransform;

		private GridDataHandler _gridDataHandler;

		private CellData _currentCell;

		private WaypointManager _waypointManager;

		private TrafficWaypointsDataHandler _trafficWaypointsDataHandler;

		private TrafficWaypoint _proposedTarget;

		private TrafficWaypoint _currentTarget;

		private bool _initialized;

		private bool _targetChanged;

		public event LaneChange OnLaneChange
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

		private void TriggetChangeDrivingStateEvent(int fromWaypointIndex, int toWaypointIndex)
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CInitialize_003Ed__18))]
		private IEnumerator Initialize()
		{
			return null;
		}

		private void Update()
		{
		}

		private bool CheckOrientation(TrafficWaypoint waypoint)
		{
			return false;
		}

		public float GetCurrentSpeedMS()
		{
			return 0f;
		}
	}
}
