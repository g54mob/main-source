using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[SelectionBase]
public abstract class ABaseCannon : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonDespawnProc_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonMoveProc_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonSpawnProc_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCannonUpgradeProc_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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
	[Header("設定資料")]
	protected CannonSettingData settingData;

	[SerializeField]
	protected Animator animator;

	[SerializeField]
	protected ParticleSystem particle_ShootEffect;

	[SerializeField]
	[Header("砲台的旋轉節點")]
	protected Transform node_CannonHeadModel;

	[SerializeField]
	[Header("發射點node")]
	protected Transform node_ShootPosition;

	protected ABasePanel connectedPanel;

	protected float shootTimer;

	protected AMonsterBase currentTarget;

	protected eTowerTargetPriority targetPriority;

	protected bool isInitialized;

	public Animator Animator => null;

	public Vector3 ShootWorldPosition => default(Vector3);

	public ABasePanel ConnectedPanel => null;

	public bool IsInitialized => false;

	protected void Awake()
	{
	}

	public void Spawn()
	{
	}

	public void SetPanel(ABasePanel panel)
	{
	}

	public void Despawn()
	{
	}

	public void Move()
	{
	}

	public void Shoot()
	{
	}

	public int GetCost(float multiplier = 1f)
	{
		return 0;
	}

	protected abstract void ShootProc();

	[AsyncStateMachine(typeof(_003CCannonSpawnProc_003Ed__26))]
	protected virtual void CannonSpawnProc()
	{
	}

	[AsyncStateMachine(typeof(_003CCannonUpgradeProc_003Ed__27))]
	protected virtual void CannonUpgradeProc()
	{
	}

	[AsyncStateMachine(typeof(_003CCannonMoveProc_003Ed__28))]
	protected virtual void CannonMoveProc()
	{
	}

	[AsyncStateMachine(typeof(_003CCannonDespawnProc_003Ed__29))]
	protected virtual void CannonDespawnProc()
	{
	}
}
