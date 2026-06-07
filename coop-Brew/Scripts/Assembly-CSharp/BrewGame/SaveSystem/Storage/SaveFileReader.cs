using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrewGame.SaveSystem.Core;

namespace BrewGame.SaveSystem.Storage
{
	public static class SaveFileReader
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CDeleteSlotAsync_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

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
		private struct _003CGetAllSlotsMetadataAsync_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata[]> _003C_003Et__builder;

			private string _003CprofileId_003E5__2;

			private TaskAwaiter<SaveSlotMetadata[]> _003C_003Eu__1;

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

		private static CompositeStorageProvider _storageProvider;

		private static LocalFileStorageProvider _localProvider;

		private static SteamCloudStorageProvider _steamProvider;

		private static CompositeStorageProvider StorageProvider => null;

		public static string GetCurrentProfileId()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAllSlotsMetadataAsync_003Ed__6))]
		public static Task<SaveSlotMetadata[]> GetAllSlotsMetadataAsync()
		{
			return null;
		}

		public static CloudSyncStatus GetCloudSyncStatus(string profileId, int slotIndex)
		{
			return default(CloudSyncStatus);
		}

		public static bool SlotExists(int slotIndex)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CDeleteSlotAsync_003Ed__9))]
		public static Task<bool> DeleteSlotAsync(int slotIndex)
		{
			return null;
		}

		public static bool IsSteamCloudAvailable()
		{
			return false;
		}
	}
}
