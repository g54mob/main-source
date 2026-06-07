using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrewGame.SaveSystem.Core;

namespace BrewGame.SaveSystem.Storage
{
	public class LocalFileStorageProvider : ISaveStorageProvider
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CDeleteAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int slotIndex;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CGetAllSlotsMetadataAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata[]> _003C_003Et__builder;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

			private SaveSlotMetadata[] _003Cslots_003E5__2;

			private int _003Ci_003E5__3;

			private SaveSlotMetadata[] _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private TaskAwaiter<SaveSlotMetadata> _003C_003Eu__1;

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
		private struct _003CGetSlotMetadataAsync_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata> _003C_003Et__builder;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

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
		private struct _003CLoadAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

			public int slotIndex;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

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
		private struct _003CRestoreFromBackupAsync_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int slotIndex;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CSaveAsync_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public byte[] data;

			public int slotIndex;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CTryLoadBackupAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

			public LocalFileStorageProvider _003C_003E4__this;

			public string profileId;

			public int slotIndex;

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

		private const string SAVES_FOLDER = "Saves";

		private const string SLOT_FILE_PREFIX = "slot_";

		private const string SAVE_EXTENSION = ".json";

		private const string BACKUP_EXTENSION = ".backup";

		private const string META_EXTENSION = "_meta.json";

		private const int SLOT_COUNT = 3;

		private static bool _showDebugLogs;

		public string ProviderName => null;

		public bool IsAvailable => false;

		private string GetSavesBasePath()
		{
			return null;
		}

		private string GetProfilePath(string profileId)
		{
			return null;
		}

		private string GetSlotPath(string profileId, int slotIndex)
		{
			return null;
		}

		private string GetBackupPath(string profileId, int slotIndex)
		{
			return null;
		}

		private string SanitizeProfileId(string profileId)
		{
			return null;
		}

		private void EnsureProfileDirectoryExists(string profileId)
		{
		}

		[AsyncStateMachine(typeof(_003CSaveAsync_003Ed__17))]
		public Task<bool> SaveAsync(string profileId, int slotIndex, byte[] data)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__18))]
		public Task<byte[]> LoadAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTryLoadBackupAsync_003Ed__19))]
		private Task<byte[]> TryLoadBackupAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDeleteAsync_003Ed__20))]
		public Task<bool> DeleteAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAllSlotsMetadataAsync_003Ed__21))]
		public Task<SaveSlotMetadata[]> GetAllSlotsMetadataAsync(string profileId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetSlotMetadataAsync_003Ed__22))]
		private Task<SaveSlotMetadata> GetSlotMetadataAsync(string profileId, int slotIndex)
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

		[AsyncStateMachine(typeof(_003CRestoreFromBackupAsync_003Ed__25))]
		public Task<bool> RestoreFromBackupAsync(string profileId, int slotIndex)
		{
			return null;
		}

		public bool BackupExists(string profileId, int slotIndex)
		{
			return false;
		}

		public string GetSavesPath()
		{
			return null;
		}

		public static void SetDebugLogging(bool enabled)
		{
		}
	}
}
