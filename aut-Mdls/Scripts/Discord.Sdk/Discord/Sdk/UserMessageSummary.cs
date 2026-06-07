using System;
using System.Threading;

namespace Discord.Sdk
{
	public class UserMessageSummary : IDisposable
	{
		internal NativeMethods.UserMessageSummary self;

		private int disposed_;

		internal UserMessageSummary(NativeMethods.UserMessageSummary self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~UserMessageSummary()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.UserMessageSummary* ptr = &self)
				{
					NativeMethods.UserMessageSummary.Drop(ptr);
				}
			}
		}

		public unsafe UserMessageSummary(UserMessageSummary other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserMessageSummary");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.UserMessageSummary* arg = &other.self)
			{
				fixed (NativeMethods.UserMessageSummary* ptr = &self)
				{
					NativeMethods.UserMessageSummary.Clone(ptr, arg);
				}
			}
		}

		internal unsafe UserMessageSummary(NativeMethods.UserMessageSummary* otherPtr)
		{
			fixed (NativeMethods.UserMessageSummary* ptr = &self)
			{
				NativeMethods.UserMessageSummary.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong LastMessageId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserMessageSummary");
			}
			ulong result;
			fixed (NativeMethods.UserMessageSummary* ptr = &self)
			{
				result = NativeMethods.UserMessageSummary.LastMessageId(ptr);
			}
			return result;
		}

		public unsafe ulong UserId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserMessageSummary");
			}
			ulong result;
			fixed (NativeMethods.UserMessageSummary* ptr = &self)
			{
				result = NativeMethods.UserMessageSummary.UserId(ptr);
			}
			return result;
		}
	}
}
