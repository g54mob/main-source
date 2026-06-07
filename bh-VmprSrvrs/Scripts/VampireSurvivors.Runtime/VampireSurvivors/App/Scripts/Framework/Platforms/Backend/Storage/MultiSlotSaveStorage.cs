using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage
{
	public class MultiSlotSaveStorage : IMultiSlotSaveStorage
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetMergeConflictSlotData_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

			public MultiSlotSaveStorage _003C_003E4__this;

			private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

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
		private struct _003CGetSlotData_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

			public MultiSlotSaveStorage _003C_003E4__this;

			public int slot;

			private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

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
		private struct _003CTryGet_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

			public MultiSlotSaveStorage _003C_003E4__this;

			public PlayFabPlayerData.AllowedPlayerDataKeys key;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CTrySet_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public PlayerOptionsData value;

			public MultiSlotSaveStorage _003C_003E4__this;

			public PlayFabPlayerData.AllowedPlayerDataKeys key;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		private const string SAVE_SLOT_KEY_PREFIX = "SAVE_DATA_SLOT_";

		private ISaveDataCompressor compressor;

		private IPlayerDataStorage storage;

		private int maxSlots;

		public MultiSlotSaveStorage(IPlayerDataStorage storage, int maxSlots)
		{
		}

		public Task<bool> SetSlotData(int slot, PlayerOptionsData value)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetSlotData_003Ed__6))]
		public Task<PlayerOptionsData> GetSlotData(int slot)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetMergeConflictSlotData_003Ed__7))]
		public Task<PlayerOptionsData> GetMergeConflictSlotData()
		{
			return null;
		}

		private void AssertArgs(int slot)
		{
		}

		private PlayFabPlayerData.AllowedPlayerDataKeys GetKey(int slot)
		{
			return default(PlayFabPlayerData.AllowedPlayerDataKeys);
		}

		[AsyncStateMachine(typeof(_003CTryGet_003Ed__10))]
		private Task<PlayerOptionsData> TryGet(PlayFabPlayerData.AllowedPlayerDataKeys key)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTrySet_003Ed__11))]
		private Task<bool> TrySet(PlayFabPlayerData.AllowedPlayerDataKeys key, PlayerOptionsData value)
		{
			return null;
		}
	}
}
