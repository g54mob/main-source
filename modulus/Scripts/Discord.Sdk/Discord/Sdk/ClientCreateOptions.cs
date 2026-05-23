using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ClientCreateOptions : IDisposable
	{
		internal NativeMethods.ClientCreateOptions self;

		private int disposed_;

		internal ClientCreateOptions(NativeMethods.ClientCreateOptions self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ClientCreateOptions()
		{
			Dispose();
		}

		public unsafe ClientCreateOptions()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ClientCreateOptions* ptr = &self)
				{
					NativeMethods.ClientCreateOptions.Drop(ptr);
				}
			}
		}

		public unsafe ClientCreateOptions(ClientCreateOptions other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ClientCreateOptions* arg = &other.self)
			{
				fixed (NativeMethods.ClientCreateOptions* ptr = &self)
				{
					NativeMethods.ClientCreateOptions.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ClientCreateOptions(NativeMethods.ClientCreateOptions* otherPtr)
		{
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.Clone(ptr, otherPtr);
			}
		}

		public unsafe string WebBase()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.WebBase(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetWebBase(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.SetWebBase(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe string ApiBase()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.ApiBase(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetApiBase(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.SetApiBase(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe AudioSystem ExperimentalAudioSystem()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			AudioSystem result;
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				result = NativeMethods.ClientCreateOptions.ExperimentalAudioSystem(ptr);
			}
			return result;
		}

		public unsafe void SetExperimentalAudioSystem(AudioSystem value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.SetExperimentalAudioSystem(ptr, value);
			}
		}

		public unsafe bool ExperimentalAndroidPreventCommsForBluetooth()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			bool result;
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				result = NativeMethods.ClientCreateOptions.ExperimentalAndroidPreventCommsForBluetooth(ptr);
			}
			return result;
		}

		public unsafe void SetExperimentalAndroidPreventCommsForBluetooth(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.SetExperimentalAndroidPreventCommsForBluetooth(ptr, value);
			}
		}

		public unsafe ulong? CpuAffinityMask()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			bool num;
			ulong value = default(ulong);
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				num = NativeMethods.ClientCreateOptions.CpuAffinityMask(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe void SetCpuAffinityMask(ulong? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientCreateOptions");
			}
			ulong valueOrDefault = value.GetValueOrDefault();
			fixed (NativeMethods.ClientCreateOptions* ptr = &self)
			{
				NativeMethods.ClientCreateOptions.SetCpuAffinityMask(ptr, value.HasValue ? (&valueOrDefault) : null);
			}
		}
	}
}
