using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

public class CityDistricts : HighlanderSingleton<CityDistricts>
{
	public class DistrictPlacement
	{
		public float score;

		public List<CityTile> tiles;

		public List<CityTile> innerTiles;

		public List<CityTile> edgeTiles;
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGenerateDistricts_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public CityDistricts _003C_003E4__this;

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

	public GameObject districtPrefab;

	public List<DistrictController> districtDirectory;

	[AsyncStateMachine(typeof(_003CGenerateDistricts_003Ed__3))]
	public UniTask GenerateDistricts()
	{
		return default(UniTask);
	}
}
