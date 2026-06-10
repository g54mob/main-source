using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

public class CityBuildings : HighlanderSingleton<CityBuildings>
{
	public class PickBuilding
	{
		public BuildingPreset preset;

		public float rank;
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGenerateBuildings_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public CityBuildings _003C_003E4__this;

		private List<CityTile> _003Call_003E5__2;

		private int _003CloadBuildingsTotal_003E5__3;

		private int _003CloadBuildingsProgress_003E5__4;

		private int _003CloopFailSafe_003E5__5;

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

	public int loadChunk;

	private List<BuildingPreset> buildingPresets;

	public List<NewBuilding> buildingDirectory;

	public GameObject buildingPrefab;

	private List<PickBuilding> selectionList;

	[AsyncStateMachine(typeof(_003CGenerateBuildings_003Ed__6))]
	public UniTask GenerateBuildings()
	{
		return default(UniTask);
	}
}
