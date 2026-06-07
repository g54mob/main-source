using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int aqFiwDJUPylUiVfAYTciTIbNKWqr;

		private uint EtyRVrAaNqDcRgCTvJepXbnurPtbA;

		private IntPtr kdSxLaMNLKkkVUBVTRPLZXsJHFzt;

		private bool aXOAipkSKelBOPwmVJBiUPFdfhwM;

		public uint size => EtyRVrAaNqDcRgCTvJepXbnurPtbA;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			EtyRVrAaNqDcRgCTvJepXbnurPtbA = P_0;
			aqFiwDJUPylUiVfAYTciTIbNKWqr = 0;
			try
			{
				kdSxLaMNLKkkVUBVTRPLZXsJHFzt = Marshal.AllocHGlobal((int)P_0);
				if (kdSxLaMNLKkkVUBVTRPLZXsJHFzt == IntPtr.Zero)
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
			if (aXOAipkSKelBOPwmVJBiUPFdfhwM)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > EtyRVrAaNqDcRgCTvJepXbnurPtbA)
			{
				return IntPtr.Zero;
			}
			if (aqFiwDJUPylUiVfAYTciTIbNKWqr + bytes >= EtyRVrAaNqDcRgCTvJepXbnurPtbA)
			{
				aqFiwDJUPylUiVfAYTciTIbNKWqr = 0;
			}
			IntPtr intPtr = new IntPtr(kdSxLaMNLKkkVUBVTRPLZXsJHFzt.ToInt64() + aqFiwDJUPylUiVfAYTciTIbNKWqr);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			aqFiwDJUPylUiVfAYTciTIbNKWqr += (int)bytes;
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
			if (!aXOAipkSKelBOPwmVJBiUPFdfhwM)
			{
				aXOAipkSKelBOPwmVJBiUPFdfhwM = true;
				if (kdSxLaMNLKkkVUBVTRPLZXsJHFzt != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(kdSxLaMNLKkkVUBVTRPLZXsJHFzt);
					kdSxLaMNLKkkVUBVTRPLZXsJHFzt = IntPtr.Zero;
				}
			}
		}
	}
}
