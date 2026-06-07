using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChristmasBombBreak : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSpawnParticlesAfterDelay_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChristmasBombBreak _003C_003E4__this;

		public Vector3 spawnPos;

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
		public _003CSpawnParticlesAfterDelay_003Ed__7(int _003C_003E1__state)
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

	[Header("Assign in Inspector")]
	public GameObject gameController;

	public GameObject particleEffectPrefab;

	public AudioClip breakSound;

	[Header("Sound Settings")]
	public float soundVolume;

	private bool hasTriggered;

	public virtual void Start()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnParticlesAfterDelay_003Ed__7))]
	private IEnumerator SpawnParticlesAfterDelay(Vector3 spawnPos)
	{
		return null;
	}
}
