using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

public class Cannon_AOEAttack : ABaseCannon
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CShootProcAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public Cannon_AOEAttack _003C_003E4__this;

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
	private float attackDamageDelayTime;

	private void Start()
	{
	}

	private void Update()
	{
	}

	protected override void ShootProc()
	{
	}

	[AsyncStateMachine(typeof(_003CShootProcAsync_003Ed__4))]
	private UniTaskVoid ShootProcAsync()
	{
		return default(UniTaskVoid);
	}
}
