using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

public class CityBoundaryAndTiles : HighlanderSingleton<CityBoundaryAndTiles>
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CSetupCityBoundary_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public CityBoundaryAndTiles _003C_003E4__this;

		private Cysharp.Threading.Tasks.YieldAwaitable.Awaiter _003C_003Eu__1;

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

	public float boundaryLeft;

	public float boundaryRight;

	public float boundaryUp;

	public float boundaryDown;

	public GameObject cityTilePrefab;

	public Dictionary<Vector2Int, CityTile> cityTiles;

	[AsyncStateMachine(typeof(_003CSetupCityBoundary_003Ed__6))]
	public UniTask SetupCityBoundary()
	{
		return default(UniTask);
	}
}
