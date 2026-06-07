using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Web : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Web _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__9(int _003C_003E1__state)
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

	private Vector3 headModelForward;

	[SerializeField]
	private List<Transform> list_WebNodes;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private float maxConnectDistance;

	[Header("放置時的煙霧特效")]
	[SerializeField]
	protected ParticleSystem particle_PlacementCloud;

	private int accumulatedDamage;

	private Vector3 lastHitPosition;

	protected override void OnEnableProc()
	{
	}

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__9))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	public override void TowerStunProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	private void LateUpdate()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	private void UpdateLinePosition(Vector3 targetTowerPosition)
	{
	}

	public List<Transform> GetWebNodes()
	{
		return null;
	}

	private void UpdateLineConnection(Tower_Web otherTower)
	{
	}

	public static List<Vector3> CreateSpline(Vector3 start, Vector3 end, int pointCount, Vector3 offset)
	{
		return null;
	}
}
