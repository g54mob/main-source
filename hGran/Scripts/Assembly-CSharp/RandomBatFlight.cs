using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class RandomBatFlight : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEvasionRoutine_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RandomBatFlight _003C_003E4__this;

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
		public _003CEvasionRoutine_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CFlightRoutine_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RandomBatFlight _003C_003E4__this;

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
		public _003CFlightRoutine_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CSoundRoutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RandomBatFlight _003C_003E4__this;

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
		public _003CSoundRoutine_003Ed__26(int _003C_003E1__state)
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
	private float flightRange;

	[SerializeField]
	private float flightSpeed;

	[SerializeField]
	private float rotationSpeed;

	[SerializeField]
	private float verticalMoveSpeed;

	[SerializeField]
	private float verticalAltitudeVariation;

	[SerializeField]
	private float raycastDistance;

	[SerializeField]
	private LayerMask obstacleLayer;

	[SerializeField]
	private float evasionCooldown;

	[SerializeField]
	private float raycastCheckFrequency;

	[SerializeField]
	private float minWaitTime;

	[SerializeField]
	private float maxWaitTime;

	[SerializeField]
	private AudioClip flightSoundClip;

	[SerializeField]
	private float minSoundDelay;

	[SerializeField]
	private float maxSoundDelay;

	private NavMeshAgent agent;

	private AudioSource audioSource;

	private Vector3 initialPosition;

	private float baseAltitudeOffset;

	private float targetAltitudeY;

	private float lastEvasionTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CEvasionRoutine_003Ed__23))]
	private IEnumerator EvasionRoutine()
	{
		return null;
	}

	private void CheckForObstaclesAndSteer()
	{
	}

	[IteratorStateMachine(typeof(_003CFlightRoutine_003Ed__25))]
	private IEnumerator FlightRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CSoundRoutine_003Ed__26))]
	private IEnumerator SoundRoutine()
	{
		return null;
	}

	private Vector3 GetRandomPointInNavMesh(Vector3 origin, float range)
	{
		return default(Vector3);
	}
}
