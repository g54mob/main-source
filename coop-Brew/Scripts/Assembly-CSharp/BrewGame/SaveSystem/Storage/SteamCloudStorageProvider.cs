using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrewGame.SaveSystem.Core;

namespace BrewGame.SaveSystem.Storage
{
	public class SteamCloudStorageProvider : ISaveStorageProvider
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass10_0
		{
			public string filename;

			public byte[] data;

			internal bool _003CSaveAsync_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public string filename;

			internal byte[] _003CLoadAsync_003Eb__0()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass12_0
		{
			public string filename;

			internal bool _003CDeleteAsync_003Eb__0()
			{
				return false;
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CDeleteAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SteamCloudStorageProvider _003C_003E4__this;

			public int slotIndex;

			public string profileId;

			private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

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
		private struct _003CGetAllSlotsMetadataAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata[]> _003C_003Et__builder;

			public SteamCloudStorageProvider _003C_003E4__this;

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
		private struct _003CGetSlotMetadataAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata> _003C_003Et__builder;

			public SteamCloudStorageProvider _003C_003E4__this;

			public int slotIndex;

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
		private struct _003CLoadAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

			public SteamCloudStorageProvider _003C_003E4__this;

			public int slotIndex;

			public string profileId;

			private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

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
		private struct _003CSaveAsync_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public byte[] data;

			public SteamCloudStorageProvider _003C_003E4__this;

			public int slotIndex;

			public string profileId;

			private _003C_003Ec__DisplayClass10_0 _003C_003E8__1;

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

		private const string FILE_PREFIX = "brewgether_save_";

		private const string SAVE_EXTENSION = ".json";

		private const int SLOT_COUNT = 3;

		private static bool _showDebugLogs;

		public string ProviderName => null;

		public bool IsAvailable => false;

		private string GetCloudFilename(string profileId, int slotIndex)
		{
			return null;
		}

		private string SanitizeProfileId(string profileId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSaveAsync_003Ed__10))]
		public Task<bool> SaveAsync(string profileId, int slotIndex, byte[] data)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__11))]
		public Task<byte[]> LoadAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDeleteAsync_003Ed__12))]
		public Task<bool> DeleteAsync(string profileId, int slotIndex)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAllSlotsMetadataAsync_003Ed__13))]
		public Task<SaveSlotMetadata[]> GetAllSlotsMetadataAsync(string profileId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetSlotMetadataAsync_003Ed__14))]
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

		public (ulong, ulong) GetQuotaInfo()
		{
			return default((ulong, ulong));
		}

		public int GetFileCount()
		{
			return 0;
		}

		public static void SetDebugLogging(bool enabled)
		{
		}
	}
}
