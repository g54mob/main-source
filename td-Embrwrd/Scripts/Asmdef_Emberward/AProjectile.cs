using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

[SelectionBase]
public abstract class AProjectile : MonoBehaviour
{
	public enum eState
	{
		NONE = 0,
		STARTED = 1,
		FINISHED = 2,
		DESTROYED = 3
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CDespawnAsync_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public bool doDeactiveModel;

		public AProjectile _003C_003E4__this;

		public bool doPlayExplosionParticle;

		private UniTask.Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	protected eState state;

	[SerializeField]
	protected GameObject node_Model;

	[SerializeField]
	protected ParticleSystem particle_Explosion;

	[SerializeField]
	protected float despawnDelay;

	protected Vector3 spawnPosition;

	private int shootIndex;

	private int bulletIndex;

	protected AMonsterBase targetMonster;

	protected Action<AMonsterBase, int, int> OnHitTargetCallback;

	protected GameObject spawnSource;

	protected ABaseTower fromTower;

	protected bool isFromPlayer;

	protected float baseCritChance;

	protected Vector3 lastMonsterHitPosition;

	public eState State => default(eState);

	public virtual void Spawn(AMonsterBase target, GameObject source = null)
	{
	}

	public void RegisterOnHitCallback(Action<AMonsterBase, int, int> onHitTargetCallback)
	{
	}

	public void SetBulletData(int shootIndex, int bulletIndex, ABaseTower fromTower, bool isFromPlayer = true)
	{
	}

	public void CopyBulletData(AProjectile bullet)
	{
	}

	public void OnHit(AMonsterBase monster)
	{
	}

	public virtual void OnHitProc(AMonsterBase monster)
	{
	}

	public virtual void Despawn(bool doDeactiveModel = true, bool doPlayExplosionParticle = true)
	{
	}

	[AsyncStateMachine(typeof(_003CDespawnAsync_003Ed__24))]
	private UniTaskVoid DespawnAsync(bool doDeactiveModel, bool doPlayExplosionParticle)
	{
		return default(UniTaskVoid);
	}

	protected abstract void SpawnProc();

	protected abstract void DespawnProc();

	protected abstract void DestroyProc();

	public bool IsState(eState targetState)
	{
		return false;
	}
}
