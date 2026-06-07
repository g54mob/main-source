using System;
using System.Threading;

namespace Discord.Sdk
{
	public class CallInfoHandle : IDisposable
	{
		internal NativeMethods.CallInfoHandle self;

		private int disposed_;

		internal CallInfoHandle(NativeMethods.CallInfoHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~CallInfoHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.CallInfoHandle* ptr = &self)
				{
					NativeMethods.CallInfoHandle.Drop(ptr);
				}
			}
		}

		public unsafe CallInfoHandle(CallInfoHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("CallInfoHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.CallInfoHandle* other2 = &other.self)
			{
				fixed (NativeMethods.CallInfoHandle* ptr = &self)
				{
					NativeMethods.CallInfoHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe CallInfoHandle(NativeMethods.CallInfoHandle* otherPtr)
		{
			fixed (NativeMethods.CallInfoHandle* ptr = &self)
			{
				NativeMethods.CallInfoHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong ChannelId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("CallInfoHandle");
			}
			ulong result;
			fixed (NativeMethods.CallInfoHandle* ptr = &self)
			{
				result = NativeMethods.CallInfoHandle.ChannelId(ptr);
			}
			return result;
		}

		public unsafe ulong[] GetParticipants()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("CallInfoHandle");
			}
			NativeMethods.Discord_UInt64Span discord_UInt64Span = default(NativeMethods.Discord_UInt64Span);
			fixed (NativeMethods.CallInfoHandle* ptr = &self)
			{
				NativeMethods.CallInfoHandle.GetParticipants(ptr, &discord_UInt64Span);
			}
			ulong[] result = new Span<ulong>(discord_UInt64Span.ptr, (int)(uint)discord_UInt64Span.size).ToArray();
			NativeMethods.Discord_Free(discord_UInt64Span.ptr);
			return result;
		}

		public unsafe VoiceStateHandle? GetVoiceStateHandle(ulong userId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("CallInfoHandle");
			}
			NativeMethods.VoiceStateHandle voiceStateHandle = default(NativeMethods.VoiceStateHandle);
			bool voiceStateHandle2;
			fixed (NativeMethods.CallInfoHandle* ptr = &self)
			{
				voiceStateHandle2 = NativeMethods.CallInfoHandle.GetVoiceStateHandle(ptr, userId, &voiceStateHandle);
			}
			if (!voiceStateHandle2)
			{
				return null;
			}
			return new VoiceStateHandle(voiceStateHandle, 0);
		}

		public unsafe ulong GuildId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("CallInfoHandle");
			}
			ulong result;
			fixed (NativeMethods.CallInfoHandle* ptr = &self)
			{
				result = NativeMethods.CallInfoHandle.GuildId(ptr);
			}
			return result;
		}
	}
}
