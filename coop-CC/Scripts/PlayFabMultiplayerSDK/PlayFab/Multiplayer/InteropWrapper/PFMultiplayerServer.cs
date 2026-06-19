using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMultiplayerServer
	{
		public unsafe static int PFMultiplayerCreateAndClaimServerLobby(PFMultiplayerHandle handle, PFEntityKey server, PFLobbyCreateConfiguration createConfiguration, object asyncIdentifier, out PFLobbyHandle lobby)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			PFLobby* interopHandle = null;
			void* asyncContext = intPtr.ToPointer();
			int num = Methods.PFMultiplayerCreateAndClaimServerLobby(handle.InteropHandle, server.ToPointer(disposableCollection), createConfiguration.ToPointer(disposableCollection), asyncContext, &interopHandle);
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			lobby = new PFLobbyHandle(interopHandle);
			return num;
		}

		public unsafe static int PFMultiplayerClaimServerLobby(PFMultiplayerHandle handle, PFEntityKey server, string lobbyId, object asyncIdentifier, out PFLobbyHandle lobby)
		{
			lobby = null;
			if (lobbyId == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(lobbyId, disposableCollection);
			PFLobby* interopHandle = null;
			void* asyncContext = intPtr.ToPointer();
			int num = Methods.PFMultiplayerClaimServerLobby(handle.InteropHandle, server.ToPointer(disposableCollection), uTF8StringPtr.Pointer, asyncContext, &interopHandle);
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			lobby = new PFLobbyHandle(interopHandle);
			return num;
		}

		public unsafe static int PFMultiplayerJoinLobbyAsServer(PFMultiplayerHandle handle, PFEntityKey server, string connectionString, PFLobbyServerJoinConfiguration configuration, object asyncIdentifier, out PFLobbyHandle lobby)
		{
			lobby = null;
			if (connectionString == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(connectionString, disposableCollection);
			PFLobby* interopHandle = null;
			void* asyncContext = intPtr.ToPointer();
			int num = Methods.PFMultiplayerJoinLobbyAsServer(handle.InteropHandle, server.ToPointer(disposableCollection), uTF8StringPtr.Pointer, configuration.ToPointer(disposableCollection), asyncContext, &interopHandle);
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			lobby = new PFLobbyHandle(interopHandle);
			return num;
		}

		public unsafe static int PFLobbyServerPostUpdate(PFLobbyHandle lobby, PFLobbyDataUpdate lobbyUpdate, object asyncIdentifier)
		{
			if (lobby == null)
			{
				return -2147024809;
			}
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			PlayFab.Multiplayer.Interop.PFLobbyDataUpdate* lobbyUpdate2 = null;
			if (lobbyUpdate != null)
			{
				lobbyUpdate2 = lobbyUpdate.ToPointer(disposableCollection);
			}
			int num = Methods.PFLobbyServerPostUpdate(lobby.InteropHandle, lobbyUpdate2, intPtr.ToPointer());
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			return num;
		}

		public unsafe static int PFLobbyServerPostUpdateAsServer(PFLobbyHandle lobby, PFLobbyServerDataUpdate serverUpdate, object asyncIdentifier)
		{
			if (lobby == null)
			{
				return -2147024809;
			}
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			PlayFab.Multiplayer.Interop.PFLobbyServerDataUpdate* serverUpdate2 = null;
			if (serverUpdate != null)
			{
				serverUpdate2 = serverUpdate.ToPointer(disposableCollection);
			}
			int num = Methods.PFLobbyServerPostUpdateAsServer(lobby.InteropHandle, serverUpdate2, intPtr.ToPointer());
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			return num;
		}

		public unsafe static int PFLobbyServerLeaveAsServer(PFLobbyHandle lobby, object asyncIdentifier)
		{
			if (lobby == null)
			{
				return -2147024809;
			}
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			using (new DisposableCollection())
			{
				int num = Methods.PFLobbyServerLeaveAsServer(lobby.InteropHandle, intPtr.ToPointer());
				if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
				return num;
			}
		}

		public unsafe static int PFLobbyServerDeleteLobby(PFLobbyHandle lobby, object asyncIdentifier)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			using (new DisposableCollection())
			{
				int num = Methods.PFLobbyServerDeleteLobby(lobby.InteropHandle, intPtr.ToPointer());
				if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
				return num;
			}
		}

		public unsafe static int PFMultiplayerCreateServerBackfillTicket(PFMultiplayerHandle multiplayer, PFEntityKey server, PFMatchmakingServerBackfillTicketConfiguration configuration, object asyncIdentifier, out PFMatchmakingTicketHandle handle)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			PFMatchmakingTicket* interopHandle = default(PFMatchmakingTicket*);
			int error = Methods.PFMultiplayerCreateServerBackfillTicket(multiplayer.InteropHandle, server.ToPointer(disposableCollection), configuration.ToPointer(disposableCollection), intPtr.ToPointer(), &interopHandle);
			if (LobbyError.FAILED(error) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			return PFMatchmakingTicketHandle.WrapAndReturnError(error, interopHandle, out handle);
		}
	}
}
