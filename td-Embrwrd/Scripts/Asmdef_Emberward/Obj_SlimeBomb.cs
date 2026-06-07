using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_SlimeBomb : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_JumpToExplode_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SlimeBomb _003C_003E4__this;

		public Vector3 targetPosition;

		public float jumpHeight;

		public float duration;

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
		public _003CCR_JumpToExplode_003Ed__20(int _003C_003E1__state)
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
	private GameObject node_Model;

	[SerializeField]
	private ParticleSystem particle_Explosion;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private float explosionRange;

	[SerializeField]
	private bool isDeployed;

	[SerializeField]
	private bool isExploded;

	private AMonsterBase targetMonster;

	private int damage;

	private ABaseTower fromTower;

	private float detectInterval;

	private float detectTimer;

	private float wanderInterval;

	private float wanderTimer;

	private Vector3 deployPosition;

	public static Obj_SlimeBomb Create(Vector3 position, Quaternion rotation, Transform parent = null)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	public void Deploy(int damage, ABaseTower fromTower, Vector3 targetPosition)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_JumpToExplode_003Ed__20))]
	private IEnumerator CR_JumpToExplode(Vector3 targetPosition, float jumpHeight, float duration)
	{
		return null;
	}

	public void SelfDestroy()
	{
	}
}
