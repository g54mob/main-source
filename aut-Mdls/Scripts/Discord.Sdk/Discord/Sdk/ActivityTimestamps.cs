using System;
using System.Threading;

namespace Discord.Sdk
{
	public class ActivityTimestamps : IDisposable
	{
		internal NativeMethods.ActivityTimestamps self;

		private int disposed_;

		internal ActivityTimestamps(NativeMethods.ActivityTimestamps self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ActivityTimestamps()
		{
			Dispose();
		}

		public unsafe ActivityTimestamps()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ActivityTimestamps* ptr = &self)
			{
				NativeMethods.ActivityTimestamps.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ActivityTimestamps* ptr = &self)
				{
					NativeMethods.ActivityTimestamps.Drop(ptr);
				}
			}
		}

		public unsafe ActivityTimestamps(ActivityTimestamps other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityTimestamps");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ActivityTimestamps* arg = &other.self)
			{
				fixed (NativeMethods.ActivityTimestamps* ptr = &self)
				{
					NativeMethods.ActivityTimestamps.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ActivityTimestamps(NativeMethods.ActivityTimestamps* otherPtr)
		{
			fixed (NativeMethods.ActivityTimestamps* ptr = &self)
			{
				NativeMethods.ActivityTimestamps.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong Start()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityTimestamps");
			}
			ulong result;
			fixed (NativeMethods.ActivityTimestamps* ptr = &self)
			{
				result = NativeMethods.ActivityTimestamps.Start(ptr);
			}
			return result;
		}

		public unsafe void SetStart(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityTimestamps");
			}
			fixed (NativeMethods.ActivityTimestamps* ptr = &self)
			{
				NativeMethods.ActivityTimestamps.SetStart(ptr, value);
			}
		}

		public unsafe ulong End()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityTimestamps");
			}
			ulong result;
			fixed (NativeMethods.ActivityTimestamps* ptr = &self)
			{
				result = NativeMethods.ActivityTimestamps.End(ptr);
			}
			return result;
		}

		public unsafe void SetEnd(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityTimestamps");
			}
			fixed (NativeMethods.ActivityTimestamps* ptr = &self)
			{
				NativeMethods.ActivityTimestamps.SetEnd(ptr, value);
			}
		}
	}
}
