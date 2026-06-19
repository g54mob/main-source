using System;
using System.Runtime.CompilerServices;

internal struct mNGsIvlLyceofikppBqdVtQuAhso
{
	public IntPtr LjvfuhORJgLCiwGYyiHqyWuCfjx;

	private IntPtr vjCqvTYCHacBRkBSLIhqgKQqlrm;

	private int kHDRWyHLYWVUjQGgdKlFlHEmbLF;

	public int OFUbnqgnTEObJNgzZhMUjQRqSuLP;

	public int vrUgZnbMlYERXMlYNGcJMwxzdSsC;

	internal bool IsValid
	{
		get
		{
			if (kHDRWyHLYWVUjQGgdKlFlHEmbLF > 0)
			{
				return vjCqvTYCHacBRkBSLIhqgKQqlrm != IntPtr.Zero;
			}
			return false;
		}
	}

	public IntPtr RawDataPtr => vjCqvTYCHacBRkBSLIhqgKQqlrm;

	public int RawDataBytes => kHDRWyHLYWVUjQGgdKlFlHEmbLF;

	internal unsafe mNGsIvlLyceofikppBqdVtQuAhso(ref dyBuhgITgugHFQsBNbztydiZyDp rawInput, pVieCwJYaaGIqOpQiptUnLZEexYB memQueue)
	{
		LjvfuhORJgLCiwGYyiHqyWuCfjx = rawInput.uKgrmzWDMXdahjyvrfNpOFIMDQxc.LjvfuhORJgLCiwGYyiHqyWuCfjx;
		OFUbnqgnTEObJNgzZhMUjQRqSuLP = rawInput.gkSLMNIyLcKlncULGDGOWrfGLDs.UCBLZCTVNCCNBSyJySskcykeRHj.OFUbnqgnTEObJNgzZhMUjQRqSuLP;
		vrUgZnbMlYERXMlYNGcJMwxzdSsC = rawInput.gkSLMNIyLcKlncULGDGOWrfGLDs.UCBLZCTVNCCNBSyJySskcykeRHj.AsjNnPRWwbsvsVyWXLhZZhtYNEy;
		kHDRWyHLYWVUjQGgdKlFlHEmbLF = OFUbnqgnTEObJNgzZhMUjQRqSuLP * vrUgZnbMlYERXMlYNGcJMwxzdSsC;
		if (kHDRWyHLYWVUjQGgdKlFlHEmbLF > 0)
		{
			fixed (IntPtr* zFxHGYzJRvcrWEIgsDZpxpHScVXd = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref rawInput.gkSLMNIyLcKlncULGDGOWrfGLDs.UCBLZCTVNCCNBSyJySskcykeRHj.zFxHGYzJRvcrWEIgsDZpxpHScVXd))
			{
				vjCqvTYCHacBRkBSLIhqgKQqlrm = memQueue.zkwAQVnfzqfJaCfPOplLVkfflWk((uint)kHDRWyHLYWVUjQGgdKlFlHEmbLF, zFxHGYzJRvcrWEIgsDZpxpHScVXd);
			}
		}
		else
		{
			vjCqvTYCHacBRkBSLIhqgKQqlrm = IntPtr.Zero;
		}
	}
}
