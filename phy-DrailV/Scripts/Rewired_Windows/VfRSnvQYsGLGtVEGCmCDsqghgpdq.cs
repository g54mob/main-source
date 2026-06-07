using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class VfRSnvQYsGLGtVEGCmCDsqghgpdq : KhpAjhNKlrKeefViVonIWJnYNnTN<lKEQBlvCUBCTfQIySCOmfaajsKEz, iPzJqQkGzeGnECWWJpTANYjFgsARA>
{
	[CompilerGenerated]
	private int dZabFsRGnpVWBVumOFLCaxhIgDWb;

	[CompilerGenerated]
	private int eDDEkypSWHCJXjJYbwkFuqDOBjQx;

	[CompilerGenerated]
	private int OVULDvColNcQWktlvDDooItIpmIU;

	[CompilerGenerated]
	private bool[] mEQCYglkAxshDkIjSEKzHyFtKFDCA;

	public int XHAcjfYHxobupnkeqiFjdRtqsftl
	{
		[CompilerGenerated]
		get
		{
			return dZabFsRGnpVWBVumOFLCaxhIgDWb;
		}
		[CompilerGenerated]
		set
		{
			dZabFsRGnpVWBVumOFLCaxhIgDWb = num;
		}
	}

	public int hOOUxyzjPSHmCugYimIocEeoCnOZ
	{
		[CompilerGenerated]
		get
		{
			return eDDEkypSWHCJXjJYbwkFuqDOBjQx;
		}
		[CompilerGenerated]
		set
		{
			eDDEkypSWHCJXjJYbwkFuqDOBjQx = num;
		}
	}

	public int nXGdfezugKPnijHxPqSGMXNvieeu
	{
		[CompilerGenerated]
		get
		{
			return OVULDvColNcQWktlvDDooItIpmIU;
		}
		[CompilerGenerated]
		set
		{
			OVULDvColNcQWktlvDDooItIpmIU = oVULDvColNcQWktlvDDooItIpmIU;
		}
	}

	public bool[] syxPbhBJItzVAVLveDKeKXtdjmVVA
	{
		[CompilerGenerated]
		get
		{
			return mEQCYglkAxshDkIjSEKzHyFtKFDCA;
		}
		[CompilerGenerated]
		private set
		{
			mEQCYglkAxshDkIjSEKzHyFtKFDCA = array;
		}
	}

	public VfRSnvQYsGLGtVEGCmCDsqghgpdq()
	{
		syxPbhBJItzVAVLveDKeKXtdjmVVA = new bool[8];
	}

	public void Update(iPzJqQkGzeGnECWWJpTANYjFgsARA P_0)
	{
		int num = P_0.FDBmjDDgHCcvdcHTOcawfGeHrHhqA;
		switch (P_0.FIXJlAqlRgoiIHjRrhRdWyuxzSAC)
		{
		case mCzZnuiAjxPpUZWzftOHdXlCNopW.X:
			XHAcjfYHxobupnkeqiFjdRtqsftl = num;
			return;
		case mCzZnuiAjxPpUZWzftOHdXlCNopW.Y:
			hOOUxyzjPSHmCugYimIocEeoCnOZ = num;
			return;
		case mCzZnuiAjxPpUZWzftOHdXlCNopW.Z:
			nXGdfezugKPnijHxPqSGMXNvieeu = num;
			return;
		}
		int num2 = (int)(P_0.FIXJlAqlRgoiIHjRrhRdWyuxzSAC - 12);
		if (num2 >= 0 && num2 < 8)
		{
			syxPbhBJItzVAVLveDKeKXtdjmVVA[num2] = (num & 0x80) != 0;
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		lKEQBlvCUBCTfQIySCOmfaajsKEz* ptr = (lKEQBlvCUBCTfQIySCOmfaajsKEz*)(void*)P_0;
		XHAcjfYHxobupnkeqiFjdRtqsftl = ptr->XHAcjfYHxobupnkeqiFjdRtqsftl;
		hOOUxyzjPSHmCugYimIocEeoCnOZ = ptr->hOOUxyzjPSHmCugYimIocEeoCnOZ;
		nXGdfezugKPnijHxPqSGMXNvieeu = ptr->nXGdfezugKPnijHxPqSGMXNvieeu;
		void* ptr2 = &ptr->LRXTPwczTwQAczfEBciNBydshApdA;
		fixed (bool* ptr3 = syxPbhBJItzVAVLveDKeKXtdjmVVA)
		{
			for (int i = 0; i < 8; i++)
			{
				ptr3[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", XHAcjfYHxobupnkeqiFjdRtqsftl, hOOUxyzjPSHmCugYimIocEeoCnOZ, nXGdfezugKPnijHxPqSGMXNvieeu, egeTdzIGHudlgfKlEvWOdRMMLrIl.bHIzBJRRlInpNDkEXBvKBHXNpuXb(";", syxPbhBJItzVAVLveDKeKXtdjmVVA));
	}
}
