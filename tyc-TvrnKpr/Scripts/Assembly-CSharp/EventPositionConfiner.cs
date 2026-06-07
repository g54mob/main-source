using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AK.Wwise;
using Gh;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EventPositionConfiner : MonoBehaviour
{
	public enum Camera
	{
		Tavern = 0,
		WorldMap = 1
	}

	[CompilerGenerated]
	private sealed class _003CClampEmitterPosition_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EventPositionConfiner _003C_003E4__this;

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
		public _003CClampEmitterPosition_003Ed__21(int _003C_003E1__state)
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

	[Header("Event to clamp to AkAudioListener")]
	public bool useStaticEventMode;

	public AK.Wwise.Event Event;

	[Header("Settings")]
	public float updateInterval;

	public Camera listenerCamera;

	private IEnumerator _positionClamperRoutine;

	private Collider[] _constraintColliders;

	private Transform _targetTransform;

	private Dictionary<string, GameObject> _eventEmitters;

	private Transform _emitterSocket;

	[SerializeField]
	private GameObject _emitterPrefab;

	public bool pauseWithTimeScaleOnEmitter;

	private void Awake()
	{
	}

	private SimpleSoundPlayer CreateEventEmitter()
	{
		return null;
	}

	private void OnActiveCameraChanged(object sender, EventArgs e)
	{
	}

	private void UpdateTargetTransform()
	{
	}

	public void PlayEventOnEmitter(AK.Wwise.Event eventData)
	{
	}

	public void StopEventOnEmitter(string soundEvent)
	{
	}

	public void StopAllEventsOnEmitter()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CClampEmitterPosition_003Ed__21))]
	private IEnumerator ClampEmitterPosition()
	{
		return null;
	}

	private void OnDrawGizmos()
	{
	}
}
