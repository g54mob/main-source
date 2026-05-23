using System;
using System.Runtime.InteropServices;

internal class tRYyuqvNaAroIkduxNnmcDdOaen : IDisposable
{
	private int cIUnrLZhlfvJRUVUIpMRzChRCuL;

	private uint lqTmJvWoCjJVTvmDeCmOJTAiWOQ;

	private IntPtr GuSepRlszNWLGUQZojdJnkODcyu;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public tRYyuqvNaAroIkduxNnmcDdOaen(uint size)
	{
		if (size == 0)
		{
			throw new Exception("size must be > 0!");
		}
		lqTmJvWoCjJVTvmDeCmOJTAiWOQ = size;
		cIUnrLZhlfvJRUVUIpMRzChRCuL = 0;
		try
		{
			GuSepRlszNWLGUQZojdJnkODcyu = Marshal.AllocHGlobal((int)size);
			if (GuSepRlszNWLGUQZojdJnkODcyu == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr vcQVsNQJjICkKZlvTwHrmCNfVZD(uint P_0, void* P_1)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > lqTmJvWoCjJVTvmDeCmOJTAiWOQ)
		{
			return IntPtr.Zero;
		}
		if (cIUnrLZhlfvJRUVUIpMRzChRCuL + P_0 >= lqTmJvWoCjJVTvmDeCmOJTAiWOQ)
		{
			cIUnrLZhlfvJRUVUIpMRzChRCuL = 0;
		}
		IntPtr intPtr = new IntPtr(GuSepRlszNWLGUQZojdJnkODcyu.ToInt64() + cIUnrLZhlfvJRUVUIpMRzChRCuL);
		WISJwItoxlmpVJIyUeIxBJGahMp.paUzUKGciuAmJnjIrFfoiXQPbNEU(intPtr, (IntPtr)P_1, (int)P_0);
		cIUnrLZhlfvJRUVUIpMRzChRCuL += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~tRYyuqvNaAroIkduxNnmcDdOaen()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
			if (GuSepRlszNWLGUQZojdJnkODcyu != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(GuSepRlszNWLGUQZojdJnkODcyu);
			}
		}
	}
}
