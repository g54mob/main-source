using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class Call : IDisposable
	{
		public enum Error
		{
			None = 0,
			SignalingConnectionFailed = 1,
			SignalingUnexpectedClose = 2,
			VoiceConnectionFailed = 3,
			JoinTimeout = 4,
			Forbidden = 5
		}

		public enum Status
		{
			Disconnected = 0,
			Joining = 1,
			Connecting = 2,
			SignalingConnected = 3,
			Connected = 4,
			Reconnecting = 5,
			Disconnecting = 6
		}

		public delegate void OnVoiceStateChanged(ulong userId);

		public delegate void OnParticipantChanged(ulong userId, bool added);

		public delegate void OnSpeakingStatusChanged(ulong userId, bool isPlayingSound);

		public delegate void OnStatusChanged(Status status, Error error, int errorDetail);

		internal NativeMethods.Call self;

		private int disposed_;

		internal Call(NativeMethods.Call self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~Call()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.Call* ptr = &self)
				{
					NativeMethods.Call.Drop(ptr);
				}
			}
		}

		public unsafe Call(Call other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.Call* other2 = &other.self)
			{
				fixed (NativeMethods.Call* ptr = &self)
				{
					NativeMethods.Call.Clone(ptr, other2);
				}
			}
		}

		internal unsafe Call(NativeMethods.Call* otherPtr)
		{
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.Clone(ptr, otherPtr);
			}
		}

		public unsafe static string ErrorToString(Error type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Call.ErrorToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe AudioModeType GetAudioMode()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			AudioModeType audioMode;
			fixed (NativeMethods.Call* ptr = &self)
			{
				audioMode = NativeMethods.Call.GetAudioMode(ptr);
			}
			return audioMode;
		}

		public unsafe ulong GetChannelId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			ulong channelId;
			fixed (NativeMethods.Call* ptr = &self)
			{
				channelId = NativeMethods.Call.GetChannelId(ptr);
			}
			return channelId;
		}

		public unsafe ulong GetGuildId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			ulong guildId;
			fixed (NativeMethods.Call* ptr = &self)
			{
				guildId = NativeMethods.Call.GetGuildId(ptr);
			}
			return guildId;
		}

		public unsafe bool GetLocalMute(ulong userId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			bool localMute;
			fixed (NativeMethods.Call* ptr = &self)
			{
				localMute = NativeMethods.Call.GetLocalMute(ptr, userId);
			}
			return localMute;
		}

		public unsafe ulong[] GetParticipants()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.Discord_UInt64Span discord_UInt64Span = default(NativeMethods.Discord_UInt64Span);
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.GetParticipants(ptr, &discord_UInt64Span);
			}
			ulong[] result = new Span<ulong>(discord_UInt64Span.ptr, (int)(uint)discord_UInt64Span.size).ToArray();
			NativeMethods.Discord_Free(discord_UInt64Span.ptr);
			return result;
		}

		public unsafe float GetParticipantVolume(ulong userId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			float participantVolume;
			fixed (NativeMethods.Call* ptr = &self)
			{
				participantVolume = NativeMethods.Call.GetParticipantVolume(ptr, userId);
			}
			return participantVolume;
		}

		public unsafe bool GetPTTActive()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			bool pTTActive;
			fixed (NativeMethods.Call* ptr = &self)
			{
				pTTActive = NativeMethods.Call.GetPTTActive(ptr);
			}
			return pTTActive;
		}

		public unsafe uint GetPTTReleaseDelay()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			uint pTTReleaseDelay;
			fixed (NativeMethods.Call* ptr = &self)
			{
				pTTReleaseDelay = NativeMethods.Call.GetPTTReleaseDelay(ptr);
			}
			return pTTReleaseDelay;
		}

		public unsafe bool GetSelfDeaf()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			bool selfDeaf;
			fixed (NativeMethods.Call* ptr = &self)
			{
				selfDeaf = NativeMethods.Call.GetSelfDeaf(ptr);
			}
			return selfDeaf;
		}

		public unsafe bool GetSelfMute()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			bool selfMute;
			fixed (NativeMethods.Call* ptr = &self)
			{
				selfMute = NativeMethods.Call.GetSelfMute(ptr);
			}
			return selfMute;
		}

		public unsafe Status GetStatus()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			Status status;
			fixed (NativeMethods.Call* ptr = &self)
			{
				status = NativeMethods.Call.GetStatus(ptr);
			}
			return status;
		}

		public unsafe VADThresholdSettings GetVADThreshold()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.VADThresholdSettings vADThresholdSettings = default(NativeMethods.VADThresholdSettings);
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.GetVADThreshold(ptr, &vADThresholdSettings);
			}
			return new VADThresholdSettings(vADThresholdSettings, 0);
		}

		public unsafe VoiceStateHandle? GetVoiceStateHandle(ulong userId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.VoiceStateHandle voiceStateHandle = default(NativeMethods.VoiceStateHandle);
			bool voiceStateHandle2;
			fixed (NativeMethods.Call* ptr = &self)
			{
				voiceStateHandle2 = NativeMethods.Call.GetVoiceStateHandle(ptr, userId, &voiceStateHandle);
			}
			if (!voiceStateHandle2)
			{
				return null;
			}
			return new VoiceStateHandle(voiceStateHandle, 0);
		}

		public unsafe void SetAudioMode(AudioModeType audioMode)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetAudioMode(ptr, audioMode);
			}
		}

		public unsafe void SetLocalMute(ulong userId, bool mute)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetLocalMute(ptr, userId, mute);
			}
		}

		public unsafe void SetOnVoiceStateChangedCallback(OnVoiceStateChanged cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.Call.OnVoiceStateChanged cb2 = NativeMethods.Call.OnVoiceStateChanged_Handler;
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetOnVoiceStateChangedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetParticipantChangedCallback(OnParticipantChanged cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.Call.OnParticipantChanged cb2 = NativeMethods.Call.OnParticipantChanged_Handler;
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetParticipantChangedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetParticipantVolume(ulong userId, float volume)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetParticipantVolume(ptr, userId, volume);
			}
		}

		public unsafe void SetPTTActive(bool active)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetPTTActive(ptr, active);
			}
		}

		public unsafe void SetPTTReleaseDelay(uint releaseDelayMs)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetPTTReleaseDelay(ptr, releaseDelayMs);
			}
		}

		public unsafe void SetSelfDeaf(bool deaf)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetSelfDeaf(ptr, deaf);
			}
		}

		public unsafe void SetSelfMute(bool mute)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetSelfMute(ptr, mute);
			}
		}

		public unsafe void SetSpeakingStatusChangedCallback(OnSpeakingStatusChanged cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.Call.OnSpeakingStatusChanged cb2 = NativeMethods.Call.OnSpeakingStatusChanged_Handler;
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetSpeakingStatusChangedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetStatusChangedCallback(OnStatusChanged cb)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			NativeMethods.Call.OnStatusChanged cb2 = NativeMethods.Call.OnStatusChanged_Handler;
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetStatusChangedCallback(ptr, cb2, NativeMethods.ManagedUserData.Free, NativeMethods.ManagedUserData.CreateHandle(cb));
			}
		}

		public unsafe void SetVADThreshold(bool automatic, float threshold)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Call");
			}
			fixed (NativeMethods.Call* ptr = &self)
			{
				NativeMethods.Call.SetVADThreshold(ptr, automatic, threshold);
			}
		}

		public unsafe static string StatusToString(Status type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.Call.StatusToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}
	}
}
