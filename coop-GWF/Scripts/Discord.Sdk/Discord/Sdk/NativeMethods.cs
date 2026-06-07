using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Discord.Sdk
{
	public static class NativeMethods
	{
		public unsafe delegate void Discord_FreeFn(void* ptr);

		internal class ManagedUserData
		{
			public Delegate managedCallback;

			public unsafe static void* Free;

			public ManagedUserData(Delegate managedCallback)
			{
				this.managedCallback = managedCallback;
			}

			unsafe static ManagedUserData()
			{
				Free = (void*)Marshal.GetFunctionPointerForDelegate<Discord_FreeFn>(UnmanagedFree);
			}

			[MonoPInvokeCallback(typeof(Discord_FreeFn))]
			public unsafe static void UnmanagedFree(void* userData)
			{
				GCHandle.FromIntPtr((IntPtr)userData).Free();
			}

			public unsafe static T DelegateFromPointer<T>(void* userData) where T : Delegate
			{
				return (T)((ManagedUserData)GCHandle.FromIntPtr((IntPtr)userData).Target).managedCallback;
			}

			public unsafe static void* CreateHandle(Delegate cb)
			{
				return GCHandle.ToIntPtr(GCHandle.Alloc(new ManagedUserData(cb))).ToPointer();
			}
		}

		public struct Discord_String
		{
			public unsafe byte* ptr;

			public UIntPtr size;
		}

		public struct Discord_ActivityButtonSpan
		{
			public unsafe ActivityButton* ptr;

			public UIntPtr size;
		}

		public struct Discord_UInt64Span
		{
			public unsafe ulong* ptr;

			public UIntPtr size;
		}

		public struct Discord_UserApplicationProfileHandleSpan
		{
			public unsafe UserApplicationProfileHandle* ptr;

			public UIntPtr size;
		}

		public struct Discord_LobbyMemberHandleSpan
		{
			public unsafe LobbyMemberHandle* ptr;

			public UIntPtr size;
		}

		public struct Discord_CallSpan
		{
			public unsafe Call* ptr;

			public UIntPtr size;
		}

		public struct Discord_AudioDeviceSpan
		{
			public unsafe AudioDevice* ptr;

			public UIntPtr size;
		}

		public struct Discord_MessageHandleSpan
		{
			public unsafe MessageHandle* ptr;

			public UIntPtr size;
		}

		public struct Discord_UserMessageSummarySpan
		{
			public unsafe UserMessageSummary* ptr;

			public UIntPtr size;
		}

		public struct Discord_GuildChannelSpan
		{
			public unsafe GuildChannel* ptr;

			public UIntPtr size;
		}

		public struct Discord_GuildMinimalSpan
		{
			public unsafe GuildMinimal* ptr;

			public UIntPtr size;
		}

		public struct Discord_RelationshipHandleSpan
		{
			public unsafe RelationshipHandle* ptr;

			public UIntPtr size;
		}

		public struct Discord_UserHandleSpan
		{
			public unsafe UserHandle* ptr;

			public UIntPtr size;
		}

		public struct Discord_Properties
		{
			public IntPtr size;

			public unsafe Discord_String* keys;

			public unsafe Discord_String* values;
		}

		public struct ActivityInvite
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_Init")]
			public unsafe static extern void Init(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_Drop")]
			public unsafe static extern void Drop(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_Clone")]
			public unsafe static extern void Clone(ActivityInvite* self, ActivityInvite* rhs);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SenderId")]
			public unsafe static extern ulong SenderId(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetSenderId")]
			public unsafe static extern void SetSenderId(ActivityInvite* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_ChannelId")]
			public unsafe static extern ulong ChannelId(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetChannelId")]
			public unsafe static extern void SetChannelId(ActivityInvite* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_MessageId")]
			public unsafe static extern ulong MessageId(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetMessageId")]
			public unsafe static extern void SetMessageId(ActivityInvite* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_Type")]
			public unsafe static extern ActivityActionTypes Type(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetType")]
			public unsafe static extern void SetType(ActivityInvite* self, ActivityActionTypes value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_ApplicationId")]
			public unsafe static extern ulong ApplicationId(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetApplicationId")]
			public unsafe static extern void SetApplicationId(ActivityInvite* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_ParentApplicationId")]
			public unsafe static extern ulong ParentApplicationId(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetParentApplicationId")]
			public unsafe static extern void SetParentApplicationId(ActivityInvite* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_PartyId")]
			public unsafe static extern void PartyId(ActivityInvite* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetPartyId")]
			public unsafe static extern void SetPartyId(ActivityInvite* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SessionId")]
			public unsafe static extern void SessionId(ActivityInvite* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetSessionId")]
			public unsafe static extern void SetSessionId(ActivityInvite* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_IsValid")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsValid(ActivityInvite* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityInvite_SetIsValid")]
			public unsafe static extern void SetIsValid(ActivityInvite* self, bool value);
		}

		public struct ActivityAssets
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_Init")]
			public unsafe static extern void Init(ActivityAssets* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_Drop")]
			public unsafe static extern void Drop(ActivityAssets* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_Clone")]
			public unsafe static extern void Clone(ActivityAssets* self, ActivityAssets* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_LargeImage")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool LargeImage(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetLargeImage")]
			public unsafe static extern void SetLargeImage(ActivityAssets* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_LargeText")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool LargeText(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetLargeText")]
			public unsafe static extern void SetLargeText(ActivityAssets* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_LargeUrl")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool LargeUrl(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetLargeUrl")]
			public unsafe static extern void SetLargeUrl(ActivityAssets* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SmallImage")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SmallImage(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetSmallImage")]
			public unsafe static extern void SetSmallImage(ActivityAssets* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SmallText")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SmallText(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetSmallText")]
			public unsafe static extern void SetSmallText(ActivityAssets* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SmallUrl")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SmallUrl(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetSmallUrl")]
			public unsafe static extern void SetSmallUrl(ActivityAssets* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_InviteCoverImage")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool InviteCoverImage(ActivityAssets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityAssets_SetInviteCoverImage")]
			public unsafe static extern void SetInviteCoverImage(ActivityAssets* self, Discord_String* value);
		}

		public struct ActivityTimestamps
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_Init")]
			public unsafe static extern void Init(ActivityTimestamps* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_Drop")]
			public unsafe static extern void Drop(ActivityTimestamps* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_Clone")]
			public unsafe static extern void Clone(ActivityTimestamps* self, ActivityTimestamps* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_Start")]
			public unsafe static extern ulong Start(ActivityTimestamps* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_SetStart")]
			public unsafe static extern void SetStart(ActivityTimestamps* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_End")]
			public unsafe static extern ulong End(ActivityTimestamps* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityTimestamps_SetEnd")]
			public unsafe static extern void SetEnd(ActivityTimestamps* self, ulong value);
		}

		public struct ActivityParty
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_Init")]
			public unsafe static extern void Init(ActivityParty* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_Drop")]
			public unsafe static extern void Drop(ActivityParty* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_Clone")]
			public unsafe static extern void Clone(ActivityParty* self, ActivityParty* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_Id")]
			public unsafe static extern void Id(ActivityParty* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_SetId")]
			public unsafe static extern void SetId(ActivityParty* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_CurrentSize")]
			public unsafe static extern int CurrentSize(ActivityParty* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_SetCurrentSize")]
			public unsafe static extern void SetCurrentSize(ActivityParty* self, int value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_MaxSize")]
			public unsafe static extern int MaxSize(ActivityParty* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_SetMaxSize")]
			public unsafe static extern void SetMaxSize(ActivityParty* self, int value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_Privacy")]
			public unsafe static extern ActivityPartyPrivacy Privacy(ActivityParty* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityParty_SetPrivacy")]
			public unsafe static extern void SetPrivacy(ActivityParty* self, ActivityPartyPrivacy value);
		}

		public struct ActivitySecrets
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivitySecrets_Init")]
			public unsafe static extern void Init(ActivitySecrets* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivitySecrets_Drop")]
			public unsafe static extern void Drop(ActivitySecrets* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivitySecrets_Clone")]
			public unsafe static extern void Clone(ActivitySecrets* self, ActivitySecrets* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivitySecrets_Join")]
			public unsafe static extern void Join(ActivitySecrets* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivitySecrets_SetJoin")]
			public unsafe static extern void SetJoin(ActivitySecrets* self, Discord_String value);
		}

		public struct ActivityButton
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_Init")]
			public unsafe static extern void Init(ActivityButton* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_Drop")]
			public unsafe static extern void Drop(ActivityButton* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_Clone")]
			public unsafe static extern void Clone(ActivityButton* self, ActivityButton* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_Label")]
			public unsafe static extern void Label(ActivityButton* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_SetLabel")]
			public unsafe static extern void SetLabel(ActivityButton* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_Url")]
			public unsafe static extern void Url(ActivityButton* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ActivityButton_SetUrl")]
			public unsafe static extern void SetUrl(ActivityButton* self, Discord_String value);
		}

		public struct Activity
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Init")]
			public unsafe static extern void Init(Activity* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Drop")]
			public unsafe static extern void Drop(Activity* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Clone")]
			public unsafe static extern void Clone(Activity* self, Activity* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_AddButton")]
			public unsafe static extern void AddButton(Activity* self, ActivityButton* button);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Equals")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Equals(Activity* self, Activity* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_GetButtons")]
			public unsafe static extern void GetButtons(Activity* self, Discord_ActivityButtonSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Name")]
			public unsafe static extern void Name(Activity* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetName")]
			public unsafe static extern void SetName(Activity* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Type")]
			public unsafe static extern ActivityTypes Type(Activity* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetType")]
			public unsafe static extern void SetType(Activity* self, ActivityTypes value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_StatusDisplayType")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool StatusDisplayType(Activity* self, StatusDisplayTypes* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetStatusDisplayType")]
			public unsafe static extern void SetStatusDisplayType(Activity* self, StatusDisplayTypes* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_State")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool State(Activity* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetState")]
			public unsafe static extern void SetState(Activity* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_StateUrl")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool StateUrl(Activity* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetStateUrl")]
			public unsafe static extern void SetStateUrl(Activity* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Details")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Details(Activity* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetDetails")]
			public unsafe static extern void SetDetails(Activity* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_DetailsUrl")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool DetailsUrl(Activity* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetDetailsUrl")]
			public unsafe static extern void SetDetailsUrl(Activity* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_ApplicationId")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ApplicationId(Activity* self, ulong* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetApplicationId")]
			public unsafe static extern void SetApplicationId(Activity* self, ulong* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_ParentApplicationId")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ParentApplicationId(Activity* self, ulong* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetParentApplicationId")]
			public unsafe static extern void SetParentApplicationId(Activity* self, ulong* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Assets")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Assets(Activity* self, ActivityAssets* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetAssets")]
			public unsafe static extern void SetAssets(Activity* self, ActivityAssets* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Timestamps")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Timestamps(Activity* self, ActivityTimestamps* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetTimestamps")]
			public unsafe static extern void SetTimestamps(Activity* self, ActivityTimestamps* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Party")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Party(Activity* self, ActivityParty* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetParty")]
			public unsafe static extern void SetParty(Activity* self, ActivityParty* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_Secrets")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Secrets(Activity* self, ActivitySecrets* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetSecrets")]
			public unsafe static extern void SetSecrets(Activity* self, ActivitySecrets* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SupportedPlatforms")]
			public unsafe static extern ActivityGamePlatforms SupportedPlatforms(Activity* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Activity_SetSupportedPlatforms")]
			public unsafe static extern void SetSupportedPlatforms(Activity* self, ActivityGamePlatforms value);
		}

		public struct ClientResult
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Drop")]
			public unsafe static extern void Drop(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Clone")]
			public unsafe static extern void Clone(ClientResult* self, ClientResult* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_ToString")]
			public unsafe static extern void ToString(ClientResult* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Type")]
			public unsafe static extern ErrorType Type(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetType")]
			public unsafe static extern void SetType(ClientResult* self, ErrorType value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Error")]
			public unsafe static extern void Error(ClientResult* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetError")]
			public unsafe static extern void SetError(ClientResult* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_ErrorCode")]
			public unsafe static extern int ErrorCode(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetErrorCode")]
			public unsafe static extern void SetErrorCode(ClientResult* self, int value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Status")]
			public unsafe static extern HttpStatusCode Status(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetStatus")]
			public unsafe static extern void SetStatus(ClientResult* self, HttpStatusCode value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_ResponseBody")]
			public unsafe static extern void ResponseBody(ClientResult* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetResponseBody")]
			public unsafe static extern void SetResponseBody(ClientResult* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Successful")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Successful(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetSuccessful")]
			public unsafe static extern void SetSuccessful(ClientResult* self, bool value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_Retryable")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Retryable(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetRetryable")]
			public unsafe static extern void SetRetryable(ClientResult* self, bool value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_RetryAfter")]
			public unsafe static extern float RetryAfter(ClientResult* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientResult_SetRetryAfter")]
			public unsafe static extern void SetRetryAfter(ClientResult* self, float value);
		}

		public struct AuthorizationCodeChallenge
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_Init")]
			public unsafe static extern void Init(AuthorizationCodeChallenge* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_Drop")]
			public unsafe static extern void Drop(AuthorizationCodeChallenge* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_Clone")]
			public unsafe static extern void Clone(AuthorizationCodeChallenge* self, AuthorizationCodeChallenge* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_Method")]
			public unsafe static extern AuthenticationCodeChallengeMethod Method(AuthorizationCodeChallenge* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_SetMethod")]
			public unsafe static extern void SetMethod(AuthorizationCodeChallenge* self, AuthenticationCodeChallengeMethod value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_Challenge")]
			public unsafe static extern void Challenge(AuthorizationCodeChallenge* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeChallenge_SetChallenge")]
			public unsafe static extern void SetChallenge(AuthorizationCodeChallenge* self, Discord_String value);
		}

		public struct AuthorizationCodeVerifier
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeVerifier_Drop")]
			public unsafe static extern void Drop(AuthorizationCodeVerifier* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeVerifier_Clone")]
			public unsafe static extern void Clone(AuthorizationCodeVerifier* self, AuthorizationCodeVerifier* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeVerifier_Challenge")]
			public unsafe static extern void Challenge(AuthorizationCodeVerifier* self, AuthorizationCodeChallenge* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeVerifier_SetChallenge")]
			public unsafe static extern void SetChallenge(AuthorizationCodeVerifier* self, AuthorizationCodeChallenge* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeVerifier_Verifier")]
			public unsafe static extern void Verifier(AuthorizationCodeVerifier* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationCodeVerifier_SetVerifier")]
			public unsafe static extern void SetVerifier(AuthorizationCodeVerifier* self, Discord_String value);
		}

		public struct AuthorizationArgs
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_Init")]
			public unsafe static extern void Init(AuthorizationArgs* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_Drop")]
			public unsafe static extern void Drop(AuthorizationArgs* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_Clone")]
			public unsafe static extern void Clone(AuthorizationArgs* self, AuthorizationArgs* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_ClientId")]
			public unsafe static extern ulong ClientId(AuthorizationArgs* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetClientId")]
			public unsafe static extern void SetClientId(AuthorizationArgs* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_Scopes")]
			public unsafe static extern void Scopes(AuthorizationArgs* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetScopes")]
			public unsafe static extern void SetScopes(AuthorizationArgs* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_State")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool State(AuthorizationArgs* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetState")]
			public unsafe static extern void SetState(AuthorizationArgs* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_Nonce")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Nonce(AuthorizationArgs* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetNonce")]
			public unsafe static extern void SetNonce(AuthorizationArgs* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_CodeChallenge")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool CodeChallenge(AuthorizationArgs* self, AuthorizationCodeChallenge* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetCodeChallenge")]
			public unsafe static extern void SetCodeChallenge(AuthorizationArgs* self, AuthorizationCodeChallenge* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_IntegrationType")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IntegrationType(AuthorizationArgs* self, IntegrationType* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetIntegrationType")]
			public unsafe static extern void SetIntegrationType(AuthorizationArgs* self, IntegrationType* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_CustomSchemeParam")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool CustomSchemeParam(AuthorizationArgs* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AuthorizationArgs_SetCustomSchemeParam")]
			public unsafe static extern void SetCustomSchemeParam(AuthorizationArgs* self, Discord_String* value);
		}

		public struct DeviceAuthorizationArgs
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_Init")]
			public unsafe static extern void Init(DeviceAuthorizationArgs* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_Drop")]
			public unsafe static extern void Drop(DeviceAuthorizationArgs* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_Clone")]
			public unsafe static extern void Clone(DeviceAuthorizationArgs* self, DeviceAuthorizationArgs* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_ClientId")]
			public unsafe static extern ulong ClientId(DeviceAuthorizationArgs* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_SetClientId")]
			public unsafe static extern void SetClientId(DeviceAuthorizationArgs* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_Scopes")]
			public unsafe static extern void Scopes(DeviceAuthorizationArgs* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_DeviceAuthorizationArgs_SetScopes")]
			public unsafe static extern void SetScopes(DeviceAuthorizationArgs* self, Discord_String value);
		}

		public struct VoiceStateHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VoiceStateHandle_Drop")]
			public unsafe static extern void Drop(VoiceStateHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VoiceStateHandle_Clone")]
			public unsafe static extern void Clone(VoiceStateHandle* self, VoiceStateHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VoiceStateHandle_SelfDeaf")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SelfDeaf(VoiceStateHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VoiceStateHandle_SelfMute")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SelfMute(VoiceStateHandle* self);
		}

		public struct VADThresholdSettings
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VADThresholdSettings_Drop")]
			public unsafe static extern void Drop(VADThresholdSettings* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VADThresholdSettings_VadThreshold")]
			public unsafe static extern float VadThreshold(VADThresholdSettings* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VADThresholdSettings_SetVadThreshold")]
			public unsafe static extern void SetVadThreshold(VADThresholdSettings* self, float value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VADThresholdSettings_Automatic")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Automatic(VADThresholdSettings* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_VADThresholdSettings_SetAutomatic")]
			public unsafe static extern void SetAutomatic(VADThresholdSettings* self, bool value);
		}

		public struct Call
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OnVoiceStateChanged(ulong userId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OnParticipantChanged(ulong userId, bool added, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OnSpeakingStatusChanged(ulong userId, bool isPlayingSound, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OnStatusChanged(Discord.Sdk.Call.Status status, Discord.Sdk.Call.Error error, int errorDetail, void* __userData);

			public IntPtr Opaque0;

			public IntPtr Opaque1;

			public IntPtr Opaque2;

			[MonoPInvokeCallback(typeof(OnVoiceStateChanged))]
			public unsafe static void OnVoiceStateChanged_Handler(ulong userId, void* __userData)
			{
				Discord.Sdk.Call.OnVoiceStateChanged onVoiceStateChanged = ManagedUserData.DelegateFromPointer<Discord.Sdk.Call.OnVoiceStateChanged>(__userData);
				try
				{
					onVoiceStateChanged(userId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(OnParticipantChanged))]
			public unsafe static void OnParticipantChanged_Handler(ulong userId, bool added, void* __userData)
			{
				Discord.Sdk.Call.OnParticipantChanged onParticipantChanged = ManagedUserData.DelegateFromPointer<Discord.Sdk.Call.OnParticipantChanged>(__userData);
				try
				{
					onParticipantChanged(userId, added);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(OnSpeakingStatusChanged))]
			public unsafe static void OnSpeakingStatusChanged_Handler(ulong userId, bool isPlayingSound, void* __userData)
			{
				Discord.Sdk.Call.OnSpeakingStatusChanged onSpeakingStatusChanged = ManagedUserData.DelegateFromPointer<Discord.Sdk.Call.OnSpeakingStatusChanged>(__userData);
				try
				{
					onSpeakingStatusChanged(userId, isPlayingSound);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(OnStatusChanged))]
			public unsafe static void OnStatusChanged_Handler(Discord.Sdk.Call.Status status, Discord.Sdk.Call.Error error, int errorDetail, void* __userData)
			{
				Discord.Sdk.Call.OnStatusChanged onStatusChanged = ManagedUserData.DelegateFromPointer<Discord.Sdk.Call.OnStatusChanged>(__userData);
				try
				{
					onStatusChanged(status, error, errorDetail);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_Drop")]
			public unsafe static extern void Drop(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_Clone")]
			public unsafe static extern void Clone(Call* self, Call* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_ErrorToString")]
			public unsafe static extern void ErrorToString(Discord.Sdk.Call.Error type, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetAudioMode")]
			public unsafe static extern AudioModeType GetAudioMode(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetChannelId")]
			public unsafe static extern ulong GetChannelId(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetGuildId")]
			public unsafe static extern ulong GetGuildId(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetLocalMute")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetLocalMute(Call* self, ulong userId);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetParticipants")]
			public unsafe static extern void GetParticipants(Call* self, Discord_UInt64Span* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetParticipantVolume")]
			public unsafe static extern float GetParticipantVolume(Call* self, ulong userId);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetPTTActive")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetPTTActive(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetPTTReleaseDelay")]
			public unsafe static extern uint GetPTTReleaseDelay(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetSelfDeaf")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetSelfDeaf(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetSelfMute")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetSelfMute(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetStatus")]
			public unsafe static extern Discord.Sdk.Call.Status GetStatus(Call* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetVADThreshold")]
			public unsafe static extern void GetVADThreshold(Call* self, VADThresholdSettings* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_GetVoiceStateHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetVoiceStateHandle(Call* self, ulong userId, VoiceStateHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetAudioMode")]
			public unsafe static extern void SetAudioMode(Call* self, AudioModeType audioMode);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetLocalMute")]
			public unsafe static extern void SetLocalMute(Call* self, ulong userId, bool mute);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetOnVoiceStateChangedCallback")]
			public unsafe static extern void SetOnVoiceStateChangedCallback(Call* self, OnVoiceStateChanged cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetParticipantChangedCallback")]
			public unsafe static extern void SetParticipantChangedCallback(Call* self, OnParticipantChanged cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetParticipantVolume")]
			public unsafe static extern void SetParticipantVolume(Call* self, ulong userId, float volume);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetPTTActive")]
			public unsafe static extern void SetPTTActive(Call* self, bool active);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetPTTReleaseDelay")]
			public unsafe static extern void SetPTTReleaseDelay(Call* self, uint releaseDelayMs);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetSelfDeaf")]
			public unsafe static extern void SetSelfDeaf(Call* self, bool deaf);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetSelfMute")]
			public unsafe static extern void SetSelfMute(Call* self, bool mute);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetSpeakingStatusChangedCallback")]
			public unsafe static extern void SetSpeakingStatusChangedCallback(Call* self, OnSpeakingStatusChanged cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetStatusChangedCallback")]
			public unsafe static extern void SetStatusChangedCallback(Call* self, OnStatusChanged cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_SetVADThreshold")]
			public unsafe static extern void SetVADThreshold(Call* self, bool automatic, float threshold);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Call_StatusToString")]
			public unsafe static extern void StatusToString(Discord.Sdk.Call.Status type, Discord_String* returnValue);
		}

		public struct ChannelHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ChannelHandle_Drop")]
			public unsafe static extern void Drop(ChannelHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ChannelHandle_Clone")]
			public unsafe static extern void Clone(ChannelHandle* self, ChannelHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ChannelHandle_Id")]
			public unsafe static extern ulong Id(ChannelHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ChannelHandle_Name")]
			public unsafe static extern void Name(ChannelHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ChannelHandle_Recipients")]
			public unsafe static extern void Recipients(ChannelHandle* self, Discord_UInt64Span* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ChannelHandle_Type")]
			public unsafe static extern ChannelType Type(ChannelHandle* self);
		}

		public struct GuildMinimal
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildMinimal_Drop")]
			public unsafe static extern void Drop(GuildMinimal* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildMinimal_Clone")]
			public unsafe static extern void Clone(GuildMinimal* self, GuildMinimal* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildMinimal_Id")]
			public unsafe static extern ulong Id(GuildMinimal* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildMinimal_SetId")]
			public unsafe static extern void SetId(GuildMinimal* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildMinimal_Name")]
			public unsafe static extern void Name(GuildMinimal* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildMinimal_SetName")]
			public unsafe static extern void SetName(GuildMinimal* self, Discord_String value);
		}

		public struct GuildChannel
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_Drop")]
			public unsafe static extern void Drop(GuildChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_Clone")]
			public unsafe static extern void Clone(GuildChannel* self, GuildChannel* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_Id")]
			public unsafe static extern ulong Id(GuildChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetId")]
			public unsafe static extern void SetId(GuildChannel* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_Name")]
			public unsafe static extern void Name(GuildChannel* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetName")]
			public unsafe static extern void SetName(GuildChannel* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_Type")]
			public unsafe static extern ChannelType Type(GuildChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetType")]
			public unsafe static extern void SetType(GuildChannel* self, ChannelType value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_Position")]
			public unsafe static extern int Position(GuildChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetPosition")]
			public unsafe static extern void SetPosition(GuildChannel* self, int value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_ParentId")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ParentId(GuildChannel* self, ulong* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetParentId")]
			public unsafe static extern void SetParentId(GuildChannel* self, ulong* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_IsLinkable")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsLinkable(GuildChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetIsLinkable")]
			public unsafe static extern void SetIsLinkable(GuildChannel* self, bool value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_IsViewableAndWriteableByAllMembers")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsViewableAndWriteableByAllMembers(GuildChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetIsViewableAndWriteableByAllMembers")]
			public unsafe static extern void SetIsViewableAndWriteableByAllMembers(GuildChannel* self, bool value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_LinkedLobby")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool LinkedLobby(GuildChannel* self, LinkedLobby* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_GuildChannel_SetLinkedLobby")]
			public unsafe static extern void SetLinkedLobby(GuildChannel* self, LinkedLobby* value);
		}

		public struct LinkedLobby
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_Init")]
			public unsafe static extern void Init(LinkedLobby* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_Drop")]
			public unsafe static extern void Drop(LinkedLobby* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_Clone")]
			public unsafe static extern void Clone(LinkedLobby* self, LinkedLobby* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_ApplicationId")]
			public unsafe static extern ulong ApplicationId(LinkedLobby* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_SetApplicationId")]
			public unsafe static extern void SetApplicationId(LinkedLobby* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_LobbyId")]
			public unsafe static extern ulong LobbyId(LinkedLobby* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedLobby_SetLobbyId")]
			public unsafe static extern void SetLobbyId(LinkedLobby* self, ulong value);
		}

		public struct LinkedChannel
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_Drop")]
			public unsafe static extern void Drop(LinkedChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_Clone")]
			public unsafe static extern void Clone(LinkedChannel* self, LinkedChannel* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_Id")]
			public unsafe static extern ulong Id(LinkedChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_SetId")]
			public unsafe static extern void SetId(LinkedChannel* self, ulong value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_Name")]
			public unsafe static extern void Name(LinkedChannel* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_SetName")]
			public unsafe static extern void SetName(LinkedChannel* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_GuildId")]
			public unsafe static extern ulong GuildId(LinkedChannel* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LinkedChannel_SetGuildId")]
			public unsafe static extern void SetGuildId(LinkedChannel* self, ulong value);
		}

		public struct RelationshipHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_Drop")]
			public unsafe static extern void Drop(RelationshipHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_Clone")]
			public unsafe static extern void Clone(RelationshipHandle* self, RelationshipHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_DiscordRelationshipType")]
			public unsafe static extern RelationshipType DiscordRelationshipType(RelationshipHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_GameRelationshipType")]
			public unsafe static extern RelationshipType GameRelationshipType(RelationshipHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_Id")]
			public unsafe static extern ulong Id(RelationshipHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_IsSpamRequest")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsSpamRequest(RelationshipHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RelationshipHandle_User")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool User(RelationshipHandle* self, UserHandle* returnValue);
		}

		public struct UserApplicationProfileHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_Drop")]
			public unsafe static extern void Drop(UserApplicationProfileHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_Clone")]
			public unsafe static extern void Clone(UserApplicationProfileHandle* self, UserApplicationProfileHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_AvatarHash")]
			public unsafe static extern void AvatarHash(UserApplicationProfileHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_Metadata")]
			public unsafe static extern void Metadata(UserApplicationProfileHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_ProviderId")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ProviderId(UserApplicationProfileHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_ProviderIssuedUserId")]
			public unsafe static extern void ProviderIssuedUserId(UserApplicationProfileHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_ProviderType")]
			public unsafe static extern ExternalIdentityProviderType ProviderType(UserApplicationProfileHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserApplicationProfileHandle_Username")]
			public unsafe static extern void Username(UserApplicationProfileHandle* self, Discord_String* returnValue);
		}

		public struct UserHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Drop")]
			public unsafe static extern void Drop(UserHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Clone")]
			public unsafe static extern void Clone(UserHandle* self, UserHandle* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Avatar")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Avatar(UserHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_AvatarTypeToString")]
			public unsafe static extern void AvatarTypeToString(Discord.Sdk.UserHandle.AvatarType type, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_AvatarUrl")]
			public unsafe static extern void AvatarUrl(UserHandle* self, Discord.Sdk.UserHandle.AvatarType animatedType, Discord.Sdk.UserHandle.AvatarType staticType, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_DisplayName")]
			public unsafe static extern void DisplayName(UserHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_GameActivity")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GameActivity(UserHandle* self, Activity* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_GlobalName")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GlobalName(UserHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Id")]
			public unsafe static extern ulong Id(UserHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_IsProvisional")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsProvisional(UserHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Relationship")]
			public unsafe static extern void Relationship(UserHandle* self, RelationshipHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Status")]
			public unsafe static extern StatusType Status(UserHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_UserApplicationProfiles")]
			public unsafe static extern void UserApplicationProfiles(UserHandle* self, Discord_UserApplicationProfileHandleSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserHandle_Username")]
			public unsafe static extern void Username(UserHandle* self, Discord_String* returnValue);
		}

		public struct LobbyMemberHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_Drop")]
			public unsafe static extern void Drop(LobbyMemberHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_Clone")]
			public unsafe static extern void Clone(LobbyMemberHandle* self, LobbyMemberHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_CanLinkLobby")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool CanLinkLobby(LobbyMemberHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_Connected")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Connected(LobbyMemberHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_Id")]
			public unsafe static extern ulong Id(LobbyMemberHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_Metadata")]
			public unsafe static extern void Metadata(LobbyMemberHandle* self, Discord_Properties* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyMemberHandle_User")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool User(LobbyMemberHandle* self, UserHandle* returnValue);
		}

		public struct LobbyHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_Drop")]
			public unsafe static extern void Drop(LobbyHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_Clone")]
			public unsafe static extern void Clone(LobbyHandle* self, LobbyHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_GetCallInfoHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetCallInfoHandle(LobbyHandle* self, CallInfoHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_GetLobbyMemberHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetLobbyMemberHandle(LobbyHandle* self, ulong memberId, LobbyMemberHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_Id")]
			public unsafe static extern ulong Id(LobbyHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_LinkedChannel")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool LinkedChannel(LobbyHandle* self, LinkedChannel* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_LobbyMemberIds")]
			public unsafe static extern void LobbyMemberIds(LobbyHandle* self, Discord_UInt64Span* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_LobbyMembers")]
			public unsafe static extern void LobbyMembers(LobbyHandle* self, Discord_LobbyMemberHandleSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_LobbyHandle_Metadata")]
			public unsafe static extern void Metadata(LobbyHandle* self, Discord_Properties* returnValue);
		}

		public struct AdditionalContent
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Init")]
			public unsafe static extern void Init(AdditionalContent* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Drop")]
			public unsafe static extern void Drop(AdditionalContent* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Clone")]
			public unsafe static extern void Clone(AdditionalContent* self, AdditionalContent* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Equals")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Equals(AdditionalContent* self, AdditionalContent* rhs);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_TypeToString")]
			public unsafe static extern void TypeToString(AdditionalContentType type, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Type")]
			public unsafe static extern AdditionalContentType Type(AdditionalContent* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_SetType")]
			public unsafe static extern void SetType(AdditionalContent* self, AdditionalContentType value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Title")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Title(AdditionalContent* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_SetTitle")]
			public unsafe static extern void SetTitle(AdditionalContent* self, Discord_String* value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_Count")]
			public unsafe static extern byte Count(AdditionalContent* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AdditionalContent_SetCount")]
			public unsafe static extern void SetCount(AdditionalContent* self, byte value);
		}

		public struct MessageHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Drop")]
			public unsafe static extern void Drop(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Clone")]
			public unsafe static extern void Clone(MessageHandle* self, MessageHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_AdditionalContent")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool AdditionalContent(MessageHandle* self, AdditionalContent* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_ApplicationId")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ApplicationId(MessageHandle* self, ulong* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Author")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Author(MessageHandle* self, UserHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_AuthorId")]
			public unsafe static extern ulong AuthorId(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Channel")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Channel(MessageHandle* self, ChannelHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_ChannelId")]
			public unsafe static extern ulong ChannelId(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Content")]
			public unsafe static extern void Content(MessageHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_DisclosureType")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool DisclosureType(MessageHandle* self, DisclosureTypes* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_EditedTimestamp")]
			public unsafe static extern ulong EditedTimestamp(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Id")]
			public unsafe static extern ulong Id(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Lobby")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Lobby(MessageHandle* self, LobbyHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Metadata")]
			public unsafe static extern void Metadata(MessageHandle* self, Discord_Properties* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_ModerationMetadata")]
			public unsafe static extern void ModerationMetadata(MessageHandle* self, Discord_Properties* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_RawContent")]
			public unsafe static extern void RawContent(MessageHandle* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_Recipient")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Recipient(MessageHandle* self, UserHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_RecipientId")]
			public unsafe static extern ulong RecipientId(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_SentFromGame")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SentFromGame(MessageHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_MessageHandle_SentTimestamp")]
			public unsafe static extern ulong SentTimestamp(MessageHandle* self);
		}

		public struct AudioDevice
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_Drop")]
			public unsafe static extern void Drop(AudioDevice* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_Clone")]
			public unsafe static extern void Clone(AudioDevice* self, AudioDevice* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_Equals")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool Equals(AudioDevice* self, AudioDevice* rhs);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_Id")]
			public unsafe static extern void Id(AudioDevice* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_SetId")]
			public unsafe static extern void SetId(AudioDevice* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_Name")]
			public unsafe static extern void Name(AudioDevice* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_SetName")]
			public unsafe static extern void SetName(AudioDevice* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_IsDefault")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsDefault(AudioDevice* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_AudioDevice_SetIsDefault")]
			public unsafe static extern void SetIsDefault(AudioDevice* self, bool value);
		}

		public struct UserMessageSummary
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserMessageSummary_Drop")]
			public unsafe static extern void Drop(UserMessageSummary* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserMessageSummary_Clone")]
			public unsafe static extern void Clone(UserMessageSummary* self, UserMessageSummary* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserMessageSummary_LastMessageId")]
			public unsafe static extern ulong LastMessageId(UserMessageSummary* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UserMessageSummary_UserId")]
			public unsafe static extern ulong UserId(UserMessageSummary* self);
		}

		public struct ClientCreateOptions
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_Init")]
			public unsafe static extern void Init(ClientCreateOptions* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_Drop")]
			public unsafe static extern void Drop(ClientCreateOptions* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_Clone")]
			public unsafe static extern void Clone(ClientCreateOptions* self, ClientCreateOptions* arg0);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_WebBase")]
			public unsafe static extern void WebBase(ClientCreateOptions* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_SetWebBase")]
			public unsafe static extern void SetWebBase(ClientCreateOptions* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_ApiBase")]
			public unsafe static extern void ApiBase(ClientCreateOptions* self, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_SetApiBase")]
			public unsafe static extern void SetApiBase(ClientCreateOptions* self, Discord_String value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_ExperimentalAudioSystem")]
			public unsafe static extern AudioSystem ExperimentalAudioSystem(ClientCreateOptions* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_SetExperimentalAudioSystem")]
			public unsafe static extern void SetExperimentalAudioSystem(ClientCreateOptions* self, AudioSystem value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_ExperimentalAndroidPreventCommsForBluetooth")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ExperimentalAndroidPreventCommsForBluetooth(ClientCreateOptions* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_SetExperimentalAndroidPreventCommsForBluetooth")]
			public unsafe static extern void SetExperimentalAndroidPreventCommsForBluetooth(ClientCreateOptions* self, bool value);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_CpuAffinityMask")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool CpuAffinityMask(ClientCreateOptions* self, ulong* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClientCreateOptions_SetCpuAffinityMask")]
			public unsafe static extern void SetCpuAffinityMask(ClientCreateOptions* self, ulong* value);
		}

		public struct Client
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void EndCallCallback(void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void EndCallsCallback(void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetCurrentInputDeviceCallback(AudioDevice* device, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetCurrentOutputDeviceCallback(AudioDevice* device, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetInputDevicesCallback(Discord_AudioDeviceSpan devices, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetOutputDevicesCallback(Discord_AudioDeviceSpan devices, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void DeviceChangeCallback(Discord_AudioDeviceSpan inputDevices, Discord_AudioDeviceSpan outputDevices, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void SetInputDeviceCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void NoAudioInputCallback(bool inputDetected, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void SetOutputDeviceCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void VoiceParticipantChangedCallback(ulong lobbyId, ulong memberId, bool added, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UserAudioReceivedCallback(ulong userId, short* data, ulong samplesPerChannel, int sampleRate, ulong channels, bool* outShouldMute, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UserAudioCapturedCallback(short* data, ulong samplesPerChannel, int sampleRate, ulong channels, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void AuthorizationCallback(ClientResult* result, Discord_String code, Discord_String redirectUri, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void ExchangeChildTokenCallback(ClientResult* result, Discord_String accessToken, AuthorizationTokenType tokenType, int expiresIn, Discord_String scopes, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void FetchCurrentUserCallback(ClientResult* result, ulong id, Discord_String name, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void TokenExchangeCallback(ClientResult* result, Discord_String accessToken, Discord_String refreshToken, AuthorizationTokenType tokenType, int expiresIn, Discord_String scopes, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void AuthorizeRequestCallback(void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void RevokeTokenCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void AuthorizeDeviceScreenClosedCallback(void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void TokenExpirationCallback(void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UnmergeIntoProvisionalAccountCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UpdateProvisionalAccountDisplayNameCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UpdateTokenCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void DeleteUserMessageCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void EditUserMessageCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetLobbyMessagesCallback(ClientResult* result, Discord_MessageHandleSpan messages, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UserMessageSummariesCallback(ClientResult* result, Discord_UserMessageSummarySpan summaries, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UserMessagesWithLimitCallback(ClientResult* result, Discord_MessageHandleSpan messages, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void ProvisionalUserMergeRequiredCallback(void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OpenMessageInDiscordCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void SendUserMessageCallback(ClientResult* result, ulong messageId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void MessageCreatedCallback(ulong messageId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void MessageDeletedCallback(ulong messageId, ulong channelId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void MessageUpdatedCallback(ulong messageId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LogCallback(Discord_String message, LoggingSeverity severity, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OpenConnectedGamesSettingsInDiscordCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void OnStatusChanged(Discord.Sdk.Client.Status status, Discord.Sdk.Client.Error error, int errorDetail, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void CreateOrJoinLobbyCallback(ClientResult* result, ulong lobbyId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetGuildChannelsCallback(ClientResult* result, Discord_GuildChannelSpan guildChannels, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetUserGuildsCallback(ClientResult* result, Discord_GuildMinimalSpan guilds, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void JoinLinkedLobbyGuildCallback(ClientResult* result, Discord_String inviteUrl, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LeaveLobbyCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LinkOrUnlinkChannelCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LobbyCreatedCallback(ulong lobbyId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LobbyDeletedCallback(ulong lobbyId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LobbyMemberAddedCallback(ulong lobbyId, ulong memberId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LobbyMemberRemovedCallback(ulong lobbyId, ulong memberId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LobbyMemberUpdatedCallback(ulong lobbyId, ulong memberId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void LobbyUpdatedCallback(ulong lobbyId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void IsDiscordAppInstalledCallback(bool installed, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void AcceptActivityInviteCallback(ClientResult* result, Discord_String joinSecret, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void SendActivityInviteCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void ActivityInviteCallback(ActivityInvite* invite, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void ActivityJoinCallback(Discord_String joinSecret, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void ActivityJoinWithApplicationCallback(ulong applicationId, Discord_String joinSecret, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UpdateStatusCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UpdateRichPresenceCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UpdateRelationshipCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void SendFriendRequestCallback(ClientResult* result, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void RelationshipCreatedCallback(ulong userId, bool isDiscordRelationshipUpdate, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void RelationshipDeletedCallback(ulong userId, bool isDiscordRelationshipUpdate, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void GetDiscordClientConnectedUserCallback(ClientResult* result, UserHandle* user, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void RelationshipGroupsUpdatedCallback(ulong userId, void* __userData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void UserUpdatedCallback(ulong userId, void* __userData);

			public IntPtr Handle;

			[MonoPInvokeCallback(typeof(EndCallCallback))]
			public unsafe static void EndCallCallback_Handler(void* __userData)
			{
				Discord.Sdk.Client.EndCallCallback endCallCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.EndCallCallback>(__userData);
				try
				{
					endCallCallback();
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(EndCallsCallback))]
			public unsafe static void EndCallsCallback_Handler(void* __userData)
			{
				Discord.Sdk.Client.EndCallsCallback endCallsCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.EndCallsCallback>(__userData);
				try
				{
					endCallsCallback();
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(GetCurrentInputDeviceCallback))]
			public unsafe static void GetCurrentInputDeviceCallback_Handler(AudioDevice* device, void* __userData)
			{
				Discord.Sdk.Client.GetCurrentInputDeviceCallback getCurrentInputDeviceCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetCurrentInputDeviceCallback>(__userData);
				try
				{
					getCurrentInputDeviceCallback(new Discord.Sdk.AudioDevice(device));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(GetCurrentOutputDeviceCallback))]
			public unsafe static void GetCurrentOutputDeviceCallback_Handler(AudioDevice* device, void* __userData)
			{
				Discord.Sdk.Client.GetCurrentOutputDeviceCallback getCurrentOutputDeviceCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetCurrentOutputDeviceCallback>(__userData);
				try
				{
					getCurrentOutputDeviceCallback(new Discord.Sdk.AudioDevice(device));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(GetInputDevicesCallback))]
			public unsafe static void GetInputDevicesCallback_Handler(Discord_AudioDeviceSpan devices, void* __userData)
			{
				Discord.Sdk.Client.GetInputDevicesCallback getInputDevicesCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetInputDevicesCallback>(__userData);
				try
				{
					getInputDevicesCallback((from __native in new Span<AudioDevice>(devices.ptr, (int)(uint)devices.size).ToArray()
						select new Discord.Sdk.AudioDevice(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(devices.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(GetOutputDevicesCallback))]
			public unsafe static void GetOutputDevicesCallback_Handler(Discord_AudioDeviceSpan devices, void* __userData)
			{
				Discord.Sdk.Client.GetOutputDevicesCallback getOutputDevicesCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetOutputDevicesCallback>(__userData);
				try
				{
					getOutputDevicesCallback((from __native in new Span<AudioDevice>(devices.ptr, (int)(uint)devices.size).ToArray()
						select new Discord.Sdk.AudioDevice(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(devices.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(DeviceChangeCallback))]
			public unsafe static void DeviceChangeCallback_Handler(Discord_AudioDeviceSpan inputDevices, Discord_AudioDeviceSpan outputDevices, void* __userData)
			{
				Discord.Sdk.Client.DeviceChangeCallback deviceChangeCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.DeviceChangeCallback>(__userData);
				try
				{
					deviceChangeCallback((from __native in new Span<AudioDevice>(inputDevices.ptr, (int)(uint)inputDevices.size).ToArray()
						select new Discord.Sdk.AudioDevice(__native, 0)).ToArray(), (from __native in new Span<AudioDevice>(outputDevices.ptr, (int)(uint)outputDevices.size).ToArray()
						select new Discord.Sdk.AudioDevice(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(inputDevices.ptr);
					Discord_Free(outputDevices.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(SetInputDeviceCallback))]
			public unsafe static void SetInputDeviceCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.SetInputDeviceCallback setInputDeviceCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.SetInputDeviceCallback>(__userData);
				try
				{
					setInputDeviceCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(NoAudioInputCallback))]
			public unsafe static void NoAudioInputCallback_Handler(bool inputDetected, void* __userData)
			{
				Discord.Sdk.Client.NoAudioInputCallback noAudioInputCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.NoAudioInputCallback>(__userData);
				try
				{
					noAudioInputCallback(inputDetected);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(SetOutputDeviceCallback))]
			public unsafe static void SetOutputDeviceCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.SetOutputDeviceCallback setOutputDeviceCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.SetOutputDeviceCallback>(__userData);
				try
				{
					setOutputDeviceCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(VoiceParticipantChangedCallback))]
			public unsafe static void VoiceParticipantChangedCallback_Handler(ulong lobbyId, ulong memberId, bool added, void* __userData)
			{
				Discord.Sdk.Client.VoiceParticipantChangedCallback voiceParticipantChangedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.VoiceParticipantChangedCallback>(__userData);
				try
				{
					voiceParticipantChangedCallback(lobbyId, memberId, added);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UserAudioReceivedCallback))]
			public unsafe static void UserAudioReceivedCallback_Handler(ulong userId, short* data, ulong samplesPerChannel, int sampleRate, ulong channels, bool* outShouldMute, void* __userData)
			{
				Discord.Sdk.Client.UserAudioReceivedCallback userAudioReceivedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UserAudioReceivedCallback>(__userData);
				try
				{
					userAudioReceivedCallback(userId, (IntPtr)data, samplesPerChannel, sampleRate, channels, ref *outShouldMute);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UserAudioCapturedCallback))]
			public unsafe static void UserAudioCapturedCallback_Handler(short* data, ulong samplesPerChannel, int sampleRate, ulong channels, void* __userData)
			{
				Discord.Sdk.Client.UserAudioCapturedCallback userAudioCapturedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UserAudioCapturedCallback>(__userData);
				try
				{
					userAudioCapturedCallback((IntPtr)data, samplesPerChannel, sampleRate, channels);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(AuthorizationCallback))]
			public unsafe static void AuthorizationCallback_Handler(ClientResult* result, Discord_String code, Discord_String redirectUri, void* __userData)
			{
				Discord.Sdk.Client.AuthorizationCallback authorizationCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.AuthorizationCallback>(__userData);
				try
				{
					authorizationCallback(new Discord.Sdk.ClientResult(*result, 0), Marshal.PtrToStringUTF8((IntPtr)code.ptr, (int)(uint)code.size), Marshal.PtrToStringUTF8((IntPtr)redirectUri.ptr, (int)(uint)redirectUri.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(code.ptr);
					Discord_Free(redirectUri.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(ExchangeChildTokenCallback))]
			public unsafe static void ExchangeChildTokenCallback_Handler(ClientResult* result, Discord_String accessToken, AuthorizationTokenType tokenType, int expiresIn, Discord_String scopes, void* __userData)
			{
				Discord.Sdk.Client.ExchangeChildTokenCallback exchangeChildTokenCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.ExchangeChildTokenCallback>(__userData);
				try
				{
					exchangeChildTokenCallback(new Discord.Sdk.ClientResult(*result, 0), Marshal.PtrToStringUTF8((IntPtr)accessToken.ptr, (int)(uint)accessToken.size), tokenType, expiresIn, Marshal.PtrToStringUTF8((IntPtr)scopes.ptr, (int)(uint)scopes.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(accessToken.ptr);
					Discord_Free(scopes.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(FetchCurrentUserCallback))]
			public unsafe static void FetchCurrentUserCallback_Handler(ClientResult* result, ulong id, Discord_String name, void* __userData)
			{
				Discord.Sdk.Client.FetchCurrentUserCallback fetchCurrentUserCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.FetchCurrentUserCallback>(__userData);
				try
				{
					fetchCurrentUserCallback(new Discord.Sdk.ClientResult(*result, 0), id, Marshal.PtrToStringUTF8((IntPtr)name.ptr, (int)(uint)name.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(name.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(TokenExchangeCallback))]
			public unsafe static void TokenExchangeCallback_Handler(ClientResult* result, Discord_String accessToken, Discord_String refreshToken, AuthorizationTokenType tokenType, int expiresIn, Discord_String scopes, void* __userData)
			{
				Discord.Sdk.Client.TokenExchangeCallback tokenExchangeCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.TokenExchangeCallback>(__userData);
				try
				{
					tokenExchangeCallback(new Discord.Sdk.ClientResult(*result, 0), Marshal.PtrToStringUTF8((IntPtr)accessToken.ptr, (int)(uint)accessToken.size), Marshal.PtrToStringUTF8((IntPtr)refreshToken.ptr, (int)(uint)refreshToken.size), tokenType, expiresIn, Marshal.PtrToStringUTF8((IntPtr)scopes.ptr, (int)(uint)scopes.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(accessToken.ptr);
					Discord_Free(refreshToken.ptr);
					Discord_Free(scopes.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(AuthorizeRequestCallback))]
			public unsafe static void AuthorizeRequestCallback_Handler(void* __userData)
			{
				Discord.Sdk.Client.AuthorizeRequestCallback authorizeRequestCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.AuthorizeRequestCallback>(__userData);
				try
				{
					authorizeRequestCallback();
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(RevokeTokenCallback))]
			public unsafe static void RevokeTokenCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.RevokeTokenCallback revokeTokenCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.RevokeTokenCallback>(__userData);
				try
				{
					revokeTokenCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(AuthorizeDeviceScreenClosedCallback))]
			public unsafe static void AuthorizeDeviceScreenClosedCallback_Handler(void* __userData)
			{
				Discord.Sdk.Client.AuthorizeDeviceScreenClosedCallback authorizeDeviceScreenClosedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.AuthorizeDeviceScreenClosedCallback>(__userData);
				try
				{
					authorizeDeviceScreenClosedCallback();
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(TokenExpirationCallback))]
			public unsafe static void TokenExpirationCallback_Handler(void* __userData)
			{
				Discord.Sdk.Client.TokenExpirationCallback tokenExpirationCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.TokenExpirationCallback>(__userData);
				try
				{
					tokenExpirationCallback();
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UnmergeIntoProvisionalAccountCallback))]
			public unsafe static void UnmergeIntoProvisionalAccountCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.UnmergeIntoProvisionalAccountCallback unmergeIntoProvisionalAccountCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UnmergeIntoProvisionalAccountCallback>(__userData);
				try
				{
					unmergeIntoProvisionalAccountCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UpdateProvisionalAccountDisplayNameCallback))]
			public unsafe static void UpdateProvisionalAccountDisplayNameCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.UpdateProvisionalAccountDisplayNameCallback updateProvisionalAccountDisplayNameCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UpdateProvisionalAccountDisplayNameCallback>(__userData);
				try
				{
					updateProvisionalAccountDisplayNameCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UpdateTokenCallback))]
			public unsafe static void UpdateTokenCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.UpdateTokenCallback updateTokenCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UpdateTokenCallback>(__userData);
				try
				{
					updateTokenCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(DeleteUserMessageCallback))]
			public unsafe static void DeleteUserMessageCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.DeleteUserMessageCallback deleteUserMessageCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.DeleteUserMessageCallback>(__userData);
				try
				{
					deleteUserMessageCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(EditUserMessageCallback))]
			public unsafe static void EditUserMessageCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.EditUserMessageCallback editUserMessageCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.EditUserMessageCallback>(__userData);
				try
				{
					editUserMessageCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(GetLobbyMessagesCallback))]
			public unsafe static void GetLobbyMessagesCallback_Handler(ClientResult* result, Discord_MessageHandleSpan messages, void* __userData)
			{
				Discord.Sdk.Client.GetLobbyMessagesCallback getLobbyMessagesCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetLobbyMessagesCallback>(__userData);
				try
				{
					getLobbyMessagesCallback(new Discord.Sdk.ClientResult(*result, 0), (from __native in new Span<MessageHandle>(messages.ptr, (int)(uint)messages.size).ToArray()
						select new Discord.Sdk.MessageHandle(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(messages.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(UserMessageSummariesCallback))]
			public unsafe static void UserMessageSummariesCallback_Handler(ClientResult* result, Discord_UserMessageSummarySpan summaries, void* __userData)
			{
				Discord.Sdk.Client.UserMessageSummariesCallback userMessageSummariesCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UserMessageSummariesCallback>(__userData);
				try
				{
					userMessageSummariesCallback(new Discord.Sdk.ClientResult(*result, 0), (from __native in new Span<UserMessageSummary>(summaries.ptr, (int)(uint)summaries.size).ToArray()
						select new Discord.Sdk.UserMessageSummary(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(summaries.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(UserMessagesWithLimitCallback))]
			public unsafe static void UserMessagesWithLimitCallback_Handler(ClientResult* result, Discord_MessageHandleSpan messages, void* __userData)
			{
				Discord.Sdk.Client.UserMessagesWithLimitCallback userMessagesWithLimitCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UserMessagesWithLimitCallback>(__userData);
				try
				{
					userMessagesWithLimitCallback(new Discord.Sdk.ClientResult(*result, 0), (from __native in new Span<MessageHandle>(messages.ptr, (int)(uint)messages.size).ToArray()
						select new Discord.Sdk.MessageHandle(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(messages.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(ProvisionalUserMergeRequiredCallback))]
			public unsafe static void ProvisionalUserMergeRequiredCallback_Handler(void* __userData)
			{
				Discord.Sdk.Client.ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.ProvisionalUserMergeRequiredCallback>(__userData);
				try
				{
					provisionalUserMergeRequiredCallback();
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(OpenMessageInDiscordCallback))]
			public unsafe static void OpenMessageInDiscordCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.OpenMessageInDiscordCallback openMessageInDiscordCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.OpenMessageInDiscordCallback>(__userData);
				try
				{
					openMessageInDiscordCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(SendUserMessageCallback))]
			public unsafe static void SendUserMessageCallback_Handler(ClientResult* result, ulong messageId, void* __userData)
			{
				Discord.Sdk.Client.SendUserMessageCallback sendUserMessageCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.SendUserMessageCallback>(__userData);
				try
				{
					sendUserMessageCallback(new Discord.Sdk.ClientResult(*result, 0), messageId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(MessageCreatedCallback))]
			public unsafe static void MessageCreatedCallback_Handler(ulong messageId, void* __userData)
			{
				Discord.Sdk.Client.MessageCreatedCallback messageCreatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.MessageCreatedCallback>(__userData);
				try
				{
					messageCreatedCallback(messageId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(MessageDeletedCallback))]
			public unsafe static void MessageDeletedCallback_Handler(ulong messageId, ulong channelId, void* __userData)
			{
				Discord.Sdk.Client.MessageDeletedCallback messageDeletedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.MessageDeletedCallback>(__userData);
				try
				{
					messageDeletedCallback(messageId, channelId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(MessageUpdatedCallback))]
			public unsafe static void MessageUpdatedCallback_Handler(ulong messageId, void* __userData)
			{
				Discord.Sdk.Client.MessageUpdatedCallback messageUpdatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.MessageUpdatedCallback>(__userData);
				try
				{
					messageUpdatedCallback(messageId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LogCallback))]
			public unsafe static void LogCallback_Handler(Discord_String message, LoggingSeverity severity, void* __userData)
			{
				Discord.Sdk.Client.LogCallback logCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LogCallback>(__userData);
				try
				{
					logCallback(Marshal.PtrToStringUTF8((IntPtr)message.ptr, (int)(uint)message.size), severity);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(message.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(OpenConnectedGamesSettingsInDiscordCallback))]
			public unsafe static void OpenConnectedGamesSettingsInDiscordCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.OpenConnectedGamesSettingsInDiscordCallback openConnectedGamesSettingsInDiscordCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.OpenConnectedGamesSettingsInDiscordCallback>(__userData);
				try
				{
					openConnectedGamesSettingsInDiscordCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(OnStatusChanged))]
			public unsafe static void OnStatusChanged_Handler(Discord.Sdk.Client.Status status, Discord.Sdk.Client.Error error, int errorDetail, void* __userData)
			{
				Discord.Sdk.Client.OnStatusChanged onStatusChanged = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.OnStatusChanged>(__userData);
				try
				{
					onStatusChanged(status, error, errorDetail);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(CreateOrJoinLobbyCallback))]
			public unsafe static void CreateOrJoinLobbyCallback_Handler(ClientResult* result, ulong lobbyId, void* __userData)
			{
				Discord.Sdk.Client.CreateOrJoinLobbyCallback createOrJoinLobbyCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.CreateOrJoinLobbyCallback>(__userData);
				try
				{
					createOrJoinLobbyCallback(new Discord.Sdk.ClientResult(*result, 0), lobbyId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(GetGuildChannelsCallback))]
			public unsafe static void GetGuildChannelsCallback_Handler(ClientResult* result, Discord_GuildChannelSpan guildChannels, void* __userData)
			{
				Discord.Sdk.Client.GetGuildChannelsCallback getGuildChannelsCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetGuildChannelsCallback>(__userData);
				try
				{
					getGuildChannelsCallback(new Discord.Sdk.ClientResult(*result, 0), (from __native in new Span<GuildChannel>(guildChannels.ptr, (int)(uint)guildChannels.size).ToArray()
						select new Discord.Sdk.GuildChannel(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(guildChannels.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(GetUserGuildsCallback))]
			public unsafe static void GetUserGuildsCallback_Handler(ClientResult* result, Discord_GuildMinimalSpan guilds, void* __userData)
			{
				Discord.Sdk.Client.GetUserGuildsCallback getUserGuildsCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetUserGuildsCallback>(__userData);
				try
				{
					getUserGuildsCallback(new Discord.Sdk.ClientResult(*result, 0), (from __native in new Span<GuildMinimal>(guilds.ptr, (int)(uint)guilds.size).ToArray()
						select new Discord.Sdk.GuildMinimal(__native, 0)).ToArray());
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(guilds.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(JoinLinkedLobbyGuildCallback))]
			public unsafe static void JoinLinkedLobbyGuildCallback_Handler(ClientResult* result, Discord_String inviteUrl, void* __userData)
			{
				Discord.Sdk.Client.JoinLinkedLobbyGuildCallback joinLinkedLobbyGuildCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.JoinLinkedLobbyGuildCallback>(__userData);
				try
				{
					joinLinkedLobbyGuildCallback(new Discord.Sdk.ClientResult(*result, 0), Marshal.PtrToStringUTF8((IntPtr)inviteUrl.ptr, (int)(uint)inviteUrl.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(inviteUrl.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(LeaveLobbyCallback))]
			public unsafe static void LeaveLobbyCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.LeaveLobbyCallback leaveLobbyCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LeaveLobbyCallback>(__userData);
				try
				{
					leaveLobbyCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LinkOrUnlinkChannelCallback))]
			public unsafe static void LinkOrUnlinkChannelCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.LinkOrUnlinkChannelCallback linkOrUnlinkChannelCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LinkOrUnlinkChannelCallback>(__userData);
				try
				{
					linkOrUnlinkChannelCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LobbyCreatedCallback))]
			public unsafe static void LobbyCreatedCallback_Handler(ulong lobbyId, void* __userData)
			{
				Discord.Sdk.Client.LobbyCreatedCallback lobbyCreatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LobbyCreatedCallback>(__userData);
				try
				{
					lobbyCreatedCallback(lobbyId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LobbyDeletedCallback))]
			public unsafe static void LobbyDeletedCallback_Handler(ulong lobbyId, void* __userData)
			{
				Discord.Sdk.Client.LobbyDeletedCallback lobbyDeletedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LobbyDeletedCallback>(__userData);
				try
				{
					lobbyDeletedCallback(lobbyId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LobbyMemberAddedCallback))]
			public unsafe static void LobbyMemberAddedCallback_Handler(ulong lobbyId, ulong memberId, void* __userData)
			{
				Discord.Sdk.Client.LobbyMemberAddedCallback lobbyMemberAddedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LobbyMemberAddedCallback>(__userData);
				try
				{
					lobbyMemberAddedCallback(lobbyId, memberId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LobbyMemberRemovedCallback))]
			public unsafe static void LobbyMemberRemovedCallback_Handler(ulong lobbyId, ulong memberId, void* __userData)
			{
				Discord.Sdk.Client.LobbyMemberRemovedCallback lobbyMemberRemovedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LobbyMemberRemovedCallback>(__userData);
				try
				{
					lobbyMemberRemovedCallback(lobbyId, memberId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LobbyMemberUpdatedCallback))]
			public unsafe static void LobbyMemberUpdatedCallback_Handler(ulong lobbyId, ulong memberId, void* __userData)
			{
				Discord.Sdk.Client.LobbyMemberUpdatedCallback lobbyMemberUpdatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LobbyMemberUpdatedCallback>(__userData);
				try
				{
					lobbyMemberUpdatedCallback(lobbyId, memberId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(LobbyUpdatedCallback))]
			public unsafe static void LobbyUpdatedCallback_Handler(ulong lobbyId, void* __userData)
			{
				Discord.Sdk.Client.LobbyUpdatedCallback lobbyUpdatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.LobbyUpdatedCallback>(__userData);
				try
				{
					lobbyUpdatedCallback(lobbyId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(IsDiscordAppInstalledCallback))]
			public unsafe static void IsDiscordAppInstalledCallback_Handler(bool installed, void* __userData)
			{
				Discord.Sdk.Client.IsDiscordAppInstalledCallback isDiscordAppInstalledCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.IsDiscordAppInstalledCallback>(__userData);
				try
				{
					isDiscordAppInstalledCallback(installed);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(AcceptActivityInviteCallback))]
			public unsafe static void AcceptActivityInviteCallback_Handler(ClientResult* result, Discord_String joinSecret, void* __userData)
			{
				Discord.Sdk.Client.AcceptActivityInviteCallback acceptActivityInviteCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.AcceptActivityInviteCallback>(__userData);
				try
				{
					acceptActivityInviteCallback(new Discord.Sdk.ClientResult(*result, 0), Marshal.PtrToStringUTF8((IntPtr)joinSecret.ptr, (int)(uint)joinSecret.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(joinSecret.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(SendActivityInviteCallback))]
			public unsafe static void SendActivityInviteCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.SendActivityInviteCallback sendActivityInviteCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.SendActivityInviteCallback>(__userData);
				try
				{
					sendActivityInviteCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(ActivityInviteCallback))]
			public unsafe static void ActivityInviteCallback_Handler(ActivityInvite* invite, void* __userData)
			{
				Discord.Sdk.Client.ActivityInviteCallback activityInviteCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.ActivityInviteCallback>(__userData);
				try
				{
					activityInviteCallback(new Discord.Sdk.ActivityInvite(*invite, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(ActivityJoinCallback))]
			public unsafe static void ActivityJoinCallback_Handler(Discord_String joinSecret, void* __userData)
			{
				Discord.Sdk.Client.ActivityJoinCallback activityJoinCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.ActivityJoinCallback>(__userData);
				try
				{
					activityJoinCallback(Marshal.PtrToStringUTF8((IntPtr)joinSecret.ptr, (int)(uint)joinSecret.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(joinSecret.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(ActivityJoinWithApplicationCallback))]
			public unsafe static void ActivityJoinWithApplicationCallback_Handler(ulong applicationId, Discord_String joinSecret, void* __userData)
			{
				Discord.Sdk.Client.ActivityJoinWithApplicationCallback activityJoinWithApplicationCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.ActivityJoinWithApplicationCallback>(__userData);
				try
				{
					activityJoinWithApplicationCallback(applicationId, Marshal.PtrToStringUTF8((IntPtr)joinSecret.ptr, (int)(uint)joinSecret.size));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
				finally
				{
					Discord_Free(joinSecret.ptr);
				}
			}

			[MonoPInvokeCallback(typeof(UpdateStatusCallback))]
			public unsafe static void UpdateStatusCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.UpdateStatusCallback updateStatusCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UpdateStatusCallback>(__userData);
				try
				{
					updateStatusCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UpdateRichPresenceCallback))]
			public unsafe static void UpdateRichPresenceCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.UpdateRichPresenceCallback updateRichPresenceCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UpdateRichPresenceCallback>(__userData);
				try
				{
					updateRichPresenceCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UpdateRelationshipCallback))]
			public unsafe static void UpdateRelationshipCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.UpdateRelationshipCallback updateRelationshipCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UpdateRelationshipCallback>(__userData);
				try
				{
					updateRelationshipCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(SendFriendRequestCallback))]
			public unsafe static void SendFriendRequestCallback_Handler(ClientResult* result, void* __userData)
			{
				Discord.Sdk.Client.SendFriendRequestCallback sendFriendRequestCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.SendFriendRequestCallback>(__userData);
				try
				{
					sendFriendRequestCallback(new Discord.Sdk.ClientResult(*result, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(RelationshipCreatedCallback))]
			public unsafe static void RelationshipCreatedCallback_Handler(ulong userId, bool isDiscordRelationshipUpdate, void* __userData)
			{
				Discord.Sdk.Client.RelationshipCreatedCallback relationshipCreatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.RelationshipCreatedCallback>(__userData);
				try
				{
					relationshipCreatedCallback(userId, isDiscordRelationshipUpdate);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(RelationshipDeletedCallback))]
			public unsafe static void RelationshipDeletedCallback_Handler(ulong userId, bool isDiscordRelationshipUpdate, void* __userData)
			{
				Discord.Sdk.Client.RelationshipDeletedCallback relationshipDeletedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.RelationshipDeletedCallback>(__userData);
				try
				{
					relationshipDeletedCallback(userId, isDiscordRelationshipUpdate);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(GetDiscordClientConnectedUserCallback))]
			public unsafe static void GetDiscordClientConnectedUserCallback_Handler(ClientResult* result, UserHandle* user, void* __userData)
			{
				Discord.Sdk.Client.GetDiscordClientConnectedUserCallback getDiscordClientConnectedUserCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.GetDiscordClientConnectedUserCallback>(__userData);
				try
				{
					getDiscordClientConnectedUserCallback(new Discord.Sdk.ClientResult(*result, 0), (user == null) ? null : new Discord.Sdk.UserHandle(*user, 0));
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(RelationshipGroupsUpdatedCallback))]
			public unsafe static void RelationshipGroupsUpdatedCallback_Handler(ulong userId, void* __userData)
			{
				Discord.Sdk.Client.RelationshipGroupsUpdatedCallback relationshipGroupsUpdatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.RelationshipGroupsUpdatedCallback>(__userData);
				try
				{
					relationshipGroupsUpdatedCallback(userId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[MonoPInvokeCallback(typeof(UserUpdatedCallback))]
			public unsafe static void UserUpdatedCallback_Handler(ulong userId, void* __userData)
			{
				Discord.Sdk.Client.UserUpdatedCallback userUpdatedCallback = ManagedUserData.DelegateFromPointer<Discord.Sdk.Client.UserUpdatedCallback>(__userData);
				try
				{
					userUpdatedCallback(userId);
				}
				catch (Exception ex)
				{
					__ReportUnhandledException(ex);
				}
			}

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_Init")]
			public unsafe static extern void Init(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_InitWithBases")]
			public unsafe static extern void InitWithBases(Client* self, Discord_String apiBase, Discord_String webBase);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_InitWithOptions")]
			public unsafe static extern void InitWithOptions(Client* self, ClientCreateOptions* options);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_Drop")]
			public unsafe static extern void Drop(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_ErrorToString")]
			public unsafe static extern void ErrorToString(Discord.Sdk.Client.Error type, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetApplicationId")]
			public unsafe static extern ulong GetApplicationId(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetCurrentUser")]
			public unsafe static extern void GetCurrentUser(Client* self, UserHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetDefaultAudioDeviceId")]
			public unsafe static extern void GetDefaultAudioDeviceId(Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetDefaultCommunicationScopes")]
			public unsafe static extern void GetDefaultCommunicationScopes(Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetDefaultPresenceScopes")]
			public unsafe static extern void GetDefaultPresenceScopes(Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetVersionHash")]
			public unsafe static extern void GetVersionHash(Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetVersionMajor")]
			public static extern int GetVersionMajor();

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetVersionMinor")]
			public static extern int GetVersionMinor();

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetVersionPatch")]
			public static extern int GetVersionPatch();

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetHttpRequestTimeout")]
			public unsafe static extern void SetHttpRequestTimeout(Client* self, int httpTimeoutInMilliseconds);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_StatusToString")]
			public unsafe static extern void StatusToString(Discord.Sdk.Client.Status type, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_ThreadToString")]
			public unsafe static extern void ThreadToString(Discord.Sdk.Client.Thread type, Discord_String* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_EndCall")]
			public unsafe static extern void EndCall(Client* self, ulong channelId, EndCallCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_EndCalls")]
			public unsafe static extern void EndCalls(Client* self, EndCallsCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetCall")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetCall(Client* self, ulong channelId, Call* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetCalls")]
			public unsafe static extern void GetCalls(Client* self, Discord_CallSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetCurrentInputDevice")]
			public unsafe static extern void GetCurrentInputDevice(Client* self, GetCurrentInputDeviceCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetCurrentOutputDevice")]
			public unsafe static extern void GetCurrentOutputDevice(Client* self, GetCurrentOutputDeviceCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetInputDevices")]
			public unsafe static extern void GetInputDevices(Client* self, GetInputDevicesCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetInputVolume")]
			public unsafe static extern float GetInputVolume(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetOutputDevices")]
			public unsafe static extern void GetOutputDevices(Client* self, GetOutputDevicesCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetOutputVolume")]
			public unsafe static extern float GetOutputVolume(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetSelfDeafAll")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetSelfDeafAll(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetSelfMuteAll")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetSelfMuteAll(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetAecDump")]
			public unsafe static extern void SetAecDump(Client* self, bool on);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetAutomaticGainControl")]
			public unsafe static extern void SetAutomaticGainControl(Client* self, bool on);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetDeviceChangeCallback")]
			public unsafe static extern void SetDeviceChangeCallback(Client* self, DeviceChangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetEchoCancellation")]
			public unsafe static extern void SetEchoCancellation(Client* self, bool on);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetEngineManagedAudioSession")]
			public unsafe static extern void SetEngineManagedAudioSession(Client* self, bool isEngineManaged);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetInputDevice")]
			public unsafe static extern void SetInputDevice(Client* self, Discord_String deviceId, SetInputDeviceCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetInputVolume")]
			public unsafe static extern void SetInputVolume(Client* self, float inputVolume);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetNoAudioInputCallback")]
			public unsafe static extern void SetNoAudioInputCallback(Client* self, NoAudioInputCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetNoAudioInputThreshold")]
			public unsafe static extern void SetNoAudioInputThreshold(Client* self, float dBFSThreshold);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetNoiseSuppression")]
			public unsafe static extern void SetNoiseSuppression(Client* self, bool on);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetOpusHardwareCoding")]
			public unsafe static extern void SetOpusHardwareCoding(Client* self, bool encode, bool decode);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetOutputDevice")]
			public unsafe static extern void SetOutputDevice(Client* self, Discord_String deviceId, SetOutputDeviceCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetOutputVolume")]
			public unsafe static extern void SetOutputVolume(Client* self, float outputVolume);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetSelfDeafAll")]
			public unsafe static extern void SetSelfDeafAll(Client* self, bool deaf);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetSelfMuteAll")]
			public unsafe static extern void SetSelfMuteAll(Client* self, bool mute);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetSpeakerMode")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SetSpeakerMode(Client* self, bool speakerMode);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetThreadPriority")]
			public unsafe static extern void SetThreadPriority(Client* self, Discord.Sdk.Client.Thread thread, int priority);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetVoiceParticipantChangedCallback")]
			public unsafe static extern void SetVoiceParticipantChangedCallback(Client* self, VoiceParticipantChangedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_ShowAudioRoutePicker")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool ShowAudioRoutePicker(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_StartCall")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool StartCall(Client* self, ulong channelId, Call* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_StartCallWithAudioCallbacks")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool StartCallWithAudioCallbacks(Client* self, ulong lobbyId, UserAudioReceivedCallback receivedCb, void* receivedCb__userDataFree, void* receivedCb__userData, UserAudioCapturedCallback capturedCb, void* capturedCb__userDataFree, void* capturedCb__userData, Call* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AbortAuthorize")]
			public unsafe static extern void AbortAuthorize(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AbortGetTokenFromDevice")]
			public unsafe static extern void AbortGetTokenFromDevice(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_Authorize")]
			public unsafe static extern void Authorize(Client* self, AuthorizationArgs* args, AuthorizationCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CloseAuthorizeDeviceScreen")]
			public unsafe static extern void CloseAuthorizeDeviceScreen(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CreateAuthorizationCodeVerifier")]
			public unsafe static extern void CreateAuthorizationCodeVerifier(Client* self, AuthorizationCodeVerifier* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_ExchangeChildToken")]
			public unsafe static extern void ExchangeChildToken(Client* self, Discord_String parentApplicationToken, ulong childApplicationId, ExchangeChildTokenCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_FetchCurrentUser")]
			public unsafe static extern void FetchCurrentUser(Client* self, AuthorizationTokenType tokenType, Discord_String token, FetchCurrentUserCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetProvisionalToken")]
			public unsafe static extern void GetProvisionalToken(Client* self, ulong applicationId, AuthenticationExternalAuthType externalAuthType, Discord_String externalAuthToken, TokenExchangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetToken")]
			public unsafe static extern void GetToken(Client* self, ulong applicationId, Discord_String code, Discord_String codeVerifier, Discord_String redirectUri, TokenExchangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetTokenFromDevice")]
			public unsafe static extern void GetTokenFromDevice(Client* self, DeviceAuthorizationArgs* args, TokenExchangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetTokenFromDeviceProvisionalMerge")]
			public unsafe static extern void GetTokenFromDeviceProvisionalMerge(Client* self, DeviceAuthorizationArgs* args, AuthenticationExternalAuthType externalAuthType, Discord_String externalAuthToken, TokenExchangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetTokenFromProvisionalMerge")]
			public unsafe static extern void GetTokenFromProvisionalMerge(Client* self, ulong applicationId, Discord_String code, Discord_String codeVerifier, Discord_String redirectUri, AuthenticationExternalAuthType externalAuthType, Discord_String externalAuthToken, TokenExchangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_IsAuthenticated")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool IsAuthenticated(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_OpenAuthorizeDeviceScreen")]
			public unsafe static extern void OpenAuthorizeDeviceScreen(Client* self, ulong clientId, Discord_String userCode);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_ProvisionalUserMergeCompleted")]
			public unsafe static extern void ProvisionalUserMergeCompleted(Client* self, bool success);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RefreshToken")]
			public unsafe static extern void RefreshToken(Client* self, ulong applicationId, Discord_String refreshToken, TokenExchangeCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RegisterAuthorizeRequestCallback")]
			public unsafe static extern void RegisterAuthorizeRequestCallback(Client* self, AuthorizeRequestCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RemoveAuthorizeRequestCallback")]
			public unsafe static extern void RemoveAuthorizeRequestCallback(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RevokeToken")]
			public unsafe static extern void RevokeToken(Client* self, ulong applicationId, Discord_String token, RevokeTokenCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetAuthorizeDeviceScreenClosedCallback")]
			public unsafe static extern void SetAuthorizeDeviceScreenClosedCallback(Client* self, AuthorizeDeviceScreenClosedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetGameWindowPid")]
			public unsafe static extern void SetGameWindowPid(Client* self, int pid);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetTokenExpirationCallback")]
			public unsafe static extern void SetTokenExpirationCallback(Client* self, TokenExpirationCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_UnmergeIntoProvisionalAccount")]
			public unsafe static extern void UnmergeIntoProvisionalAccount(Client* self, ulong applicationId, AuthenticationExternalAuthType externalAuthType, Discord_String externalAuthToken, UnmergeIntoProvisionalAccountCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_UpdateProvisionalAccountDisplayName")]
			public unsafe static extern void UpdateProvisionalAccountDisplayName(Client* self, Discord_String name, UpdateProvisionalAccountDisplayNameCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_UpdateToken")]
			public unsafe static extern void UpdateToken(Client* self, AuthorizationTokenType tokenType, Discord_String token, UpdateTokenCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CanOpenMessageInDiscord")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool CanOpenMessageInDiscord(Client* self, ulong messageId);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_DeleteUserMessage")]
			public unsafe static extern void DeleteUserMessage(Client* self, ulong recipientId, ulong messageId, DeleteUserMessageCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_EditUserMessage")]
			public unsafe static extern void EditUserMessage(Client* self, ulong recipientId, ulong messageId, Discord_String content, EditUserMessageCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetChannelHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetChannelHandle(Client* self, ulong channelId, ChannelHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetLobbyMessagesWithLimit")]
			public unsafe static extern void GetLobbyMessagesWithLimit(Client* self, ulong lobbyId, int limit, GetLobbyMessagesCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetMessageHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetMessageHandle(Client* self, ulong messageId, MessageHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetUserMessageSummaries")]
			public unsafe static extern void GetUserMessageSummaries(Client* self, UserMessageSummariesCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetUserMessagesWithLimit")]
			public unsafe static extern void GetUserMessagesWithLimit(Client* self, ulong recipientId, int limit, UserMessagesWithLimitCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_OpenMessageInDiscord")]
			public unsafe static extern void OpenMessageInDiscord(Client* self, ulong messageId, ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback, void* provisionalUserMergeRequiredCallback__userDataFree, void* provisionalUserMergeRequiredCallback__userData, OpenMessageInDiscordCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendLobbyMessage")]
			public unsafe static extern void SendLobbyMessage(Client* self, ulong lobbyId, Discord_String content, SendUserMessageCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendLobbyMessageWithMetadata")]
			public unsafe static extern void SendLobbyMessageWithMetadata(Client* self, ulong lobbyId, Discord_String content, Discord_Properties metadata, SendUserMessageCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendUserMessage")]
			public unsafe static extern void SendUserMessage(Client* self, ulong recipientId, Discord_String content, SendUserMessageCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendUserMessageWithMetadata")]
			public unsafe static extern void SendUserMessageWithMetadata(Client* self, ulong recipientId, Discord_String content, Discord_Properties metadata, SendUserMessageCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetMessageCreatedCallback")]
			public unsafe static extern void SetMessageCreatedCallback(Client* self, MessageCreatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetMessageDeletedCallback")]
			public unsafe static extern void SetMessageDeletedCallback(Client* self, MessageDeletedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetMessageUpdatedCallback")]
			public unsafe static extern void SetMessageUpdatedCallback(Client* self, MessageUpdatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetShowingChat")]
			public unsafe static extern void SetShowingChat(Client* self, bool showingChat);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AddLogCallback")]
			public unsafe static extern void AddLogCallback(Client* self, LogCallback callback, void* callback__userDataFree, void* callback__userData, LoggingSeverity minSeverity);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AddVoiceLogCallback")]
			public unsafe static extern void AddVoiceLogCallback(Client* self, LogCallback callback, void* callback__userDataFree, void* callback__userData, LoggingSeverity minSeverity);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_Connect")]
			public unsafe static extern void Connect(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_Disconnect")]
			public unsafe static extern void Disconnect(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetStatus")]
			public unsafe static extern Discord.Sdk.Client.Status GetStatus(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_OpenConnectedGamesSettingsInDiscord")]
			public unsafe static extern void OpenConnectedGamesSettingsInDiscord(Client* self, OpenConnectedGamesSettingsInDiscordCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetApplicationId")]
			public unsafe static extern void SetApplicationId(Client* self, ulong applicationId);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLogDir")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool SetLogDir(Client* self, Discord_String path, LoggingSeverity minSeverity);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetStatusChangedCallback")]
			public unsafe static extern void SetStatusChangedCallback(Client* self, OnStatusChanged cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetVoiceLogDir")]
			public unsafe static extern void SetVoiceLogDir(Client* self, Discord_String path, LoggingSeverity minSeverity);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CreateOrJoinLobby")]
			public unsafe static extern void CreateOrJoinLobby(Client* self, Discord_String secret, CreateOrJoinLobbyCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CreateOrJoinLobbyWithMetadata")]
			public unsafe static extern void CreateOrJoinLobbyWithMetadata(Client* self, Discord_String secret, Discord_Properties lobbyMetadata, Discord_Properties memberMetadata, CreateOrJoinLobbyCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetGuildChannels")]
			public unsafe static extern void GetGuildChannels(Client* self, ulong guildId, GetGuildChannelsCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetLobbyHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetLobbyHandle(Client* self, ulong lobbyId, LobbyHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetLobbyIds")]
			public unsafe static extern void GetLobbyIds(Client* self, Discord_UInt64Span* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetUserGuilds")]
			public unsafe static extern void GetUserGuilds(Client* self, GetUserGuildsCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_JoinLinkedLobbyGuild")]
			public unsafe static extern void JoinLinkedLobbyGuild(Client* self, ulong lobbyId, ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback, void* provisionalUserMergeRequiredCallback__userDataFree, void* provisionalUserMergeRequiredCallback__userData, JoinLinkedLobbyGuildCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_LeaveLobby")]
			public unsafe static extern void LeaveLobby(Client* self, ulong lobbyId, LeaveLobbyCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_LinkChannelToLobby")]
			public unsafe static extern void LinkChannelToLobby(Client* self, ulong lobbyId, ulong channelId, LinkOrUnlinkChannelCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLobbyCreatedCallback")]
			public unsafe static extern void SetLobbyCreatedCallback(Client* self, LobbyCreatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLobbyDeletedCallback")]
			public unsafe static extern void SetLobbyDeletedCallback(Client* self, LobbyDeletedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLobbyMemberAddedCallback")]
			public unsafe static extern void SetLobbyMemberAddedCallback(Client* self, LobbyMemberAddedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLobbyMemberRemovedCallback")]
			public unsafe static extern void SetLobbyMemberRemovedCallback(Client* self, LobbyMemberRemovedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLobbyMemberUpdatedCallback")]
			public unsafe static extern void SetLobbyMemberUpdatedCallback(Client* self, LobbyMemberUpdatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetLobbyUpdatedCallback")]
			public unsafe static extern void SetLobbyUpdatedCallback(Client* self, LobbyUpdatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_UnlinkChannelFromLobby")]
			public unsafe static extern void UnlinkChannelFromLobby(Client* self, ulong lobbyId, LinkOrUnlinkChannelCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_IsDiscordAppInstalled")]
			public unsafe static extern void IsDiscordAppInstalled(Client* self, IsDiscordAppInstalledCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AcceptActivityInvite")]
			public unsafe static extern void AcceptActivityInvite(Client* self, ActivityInvite* invite, AcceptActivityInviteCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_ClearRichPresence")]
			public unsafe static extern void ClearRichPresence(Client* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RegisterLaunchCommand")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool RegisterLaunchCommand(Client* self, ulong applicationId, Discord_String command);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RegisterLaunchSteamApplication")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool RegisterLaunchSteamApplication(Client* self, ulong applicationId, uint steamAppId);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendActivityInvite")]
			public unsafe static extern void SendActivityInvite(Client* self, ulong userId, Discord_String content, SendActivityInviteCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendActivityJoinRequest")]
			public unsafe static extern void SendActivityJoinRequest(Client* self, ulong userId, SendActivityInviteCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendActivityJoinRequestReply")]
			public unsafe static extern void SendActivityJoinRequestReply(Client* self, ActivityInvite* invite, SendActivityInviteCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetActivityInviteCreatedCallback")]
			public unsafe static extern void SetActivityInviteCreatedCallback(Client* self, ActivityInviteCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetActivityInviteUpdatedCallback")]
			public unsafe static extern void SetActivityInviteUpdatedCallback(Client* self, ActivityInviteCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetActivityJoinCallback")]
			public unsafe static extern void SetActivityJoinCallback(Client* self, ActivityJoinCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetActivityJoinWithApplicationCallback")]
			public unsafe static extern void SetActivityJoinWithApplicationCallback(Client* self, ActivityJoinWithApplicationCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetOnlineStatus")]
			public unsafe static extern void SetOnlineStatus(Client* self, StatusType status, UpdateStatusCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_UpdateRichPresence")]
			public unsafe static extern void UpdateRichPresence(Client* self, Activity* activity, UpdateRichPresenceCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AcceptDiscordFriendRequest")]
			public unsafe static extern void AcceptDiscordFriendRequest(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_AcceptGameFriendRequest")]
			public unsafe static extern void AcceptGameFriendRequest(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_BlockUser")]
			public unsafe static extern void BlockUser(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CancelDiscordFriendRequest")]
			public unsafe static extern void CancelDiscordFriendRequest(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_CancelGameFriendRequest")]
			public unsafe static extern void CancelGameFriendRequest(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetRelationshipHandle")]
			public unsafe static extern void GetRelationshipHandle(Client* self, ulong userId, RelationshipHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetRelationships")]
			public unsafe static extern void GetRelationships(Client* self, Discord_RelationshipHandleSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetRelationshipsByGroup")]
			public unsafe static extern void GetRelationshipsByGroup(Client* self, RelationshipGroupType groupType, Discord_RelationshipHandleSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RejectDiscordFriendRequest")]
			public unsafe static extern void RejectDiscordFriendRequest(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RejectGameFriendRequest")]
			public unsafe static extern void RejectGameFriendRequest(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RemoveDiscordAndGameFriend")]
			public unsafe static extern void RemoveDiscordAndGameFriend(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_RemoveGameFriend")]
			public unsafe static extern void RemoveGameFriend(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SearchFriendsByUsername")]
			public unsafe static extern void SearchFriendsByUsername(Client* self, Discord_String searchStr, Discord_UserHandleSpan* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendDiscordFriendRequest")]
			public unsafe static extern void SendDiscordFriendRequest(Client* self, Discord_String username, SendFriendRequestCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendDiscordFriendRequestById")]
			public unsafe static extern void SendDiscordFriendRequestById(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendGameFriendRequest")]
			public unsafe static extern void SendGameFriendRequest(Client* self, Discord_String username, SendFriendRequestCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SendGameFriendRequestById")]
			public unsafe static extern void SendGameFriendRequestById(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetRelationshipCreatedCallback")]
			public unsafe static extern void SetRelationshipCreatedCallback(Client* self, RelationshipCreatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetRelationshipDeletedCallback")]
			public unsafe static extern void SetRelationshipDeletedCallback(Client* self, RelationshipDeletedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_UnblockUser")]
			public unsafe static extern void UnblockUser(Client* self, ulong userId, UpdateRelationshipCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetCurrentUserV2")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetCurrentUserV2(Client* self, UserHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetDiscordClientConnectedUser")]
			public unsafe static extern void GetDiscordClientConnectedUser(Client* self, ulong applicationId, GetDiscordClientConnectedUserCallback callback, void* callback__userDataFree, void* callback__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_GetUser")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetUser(Client* self, ulong userId, UserHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetRelationshipGroupsUpdatedCallback")]
			public unsafe static extern void SetRelationshipGroupsUpdatedCallback(Client* self, RelationshipGroupsUpdatedCallback cb, void* cb__userDataFree, void* cb__userData);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Client_SetUserUpdatedCallback")]
			public unsafe static extern void SetUserUpdatedCallback(Client* self, UserUpdatedCallback cb, void* cb__userDataFree, void* cb__userData);
		}

		public struct CallInfoHandle
		{
			public IntPtr Handle;

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_CallInfoHandle_Drop")]
			public unsafe static extern void Drop(CallInfoHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_CallInfoHandle_Clone")]
			public unsafe static extern void Clone(CallInfoHandle* self, CallInfoHandle* other);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_CallInfoHandle_ChannelId")]
			public unsafe static extern ulong ChannelId(CallInfoHandle* self);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_CallInfoHandle_GetParticipants")]
			public unsafe static extern void GetParticipants(CallInfoHandle* self, Discord_UInt64Span* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_CallInfoHandle_GetVoiceStateHandle")]
			[return: MarshalAs(UnmanagedType.U1)]
			public unsafe static extern bool GetVoiceStateHandle(CallInfoHandle* self, ulong userId, VoiceStateHandle* returnValue);

			[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_CallInfoHandle_GuildId")]
			public unsafe static extern ulong GuildId(CallInfoHandle* self);
		}

		public const string LibraryName = "discord_partner_sdk";

		public static event Action<Exception>? UnhandledException;

		static NativeMethods()
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			List<PlayerLoopSystem> list = currentPlayerLoop.subSystemList.ToList();
			PlayerLoopSystem item = new PlayerLoopSystem
			{
				type = typeof(NativeMethods),
				updateDelegate = Discord_RunCallbacks
			};
			list.Insert(0, item);
			currentPlayerLoop.subSystemList = list.ToArray();
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
			Discord_ResetCallbacks();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void __Init()
		{
		}

		public static void __ReportUnhandledException(Exception ex)
		{
			Action<Exception> unhandledException = NativeMethods.UnhandledException;
			if (unhandledException != null)
			{
				unhandledException(ex);
			}
			else
			{
				Debug.LogException(ex);
			}
		}

		public static void __OnPostConstruct(object obj)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void __InitString(Discord_String* str, string value)
		{
			str->ptr = (byte*)(void*)Marshal.StringToCoTaskMemUTF8(value);
			str->size = (UIntPtr)(ulong)Encoding.UTF8.GetByteCount(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void __FreeString(Discord_String* str)
		{
			Marshal.FreeCoTaskMem((IntPtr)str->ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool __InitStringLocal(byte* buf, int* bufUsed, int bufCapacity, Discord_String* str, string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			int num = (byteCount + 7) & -8;
			if (*bufUsed + num > bufCapacity)
			{
				str->ptr = (byte*)(void*)Marshal.StringToCoTaskMemUTF8(value);
				str->size = (UIntPtr)(ulong)byteCount;
				return true;
			}
			Span<byte> bytes = new Span<byte>(buf + *bufUsed, bufCapacity - *bufUsed);
			Encoding.UTF8.GetBytes(value, bytes);
			str->ptr = buf + *bufUsed;
			*bufUsed += num;
			str->size = (UIntPtr)(ulong)byteCount;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool __InitNullableStringLocal(byte* buf, int* bufUsed, int bufCapacity, Discord_String* str, string? value)
		{
			if (value == null)
			{
				str->ptr = null;
				str->size = UIntPtr.Zero;
				return false;
			}
			return __InitStringLocal(buf, bufUsed, bufCapacity, str, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool __AllocLocal(byte* buf, int* bufUsed, int bufCapacity, void** ptrOut, int size)
		{
			int num = (size + 7) & -8;
			if (*bufUsed + num > bufCapacity)
			{
				*ptrOut = (void*)Marshal.AllocCoTaskMem(size);
				return true;
			}
			*ptrOut = buf + *bufUsed + (num - size);
			*bufUsed += num;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool __AllocLocalStringArray(byte* buf, int* bufUsed, int bufCapacity, Discord_String** ptrOut, int count)
		{
			void* ptr = default(void*);
			bool result = __AllocLocal(buf, bufUsed, bufCapacity, &ptr, count * sizeof(Discord_String));
			*ptrOut = (Discord_String*)ptr;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static bool __AllocateLocalBoolArray(byte* buf, int* bufUsed, int bufCapacity, bool** ptrOut, int count)
		{
			void* ptr = default(void*);
			bool result = __AllocLocal(buf, bufUsed, bufCapacity, &ptr, count);
			*ptrOut = (bool*)ptr;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void __FreeLocalString(Discord_String* str, bool owned)
		{
			if (owned)
			{
				Marshal.FreeCoTaskMem((IntPtr)str->ptr);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void __FreeLocal(void* ptr, bool owned)
		{
			if (owned)
			{
				Marshal.FreeCoTaskMem((IntPtr)ptr);
			}
		}

		[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void* Discord_Alloc(UIntPtr size);

		[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Discord_Free(void* ptr);

		[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Discord_FreeProperties(Discord_Properties props);

		[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Discord_SetFreeThreaded();

		[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Discord_RunCallbacks();

		[DllImport("discord_partner_sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Discord_ResetCallbacks();
	}
}
