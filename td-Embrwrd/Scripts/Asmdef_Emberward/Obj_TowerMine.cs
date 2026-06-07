using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_TowerMine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_DelayedDestroy_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TowerMine _003C_003E4__this;

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
		public _003CCR_DelayedDestroy_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CCR_DelayedExplode_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TowerMine _003C_003E4__this;

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
		public _003CCR_DelayedExplode_003Ed__25(int _003C_003E1__state)
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
	private float detectRange;

	[SerializeField]
	private GameObject node_Model;

	[SerializeField]
	private Renderer renderer_Mine;

	[SerializeField]
	private ParticleSystem particle_Explosion_Arcane;

	[SerializeField]
	private ParticleSystem particle_Explosion_Ice;

	[SerializeField]
	private Material mat_Normal_Arcane;

	[SerializeField]
	private Material mat_Normal_Ice;

	[SerializeField]
	private Material mat_PrepareForExplosion;

	private int damage;

	private float critChance;

	private bool isDeployed;

	private ABaseTower fromTower;

	private eDamageType damageType;

	private Action<Obj_TowerMine> OnMineRemoved;

	private Material originalMaterial;

	[SerializeField]
	private ABaseTower.eUpgradeType upgradeType;

	private Action<AMonsterBase, int, int> BulletHitCallback;

	private float detectInterval;

	private float detectTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	public void Setup(int damage, float critChance, Vector3 startPos, Vector3 targetPos, ABaseTower fromTower, Action<Obj_TowerMine> OnMineRemoved)
	{
	}

	public void RegisterHitCallback(Action<AMonsterBase, int, int> OnHitCallback)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedExplode_003Ed__25))]
	private IEnumerator CR_DelayedExplode()
	{
		return null;
	}

	public void OverrideUpgradeType(ABaseTower.eUpgradeType upgradeType)
	{
	}

	public void OverrideDamageType(eDamageType damageType)
	{
	}

	private void Explode(bool forceExplode = false)
	{
	}

	public void ForceExplode()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedDestroy_003Ed__30))]
	private IEnumerator CR_DelayedDestroy()
	{
		return null;
	}
}
