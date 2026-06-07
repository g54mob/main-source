using System;
using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;

namespace Oculus.Platform
{
	public static class Rooms
	{
		public static Request<Room> UpdateDataStore(ulong roomID, Dictionary<string, string> data)
		{
			if (Core.IsInitialized())
			{
				CAPI.ovrKeyValuePair[] array = new CAPI.ovrKeyValuePair[data.Count];
				int num = 0;
				foreach (KeyValuePair<string, string> datum in data)
				{
					array[num++] = new CAPI.ovrKeyValuePair(datum.Key, datum.Value);
				}
				return new Request<Room>(CAPI.ovr_Room_UpdateDataStore(roomID, array));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		[Obsolete("Deprecated in favor of SetRoomInviteAcceptedNotificationCallback")]
		public static void SetRoomInviteNotificationCallback(Message<string>.Callback callback)
		{
			SetRoomInviteAcceptedNotificationCallback(callback);
		}

		public static Request<Room> CreateAndJoinPrivate(RoomJoinPolicy joinPolicy, uint maxUsers, bool subscribeToUpdates = false)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_CreateAndJoinPrivate(joinPolicy, maxUsers, subscribeToUpdates));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> CreateAndJoinPrivate2(RoomJoinPolicy joinPolicy, uint maxUsers, RoomOptions roomOptions)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_CreateAndJoinPrivate2(joinPolicy, maxUsers, (IntPtr)roomOptions));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> Get(ulong roomID)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_Get(roomID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> GetCurrent()
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_GetCurrent());
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> GetCurrentForUser(ulong userID)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_GetCurrentForUser(userID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<UserList> GetInvitableUsers()
		{
			if (Core.IsInitialized())
			{
				return new Request<UserList>(CAPI.ovr_Room_GetInvitableUsers());
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<UserList> GetInvitableUsers2(RoomOptions roomOptions = null)
		{
			if (Core.IsInitialized())
			{
				return new Request<UserList>(CAPI.ovr_Room_GetInvitableUsers2((IntPtr)roomOptions));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<RoomList> GetModeratedRooms()
		{
			if (Core.IsInitialized())
			{
				return new Request<RoomList>(CAPI.ovr_Room_GetModeratedRooms());
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> InviteUser(ulong roomID, string inviteToken)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_InviteUser(roomID, inviteToken));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> Join(ulong roomID, bool subscribeToUpdates = false)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_Join(roomID, subscribeToUpdates));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> Join2(ulong roomID, RoomOptions roomOptions)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_Join2(roomID, (IntPtr)roomOptions));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> KickUser(ulong roomID, ulong userID, int kickDurationSeconds)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_KickUser(roomID, userID, kickDurationSeconds));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request LaunchInvitableUserFlow(ulong roomID)
		{
			if (Core.IsInitialized())
			{
				return new Request(CAPI.ovr_Room_LaunchInvitableUserFlow(roomID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> Leave(ulong roomID)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_Leave(roomID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> SetDescription(ulong roomID, string description)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_SetDescription(roomID, description));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> UpdateMembershipLockStatus(ulong roomID, RoomMembershipLockStatus membershipLockStatus)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_UpdateMembershipLockStatus(roomID, membershipLockStatus));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request UpdateOwner(ulong roomID, ulong userID)
		{
			if (Core.IsInitialized())
			{
				return new Request(CAPI.ovr_Room_UpdateOwner(roomID, userID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Room> UpdatePrivateRoomJoinPolicy(ulong roomID, RoomJoinPolicy newJoinPolicy)
		{
			if (Core.IsInitialized())
			{
				return new Request<Room>(CAPI.ovr_Room_UpdatePrivateRoomJoinPolicy(roomID, newJoinPolicy));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static void SetRoomInviteAcceptedNotificationCallback(Message<string>.Callback callback)
		{
			Callback.SetNotificationCallback(Message.MessageType.Notification_Room_InviteAccepted, callback);
		}

		public static void SetRoomInviteReceivedNotificationCallback(Message<RoomInviteNotification>.Callback callback)
		{
			Callback.SetNotificationCallback(Message.MessageType.Notification_Room_InviteReceived, callback);
		}

		public static void SetUpdateNotificationCallback(Message<Room>.Callback callback)
		{
			Callback.SetNotificationCallback(Message.MessageType.Notification_Room_RoomUpdate, callback);
		}

		public static Request<RoomList> GetNextRoomListPage(RoomList list)
		{
			if (!list.HasNextPage)
			{
				Debug.LogWarning("Oculus.Platform.GetNextRoomListPage: List has no next page");
				return null;
			}
			if (Core.IsInitialized())
			{
				return new Request<RoomList>(CAPI.ovr_HTTP_GetWithMessageType(list.NextUrl, 1317239238));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}
	}
}
