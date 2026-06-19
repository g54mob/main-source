using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int cQKfjmmggfxHjGIncdnjhtWuaHBLA;

		private uint ApbOjUhwubSNSHFkHEheZuYRYvQf;

		private IntPtr yAPONRdgQNGGwDkfvvQExXLwEGuB;

		private bool iKTojQTovlsnBKbNjSrpoGyWTsTs;

		public uint size => ApbOjUhwubSNSHFkHEheZuYRYvQf;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			ApbOjUhwubSNSHFkHEheZuYRYvQf = P_0;
			cQKfjmmggfxHjGIncdnjhtWuaHBLA = 0;
			try
			{
				yAPONRdgQNGGwDkfvvQExXLwEGuB = Marshal.AllocHGlobal((int)P_0);
				if (yAPONRdgQNGGwDkfvvQExXLwEGuB == IntPtr.Zero)
				{
					throw new Exception("Could not allocate native memory.");
				}
			}
			catch
			{
				throw;
			}
		}

		public IntPtr Allocate(uint bytes, IntPtr ptrToData)
		{
			if (iKTojQTovlsnBKbNjSrpoGyWTsTs)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > ApbOjUhwubSNSHFkHEheZuYRYvQf)
			{
				return IntPtr.Zero;
			}
			if (cQKfjmmggfxHjGIncdnjhtWuaHBLA + bytes >= ApbOjUhwubSNSHFkHEheZuYRYvQf)
			{
				cQKfjmmggfxHjGIncdnjhtWuaHBLA = 0;
			}
			IntPtr intPtr = new IntPtr(yAPONRdgQNGGwDkfvvQExXLwEGuB.ToInt64() + cQKfjmmggfxHjGIncdnjhtWuaHBLA);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			cQKfjmmggfxHjGIncdnjhtWuaHBLA += (int)bytes;
			return intPtr;
		}

		public IntPtr Allocate(uint bytes)
		{
			return Allocate(bytes, IntPtr.Zero);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~NativeMemoryBlock()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!iKTojQTovlsnBKbNjSrpoGyWTsTs)
			{
				iKTojQTovlsnBKbNjSrpoGyWTsTs = true;
				if (yAPONRdgQNGGwDkfvvQExXLwEGuB != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(yAPONRdgQNGGwDkfvvQExXLwEGuB);
					yAPONRdgQNGGwDkfvvQExXLwEGuB = IntPtr.Zero;
				}
			}
		}
	}
}
