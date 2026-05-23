using System;
using Rewired.Utils;

internal class BTHrwIBgxFqazDintdmlgnJdIAF : IDisposable
{
	private readonly WwcwFFXrcgizEHXRtCqRIUJLIniV RlrDFPWlIVBjihBXNSARRWgibHv;

	private readonly int BasRbumEneSBEIsoVbcyXDWkoSf;

	private long mcQBefdLVSuUfUMZSwkLHAnWxrc;

	private long foOshOQvlXmVhQwIaKmQwkIhaCZ;

	private int hAzJSaTBPbrMVGpHWQzmNWMMRWr;

	private bool XLmcwNNZwcqMONhvmdHhnCVeaEY;

	private uint QkcPYHPVLyjnOUeCxHeriLduVxfe;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public int Capacity
	{
		get
		{
			return BasRbumEneSBEIsoVbcyXDWkoSf;
		}
	}

	public int BytesInBuffer
	{
		get
		{
			return hAzJSaTBPbrMVGpHWQzmNWMMRWr;
		}
	}

	public bool BufferOverrun
	{
		get
		{
			return XLmcwNNZwcqMONhvmdHhnCVeaEY;
		}
	}

	public BTHrwIBgxFqazDintdmlgnJdIAF(int capacity)
	{
		BasRbumEneSBEIsoVbcyXDWkoSf = capacity;
		if (capacity <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		RlrDFPWlIVBjihBXNSARRWgibHv = new WwcwFFXrcgizEHXRtCqRIUJLIniV(capacity);
	}

	public unsafe int mszIJNECfxEuJZasPAYwzZDCgpx(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)mcQBefdLVSuUfUMZSwkLHAnWxrc;
		P_4 = QkcPYHPVLyjnOUeCxHeriLduVxfe;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = RlrDFPWlIVBjihBXNSARRWgibHv.oXchfZSLmtNkbNnHlTJqYQvNcJW(P_0, P_1, P_2, (int)mcQBefdLVSuUfUMZSwkLHAnWxrc);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += RlrDFPWlIVBjihBXNSARRWgibHv.oXchfZSLmtNkbNnHlTJqYQvNcJW(P_0 + num, P_1 - num, P_2 - num);
		}
		BzypfrcNoSWHlJZNmTSOWWxFRNm(num);
		return num;
	}

	public unsafe int mszIJNECfxEuJZasPAYwzZDCgpx(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)mcQBefdLVSuUfUMZSwkLHAnWxrc;
			P_4 = QkcPYHPVLyjnOUeCxHeriLduVxfe;
			return 0;
		}
		return mszIJNECfxEuJZasPAYwzZDCgpx((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int mszIJNECfxEuJZasPAYwzZDCgpx(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)mcQBefdLVSuUfUMZSwkLHAnWxrc;
			P_3 = QkcPYHPVLyjnOUeCxHeriLduVxfe;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return mszIJNECfxEuJZasPAYwzZDCgpx(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int mszIJNECfxEuJZasPAYwzZDCgpx(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return mszIJNECfxEuJZasPAYwzZDCgpx(P_0, P_1, P_2, out num, out num2);
	}

	public int mszIJNECfxEuJZasPAYwzZDCgpx(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return mszIJNECfxEuJZasPAYwzZDCgpx(P_0, P_1, P_2, out num, out num2);
	}

	public int mszIJNECfxEuJZasPAYwzZDCgpx(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return mszIJNECfxEuJZasPAYwzZDCgpx(P_0, P_1, out num, out num2);
	}

	public unsafe int NanoMDSNERLILwGbZOVIzaIWByQA(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || hAzJSaTBPbrMVGpHWQzmNWMMRWr == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > hAzJSaTBPbrMVGpHWQzmNWMMRWr)
		{
			P_2 = hAzJSaTBPbrMVGpHWQzmNWMMRWr;
		}
		int num = RlrDFPWlIVBjihBXNSARRWgibHv.WZbANmUdaBabMjcRyqxSFuUdMeDZ(P_0, P_1, P_2, (int)foOshOQvlXmVhQwIaKmQwkIhaCZ);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += RlrDFPWlIVBjihBXNSARRWgibHv.WZbANmUdaBabMjcRyqxSFuUdMeDZ(P_0 + num, P_1 - num, P_2 - num);
		}
		dSegqAbNuchGJlCuqOmgjLpWvTrr(num);
		return num;
	}

	public unsafe int NanoMDSNERLILwGbZOVIzaIWByQA(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return NanoMDSNERLILwGbZOVIzaIWByQA(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int NanoMDSNERLILwGbZOVIzaIWByQA(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return NanoMDSNERLILwGbZOVIzaIWByQA((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int yOFSIdBTmOCZgHOejreZhfdhCWn(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || hAzJSaTBPbrMVGpHWQzmNWMMRWr == 0 || P_3 < 0 || P_3 >= BasRbumEneSBEIsoVbcyXDWkoSf)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > hAzJSaTBPbrMVGpHWQzmNWMMRWr)
		{
			P_2 = hAzJSaTBPbrMVGpHWQzmNWMMRWr;
		}
		int num = RlrDFPWlIVBjihBXNSARRWgibHv.WZbANmUdaBabMjcRyqxSFuUdMeDZ(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += RlrDFPWlIVBjihBXNSARRWgibHv.WZbANmUdaBabMjcRyqxSFuUdMeDZ(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int yOFSIdBTmOCZgHOejreZhfdhCWn(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return yOFSIdBTmOCZgHOejreZhfdhCWn(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int yOFSIdBTmOCZgHOejreZhfdhCWn(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return yOFSIdBTmOCZgHOejreZhfdhCWn((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool dVqgpUEVoGqAkyEaepBNdkHiJiHI(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= BasRbumEneSBEIsoVbcyXDWkoSf)
		{
			return false;
		}
		if (P_0 < mcQBefdLVSuUfUMZSwkLHAnWxrc)
		{
			if (P_1 == QkcPYHPVLyjnOUeCxHeriLduVxfe)
			{
				return true;
			}
		}
		else if (P_0 >= mcQBefdLVSuUfUMZSwkLHAnWxrc)
		{
			if (QkcPYHPVLyjnOUeCxHeriLduVxfe == 0)
			{
				return false;
			}
			if (QkcPYHPVLyjnOUeCxHeriLduVxfe - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void SyFZKnpdKtjKkalPwEnGerlPEmYq()
	{
		mcQBefdLVSuUfUMZSwkLHAnWxrc = 0L;
		foOshOQvlXmVhQwIaKmQwkIhaCZ = 0L;
		hAzJSaTBPbrMVGpHWQzmNWMMRWr = 0;
		XLmcwNNZwcqMONhvmdHhnCVeaEY = false;
		QkcPYHPVLyjnOUeCxHeriLduVxfe = 0u;
	}

	private void BzypfrcNoSWHlJZNmTSOWWxFRNm(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)mcQBefdLVSuUfUMZSwkLHAnWxrc;
		mcQBefdLVSuUfUMZSwkLHAnWxrc += P_0;
		bool flag = false;
		if (num < foOshOQvlXmVhQwIaKmQwkIhaCZ)
		{
			if (mcQBefdLVSuUfUMZSwkLHAnWxrc > foOshOQvlXmVhQwIaKmQwkIhaCZ)
			{
				flag = true;
			}
		}
		else if (num > foOshOQvlXmVhQwIaKmQwkIhaCZ)
		{
			if (mcQBefdLVSuUfUMZSwkLHAnWxrc - BasRbumEneSBEIsoVbcyXDWkoSf > foOshOQvlXmVhQwIaKmQwkIhaCZ)
			{
				flag = true;
			}
		}
		else if (hAzJSaTBPbrMVGpHWQzmNWMMRWr > 0)
		{
			flag = true;
		}
		if (flag)
		{
			XLmcwNNZwcqMONhvmdHhnCVeaEY = true;
			foOshOQvlXmVhQwIaKmQwkIhaCZ = mcQBefdLVSuUfUMZSwkLHAnWxrc;
			if (foOshOQvlXmVhQwIaKmQwkIhaCZ >= BasRbumEneSBEIsoVbcyXDWkoSf)
			{
				foOshOQvlXmVhQwIaKmQwkIhaCZ -= BasRbumEneSBEIsoVbcyXDWkoSf;
			}
		}
		if (mcQBefdLVSuUfUMZSwkLHAnWxrc >= BasRbumEneSBEIsoVbcyXDWkoSf)
		{
			mcQBefdLVSuUfUMZSwkLHAnWxrc -= BasRbumEneSBEIsoVbcyXDWkoSf;
			jHcBmONfVvFgDDCglEvzfuQdJzkw();
		}
		hAzJSaTBPbrMVGpHWQzmNWMMRWr = (int)MathTools.Clamp((long)hAzJSaTBPbrMVGpHWQzmNWMMRWr + (long)P_0, 0L, BasRbumEneSBEIsoVbcyXDWkoSf);
	}

	private void dSegqAbNuchGJlCuqOmgjLpWvTrr(int P_0)
	{
		if (P_0 > 0)
		{
			if (XLmcwNNZwcqMONhvmdHhnCVeaEY)
			{
				XLmcwNNZwcqMONhvmdHhnCVeaEY = false;
			}
			foOshOQvlXmVhQwIaKmQwkIhaCZ += P_0;
			if (foOshOQvlXmVhQwIaKmQwkIhaCZ >= BasRbumEneSBEIsoVbcyXDWkoSf)
			{
				foOshOQvlXmVhQwIaKmQwkIhaCZ -= BasRbumEneSBEIsoVbcyXDWkoSf;
			}
			long num = (long)hAzJSaTBPbrMVGpHWQzmNWMMRWr - (long)P_0;
			hAzJSaTBPbrMVGpHWQzmNWMMRWr = (int)((num >= 0) ? num : 0);
		}
	}

	private void jHcBmONfVvFgDDCglEvzfuQdJzkw()
	{
		if (QkcPYHPVLyjnOUeCxHeriLduVxfe == uint.MaxValue)
		{
			QkcPYHPVLyjnOUeCxHeriLduVxfe = 0u;
		}
		else
		{
			QkcPYHPVLyjnOUeCxHeriLduVxfe++;
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~BTHrwIBgxFqazDintdmlgnJdIAF()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			if (P_0 && RlrDFPWlIVBjihBXNSARRWgibHv != null)
			{
				RlrDFPWlIVBjihBXNSARRWgibHv.Dispose();
			}
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}
}
