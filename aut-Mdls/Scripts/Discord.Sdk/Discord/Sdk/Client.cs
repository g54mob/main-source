using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class Client : IDisposable
	{
		public enum Error
		{
			None = 0,
			ConnectionFailed = 1,
			UnexpectedClose = 2,
			ConnectionCanceled = 3
		}

		public enum Status
		{
			Disconnected = 0,
			Connecting = 1,
			Connected = 2,
			Ready = 3,
			Reconnecting = 4,
			Disconnecting = 5,
			HttpWait = 6
		}

		public enum Thread
		{
			Client = 0,
			Voice = 1,
			Network = 2
		}

		public delegate void EndCallCallback();

		public delegate void EndCallsCallback();

		public delegate void GetCurrentInputDeviceCallback(AudioDevice device);

		public delegate void GetCurrentOutputDeviceCallback(AudioDevice device);

		public delegate void GetInputDevicesCallback(AudioDevice[] devices);

		public delegate void GetOutputDevicesCallback(AudioDevice[] devices);

		public delegate void DeviceChangeCallback(AudioDevice[] inputDevices, AudioDevice[] outputDevices);

		public delegate void SetInputDeviceCallback(ClientResult result);

		public delegate void NoAudioInputCallback(bool inputDetected);

		public delegate void SetOutputDeviceCallback(ClientResult result);

		public delegate void VoiceParticipantChangedCallback(ulong lobbyId, ulong memberId, bool added);

		public delegate void UserAudioReceivedCallback(ulong userId, IntPtr data, ulong samplesPerChannel, int sampleRate, ulong channels, ref bool outShouldMute);

		public delegate void UserAudioCapturedCallback(IntPtr data, ulong samplesPerChannel, int sampleRate, ulong channels);

		public delegate void AuthorizationCallback(ClientResult result, string code, string redirectUri);

		public delegate void ExchangeChildTokenCallback(ClientResult result, string accessToken, AuthorizationTokenType tokenType, int expiresIn, string scopes);

		public delegate void FetchCurrentUserCallback(ClientResult result, ulong id, string name);

		public delegate void TokenExchangeCallback(ClientResult result, string accessToken, string refreshToken, AuthorizationTokenType tokenType, int expiresIn, string scopes);

		public delegate void AuthorizeRequestCallback();

		public delegate void RevokeTokenCallback(ClientResult result);

		public delegate void AuthorizeDeviceScreenClosedCallback();

		public delegate void TokenExpirationCallback();

		public delegate void UnmergeIntoProvisionalAccountCallback(ClientResult result);

		public delegate void UpdateProvisionalAccountDisplayNameCallback(ClientResult result);

		public delegate void UpdateTokenCallback(ClientResult result);

		public delegate void DeleteUserMessageCallback(ClientResult result);

		public delegate void EditUserMessageCallback(ClientResult result);

		public delegate void GetLobbyMessagesCallback(ClientResult result, MessageHandle[] messages);

		public delegate void UserMessageSummariesCallback(ClientResult result, UserMessageSummary[] summaries);

		public delegate void UserMessagesWithLimitCallback(ClientResult result, MessageHandle[] messages);

		public delegate void ProvisionalUserMergeRequiredCallback();

		public delegate void OpenMessageInDiscordCallback(ClientResult result);

		public delegate void SendUserMessageCallback(ClientResult result, ulong messageId);

		public delegate void MessageCreatedCallback(ulong messageId);

		public delegate void MessageDeletedCallback(ulong messageId, ulong channelId);

		public delegate void MessageUpdatedCallback(ulong messageId);

		public delegate void LogCallback(string message, LoggingSeverity severity);

		public delegate void OpenConnectedGamesSettingsInDiscordCallback(ClientResult result);

		public delegate void OnStatusChanged(Status status, Error error, int errorDetail);

		public delegate void CreateOrJoinLobbyCallback(ClientResult result, ulong lobbyId);

		public delegate void GetGuildChannelsCallback(ClientResult result, GuildChannel[] guildChannels);

		public delegate void GetUserGuildsCallback(ClientResult result, GuildMinimal[] guilds);

		public delegate void JoinLinkedLobbyGuildCallback(ClientResult result, string inviteUrl);

		public delegate void LeaveLobbyCallback(ClientResult result);

		public delegate void LinkOrUnlinkChannelCallback(ClientResult result);

		public delegate void LobbyCreatedCallback(ulong lobbyId);

		public delegate void LobbyDeletedCallback(ulong lobbyId);

		public delegate void LobbyMemberAddedCallback(ulong lobbyId, ulong memberId);

		public delegate void LobbyMemberRemovedCallback(ulong lobbyId, ulong memberId);

		public delegate void LobbyMemberUpdatedCallback(ulong lobbyId, ulong memberId);

		public delegate void LobbyUpdatedCallback(ulong lobbyId);

		public delegate void AcceptActivityInviteCallback(ClientResult result, string joinSecret);

		public delegate void SendActivityInviteCallback(ClientResult result);

		public delegate void ActivityInviteCallback(ActivityInvite invite);

		public delegate void ActivityJoinCallback(string joinSecret);

		public delegate void ActivityJoinWithApplicationCallback(ulong applicationId, string joinSecret);

		public delegate void UpdateStatusCallback(ClientResult result);

		public delegate void UpdateRichPresenceCallback(ClientResult result);

		public delegate void UpdateRelationshipCallback(ClientResult result);

		public delegate void SendFriendRequestCallback(ClientResult result);

		public delegate void RelationshipCreatedCallback(ulong userId, bool isDiscordRelationshipUpdate);

		public delegate void RelationshipDeletedCallback(ulong userId, bool isDiscordRelationshipUpdate);

		public delegate void GetDiscordClientConnectedUserCallback(ClientResult result, UserHandle? user);

		public delegate void RelationshipGroupsUpdatedCallback(ulong userId);

		public delegate void UserUpdatedCallback(ulong userId);

		internal NativeMethods.Client self;

		private int disposed_;

		internal Client(NativeMethods.Client self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~Client()
		{
			Dispose();
		}

		public unsafe Client()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe Client(string apiBase, string webBase)
		{
			NativeMethods.__Init();
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String apiBase2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &apiBase2, apiBase);
			NativeMethods.Discord_String webBase2 = default(NativeMethods.Discord_String);
			bool owned2 = NativeMethods.__InitStringLocal(buf, &num, 1024, &webBase2, webBase);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.InitWithBases(ptr, apiBase2, webBase2);
			}
			NativeMethods.__FreeLocalString(&webBase2, owned2);
			NativeMethods.__FreeLocalString(&apiBase2, owned);
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe Client(ClientCreateOptions options)
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ClientCreateOptions* options2 = &options.self)
			{
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.InitWithOptions(ptr, options2);
				}
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.Drop(ptr);
				}
			}
		}

		public unsafe static string ErrorToString(Error type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.ErrorToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe ulong GetApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			ulong applicationId;
			fixed (NativeMethods.Client* ptr = &self)
			{
				applicationId = NativeMethods.Client.GetApplicationId(ptr);
			}
			return applicationId;
		}

		[Obsolete("Please use GetCurrentUserV2 instead. This will be removed in a future version.")]
		public unsafe UserHandle GetCurrentUser()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetCurrentUser(ptr, &userHandle);
			}
			return new UserHandle(userHandle, 0);
		}

		public unsafe static string GetDefaultAudioDeviceId()
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.GetDefaultAudioDeviceId(&discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe static string GetDefaultCommunicationScopes()
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.GetDefaultCommunicationScopes(&discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe static string GetDefaultPresenceScopes()
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.GetDefaultPresenceScopes(&discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe static string GetVersionHash()
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.GetVersionHash(&discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public static int GetVersionMajor()
		{
			return NativeMethods.Client.GetVersionMajor();
		}

		public static int GetVersionMinor()
		{
			return NativeMethods.Client.GetVersionMinor();
		}

		public static int GetVersionPatch()
		{
			return NativeMethods.Client.GetVersionPatch();
		}

		public unsafe void SetHttpRequestTimeout(int httpTimeoutInMilliseconds)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetHttpRequestTimeout(ptr, httpTimeoutInMilliseconds);
			}
		}

		public unsafe static string StatusToString(Status type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.StatusToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe static string ThreadToString(Thread type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Client.ThreadToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void EndCall(ulong channelId, EndCallCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.EndCallCallback callback2 = NativeMethods.Client.EndCallCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.EndCall(ptr, channelId, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void EndCalls(EndCallsCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.EndCallsCallback callback2 = NativeMethods.Client.EndCallsCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.EndCalls(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe Call? GetCall(ulong channelId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Call call = default(NativeMethods.Call);
			bool call2;
			fixed (NativeMethods.Client* ptr = &self)
			{
				call2 = NativeMethods.Client.GetCall(ptr, channelId, &call);
			}
			if (!call2)
			{
				return null;
			}
			return new Call(call, 0);
		}

		public unsafe Call?[] GetCalls()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Discord_CallSpan discord_CallSpan = default(NativeMethods.Discord_CallSpan);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetCalls(ptr, &discord_CallSpan);
			}
			Call[] array = new Call[(uint)discord_CallSpan.size];
			for (int i = 0; i < (int)(uint)discord_CallSpan.size; i++)
			{
				array[i] = new Call(discord_CallSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_CallSpan.ptr);
			return array;
		}

		public unsafe void GetCurrentInputDevice(GetCurrentInputDeviceCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetCurrentInputDeviceCallback cb2 = NativeMethods.Client.GetCurrentInputDeviceCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetCurrentInputDevice(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void GetCurrentOutputDevice(GetCurrentOutputDeviceCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetCurrentOutputDeviceCallback cb2 = NativeMethods.Client.GetCurrentOutputDeviceCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetCurrentOutputDevice(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void GetInputDevices(GetInputDevicesCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetInputDevicesCallback cb2 = NativeMethods.Client.GetInputDevicesCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetInputDevices(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe float GetInputVolume()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			float inputVolume;
			fixed (NativeMethods.Client* ptr = &self)
			{
				inputVolume = NativeMethods.Client.GetInputVolume(ptr);
			}
			return inputVolume;
		}

		public unsafe void GetOutputDevices(GetOutputDevicesCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetOutputDevicesCallback cb2 = NativeMethods.Client.GetOutputDevicesCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetOutputDevices(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe float GetOutputVolume()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			float outputVolume;
			fixed (NativeMethods.Client* ptr = &self)
			{
				outputVolume = NativeMethods.Client.GetOutputVolume(ptr);
			}
			return outputVolume;
		}

		public unsafe bool GetSelfDeafAll()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool selfDeafAll;
			fixed (NativeMethods.Client* ptr = &self)
			{
				selfDeafAll = NativeMethods.Client.GetSelfDeafAll(ptr);
			}
			return selfDeafAll;
		}

		public unsafe bool GetSelfMuteAll()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool selfMuteAll;
			fixed (NativeMethods.Client* ptr = &self)
			{
				selfMuteAll = NativeMethods.Client.GetSelfMuteAll(ptr);
			}
			return selfMuteAll;
		}

		public unsafe void SetAecDump(bool on)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetAecDump(ptr, on);
			}
		}

		public unsafe void SetAutomaticGainControl(bool on)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetAutomaticGainControl(ptr, on);
			}
		}

		public unsafe void SetDeviceChangeCallback(DeviceChangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.DeviceChangeCallback callback2 = NativeMethods.Client.DeviceChangeCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetDeviceChangeCallback(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void SetEchoCancellation(bool on)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetEchoCancellation(ptr, on);
			}
		}

		public unsafe void SetEngineManagedAudioSession(bool isEngineManaged)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetEngineManagedAudioSession(ptr, isEngineManaged);
			}
		}

		public unsafe void SetInputDevice(string deviceId, SetInputDeviceCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String deviceId2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &deviceId2, deviceId);
			NativeMethods.Client.SetInputDeviceCallback cb2 = NativeMethods.Client.SetInputDeviceCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetInputDevice(ptr, deviceId2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&deviceId2, owned);
		}

		public unsafe void SetInputVolume(float inputVolume)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetInputVolume(ptr, inputVolume);
			}
		}

		public unsafe void SetNoAudioInputCallback(NoAudioInputCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.NoAudioInputCallback callback2 = NativeMethods.Client.NoAudioInputCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetNoAudioInputCallback(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void SetNoAudioInputThreshold(float dBFSThreshold)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetNoAudioInputThreshold(ptr, dBFSThreshold);
			}
		}

		public unsafe void SetNoiseSuppression(bool on)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetNoiseSuppression(ptr, on);
			}
		}

		public unsafe void SetOpusHardwareCoding(bool encode, bool decode)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetOpusHardwareCoding(ptr, encode, decode);
			}
		}

		public unsafe void SetOutputDevice(string deviceId, SetOutputDeviceCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String deviceId2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &deviceId2, deviceId);
			NativeMethods.Client.SetOutputDeviceCallback cb2 = NativeMethods.Client.SetOutputDeviceCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetOutputDevice(ptr, deviceId2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&deviceId2, owned);
		}

		public unsafe void SetOutputVolume(float outputVolume)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetOutputVolume(ptr, outputVolume);
			}
		}

		public unsafe void SetSelfDeafAll(bool deaf)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetSelfDeafAll(ptr, deaf);
			}
		}

		public unsafe void SetSelfMuteAll(bool mute)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetSelfMuteAll(ptr, mute);
			}
		}

		[Obsolete("Calling Client::SetSpeakerMode is DEPRECATED.")]
		public unsafe bool SetSpeakerMode(bool speakerMode)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.SetSpeakerMode(ptr, speakerMode);
			}
			return result;
		}

		public unsafe void SetThreadPriority(Thread thread, int priority)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetThreadPriority(ptr, thread, priority);
			}
		}

		public unsafe void SetVoiceParticipantChangedCallback(VoiceParticipantChangedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.VoiceParticipantChangedCallback cb2 = NativeMethods.Client.VoiceParticipantChangedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetVoiceParticipantChangedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe bool ShowAudioRoutePicker()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.ShowAudioRoutePicker(ptr);
			}
			return result;
		}

		public unsafe Call? StartCall(ulong channelId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Call call = default(NativeMethods.Call);
			bool num;
			fixed (NativeMethods.Client* ptr = &self)
			{
				num = NativeMethods.Client.StartCall(ptr, channelId, &call);
			}
			if (!num)
			{
				return null;
			}
			return new Call(call, 0);
		}

		public unsafe Call? StartCallWithAudioCallbacks(ulong lobbyId, UserAudioReceivedCallback receivedCb, UserAudioCapturedCallback capturedCb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Call call = default(NativeMethods.Call);
			NativeMethods.Client.UserAudioReceivedCallback receivedCb2 = NativeMethods.Client.UserAudioReceivedCallback_Handler;
			NativeMethods.Client.UserAudioCapturedCallback capturedCb2 = NativeMethods.Client.UserAudioCapturedCallback_Handler;
			bool num;
			fixed (NativeMethods.Client* ptr = &self)
			{
				num = NativeMethods.Client.StartCallWithAudioCallbacks(ptr, lobbyId, receivedCb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(receivedCb), capturedCb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(capturedCb), &call);
			}
			if (!num)
			{
				return null;
			}
			return new Call(call, 0);
		}

		public unsafe void AbortAuthorize()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.AbortAuthorize(ptr);
			}
		}

		public unsafe void AbortGetTokenFromDevice()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.AbortGetTokenFromDevice(ptr);
			}
		}

		public unsafe void Authorize(AuthorizationArgs args, AuthorizationCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.AuthorizationArgs* args2 = &args.self)
			{
				NativeMethods.Client.AuthorizationCallback callback2 = NativeMethods.Client.AuthorizationCallback_Handler;
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.Authorize(ptr, args2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
				}
			}
		}

		public unsafe void CloseAuthorizeDeviceScreen()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.CloseAuthorizeDeviceScreen(ptr);
			}
		}

		public unsafe AuthorizationCodeVerifier CreateAuthorizationCodeVerifier()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.AuthorizationCodeVerifier authorizationCodeVerifier = default(NativeMethods.AuthorizationCodeVerifier);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.CreateAuthorizationCodeVerifier(ptr, &authorizationCodeVerifier);
			}
			return new AuthorizationCodeVerifier(authorizationCodeVerifier, 0);
		}

		public unsafe void ExchangeChildToken(string parentApplicationToken, ulong childApplicationId, ExchangeChildTokenCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String parentApplicationToken2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &parentApplicationToken2, parentApplicationToken);
			NativeMethods.Client.ExchangeChildTokenCallback callback2 = NativeMethods.Client.ExchangeChildTokenCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.ExchangeChildToken(ptr, parentApplicationToken2, childApplicationId, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&parentApplicationToken2, owned);
		}

		public unsafe void FetchCurrentUser(AuthorizationTokenType tokenType, string token, FetchCurrentUserCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String token2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &token2, token);
			NativeMethods.Client.FetchCurrentUserCallback callback2 = NativeMethods.Client.FetchCurrentUserCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.FetchCurrentUser(ptr, tokenType, token2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&token2, owned);
		}

		public unsafe void GetProvisionalToken(ulong applicationId, AuthenticationExternalAuthType externalAuthType, string externalAuthToken, TokenExchangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String externalAuthToken2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &externalAuthToken2, externalAuthToken);
			NativeMethods.Client.TokenExchangeCallback callback2 = NativeMethods.Client.TokenExchangeCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetProvisionalToken(ptr, applicationId, externalAuthType, externalAuthToken2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&externalAuthToken2, owned);
		}

		public unsafe void GetToken(ulong applicationId, string code, string codeVerifier, string redirectUri, TokenExchangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String code2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &code2, code);
			NativeMethods.Discord_String codeVerifier2 = default(NativeMethods.Discord_String);
			bool owned2 = NativeMethods.__InitStringLocal(buf, &num, 1024, &codeVerifier2, codeVerifier);
			NativeMethods.Discord_String redirectUri2 = default(NativeMethods.Discord_String);
			bool owned3 = NativeMethods.__InitStringLocal(buf, &num, 1024, &redirectUri2, redirectUri);
			NativeMethods.Client.TokenExchangeCallback callback2 = NativeMethods.Client.TokenExchangeCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetToken(ptr, applicationId, code2, codeVerifier2, redirectUri2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&redirectUri2, owned3);
			NativeMethods.__FreeLocalString(&codeVerifier2, owned2);
			NativeMethods.__FreeLocalString(&code2, owned);
		}

		public unsafe void GetTokenFromDevice(DeviceAuthorizationArgs args, TokenExchangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.DeviceAuthorizationArgs* args2 = &args.self)
			{
				NativeMethods.Client.TokenExchangeCallback callback2 = NativeMethods.Client.TokenExchangeCallback_Handler;
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.GetTokenFromDevice(ptr, args2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
				}
			}
		}

		public unsafe void GetTokenFromDeviceProvisionalMerge(DeviceAuthorizationArgs args, AuthenticationExternalAuthType externalAuthType, string externalAuthToken, TokenExchangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.DeviceAuthorizationArgs* args2 = &args.self)
			{
				byte* buf = stackalloc byte[1024];
				int num = 0;
				NativeMethods.Discord_String externalAuthToken2 = default(NativeMethods.Discord_String);
				bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &externalAuthToken2, externalAuthToken);
				NativeMethods.Client.TokenExchangeCallback callback2 = NativeMethods.Client.TokenExchangeCallback_Handler;
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.GetTokenFromDeviceProvisionalMerge(ptr, args2, externalAuthType, externalAuthToken2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
				}
				NativeMethods.__FreeLocalString(&externalAuthToken2, owned);
			}
		}

		public unsafe void GetTokenFromProvisionalMerge(ulong applicationId, string code, string codeVerifier, string redirectUri, AuthenticationExternalAuthType externalAuthType, string externalAuthToken, TokenExchangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String code2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &code2, code);
			NativeMethods.Discord_String codeVerifier2 = default(NativeMethods.Discord_String);
			bool owned2 = NativeMethods.__InitStringLocal(buf, &num, 1024, &codeVerifier2, codeVerifier);
			NativeMethods.Discord_String redirectUri2 = default(NativeMethods.Discord_String);
			bool owned3 = NativeMethods.__InitStringLocal(buf, &num, 1024, &redirectUri2, redirectUri);
			NativeMethods.Discord_String externalAuthToken2 = default(NativeMethods.Discord_String);
			bool owned4 = NativeMethods.__InitStringLocal(buf, &num, 1024, &externalAuthToken2, externalAuthToken);
			NativeMethods.Client.TokenExchangeCallback callback2 = NativeMethods.Client.TokenExchangeCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetTokenFromProvisionalMerge(ptr, applicationId, code2, codeVerifier2, redirectUri2, externalAuthType, externalAuthToken2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&externalAuthToken2, owned4);
			NativeMethods.__FreeLocalString(&redirectUri2, owned3);
			NativeMethods.__FreeLocalString(&codeVerifier2, owned2);
			NativeMethods.__FreeLocalString(&code2, owned);
		}

		public unsafe bool IsAuthenticated()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.IsAuthenticated(ptr);
			}
			return result;
		}

		public unsafe void OpenAuthorizeDeviceScreen(ulong clientId, string userCode)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String userCode2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &userCode2, userCode);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.OpenAuthorizeDeviceScreen(ptr, clientId, userCode2);
			}
			NativeMethods.__FreeLocalString(&userCode2, owned);
		}

		public unsafe void ProvisionalUserMergeCompleted(bool success)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.ProvisionalUserMergeCompleted(ptr, success);
			}
		}

		public unsafe void RefreshToken(ulong applicationId, string refreshToken, TokenExchangeCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String refreshToken2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &refreshToken2, refreshToken);
			NativeMethods.Client.TokenExchangeCallback callback2 = NativeMethods.Client.TokenExchangeCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RefreshToken(ptr, applicationId, refreshToken2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&refreshToken2, owned);
		}

		public unsafe void RegisterAuthorizeRequestCallback(AuthorizeRequestCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.AuthorizeRequestCallback callback2 = NativeMethods.Client.AuthorizeRequestCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RegisterAuthorizeRequestCallback(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void RemoveAuthorizeRequestCallback()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RemoveAuthorizeRequestCallback(ptr);
			}
		}

		public unsafe void RevokeToken(ulong applicationId, string token, RevokeTokenCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String token2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &token2, token);
			NativeMethods.Client.RevokeTokenCallback callback2 = NativeMethods.Client.RevokeTokenCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RevokeToken(ptr, applicationId, token2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&token2, owned);
		}

		public unsafe void SetAuthorizeDeviceScreenClosedCallback(AuthorizeDeviceScreenClosedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.AuthorizeDeviceScreenClosedCallback cb2 = NativeMethods.Client.AuthorizeDeviceScreenClosedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetAuthorizeDeviceScreenClosedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetGameWindowPid(int pid)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetGameWindowPid(ptr, pid);
			}
		}

		public unsafe void SetTokenExpirationCallback(TokenExpirationCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.TokenExpirationCallback callback2 = NativeMethods.Client.TokenExpirationCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetTokenExpirationCallback(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void UnmergeIntoProvisionalAccount(ulong applicationId, AuthenticationExternalAuthType externalAuthType, string externalAuthToken, UnmergeIntoProvisionalAccountCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String externalAuthToken2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &externalAuthToken2, externalAuthToken);
			NativeMethods.Client.UnmergeIntoProvisionalAccountCallback callback2 = NativeMethods.Client.UnmergeIntoProvisionalAccountCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.UnmergeIntoProvisionalAccount(ptr, applicationId, externalAuthType, externalAuthToken2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&externalAuthToken2, owned);
		}

		public unsafe void UpdateProvisionalAccountDisplayName(string name, UpdateProvisionalAccountDisplayNameCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String name2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &name2, name);
			NativeMethods.Client.UpdateProvisionalAccountDisplayNameCallback callback2 = NativeMethods.Client.UpdateProvisionalAccountDisplayNameCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.UpdateProvisionalAccountDisplayName(ptr, name2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&name2, owned);
		}

		public unsafe void UpdateToken(AuthorizationTokenType tokenType, string token, UpdateTokenCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String token2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &token2, token);
			NativeMethods.Client.UpdateTokenCallback callback2 = NativeMethods.Client.UpdateTokenCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.UpdateToken(ptr, tokenType, token2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&token2, owned);
		}

		public unsafe bool CanOpenMessageInDiscord(ulong messageId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.CanOpenMessageInDiscord(ptr, messageId);
			}
			return result;
		}

		public unsafe void DeleteUserMessage(ulong recipientId, ulong messageId, DeleteUserMessageCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.DeleteUserMessageCallback cb2 = NativeMethods.Client.DeleteUserMessageCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.DeleteUserMessage(ptr, recipientId, messageId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void EditUserMessage(ulong recipientId, ulong messageId, string content, EditUserMessageCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String content2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &content2, content);
			NativeMethods.Client.EditUserMessageCallback cb2 = NativeMethods.Client.EditUserMessageCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.EditUserMessage(ptr, recipientId, messageId, content2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&content2, owned);
		}

		public unsafe ChannelHandle? GetChannelHandle(ulong channelId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.ChannelHandle channelHandle = default(NativeMethods.ChannelHandle);
			bool channelHandle2;
			fixed (NativeMethods.Client* ptr = &self)
			{
				channelHandle2 = NativeMethods.Client.GetChannelHandle(ptr, channelId, &channelHandle);
			}
			if (!channelHandle2)
			{
				return null;
			}
			return new ChannelHandle(channelHandle, 0);
		}

		public unsafe void GetLobbyMessagesWithLimit(ulong lobbyId, int limit, GetLobbyMessagesCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetLobbyMessagesCallback cb2 = NativeMethods.Client.GetLobbyMessagesCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetLobbyMessagesWithLimit(ptr, lobbyId, limit, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe MessageHandle? GetMessageHandle(ulong messageId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.MessageHandle messageHandle = default(NativeMethods.MessageHandle);
			bool messageHandle2;
			fixed (NativeMethods.Client* ptr = &self)
			{
				messageHandle2 = NativeMethods.Client.GetMessageHandle(ptr, messageId, &messageHandle);
			}
			if (!messageHandle2)
			{
				return null;
			}
			return new MessageHandle(messageHandle, 0);
		}

		public unsafe void GetUserMessageSummaries(UserMessageSummariesCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UserMessageSummariesCallback cb2 = NativeMethods.Client.UserMessageSummariesCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetUserMessageSummaries(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void GetUserMessagesWithLimit(ulong recipientId, int limit, UserMessagesWithLimitCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UserMessagesWithLimitCallback cb2 = NativeMethods.Client.UserMessagesWithLimitCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetUserMessagesWithLimit(ptr, recipientId, limit, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void OpenMessageInDiscord(ulong messageId, ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback, OpenMessageInDiscordCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback2 = NativeMethods.Client.ProvisionalUserMergeRequiredCallback_Handler;
			NativeMethods.Client.OpenMessageInDiscordCallback callback2 = NativeMethods.Client.OpenMessageInDiscordCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.OpenMessageInDiscord(ptr, messageId, provisionalUserMergeRequiredCallback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(provisionalUserMergeRequiredCallback), callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void SendLobbyMessage(ulong lobbyId, string content, SendUserMessageCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String content2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &content2, content);
			NativeMethods.Client.SendUserMessageCallback cb2 = NativeMethods.Client.SendUserMessageCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendLobbyMessage(ptr, lobbyId, content2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&content2, owned);
		}

		public unsafe void SendLobbyMessageWithMetadata(ulong lobbyId, string content, Dictionary<string, string> metadata, SendUserMessageCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String content2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &content2, content);
			NativeMethods.Discord_Properties metadata2 = default(NativeMethods.Discord_Properties);
			metadata2.size = (IntPtr)metadata.Count;
			NativeMethods.Discord_String* ptr = default(NativeMethods.Discord_String*);
			bool owned2 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr, metadata.Count);
			NativeMethods.Discord_String* ptr2 = default(NativeMethods.Discord_String*);
			bool owned3 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr2, metadata.Count);
			bool* ptr3 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr3, metadata.Count);
			bool* ptr4 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr4, metadata.Count);
			int num2 = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Discord_String discord_String2 = default(NativeMethods.Discord_String);
			foreach (var (value, value2) in metadata)
			{
				ptr3[num2] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String, value);
				ptr4[num2] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String2, value2);
				ptr[num2] = discord_String;
				ptr2[num2] = discord_String2;
				num2++;
			}
			metadata2.keys = ptr;
			metadata2.values = ptr2;
			NativeMethods.Client.SendUserMessageCallback cb2 = NativeMethods.Client.SendUserMessageCallback_Handler;
			fixed (NativeMethods.Client* ptr5 = &self)
			{
				NativeMethods.Client.SendLobbyMessageWithMetadata(ptr5, lobbyId, content2, metadata2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			for (int i = 0; i < (int)metadata2.size; i++)
			{
				NativeMethods.__FreeLocalString(ptr + i, ptr3[i]);
				NativeMethods.__FreeLocalString(ptr2 + i, ptr4[i]);
			}
			NativeMethods.__FreeLocal(ptr, owned2);
			NativeMethods.__FreeLocal(ptr2, owned3);
			NativeMethods.__FreeLocalString(&content2, owned);
		}

		public unsafe void SendUserMessage(ulong recipientId, string content, SendUserMessageCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String content2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &content2, content);
			NativeMethods.Client.SendUserMessageCallback cb2 = NativeMethods.Client.SendUserMessageCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendUserMessage(ptr, recipientId, content2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&content2, owned);
		}

		public unsafe void SendUserMessageWithMetadata(ulong recipientId, string content, Dictionary<string, string> metadata, SendUserMessageCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String content2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &content2, content);
			NativeMethods.Discord_Properties metadata2 = default(NativeMethods.Discord_Properties);
			metadata2.size = (IntPtr)metadata.Count;
			NativeMethods.Discord_String* ptr = default(NativeMethods.Discord_String*);
			bool owned2 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr, metadata.Count);
			NativeMethods.Discord_String* ptr2 = default(NativeMethods.Discord_String*);
			bool owned3 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr2, metadata.Count);
			bool* ptr3 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr3, metadata.Count);
			bool* ptr4 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr4, metadata.Count);
			int num2 = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Discord_String discord_String2 = default(NativeMethods.Discord_String);
			foreach (var (value, value2) in metadata)
			{
				ptr3[num2] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String, value);
				ptr4[num2] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String2, value2);
				ptr[num2] = discord_String;
				ptr2[num2] = discord_String2;
				num2++;
			}
			metadata2.keys = ptr;
			metadata2.values = ptr2;
			NativeMethods.Client.SendUserMessageCallback cb2 = NativeMethods.Client.SendUserMessageCallback_Handler;
			fixed (NativeMethods.Client* ptr5 = &self)
			{
				NativeMethods.Client.SendUserMessageWithMetadata(ptr5, recipientId, content2, metadata2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			for (int i = 0; i < (int)metadata2.size; i++)
			{
				NativeMethods.__FreeLocalString(ptr + i, ptr3[i]);
				NativeMethods.__FreeLocalString(ptr2 + i, ptr4[i]);
			}
			NativeMethods.__FreeLocal(ptr, owned2);
			NativeMethods.__FreeLocal(ptr2, owned3);
			NativeMethods.__FreeLocalString(&content2, owned);
		}

		public unsafe void SetMessageCreatedCallback(MessageCreatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.MessageCreatedCallback cb2 = NativeMethods.Client.MessageCreatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetMessageCreatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetMessageDeletedCallback(MessageDeletedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.MessageDeletedCallback cb2 = NativeMethods.Client.MessageDeletedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetMessageDeletedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetMessageUpdatedCallback(MessageUpdatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.MessageUpdatedCallback cb2 = NativeMethods.Client.MessageUpdatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetMessageUpdatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetShowingChat(bool showingChat)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetShowingChat(ptr, showingChat);
			}
		}

		public unsafe void AddLogCallback(LogCallback callback, LoggingSeverity minSeverity)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LogCallback callback2 = NativeMethods.Client.LogCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.AddLogCallback(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback), minSeverity);
			}
		}

		public unsafe void AddVoiceLogCallback(LogCallback callback, LoggingSeverity minSeverity)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LogCallback callback2 = NativeMethods.Client.LogCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.AddVoiceLogCallback(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback), minSeverity);
			}
		}

		public unsafe void Connect()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.Connect(ptr);
			}
		}

		public unsafe void Disconnect()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.Disconnect(ptr);
			}
		}

		public unsafe Status GetStatus()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			Status status;
			fixed (NativeMethods.Client* ptr = &self)
			{
				status = NativeMethods.Client.GetStatus(ptr);
			}
			return status;
		}

		public unsafe void OpenConnectedGamesSettingsInDiscord(OpenConnectedGamesSettingsInDiscordCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.OpenConnectedGamesSettingsInDiscordCallback callback2 = NativeMethods.Client.OpenConnectedGamesSettingsInDiscordCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.OpenConnectedGamesSettingsInDiscord(ptr, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void SetApplicationId(ulong applicationId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetApplicationId(ptr, applicationId);
			}
		}

		public unsafe bool SetLogDir(string path, LoggingSeverity minSeverity)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String path2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &path2, path);
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.SetLogDir(ptr, path2, minSeverity);
			}
			NativeMethods.__FreeLocalString(&path2, owned);
			return result;
		}

		public unsafe void SetStatusChangedCallback(OnStatusChanged cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.OnStatusChanged cb2 = NativeMethods.Client.OnStatusChanged_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetStatusChangedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetVoiceLogDir(string path, LoggingSeverity minSeverity)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String path2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &path2, path);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetVoiceLogDir(ptr, path2, minSeverity);
			}
			NativeMethods.__FreeLocalString(&path2, owned);
		}

		public unsafe void CreateOrJoinLobby(string secret, CreateOrJoinLobbyCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String secret2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &secret2, secret);
			NativeMethods.Client.CreateOrJoinLobbyCallback callback2 = NativeMethods.Client.CreateOrJoinLobbyCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.CreateOrJoinLobby(ptr, secret2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			NativeMethods.__FreeLocalString(&secret2, owned);
		}

		public unsafe void CreateOrJoinLobbyWithMetadata(string secret, Dictionary<string, string> lobbyMetadata, Dictionary<string, string> memberMetadata, CreateOrJoinLobbyCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String secret2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &secret2, secret);
			NativeMethods.Discord_Properties lobbyMetadata2 = default(NativeMethods.Discord_Properties);
			lobbyMetadata2.size = (IntPtr)lobbyMetadata.Count;
			NativeMethods.Discord_String* ptr = default(NativeMethods.Discord_String*);
			bool owned2 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr, lobbyMetadata.Count);
			NativeMethods.Discord_String* ptr2 = default(NativeMethods.Discord_String*);
			bool owned3 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr2, lobbyMetadata.Count);
			bool* ptr3 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr3, lobbyMetadata.Count);
			bool* ptr4 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr4, lobbyMetadata.Count);
			int num2 = 0;
			string value;
			string key;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Discord_String discord_String2 = default(NativeMethods.Discord_String);
			foreach (KeyValuePair<string, string> lobbyMetadatum in lobbyMetadata)
			{
				lobbyMetadatum.Deconstruct(out value, out key);
				string value2 = value;
				string value3 = key;
				ptr3[num2] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String, value2);
				ptr4[num2] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String2, value3);
				ptr[num2] = discord_String;
				ptr2[num2] = discord_String2;
				num2++;
			}
			lobbyMetadata2.keys = ptr;
			lobbyMetadata2.values = ptr2;
			NativeMethods.Discord_Properties memberMetadata2 = default(NativeMethods.Discord_Properties);
			memberMetadata2.size = (IntPtr)memberMetadata.Count;
			NativeMethods.Discord_String* ptr5 = default(NativeMethods.Discord_String*);
			bool owned4 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr5, memberMetadata.Count);
			NativeMethods.Discord_String* ptr6 = default(NativeMethods.Discord_String*);
			bool owned5 = NativeMethods.__AllocLocalStringArray(buf, &num, 1024, &ptr6, memberMetadata.Count);
			bool* ptr7 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr7, memberMetadata.Count);
			bool* ptr8 = default(bool*);
			NativeMethods.__AllocateLocalBoolArray(buf, &num, 1024, &ptr8, memberMetadata.Count);
			int num3 = 0;
			NativeMethods.Discord_String discord_String3 = default(NativeMethods.Discord_String);
			NativeMethods.Discord_String discord_String4 = default(NativeMethods.Discord_String);
			foreach (KeyValuePair<string, string> memberMetadatum in memberMetadata)
			{
				memberMetadatum.Deconstruct(out key, out value);
				string value4 = key;
				string value5 = value;
				ptr7[num3] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String3, value4);
				ptr8[num3] = NativeMethods.__InitStringLocal(buf, &num, 1024, &discord_String4, value5);
				ptr5[num3] = discord_String3;
				ptr6[num3] = discord_String4;
				num3++;
			}
			memberMetadata2.keys = ptr5;
			memberMetadata2.values = ptr6;
			NativeMethods.Client.CreateOrJoinLobbyCallback callback2 = NativeMethods.Client.CreateOrJoinLobbyCallback_Handler;
			fixed (NativeMethods.Client* ptr9 = &self)
			{
				NativeMethods.Client.CreateOrJoinLobbyWithMetadata(ptr9, secret2, lobbyMetadata2, memberMetadata2, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
			for (int i = 0; i < (int)memberMetadata2.size; i++)
			{
				NativeMethods.__FreeLocalString(ptr5 + i, ptr7[i]);
				NativeMethods.__FreeLocalString(ptr6 + i, ptr8[i]);
			}
			NativeMethods.__FreeLocal(ptr5, owned4);
			NativeMethods.__FreeLocal(ptr6, owned5);
			for (int j = 0; j < (int)lobbyMetadata2.size; j++)
			{
				NativeMethods.__FreeLocalString(ptr + j, ptr3[j]);
				NativeMethods.__FreeLocalString(ptr2 + j, ptr4[j]);
			}
			NativeMethods.__FreeLocal(ptr, owned2);
			NativeMethods.__FreeLocal(ptr2, owned3);
			NativeMethods.__FreeLocalString(&secret2, owned);
		}

		public unsafe void GetGuildChannels(ulong guildId, GetGuildChannelsCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetGuildChannelsCallback cb2 = NativeMethods.Client.GetGuildChannelsCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetGuildChannels(ptr, guildId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe LobbyHandle? GetLobbyHandle(ulong lobbyId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.LobbyHandle lobbyHandle = default(NativeMethods.LobbyHandle);
			bool lobbyHandle2;
			fixed (NativeMethods.Client* ptr = &self)
			{
				lobbyHandle2 = NativeMethods.Client.GetLobbyHandle(ptr, lobbyId, &lobbyHandle);
			}
			if (!lobbyHandle2)
			{
				return null;
			}
			return new LobbyHandle(lobbyHandle, 0);
		}

		public unsafe ulong[] GetLobbyIds()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Discord_UInt64Span discord_UInt64Span = default(NativeMethods.Discord_UInt64Span);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetLobbyIds(ptr, &discord_UInt64Span);
			}
			ulong[] result = new Span<ulong>(discord_UInt64Span.ptr, (int)(uint)discord_UInt64Span.size).ToArray();
			NativeMethods.Discord_Free(discord_UInt64Span.ptr);
			return result;
		}

		public unsafe void GetUserGuilds(GetUserGuildsCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetUserGuildsCallback cb2 = NativeMethods.Client.GetUserGuildsCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetUserGuilds(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void JoinLinkedLobbyGuild(ulong lobbyId, ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback, JoinLinkedLobbyGuildCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.ProvisionalUserMergeRequiredCallback provisionalUserMergeRequiredCallback2 = NativeMethods.Client.ProvisionalUserMergeRequiredCallback_Handler;
			NativeMethods.Client.JoinLinkedLobbyGuildCallback callback2 = NativeMethods.Client.JoinLinkedLobbyGuildCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.JoinLinkedLobbyGuild(ptr, lobbyId, provisionalUserMergeRequiredCallback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(provisionalUserMergeRequiredCallback), callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void LeaveLobby(ulong lobbyId, LeaveLobbyCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LeaveLobbyCallback callback2 = NativeMethods.Client.LeaveLobbyCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.LeaveLobby(ptr, lobbyId, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void LinkChannelToLobby(ulong lobbyId, ulong channelId, LinkOrUnlinkChannelCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LinkOrUnlinkChannelCallback callback2 = NativeMethods.Client.LinkOrUnlinkChannelCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.LinkChannelToLobby(ptr, lobbyId, channelId, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void SetLobbyCreatedCallback(LobbyCreatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LobbyCreatedCallback cb2 = NativeMethods.Client.LobbyCreatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetLobbyCreatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetLobbyDeletedCallback(LobbyDeletedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LobbyDeletedCallback cb2 = NativeMethods.Client.LobbyDeletedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetLobbyDeletedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetLobbyMemberAddedCallback(LobbyMemberAddedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LobbyMemberAddedCallback cb2 = NativeMethods.Client.LobbyMemberAddedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetLobbyMemberAddedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetLobbyMemberRemovedCallback(LobbyMemberRemovedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LobbyMemberRemovedCallback cb2 = NativeMethods.Client.LobbyMemberRemovedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetLobbyMemberRemovedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetLobbyMemberUpdatedCallback(LobbyMemberUpdatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LobbyMemberUpdatedCallback cb2 = NativeMethods.Client.LobbyMemberUpdatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetLobbyMemberUpdatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetLobbyUpdatedCallback(LobbyUpdatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LobbyUpdatedCallback cb2 = NativeMethods.Client.LobbyUpdatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetLobbyUpdatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void UnlinkChannelFromLobby(ulong lobbyId, LinkOrUnlinkChannelCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.LinkOrUnlinkChannelCallback callback2 = NativeMethods.Client.LinkOrUnlinkChannelCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.UnlinkChannelFromLobby(ptr, lobbyId, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void AcceptActivityInvite(ActivityInvite invite, AcceptActivityInviteCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.ActivityInvite* invite2 = &invite.self)
			{
				NativeMethods.Client.AcceptActivityInviteCallback cb2 = NativeMethods.Client.AcceptActivityInviteCallback_Handler;
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.AcceptActivityInvite(ptr, invite2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
				}
			}
		}

		public unsafe void ClearRichPresence()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.ClearRichPresence(ptr);
			}
		}

		public unsafe bool RegisterLaunchCommand(ulong applicationId, string command)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String command2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &command2, command);
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.RegisterLaunchCommand(ptr, applicationId, command2);
			}
			NativeMethods.__FreeLocalString(&command2, owned);
			return result;
		}

		public unsafe bool RegisterLaunchSteamApplication(ulong applicationId, uint steamAppId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			bool result;
			fixed (NativeMethods.Client* ptr = &self)
			{
				result = NativeMethods.Client.RegisterLaunchSteamApplication(ptr, applicationId, steamAppId);
			}
			return result;
		}

		public unsafe void SendActivityInvite(ulong userId, string content, SendActivityInviteCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String content2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &content2, content);
			NativeMethods.Client.SendActivityInviteCallback cb2 = NativeMethods.Client.SendActivityInviteCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendActivityInvite(ptr, userId, content2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&content2, owned);
		}

		public unsafe void SendActivityJoinRequest(ulong userId, SendActivityInviteCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.SendActivityInviteCallback cb2 = NativeMethods.Client.SendActivityInviteCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendActivityJoinRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SendActivityJoinRequestReply(ActivityInvite invite, SendActivityInviteCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.ActivityInvite* invite2 = &invite.self)
			{
				NativeMethods.Client.SendActivityInviteCallback cb2 = NativeMethods.Client.SendActivityInviteCallback_Handler;
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.SendActivityJoinRequestReply(ptr, invite2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
				}
			}
		}

		public unsafe void SetActivityInviteCreatedCallback(ActivityInviteCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.ActivityInviteCallback cb2 = NativeMethods.Client.ActivityInviteCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetActivityInviteCreatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetActivityInviteUpdatedCallback(ActivityInviteCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.ActivityInviteCallback cb2 = NativeMethods.Client.ActivityInviteCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetActivityInviteUpdatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetActivityJoinCallback(ActivityJoinCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.ActivityJoinCallback cb2 = NativeMethods.Client.ActivityJoinCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetActivityJoinCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetActivityJoinWithApplicationCallback(ActivityJoinWithApplicationCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.ActivityJoinWithApplicationCallback cb2 = NativeMethods.Client.ActivityJoinWithApplicationCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetActivityJoinWithApplicationCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetOnlineStatus(StatusType status, UpdateStatusCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateStatusCallback callback2 = NativeMethods.Client.UpdateStatusCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetOnlineStatus(ptr, status, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe void UpdateRichPresence(Activity activity, UpdateRichPresenceCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			fixed (NativeMethods.Activity* activity2 = &activity.self)
			{
				NativeMethods.Client.UpdateRichPresenceCallback cb2 = NativeMethods.Client.UpdateRichPresenceCallback_Handler;
				fixed (NativeMethods.Client* ptr = &self)
				{
					NativeMethods.Client.UpdateRichPresence(ptr, activity2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
				}
			}
		}

		public unsafe void AcceptDiscordFriendRequest(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.AcceptDiscordFriendRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void AcceptGameFriendRequest(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.AcceptGameFriendRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void BlockUser(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.BlockUser(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void CancelDiscordFriendRequest(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.CancelDiscordFriendRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void CancelGameFriendRequest(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.CancelGameFriendRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe RelationshipHandle GetRelationshipHandle(ulong userId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.RelationshipHandle relationshipHandle = default(NativeMethods.RelationshipHandle);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetRelationshipHandle(ptr, userId, &relationshipHandle);
			}
			return new RelationshipHandle(relationshipHandle, 0);
		}

		public unsafe RelationshipHandle[] GetRelationships()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Discord_RelationshipHandleSpan discord_RelationshipHandleSpan = default(NativeMethods.Discord_RelationshipHandleSpan);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetRelationships(ptr, &discord_RelationshipHandleSpan);
			}
			RelationshipHandle[] array = new RelationshipHandle[(uint)discord_RelationshipHandleSpan.size];
			for (int i = 0; i < (int)(uint)discord_RelationshipHandleSpan.size; i++)
			{
				array[i] = new RelationshipHandle(discord_RelationshipHandleSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_RelationshipHandleSpan.ptr);
			return array;
		}

		public unsafe RelationshipHandle[] GetRelationshipsByGroup(RelationshipGroupType groupType)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Discord_RelationshipHandleSpan discord_RelationshipHandleSpan = default(NativeMethods.Discord_RelationshipHandleSpan);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetRelationshipsByGroup(ptr, groupType, &discord_RelationshipHandleSpan);
			}
			RelationshipHandle[] array = new RelationshipHandle[(uint)discord_RelationshipHandleSpan.size];
			for (int i = 0; i < (int)(uint)discord_RelationshipHandleSpan.size; i++)
			{
				array[i] = new RelationshipHandle(discord_RelationshipHandleSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_RelationshipHandleSpan.ptr);
			return array;
		}

		public unsafe void RejectDiscordFriendRequest(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RejectDiscordFriendRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void RejectGameFriendRequest(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RejectGameFriendRequest(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void RemoveDiscordAndGameFriend(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RemoveDiscordAndGameFriend(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void RemoveGameFriend(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.RemoveGameFriend(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe UserHandle[] SearchFriendsByUsername(string searchStr)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Discord_UserHandleSpan discord_UserHandleSpan = default(NativeMethods.Discord_UserHandleSpan);
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String searchStr2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &searchStr2, searchStr);
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SearchFriendsByUsername(ptr, searchStr2, &discord_UserHandleSpan);
			}
			NativeMethods.__FreeLocalString(&searchStr2, owned);
			UserHandle[] array = new UserHandle[(uint)discord_UserHandleSpan.size];
			for (int i = 0; i < (int)(uint)discord_UserHandleSpan.size; i++)
			{
				array[i] = new UserHandle(discord_UserHandleSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_UserHandleSpan.ptr);
			return array;
		}

		public unsafe void SendDiscordFriendRequest(string username, SendFriendRequestCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String username2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &username2, username);
			NativeMethods.Client.SendFriendRequestCallback cb2 = NativeMethods.Client.SendFriendRequestCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendDiscordFriendRequest(ptr, username2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&username2, owned);
		}

		public unsafe void SendDiscordFriendRequestById(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendDiscordFriendRequestById(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SendGameFriendRequest(string username, SendFriendRequestCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String username2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &username2, username);
			NativeMethods.Client.SendFriendRequestCallback cb2 = NativeMethods.Client.SendFriendRequestCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendGameFriendRequest(ptr, username2, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
			NativeMethods.__FreeLocalString(&username2, owned);
		}

		public unsafe void SendGameFriendRequestById(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SendGameFriendRequestById(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetRelationshipCreatedCallback(RelationshipCreatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.RelationshipCreatedCallback cb2 = NativeMethods.Client.RelationshipCreatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetRelationshipCreatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetRelationshipDeletedCallback(RelationshipDeletedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.RelationshipDeletedCallback cb2 = NativeMethods.Client.RelationshipDeletedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetRelationshipDeletedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void UnblockUser(ulong userId, UpdateRelationshipCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UpdateRelationshipCallback cb2 = NativeMethods.Client.UpdateRelationshipCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.UnblockUser(ptr, userId, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe UserHandle? GetCurrentUserV2()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			bool currentUserV;
			fixed (NativeMethods.Client* ptr = &self)
			{
				currentUserV = NativeMethods.Client.GetCurrentUserV2(ptr, &userHandle);
			}
			if (!currentUserV)
			{
				return null;
			}
			return new UserHandle(userHandle, 0);
		}

		public unsafe void GetDiscordClientConnectedUser(ulong applicationId, GetDiscordClientConnectedUserCallback callback)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.GetDiscordClientConnectedUserCallback callback2 = NativeMethods.Client.GetDiscordClientConnectedUserCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.GetDiscordClientConnectedUser(ptr, applicationId, callback2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(callback));
			}
		}

		public unsafe UserHandle? GetUser(ulong userId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			bool user;
			fixed (NativeMethods.Client* ptr = &self)
			{
				user = NativeMethods.Client.GetUser(ptr, userId, &userHandle);
			}
			if (!user)
			{
				return null;
			}
			return new UserHandle(userHandle, 0);
		}

		public unsafe void SetRelationshipGroupsUpdatedCallback(RelationshipGroupsUpdatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.RelationshipGroupsUpdatedCallback cb2 = NativeMethods.Client.RelationshipGroupsUpdatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetRelationshipGroupsUpdatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetUserUpdatedCallback(UserUpdatedCallback cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Client");
			}
			NativeMethods.Client.UserUpdatedCallback cb2 = NativeMethods.Client.UserUpdatedCallback_Handler;
			fixed (NativeMethods.Client* ptr = &self)
			{
				NativeMethods.Client.SetUserUpdatedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}
	}
}
