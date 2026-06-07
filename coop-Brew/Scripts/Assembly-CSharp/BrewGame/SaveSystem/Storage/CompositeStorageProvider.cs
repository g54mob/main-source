using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrewGame.SaveSystem.Core;

namespace BrewGame.SaveSystem.Storage
{
	public class CompositeStorageProvider : ISaveStorageProvider
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CDeleteAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			private bool _003ClocalSuccess_003E5__2;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CForceDownloadAllFromSteamAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			private int _003CdownloadedCount_003E5__2;

			private int _003Ci_003E5__3;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CForceSyncSlotAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CGetAllSlotsMetadataAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata[]> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			private SaveSlotMetadata[] _003ClocalSlots_003E5__2;

			private TaskAwaiter<SaveSlotMetadata[]> _003C_003Eu__1;

			private int _003Ci_003E5__3;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CLoadAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			private long _003ClocalTimestamp_003E5__2;

			private long _003CsteamTimestamp_003E5__3;

			private byte[] _003CsteamData_003E5__4;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CRestoreFromBackupAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CSaveAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			public byte[] data;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CSyncSteamToLocalAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			public byte[] data;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CSyncToSteamCloudAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CompositeStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			public byte[] data;

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

		private readonly LocalFileStorageProvider _localProvider;

		private readonly SteamCloudStorageProvider _steamProvider;

		private static bool _showDebugLogs;

		public string ProviderName => null;

		public bool IsAvailable => false;

		public bool IsSteamCloudAvailable => false;

		public CompositeStorageProvider()
		{
		}

		public CompositeStorageProvider(LocalFileStorageProvider localProvider, SteamCloudStorageProvider steamProvider)
		{
		}

		[AsyncStateMachine(typeof(_003CSaveAsync_003Ed__11))]
		public Task<bool> SaveAsync(string profileId, int slotIndex, byte[] data)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSyncToSteamCloudAsync_003Ed__12))]
		private Task SyncToSteamCloudAsync(string profileId, int slotIndex, byte[] data)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__13))]
		public Task<byte[]> LoadAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSyncSteamToLocalAsync_003Ed__14))]
		private Task SyncSteamToLocalAsync(string profileId, int slotIndex, byte[] data)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDeleteAsync_003Ed__15))]
		public Task<bool> DeleteAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAllSlotsMetadataAsync_003Ed__16))]
		public Task<SaveSlotMetadata[]> GetAllSlotsMetadataAsync(string profileId)
		{
			return null;
		}

		public bool SlotExists(string profileId, int slotIndex)
		{
			return false;
		}

		public long GetSlotTimestamp(string profileId, int slotIndex)
		{
			return 0L;
		}

		[AsyncStateMachine(typeof(_003CForceSyncSlotAsync_003Ed__19))]
		public Task<bool> ForceSyncSlotAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CForceDownloadAllFromSteamAsync_003Ed__20))]
		public Task<int> ForceDownloadAllFromSteamAsync(string profileId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRestoreFromBackupAsync_003Ed__21))]
		public Task<bool> RestoreFromBackupAsync(string profileId, int slotIndex)
		{
			return null;
		}

		public bool BackupExists(string profileId, int slotIndex)
		{
			return false;
		}

		public LocalFileStorageProvider GetLocalProvider()
		{
			return null;
		}

		public SteamCloudStorageProvider GetSteamProvider()
		{
			return null;
		}

		public static void SetDebugLogging(bool enabled)
		{
		}
	}
}
