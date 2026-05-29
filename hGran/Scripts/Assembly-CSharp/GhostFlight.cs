using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GhostFlight : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFlightRoutine_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GhostFlight _003C_003E4__this;

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
		public _003CFlightRoutine_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CSoundRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GhostFlight _003C_003E4__this;

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
		public _003CSoundRoutine_003Ed__19(int _003C_003E1__state)
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

	[Header("Flight Parameters")]
	[Tooltip("The speed at which the ghost moves between targets.")]
	[SerializeField]
	private float flightSpeed;

	[Tooltip("The rotation speed for turning towards the target.")]
	[SerializeField]
	private float rotationSpeed;

	[Tooltip("How close the ghost needs to get to the current target before picking a new one. This also defines the start of the deceleration zone.")]
	[SerializeField]
	private float targetReachedDistance;

	[Header("Start Delay")]
	[Tooltip("Time in seconds the ghost waits motionless before starting its random flight routine.")]
	[SerializeField]
	private float startDelay;

	[Header("Flight Volume (The Six Walls)")]
	[Tooltip("Minimum boundary for the X-axis (West wall).")]
	[SerializeField]
	private float minX;

	[Tooltip("Maximum boundary for the X-axis (East wall).")]
	[SerializeField]
	private float maxX;

	[Tooltip("Minimum boundary for the Z-axis (North wall).")]
	[SerializeField]
	private float minZ;

	[Tooltip("Maximum boundary for the Z-axis (South wall).")]
	[SerializeField]
	private float maxZ;

	[Tooltip("Minimum boundary for the Y-axis (Floor/Bottom).")]
	[SerializeField]
	private float minY;

	[Tooltip("Maximum boundary for the Y-axis (Ceiling/Top).")]
	[SerializeField]
	private float maxY;

	[Header("Audio Settings")]
	[Tooltip("An array of AudioClips the ghost will play randomly.")]
	[SerializeField]
	private AudioClip[] flightSounds;

	[Tooltip("Minimum delay in seconds between random ghost sounds.")]
	[SerializeField]
	private float minSoundDelay;

	[Tooltip("Maximum delay in seconds between random ghost sounds.")]
	[SerializeField]
	private float maxSoundDelay;

	private Vector3 initialPosition;

	private Vector3 currentTarget;

	private AudioSource audioSource;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CFlightRoutine_003Ed__18))]
	private IEnumerator FlightRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CSoundRoutine_003Ed__19))]
	private IEnumerator SoundRoutine()
	{
		return null;
	}

	private Vector3 GetNewRandomTarget()
	{
		return default(Vector3);
	}

	private void OnDrawGizmosSelected()
	{
	}
}
