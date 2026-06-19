using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGenerateItems_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemSpawner _003C_003E4__this;

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
		public _003CGenerateItems_003Ed__21(int _003C_003E1__state)
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
	private ItemType _itemType;

	[SerializeField]
	private int _baseSpawnTime;

	[SerializeField]
	private int _maxSpawnCount;

	private float _spawnRateModifier;

	private float _maxSpawnCountModifier;

	private int _count;

	private Coroutine _coroutine;

	private bool _spawning;

	public List<Vector2> RelativeSpawnPositions;

	public float SpawnPositionSquareWidth;

	private bool _onDestroy;

	public LayerMask CollisionMask;

	private float MaxSpawnCount => 0f;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void TryStart()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CGenerateItems_003Ed__21))]
	public IEnumerator GenerateItems()
	{
		return null;
	}

	public void AddSpawnRate(float value)
	{
	}

	public void AddMaxSpawnCountModifier(float value)
	{
	}

	public void AddMaxSpawnCountM(int value)
	{
	}
}
