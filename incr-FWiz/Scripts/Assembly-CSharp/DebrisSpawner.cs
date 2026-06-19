using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTrySpawn_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DebrisSpawner _003C_003E4__this;

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
		public _003CTrySpawn_003Ed__13(int _003C_003E1__state)
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

	public List<int> DebrisIDs;

	public int MaxDebrisCount;

	public float BaseSpawnInterval;

	private float _spawnIntervalModifier;

	public List<Debris> SpawnPool;

	public float CollisionRadius;

	public LayerMask CollisionMask;

	public List<DebrisSpawnArea> SpawnAreas;

	private bool _runningSpawnRoutine;

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	public void OnDebrisDestroyed(Debris debris)
	{
	}

	public void TryStartSpawning()
	{
	}

	[IteratorStateMachine(typeof(_003CTrySpawn_003Ed__13))]
	public IEnumerator TrySpawn()
	{
		return null;
	}

	public void AddSpawnIntervalModifier(float addition)
	{
	}

	public bool SpawnDebris()
	{
		return false;
	}
}
