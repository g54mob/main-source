using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

public class CityBlocks : HighlanderSingleton<CityBlocks>
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGenerateBlocks_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public CityBlocks _003C_003E4__this;

		private List<CityTile> _003CrandomList_003E5__2;

		private List<CityTile> _003CborderTiles_003E5__3;

		private string _003Cseed_003E5__4;

		private float _003CcityBlocksTotal_003E5__5;

		private float _003CcityBlocksProgress_003E5__6;

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

	public List<BlockController> blocksDirectory;

	[AsyncStateMachine(typeof(_003CGenerateBlocks_003Ed__2))]
	public UniTask GenerateBlocks()
	{
		return default(UniTask);
	}
}
