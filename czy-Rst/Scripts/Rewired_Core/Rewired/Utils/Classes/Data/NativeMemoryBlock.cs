using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int znnlHqBfLzjbkFHPGFDYPvFkRosv;

		private uint PRUUAKKbZvnwDClIzooLrpXJNjbt;

		private IntPtr tecnKPQlZBviTOQEBUTdTZWgOnbP;

		private bool jcNbUNqInSBMJvzJgTYDGtMrVgnA;

		public uint size => PRUUAKKbZvnwDClIzooLrpXJNjbt;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			PRUUAKKbZvnwDClIzooLrpXJNjbt = P_0;
			znnlHqBfLzjbkFHPGFDYPvFkRosv = 0;
			try
			{
				tecnKPQlZBviTOQEBUTdTZWgOnbP = Marshal.AllocHGlobal((int)P_0);
				if (tecnKPQlZBviTOQEBUTdTZWgOnbP == IntPtr.Zero)
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
			if (jcNbUNqInSBMJvzJgTYDGtMrVgnA)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > PRUUAKKbZvnwDClIzooLrpXJNjbt)
			{
				return IntPtr.Zero;
			}
			if (znnlHqBfLzjbkFHPGFDYPvFkRosv + bytes >= PRUUAKKbZvnwDClIzooLrpXJNjbt)
			{
				znnlHqBfLzjbkFHPGFDYPvFkRosv = 0;
			}
			IntPtr intPtr = new IntPtr(tecnKPQlZBviTOQEBUTdTZWgOnbP.ToInt64() + znnlHqBfLzjbkFHPGFDYPvFkRosv);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			znnlHqBfLzjbkFHPGFDYPvFkRosv += (int)bytes;
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
			if (!jcNbUNqInSBMJvzJgTYDGtMrVgnA)
			{
				jcNbUNqInSBMJvzJgTYDGtMrVgnA = true;
				if (tecnKPQlZBviTOQEBUTdTZWgOnbP != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(tecnKPQlZBviTOQEBUTdTZWgOnbP);
					tecnKPQlZBviTOQEBUTdTZWgOnbP = IntPtr.Zero;
				}
			}
		}
	}
}
