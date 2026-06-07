using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int mJCdKJGGkCUZxBBewsMhzJYEcGId;

		private uint EPbfYlFZIKBTGzGCPADwiPBGdhVSB;

		private IntPtr kGTKCmDgEaxZWYuWxneIhZUKnbPX;

		private bool irDrzftHDGyOZDxWboPbcfZcJkYc;

		public uint size => EPbfYlFZIKBTGzGCPADwiPBGdhVSB;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			EPbfYlFZIKBTGzGCPADwiPBGdhVSB = P_0;
			mJCdKJGGkCUZxBBewsMhzJYEcGId = 0;
			try
			{
				kGTKCmDgEaxZWYuWxneIhZUKnbPX = Marshal.AllocHGlobal((int)P_0);
				if (kGTKCmDgEaxZWYuWxneIhZUKnbPX == IntPtr.Zero)
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
			if (irDrzftHDGyOZDxWboPbcfZcJkYc)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > EPbfYlFZIKBTGzGCPADwiPBGdhVSB)
			{
				return IntPtr.Zero;
			}
			if (mJCdKJGGkCUZxBBewsMhzJYEcGId + bytes >= EPbfYlFZIKBTGzGCPADwiPBGdhVSB)
			{
				mJCdKJGGkCUZxBBewsMhzJYEcGId = 0;
			}
			IntPtr intPtr = new IntPtr(kGTKCmDgEaxZWYuWxneIhZUKnbPX.ToInt64() + mJCdKJGGkCUZxBBewsMhzJYEcGId);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			mJCdKJGGkCUZxBBewsMhzJYEcGId += (int)bytes;
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
			if (!irDrzftHDGyOZDxWboPbcfZcJkYc)
			{
				irDrzftHDGyOZDxWboPbcfZcJkYc = true;
				if (kGTKCmDgEaxZWYuWxneIhZUKnbPX != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(kGTKCmDgEaxZWYuWxneIhZUKnbPX);
					kGTKCmDgEaxZWYuWxneIhZUKnbPX = IntPtr.Zero;
				}
			}
		}
	}
}
