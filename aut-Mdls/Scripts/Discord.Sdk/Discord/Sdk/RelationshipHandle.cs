using System;
using System.Threading;

namespace Discord.Sdk
{
	public class RelationshipHandle : IDisposable
	{
		internal NativeMethods.RelationshipHandle self;

		private int disposed_;

		internal RelationshipHandle(NativeMethods.RelationshipHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~RelationshipHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.RelationshipHandle* ptr = &self)
				{
					NativeMethods.RelationshipHandle.Drop(ptr);
				}
			}
		}

		public unsafe RelationshipHandle(RelationshipHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("RelationshipHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.RelationshipHandle* other2 = &other.self)
			{
				fixed (NativeMethods.RelationshipHandle* ptr = &self)
				{
					NativeMethods.RelationshipHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe RelationshipHandle(NativeMethods.RelationshipHandle* otherPtr)
		{
			fixed (NativeMethods.RelationshipHandle* ptr = &self)
			{
				NativeMethods.RelationshipHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe RelationshipType DiscordRelationshipType()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("RelationshipHandle");
			}
			RelationshipType result;
			fixed (NativeMethods.RelationshipHandle* ptr = &self)
			{
				result = NativeMethods.RelationshipHandle.DiscordRelationshipType(ptr);
			}
			return result;
		}

		public unsafe RelationshipType GameRelationshipType()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("RelationshipHandle");
			}
			RelationshipType result;
			fixed (NativeMethods.RelationshipHandle* ptr = &self)
			{
				result = NativeMethods.RelationshipHandle.GameRelationshipType(ptr);
			}
			return result;
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("RelationshipHandle");
			}
			ulong result;
			fixed (NativeMethods.RelationshipHandle* ptr = &self)
			{
				result = NativeMethods.RelationshipHandle.Id(ptr);
			}
			return result;
		}

		public unsafe bool IsSpamRequest()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("RelationshipHandle");
			}
			bool result;
			fixed (NativeMethods.RelationshipHandle* ptr = &self)
			{
				result = NativeMethods.RelationshipHandle.IsSpamRequest(ptr);
			}
			return result;
		}

		public unsafe UserHandle? User()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("RelationshipHandle");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			bool num;
			fixed (NativeMethods.RelationshipHandle* ptr = &self)
			{
				num = NativeMethods.RelationshipHandle.User(ptr, &userHandle);
			}
			if (!num)
			{
				return null;
			}
			return new UserHandle(userHandle, 0);
		}
	}
}
