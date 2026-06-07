using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class ptDAZOMgYivncCYMdWwaXadwMfL<_0001> : IDisposable where _0001 : struct
{
	private static readonly int emSSCqVmfGFDPcDBYbZEPuHFAXpn = Marshal.SizeOf(typeof(_0001));

	private GhZlVkTHikiQVkHTKPgKHUKBJNyUb GLIIxNDzkfkUnFqvpGGCFvmwFRlDb;

	private bool zyIaXeXytmZgkWTHVLqcUUVeOcNL;

	public GhZlVkTHikiQVkHTKPgKHUKBJNyUb vUAXvPDLVxGlQdUqLBWTVRmoHuFGA => GLIIxNDzkfkUnFqvpGGCFvmwFRlDb;

	public bool TugHMjomgzKNNBIZQZmzljNsfyzy
	{
		get
		{
			if (GLIIxNDzkfkUnFqvpGGCFvmwFRlDb != null)
			{
				return GLIIxNDzkfkUnFqvpGGCFvmwFRlDb.YSSxgaImOklYZpafogNhItelQMlJ != IntPtr.Zero;
			}
			return false;
		}
	}

	public unsafe _0001 NBmCWVHOCQkVZZqJiqCbATHxvSeq
	{
		get
		{
			iopDYXfnxwYSmNLrbshaPYhdTjkwA();
			return Unsafe.Read<_0001>((void*)GLIIxNDzkfkUnFqvpGGCFvmwFRlDb.YSSxgaImOklYZpafogNhItelQMlJ);
		}
		set
		{
			iopDYXfnxwYSmNLrbshaPYhdTjkwA();
			_0001* ptr = &val;
			GLIIxNDzkfkUnFqvpGGCFvmwFRlDb.xcjrJitMJrIbfNjWpEOUAlrqgPkX((IntPtr)ptr, emSSCqVmfGFDPcDBYbZEPuHFAXpn, emSSCqVmfGFDPcDBYbZEPuHFAXpn);
		}
	}

	public ptDAZOMgYivncCYMdWwaXadwMfL()
	{
		GLIIxNDzkfkUnFqvpGGCFvmwFRlDb = new GhZlVkTHikiQVkHTKPgKHUKBJNyUb(emSSCqVmfGFDPcDBYbZEPuHFAXpn);
	}

	private void iCsfkUXgVoSVCEQZPbCnKdkitIINA()
	{
		if (GLIIxNDzkfkUnFqvpGGCFvmwFRlDb == null)
		{
			GLIIxNDzkfkUnFqvpGGCFvmwFRlDb.Dispose();
			GLIIxNDzkfkUnFqvpGGCFvmwFRlDb = null;
		}
	}

	private void iopDYXfnxwYSmNLrbshaPYhdTjkwA()
	{
		if (!TugHMjomgzKNNBIZQZmzljNsfyzy)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void MnBKiEyZtYkwTsOnRoalchFJINYkA(bool P_0)
	{
		if (!zyIaXeXytmZgkWTHVLqcUUVeOcNL)
		{
			if (P_0)
			{
				iCsfkUXgVoSVCEQZPbCnKdkitIINA();
			}
			zyIaXeXytmZgkWTHVLqcUUVeOcNL = true;
		}
	}

	public void Dispose()
	{
		MnBKiEyZtYkwTsOnRoalchFJINYkA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
