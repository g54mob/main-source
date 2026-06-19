using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMultiplayer
	{
		public const uint PFLobbyMaxMemberCountLowerLimit = 2u;

		public const uint PFLobbyMaxMemberCountUpperLimit = 128u;

		public const uint PFLobbyMaxSearchPropertyCount = 30u;

		public const uint PFLobbyMaxLobbyPropertyCount = 30u;

		public const uint PFLobbyMaxMemberPropertyCount = 30u;

		public const uint PFLobbyMaxServerPropertyCount = 30u;

		public const uint PFLobbyClientRequestedSearchResultCountUpperLimit = 50u;

		internal static ObjectPool ObjPool { get; set; }

		public unsafe static int PFLobbyGetLobbyId(PFLobbyHandle lobby, out string id)
		{
			id = null;
			if (lobby == null)
			{
				return -2147024809;
			}
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFLobbyGetLobbyId(lobby.InteropHandle, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				id = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetMaxMemberCount(PFLobbyHandle lobby, out uint maxMemberCount)
		{
			maxMemberCount = 0u;
			if (lobby == null)
			{
				return -2147024809;
			}
			uint num = 0u;
			int num2 = Methods.PFLobbyGetMaxMemberCount(lobby.InteropHandle, &num);
			if (LobbyError.SUCCEEDED(num2))
			{
				maxMemberCount = num;
			}
			return num2;
		}

		public unsafe static int PFLobbyGetOwner(PFLobbyHandle lobby, out PFEntityKey entityKey)
		{
			entityKey = null;
			if (lobby == null)
			{
				return -2147024809;
			}
			PlayFab.Multiplayer.Interop.PFEntityKey* ptr = null;
			int num = Methods.PFLobbyGetOwner(lobby.InteropHandle, &ptr);
			if (LobbyError.SUCCEEDED(num) && ptr != null)
			{
				entityKey = new PFEntityKey(ptr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetOwnerMigrationPolicy(PFLobbyHandle lobby, out PFLobbyOwnerMigrationPolicy ownerMigrationPolicy)
		{
			ownerMigrationPolicy = PFLobbyOwnerMigrationPolicy.Manual;
			if (lobby == null)
			{
				return -2147024809;
			}
			PlayFab.Multiplayer.Interop.PFLobbyOwnerMigrationPolicy pFLobbyOwnerMigrationPolicy = default(PlayFab.Multiplayer.Interop.PFLobbyOwnerMigrationPolicy);
			int result = Methods.PFLobbyGetOwnerMigrationPolicy(lobby.InteropHandle, &pFLobbyOwnerMigrationPolicy);
			ownerMigrationPolicy = (PFLobbyOwnerMigrationPolicy)pFLobbyOwnerMigrationPolicy;
			return result;
		}

		public unsafe static int PFLobbyGetAccessPolicy(PFLobbyHandle lobby, out PFLobbyAccessPolicy accessPolicy)
		{
			accessPolicy = PFLobbyAccessPolicy.Private;
			if (lobby == null)
			{
				return -2147024809;
			}
			PlayFab.Multiplayer.Interop.PFLobbyAccessPolicy pFLobbyAccessPolicy = default(PlayFab.Multiplayer.Interop.PFLobbyAccessPolicy);
			int result = Methods.PFLobbyGetAccessPolicy(lobby.InteropHandle, &pFLobbyAccessPolicy);
			accessPolicy = (PFLobbyAccessPolicy)pFLobbyAccessPolicy;
			return result;
		}

		public unsafe static int PFLobbyGetMembershipLock(PFLobbyHandle lobby, out PFLobbyMembershipLock lockState)
		{
			lockState = PFLobbyMembershipLock.Unlocked;
			if (lobby == null)
			{
				return -2147024809;
			}
			PlayFab.Multiplayer.Interop.PFLobbyMembershipLock pFLobbyMembershipLock = default(PlayFab.Multiplayer.Interop.PFLobbyMembershipLock);
			int num = Methods.PFLobbyGetMembershipLock(lobby.InteropHandle, &pFLobbyMembershipLock);
			if (LobbyError.SUCCEEDED(num))
			{
				lockState = (PFLobbyMembershipLock)pFLobbyMembershipLock;
			}
			return num;
		}

		public unsafe static int PFLobbyGetConnectionString(PFLobbyHandle lobby, out string connectionString)
		{
			connectionString = null;
			if (lobby == null)
			{
				return -2147024809;
			}
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFLobbyGetConnectionString(lobby.InteropHandle, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				connectionString = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetMembers(PFLobbyHandle lobby, out PFEntityKey[] users)
		{
			users = null;
			if (lobby == null)
			{
				return -2147024809;
			}
			uint num2 = default(uint);
			PlayFab.Multiplayer.Interop.PFEntityKey* ptr = default(PlayFab.Multiplayer.Interop.PFEntityKey*);
			int num = Methods.PFLobbyGetMembers(lobby.InteropHandle, &num2, &ptr);
			if (LobbyError.SUCCEEDED(num))
			{
				users = new PFEntityKey[num2];
				for (int i = 0; i < num2; i++)
				{
					users[i] = new PFEntityKey(ptr + i);
				}
			}
			return num;
		}

		public unsafe static int PFLobbyLeave(PFLobbyHandle lobby, PFEntityKey localUser, object asyncIdentifier)
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
			PlayFab.Multiplayer.Interop.PFEntityKey* localUser2 = ((localUser == null) ? null : localUser.ToPointer(disposableCollection));
			int num = Methods.PFLobbyLeave(lobby.InteropHandle, localUser2, intPtr.ToPointer());
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			return num;
		}

		public unsafe static int PFLobbyGetSearchPropertyKeys(PFLobbyHandle lobby, out string[] keys)
		{
			uint count = 0u;
			sbyte** rawPtr = default(sbyte**);
			int num = Methods.PFLobbyGetSearchPropertyKeys(lobby.InteropHandle, &count, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				keys = Converters.StringPtrToArray(rawPtr, count);
				return num;
			}
			keys = new string[0];
			return num;
		}

		public unsafe static int PFLobbyGetLobbyPropertyKeys(PFLobbyHandle lobby, out string[] keys)
		{
			uint count = 0u;
			sbyte** rawPtr = default(sbyte**);
			int num = Methods.PFLobbyGetLobbyPropertyKeys(lobby.InteropHandle, &count, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				keys = Converters.StringPtrToArray(rawPtr, count);
				return num;
			}
			keys = new string[0];
			return num;
		}

		public unsafe static int PFLobbyGetMemberPropertyKeys(PFLobbyHandle lobby, PFEntityKey member, out string[] keys)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			uint count = 0u;
			sbyte** rawPtr = default(sbyte**);
			int num = Methods.PFLobbyGetMemberPropertyKeys(lobby.InteropHandle, member.ToPointer(disposableCollection), &count, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				keys = Converters.StringPtrToArray(rawPtr, count);
			}
			else
			{
				keys = new string[0];
			}
			return num;
		}

		public unsafe static int PFLobbyGetSearchProperty(PFLobbyHandle lobby, string key, out string value)
		{
			value = null;
			if (lobby == null || key == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(key, disposableCollection);
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFLobbyGetSearchProperty(lobby.InteropHandle, uTF8StringPtr.Pointer, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				value = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetLobbyProperty(PFLobbyHandle lobby, string key, out string value)
		{
			value = null;
			if (lobby == null || key == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(key, disposableCollection);
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFLobbyGetLobbyProperty(lobby.InteropHandle, uTF8StringPtr.Pointer, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				value = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetMemberProperty(PFLobbyHandle lobby, PFEntityKey member, string key, out string value)
		{
			value = null;
			if (lobby == null || key == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(key, disposableCollection);
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFLobbyGetMemberProperty(lobby.InteropHandle, member.ToPointer(disposableCollection), uTF8StringPtr.Pointer, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				value = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetMemberConnectionStatus(PFLobbyHandle lobby, PFEntityKey member, out PFLobbyMemberConnectionStatus memberConnectionStatus)
		{
			memberConnectionStatus = PFLobbyMemberConnectionStatus.NotConnected;
			if (lobby == null || member == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			PlayFab.Multiplayer.Interop.PFLobbyMemberConnectionStatus pFLobbyMemberConnectionStatus = default(PlayFab.Multiplayer.Interop.PFLobbyMemberConnectionStatus);
			int result = Methods.PFLobbyGetMemberConnectionStatus(lobby.InteropHandle, member.ToPointer(disposableCollection), &pFLobbyMemberConnectionStatus);
			memberConnectionStatus = (PFLobbyMemberConnectionStatus)pFLobbyMemberConnectionStatus;
			return result;
		}

		public unsafe static int PFLobbyGetServer(PFLobbyHandle lobby, out PFEntityKey server)
		{
			server = null;
			if (lobby == null)
			{
				return -2147024809;
			}
			PlayFab.Multiplayer.Interop.PFEntityKey* ptr = null;
			int num = Methods.PFLobbyGetServer(lobby.InteropHandle, &ptr);
			if (LobbyError.SUCCEEDED(num) && ptr != null)
			{
				server = new PFEntityKey(ptr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetServerPropertyKeys(PFLobbyHandle lobby, out string[] keys)
		{
			using (new DisposableCollection())
			{
				uint count = 0u;
				sbyte** rawPtr = default(sbyte**);
				int num = Methods.PFLobbyGetServerPropertyKeys(lobby.InteropHandle, &count, &rawPtr);
				if (LobbyError.SUCCEEDED(num))
				{
					keys = Converters.StringPtrToArray(rawPtr, count);
				}
				else
				{
					keys = new string[0];
				}
				return num;
			}
		}

		public unsafe static int PFLobbyGetServerProperty(PFLobbyHandle lobby, string key, out string value)
		{
			value = null;
			if (lobby == null || key == null)
			{
				return -2147024809;
			}
			using DisposableCollection disposableCollection = new DisposableCollection();
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(key, disposableCollection);
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFLobbyGetServerProperty(lobby.InteropHandle, uTF8StringPtr.Pointer, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				value = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFLobbyGetServerConnectionStatus(PFLobbyHandle lobby, out PFLobbyServerConnectionStatus memberConnectionStatus)
		{
			memberConnectionStatus = PFLobbyServerConnectionStatus.NotConnected;
			if (lobby == null)
			{
				return -2147024809;
			}
			using (new DisposableCollection())
			{
				PlayFab.Multiplayer.Interop.PFLobbyServerConnectionStatus pFLobbyServerConnectionStatus = default(PlayFab.Multiplayer.Interop.PFLobbyServerConnectionStatus);
				int result = Methods.PFLobbyGetServerConnectionStatus(lobby.InteropHandle, &pFLobbyServerConnectionStatus);
				memberConnectionStatus = (PFLobbyServerConnectionStatus)pFLobbyServerConnectionStatus;
				return result;
			}
		}

		public unsafe static int PFLobbyPostUpdate(PFLobbyHandle lobby, PFEntityKey member, PFLobbyDataUpdate lobbyUpdate, PFLobbyMemberDataUpdate memberUpdate, object asyncIdentifier)
		{
			if (member == null || lobby == null)
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
			PlayFab.Multiplayer.Interop.PFLobbyMemberDataUpdate* memberUpdate2 = null;
			if (memberUpdate != null)
			{
				memberUpdate2 = memberUpdate.ToPointer(disposableCollection);
			}
			int num = Methods.PFLobbyPostUpdate(lobby.InteropHandle, member.ToPointer(disposableCollection), lobbyUpdate2, memberUpdate2, intPtr.ToPointer());
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			return num;
		}

		public unsafe static int PFLobbyGetCustomContext(PFLobbyHandle lobby, out object customContext)
		{
			if (lobby == null)
			{
				customContext = null;
				return -2147024809;
			}
			void* ptr = default(void*);
			int result = Methods.PFLobbyGetCustomContext(lobby.InteropHandle, &ptr);
			customContext = null;
			if (ptr != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(ptr));
				customContext = gCHandle.Target;
				gCHandle.Free();
			}
			return result;
		}

		public unsafe static int PFLobbySetCustomContext(PFLobbyHandle lobby, object customContext)
		{
			if (lobby == null)
			{
				return -2147024809;
			}
			void* ptr = default(void*);
			int num = Methods.PFLobbyGetCustomContext(lobby.InteropHandle, &ptr);
			if (LobbyError.SUCCEEDED(num))
			{
				IntPtr intPtr = IntPtr.Zero;
				if (customContext != null)
				{
					intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(customContext));
				}
				num = Methods.PFLobbySetCustomContext(lobby.InteropHandle, intPtr.ToPointer());
				if (LobbyError.SUCCEEDED(num))
				{
					if (ptr != null)
					{
						GCHandle.FromIntPtr((IntPtr)ptr).Free();
					}
				}
				else if (intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
			}
			return num;
		}

		public unsafe static int PFLobbySendInvite(PFLobbyHandle lobby, PFEntityKey sender, PFEntityKey invitee, object asyncContext)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncContext != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
			}
			return Methods.PFLobbySendInvite(lobby.InteropHandle, sender.ToPointer(disposableCollection), invitee.ToPointer(disposableCollection), intPtr.ToPointer());
		}

		public unsafe static string PFMultiplayerGetErrorMessage(int hresult)
		{
			sbyte* ptr = Methods.PFMultiplayerGetErrorMessage(hresult);
			if (ptr != null)
			{
				return Converters.PtrToStringUTF8((IntPtr)ptr);
			}
			return null;
		}

		public unsafe static int PFMultiplayerInitialize(string titleId, out PFMultiplayerHandle handle)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(titleId, disposableCollection);
			PlayFab.Multiplayer.Interop.PFMultiplayer* interopHandle = default(PlayFab.Multiplayer.Interop.PFMultiplayer*);
			int num = Methods.PFMultiplayerInitialize(uTF8StringPtr.Pointer, &interopHandle);
			if (num == -1994169343)
			{
				Methods.PFMultiplayerUninitialize(null);
				num = Methods.PFMultiplayerInitialize(uTF8StringPtr.Pointer, &interopHandle);
			}
			return PFMultiplayerHandle.WrapAndReturnError(num, interopHandle, out handle);
		}

		public unsafe static int PFMultiplayerUninitialize(PFMultiplayerHandle handle)
		{
			return Methods.PFMultiplayerUninitialize(handle.InteropHandle);
		}

		public static int PFMultiplayerSetThreadAffinityMask(PFMultiplayerThreadId threadId, ulong threadAffinityMask)
		{
			return Methods.PFMultiplayerSetThreadAffinityMask((PlayFab.Multiplayer.Interop.PFMultiplayerThreadId)threadId, threadAffinityMask);
		}

		public unsafe static int PFMultiplayerSetEntityToken(PFMultiplayerHandle handle, PFEntityKey localMember, string entityToken)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(entityToken, disposableCollection);
			return Methods.PFMultiplayerSetEntityToken(handle.InteropHandle, localMember.ToPointer(disposableCollection), uTF8StringPtr.Pointer);
		}

		static PFMultiplayer()
		{
			ObjPool = new ObjectPool();
			ObjPool.AddEntry<List<PFLobbyStateChange>>(4, new Type[0]);
			ObjPool.AddEntry<List<PFMatchmakingStateChange>>(4, new Type[0]);
		}

		public unsafe static int PFMultiplayerStartProcessingLobbyStateChanges(PFMultiplayerHandle handle, out LobbyStateChangeCollection collection)
		{
			uint num = 0u;
			collection.StateChanges = ObjPool.Retrieve<List<PFLobbyStateChange>>();
			PlayFab.Multiplayer.Interop.PFLobbyStateChange** ptr = null;
			int num2 = Methods.PFMultiplayerStartProcessingLobbyStateChanges(handle.InteropHandle, &num, &ptr);
			collection.RawStateChanges = ptr;
			collection.StateChangeCount = num;
			if (LobbyError.SUCCEEDED(num2) && num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					PFLobbyStateChange pFLobbyStateChange = PFLobbyStateChange.CreateFromPtr(ptr[i]);
					if (pFLobbyStateChange.GetType() != typeof(PFLobbyStateChange))
					{
						collection.StateChanges.Add(pFLobbyStateChange);
					}
				}
			}
			return num2;
		}

		public unsafe static int PFMultiplayerFinishProcessingLobbyStateChanges(PFMultiplayerHandle handle, LobbyStateChangeCollection collection)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			collection.StateChanges.Clear();
			ObjPool.Return(collection.StateChanges);
			return Methods.PFMultiplayerFinishProcessingLobbyStateChanges(handle.InteropHandle, collection.StateChangeCount, collection.RawStateChanges);
		}

		public unsafe static int PFMultiplayerCreateAndJoinLobby(PFMultiplayerHandle handle, PFEntityKey creator, PFLobbyCreateConfiguration createConfiguration, PFLobbyJoinConfiguration joinConfiguration, object asyncIdentifier, out PFLobbyHandle lobby)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			PFLobby* interopHandle = null;
			void* asyncContext = intPtr.ToPointer();
			int num = Methods.PFMultiplayerCreateAndJoinLobby(handle.InteropHandle, creator.ToPointer(disposableCollection), createConfiguration.ToPointer(disposableCollection), joinConfiguration.ToPointer(disposableCollection), asyncContext, &interopHandle);
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			lobby = new PFLobbyHandle(interopHandle);
			return num;
		}

		public unsafe static int PFLobbyForceRemoveMember(PFLobbyHandle lobby, PFEntityKey targetMember, bool preventRejoin, object asyncContext)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncContext != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
			}
			return Methods.PFLobbyForceRemoveMember(lobby.InteropHandle, targetMember.ToPointer(disposableCollection), (byte)(preventRejoin ? 1u : 0u), intPtr.ToPointer());
		}

		public unsafe static int PFLobbyAddMember(PFLobbyHandle lobby, PFEntityKey localUser, IDictionary<string, string> memberProperties, object asyncContext)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncContext != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
			}
			uint memberPropertyCount = Convert.ToUInt32(memberProperties.Count);
			SizeT count;
			sbyte** memberPropertyKeys = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(memberProperties.Keys.ToArray(), disposableCollection, out count);
			sbyte** memberPropertyValues = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(memberProperties.Values.ToArray(), disposableCollection, out count);
			return Methods.PFLobbyAddMember(lobby.InteropHandle, localUser.ToPointer(disposableCollection), memberPropertyCount, memberPropertyKeys, memberPropertyValues, intPtr.ToPointer());
		}

		public unsafe static int PFMultiplayerJoinLobby(PFMultiplayerHandle handle, PFEntityKey newMember, string connectionString, PFLobbyJoinConfiguration configuration, object asyncContext, out PFLobbyHandle lobby)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncContext != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
			}
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(connectionString, disposableCollection);
			PFLobby* interopHandle = null;
			int num = Methods.PFMultiplayerJoinLobby(handle.InteropHandle, newMember.ToPointer(disposableCollection), uTF8StringPtr.Pointer, configuration.ToPointer(disposableCollection), intPtr.ToPointer(), &interopHandle);
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			lobby = new PFLobbyHandle(interopHandle);
			return num;
		}

		public unsafe static int PFMultiplayerJoinArrangedLobby(PFMultiplayerHandle handle, PFEntityKey newMember, string arrangementString, PFLobbyArrangedJoinConfiguration configuration, object asyncContext, out PFLobbyHandle lobby)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncContext != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
			}
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(arrangementString, disposableCollection);
			PFLobby* interopHandle = null;
			int num = Methods.PFMultiplayerJoinArrangedLobby(handle.InteropHandle, newMember.ToPointer(disposableCollection), uTF8StringPtr.Pointer, configuration.ToPointer(disposableCollection), intPtr.ToPointer(), &interopHandle);
			if (LobbyError.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			lobby = new PFLobbyHandle(interopHandle);
			return num;
		}

		public unsafe static int PFMultiplayerFindLobbies(PFMultiplayerHandle handle, PFEntityKey searchingEntity, PFLobbySearchConfiguration searchConfiguration, object asyncContext)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr intPtr = IntPtr.Zero;
			if (asyncContext != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncContext));
			}
			return Methods.PFMultiplayerFindLobbies(handle.InteropHandle, searchingEntity.ToPointer(disposableCollection), searchConfiguration.ToPointer(disposableCollection), intPtr.ToPointer());
		}

		public unsafe static int PFMultiplayerStartListeningForLobbyInvites(PFMultiplayerHandle handle, PFEntityKey listeningEntity)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			return Methods.PFMultiplayerStartListeningForLobbyInvites(handle.InteropHandle, listeningEntity.ToPointer(disposableCollection));
		}

		public unsafe static int PFMultiplayerStopListeningForLobbyInvites(PFMultiplayerHandle handle, PFEntityKey listeningEntity)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			return Methods.PFMultiplayerStopListeningForLobbyInvites(handle.InteropHandle, listeningEntity.ToPointer(disposableCollection));
		}

		public unsafe static int PFMultiplayerGetLobbyInviteListenerStatus(PFMultiplayerHandle handle, PFEntityKey listeningEntity, out PFLobbyInviteListenerStatus status)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			PlayFab.Multiplayer.Interop.PFLobbyInviteListenerStatus pFLobbyInviteListenerStatus = default(PlayFab.Multiplayer.Interop.PFLobbyInviteListenerStatus);
			int result = Methods.PFMultiplayerGetLobbyInviteListenerStatus(handle.InteropHandle, listeningEntity.ToPointer(disposableCollection), &pFLobbyInviteListenerStatus);
			status = (PFLobbyInviteListenerStatus)pFLobbyInviteListenerStatus;
			return result;
		}

		public unsafe static int PFMultiplayerCreateMatchmakingTicket(PFMultiplayerHandle multiplayer, PFEntityKey[] localUsers, string[] localUserAttributes, PFMatchmakingTicketConfiguration configuration, object asyncIdentifier, out PFMatchmakingTicketHandle handle)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			sbyte*[] array = Converters.StringArrayToPtr(localUserAttributes, disposableCollection);
			PlayFab.Multiplayer.Interop.PFEntityKey[] array2 = new PlayFab.Multiplayer.Interop.PFEntityKey[localUsers.Length];
			for (int i = 0; i < localUsers.Length; i++)
			{
				UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(localUsers[i].Id, disposableCollection);
				UTF8StringPtr uTF8StringPtr2 = new UTF8StringPtr(localUsers[i].Type, disposableCollection);
				array2[i].id = uTF8StringPtr.Pointer;
				array2[i].type = uTF8StringPtr2.Pointer;
			}
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			fixed (PlayFab.Multiplayer.Interop.PFEntityKey* localUsers2 = &array2[0])
			{
				fixed (sbyte** localUserAttributes2 = &array[0])
				{
					PFMatchmakingTicket* interopHandle = default(PFMatchmakingTicket*);
					int error = Methods.PFMultiplayerCreateMatchmakingTicket(multiplayer.InteropHandle, (uint)localUsers.Length, localUsers2, localUserAttributes2, configuration.ToPointer(disposableCollection), intPtr.ToPointer(), &interopHandle);
					if (LobbyError.FAILED(error) && intPtr != IntPtr.Zero)
					{
						GCHandle.FromIntPtr(intPtr).Free();
					}
					return PFMatchmakingTicketHandle.WrapAndReturnError(error, interopHandle, out handle);
				}
			}
		}

		public unsafe static int PFMultiplayerJoinMatchmakingTicketFromId(PFMultiplayerHandle multiplayer, PFEntityKey[] localUsers, string[] localUserAttributes, string ticketId, string queueName, object asyncIdentifier, out PFMatchmakingTicketHandle handle)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			sbyte*[] array = Converters.StringArrayToPtr(localUserAttributes, disposableCollection);
			PlayFab.Multiplayer.Interop.PFEntityKey[] array2 = new PlayFab.Multiplayer.Interop.PFEntityKey[localUsers.Length];
			for (int i = 0; i < localUsers.Length; i++)
			{
				UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(localUsers[i].Id, disposableCollection);
				UTF8StringPtr uTF8StringPtr2 = new UTF8StringPtr(localUsers[i].Type, disposableCollection);
				array2[i].id = uTF8StringPtr.Pointer;
				array2[i].type = uTF8StringPtr2.Pointer;
			}
			IntPtr intPtr = IntPtr.Zero;
			if (asyncIdentifier != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(asyncIdentifier));
			}
			fixed (PlayFab.Multiplayer.Interop.PFEntityKey* localUsers2 = &array2[0])
			{
				fixed (sbyte** localUserAttributes2 = &array[0])
				{
					UTF8StringPtr uTF8StringPtr3 = new UTF8StringPtr(ticketId, disposableCollection);
					UTF8StringPtr uTF8StringPtr4 = new UTF8StringPtr(queueName, disposableCollection);
					PFMatchmakingTicket* interopHandle = default(PFMatchmakingTicket*);
					int error = Methods.PFMultiplayerJoinMatchmakingTicketFromId(multiplayer.InteropHandle, (uint)localUsers.Length, localUsers2, localUserAttributes2, uTF8StringPtr3.Pointer, uTF8StringPtr4.Pointer, intPtr.ToPointer(), &interopHandle);
					if (LobbyError.FAILED(error) && intPtr != IntPtr.Zero)
					{
						GCHandle.FromIntPtr(intPtr).Free();
					}
					return PFMatchmakingTicketHandle.WrapAndReturnError(error, interopHandle, out handle);
				}
			}
		}

		public unsafe static int PFMultiplayerDestroyMatchmakingTicket(PFMultiplayerHandle multiplayer, PFMatchmakingTicketHandle matchTicketHandle)
		{
			return Methods.PFMultiplayerDestroyMatchmakingTicket(multiplayer.InteropHandle, matchTicketHandle.InteropHandle);
		}

		public unsafe static int PFMatchmakingTicketGetStatus(PFMatchmakingTicketHandle matchTicketHandle, out PFMatchmakingTicketStatus status)
		{
			status = PFMatchmakingTicketStatus.Failed;
			PlayFab.Multiplayer.Interop.PFMatchmakingTicketStatus pFMatchmakingTicketStatus = default(PlayFab.Multiplayer.Interop.PFMatchmakingTicketStatus);
			int num = Methods.PFMatchmakingTicketGetStatus(matchTicketHandle.InteropHandle, &pFMatchmakingTicketStatus);
			if (LobbyError.SUCCEEDED(num))
			{
				status = (PFMatchmakingTicketStatus)pFMatchmakingTicketStatus;
			}
			return num;
		}

		public unsafe static int PFMatchmakingTicketCancel(PFMatchmakingTicketHandle matchTicketHandle)
		{
			return Methods.PFMatchmakingTicketCancel(matchTicketHandle.InteropHandle);
		}

		public unsafe static int PFMatchmakingTicketGetTicketId(PFMatchmakingTicketHandle matchTicketHandle, out string ticketId)
		{
			ticketId = null;
			sbyte* rawPtr = default(sbyte*);
			int num = Methods.PFMatchmakingTicketGetTicketId(matchTicketHandle.InteropHandle, &rawPtr);
			if (LobbyError.SUCCEEDED(num))
			{
				ticketId = Converters.PtrToStringUTF8(rawPtr);
			}
			return num;
		}

		public unsafe static int PFMatchmakingTicketGetMatch(PFMatchmakingTicketHandle matchTicketHandle, out PFMatchmakingMatchDetails matchDetails)
		{
			matchDetails = null;
			PlayFab.Multiplayer.Interop.PFMatchmakingMatchDetails* ptr = default(PlayFab.Multiplayer.Interop.PFMatchmakingMatchDetails*);
			int num = Methods.PFMatchmakingTicketGetMatch(matchTicketHandle.InteropHandle, &ptr);
			if (LobbyError.SUCCEEDED(num) && ptr != null)
			{
				matchDetails = new PFMatchmakingMatchDetails(ptr);
			}
			return num;
		}

		public unsafe static int PFMatchmakingTicketGetCustomContext(PFMatchmakingTicketHandle matchTicketHandle, out object customContext)
		{
			customContext = null;
			void* ptr = default(void*);
			int num = Methods.PFMatchmakingTicketGetCustomContext(matchTicketHandle.InteropHandle, &ptr);
			if (LobbyError.SUCCEEDED(num) && ptr != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(ptr));
				customContext = gCHandle.Target;
				gCHandle.Free();
			}
			return num;
		}

		public unsafe static int PFMatchmakingTicketSetCustomContext(PFMatchmakingTicketHandle matchTicketHandle, object customContext)
		{
			void* ptr = default(void*);
			int num = Methods.PFMatchmakingTicketGetCustomContext(matchTicketHandle.InteropHandle, &ptr);
			if (LobbyError.SUCCEEDED(num))
			{
				IntPtr intPtr = IntPtr.Zero;
				if (customContext != null)
				{
					intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(customContext));
				}
				num = Methods.PFMatchmakingTicketSetCustomContext(matchTicketHandle.InteropHandle, intPtr.ToPointer());
				if (LobbyError.SUCCEEDED(num))
				{
					if (ptr != null)
					{
						GCHandle.FromIntPtr((IntPtr)ptr).Free();
					}
				}
				else if (intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
			}
			return num;
		}

		public unsafe static int PFMultiplayerStartProcessingMatchmakingStateChanges(PFMultiplayerHandle handle, out MatchmakingStateChangeCollection collection)
		{
			uint num = 0u;
			collection.StateChanges = ObjPool.Retrieve<List<PFMatchmakingStateChange>>();
			PlayFab.Multiplayer.Interop.PFMatchmakingStateChange** ptr = null;
			ptr = null;
			num = 0u;
			int num2 = Methods.PFMultiplayerStartProcessingMatchmakingStateChanges(handle.InteropHandle, &num, &ptr);
			collection.RawStateChanges = ptr;
			collection.StateChangeCount = num;
			if (LobbyError.SUCCEEDED(num2) && num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					PFMatchmakingStateChange pFMatchmakingStateChange = PFMatchmakingStateChange.CreateFromPtr(ptr[i]);
					if (pFMatchmakingStateChange.GetType() != typeof(PFMatchmakingStateChange))
					{
						collection.StateChanges.Add(pFMatchmakingStateChange);
					}
				}
			}
			return num2;
		}

		public unsafe static int PFMultiplayerFinishProcessingMatchmakingStateChanges(PFMultiplayerHandle handle, MatchmakingStateChangeCollection collection)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			collection.StateChanges.Clear();
			ObjPool.Return(collection.StateChanges);
			return Methods.PFMultiplayerFinishProcessingMatchmakingStateChanges(handle.InteropHandle, collection.StateChangeCount, collection.RawStateChanges);
		}
	}
}
