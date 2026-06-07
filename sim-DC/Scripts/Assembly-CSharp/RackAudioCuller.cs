using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RackAudioCuller : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCullLoop_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RackAudioCuller _003C_003E4__this;

		private WaitForSeconds _003Cwait_003E5__2;

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
		public _003CCullLoop_003Ed__13(int _003C_003E1__state)
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

	public static RackAudioCuller instance;

	[Tooltip("Max simultaneous rack audio sources")]
	public int maxActiveSources;

	[Tooltip("How often to re-evaluate (seconds)")]
	public float updateInterval;

	[Tooltip("Beyond this distance, never play")]
	public float maxDistance;

	[Tooltip("Volume fade speed (units per second)")]
	public float fadeSpeed;

	private readonly List<Rack> registeredRacks;

	private readonly List<(Rack rack, float sqrDist)> sortBuffer;

	private static readonly Comparison<(Rack rack, float sqrDist)> distCompare;

	private readonly HashSet<Rack> activeSet;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Register(Rack rack)
	{
	}

	public void Unregister(Rack rack)
	{
	}

	[IteratorStateMachine(typeof(_003CCullLoop_003Ed__13))]
	private IEnumerator CullLoop()
	{
		return null;
	}

	private void OnDestroy()
	{
	}
}
