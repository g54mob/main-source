using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSpawnLoop_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CreatureSpawner _003C_003E4__this;

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
		public _003CSpawnLoop_003Ed__27(int _003C_003E1__state)
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
	private Creature _creaturePrefab;

	[SerializeField]
	private float _maxSpawnProximity;

	[SerializeField]
	private float _minSpawnInterval;

	[SerializeField]
	private float _maxSpawnInterval;

	[SerializeField]
	private int _maxCreatures;

	private float _spawnRateModifier;

	private bool _doingSpawnLoop;

	[SerializeField]
	private bool _spawningOn;

	private Coroutine _spawnLoopCoroutine;

	public List<Vector2> RelativePositions;

	public Vector2 ReleativePositionUncertainty;

	public List<Creature> Creatures { get; private set; }

	private bool CanStartSpawning => false;

	private bool CanContinueSpawning => false;

	public void SetSpawning(bool spawningOn)
	{
	}

	public void EnableSpawning()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void TryStartSpawning()
	{
	}

	public void TryStopSpawning()
	{
	}

	private void OnDestroy()
	{
	}

	private void InitiateCreature(Creature creature)
	{
	}

	private void OnCreatureDestroyed(Creature creature)
	{
	}

	public void TrySpawnCreature()
	{
	}

	public Vector2 GetRandomRelativePosition()
	{
		return default(Vector2);
	}

	public bool TryGetLocalSpawnPosition(out Vector2 position)
	{
		position = default(Vector2);
		return false;
	}

	[IteratorStateMachine(typeof(_003CSpawnLoop_003Ed__27))]
	public IEnumerator SpawnLoop()
	{
		return null;
	}

	public void AddSpawnRateModifier(float multiplier)
	{
	}

	public void AddCapacity(int amount)
	{
	}
}
